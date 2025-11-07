using CurrencyMcp.tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyMcp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestToolController : ControllerBase
    {
        private readonly CurrencyTool _tool;

        public TestToolController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _tool = new CurrencyTool(httpClientFactory, configuration);
        }

        [HttpGet("get_currency_latest")]
        public async Task<IActionResult> get_currency_latest(
            [FromQuery] string base_ = "USD",
            [FromQuery] string symbols = ""
            )
        {
            var result = await _tool.get_currency_latest(base_, symbols);
            return Content(result, "application/json");
        }

        [HttpGet("get_currency_history")]
        public async Task<IActionResult> get_currency_history(
            [FromQuery] string base_ = "USD",
            [FromQuery] string date = "",
            [FromQuery] string symbols = ""
            )
        {
            var result = await _tool.get_currency_history(base_, date, symbols);
            return Content(result, "application/json");
        }

        [HttpGet("get_currency_time_series")]
        public async Task<IActionResult> get_currency_time_series(
            [FromQuery] string base_ = "USD",
            [FromQuery] string start_date = "",
            [FromQuery] string end_date = "",
            [FromQuery] string symbols = ""
            )
        {
            var result = await _tool.get_currency_time_series(base_, start_date, end_date, symbols);
            return Content(result, "application/json");
        }

        [HttpGet("get_currency_currencies")]
        public async Task<IActionResult> get_currency_currencies()
        {
            var result = await _tool.get_currency_currencies();
            return Content(result, "application/json");
        }

        [HttpGet("get_currency_convert")]
        public async Task<IActionResult> get_currency_convert(
            [FromQuery] string base_ = "USD",
            [FromQuery] string to = "",
            [FromQuery] string amount = ""
            )
        {
            var result = await _tool.get_currency_convert(base_, to, amount);
            return Content(result, "application/json");
        }
    }
}
