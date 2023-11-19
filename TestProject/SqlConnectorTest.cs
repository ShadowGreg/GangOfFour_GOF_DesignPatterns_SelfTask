using Creational_FactoryMethod_task1._2.Infrastructure.DataConnectors;

namespace TestProject; 

public class SqlConnectorTest {
    [Fact]
    public void Create_Connector_Test_Thet_not_null() {
        //Arrange

        //Act
        var actual =  SqlConnector.GetConnection();

        //Assert
        Assert.NotNull(actual);
    }
}