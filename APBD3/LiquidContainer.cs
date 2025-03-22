namespace APBD3;

public class LiquidContainer : Container, IHazardNotifier {
    private readonly bool _isHazardous;

    public LiquidContainer(double weight, double height, double depth, double deadWeight, double maxLoad, bool isHazardous)
        : base(ContainerType.L, weight, height, depth, deadWeight, maxLoad) {
        _isHazardous = isHazardous;
    }

    public override void Load(double mass) {
        var limit = _isHazardous ? MaxLoad*0.5 : MaxLoad*0.9;
        if (LoadMass + mass > limit) {
            HazardNotifier("Jebnie");
        }
        base.Load(mass);
    }

    public void HazardNotifier(string message) {
        Console.WriteLine($"[ALERT] Container {Id}: {message}");
    }
}