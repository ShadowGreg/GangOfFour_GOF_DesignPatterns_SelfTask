using Creational_FactoryMethod_task1._1.Core;

namespace Creational_FactoryMethod_task1._1.DataBase;

public class DataBaseOperation: IDataBaseConnection {
    public List<BaseDoc> GetAllData() {
        return DataInMemory.DocsList;
    }

    public string GetDocumentByNumber(string number) {
        return DataInMemory.Json(number);
    }
}