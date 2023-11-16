using Creational_FactoryMethod_task1._1.Controller;
using Creational_FactoryMethod_task1._1.DataBase;

namespace TestProject;

public class PreviewControllerTest {
    [Fact]
    public void GetDocument_InputCorrectJson_ReturnNotNullString() {
        //Arrange
        PreviewController controller = new PreviewController(new DataBaseOperation());
        string json =
            "{\"Id\":2,\"Number\":\"2\",\"Date\":\"2021-02-02T00:00:00\",\"BriefContent\":\"BriefContent2\"}{\"Type\":1,\"Correspondent\":\"Correspondent2\",\"Id\":2,\"BaseDocId\":2,\"DocType\":0}";

        //Act
        var primeService = controller.GetDocument(json);

        //Assert
        Assert.NotNull(primeService);
    }
}