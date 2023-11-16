using System.Text;
using Creational_FactoryMethod_task1._1.Core;
using Creational_FactoryMethod_task1._1.DataBase;
using Newtonsoft.Json;

namespace Creational_FactoryMethod_task1._1.Controller; 
public class PreviewController {
    private static IDataBaseConnection _connection;

    public PreviewController(IDataBaseConnection connection) {
        _connection = connection;
    }

    public string GetAllData() {
        StringBuilder allDocsTable = new StringBuilder();
        var connection = _connection.GetAllData();
        foreach (var doc in connection) {
            allDocsTable.AppendLine(doc + "\n");
        }

        return allDocsTable.ToString();
    }

    public string GetDocumentByNumber(string number) {
        string answer = GetDocument(_connection.GetDocumentByNumber(number));
        return answer;
    }

    public string GetDocument(string json) {
        string[] jsonParts = json.Split(new[] { "}{", }, StringSplitOptions.None);
        string part1 = jsonParts[0] + "}";
        string part2 = "{" + jsonParts[1];
        var baseDoc = JsonConvert.DeserializeObject<BaseDoc>(part1);
        Type classType = null;
        BaseDocType docType = baseDoc.DocType;

        switch (docType) {
            case BaseDocType.Letter:
                classType = typeof(Letter);
                break;
            case BaseDocType.Order:
                classType = typeof(Order);
                break;
            case BaseDocType.Disposal:
                classType = typeof(Disposal);
                break;
        }

        dynamic dynamicObj = null;
        if (classType != null) {
            dynamicObj = JsonConvert.DeserializeObject(part2, classType) ?? "No such type";
        }

        var output = new StringBuilder();

        output.AppendLine(baseDoc.ToString());
        output.AppendLine(dynamicObj?.ToString());
        return output.ToString();
    }
}