using Creational_FactoryMethod.Core;

namespace Creational_FactoryMethod.Controller; 

public class DataBaseOperation: IDataBaseConnection {
    public List<BaseDoc> GetAllData() {
        return DataInMemory.DocsList;
    }

    public string GetDocumentByNumber(string number) {
        return DataInMemory.Json(number);
    }
}