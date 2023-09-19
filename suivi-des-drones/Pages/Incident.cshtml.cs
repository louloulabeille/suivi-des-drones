using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace suivi_des_drones.Pages
{
    public class IncidentModel : PageModel
    {
        public JsonResult OnGet()
        {
            return new JsonResult(new List<int>() { 1,2,5,9,7});
        }
    }
}
