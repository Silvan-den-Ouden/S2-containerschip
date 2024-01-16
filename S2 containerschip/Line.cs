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
            bool addedContainer = false;

            for (int i = 0; i < Stacks.Count; i++)
            {
                if (LineCanAddContainer(container, i))
                {
                    if (Stacks[i].CanAddContainerToStack(container))
                    {
                        Stacks[i].AddContainer(container);
                        addedContainer = true;
                        break;
                    }
                }
            }

            if(!addedContainer)
            {
                throw new InvalidOperationException("Could not add container to any line");
            }

        }

        // FEEDBACK VRAGEN: should I have multiple or just one return?
        public bool LineCanAddContainer(Container container, int stackIndex)
        {
            bool result = false;

            if (ShouldAddContainer(stackIndex))
            {
                if (container.Valuable && CanAddValuableContainer(stackIndex))
                {
                    result = true;
                }
                else if (container.Cooled && CanAddCoolableContainer(stackIndex))
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

        public bool ShouldAddContainer(int stackIndex)
        {
            if (stackIndex < 0 || stackIndex >= Stacks.Count)
            {
                return false;
            }

            bool stackBehindHasValuable = (stackIndex + 1 < Stacks.Count) && Stacks[stackIndex + 1].HasValuable();
            bool stackInFrontHasValuable = (stackIndex - 1 >= 0) && Stacks[stackIndex - 1].HasValuable();
            int heightOfStackBehind = stackBehindHasValuable ? Stacks[stackIndex + 1].Containers.Count : -1;
            int heightOfStackInFront = stackInFrontHasValuable ? Stacks[stackIndex - 1].Containers.Count : -1;

            int futureHeightOfStack = Stacks[stackIndex].Containers.Count + 1;

            if ((stackIndex + 1) % 3 == 0)
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
