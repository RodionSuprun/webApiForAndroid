using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiForAndroid.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string County { get; set; }
        public string Desc { get; set; }
        public string Photo { get; set; }
        public int NumberOfNumbers { get; set; }
        public int NumberOfStars { get; set; }
        public int Price { get; set; }
    }
}
