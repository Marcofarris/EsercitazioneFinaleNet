using EsercitazioneFinale.Models;
using Microsoft.AspNetCore.Mvc;

namespace EsercitazioneFinale.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login(bool showerror)
        {
            if (HttpContext.Session.GetString("LogSession") != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(new UserLogin(showerror));
        }
        [HttpPost]
        public IActionResult Login(User u)
        {
            var result = DB.Login(u.UserName, u.Password);
            if (result != "0")
            {
                HttpContext.Session.SetString("LogSession", result);
            }
            else
            {
                HttpContext.Session.Remove("LogSession");
                return RedirectToAction("Login", new { showerror = true });
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
