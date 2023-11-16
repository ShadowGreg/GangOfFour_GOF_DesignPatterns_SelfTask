using System.Text;
using Creational_FactoryMethod.Core;
using Newtonsoft.Json;

namespace Creational_FactoryMethod.Controller;

public class PreviewController {
    private static IDataBaseConnection _connection;

    public PreviewController(IDataBaseConnection connection) {
        _connection = connection;
    }

    public string GetAllData() {
        StringBuilder allDocsTable = new StringBuilder();
        foreach (var doc in _connection.GetAllData()) {
            allDocsTable.AppendLine(doc.ToString() + "\n");
        }

        return allDocsTable.ToString();
    }

    public string GetDocumentByNumber(string number) {
        string answer = GetDocument(_connection.GetDocumentByNumber(number));
        return answer;
    }

    public string GetDocument(string json) {
        BaseDoc baseDoc = JsonConvert.DeserializeObject<BaseDoc>(json);
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
            dynamicObj = JsonConvert.DeserializeObject(json, classType) ?? "No such type";
        }

        var output = new StringBuilder();

        output.AppendLine(baseDoc.ToString());
        output.AppendLine(dynamicObj?.ToString());
        return output.ToString();
    }
}