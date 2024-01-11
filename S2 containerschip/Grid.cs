namespace S2_containerschip
{
    public class Grid
    {
        List<Row> rows { get; set; }

        // first row is front
        public Grid()
        {
            rows = new();
        }

        public void MakeRowsBasedOnLengthOfShip(int length)
        {

        }
        
        // When trying to add container, it should add if the row in front of it does not contain a valuable container at the same height
        //  CanAddContainer()
        //  Row.CanAddContainer should be true
        //  Check the thingie above aswell
    }
}
