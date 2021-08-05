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
        public int PriceAwitSakit { get; set; }
        public string NameBabyBoi { get; set; }
        public DateTime DateTayo { get; set; }
        public List<string> ItemsInMyBag { get; set; }
    }
}
