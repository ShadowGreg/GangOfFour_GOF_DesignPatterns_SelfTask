using System.Formats.Asn1;
using Microsoft.Data.Sqlite;

namespace Creational_FactoryMethod_task1._2.Data;

public static class dbConnection {
    private static SqliteConnection _connection;

    private static void CreateDBFile() {
        if (!File.Exists("../../../../Creational_FactoryMethod_task1.2/Data/database.db")) {
            File.Create("../../../../Creational_FactoryMethod_task1.2/Data/database.db").Close();
        }
    }

    public static SqliteConnection GetConnection() {
        switch (_connection) {
            case null:
                CreateDBFile();
                _connection =
                    new SqliteConnection("Data Source=../../../../Creational_FactoryMethod_task1.2/Data/database.db");
                break;
            case not null:
            {
                try {
                    _connection.Close();
                    // throw new AsnContentException("Connection already exists");
                }
                catch (Exception e) {
                    Console.WriteLine(e);
                    // throw;
                }

                break;
            }
        }

        return _connection;
    }
}