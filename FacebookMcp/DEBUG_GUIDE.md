# FacebookMcp 调试指南

## 推荐设置断点的位置

### 1. FacebookTool.cs 中设置断点
```csharp
// 第 32-33 行 - 搜索方法入口
public async Task<string> search_facebook_posts(
    string query = "facebook")  // 👈 在这里设置断点

// 第 40 行 - URL 构建
string url = $"{BASE_URL}/search/posts?query={Uri.EscapeDataString(query)}";  // 👈 断点

// 第 44 行 - HTTP 请求发送
var response = await _client.GetAsync(url);  // 👈 断点
```

### 2. TestToolController.cs 中设置断点
```csharp
// 第 19 行 - 控制器方法入口
public async Task<IActionResult> SearchPosts(string query = "facebook")  // 👈 断点
{
    var result = await _facebookTool.search_facebook_posts(query);  // 👈 断点
    return Ok(result);
}
```

## Visual Studio 调试步骤

### 方法一：使用 Visual Studio 调试

1. **打开解决方案**
   - 在 Visual Studio 中打开 `AKShareMcp.sln`

2. **设置启动项目**
   - 右键点击 `FacebookMcp` 项目
   - 选择"设为启动项目"

3. **设置断点**
   - 打开 `FacebookTool.cs`
   - 在第 33 行（search_facebook_posts 方法）点击左侧边距设置断点

4. **启动调试**
   - 按 `F5` 或点击"开始调试"按钮
   - 或使用菜单："调试" → "开始调试"

5. **触发断点**
   - 浏览器会自动打开
   - 访问：`http://localhost:5250/TestTool/search-posts?query=test`
   - 程序会在断点处停止

### 方法二：附加到进程调试

1. **先正常运行项目**
   ```bash
   dotnet run --project FacebookMcp\FacebookMcp.csproj
   ```

2. **在 Visual Studio 中附加**
   - 菜单："调试" → "附加到进程"
   - 找到 `FacebookMcp.exe` 进程
   - 点击"附加"

3. **设置断点并触发**
   - 设置断点
   - 访问 API 端点触发断点

## 调试快捷键

| 快捷键 | 功能 |
|--------|------|
| F5     | 开始调试/继续执行 |
| F9     | 设置/取消断点 |
| F10    | 逐过程（不进入方法内部） |
| F11    | 逐语句（进入方法内部） |
| Shift+F11 | 跳出当前方法 |
| Ctrl+F5 | 运行但不调试 |
| Shift+F5 | 停止调试 |

## 查看变量值

调试时可以：
1. **鼠标悬停**：将鼠标悬停在变量上查看值
2. **局部变量窗口**：查看当前作用域的所有变量
3. **监视窗口**：添加要持续监视的变量
4. **即时窗口**：执行表达式和命令

## 条件断点

右键点击断点，选择"条件"，可以设置：
- 条件表达式（如：`query == "facebook"`）
- 命中次数（如：第 5 次命中时才中断）
- 筛选器（如：特定线程）

## 异常断点

菜单："调试" → "窗口" → "异常设置"
- 勾选要中断的异常类型
- 建议勾选 `System.InvalidOperationException` 来调试依赖注入问题

## 常见调试场景

### 1. 调试依赖注入问题
在 `Program.cs` 的服务注册处设置断点：
```csharp
builder.Services.AddScoped<FacebookTool>();  // 👈 断点
```

### 2. 调试 HTTP 请求
在发送请求前后设置断点：
```csharp
var response = await _client.GetAsync(url);  // 👈 请求前
if (response.IsSuccessStatusCode)  // 👈 请求后
```

### 3. 调试配置读取
```csharp
var apiKey = _configuration["FacebookScraper:ApiKey"];  // 👈 断点
```

## 输出日志调试

除了断点，还可以使用日志：
```csharp
Console.WriteLine($"调试信息: query = {query}");
_logger.LogInformation("API调用: {Url}", url);
```

## 提示

1. 调试时服务会暂停，浏览器请求可能超时
2. 使用"编辑并继续"功能可以在调试时修改代码
3. 使用"数据提示"固定常用变量便于观察
4. 调试完成后记得移除不必要的断点



