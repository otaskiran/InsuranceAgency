﻿using InsuranceAgency.Core;
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

        public IEnumerable<Agency> GetAgenciesByName(string name = null)
        {
            return from a in agencies
                   where string.IsNullOrEmpty(name) || a.Name.StartsWith(name)
                   orderby a.Name
                   select a;
        }
    }
}
