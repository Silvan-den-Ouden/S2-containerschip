namespace S2_containerschip
{
    public class Line
    {
        public List<Stack> Stacks { get; private set; }

        public Line(int shipLength)
        {
            Stacks = new();
            MakeLineBasedOnLengthOfShip(shipLength);
        }
        
        public Line()
        {
            Stacks = new();
        }

        public void MakeLineBasedOnLengthOfShip(int shipLength)
        {
            if (shipLength == 0) {
                throw new InvalidOperationException("Cannot make infinitly thin ship.");
            }
            if (shipLength < 0)
            {
                throw new InvalidOperationException("Cannot make imaginary ship.");
            }

            for (int i = 0; i < shipLength; i++) {
                Stacks.Add(new Stack());
            }
        }

        public void AddContainer(Container container)
        {
            bool addedContainer = false;

            
            if (LineCanAddContainer(container) != -1)
            {
                int stackIndex = LineCanAddContainer(container);
                if (Stacks[stackIndex].CanAddContainerToStack(container))
                {
                    Stacks[stackIndex].AddContainer(container);
                    addedContainer = true;
                }
            }
            

            if (!addedContainer)
            {
                throw new InvalidOperationException("Could not add container to line");
            }

        }

        public int LineCanAddContainer(Container container)
        {
            for (int stackIndex = 0; stackIndex < Stacks.Count; stackIndex++)
            {
                if (ShouldAddContainer(stackIndex) && Stacks[stackIndex].CanAddContainerToStack(container))
                {
                    if(container.Valuable && container.Cooled && CanAddValuableContainer(stackIndex) && CanAddCooledContainer(stackIndex))
                    {
                        return stackIndex;
                    }
                    if (container.Valuable && !container.Cooled && CanAddValuableContainer(stackIndex))
                    {
                        return stackIndex;
                    }
                    else if (container.Cooled && !container.Valuable && CanAddCooledContainer(stackIndex))
                    {
                        return stackIndex;
                    }
                    else if (!container.Cooled && !container.Valuable)
                    {
                        return stackIndex;
                    }
                }
            }

            return -1;
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
            if (Stacks[index].HasValuable())
            {
                return false;
            }

            if (HasValuableCooled())
            {
                if ((index + 2) % 3 == 0)
                {
                    return false;
                }
            }
            else
            {
                if ((index + 1) % 3 == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public bool CanAddCooledContainer(int index)
        {
            if (index != 0)
            {
                return false;
            }

            return true;
        }

        public int GetLineWeight()
        {
            int lineWeight = 0;

            foreach(Stack stack in Stacks)
            {
                lineWeight += stack.GetStackWeight();
            }

            return lineWeight;
        }


        public bool HasValuableCooled()
        {
            foreach(Container container in Stacks[0].Containers)
            {
                if (container.Valuable && container.Cooled)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
