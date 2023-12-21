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
        // max gewicht op container is 120 ton

        public Container(int weight, bool cooled, bool valuable) { 
            Weight = weight;
            Cooled = cooled;
            Valuable = valuable;
        }
    }
}
