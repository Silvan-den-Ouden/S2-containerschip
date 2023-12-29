using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2_containerschip
{
    public class Ship
    {
        List<Row> rows { get; set; }

        // first row is front
        public Ship()
        {
            rows = new();
        }

        // MakeRowsBasedOnLengthOfShip()
    }
}
