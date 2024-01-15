namespace S2_containerschip
{
    public class Stack
    {
        public List<Container> Containers { get; set; }
        public bool HasValuable { get ; set; }

        public Stack() {
            Containers = new();
            HasValuable = false;    
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

            return true;
        }

        public int GetStackWeight()
        {
            int load = 0;

            for(int i = 0; i < Containers.Count; i++) {
                load += Containers[i].GetWeight();
            }

            return load;
        }
    }
}
