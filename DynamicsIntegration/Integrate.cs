using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicsIntegration
{
    public class Integrate : PluginImplementation
    {
        public override void ExecutePlugin(IServiceProvider serviceProvider)
        {
            IOrganizationService service = GetCrmService();

            if (service != null)
                throw new InvalidPluginExecutionException("Conexão realizada com sucesso");
            else
                throw new InvalidPluginExecutionException("Conexão não realizada");
        }
        public static IOrganizationService GetCrmService()
        {
            string connectionString =
                "AuthType=OAuth;" +
                "Username=grupo1@dynamics2G1.onmicrosoft.com;" +
                "Password=@dynamics2G1;" +
                "Url=https://org5eb90507.crm2.dynamics.com;" +
                "AppId=47a5208a-7f24-4862-b227-4149ed7eb05a;" +
                "RedirectUri=app://58145B91-0C36-4500-8554-080854F2AC97;";

            CrmServiceClient crmServiceClient = new CrmServiceClient(connectionString);
            return crmServiceClient.OrganizationWebProxyClient;
        }
    }
}
