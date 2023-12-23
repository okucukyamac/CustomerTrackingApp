using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerTracking.Core.Models.DTOs
{
    public class ProductDto:BaseDto
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
    }
}
