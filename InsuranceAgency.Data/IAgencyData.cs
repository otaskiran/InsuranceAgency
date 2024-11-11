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
        IEnumerable<Agency> GetAgenciesByName(string name);
        Agency GetById(int agencyId);
        Agency Update(Agency updatedAgency);
        int Commit();
    }

    public class InMemoryAgencyData : IAgencyData
    {
        List<Agency> agencies;
        public InMemoryAgencyData()
        {
            agencies = new List<Agency>()
            {
                new Agency { Id = 1, Name = "Agency A", Location = "Istanbul", AgencyType = AgencyType.Multiple },
                new Agency { Id = 2, Name = "Agency B", Location = "Bergen", AgencyType = AgencyType.Single },
                new Agency { Id = 3, Name = "Agency C", Location = "Oslo", AgencyType = AgencyType.None }
            };
        }

        public int Commit()
        {
            return 0;
        }

        public IEnumerable<Agency> GetAgenciesByName(string name = null)
        {
            return from a in agencies
                   where string.IsNullOrEmpty(name) || a.Name.StartsWith(name)
                   orderby a.Name
                   select a;
        }

        public Agency GetById(int agencyId)
        {
            return agencies.SingleOrDefault(a => a.Id == agencyId);
        }

        public Agency Update(Agency updatedAgency)
        {
            var agency = agencies.SingleOrDefault(a => a.Id == updatedAgency.Id);
            if (agencies != null)
            {
                agency.Name = updatedAgency.Name;
                agency.Location = updatedAgency.Location;
                agency.AgencyType = updatedAgency.AgencyType;
            }
            return agency;
        }


    }
}
