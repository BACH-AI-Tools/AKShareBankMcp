using BankMcp.tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace BankMcp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestToolController : ControllerBase
    {
        private readonly BankTool _tool;

        public TestToolController(IHttpClientFactory httpClientFactory)
        {
            _tool = new BankTool(httpClientFactory);
        }


        [HttpGet("get_bank_fjcf_table_detail")]
        public async Task<IActionResult> get_bond_cash_summary_sse(
            [FromQuery] int page = 5,
            [FromQuery] string item = "分局本级",
            [FromQuery] int begin = 1)
        {
            var result = await _tool.get_bank_fjcf_table_detail(page, item, begin);
            return Content(result, "application/json");
        }
    }
}
