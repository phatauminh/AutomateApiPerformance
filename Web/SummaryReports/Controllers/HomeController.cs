using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Report.WebUI.Interfaces;
using Report.WebUI.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Report.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISummaryReportService _service;

        public HomeController(ILogger<HomeController> logger, ISummaryReportService service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Versions = await _service.GetVersions();
            return View();
        }

        public IActionResult Settings(string version,string reportSetting)
        {
            SharedSettings.Version = version;
            SharedSettings.Setting = reportSetting;
            return RedirectToAction("Index");
        }

        public IActionResult ResetSettings()
        {
            SharedSettings.Version = null;
            SharedSettings.Setting = null;
            return RedirectToAction("Index");
        }

        public IActionResult Report()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
