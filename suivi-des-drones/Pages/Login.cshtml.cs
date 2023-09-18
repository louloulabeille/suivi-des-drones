using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using suivi_des_drones.Core.Models;
using suivie_des_drones.Core.Application.Repository;
using suivie_des_drones.Cores.Interfaces;
using suivie_des_drones.Cores.Interfaces.Repository;

namespace suivi_des_drones.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ILogger _ilogger;
        private readonly IRepositoryLogin _loginRepository;

        [BindProperty]
        public Login _login { get; set; } = new Login();

        public LoginModel(ILogger<Login> logger, IRepositoryLogin loginRepository)
        {
            _ilogger = logger;
            _loginRepository = loginRepository;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            var retour = this.Page();

            try
            {
                if (ModelState.IsValid && _loginRepository is not null)
                {
                    Login login = _login;
                    if (_loginRepository.IsValidLoggin(ref login))
                    {
                        _login = login;
                        this.HttpContext.Session.SetInt32("UserId", _login.Id);
                        return RedirectToPage("Index");
                    }
                }
                
            }
            catch
            {

            }

            return retour;
        }

    }
}
