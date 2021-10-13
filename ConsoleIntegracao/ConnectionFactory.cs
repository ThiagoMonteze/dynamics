using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleIntegracao
{
    public class ConnectionFactory
    {
        public static IOrganizationService GetCrmService() 
        {
            string connectionString =
                "AuthType=OAuth;" +
                "Username=projeto@grupo6FYI.onmicrosoft.com;" +
                "Password=Grp6FYI@;" +
                "Url=https://org2d122f28.crm2.dynamics.com/;" +
                "AppId=6d829124-d90d-458d-98ec-092b4fc9c1fc;" +
                "RedirectUri=app://58145B91-0C36-4500-8554-080854F2AC97;";

            CrmServiceClient crmServiceClient = new CrmServiceClient(connectionString);
            return crmServiceClient.OrganizationWebProxyClient;

          }
    }
}
