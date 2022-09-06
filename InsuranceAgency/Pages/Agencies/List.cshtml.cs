using InsuranceAgency.Core;
using InsuranceAgency.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InsuranceAgency.Pages.Agencies
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IAgencyData agencyData;

        public string Message { get; set; }
        public IEnumerable<Agency> Agencies { get; set; }

        public ListModel(IConfiguration config, IAgencyData agencyData)
        {
            this.Message = "";
            this.Agencies = new List<Agency>();
            this.config = config;
            this.agencyData = agencyData;
        }

        public void OnGet(string searchTerm)
        {
            Message = config["Message"];
            Agencies = agencyData.GetAgenciesByName(searchTerm);
        }
    }
}
