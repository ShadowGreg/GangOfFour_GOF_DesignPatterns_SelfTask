namespace Creational_FactoryMethod_task1._2.Domain.Entities;

public enum ProductType {
    MotherBoard,
    Processor,
    HardDisk
}

public class Product {
    public ProductType ProductType { get; set; }
    public int ItemNumber { get; set; }
    public string ItemName { get; set; }
    public double ItemPrice { get; set; }
}