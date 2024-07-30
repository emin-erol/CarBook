using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.DashboardInterfaces
{
    public interface IDashboardRepository
    {
        Task<Dictionary<int,int>> GetReservationDates();
        Task<Dictionary<string,int>> GetCarCountsInLocation();
        Task<Dictionary<int, int>> GetCarCountsByYear();
    }
}
