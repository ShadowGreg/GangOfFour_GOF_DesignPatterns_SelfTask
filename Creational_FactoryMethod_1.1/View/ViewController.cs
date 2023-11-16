using Creational_FactoryMethod.Controller;

namespace Creational_FactoryMethod.View;

public class ViewController {
    static PreviewController _previewController = new PreviewController(new DataBaseOperation());

    public static void Run() {
        bool flag = true;
        while (flag) {
            Console.WriteLine("1. Show all docs\n2. Show document by number\n3. Exit");
            var promp = Console.ReadLine();
            switch (promp) {
                case "1":
                {
                    Console.WriteLine(_previewController.GetAllData());
                    break;
                }
                case "2":
                {
                    Console.WriteLine("Enter number: ");
                    Console.WriteLine(_previewController.GetDocumentByNumber(Console.ReadLine()));
                    break;
                }
                case "3":
                {
                    flag = false;
                    break;
                }
            }
        }
    }
}