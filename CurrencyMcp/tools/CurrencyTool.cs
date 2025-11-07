using AKToolApi;
using ModelContextProtocol.Server;
using System.ComponentModel;

namespace CurrencyMcp.tools
{

    [McpServerToolType]
    public class CurrencyTool
    {
        public const string prefixUrl = "/api/public";

        private string api_key = "";
        private readonly HttpClient _client;
        private IConfiguration _configuration;

        public CurrencyTool(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _client = httpClientFactory.CreateClient("aktoolApi");
            _configuration = configuration;
            api_key = _configuration["CurrencyToolApiKey"] ?? "";
        }

        [McpServerTool]
        [Description("查询指定货币的最新报价数据")]
        public async Task<string> get_currency_latest(
        [Description("base=\"USD\"; 基础货币")] string base_ = "USD",
        [Description("symbols=\"\"; 默认返回全部, 逗号分隔, 如 \"AUD,CNY\"")] string symbols = ""
)
        {
            string url = $"{prefixUrl}/currency_latest?base={base_}&symbols={symbols}&api_key={api_key}";
            var content = await AKToolApiHelper.GetStringAsync(_client, url);
            return content;
        }

        [McpServerTool]
        [Description("查询指定货币在指定交易日的报价历史数据")]
        public async Task<string> get_currency_history(
            [Description("base=\"USD\"; 基础货币")] string base_ = "USD",
            [Description("date=\"2023-02-03\"; 查询日期")] string date = "",
            [Description("symbols=\"\"; 默认返回全部, 逗号分隔, 如 \"AUD,CNY\"")] string symbols = ""
        )
        {
            string url = $"{prefixUrl}/currency_history?base={base_}&date={date}&symbols={symbols}&api_key={api_key}";
            var content = await AKToolApiHelper.GetStringAsync(_client, url);
            return content;
        }

        [McpServerTool]
        [Description("查询指定货币在指定交易日到另一指定交易日的报价数据")]
        public async Task<string> get_currency_time_series(
            [Description("base=\"USD\"; 基础货币")] string base_ = "USD",
            [Description("start_date=\"2023-02-03\"; 开始日期")] string start_date = "",
            [Description("end_date=\"2023-03-04\"; 结束日期")] string end_date = "",
            [Description("symbols=\"\"; 默认返回全部, 逗号分隔, 如 \"AUD,CNY\"")] string symbols = ""
        )
        {
            string url = $"{prefixUrl}/currency_time_series?base={base_}&start_date={start_date}&end_date={end_date}&symbols={symbols}&api_key={api_key}";
            var content = await AKToolApiHelper.GetStringAsync(_client, url);
            return content;
        }

        [McpServerTool]
        [Description("所有货币的基础信息")]
        public async Task<string> get_currency_currencies()
        {
            string url = $"{prefixUrl}/currency_currencies?c_type=&api_key={api_key}";
            var content = await AKToolApiHelper.GetStringAsync(_client, url);
            return content;
        }

        [McpServerTool]
        [Description("指定货币对指定货币数量的转换后价格")]
        public async Task<string> get_currency_convert(
            [Description("base=\"USD\"; 基础货币")] string base_ = "USD",
            [Description("to=\"CNY\"; 需要转换到的货币")] string to = "",
            [Description("amount=\"10000\"; 转换量")] string amount = ""
        )
        {
            string url = $"{prefixUrl}/currency_convert?base={base_}&to={to}&amount={amount}&api_key={api_key}";
            var content = await AKToolApiHelper.GetStringAsync(_client, url);
            return content;
        }
    }
}
