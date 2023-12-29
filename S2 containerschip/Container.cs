using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2_containerschip
{
    public class Container
    {
        public int Weight { get; set; }
        public bool Cooled { get; set; }
        public bool Valuable { get; set; }
        public static int MaxLoad = 120;

        public Container(int weight, bool cooled, bool valuable) { 
            Weight = weight;
            Cooled = cooled;
            Valuable = valuable;
        }
    }
}
