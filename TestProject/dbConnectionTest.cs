using System.Data.Common;
using Creational_FactoryMethod_task1._2.Data;

namespace TestProject;

public class dbConnectionTest {
    [Fact]
    public void Create_Connection_Test() {
        var temp = dbConnection.GetConnection();
        
        Assert.NotNull(temp);
    }
}