namespace Creational_FactoryMethod_task1._2.Infrastructure.DataQuery; 

public interface IQuery {
    Task<List<string>>? GetProducts();
    Task<string?>? GetProductById(int id);
}