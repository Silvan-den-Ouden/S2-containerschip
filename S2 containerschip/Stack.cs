﻿namespace S2_containerschip
{
    public class Stack
    {
        public List<Container> Containers { get; set; }

        public Stack() {
            Containers = new();
        }

        public void AddContainer(Container container)
        {
            if(CanAddContainerToStack(container))
            {
                Containers.Add(container);
            } else
            {
                throw new InvalidOperationException("Could not add container to stack.");
            }
        }

        public bool CanAddContainerToStack(Container container)
        {
            if(GetLoadOnBottomContainer() + container.GetWeight() > container.GetMaxLoad())
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
                load += Containers[i].GetWeight();
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
