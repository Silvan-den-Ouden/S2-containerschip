using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace S2_containerschip
{
    public class Row
    {
        List<Stack> Stacks { get; set; }

        //public Row() {
        //    Stacks = new();
        //}

        public void MakeStacksBasedOnWidthOfShip(int shipWidth)
        {
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

        // CanAddContainer
        // should check if stack.CanAddContainer
        // if container is cooled only can add front row ooga booga


    }
}
