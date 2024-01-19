namespace S2_containerschip
{
    public class Stack
    {
        public List<Container> Containers { get; private set; }

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
            if(GetStackWeight() > container.GetMaxLoad())
            {
                return false;
            }

            if(container.Valuable && HasValuable())
            {
                return false;
            }

            return true;
        }

        public int GetStackWeight()
        {
            int stackWeight = 0;

            for(int i = 0; i < Containers.Count; i++) {
                stackWeight += Containers[i].GetWeight();
            }

            return stackWeight;
        }

        public bool HasValuable()
        {
            foreach(Container container in Containers)
            {
                if (container.Valuable)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
