namespace S2_containerschip
{
    public class Line
    {
        public List<Stack> Stacks { get; set; }

        public Line()
        {
            Stacks = new();
        }

        public void MakeLinesBasedOnWidthOfShip(int shipWidth)
        {
            if(shipWidth == 0) {
                throw new InvalidOperationException("Cannot make infinitly thin ship.");
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
            int stackIndex = GetIndexToAdd(container);
            if (stackIndex == -1)
            {
                throw new InvalidOperationException("Could not find a line to add container to.");
            }

            if (CanAddContainerToLine(container))
            {
                Stacks[stackIndex].AddContainer(container);
            } else
            {
                throw new InvalidOperationException("Could not add container to a line.");
            }
        }
        
        public bool CanAddContainerToLine(Container container)
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
