namespace S2_containerschip
{
    public class Row
    {
        public List<Stack> Stacks { get; set; }

        public Row()
        {
            Stacks = new();
        }

        public void MakeStacksBasedOnWidthOfShip(int shipWidth)
        {
            if(shipWidth == 0) {
                throw new InvalidOperationException("Cannot make infinitly small ship.");
            }
            if(shipWidth < 0)
            {
                throw new InvalidOperationException("Cannot make imaginary ship.");
            }

            for(int i = 0; i < shipWidth; i++) { 
                Stacks.Add(new Stack());
            }
        }

        public void AddContainer(Container container)
        {
            if(CanAddContainerToRow(container))
            {
                int stackIndex = GetIndexToAdd(container);
                Stacks[stackIndex].AddContainer(container);
            } else
            {
                throw new InvalidOperationException("Could not add container to a row.");
            }
        }
        
        public bool CanAddContainerToRow(Container container)
        {
            foreach(Stack stack in Stacks)
            {
                if (stack.CanAddContainerToStack(container))
                {
                    return true;
                }
            }

            return false;
        }

        public int GetIndexToAdd(Container container)
        {
            for(int i = 0; i < Stacks.Count; i++)
            {
                if (Stacks[i].CanAddContainerToStack(container))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
