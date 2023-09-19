using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NuGet.Common;

namespace suivi_des_drones.Pages
{
    public class CreateIncidentModel : PageModel
    {
        #region Propri�t�s
        [BindProperty]
        public IFormFile PictureFile { get; set; } = default!;

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

        #region m�thode 
        public async Task<IActionResult> OnPost()
        {
            IActionResult result = Page();

            using var file = new FileStream(_environment.ContentRootPath+"./" + PictureFile.FileName, FileMode.OpenOrCreate);
            await PictureFile.CopyToAsync(file);

            return result;
        }

        public void OnGet()
        {
        }
        #endregion
    }
}
