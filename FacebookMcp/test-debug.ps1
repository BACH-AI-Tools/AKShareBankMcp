# 测试调试 - 重新构建并运行

Write-Host "`n🔧 重新构建项目..." -ForegroundColor Yellow
dotnet build FacebookMcp\FacebookMcp.csproj

if ($LASTEXITCODE -eq 0) {
    Write-Host "✅ 构建成功!" -ForegroundColor Green
    
    Write-Host "`n🚀 启动 FacebookMcp (已修复依赖注入)..." -ForegroundColor Cyan
    Write-Host "📍 访问以下地址测试:" -ForegroundColor Yellow
    Write-Host "   http://localhost:5250/swagger" -ForegroundColor White
    Write-Host "   http://localhost:5250/TestTool/search-posts?query=test" -ForegroundColor White
    Write-Host "`n按 Ctrl+C 停止服务`n" -ForegroundColor Gray
    
    dotnet run --project FacebookMcp\FacebookMcp.csproj --urls "http://localhost:5250"
} else {
    Write-Host "❌ 构建失败，请检查错误信息" -ForegroundColor Red
}



