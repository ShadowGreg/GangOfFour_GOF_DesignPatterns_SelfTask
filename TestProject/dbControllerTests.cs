using System.Formats.Asn1;
using Creational_FactoryMethod_task1._2.Data;

namespace TestProject;

public class dbControllerTests {
    [Fact]
    public void Create_And_Populate_A_Database_With_Relevant_Data() {
        //Arrange
        DbController controller = new DbController();

        //Act
        var primeService = controller.CreateTable();

        //Assert
        Assert.NotNull(primeService);
    }

    [Fact]
    public void Get_All_Data_From_The_Database_And_Return_It() {
        DbController controller = new DbController();

        //Act
        var primeService = controller.GetAllProducts();

        //Assert
        Assert.NotNull(primeService);
    }

    [Fact]
    public void Get_All_Data_From_The_Database_And_Return_It_With_QueriesCount() {
        DbController controller = new DbController();

        //Act
        var actual = controller.GetAllProducts().Result.Count;

        //Assert
        Assert.Equal(15, actual);
    }

    [Fact]
    public void GetProductByNumber_With_Correct_Number() {
        DbController controller = new DbController();
        string expected =
            "ProductType:Processor ItemNumber:14 ItemName:Processor 4 ItemPrice:180 SocketType:Socket AM4 NumberOfCores:4 ClockFrequency:3,5 TechnicalProcess:7nm ";

        //Act
        var actual = controller.GetProductByNumber(14).Result;

        //Assert
        Assert.Equal(expected, actual);
    }
}