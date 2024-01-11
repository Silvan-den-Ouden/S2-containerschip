namespace S2_containerschip
{
    public class Grid
    {
        List<Row> Rows { get; set; }

        // first row is front
        public Grid()
        {
            Rows = new();
        }

        public void MakeRowsBasedOnLengthOfShip(int shipLength)
        {
            if (shipLength == 0)
            {
                throw new InvalidOperationException("Cannot make infinitly small ship.");
            }
            if (shipLength < 0)
            {
                throw new InvalidOperationException("Cannot make imaginary ship.");
            }

            for (int i = 0; i < shipLength; i++)
            {
                Rows.Add(new Row());
            }
        }
        
        // When trying to add container, it should add if the row in front of it does not contain a valuable container at the same height
        //  CanAddContainer()
        //  Row.CanAddContainer should be true
        //  Check the thingie above aswell
    }
}
