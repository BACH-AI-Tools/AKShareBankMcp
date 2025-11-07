using InterestRateMcp.tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterestRateMcp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestToolController : ControllerBase
    {
        private readonly RateTool _tool;

        public TestToolController(IHttpClientFactory httpClientFactory)
        {
            _tool = new RateTool(httpClientFactory);
        }

        [HttpGet("get_macro_bank_usa_interest_rate")]
        public async Task<IActionResult> get_macro_bank_usa_interest_rate()
        {
            var result = await _tool.get_macro_bank_usa_interest_rate();
            return Content(result, "application/json");
        }

        [HttpGet("get_macro_bank_euro_interest_rate")]
        public async Task<IActionResult> get_macro_bank_euro_interest_rate()
        {
            var result = await _tool.get_macro_bank_euro_interest_rate();
            return Content(result, "application/json");
        }

        [HttpGet("get_macro_bank_newzealand_interest_rate")]
        public async Task<IActionResult> get_macro_bank_newzealand_interest_rate()
        {
            var result = await _tool.get_macro_bank_newzealand_interest_rate();
            return Content(result, "application/json");
        }

        [HttpGet("get_macro_bank_china_interest_rate")]
        public async Task<IActionResult> get_macro_bank_china_interest_rate()
        {
            var result = await _tool.get_macro_bank_china_interest_rate();
            return Content(result, "application/json");
        }

        [HttpGet("get_macro_bank_switzerland_interest_rate")]
        public async Task<IActionResult> get_macro_bank_switzerland_interest_rate()
        {
            var result = await _tool.get_macro_bank_switzerland_interest_rate();
            return Content(result, "application/json");
        }

        [HttpGet("get_macro_bank_english_interest_rate")]
        public async Task<IActionResult> get_macro_bank_english_interest_rate()
        {
            var result = await _tool.get_macro_bank_english_interest_rate();
            return Content(result, "application/json");
        }

        [HttpGet("get_macro_bank_australia_interest_rate")]
        public async Task<IActionResult> get_macro_bank_australia_interest_rate()
        {
            var result = await _tool.get_macro_bank_australia_interest_rate();
            return Content(result, "application/json");
        }

        [HttpGet("get_macro_bank_japan_interest_rate")]
        public async Task<IActionResult> get_macro_bank_japan_interest_rate()
        {
            var result = await _tool.get_macro_bank_japan_interest_rate();
            return Content(result, "application/json");
        }

        [HttpGet("get_macro_bank_russia_interest_rate")]
        public async Task<IActionResult> get_macro_bank_russia_interest_rate()
        {
            var result = await _tool.get_macro_bank_russia_interest_rate();
            return Content(result, "application/json");
        }

        [HttpGet("get_macro_bank_india_interest_rate")]
        public async Task<IActionResult> get_macro_bank_india_interest_rate()
        {
            var result = await _tool.get_macro_bank_india_interest_rate();
            return Content(result, "application/json");
        }

        [HttpGet("get_macro_bank_brazil_interest_rate")]
        public async Task<IActionResult> get_macro_bank_brazil_interest_rate()
        {
            var result = await _tool.get_macro_bank_brazil_interest_rate();
            return Content(result, "application/json");
        }

        [HttpGet("get_repo_rate_hist")]
        public async Task<IActionResult> get_repo_rate_hist([FromQuery] string start_date = "", [FromQuery] string end_date = "")
        {
            var result = await _tool.get_repo_rate_hist(start_date, end_date);
            return Content(result, "application/json");
        }

        [HttpGet("get_repo_rate_query")]
        public async Task<IActionResult> get_repo_rate_query([FromQuery] string symbol = "")
        {
            var result = await _tool.get_repo_rate_query(symbol);
            return Content(result, "application/json");
        }

    }
}
