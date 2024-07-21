using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Araç markalarının tutulduğu tablo. Bu tablodaki markalar birden fazla araç ile bağlanacağından liste tipinde Car entity'si tanımlandı.

namespace CarBook.Domain.Entities
{
    public class Brand
    {
        public int BrandId { get; set; }
        public string Name { get; set; }
        public List<Car> Cars { get; set; }
    }
}
