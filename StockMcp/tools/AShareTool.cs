using AKToolApi;
using ModelContextProtocol.Server;
using System.ComponentModel;

namespace StockMcp.tools
{
    [McpServerToolType]
    public class AShareTool
    {
        public const string prefixUrl = "/api/public";

        private readonly HttpClient _client;

        public AShareTool(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("aktoolApi");
        }

        [McpServerTool]
        [Description("上海证券交易所股票数据总貌")]
        public async Task<string> get_stock_sse_summary()
        {
            string url = $"{prefixUrl}/stock_sse_summary";
            var content = await AKToolApiHelper.GetStringAsync(_client, url);
            return content;
        }

        [McpServerTool]
        [Description("上海证券交易所每日股票成交情况")]
        public async Task<string> get_stock_sse_deal_daily([Description("交易日期,数据格式为yyyyMMdd,例如：20250811")] string date)
        {
            string url = $"{prefixUrl}/stock_sse_deal_daily?date={date}";
            var content = await AKToolApiHelper.GetStringAsync(_client, url);
            return content;
        }

        [McpServerTool]
        [Description("东方财富-通过股票代码查询股票信息")]
        public async Task<string> get_stock_individual_info_em([Description("股票代码")] string symbol)
        {
            string url = $"{prefixUrl}/stock_individual_info_em?symbol={symbol}";
            var content = await AKToolApiHelper.GetStringAsync(_client, url);
            return content;
        }

        [McpServerTool]
        [Description("通过A股股票代码查询某只股票历史行情数据")]
        public async Task<string> get_stock_zh_a_hist(
            [Description("股票代码")] string symbol,
            [Description("开始查询的日期,数据格式为yyyyMMdd,例如20210301")] string start_date,
            [Description("结束查询的日期,数据格式为yyyyMMdd,例如20210308,")] string end_date,
            [Description("period='daily'; choice of {'daily', 'weekly', 'monthly'}")] string period = "daily",
            [Description("默认返回不复权的数据; qfq: 返回前复权后的数据; hfq: 返回后复权后的数据")] string adjust = "")
        {
            string url = $"{prefixUrl}/stock_zh_a_hist?symbol={symbol}&start_date={start_date}&end_date={end_date}&period={period}&adjust={adjust}";
            var content = await AKToolApiHelper.GetStringAsync(_client, url);
            return content;
        }

    }
}