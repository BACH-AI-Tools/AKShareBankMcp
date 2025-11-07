using Microsoft.AspNetCore.Mvc;
using FacebookMcp.tools;

namespace FacebookMcp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestToolController : ControllerBase
    {
        private readonly FacebookTool _facebookTool;

        public TestToolController(FacebookTool facebookTool)
        {
            _facebookTool = facebookTool;
        }

        /// <summary>
        /// 测试搜索Facebook地点
        /// </summary>
        /// <param name="query">搜索关键词</param>
        /// <returns>地点搜索结果</returns>
        [HttpGet("search/locations")]
        public async Task<IActionResult> TestSearchLocations([FromQuery] string query = "New York")
        {
            try
            {
                var result = await _facebookTool.SearchLocations(query);
                return Ok(new
                {
                    success = true,
                    query = query,
                    data = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    error = ex.Message
                });
            }
        }

        /// <summary>
        /// 测试搜索Facebook视频
        /// </summary>
        /// <param name="query">搜索关键词</param>
        /// <returns>视频搜索结果</returns>
        [HttpGet("search/videos")]
        public async Task<IActionResult> TestSearchVideos([FromQuery] string query = "facebook")
        {
            try
            {
                var result = await _facebookTool.SearchVideos(query);
                return Ok(new
                {
                    success = true,
                    query = query,
                    data = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    error = ex.Message
                });
            }
        }

        /// <summary>
        /// 测试搜索Facebook帖子
        /// </summary>
        /// <param name="query">搜索关键词</param>
        /// <returns>帖子搜索结果</returns>
        [HttpGet("search/posts")]
        public async Task<IActionResult> TestSearchPosts([FromQuery] string query = "facebook")
        {
            try
            {
                var result = await _facebookTool.SearchPosts(query);
                return Ok(new
                {
                    success = true,
                    query = query,
                    data = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    error = ex.Message
                });
            }
        }
        
    }
}
