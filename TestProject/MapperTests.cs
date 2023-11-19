using Creational_FactoryMethod_task1._2.Domain.Entities;
using Creational_FactoryMethod_task1._2.Domain.Maperas;

namespace TestProject; 

public class MapperTests {
    [Fact]
    public void GetProductByNumber_With_Correct_Number() {
        Mapper mapper = new Mapper();
        string text =
            "ProductType:Processor ItemNumber:14 ItemName:Processor 4 ItemPrice:180 SocketType:Socket AM4 NumberOfCores:4 ClockFrequency:3,5 TechnicalProcess:7nm ";
        string[] array = text.Split(' ');


        //Act
        var actual = mapper.GenerateProduct<Processors>(array);

        //Assert
        Assert.NotNull(actual);
    }
    
}