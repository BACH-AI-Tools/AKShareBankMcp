using AKToolApi;
using ModelContextProtocol.Server;
using System.ComponentModel;

namespace BondMcp.tools
{
    [McpServerToolType]
    public class BondTool
    {
        public const string prefixUrl = "/api/public";

        private readonly HttpClient _client;

        public BondTool(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("aktoolApi");
        }

        [McpServerTool]
        [Description("指定交易日的债券现券市场概览数据")]
        public async Task<string> get_bond_cash_summary_sse(
           [Description("交易日期,数据格式为yyyyMMdd，例如20250808")] string date = ""
           )
        {
            if (string.IsNullOrWhiteSpace(date))
            {
                date = DateTime.Now.AddDays(-1).ToString("yyyyMMdd");
            }
            string url = $"{prefixUrl}/bond_cash_summary_sse?date={date}";
            var content = await AKToolApiHelper.GetStringAsync(_client, url);
            return content;
        }

        [McpServerTool]
        [Description("指定交易日的债券成交概览数据")]
        public async Task<string> get_bond_deal_summary_sse(
          [Description("交易日期,数据格式为yyyyMMdd，例如20250808")] string date = ""
          )
        {
            if (string.IsNullOrWhiteSpace(date))
            {
                date = DateTime.Now.AddDays(-1).ToString("yyyyMMdd");
            }
            string url = $"{prefixUrl}/bond_deal_summary_sse?date={date}";
            var content = await AKToolApiHelper.GetStringAsync(_client, url);
            return content;
        }

        [McpServerTool]
        [Description("银行间市场债券发行基础数据")]
        public async Task<string> get_bond_debt_nafmii(
         [Description("页码，也就是第几页")] string page = "1"
         )
        {
            if (string.IsNullOrEmpty(page))
            {
                page = "1";
            }
            string url = $"{prefixUrl}/bond_debt_nafmii?page={page}";
            var content = await AKToolApiHelper.GetStringAsync(_client, url);
            return content;
        }

        [McpServerTool]
        [Description("现券市场做市报价")]
        public async Task<string> get_bond_spot_quote()
        {
            string url = $"{prefixUrl}/bond_spot_quote";
            var content = await AKToolApiHelper.GetStringAsync(_client, url);
            return content;
        }

        [McpServerTool]
        [Description("现券市场成交行情")]
        public async Task<string> get_bond_spot_deal()
        {
            string url = $"{prefixUrl}/bond_spot_deal";
            var content = await AKToolApiHelper.GetStringAsync(_client, url);
            return content;
        }


        [McpServerTool]
        [Description("国债及其他债券收益率曲线")]
        public async Task<string> get_bond_china_yield(
        [Description("开始日期,数据格式为yyyyMMdd，例如20250808")] string start_date,
        [Description("结束日期,数据格式为yyyyMMdd，例如20250808")] string end_date
        )
        {
            //start_date 到 end_date 需要小于一年
            if (string.IsNullOrEmpty(start_date))
            {
                start_date = DateTime.Now.AddYears(-1).ToString("yyyyMMdd");
                end_date = DateTime.Now.AddDays(-1).ToString("yyyyMMdd");
            }
            if (string.IsNullOrEmpty(end_date))
            {
                if (DateTime.TryParseExact(start_date, "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out var dt))
                {
                    end_date = dt.AddYears(1).AddDays(-1).ToString("yyyyMMdd");
                }
                else
                {
                    throw new ArgumentException("start_date 格式应为 yyyyMMdd，例如 20250808");
                }
            }

            string url = $"{prefixUrl}/bond_china_yield?start_date={start_date}&end_date={end_date}";
            var content = await AKToolApiHelper.GetStringAsync(_client, url);
            return content;
        }

        [McpServerTool]
        [Description("中美国债收益率")]
        public async Task<string> get_bond_zh_us_rate(
        [Description("开始日期,数据格式为yyyyMMdd，例如20250808")] string start_date
        )
        {
            if (string.IsNullOrEmpty(start_date))
            {
                start_date = DateTime.Now.AddYears(-1).ToString("yyyyMMdd");
            }

            string url = $"{prefixUrl}/bond_zh_us_rate?start_date={start_date}";
            var content = await AKToolApiHelper.GetStringAsync(_client, url);
            return content;
        }


        [McpServerTool]
        [Description("国债发行信息")]
        public async Task<string> get_bond_treasure_issue_cninfo(
        [Description("开始日期,数据格式为yyyyMMdd，例如20250808")] string start_date,
        [Description("结束日期,数据格式为yyyyMMdd，例如20250808")] string end_date
        )
        {
            if (string.IsNullOrEmpty(start_date))
            {
                start_date = DateTime.Now.AddYears(-1).ToString("yyyyMMdd");
                end_date = DateTime.Now.AddDays(-1).ToString("yyyyMMdd");
            }
            if (string.IsNullOrEmpty(end_date))
            {
                if (DateTime.TryParseExact(start_date, "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out var dt))
                {
                    end_date = dt.AddYears(1).AddDays(-1).ToString("yyyyMMdd");
                }
                else
                {
                    throw new ArgumentException("start_date 格式应为 yyyyMMdd，例如 20250808");
                }
            }

            string url = $"{prefixUrl}/bond_treasure_issue_cninfo?start_date={start_date}&end_date={end_date}";
            var content = await AKToolApiHelper.GetStringAsync(_client, url);
            return content;
        }


    }
}