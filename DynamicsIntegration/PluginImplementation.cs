using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicsIntegration
{
    public abstract class PluginImplementation : IPlugin
    {
        public IPluginExecutionContext Context;
        public IOrganizationServiceFactory ServiceFactory;
        public IOrganizationService Service;
        public ITracingService TracingService;

        public void Execute(IServiceProvider serviceProvider)
        {
            Context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));            
            ServiceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));            
            Service = ServiceFactory.CreateOrganizationService(Context.UserId);            
            TracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));
            ExecutePlugin(serviceProvider);
        }
        public abstract void ExecutePlugin(IServiceProvider serviceProvider);
    }
}
