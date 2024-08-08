using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.CarIntefaces
{
    public interface ICarRepository
    {
        List<Car> GetCarListWithBrand();
        List<Car> GetLast5CarsWithBrands();
        Task<string> GetCarDescription(int id);
    }
}
