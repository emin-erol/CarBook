using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.StatisticsInterfaces
{
    public interface IStatisticsRepository
    {
        int GetCarCount();
        int GetLocationCount();
        int GetAuthorCount();
        int GetBlogCount();
        int GetBrandCount();
        int GetReferenceCount();
        decimal GetAverageCarPriceForDaily();
        decimal GetAverageCarPriceForWeekly();
        decimal GetAverageCarPriceForMonthly();
        string BrandNameByMaxCar();
        string BlogTitleByMaxBlogComment();
        int GetCarCountByMileageSmallerThenInterval();
        List<int> GetCarCountByFuelGasolineOrDiesel();
        int GetCarCountByElectricCar();
        List<string> GetMostExpensiveAndCheapCarDaily();
    }
}
