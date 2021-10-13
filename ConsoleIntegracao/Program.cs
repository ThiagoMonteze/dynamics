using ConsoleIntegracao.Model;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleIntegracao
{
    class Program
    {
        static void Main(string[] args)
        {
            IOrganizationService service = ConnectionFactory.GetCrmService();

            Opportunity opportunity = new Opportunity(service);

            Console.WriteLine("Digite o número da oportunidade.");
            var opportunityId = Console.ReadLine();

            opportunity.RetrieveMultipleInfoByOpportunityLinq(new Guid(opportunityId));

            

            Console.ReadKey();
        }


    }

}


