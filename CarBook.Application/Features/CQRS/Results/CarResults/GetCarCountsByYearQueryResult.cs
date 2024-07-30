using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Results.CarResults
{
    public class GetCarCountsByYearQueryResult
    {
        public int Year { get; set; }
        public int Count { get; set; }
    }
}
