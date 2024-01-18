namespace S2_containerschip
{
    public class Grid
    {
        List<Line> Rows { get; set; }

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

        public void AddContainer()
        {

        }

        

        // needs:
        // width
        // length
        // max carry capacity
        // functionality so it doesnt capsize
        // checks so that 50% of the max ship weight is used
    }
}
