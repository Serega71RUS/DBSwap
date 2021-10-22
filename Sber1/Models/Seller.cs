using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sber1.Models
{
    class Seller
    {
        public string Salon { get; set; }
        [Key]
        public string Street { get; set; }

        public string House { get; set; }

        public int Price { get; set; }
    }
}
