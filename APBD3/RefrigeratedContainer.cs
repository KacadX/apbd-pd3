namespace APBD3;

public class RefrigeratedContainer : Container {
    public string Product { get; set; }
    public double Temperature { get; set; }
    private static readonly Dictionary<string, double> AllowedTemperatures = new()
    {
        { "Bananas", 13.3 }, { "Chocolate", 18 }, { "Fish", 2 },
        { "Meat", -15 }, { "Ice cream", -18 }, { "Frozen pizza", -30 },
        { "Cheese", 7.2 }, { "Sausages", 5 }, { "Butter", 20.5 }, { "Eggs", 19 }
    };
    
    public RefrigeratedContainer(double width, double height, double depth, double deadWeight, double maxLoad, string product, double temperature)
        : base(ContainerType.C, width, height, depth, deadWeight, maxLoad)
    {
        if (!AllowedTemperatures.TryGetValue(product, out var allowedTemperature))
            throw new ArgumentException("Invalid product type");
        if (temperature < allowedTemperature)
            throw new InvalidOperationException("Temperature too low for product");
        Product = product;
        Temperature = temperature;
    }
}