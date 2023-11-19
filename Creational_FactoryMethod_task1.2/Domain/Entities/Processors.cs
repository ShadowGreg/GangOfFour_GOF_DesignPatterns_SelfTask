namespace Creational_FactoryMethod_task1._2.Domain.Entities; 

public class Processors: Product {
    /// <summary>
    ///socket type 
    /// </summary>
    public string SocketType { get; set; }
    /// <summary>
    /// Number of Cores
    /// </summary>
    public int NumberOfCores { get; set; }
    /// <summary>
    /// clock frequency
    /// </summary>
    public int ClockFrequency { get; set; }
    /// <summary>
    /// technical process
    /// </summary>
    public string TechnicalProcess { get; set; }
}