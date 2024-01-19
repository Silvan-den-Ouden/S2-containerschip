// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using S2_containerschip;

Console.WriteLine("Hello, World!");

Container NormalContainer = new(6000, false, false);
Container HeavyContainer = new(26000, false, false);
Container ValuableContainer = new(6000, false, true);
Container CooledContainer = new(16000, true, false);
Container ValCoolContainer = new(600, true, true);


Ship ship = new(5, 3, 2250000);

List<Container> containers = new();

//List<Container> heavyContainers = new();

containers.Add(ValCoolContainer);

for(int i = 1; i <= 10; i++)
{
    containers.Add(ValuableContainer);
}

for (int i = 1; i <= 15; i++)
{
    containers.Add(CooledContainer);
}

for (int i = 1; i <= 50; i++)
{
    containers.Add(HeavyContainer);
}

Harbor harbor = new(ship, containers);

harbor.ShowShip();
