using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2_containerschip
{
    public class Harbor
    {
        public Ship Ship { get; private set; }

        public Harbor(Ship ship, List<Container> containers)
        {
            Ship = ship;

            Ship.FillShip(containers);
        }

        public void ShowShip()
        {
            if (Ship != null && Ship.Grid != null && Ship.Grid.Lines != null)
            {
                for (int i = 0; i < Ship.Grid.Lines.Count; i++)
                {
                    Console.WriteLine($"Line {i + 1}:");

                    if (Ship.Grid.Lines[i].Stacks != null)
                    {
                        for (int j = 0; j < Ship.Grid.Lines[i].Stacks.Count; j++)
                        {
                            Console.Write($"Stack {j + 1}: ");
                            if (Ship.Grid.Lines[i].Stacks[j].Containers != null)
                            {
                                for (int k = 0; k < Ship.Grid.Lines[i].Stacks[j].Containers.Count; k++)
                                {
                                    Console.Write($"{Ship.Grid.Lines[i].Stacks[j].Containers[k]} ");
                                }

                                Console.WriteLine();
                            }
                        }
                    }

                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Ship or its components are not properly initialized.");
            }
        }
    }

}
