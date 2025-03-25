namespace APBD3;

public class Ship
{
    private string Name { get; }
    public double MaxSpeedKnots { get; }
    private int MaxContainers { get; }
    private double MaxWeightTons { get; }
    
    private List<Container> Containers { get; } = new List<Container>();
    
    public Ship(string name, double maxSpeedKnots, int maxContainers, double maxWeightTons)
    {
        Name = name;
        MaxSpeedKnots = maxSpeedKnots;
        MaxContainers = maxContainers;
        MaxWeightTons = maxWeightTons;
    }
    
    public bool LoadContainer(Container container)
    {
        if (Containers.Count >= MaxContainers)
        {
            Console.WriteLine("Ship's container limit has been exceeded");
            return false;
        }

        var totalWeight = Containers.Sum(c => c.DeadWeight + c.LoadMass + c.Width);
        if (totalWeight + container.DeadWeight + container.LoadMass > MaxWeightTons * 1000)
        {
            Console.WriteLine("Maximum ship weight has been exceeded");
            return false;
        }

        Containers.Add(container);
        Console.WriteLine($"A container {container.Id} has been loaded");
        return true;
    }

    public bool UnloadContainer(int containerId)
    {
        var container = Containers.FirstOrDefault(c => c.Id == containerId);
        if (container == null)
        {
            Console.WriteLine("Container not found");
            return false;
        }

        Containers.Remove(container);
        Console.WriteLine($"Container {containerId} has been unloaded.");
        return true;
    }

    public void ListContainers()
    {
        Console.WriteLine($"Containers on board {Name}: ");
        foreach (var container in Containers)
        {
            Console.WriteLine($"- ID: {container.Id}, Type: {container.Type}, Load: {container.LoadMass} kg");
        }
    }
}