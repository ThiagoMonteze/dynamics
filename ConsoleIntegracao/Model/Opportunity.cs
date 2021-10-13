using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleIntegracao.Model
{
    public class Opportunity
    {
        public IOrganizationService Service { get; set; }

        public string TableName = "opportunity";

        public Opportunity(IOrganizationService service)
        {
            this.Service = service;
        }

        public object RetrieveMultipleInfoByOpportunityLinq(Guid opportunityid)
        {
            var context = new OrganizationServiceContext(this.Service);

            var resultado = (from opportunity in context.CreateQuery("opportunity")
                             where ((EntityReference)opportunity["opportunityid"]).Id == opportunityid
                             select new
                             {
                                 oportunidadeId = opportunity["opportunityid"].ToString(),
                                 oportunidadeNome = opportunity["name"].ToString(),
                                 valorDetalhado = ((Money)opportunity["totallineitemamount"]).Value,
                                 nivelCliente = ((EntityReference)opportunity["g6_descontoclinte"]).Name

                             }).ToList();

            Console.WriteLine("================================================================");

            foreach (var oportunidade in resultado)
            {
                Console.WriteLine($"Oportunidade número: {oportunidade.oportunidadeId}");
                Console.WriteLine(oportunidade.oportunidadeNome);
                Console.WriteLine($"Valor detalhado da oportuniade: R${oportunidade.valorDetalhado:F2}");
                Console.WriteLine($"Nível do cliente: {oportunidade.nivelCliente}");
                
                Console.WriteLine("================================================================");
                Console.WriteLine("Gostaria de atualizar o desconto? Y/N");
                var descontoAtualiza = Console.ReadLine();

                if (descontoAtualiza == "Y")
                {
                    if (oportunidade.nivelCliente == "ce10bdfb-4428-ec11-b6e6-002248372c6c")
                    {
                        Entity descontoOportunidade = new Entity(this.TableName);
                        descontoOportunidade.Id = new Guid(oportunidade.oportunidadeId);
                        descontoOportunidade["discountpercentage"] = "3";
                        this.Service.Update(descontoOportunidade);
                    }
                    else if (oportunidade.nivelCliente == "cae6b323-4528-ec11-b6e6-002248372c6c")
                    {
                        Entity descontoOportunidade = new Entity(this.TableName);
                        descontoOportunidade.Id = new Guid(oportunidade.oportunidadeId);
                        descontoOportunidade["discountpercentage"] = "5";
                        this.Service.Update(descontoOportunidade);
                    }
                    else if (oportunidade.nivelCliente == "1cacc929-4528-ec11-b6e6-002248372c6c")
                    {
                        Entity descontoOportunidade = new Entity(this.TableName);
                        descontoOportunidade.Id = new Guid(oportunidade.oportunidadeId);
                        descontoOportunidade["discountpercentage"] = "7";
                        this.Service.Update(descontoOportunidade);
                    }
                    else if (oportunidade.nivelCliente == "c3ba9234-4528-ec11-b6e6-002248372c6c")
                    {
                        Entity descontoOportunidade = new Entity(this.TableName);
                        descontoOportunidade.Id = new Guid(oportunidade.oportunidadeId);
                        descontoOportunidade["discountpercentage"] = "10";
                        this.Service.Update(descontoOportunidade);
                    }
                }
                else
                {
                    Console.WriteLine("Obrigado! Tenha um bom dia!");
                }



            }

            return resultado;
        }
    }

}






