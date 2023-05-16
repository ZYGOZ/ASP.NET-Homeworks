using System.Net;
using System.Text;
using WebServer;
using WebServer.Services;

var host = new WebHost(5050);

host?.UseStartup<Startup>();

host?.Start();

