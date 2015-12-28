using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace SimpleWebServer 
{
    /// <summary>
    /// Taken from gist at : https://gist.github.com/aksakalli/9191056
    /// </summary>
    class SimpleHTTPServer 
    {
        public readonly string[] _indexFiles = { 
            "index.html", 
            "index.htm", 
            "default.html", 
            "default.htm",
            "SandboxLoaderWJS.htm" 
        };

        private Thread _serverThread;
        private string _rootDirectory;
        private HttpListener _listener;
        private int _port;
        private bool localMode = true;
        private bool custom = false;
        private List<string> customPrefixes;

        public int Port
        {
            get { return _port; }
            private set { }
        }

        /// <summary>
        /// Construct server with given port.
        /// </summary>
        /// <param name="path">Directory path to serve.</param>
        /// <param name="port">Port of the server.</param>
        public SimpleHTTPServer(string path, int port)
        {
            this.Initialize(path, port);
        }

        /// <summary>
        /// Construct server with given port.
        /// </summary>
        /// <param name="path">Directory path to serve.</param>
        /// <param name="port">Port of the server.</param>
        /// <param name="local">Indicates whether this is loopback only server</param>
        public SimpleHTTPServer(string path, int port, bool local, bool custom, List<string> customPrefixes)
        {
            this.localMode = local;
            this.custom = custom;
            this.customPrefixes = customPrefixes;

            this.Initialize(path, port);
        }

        /// <summary>
        /// Construct server with suitable port.
        /// </summary>
        /// <param name="path">Directory path to serve.</param>
        public SimpleHTTPServer(string path)
        {
            //get an empty port
            TcpListener l = new TcpListener(IPAddress.Loopback, 0);
            l.Start();
            int port = ((IPEndPoint)l.LocalEndpoint).Port;
            l.Stop();
            this.Initialize(path, port);
        }

        /// <summary>
        /// Stop server and dispose all functions.
        /// </summary>
        public void Stop()
        {
            _serverThread.Abort();
            _listener.Stop();
        }

        private void Listen()
        {
            _listener = new HttpListener();

            // Allow user to override prefixes via config file
            if (this.custom) {
                foreach (string prefix in this.customPrefixes)
                {
                    _listener.Prefixes.Add(prefix);
                }
            }
            else
            {
                _listener.Prefixes.Add("http://" + (localMode?"localhost":"*") + ":" + _port.ToString() + "/");
            }

            _listener.Start();
            while (true)
            {
                try
                {
                    HttpListenerContext context = _listener.GetContext();
                    Process(context);
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void Process(HttpListenerContext context)
        {
            string filename = context.Request.Url.AbsolutePath;
            Console.WriteLine(filename);
            filename = filename.Substring(1);
            filename = filename.Replace("%20", " ");

            if (string.IsNullOrEmpty(filename))
            {
                foreach (string indexFile in _indexFiles)
                {
                    if (File.Exists(Path.Combine(_rootDirectory, indexFile)))
                    {
                        filename = indexFile;
                        break;
                    }
                }
            }

            filename = Path.Combine(_rootDirectory, filename);

            if (File.Exists(filename))
            {
                try
                {
                    Stream input = new FileStream(filename, FileMode.Open, FileAccess.Read);

                    //Adding permanent http response headers
                    string mime;

                    // since dictionary is no longer case insensitive, we should force lower casing everywhere
                    filename = filename.ToLower();

                    context.Response.ContentType = MainForm.formInstance.settings._mimeTypeMappings.TryGetValue(Path.GetExtension(filename), out mime) ? mime : "application/octet-stream";
                    context.Response.ContentLength64 = input.Length;
                    context.Response.AddHeader("Date", DateTime.Now.ToString("r"));
                    context.Response.AddHeader("Last-Modified", System.IO.File.GetLastWriteTime(filename).ToString("r"));
                    context.Response.AddHeader("X-Powered-By", "Simple Web Server");
                    
                    byte[] buffer = new byte[1024 * 16];
                    int nbytes;
                    while ((nbytes = input.Read(buffer, 0, buffer.Length)) > 0)
                        context.Response.OutputStream.Write(buffer, 0, nbytes);
                    input.Close();
                    context.Response.StatusCode = (int)HttpStatusCode.OK;
                    context.Response.OutputStream.Flush();
                }
                catch (Exception ex)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                }

            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            }

            context.Response.OutputStream.Close();
        }

        private void Initialize(string path, int port)
        {
            this._rootDirectory = path;
            this._port = port;
            _serverThread = new Thread(this.Listen);
            _serverThread.Start();
        }

    }
}
