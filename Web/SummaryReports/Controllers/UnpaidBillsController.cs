using Hub.API.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Report.WebUI.Interfaces;
using System.Threading.Tasks;

namespace Report.WebUI.Controllers
{
    public class UnpaidBillsController : Controller
    {
        private readonly ILogger<UnpaidBillsController> _logger;
        private readonly ISummaryReportService _service;
        private const ApiCategory UNPAID_BILLS_API = ApiCategory.UnpaidBills;

        public UnpaidBillsController(ILogger<UnpaidBillsController> logger, ISummaryReportService service)
        {
            _logger = logger;
            _service = service;
        }
        public async Task<IActionResult> Five_Users_Hit_To_Server_In_Duration_Of_10_Mins_Summary()
        {
            var scenario = "Unpaid_Bills_5_Users_Hit_To_Server_In_Duration_Of_10_Mins";

            var datapoint = await _service.GetSummaryReportDataPoints(scenario, 5, UNPAID_BILLS_API);
            ViewBag.datapoint = JsonConvert.SerializeObject(datapoint);
            return View("~/Views/Home/Report.cshtml");
        }

        public async Task<IActionResult> A_Hundred_Users_Hit_To_Server_Ramp_Up_Ramp_Down_To_25_Users_Summary()
        {
            var scenario = "Unpaid_Bills_100_Users_Hit_To_Server_Ramp_Up_Ramp_Down_To_25_Users";

            var datapoint = await _service.GetSummaryReportDataPoints(scenario, 5, UNPAID_BILLS_API);
            ViewBag.datapoint = JsonConvert.SerializeObject(datapoint);
            return View("~/Views/Home/Report.cshtml");
        }
    }
}
