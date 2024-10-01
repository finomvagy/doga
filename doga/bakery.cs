using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doga
{
   
    public class bakery
    {
       public static List<bakery> list = new List<bakery>();
        public int id { get; set; }
        public string name { get; set; }
        public int db  { get; set; }
        public int price { get; set; }
    }
}
