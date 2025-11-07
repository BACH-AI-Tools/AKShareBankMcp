# Facebook MCP API 测试脚本

Write-Host "等待服务启动..." -ForegroundColor Yellow
Start-Sleep -Seconds 3

$baseUrl = "http://localhost:5250"

Write-Host "`n测试 Facebook MCP API 端点" -ForegroundColor Green
Write-Host "=========================" -ForegroundColor Green

# 测试搜索帖子
Write-Host "`n1. 测试搜索 Facebook 帖子:" -ForegroundColor Cyan
try {
    $response = Invoke-WebRequest -Uri "$baseUrl/TestTool/search-posts?query=technology" -Method GET
    Write-Host "   状态码: $($response.StatusCode)" -ForegroundColor Green
    Write-Host "   响应预览: $($response.Content.Substring(0, [Math]::Min(200, $response.Content.Length)))..." -ForegroundColor Gray
} catch {
    Write-Host "   错误: $_" -ForegroundColor Red
}

# 测试 Swagger UI
Write-Host "`n2. 检查 Swagger UI:" -ForegroundColor Cyan
try {
    $response = Invoke-WebRequest -Uri "$baseUrl/swagger/index.html" -Method GET
    Write-Host "   Swagger UI 可用 (状态码: $($response.StatusCode))" -ForegroundColor Green
} catch {
    Write-Host "   Swagger UI 不可用: $_" -ForegroundColor Red
}

Write-Host "`n测试完成!" -ForegroundColor Green
Write-Host "你可以访问以下地址查看更多:" -ForegroundColor Yellow
Write-Host "  - Swagger UI: $baseUrl/swagger" -ForegroundColor White
Write-Host "  - 搜索帖子: $baseUrl/TestTool/search-posts?query=YOUR_QUERY" -ForegroundColor White



