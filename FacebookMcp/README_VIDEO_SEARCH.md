# Facebook 视频搜索 MCP Tool

## 功能说明
新增的 `search_facebook_videos` 工具可以搜索 Facebook 上的视频内容。

## 使用方法

### 作为 MCP Tool 使用
```csharp
// 搜索包含特定关键词的视频
var result = await facebookTool.search_facebook_videos("关键词");

// 使用默认关键词 "facebook"
var result = await facebookTool.search_facebook_videos();
```

### 通过 API 测试
启动项目后，可以通过以下端点测试：

```bash
# 搜索特定关键词的视频
GET http://localhost:5000/TestTool/search-videos?query=你的搜索词

# 使用默认搜索词
GET http://localhost:5000/TestTool/search-videos
```

## 配置说明

API Key 已在 `appsettings.json` 中配置：

```json
{
  "FacebookScraper": {
    "ApiKey": "0128668e77msh11ef774f3b032b2p1948dbjsn165e91aaa1d2",
    "Host": "facebook-scraper3.p.rapidapi.com"
  }
}
```

## 功能列表

该工具包含以下功能：
1. `search_facebook_posts` - 搜索 Facebook 帖子
2. `get_facebook_user` - 获取用户信息
3. `get_facebook_page` - 获取页面信息
4. `get_facebook_post` - 获取帖子详情
5. `get_facebook_group` - 获取群组信息
6. **`search_facebook_videos`** - 搜索 Facebook 视频（新增）

## RapidAPI 说明

此工具使用 RapidAPI 的 facebook-scraper3 服务：
- API Host: facebook-scraper3.p.rapidapi.com
- 端点: /search/videos
- 方法: GET
- 参数: query（搜索关键词）

## 错误处理

工具包含完整的错误处理：
- HTTP 错误返回状态码和原因
- 异常情况返回异常消息
- 空参数会使用默认值 "facebook"


