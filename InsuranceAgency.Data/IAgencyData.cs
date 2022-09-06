using InsuranceAgency.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceAgency.Data
{
    public interface IAgencyData
    {
        IEnumerable<Agency> GetAll();
    }

    public class InMemoryAgencyData : IAgencyData
    {
        List<Agency> agencies;
        public InMemoryAgencyData()
        {
            agencies = new List<Agency>()
            {
                new Agency {Id = 1, Name = "Agency A", Location="Istanbul", AgencyType=AgencyType.Multiple},
                new Agency { Id = 2, Name = "Agency B", Location = "Bergen", AgencyType=AgencyType.Single }
            };
        }

        public IEnumerable<Agency> GetAll()
        {
            return from a in agencies
                   orderby a.Name
                   select a;
        }
    }
}
