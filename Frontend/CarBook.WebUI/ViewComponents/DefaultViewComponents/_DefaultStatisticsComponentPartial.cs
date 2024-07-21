using CarBook.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultStatisticsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _DefaultStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            var carCountResponse = await client.GetAsync("https://localhost:7239/api/Statistics/GetCarCount");
            if (carCountResponse.IsSuccessStatusCode)
            {
                var jsonData1 = await carCountResponse.Content.ReadAsStringAsync();
                var values1 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData1);
                ViewBag.carCount = values1.CarCount;
            }

            var referenceCountResponse = await client.GetAsync("https://localhost:7239/api/Statistics/GetReferenceCount");
            if (referenceCountResponse.IsSuccessStatusCode)
            {
                var jsonData2 = await referenceCountResponse.Content.ReadAsStringAsync();
                var value2 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData2);
                ViewBag.referenceCount = value2.ReferenceCount;
            }

            var brandCountResponse = await client.GetAsync("https://localhost:7239/api/Statistics/GetBrandCount");
            if (brandCountResponse.IsSuccessStatusCode)
            {
                var jsonData3 = await brandCountResponse.Content.ReadAsStringAsync();
                var value3 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData3);
                ViewBag.brandCount = value3.BrandCount;
            }
            return View();
        }
    }
}
