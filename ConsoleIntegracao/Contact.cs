using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleIntegracao
{
    class Contact
    {
        public IOrganizationService Service { get; set; }

        public string TableName = "contact";
        
        public Contact(IOrganizationService service)
        {
            this.Service = service;
        }

        public EntityCollection RetrieveMultipleContactsByAccount(Guid accountId)
        {
            QueryExpression queryContacts = new QueryExpression(this.TableName);
            queryContacts.ColumnSet.AddColumns("fullname", "emailaddress1");
            queryContacts.Criteria.AddCondition("parentcustomerid", ConditionOperator.Equal, accountId);
            return this.Service.RetrieveMultiple(queryContacts);
        }
    }
}
