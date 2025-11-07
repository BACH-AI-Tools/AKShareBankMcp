using AKToolApi;
using ModelContextProtocol.Server;
using System.ComponentModel;
using System.Net.Http.Headers;

namespace FacebookMcp.tools
{
    [McpServerToolType]
    public class FacebookTool
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;
        private const string BASE_URL = "https://facebook-scraper3.p.rapidapi.com";
        private const string RAPID_API_HOST = "facebook-scraper3.p.rapidapi.com";

        public FacebookTool(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _client = httpClientFactory.CreateClient();
            _configuration = configuration;
            
            // 配置 RapidAPI 请求头
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Add("x-rapidapi-host", RAPID_API_HOST);
            
            // 从配置文件读取 API Key，如果没有则使用默认值
            var apiKey = _configuration["FacebookScraper:ApiKey"] ?? "0128668e77msh11ef774f3b032b2p1948dbjsn165e91aaa1d2";
            _client.DefaultRequestHeaders.Add("x-rapidapi-key", apiKey);
        }

        /// <summary>
        /// 搜索Facebook地点
        /// </summary>
        /// <param name="query">搜索关键词</param>
        /// <returns>地点搜索结果</returns>
        [Description("Search Facebook locations by query")]
        public async Task<string> SearchLocations(
            [Description("Search query for locations")] string query)
        {
            try
            {
                var url = $"{BASE_URL}/search/locations";
                if (!string.IsNullOrEmpty(query))
                {
                    url += $"?query={Uri.EscapeDataString(query)}";
                }

                var response = await _client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadAsStringAsync();
                return result;
            }
            catch (HttpRequestException ex)
            {
                return $"Error searching locations: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"Unexpected error: {ex.Message}";
            }
        }

        /// <summary>
        /// 搜索Facebook视频
        /// </summary>
        /// <param name="query">搜索关键词</param>
        /// <returns>视频搜索结果</returns>
        [Description("Search Facebook videos by query")]
        public async Task<string> SearchVideos(
            [Description("Search query for videos")] string query)
        {
            try
            {
                if (string.IsNullOrEmpty(query))
                {
                    return "Error: Query parameter is required for video search";
                }

                var url = $"{BASE_URL}/search/videos?query={Uri.EscapeDataString(query)}";
                
                var response = await _client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadAsStringAsync();
                return result;
            }
            catch (HttpRequestException ex)
            {
                return $"Error searching videos: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"Unexpected error: {ex.Message}";
            }
        }

        /// <summary>
        /// 搜索Facebook帖子
        /// </summary>
        /// <param name="query">搜索关键词</param>
        /// <returns>帖子搜索结果</returns>
        [Description("Search Facebook posts by query")]
        public async Task<string> SearchPosts(
            [Description("Search query for posts")] string query)
        {
            try
            {
                if (string.IsNullOrEmpty(query))
                {
                    return "Error: Query parameter is required for post search";
                }

                var url = $"{BASE_URL}/search/posts?query={Uri.EscapeDataString(query)}";
                
                var response = await _client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadAsStringAsync();
                return result;
            }
            catch (HttpRequestException ex)
            {
                return $"Error searching posts: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"Unexpected error: {ex.Message}";
            }
        }

    }
}
