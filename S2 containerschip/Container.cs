using System;

namespace S2_containerschip
{
    public class Container
    {
        public int Content { get; set; }
        public bool Cooled { get; set; }
        public bool Valuable { get; set; }

        // All in kg
        private readonly int MaxLoad = 120000;
        private readonly int ContainerWeight = 4000;
        private readonly int MaxContainerWeight = 30000;

        public Container(int content, bool cooled, bool valuable)
        {
            if ((content + ContainerWeight) > MaxContainerWeight)
            {
                throw new InvalidOperationException("Container weight exceeds the maximum limit of 30 tonnes.");
            }

            Content = content;
            Cooled = cooled;
            Valuable = valuable;
        }

        public int GetMaxLoad()
        {
            return MaxLoad;
        }

        public int GetWeight()
        {
            int totalContainerWeight = Content + ContainerWeight;

            return totalContainerWeight;
        }
    }
}
