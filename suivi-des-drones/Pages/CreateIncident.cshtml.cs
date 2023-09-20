using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NuGet.Common;

namespace suivi_des_drones.Pages
{
    [Authorize]
    public class CreateIncidentModel : PageModel
    {
        #region Propriétés
        [BindProperty]
        public IFormFile? PictureFile { get; set; }

        private readonly IHostEnvironment _environment;
        private readonly ILogger<CreateIncidentModel> logger;
        #endregion

        #region Constructeur
        public CreateIncidentModel(ILogger<CreateIncidentModel> logger , IHostEnvironment environment)
        {
            this.logger = logger;
            _environment = environment;
        }
        #endregion

        #region méthode 
        public async Task<IActionResult> OnPost()
        {
            IActionResult result = Page();

            if ( PictureFile is not null )
            {
                using var file = new FileStream(_environment.ContentRootPath + "./" + PictureFile.FileName, FileMode.OpenOrCreate);
                await PictureFile.CopyToAsync(file);
            }
            

            return result;
        }

        public void OnGet()
        {
        }
        #endregion
    }
}
