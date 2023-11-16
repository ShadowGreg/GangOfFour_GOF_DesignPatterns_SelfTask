namespace Creational_FactoryMethod.Core;

public class Disposal : BaseData {
    public string? Employee { get; set; }
    public int DayPeriod { get; set; }
    public string? Destination { get; set; }

    public override string ToString() {
        return $"Employee: {Employee}, \n " +
               $"DayPeriod: {DayPeriod}, \n " +
               $"Destination: {Destination}\n";
    }
}