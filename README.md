# SimpleWebServer

This project is just packaging up a gist published here :
https://gist.github.com/aksakalli/9191056

So that it can be run on Windows RT 8.1 devices.

While it can be used to serve up simple web sites, I have also modified it to correctly return the mime types needed for serving up a TridentSandbox web site with proper application cache, local storage and indexeddb.

By default, windows rt can serve up only to localhost.  You need to configure firewall for external computers to see your webserver.  Since Windows RT does not have a Windows Firewall control panel applet, you must utilize the command line.

**On Windows RT**, running an administrator command prompt you might disable windows firewall with this command :

```
netsh advfirewall set currprofile state off
```

To turn it back on you can run

```
netsh advfirewall set currprofile state off
```

More granular options might be found here :
https://support.microsoft.com/en-us/kb/947709

Once i determine a minimal syntax for a firewall 'rule' to open only a specific port, i will update this.