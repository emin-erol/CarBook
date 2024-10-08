﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.ViewModels
{
	public class CarPricingViewModel
	{
        public CarPricingViewModel()
        {
            Amounts = new List<decimal>();
        }
        public int CarId { get; set; }
		public string BrandName { get; set; }
		public string Model { get; set; }
        public int Year { get; set; }
        public string CoverImageUrl { get; set; }
        public List<decimal> Amounts { get; set; }
    }
}
