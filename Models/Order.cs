using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Order
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public List<string> Items { get; set; }
    }
}
