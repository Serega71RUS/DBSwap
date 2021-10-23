using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sber1.Models
{
    public class Auto
    {

        public string Manufacturer { get; set; }
        [Key]
        public string Model { get; set; }

        public int HP { get; set; }

        public DateTime Date { get; set; }

    }
}
