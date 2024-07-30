using CarBook.Dto.DashboardDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.DashboardViewComponents
{
    public class _AdminDashboardStatisticsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _AdminDashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            var carCountResponse = await client.GetAsync("https://localhost:7239/api/Statistics/GetCarCount");
            if (carCountResponse.IsSuccessStatusCode)
            {
                var jsonData = await carCountResponse.Content.ReadAsStringAsync();
                var value1 = JsonConvert.DeserializeObject<ResultDashboardStatisticsDto>(jsonData);
                ViewBag.carCount = value1.CarCount;
            }

            var brandCountResponse = await client.GetAsync("https://localhost:7239/api/Statistics/GetBrandCount");
            if (brandCountResponse.IsSuccessStatusCode)
            {
                var jsonData = await brandCountResponse.Content.ReadAsStringAsync();
                var value2 = JsonConvert.DeserializeObject<ResultDashboardStatisticsDto>(jsonData);
                ViewBag.brandCount = value2.BrandCount;
            }

            var locationCountResponse = await client.GetAsync("https://localhost:7239/api/Statistics/GetLocationCount");
            if (locationCountResponse.IsSuccessStatusCode)
            {
                var jsonData = await locationCountResponse.Content.ReadAsStringAsync();
                var value3 = JsonConvert.DeserializeObject<ResultDashboardStatisticsDto>(jsonData);
                ViewBag.locationCount = value3.LocationCount;
            }
            return View();
        }
    }
}
