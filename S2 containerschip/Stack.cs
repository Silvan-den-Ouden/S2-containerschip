using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2_containerschip
{
    public class Stack
    {
        List<Container> Containers { get; set; }
        private int maxLoad = 120;

        public Stack() {
            Containers = new();
        }

        public void AddContainer(Container container)
        {
            if(CanAddContainer(container))
            {
                Containers.Add(container);
            } else
            {
                // handle error
            }
        }

        private bool CanAddContainer(Container container)
        {
            if(GetLoadOnBottomContainer() <= maxLoad)
            {
                return true;
            }

            return false;
        }
        //  does it not overload the bottom container
        //  if its cooled, is it on the first row
        //  valuable checks

        private int GetLoadOnBottomContainer()
        {
            int load = 0;

            for(int i = 1; i < Containers.Count; i++) {
                load += Containers[i].Weight;
            }

            return load;
        }
        // loop through all but the bottom container and add their weights
    }
}
