namespace Creational_FactoryMethod_task1._2.Domain.Entities;

public class MotherBoard: Product {
    /// <summary>
    /// socket type
    /// </summary>
    public string SocketType { get; set; }
    /// <summary>
    /// number of processors
    /// </summary>
    public string NumberOfProcessors { get; set; } 
    /// <summary>
    /// type of RAM
    /// </summary>
    public string RamType { get; set; }
    /// <summary>
    /// system bus frequency
    /// </summary>
    public string SystemBusFrequency { get; set; } 
}