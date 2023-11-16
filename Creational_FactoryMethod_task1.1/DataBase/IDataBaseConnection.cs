using Creational_FactoryMethod_task1._1.Core;

namespace Creational_FactoryMethod_task1._1.DataBase;
public interface IDataBaseConnection {
    List<BaseDoc> GetAllData();
    string GetDocumentByNumber(string number);
}