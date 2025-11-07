using AKToolApi;
using ModelContextProtocol.Server;
using System.ComponentModel;

namespace ForeignExchangeMcp.tools
{
    [McpServerToolType]
    public class ForeignExchangeTool
    {
        public const string prefixUrl = "/api/public";

        private readonly HttpClient _client;

        public ForeignExchangeTool(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("aktoolApi");
        }


        [McpServerTool]
        [Description("查询所有外汇实时行情数据")]
        public async Task<string> get_forex_spot_em()
        {
            string url = $"{prefixUrl}/forex_spot_em";
            var content = await AKToolApiHelper.GetStringAsync(_client, url);
            return content;
        }

        [McpServerTool]
        [Description("查询指定代码的外汇历史行情数据")]
        public async Task<string> get_forex_hist_em(
            [Description("symbol=\"USDCNH\"; 品种代码；可以通过 ak.forex_spot_em() 来获取所有可获取历史行情数据的品种代码")] string symbol = ""
        )
        {
            string url = $"{prefixUrl}/forex_hist_em?symbol={symbol}";
            var content = await AKToolApiHelper.GetStringAsync(_client, url);
            return content;
        }

        [McpServerTool]
        [Description("查询指定日期指定货币（'美元', '英镑', '欧元', '澳门元', '泰国铢', '菲律宾比索', '港币', '瑞士法郎', '新加坡元', '瑞典克朗', '丹麦克朗', '挪威克朗', '日元', '加拿大元', '澳大利亚元', '新西兰元', '韩国元'）的外汇历史数据")]
        public async Task<string> get_currency_boc_sina(
            [Description("symbol=\"美元\"; choice of {'美元', '英镑', '欧元', '澳门元', '泰国铢', '菲律宾比索', '港币', '瑞士法郎', '新加坡元', '瑞典克朗', '丹麦克朗', '挪威克朗', '日元', '加拿大元', '澳大利亚元', '新西兰元', '韩国元'}")] string symbol = "美元",
            [Description("start_date=\"20230304\"; 开始日期和结束日期之间的间隔要超过 6 个月")] string start_date = "",
            [Description("end_date=\"20231110\"; 开始日期和结束日期之间的间隔要超过 6 个月")] string end_date = ""
        )
        {
            string url = $"{prefixUrl}/currency_boc_sina?symbol={symbol}&start_date={start_date}&end_date={end_date}";
            var content = await AKToolApiHelper.GetStringAsync(_client, url);
            return content;
        }

        [McpServerTool]
        [Description("查询人民币外汇即期报价")]
        public async Task<string> get_fx_spot_quote()
        {
            string url = $"{prefixUrl}/fx_spot_quote";
            var content = await AKToolApiHelper.GetStringAsync(_client, url);
            return content;
        }

        [McpServerTool]
        [Description("查询人民币外汇远掉报价")]
        public async Task<string> get_fx_swap_quote()
        {
            string url = $"{prefixUrl}/fx_swap_quote";
            var content = await AKToolApiHelper.GetStringAsync(_client, url);
            return content;
        }

        [McpServerTool]
        [Description("查询外币对即期报价")]
        public async Task<string> get_fx_pair_quote()
        {
            string url = $"{prefixUrl}/fx_pair_quote";
            var content = await AKToolApiHelper.GetStringAsync(_client, url);
            return content;
        }

        [McpServerTool]
        [Description("查询指定日期货币对-投机情绪报告(所指定的日期必须在当前交易日之前的30个交易日内)")]
        public async Task<string> get_macro_fx_sentiment(
            [Description("start_date=\"20200407\"; 所指定的日期必须在当前交易日之前的30个交易日内")] string start_date = "",
            [Description("end_date=\"20200407\"; 与 start_date 一致")] string end_date = ""
        )
        {
            string url = $"{prefixUrl}/macro_fx_sentiment?start_date={start_date}&end_date={end_date}";
            var content = await AKToolApiHelper.GetStringAsync(_client, url);
            return content;
        }

        [McpServerTool]
        [Description("查询指定货币（'人民币', '美元'）当前时点的行情报价")]
        public async Task<string> get_fx_quote_baidu(
            [Description("symbol=\"人民币\"; choice of {\"人民币\", \"美元\"}")] string symbol = "美元"
        )
        {
            string url = $"{prefixUrl}/fx_quote_baidu?symbol={symbol}";
            var content = await AKToolApiHelper.GetStringAsync(_client, url);
            return content;
        }
    }
}
