using Creational_FactoryMethod_task1._2.Domain.Entities;
using Creational_FactoryMethod_task1._2.Infrastructure.DataQuery;

namespace Creational_FactoryMethod_task1._2.Domain.Maperas;

public class Mapper {
    public Product MapToProduct(string query) {
        return GetSomeProduct(query);
    }

    public Product GetSomeProduct(string query) {
        string[] fields = query.Split(" ");
        string type = fields[0].Split(":")[1];

        switch (type) {
            case "Processor":
                return GenerateProduct<Processors>(fields);
            case "MotherBoard":
                return GenerateProduct<MotherBoard>(fields);
            case "HardDrive":
                return GenerateProduct<HardDrive>(fields);
        }

        throw new Exception("No such type");
    }

    public Product GenerateProduct<T>(string[] fields) {
        Dictionary<string, string> properties = GetProperties(fields);
        return (Product)Activator.CreateInstance(typeof(T), properties);
    }

    private static Dictionary<string, string> GetProperties(string[] fields) {
        Dictionary<string, string> properties = new();
        foreach (var item in fields) {
            string[] temp = item.Split(":");
            properties.Add(temp[0], temp[1]);
        }

        return properties;
    }
}