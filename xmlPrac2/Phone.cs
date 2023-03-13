using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xmlPrac2
{
    public class Phone
    {
        public string Name { set; get; }
        public string Producer { set; get; }
        public double Price { get; set; }
        public DateTime ProductionDate { get; set; }
        public Phone() { }
        public Phone(string name, string producer, double price, DateTime productionDate)
        {
            Name = name;
            Producer = producer;
            Price = price;
            ProductionDate = productionDate;
        }
    }
}
