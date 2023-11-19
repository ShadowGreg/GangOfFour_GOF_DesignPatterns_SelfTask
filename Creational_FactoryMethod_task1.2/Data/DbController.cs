using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Text;
using Creational_FactoryMethod_task1._2.Domain.Interfaces;
using Microsoft.Data.Sqlite;

namespace Creational_FactoryMethod_task1._2.Data;

public class DbController: IdbController {
    public Task CreateTable() {
        using (var connection = dbConnection.GetConnection()) {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText =
                "CREATE TABLE IF NOT EXISTS HardDrives (" +
                "\n ProductType TEXT, \n" +
                "\n ItemNumber INT UNIQUE, \n" +
                "\n ItemName TEXT, \n " +
                "\n ItemPrice REAL, \n" +
                "\n Volume INT, \n" +
                "\n RotationalSpeed INT," +
                "\n InterfaceType TEXT\n" +
                ");" +
                "CREATE TABLE IF NOT EXISTS MotherBoard (" +
                "\n ProductType TEXT, \n" +
                "\n ItemNumber INT UNIQUE, \n" +
                "\n ItemName TEXT, \n " +
                "\n ItemPrice REAL, \n" +
                "\n SocketType TEXT, \n" +
                "\n NumberOfProcessors TEXT," +
                "\n RamType TEXT,\n" +
                "\n SystemBusFrequency TEXT\n" +
                ");" +
                "CREATE TABLE IF NOT EXISTS Processors (" +
                "\n ProductType TEXT, \n" +
                "\n ItemNumber INT UNIQUE, \n" +
                "\n ItemName TEXT, \n " +
                "\n ItemPrice REAL, \n" +
                "\n SocketType TEXT, \n" +
                "\n NumberOfCores INT," +
                "\n ClockFrequency INT,\n" +
                "\n TechnicalProcess TEXT\n" +
                ");"
                ;
            command.ExecuteNonQuery();
            try {
                command.CommandText =
                    "INSERT INTO HardDrives (ProductType, ItemNumber, ItemName, ItemPrice, Volume, RotationalSpeed, InterfaceType) VALUES " +
                    "('HardDrive', 1, 'Hard Drive 1', 100.0, 500, 7200, 'SATA'), " +
                    "('HardDrive', 2, 'Hard Drive 2', 150.0, 1000, 5400, 'SATA'), " +
                    "('HardDrive', 3, 'Hard Drive 3', 200.0, 2000, 7200, 'NVMe'), " +
                    "('HardDrive', 4, 'Hard Drive 4', 120.0, 500, 5400, 'SATA'), " +
                    "('HardDrive', 5, 'Hard Drive 5', 180.0, 1000, 7200, 'NVMe');";
                command.ExecuteNonQuery();

                command.CommandText =
                    "INSERT INTO MotherBoard (ProductType, ItemNumber, ItemName, ItemPrice, SocketType, NumberOfProcessors, RamType, SystemBusFrequency) VALUES " +
                    "('MotherBoard', 6, 'Motherboard 1', 200.0, 'Socket AM4', 'Single', 'DDR4', '1000 MHz'), " +
                    "('MotherBoard', 7, 'Motherboard 2', 250.0, 'Socket LGA1151', 'Dual', 'DDR4', '1200 MHz'), " +
                    "('MotherBoard', 8, 'Motherboard 3', 300.0, 'Socket TR4', 'Quad', 'DDR4', '1600 MHz'), " +
                    "('MotherBoard', 9, 'Motherboard 4', 220.0, 'Socket AM4', 'Single', 'DDR4', '1000 MHz'), " +
                    "('MotherBoard', 10, 'Motherboard 5', 280.0, 'Socket LGA1151', 'Dual', 'DDR4', '1200 MHz');";
                command.ExecuteNonQuery();

                command.CommandText =
                    "INSERT INTO Processors (ProductType, ItemNumber, ItemName, ItemPrice, SocketType, NumberOfCores, ClockFrequency, TechnicalProcess) VALUES " +
                    "('Processor', 11, 'Processor 1', 150.0, 'Socket AM4', 4, 3.6, '7nm'), " +
                    "('Processor', 12, 'Processor 2', 200.0, 'Socket LGA1151', 6, 3.2, '14nm'), " +
                    "('Processor', 13, 'Processor 3', 250.0, 'Socket TR4', 8, 3.0, '7nm'), " +
                    "('Processor', 14, 'Processor 4', 180.0, 'Socket AM4', 4, 3.5, '7nm'), " +
                    "('Processor', 15, 'Processor 5', 220.0, 'Socket LGA1151', 6, 3.0, '14nm');";
                command.ExecuteNonQuery();
            }
            catch (SqliteException e) {
                Console.WriteLine(e);
            }
            finally {
                connection.Close();
            }
        }

        return Task.CompletedTask;
    }

    public async Task<List<string>>? GetAllProducts() {
        List<string> collection = new List<string>();
        using (var connection = dbConnection.GetConnection()) {
            connection.Open();
            var command = connection.CreateCommand();
            List<string> queries = new List<string>() {
                "SELECT * FROM HardDrives",
                "SELECT * FROM MotherBoard",
                "SELECT * FROM Processors"
            };
            foreach (var variablQuery in queries) {
                await GenerateListItem(command, variablQuery, collection);
            }
        }

        return await Task.FromResult(collection);
    }

    private static Task GenerateListItem(SqliteCommand command, string query, List<string> collection) {
        command.CommandText = query;

        using var reader = command.ExecuteReader();
        if (!reader.HasRows) return Task.FromException(new Exception("No rows found."));
        while (reader.Read()) // построчно считываем данные
        {
            ReadOnlyCollection<DbColumn> columns = reader.GetColumnSchema();
            StringBuilder tempString = new StringBuilder();
            foreach (var column in columns) {
                string columnName = column.ColumnName;
                object columnValue = reader[columnName];
                tempString.Append($"{columnName}: {columnValue} ");
            }

            collection.Add(tempString.ToString());
        }

        return Task.CompletedTask;
    }

    public async Task<string?>? GetProductByNumber(int number) {
        List<string> queries = new List<string>() {
            "SELECT * FROM HardDrives",
            "SELECT * FROM MotherBoard",
            "SELECT * FROM Processors"
        };
        foreach (var text in queries) {
            string query = $"{text} WHERE ItemNumber = {number};";

            string? product = "";
            using (var connection = dbConnection.GetConnection()) {
                connection.Open();
                using (SqliteCommand command = new SqliteCommand(query, connection)) {
                    using (SqliteDataReader reader = await command.ExecuteReaderAsync()) {
                        while (reader.Read()) {
                            string? result = "";

                            for (int i = 0; i < reader.FieldCount; i++) {
                                string columnName = reader.GetName(i);
                                string columnValue = reader.GetValue(i).ToString();

                                result += $"{columnName}:{columnValue} ";
                            }

                            Console.WriteLine(result);
                            product = result;
                            return await Task.FromResult(product);
                        }
                    }
                }
            }
        }

        return await Task.FromResult("");
    }
}