using ForeignExchangeMcp.tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForeignExchangeMcp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestToolController : ControllerBase
    {
        private readonly ForeignExchangeTool _tool;

        public TestToolController(IHttpClientFactory httpClientFactory)
        {
            _tool = new ForeignExchangeTool(httpClientFactory);
        }

        [HttpGet("get_forex_spot_em")]
        public async Task<IActionResult> get_forex_spot_em()
        {
            var result = await _tool.get_forex_spot_em();
            return Content(result, "application/json");
        }

        [HttpGet("get_forex_hist_em")]
        public async Task<IActionResult> get_forex_hist_em([FromQuery] string symbol = "")
        {
            var result = await _tool.get_forex_hist_em(symbol);
            return Content(result, "application/json");
        }

        [HttpGet("get_currency_boc_sina")]
        public async Task<IActionResult> get_currency_boc_sina(
            [FromQuery] string symbol = "",
            [FromQuery] string start_date = "",
            [FromQuery] string end_date = "")
        {
            var result = await _tool.get_currency_boc_sina(symbol, start_date, end_date);
            return Content(result, "application/json");
        }


        [HttpGet("get_fx_spot_quote")]
        public async Task<IActionResult> get_fx_spot_quote()
        {
            var result = await _tool.get_fx_spot_quote();
            return Content(result, "application/json");
        }

        [HttpGet("get_fx_swap_quote")]
        public async Task<IActionResult> get_fx_swap_quote()
        {
            var result = await _tool.get_fx_swap_quote();
            return Content(result, "application/json");
        }

        [HttpGet("get_fx_pair_quote")]
        public async Task<IActionResult> get_fx_pair_quote()
        {
            var result = await _tool.get_fx_pair_quote();
            return Content(result, "application/json");
        }


        [HttpGet("get_macro_fx_sentiment")]
        public async Task<IActionResult> get_macro_fx_sentiment(
            [FromQuery] string start_date = "",
            [FromQuery] string end_date = "")
        {
            var result = await _tool.get_macro_fx_sentiment(start_date, end_date);
            return Content(result, "application/json");
        }

        [HttpGet("get_fx_quote_baidu")]
        public async Task<IActionResult> get_fx_quote_baidu([FromQuery] string symbol = "")
        {
            var result = await _tool.get_fx_quote_baidu(symbol);
            return Content(result, "application/json");
        }
    }
}
