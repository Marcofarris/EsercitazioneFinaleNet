using EsercitazioneFinale.Filters;
using EsercitazioneFinale.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System.Diagnostics;

namespace EsercitazioneFinale.Controllers
{
    [AuthFilter]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var path = "https://gist.githubusercontent.com/hanse/4458506/raw/a702c19d07bd7693ee75efef18502c421b565949/phones.json";
            List<Phone> phoneList = new List<Phone>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(path))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    phoneList = JsonConvert.DeserializeObject<List<Phone>>(apiResponse);
                }
            }
            return View(phoneList);
        }

        public IActionResult Logout(bool? logout)
        {
            if (logout == true)
            {
                HttpContext.Session.Remove("LogSession");
                return RedirectToAction("Login", "Login");
            }
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}