namespace APBD3;

public class GasContainer : Container, IHazardNotifier {
    public double Pressure { get; private set; }
    
    public GasContainer(double weight, double height, double depth, double deadWeight, double maxLoad, double pressure)
        : base(ContainerType.G, weight, height, depth, deadWeight, maxLoad)
    {
        Pressure = pressure;
    }

    public override void Load(double mass)
    {
        if (LoadMass + mass > MaxLoad)
            throw new OverfillException("Load exceeds max capacity");
        base.Load(mass);
    }

    public override void Unload()
    {
        LoadMass *= 0.05;
    }

    public void HazardNotifier(string message)
    {
        Console.WriteLine($"[ALERT] Gas Container {Id}: {message}");
    }
}