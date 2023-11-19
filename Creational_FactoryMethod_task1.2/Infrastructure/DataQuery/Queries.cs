using Creational_FactoryMethod_task1._2.Domain.Interfaces;
using Creational_FactoryMethod_task1._2.Infrastructure.DataConnectors;

namespace Creational_FactoryMethod_task1._2.Infrastructure.DataQuery; 

public class Queries: IQuery  {
    private readonly IdbController _dbController = SqlConnector.GetConnection();

    public Task<List<string>>? GetProducts() {
        return _dbController?.GetAllProducts();
    }

    public Task<string?>? GetProductById(int id) {
        return _dbController?.GetProductByNumber(id);
    }
}