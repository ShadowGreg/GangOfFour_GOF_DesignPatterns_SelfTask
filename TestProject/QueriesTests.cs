using Creational_FactoryMethod_task1._2.Data;
using Creational_FactoryMethod_task1._2.Infrastructure.DataConnectors;
using Creational_FactoryMethod_task1._2.Infrastructure.DataQuery;

namespace TestProject;

public class QueriesTests {
    [Fact]
    public void Create_Queries_Test_That_not_null() {
        //Arrange

        //Act
        var actual = new Queries();

        //Assert
        Assert.NotNull(actual);
    }

    [Fact]
    public void GetProducts_Queries_Test_That_not_null() {
        //Arrange
        var connections = new Queries();
        //Act
        var actual = connections.GetProducts();


        //Assert
        Assert.NotNull(actual);
    }

    [Fact]
    public void GetProductById_Queries_Test_That_not_null() {
        //Arrange
        var connections = new Queries();
        //Act
        var actual = connections.GetProductById(12);

        //Assert
        Assert.NotNull(actual);
    }
}