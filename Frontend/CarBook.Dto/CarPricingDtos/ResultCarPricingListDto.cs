using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.CarPricingDtos
{
	public class ResultCarPricingListDto
	{
		public string Model { get; set; }
        public int CarId { get; set; }
        public string BrandName { get; set; }
        public string CoverImageUrl { get; set; }
        public decimal DailyAmount { get; set; }
		public decimal WeeklyAmount { get; set; }
		public decimal MonthlyAmount { get; set; }
	}
}
