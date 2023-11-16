using System.Text;
using Creational_FactoryMethod.Core;
using Newtonsoft.Json;

namespace Creational_FactoryMethod.Controller;

public class DataInMemory {
    public static List<BaseDoc> DocsList = new() {
        new BaseDoc() {
            Id = 1,
            Number = "1",
            Date = DateTime.Parse("01.01.2021"),
            BriefContent = "BriefContent1",
            DocType = BaseDocType.Letter,

        },
        new BaseDoc() {
            Id = 2,
            Number = "2",
            Date = DateTime.Parse("02.02.2021"),
            BriefContent = "BriefContent2",
            DocType = BaseDocType.Letter,
        },
        new BaseDoc() {
            Id = 3,
            Number = "3",
            Date = DateTime.Parse("03.03.2021"),
            BriefContent = "BriefContent3",
            DocType = BaseDocType.Order,
        },
        new BaseDoc() {
            Id = 4,
            Number = "4",
            Date = DateTime.Parse("04.04.2021"),
            BriefContent = "BriefContent4",
            DocType = BaseDocType.Order,
        },
        new BaseDoc() {
            Id = 5,
            Number = "5",
            Date = DateTime.Parse("05.05.2021"),
            BriefContent = "BriefContent5",
            DocType = BaseDocType.Disposal,
        },
        new BaseDoc() {
            Id = 6,
            Number = "6",
            Date = DateTime.Parse("06.06.2021"),
            BriefContent = "BriefContent6",
            DocType = BaseDocType.Disposal,
        },
        new BaseDoc() {
            Id = 7,
            Number = "7",
            Date = DateTime.Parse("07.07.2021"),
            BriefContent = "BriefContent7",
            DocType = BaseDocType.Disposal,
        }
    };

    private static List<Letter> Letters = new() {
        new Letter() {
            Id = 1,
            BaseDocId = 1,
            Type = TypeLetter.Incoming,
            Correspondent = "Correspondent1",
        },
        new Letter() {
            Id = 2,
            BaseDocId = 2,
            Type = TypeLetter.Outgoing,
            Correspondent = "Correspondent2",
        }
    };

    private static List<Order> Orders = new() {
        new Order() {
            Id = 1,
            BaseDocId = 3,
            Department = "Department1",
            DedLine = DateTime.Parse("01.01.2021"),
            Executor = "Executor1",
        },
        new Order() {
            Id = 2,
            BaseDocId = 4,
            Department = "Department2",
            DedLine = DateTime.Parse("02.02.2021"),
            Executor = "Executor2",
        }
    };

    private static List<Disposal> Disposals = new() {
        new Disposal() {
            Id = 1,
            BaseDocId = 5,
            Employee = "Employee1",
            DayPeriod = 7,
            Destination = "Destination1",
        },
        new Disposal() {
            Id = 2,
            BaseDocId = 6,
            Employee = "Employee2",
            DayPeriod = 14,
            Destination = "Destination2",
        },
        new Disposal() {
            Id = 3,
            BaseDocId = 7,
            Employee = "Employee3",
            DayPeriod = 23,
            Destination = "Destination3",
        }
    };
    
    public static string Json(string number) {
        StringBuilder answer = new StringBuilder();
        var temp =DocsList.Find(x => x.Number == number);
        answer.Append(JsonConvert.SerializeObject(temp) );
        var docId = temp.Id;
        BaseData ans = null;

        foreach (var order in Orders.Where(order => order.BaseDocId==docId)) {
            ans = order;
        }
        foreach (var letter in Letters.Where(order => order.BaseDocId==docId)) {
            ans = letter;
        }
        foreach (var disposal in Disposals.Where(order => order.BaseDocId==docId)) {
            ans = disposal;
        }
        answer.Append(JsonConvert.SerializeObject(ans));
        return answer.ToString();
    }
    
}