using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockMcp.tools;

namespace StockMcp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestToolController : ControllerBase
    {
        private readonly AShareTool _tool;

        public TestToolController(IHttpClientFactory httpClientFactory)
        {
            _tool = new AShareTool(httpClientFactory);
        }

        [HttpGet("get_stock_sse_summary")]
        public async Task<IActionResult> get_stock_sse_summary()
        {
            var result = await _tool.get_stock_sse_summary();
            return Content(result, "application/json");
        }

        [HttpGet("get_stock_sse_deal_daily")]
        public async Task<IActionResult> get_stock_sse_deal_daily([FromQuery] string date)
        {
            var result = await _tool.get_stock_sse_deal_daily(date);
            return Content(result, "application/json");
        }

        [HttpGet("get_stock_individual_info_em")]
        public async Task<IActionResult> get_stock_individual_info_em([FromQuery] string symbol)
        {
            var result = await _tool.get_stock_individual_info_em(symbol);
            return Content(result, "application/json");
        }

        [HttpGet("get_stock_zh_a_hist")]
        public async Task<IActionResult> get_stock_zh_a_hist(
            [FromQuery] string symbol,
            [FromQuery] string start_date,
            [FromQuery] string end_date,
            [FromQuery] string period = "daily",
            [FromQuery] string adjust = "")
        {
            var result = await _tool.get_stock_zh_a_hist(symbol, start_date, end_date, period, adjust);
            return Content(result, "application/json");
        }
    }
}
