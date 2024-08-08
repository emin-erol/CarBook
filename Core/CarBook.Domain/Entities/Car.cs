using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Aracın markasını, modelini, resmini, kilometresini, vites tipini, koltuk sayısını, bagaj miktarını, yakıt tipini, ana resim adresini
// detay özelliklerinin bulunduğu tabloyu, araç ile ilgili açıklamanın bulunduğu tabloyu, ve fiyatlandırmaların bulunduğu tabloyu
// kullanan tablonun oluşturulması.

namespace CarBook.Domain.Entities
{
    public class Car
    {
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string CoverImageUrl { get; set; }
        public int Mileage { get; set; }
        public string Transmission { get; set; }
        public byte Seat { get; set; }
        public byte Luggage { get; set; }
        public string Fuel { get; set; }
        public string BigImageUrl { get; set; }
        public string Description { get; set; }
        public List<CarFeature> CarFeatures { get; set; }
        public List<CarPricing> CarPricings { get; set; }
        public List<RentACar> RentACars { get; set; }
        public List<RentACarProcess> RentACarProcesses { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}
