﻿using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Results.CarResults
{
    public class GetCarByIdQueryResult
    {
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string CoverImageUrl { get; set; }
        public int Mileage { get; set; }
        public string Transmission { get; set; }
        public byte Seat { get; set; }
        public byte Luggage { get; set; }
        public string Fuel { get; set; }
        public string BigImageUrl { get; set; }
    }
}
