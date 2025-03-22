namespace APBD3;

public abstract class Container {
    public double Weight { get; private set; } //Szerokość
    public double Height { get; private set; } //Wysokość
    public double Depth { get; private set; } //Głębokość
    public double DeadWeight{ get; private set; } //Masa własna
    public double MaxLoad { get; private set; } //Ładowność
    public string SerialNumber { get; private set; } //Numer seryjny
    public double LoadMass { get; set; } // Obecna masa ładunku
    public ContainerType Type { get; }
    public int Id { get; }
    private static int _nextId = 0;
    

    protected Container(ContainerType type, double weight, double height, double depth, double deadWeight, double maxLoad) {
        Id = _nextId++;
        SerialNumber = $"KON-{type}-{Id}";
        Type = type;
        DeadWeight = deadWeight;
        Weight = weight;
        Height = height;
        Depth = depth;
        MaxLoad = maxLoad;
    }

    public virtual void Load(double mass) {
        if (LoadMass + mass > MaxLoad)
            throw new OverfillException("Maximum container load exceeded!");
        if (mass < 0)  
            throw new ArgumentException("Invalid mass!");
        
        LoadMass += mass;
    }

    public virtual void Unload() {
        LoadMass = 0;
    }
}