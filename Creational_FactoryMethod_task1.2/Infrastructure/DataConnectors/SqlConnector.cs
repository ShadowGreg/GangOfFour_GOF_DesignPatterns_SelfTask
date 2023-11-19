using Creational_FactoryMethod_task1._2.Data;
using Creational_FactoryMethod_task1._2.Domain.Interfaces;

namespace Creational_FactoryMethod_task1._2.Infrastructure.DataConnectors;

public static class SqlConnector {
    private static IdbController _dbController = new DbController();

    public static IdbController GetConnection() {
        _dbController.CreateTable();
        return _dbController;
    }
}