using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.CarDetailDtos
{
	public class ResultCarDescriptionByCarDto
	{
        public int CarDescriptionId { get; set; }
        public int CarId { get; set; }
        public string Details { get; set; }
    }
}
