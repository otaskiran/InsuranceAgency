using InsuranceAgency.Core;
using InsuranceAgency.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InsuranceAgency.Pages.Agencies
{
    public class DetailModel : PageModel
    {
        public Agency Agency { get; set; }
        private readonly IAgencyData AgencyData;

        public DetailModel(IAgencyData agencyData)
        {
            this.AgencyData = agencyData;
        }
        public IActionResult OnGet(int agencyId)
        {
            Agency = AgencyData.GetById(agencyId);
            if (Agency==null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}
