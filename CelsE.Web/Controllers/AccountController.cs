namespace CelsE.Web.Controllers
{
    using CelsE.Web.Helpers;
    using CelsE.Web.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using System.Threading.Tasks;

    public class AccountController : Controller
    {
        #region Propiedades
        private readonly IUserHelper userHelper;
        #endregion

        #region Constructores
        public AccountController(IUserHelper userHelper)
        {
            this.userHelper = userHelper;
        }
        #endregion

        #region Métodos
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await userHelper.LoginAsync(model);
                if (result.Succeeded)
                {
                    if (Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return Redirect(Request.Query["ReturnUrl"].First());
                    }

                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError(string.Empty, "Usuario y/o contraseña erróneo");
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await userHelper.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }
        #endregion
    }
}
