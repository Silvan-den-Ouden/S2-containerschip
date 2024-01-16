namespace S2_containerschip
{
    public class Line
    {
        public List<Stack> Stacks { get; set; }

        public Line()
        {
            Stacks = new();
        }

        public void MakeLineBasedOnLengthOfShip(int shipLength)
        {
            if(shipLength == 0) {
                throw new InvalidOperationException("Cannot make infinitly thin ship.");
            }
            if(shipLength < 0)
            {
                throw new InvalidOperationException("Cannot make imaginary ship.");
            }

            for(int i = 0; i < shipLength; i++) { 
                Stacks.Add(new Stack());
            }
        }

        public void AddContainer(Container container)
        {
            for(int i = 0; i < Stacks.Count; i++)
            {
                if(CanAddContainerToLine(container, i))
                {
                    Stacks[i].AddContainer(container);
                } else
                {
                    throw new InvalidOperationException($"Could not add container to line {i + 1}.");
                }
            }
        }

        // FEEDBACK VRAGEN: should I have multiple or juse one return?
        public bool CanAddContainerToLine(Container container, int index)
        {
            bool result = false;

            if (ShouldAddContainer(index))
            {
                if (container.Valuable && CanAddValuableContainer(index))
                {
                    result = true;
                }
                else if (container.Cooled && CanAddCoolableContainer(index))
                {
                    result = true;
                }
                else if (!container.Cooled && !container.Valuable)
                {
                    result = true;
                }
            }

            return result;
        }

        public bool ShouldAddContainer(int index)
        {
            if (index < 0 || index >= Stacks.Count)
            {
                return false;
            }

            bool stackBehindHasValuable = (index + 1 < Stacks.Count) && Stacks[index + 1].HasValuable();
            bool stackInFrontHasValuable = (index - 1 >= 0) && Stacks[index - 1].HasValuable();
            int heightOfStackBehind = stackBehindHasValuable ? Stacks[index + 1].Containers.Count : -1;
            int heightOfStackInFront = stackInFrontHasValuable ? Stacks[index - 1].Containers.Count : -1;

            int futureHeightOfStack = Stacks[index].Containers.Count + 1;

            if ((index + 1) % 3 == 0)
            {
                if (stackBehindHasValuable && futureHeightOfStack >= heightOfStackBehind)
                {
                    if (heightOfStackBehind != -1)
                    {
                        return false;
                    }
                }
                if (stackInFrontHasValuable && futureHeightOfStack >= heightOfStackInFront)
                {
                    if (heightOfStackInFront != -1)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool CanAddValuableContainer(int index)
        {
            if ((index + 1) % 3 == 0) {
                return false;
            }

            if (Stacks[index].HasValuable())
            {
                return false;
            }

            return true;
        }

        public bool CanAddCoolableContainer(int index)
        {
            if (Stacks.Count - 1 == index)
            {
                return false;
            }

            return true;
        }
    }
}
