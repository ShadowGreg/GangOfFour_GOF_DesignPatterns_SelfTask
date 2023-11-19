namespace Creational_FactoryMethod_task1._2.Domain.Interfaces;

public interface IdbController {
    Task CreateTable();
    Task<List<string>>? GetAllProducts();
    Task<string?>? GetProductByNumber(int number);
}