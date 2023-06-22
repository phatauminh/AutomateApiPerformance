using Hub.API.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Report.WebUI.Interfaces;
using System.Threading.Tasks;

namespace Report.WebUI.Controllers
{
    public class FindPaymentPlanController : Controller
    {
        private readonly ILogger<FindPaymentPlanController> _logger;
        private readonly ISummaryReportService _service;
        private const ApiCategory FIND_PAYMENT_PLAN_API = ApiCategory.FindPaymentPlan;

        public FindPaymentPlanController(ILogger<FindPaymentPlanController> logger, ISummaryReportService service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task<IActionResult> Five_Users_Hit_To_Server_In_Duration_Of_10_Mins_Summary()
        {
            var scenario = "Find_Payment_Plan_5_Users_Hit_To_Server_In_Duration_Of_10_Mins";

            var datapoint = await _service.GetSummaryReportDataPoints(scenario, 5, FIND_PAYMENT_PLAN_API);
            ViewBag.datapoint = JsonConvert.SerializeObject(datapoint);
            return View("~/Views/Home/Report.cshtml");
        }

        public async Task<IActionResult> A_Hundred_Users_Hit_To_Server_Ramp_Up_Ramp_Down_To_25_Users_Summary()
        {
            var scenario = "Find_Payment_Plan_100_Users_Hit_To_Server_Ramp_Up_Ramp_Down_To_25_Users";

            var datapoint = await _service.GetSummaryReportDataPoints(scenario, 5, FIND_PAYMENT_PLAN_API);
            ViewBag.datapoint = JsonConvert.SerializeObject(datapoint);
            return View("~/Views/Home/Report.cshtml");
        }

    }
}
