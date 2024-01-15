namespace S2_containerschip
{
    public class Grid
    {
        List<Line> Rows { get; set; }

        // first row is front
        public Grid()
        {
            Rows = new();
        }

        public void MakeRowsBasedOnLengthOfShip(int shipLength)
        {
            if (shipLength == 0)
            {
                throw new InvalidOperationException("Cannot make infinitly thin ship.");
            }
            if (shipLength < 0)
            {
                throw new InvalidOperationException("Cannot make imaginary ship.");
            }

            for (int i = 0; i < shipLength; i++)
            {
                Rows.Add(new Line());
            }
        }

        public void AddContainerToGrid()
        {

        }

        public bool ShouldAddContainer(Container container, int rowIndex)
        {
            int stackIndex = Rows[rowIndex].GetIndexToAdd(container);
            bool stackBehindHasValuable = Rows[rowIndex++].Stacks[stackIndex].HasValuable();
            bool stackInFrontHasValuable = Rows[rowIndex--].Stacks[stackIndex].HasValuable();

            // should check (if its a %3 row) && (if i-- and i++ have valuable) if its lower than both i-- and i++
            if ((rowIndex++ % 3 == 0) && (stackBehindHasValuable || stackInFrontHasValuable)) { 
                
            }

            return false;
        }

        // FEEDBACK VRAGEN: should I have multiple or juse one return?
        public bool CanAddContainer(Container container)
        {
            bool result = false;

            //if(container.Valuable && container.Cooled) { 
            //    if(CanAddValuableContainer(container) && CanAddCoolableContainer(container))
            //    {
            //        result = true;
            //    } 
            //} 

            if (container.Valuable && CanAddValuableContainer(container)) {
                result = true;
            }

            if (container.Cooled && CanAddCoolableContainer(container))
            {
                result = true;
            }

            return result;
        }
        
        public bool CanAddValuableContainer(Container container)
        {
            // should check if its not a %3 row

            return false;
        }

        public bool CanAddCoolableContainer(Container container)
        {
            // should check if the index of the row is equal to greatest index
            return false;
        }


        // When trying to add container, it should add if the row in front of it does not contain a valuable container at the same height
        //  CanAddContainer()
        //  Row.CanAddContainer should be true
        //  Check the thingie above aswell
    }
}
