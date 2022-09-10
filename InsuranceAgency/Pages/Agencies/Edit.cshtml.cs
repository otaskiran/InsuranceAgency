using InsuranceAgency.Core;
using InsuranceAgency.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InsuranceAgency.Pages.Agencies
{
    public class EditModel : PageModel
    {
        private readonly IAgencyData agencyData;
        private readonly IHtmlHelper htmlHelper;

        public Agency Agency { get; set; }
        public IEnumerable<SelectListItem> AgencyTypes { get; set; }

        public EditModel(IAgencyData agencyData, IHtmlHelper htmlHelper )
        {
            this.agencyData = agencyData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int agencyId)
        {
            AgencyTypes = htmlHelper.GetEnumSelectList<AgencyType>();
            Agency = agencyData.GetById(agencyId);
            if (Agency==null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        } 
    }
}
