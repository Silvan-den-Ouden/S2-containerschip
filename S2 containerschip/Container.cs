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
        // change this to GetMaxLoad()
        public static int MaxLoad = 120;

        public Container(int weight, bool cooled, bool valuable) { 
            Weight = weight;
            Cooled = cooled;
            Valuable = valuable;
        }

        // add max weight constraint to container (30 tonnes)
        // containers should weight 4000 kg + contents 
    }
}
