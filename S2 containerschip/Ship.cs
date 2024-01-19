namespace S2_containerschip
{
    public class Ship
    {
        int MaximumLoad { get; set; }
        public Grid Grid { get; set; }

        public Ship(int length, int width, int maximumLoad)
        {
            Grid = new(length, width);
            MaximumLoad = maximumLoad;
        }

        public void FillShip(List<Container> containers) { 
            //SortContainers
            foreach(Container container in containers)
            {
                AddContainer(container);
            }      

            if (Grid.GetTotalWeight() <= MaximumLoad * 0.5)
            {
                throw new InvalidOperationException("Ship cannot set sail, load weighs to little");
            }
        }

        private void AddContainer(Container container)
        {
            if(Grid.GetTotalWeight() + container.GetWeight() <= MaximumLoad) {
                Grid.AddContainer(container);
            } else
            {
                throw new InvalidOperationException("Could not add container to ship");
            }
        }
    }
}
