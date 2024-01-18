namespace S2_containerschip
{
    public class Grid
    {
        List<Line> Lines { get; set; }

        public Grid()
        {
            Lines = new();
        }

        public void MakeLinesBasedOnLengthOfShip(int shipLength)
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
                Lines.Add(new Line());
            }
        }

        public void AddContainer(Container container)
        {
            if(CanPlaceInMiddleLine(container) != -1)
            {
                Lines[CanPlaceInMiddleLine(container)].AddContainer(container);
            } else
            {

            }
        }

        public int CanPlaceInMiddleLine(Container container)
        {
            int MiddleIndex = -1;

            if (Lines.Count % 2 != 0 && Lines[(Lines.Count - 1) / 2].LineCanAddContainer(container) != -1)
            {
                MiddleIndex = (Lines.Count - 1) / 2;
            }

            return MiddleIndex;
        }

        public int GetTotalWeight()
        {
            int totalWeight = 0;

            foreach(Line line in Lines) 
            { 
                totalWeight += line.GetLineWeight();
            }

            return totalWeight;
        }

        // needs:
        // width
        // length
        // max carry capacity
        // functionality so it doesnt capsize
        // checks so that 50% of the max ship weight is used
    }
}
