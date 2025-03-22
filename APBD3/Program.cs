namespace APBD3;

internal static class Program {
    public static void Main(string[] args) {
        Ship ship = new Ship("Poseidon", 25, 10, 5000);

        Container gasContainer = new GasContainer(5000, 300, 1000, 1000, 4000, 10);
        Container liquidContainer = new LiquidContainer(2000, 250, 1000, 1000,4000, false);
        Container liquidContainer2 = new LiquidContainer(1000, 260, 1000, 1000, 3000, true);
        Container refrigeratedContainer = new RefrigeratedContainer(3000, 330, 1000, 1000, 3500, "Bananas", 20);
        
        ship.LoadContainer(gasContainer);
        ship.LoadContainer(liquidContainer);
        ship.LoadContainer(liquidContainer2);
        ship.LoadContainer(refrigeratedContainer);
        
        ship.ListContainers();

        gasContainer.Load(1000);
        liquidContainer.Load(3900);
        liquidContainer2.Load(1600);
        refrigeratedContainer.Load(1000);
        
        ship.ListContainers();

        ship.UnloadContainer(gasContainer.Id);
        
        ship.ListContainers();
    }
}