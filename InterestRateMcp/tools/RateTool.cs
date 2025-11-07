using AKToolApi;
using ModelContextProtocol.Server;
using System.ComponentModel;

namespace InterestRateMcp.tools
{

    [McpServerToolType]
    public class RateTool
    {
        public const string prefixUrl = "/api/public";

        private readonly HttpClient _client;

        public RateTool(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("aktoolApi");
        }

        [McpServerTool]
        [Description("美联储利率决议报告, 数据区间从 19820927-至今")]
        public async Task<string> get_macro_bank_usa_interest_rate()
        {
            string url = $"{prefixUrl}/macro_bank_usa_interest_rate";
            var content = await AKToolApiHelper.GetStringAsync(_client, url);
            return content;
        }

        [McpServerTool]
        [Description("欧洲央行决议报告, 数据区间从 19990101-至今")]
        public async Task<string> get_macro_bank_euro_interest_rate()
        {
            string url = $"{prefixUrl}/macro_bank_euro_interest_rate";
            var content = await AKToolApiHelper.GetStringAsync(_client, url);
            return content;
        }

        [McpServerTool]
        [Description("新西兰联储决议报告, 数据区间从 19990401-至今")]
        public async Task<string> get_macro_bank_newzealand_interest_rate()
        {
            string url = $"{prefixUrl}/macro_bank_newzealand_interest_rate";
            var content = await AKToolApiHelper.GetStringAsync(_client, url);
            return content;
        }

        [McpServerTool]
        [Description("中国央行决议报告, 数据区间从 19910105-至今")]
        public async Task<string> get_macro_bank_china_interest_rate()
        {
            string url = $"{prefixUrl}/macro_bank_china_interest_rate";
            var content = await AKToolApiHelper.GetStringAsync(_client, url);
            return content;
        }

        [McpServerTool]
        [Description("瑞士央行利率决议报告, 数据区间从 20080313-至今")]
        public async Task<string> get_macro_bank_switzerland_interest_rate()
        {
            string url = $"{prefixUrl}/macro_bank_switzerland_interest_rate";
            var content = await AKToolApiHelper.GetStringAsync(_client, url);
            return content;
        }

        [McpServerTool]
        [Description("英国央行决议报告, 数据区间从 19700101-至今")]
        public async Task<string> get_macro_bank_english_interest_rate()
        {
            string url = $"{prefixUrl}/macro_bank_english_interest_rate";
            var content = await AKToolApiHelper.GetStringAsync(_client, url);
            return content;
        }

        [McpServerTool]
        [Description("澳洲联储决议报告, 数据区间从 19800201-至今")]
        public async Task<string> get_macro_bank_australia_interest_rate()
        {
            string url = $"{prefixUrl}/macro_bank_australia_interest_rate";
            var content = await AKToolApiHelper.GetStringAsync(_client, url);
            return content;
        }

        [McpServerTool]
        [Description("日本利率决议报告, 数据区间从 20080214-至今")]
        public async Task<string> get_macro_bank_japan_interest_rate()
        {
            string url = $"{prefixUrl}/macro_bank_japan_interest_rate";
            var content = await AKToolApiHelper.GetStringAsync(_client, url);
            return content;
        }

        [McpServerTool]
        [Description("俄罗斯利率决议报告, 数据区间从 20030601-至今")]
        public async Task<string> get_macro_bank_russia_interest_rate()
        {
            string url = $"{prefixUrl}/macro_bank_russia_interest_rate";
            var content = await AKToolApiHelper.GetStringAsync(_client, url);
            return content;
        }

        [McpServerTool]
        [Description("印度利率决议报告, 数据区间从 20000801-至今")]
        public async Task<string> get_macro_bank_india_interest_rate()
        {
            string url = $"{prefixUrl}/macro_bank_india_interest_rate";
            var content = await AKToolApiHelper.GetStringAsync(_client, url);
            return content;
        }

        [McpServerTool]
        [Description("巴西利率决议报告, 数据区间从20080201-至今")]
        public async Task<string> get_macro_bank_brazil_interest_rate()
        {
            string url = $"{prefixUrl}/macro_bank_brazil_interest_rate";
            var content = await AKToolApiHelper.GetStringAsync(_client, url);
            return content;
        }

        [McpServerTool]
        [Description("回购定盘利率数据, 单次返回指定日期间(一年)的所有历史数据")]
        public async Task<string> get_repo_rate_hist(
            [Description("start_date=\"20200930\"; 开始时间与结束时间需要在一年内")] string start_date = "",
            [Description("end_date=\"20201029\"; 开始时间与结束时间需要在一年内")] string end_date = ""
        )
        {
            string url = $"{prefixUrl}/repo_rate_hist?start_date={start_date}&end_date={end_date}";
            var content = await AKToolApiHelper.GetStringAsync(_client, url);
            return content;
        }

        [McpServerTool]
        [Description("回购定盘利率数据, 单次返回指定 symbol 的近期数据")]
        public async Task<string> get_repo_rate_query(
            [Description("symbol=\"回购定盘利率\"; choice of {\"回购定盘利率\", \"银银间回购定盘利率\"}")] string symbol = ""
        )
        {
            string url = $"{prefixUrl}/repo_rate_query?symbol={symbol}";
            var content = await AKToolApiHelper.GetStringAsync(_client, url);
            return content;
        }
    }
}
