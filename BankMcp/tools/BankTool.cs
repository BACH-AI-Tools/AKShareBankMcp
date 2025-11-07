using AKToolApi;
using ModelContextProtocol.Server;
using System.ComponentModel;

namespace BankMcp.tools
{
    [McpServerToolType]
    public class BankTool
    {
        public const string prefixUrl = "/api/public";

        private readonly HttpClient _client;

        public BankTool(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("aktoolApi");
        }

        [McpServerTool]
        [Description("银保监分局本级行政处罚中的指定页数的所有表格数据")]
        public async Task<string> get_bank_fjcf_table_detail(
          [Description("page=5; 获取前5页数据")] int page = 5,
             [Description("item=\"分局本级\"; choice of {\"机关\", \"本级\", \"分局本级\"}")] string item = "分局本级",
             [Description("开始页面")] int begin = 1
          )
        {
            string url = $"{prefixUrl}/bank_fjcf_table_detail?page={page}&item={item}&begin={begin}";
            var content = await AKToolApiHelper.GetStringAsync(_client, url);
            return content;
        }

    }
}
