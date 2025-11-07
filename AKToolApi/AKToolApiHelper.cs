namespace AKToolApi
{
    public class AKToolApiHelper
    {
        public static async Task<string> GetStringAsync(HttpClient _client, string requestUri)
        {
            using var ret = await _client.GetAsync(requestUri);
            ret.EnsureSuccessStatusCode();
            var content = await ret.Content.ReadAsStringAsync();
            return content;
        }
    }
}
