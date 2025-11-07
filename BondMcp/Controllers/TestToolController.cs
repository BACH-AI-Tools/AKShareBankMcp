using BondMcp.tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BondMcp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestToolController : ControllerBase
    {
        private readonly BondTool _tool;

        public TestToolController(IHttpClientFactory httpClientFactory)
        {
            _tool = new BondTool(httpClientFactory);
        }

        [HttpGet("get_bond_cash_summary_sse")]
        public async Task<IActionResult> get_bond_cash_summary_sse([FromQuery] string date = "")
        {
            var result = await _tool.get_bond_cash_summary_sse(date);
            return Content(result, "application/json");
        }

        [HttpGet("get_bond_deal_summary_sse")]
        public async Task<IActionResult> get_bond_deal_summary_sse([FromQuery] string date = "")
        {
            var result = await _tool.get_bond_deal_summary_sse(date);
            return Content(result, "application/json");
        }

        [HttpGet("get_bond_debt_nafmii")]
        public async Task<IActionResult> get_bond_debt_nafmii([FromQuery] string page = "1")
        {
            var result = await _tool.get_bond_debt_nafmii(page);
            return Content(result, "application/json");
        }

        [HttpGet("get_bond_spot_quote")]
        public async Task<IActionResult> get_bond_spot_quote()
        {
            var result = await _tool.get_bond_spot_quote();
            return Content(result, "application/json");
        }

        [HttpGet("get_bond_spot_deal")]
        public async Task<IActionResult> get_bond_spot_deal()
        {
            var result = await _tool.get_bond_spot_deal();
            return Content(result, "application/json");
        }

        [HttpGet("get_bond_china_yield")]
        public async Task<IActionResult> get_bond_china_yield([FromQuery] string start_date = "", [FromQuery] string end_date = "")
        {
            var result = await _tool.get_bond_china_yield(start_date, end_date);
            return Content(result, "application/json");
        }

        [HttpGet("get_bond_zh_us_rate")]
        public async Task<IActionResult> get_bond_zh_us_rate([FromQuery] string start_date = "")
        {
            var result = await _tool.get_bond_zh_us_rate(start_date);
            return Content(result, "application/json");
        }

        [HttpGet("get_bond_treasure_issue_cninfo")]
        public async Task<IActionResult> get_bond_treasure_issue_cninfo([FromQuery] string start_date = "", [FromQuery] string end_date = "")
        {
            var result = await _tool.get_bond_treasure_issue_cninfo(start_date, end_date);
            return Content(result, "application/json");
        }

    }
}
