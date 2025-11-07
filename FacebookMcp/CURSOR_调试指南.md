# 🐞 Cursor 编辑器调试指南

## 快速开始（最简单方法）

### 方法一：命令行运行 + 日志调试 ⭐推荐

1. **添加调试日志**
   在 `FacebookTool.cs` 中添加日志输出：
   ```csharp
   public async Task<string> search_facebook_posts(string query = "facebook")
   {
       Console.WriteLine($"[DEBUG] 开始搜索: {query}");
       Console.WriteLine($"[DEBUG] API URL: {BASE_URL}/search/posts?query={Uri.EscapeDataString(query)}");
       
       // 原有代码...
   }
   ```

2. **运行项目**
   ```bash
   dotnet run --project FacebookMcp\FacebookMcp.csproj
   ```

3. **查看控制台输出**
   访问 API 时会在终端看到调试信息

### 方法二：使用 Cursor 内置调试器

#### 步骤 1: 创建调试配置

1. **创建 .vscode 文件夹**（在项目根目录）
   ```bash
   mkdir .vscode
   ```

2. **创建 launch.json 文件**
   复制 `CURSOR_DEBUG_CONFIG.json` 内容到 `.vscode/launch.json`

3. **创建 tasks.json 文件**
   复制 `CURSOR_TASKS_CONFIG.json` 内容到 `.vscode/tasks.json`

#### 步骤 2: 设置断点

1. 打开 `FacebookMcp/tools/FacebookTool.cs`
2. 在第 33 行（`search_facebook_posts` 方法内）点击行号左侧
3. 出现红点表示断点设置成功

![断点示例](https://code.visualstudio.com/assets/docs/editor/debugging/bpts-in-overview.png)

#### 步骤 3: 开始调试

1. **打开调试面板**
   - 按 `Ctrl+Shift+D`
   - 或点击左侧活动栏的"运行和调试"图标 ▶️

2. **选择配置**
   - 在顶部下拉框选择 "FacebookMcp Debug"

3. **启动调试**
   - 按 `F5` 或点击绿色播放按钮 ▶️

4. **触发断点**
   - 浏览器访问：`http://localhost:5250/TestTool/search-posts?query=test`
   - 代码会在断点处暂停

## 🎮 调试控制

| 快捷键 | 功能 | 图标 |
|--------|------|------|
| `F5` | 继续运行 | ▶️ |
| `F10` | 单步跳过 | ⤵️ |
| `F11` | 单步进入 | ⬇️ |
| `Shift+F11` | 单步跳出 | ⬆️ |
| `Shift+F5` | 停止调试 | ⏹️ |
| `Ctrl+Shift+F5` | 重启调试 | 🔄 |

## 📊 查看变量

调试暂停时可以：

1. **悬停查看**：鼠标悬停在变量上
2. **变量面板**：左侧自动显示局部变量
3. **监视面板**：添加要持续观察的表达式
4. **调试控制台**：输入表达式实时求值

## 💡 实用技巧

### 1. 条件断点
右键点击断点 → "编辑断点" → 添加条件：
```csharp
query == "test"  // 只在 query 为 "test" 时中断
```

### 2. 日志断点
右键点击断点 → "编辑断点" → 选择"日志消息"：
```
查询内容: {query}, URL: {url}
```

### 3. 异常断点
在调试面板的"断点"部分，勾选：
- [x] 所有异常
- [x] 用户未处理的异常

## 🔧 常见问题

### 问题：无法启动调试
**解决方案**：
1. 确保安装了 C# 扩展（ms-dotnettools.csharp）
2. 确保 .NET SDK 已安装：`dotnet --version`
3. 重启 Cursor 编辑器

### 问题：断点不生效（显示为灰色）
**解决方案**：
1. 确保项目已编译：`dotnet build`
2. 确保调试配置正确
3. 清理并重建：`dotnet clean && dotnet build`

### 问题：找不到调试选项
**解决方案**：
1. 安装 C# Dev Kit 扩展
2. 打开命令面板（`Ctrl+Shift+P`）
3. 输入 "Reload Window" 重新加载

## 🚀 快速调试步骤总结

1. **设置断点**：点击行号左侧
2. **按 F5**：启动调试
3. **访问 API**：触发断点
4. **F10/F11**：单步调试
5. **查看变量**：悬停或使用面板
6. **F5**：继续运行

## 📝 示例：调试 API 调用

```csharp
// 在 FacebookTool.cs 第 44 行设置断点
var response = await _client.GetAsync(url);  // 👈 断点

// 调试时可以查看：
// - url 的值
// - _client.DefaultRequestHeaders
// - response.StatusCode
// - response.Content
```

就这么简单！现在你可以开始调试了。



