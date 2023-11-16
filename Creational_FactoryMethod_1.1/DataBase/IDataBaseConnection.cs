
using Creational_FactoryMethod.Core;

namespace Creational_FactoryMethod.Controller;

public interface IDataBaseConnection {
    List<BaseDoc> GetAllData();
    string GetDocumentByNumber(string number);
}