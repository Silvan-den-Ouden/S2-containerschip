using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("Containership_Tests")]

namespace S2_containerschip
{
    public class Stack
    {
        List<Container> Containers { get; set; }

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

        public bool CanAddContainer(Container container)
        {
            // change this to .GetMaxLoad()
            if(GetLoadOnBottomContainer() + container.Weight > Container.MaxLoad)
            {
                return false;
            }

            if (TopIsValuable())
            {
                return false;
            }

            return true;
        }

        public int GetLoadOnBottomContainer()
        {
            int load = 0;

            for(int i = 1; i < Containers.Count; i++) {
                load += Containers[i].Weight;
            }

            return load;
        }

        public bool TopIsValuable()
        {
            // if there are no containers, the top cant be valuable
            if(Containers.Count == 0)
            {
                return false;
            }

            // checks if last (aka the top of the stack) container in containers is valuable 
            if (Containers[^1].Valuable)
            {
                return true;
            }

            return false;
        }
    }
}
