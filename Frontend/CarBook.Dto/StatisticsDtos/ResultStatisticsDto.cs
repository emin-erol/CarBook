using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.StatisticsDtos
{
    public class ResultStatisticsDto
    {
        public int CarCount { get; set; }
        public int LocationCount { get; set; }
        public int AuthorCount { get; set; }
        public int BlogCount { get; set; }
        public int BrandCount { get; set; }
        public int ReferenceCount { get; set; }
        public decimal AverageCarAmountDaily { get; set; }
        public decimal AverageCarAmountWeekly { get; set; }
        public decimal AverageCarAmountMonthly { get; set; }
        public string BrandName { get; set; }
        public string BlogTitle { get; set; }
        public int CarCountOfLessMileage { get; set; }
        public List<int> CarCountByFuel { get; set; }
        public int CarCountOfElectricCar { get; set; }
        public List<string> MostCheapAndExpensiveCar { get; set; }
    }
}
