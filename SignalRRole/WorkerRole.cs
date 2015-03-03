using System;
using System.Diagnostics;
using System.Net;
using System.Threading;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using Microsoft.Practices.Unity;
using Microsoft.WindowsAzure.ServiceRuntime;
using RailDataEngine.Core;

namespace SignalRRole
{
    public class WorkerRole : RoleEntryPoint
    {
        private IDisposable _app;
        private FeedListener _feedListener;
        private IUnityContainer _container;

        public override void Run()
        {
            Trace.TraceInformation("WorkerRole entry point called", "Information");

            _container = ContainerBuilder.Build();

            _feedListener = new FeedListener(GlobalHost.ConnectionManager.GetHubContext<RailDataHub>());

            var thread = new Thread(_feedListener.Listen);

            thread.Start();

            while (true)
            {
                Thread.Sleep(10000);
                Trace.TraceInformation("Working", "Information");
            }
        }

        public override bool OnStart()
        {
            ServicePointManager.DefaultConnectionLimit = 12;

            var endpoint = RoleEnvironment.CurrentRoleInstance.InstanceEndpoints["Default"];
            string baseUri = String.Format("{0}://{1}",
                endpoint.Protocol, endpoint.IPEndpoint);

            Trace.TraceInformation(String.Format("Starting OWIN at {0}", baseUri),
                "Information");

            _app = WebApp.Start<Startup>(new StartOptions(url: baseUri));
            return base.OnStart();
        }

        public override void OnStop()
        {
            if (_app != null)
            {
                _app.Dispose();
            }

            _feedListener.Stop();

            base.OnStop();
        }
    }
}