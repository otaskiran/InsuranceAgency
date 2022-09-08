using InsuranceAgency.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InsuranceAgency.Pages.Agencies
{
    public class DetailModel : PageModel
    {
        public Agency Agency { get; set; }
        public void OnGet(int agencyId)
        {
            Agency = new Agency();
            Agency.Id = agencyId;
        }
    }
}
