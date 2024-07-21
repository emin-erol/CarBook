using CarBook.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminStatistics")]
    public class AdminStatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminStatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            var carCountResponse = await client.GetAsync("https://localhost:7239/api/Statistics/GetCarCount");
            if (carCountResponse.IsSuccessStatusCode)
            {
                var jsonData = await carCountResponse.Content.ReadAsStringAsync();
                var value1 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.carCount = value1.CarCount;
            }

            var locationCountResponse = await client.GetAsync("https://localhost:7239/api/Statistics/GetLocationCount");
            if (locationCountResponse.IsSuccessStatusCode)
            {
                var jsonData2 = await locationCountResponse.Content.ReadAsStringAsync();
                var value2 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData2);
                ViewBag.locationCount = value2.LocationCount;
            }

            var authorCountResponse = await client.GetAsync("https://localhost:7239/api/Statistics/GetAuthorCount");
            if (authorCountResponse.IsSuccessStatusCode)
            {
                var jsonData3 = await authorCountResponse.Content.ReadAsStringAsync();
                var value3 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData3);
                ViewBag.authorCount = value3.AuthorCount;
            }

            var blogCountResponse = await client.GetAsync("https://localhost:7239/api/Statistics/GetBlogCount");
            if (blogCountResponse.IsSuccessStatusCode)
            {
                var jsonData4 = await blogCountResponse.Content.ReadAsStringAsync();
                var value4 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData4);
                ViewBag.blogCount = value4.BlogCount;
            }

            var brandCountResponse = await client.GetAsync("https://localhost:7239/api/Statistics/GetBrandCount");
            if (brandCountResponse.IsSuccessStatusCode)
            {
                var jsonData5 = await brandCountResponse.Content.ReadAsStringAsync();
                var value5 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData5);
                ViewBag.brandCount = value5.BrandCount;
            }

            var referenceCountResponse = await client.GetAsync("https://localhost:7239/api/Statistics/GetReferenceCount");
            if (referenceCountResponse.IsSuccessStatusCode)
            {
                var jsonData6 = await referenceCountResponse.Content.ReadAsStringAsync();
                var value6 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData6);
                ViewBag.referenceCount = value6.ReferenceCount;
            }

            var averageCarPriceDailyResponse = await client.GetAsync("https://localhost:7239/api/Statistics/GetAverageCarPriceForDaily");
            if (averageCarPriceDailyResponse.IsSuccessStatusCode)
            {
                var jsonData7 = await averageCarPriceDailyResponse.Content.ReadAsStringAsync();
                var value7 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData7);
                ViewBag.averageCarAmountDaily = value7.AverageCarAmountDaily.ToString("0.00");
            }

            var averageCarPriceWeeklyResponse = await client.GetAsync("https://localhost:7239/api/Statistics/GetAverageCarPriceForWeekly");
            if (averageCarPriceWeeklyResponse.IsSuccessStatusCode)
            {
                var jsonData8 = await averageCarPriceWeeklyResponse.Content.ReadAsStringAsync();
                var value8 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData8);
                ViewBag.averageCarAmountWeekly = value8.AverageCarAmountWeekly.ToString("0.00");
            }

            var averageCarPriceMonthlyResponse = await client.GetAsync("https://localhost:7239/api/Statistics/GetAverageCarPriceForMonthly");
            if (averageCarPriceMonthlyResponse.IsSuccessStatusCode)
            {
                var jsonData9 = await averageCarPriceMonthlyResponse.Content.ReadAsStringAsync();
                var value9 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData9);
                ViewBag.averageCarAmountMonthly = value9.AverageCarAmountMonthly.ToString("0.00");
            }

            var brandNameResponse = await client.GetAsync("https://localhost:7239/api/Statistics/BrandNameByMaxCar");
            if (brandNameResponse.IsSuccessStatusCode)
            {
                var jsonData10 = await brandNameResponse.Content.ReadAsStringAsync();
                var value10 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData10);
                ViewBag.brandName = value10.BrandName;
            }

            var blogTitleResponse = await client.GetAsync("https://localhost:7239/api/Statistics/BlogTitleByMaxBlogComment");
            if (blogTitleResponse.IsSuccessStatusCode)
            {
                var jsonData11 = await blogTitleResponse.Content.ReadAsStringAsync();
                var value11 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData11);
                ViewBag.blogTitle = value11.BlogTitle;
            }

            var carCountSmallMileageResponse = await client.GetAsync("https://localhost:7239/api/Statistics/GetCarCountByMileageSmallerThenInterval");
            if (carCountSmallMileageResponse.IsSuccessStatusCode)
            {
                var jsonData12 = await carCountSmallMileageResponse.Content.ReadAsStringAsync();
                var value12 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData12);
                ViewBag.carCountOfLessMileage = value12.CarCountOfLessMileage;
            }

            var carCountFuelTypeResponse = await client.GetAsync("https://localhost:7239/api/Statistics/GetCarCountByFuelGasolineOrDiesel");
            if (carCountFuelTypeResponse.IsSuccessStatusCode)
            {
                var jsonData13 = await carCountFuelTypeResponse.Content.ReadAsStringAsync();
                var value13 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData13);
                ViewBag.carCountByFuel = value13.CarCountByFuel;
            }

            var carCountElectricCarResponse = await client.GetAsync("https://localhost:7239/api/Statistics/GetCarCountByElectricCar");
            if (carCountElectricCarResponse.IsSuccessStatusCode)
            {
                var jsonData14 = await carCountElectricCarResponse.Content.ReadAsStringAsync();
                var value14 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData14);
                ViewBag.carCountElectricCar = value14.CarCountOfElectricCar;
            }

            var mostExpensiveAndCheapCarResponse = await client.GetAsync("https://localhost:7239/api/Statistics/GetMostExpensiveAndCheapCarDaily");
            if (mostExpensiveAndCheapCarResponse.IsSuccessStatusCode)
            {
                var jsonData15 = await mostExpensiveAndCheapCarResponse.Content.ReadAsStringAsync();
                var value15 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData15);
                ViewBag.mostExpensiveAndCheapCar = value15.MostCheapAndExpensiveCar;
            }
            return View();
        }
    }
}
