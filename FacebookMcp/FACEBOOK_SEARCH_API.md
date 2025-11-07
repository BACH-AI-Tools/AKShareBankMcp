# Facebook Search MCP Tools

## 概述
这些MCP工具封装了Facebook Scraper API的搜索功能，支持搜索地点、视频和帖子。

## API配置

### RapidAPI配置
- **API Host**: `facebook-scraper3.p.rapidapi.com`
- **API Key**: 在 `appsettings.json` 中配置 `FacebookScraper:ApiKey`
- **默认API Key**: `0128668e77msh11ef774f3b032b2p1948dbjsn165e91aaa1d2`

## MCP工具方法

### 1. SearchLocations
搜索Facebook地点信息。

**参数**：
- `query` (string): 搜索关键词（可选）

**返回**：
- JSON格式的地点搜索结果

**示例**：
```csharp
var result = await facebookTool.SearchLocations("New York");
```

### 2. SearchVideos
搜索Facebook视频内容。

**参数**：
- `query` (string): 搜索关键词（必需）

**返回**：
- JSON格式的视频搜索结果

**示例**：
```csharp
var result = await facebookTool.SearchVideos("facebook");
```

### 3. SearchPosts
搜索Facebook帖子内容。

**参数**：
- `query` (string): 搜索关键词（必需）

**返回**：
- JSON格式的帖子搜索结果

**示例**：
```csharp
var result = await facebookTool.SearchPosts("facebook");
```

## 测试端点

启动应用后，可以通过以下HTTP端点测试这些工具：

### 搜索地点
```
GET /TestTool/search/locations?query=New York
```

### 搜索视频
```
GET /TestTool/search/videos?query=facebook
```

### 搜索帖子
```
GET /TestTool/search/posts?query=facebook
```

## 错误处理

所有方法都包含了错误处理：
- HTTP请求失败时返回错误信息
- 必需参数缺失时返回参数错误信息
- 意外错误时返回通用错误信息

## 注意事项

1. **API限制**：请注意RapidAPI的使用限制和配额
2. **参数编码**：查询参数会自动进行URL编码
3. **异步操作**：所有方法都是异步的，使用 `async/await` 模式
4. **返回格式**：返回原始JSON字符串，需要根据实际需求进行解析

## 原始cURL命令参考

### 搜索地点
```bash
curl --request GET \
  --url 'https://facebook-scraper3.p.rapidapi.com/search/locations?query=YOUR_QUERY' \
  --header 'x-rapidapi-host: facebook-scraper3.p.rapidapi.com' \
  --header 'x-rapidapi-key: YOUR_API_KEY'
```

### 搜索视频
```bash
curl --request GET \
  --url 'https://facebook-scraper3.p.rapidapi.com/search/videos?query=facebook' \
  --header 'x-rapidapi-host: facebook-scraper3.p.rapidapi.com' \
  --header 'x-rapidapi-key: YOUR_API_KEY'
```

### 搜索帖子
```bash
curl --request GET \
  --url 'https://facebook-scraper3.p.rapidapi.com/search/posts?query=facebook' \
  --header 'x-rapidapi-host: facebook-scraper3.p.rapidapi.com' \
  --header 'x-rapidapi-key: YOUR_API_KEY'
```
