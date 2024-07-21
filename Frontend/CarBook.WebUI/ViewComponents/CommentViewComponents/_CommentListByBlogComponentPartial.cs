using CarBook.Dto.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.CommentViewComponents
{
    public class _CommentListByBlogComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _CommentListByBlogComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.blogId = id;
            var client = _httpClientFactory.CreateClient();
            var commentResponse = await client.GetAsync($"https://localhost:7239/api/Comments/CommentListByBlogId?id=" + id);
            if (commentResponse.IsSuccessStatusCode)
            {
                var jsonData = await commentResponse.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);

                var commentCountResponse = await client.GetAsync($"https://localhost:7239/api/Comments/CommentCountByBlog?id=" + id);
                var jsonData2 = await commentCountResponse.Content.ReadAsStringAsync();
                ViewBag.commentCount = jsonData2;
                return View(value);
            }
            return View();
        }
    }
}
