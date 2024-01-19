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
            int MiddleLineIndex = CanPlaceInMiddleLine(container);
            bool containerAdded = false;

            if(MiddleLineIndex != -1)
            {
                Lines[MiddleLineIndex].AddContainer(container);
                containerAdded = true;
            }
            else
            {
                int leftLineIndex = GetLeftIndex(container);
                int rightLineIndex = GetRightIndex(container);

                if (GetLeftWeightPercentage() <= 0.5)
                {
                    if (leftLineIndex != -1 || rightLineIndex != -1)
                    {
                        Lines[leftLineIndex != -1 ? leftLineIndex : rightLineIndex].AddContainer(container);
                        containerAdded = true;
                    }
                } else
                {
                    if (rightLineIndex != -1 || leftLineIndex != -1)
                    {
                        Lines[rightLineIndex != -1 ? rightLineIndex : leftLineIndex].AddContainer(container);
                        containerAdded = true;
                    }
                }
            }

            if(!containerAdded)
            {
                throw new InvalidOperationException("Could not add container to ship.");
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

        public int GetLeftIndex(Container container)
        {
            for (int i = 0; i < Math.Floor(Lines.Count * 0.5); i++)
            {
                return Lines[i].LineCanAddContainer(container);
            }

            return -1;
        }

        public int GetRightIndex(Container container)
        {
            for (int i = Lines.Count - 1; i >= Math.Ceiling(Lines.Count * 0.5); i--)
            {
                return Lines[i].LineCanAddContainer(container);

            }

            return -1;
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
        
        public double GetLeftWeightPercentage()
        {
            double leftWeightPercentage = GetLeftWeight() / GetTotalWeight();

            return leftWeightPercentage;
        }

        public int GetLeftWeight()
        {
            int leftWeight = 0;

            for (int i = 0; i < Math.Floor(Lines.Count * 0.5); i++){
                leftWeight += Lines[i].GetLineWeight();
            }

            return leftWeight;
        }

        public double GetRightWeightPercentage()
        {
            double rightWeightPercentage = GetRightWeight() / GetTotalWeight();

            return rightWeightPercentage;
        }

        public int GetRightWeight()
        {
            int rightWeight = 0;

            for(int i = Lines.Count - 1; i >= Math.Ceiling(Lines.Count * 0.5); i--)
            {
                rightWeight += Lines[i].GetLineWeight();
            }

            return rightWeight;
        }
    }
}
