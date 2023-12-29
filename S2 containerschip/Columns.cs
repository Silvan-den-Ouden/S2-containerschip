using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2_containerschip
{
    public class Columns
    {
        List<Row> rows { get; set; }

        // first row is front
        public Columns()
        {
            rows = new();
        }

        // MakeRowsBasedOnLengthOfShip()
        
        // When trying to add container, it should add if the row in front of it does not contain a valuable container at the same height
        //  CanAddContainer()
        //  Row.CanAddContainer should be true
        //  Check the thingie above aswell
    }
}
