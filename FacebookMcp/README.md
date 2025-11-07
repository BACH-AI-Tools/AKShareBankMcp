# Facebook MCP (Model Context Protocol) 服务

一个基于 Model Context Protocol 的 Facebook Scraper API 服务，提供 Facebook 数据抓取功能。

## 功能特性

- 🔍 搜索 Facebook 帖子
- 👤 获取用户信息
- 📄 获取页面信息
- 📝 获取帖子详情
- 👥 获取群组信息

## 技术栈

- .NET 8.0
- ASP.NET Core Web API
- ModelContextProtocol
- RapidAPI Facebook Scraper

## 快速开始

### 1. 配置 API Key

在 `appsettings.json` 中配置你的 RapidAPI Key：

```json
{
  "FacebookScraper": {
    "ApiKey": "你的_RAPIDAPI_KEY",
    "Host": "facebook-scraper3.p.rapidapi.com"
  }
}
```

### 2. 恢复依赖包

```bash
dotnet restore
```

### 3. 构建项目

```bash
dotnet build
```

### 4. 运行项目

```bash
dotnet run --urls "http://localhost:5250"
```

## API 端点

### 搜索帖子
```
GET /TestTool/search-posts?query={搜索关键词}
```

### 获取用户信息
```
GET /TestTool/user/{userId}
```

### 获取页面信息
```
GET /TestTool/page/{pageId}
```

### 获取帖子详情
```
GET /TestTool/post/{postId}
```

### 获取群组信息
```
GET /TestTool/group/{groupId}
```

## Swagger UI

服务启动后，访问以下地址查看 API 文档：
```
http://localhost:5250/swagger
```

## MCP 工具集成

该服务实现了 Model Context Protocol，可以作为 MCP 工具集成到支持 MCP 的应用中。

### 可用的 MCP 工具

1. **search_facebook_posts** - 搜索 Facebook 帖子
2. **get_facebook_user** - 获取用户信息
3. **get_facebook_page** - 获取页面信息
4. **get_facebook_post** - 获取帖子详情
5. **get_facebook_group** - 获取群组信息

## 注意事项

1. 需要有效的 RapidAPI Key 才能访问 Facebook Scraper API
2. API 调用可能受到速率限制
3. 确保遵守 Facebook 的服务条款和数据使用政策
4. 此服务仅用于合法的数据获取目的

## 故障排除

### 500 内部服务器错误

- 检查 API Key 是否正确配置
- 确认 RapidAPI 账户状态正常
- 检查网络连接

### 无法加载 NuGet 包

确保项目根目录有 `nuget.config` 文件，内容如下：

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <clear />
    <add key="NuGet.org" value="https://api.nuget.org/v3/index.json" />
  </packageSources>
</configuration>
```

## 许可证

本项目使用 MIT 许可证。



