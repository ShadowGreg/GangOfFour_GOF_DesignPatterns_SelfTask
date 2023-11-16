namespace Creational_FactoryMethod_task1._1.Core;

public enum TypeLetter {
    Incoming,
    Outgoing
}

public class Letter: BaseData {
    public TypeLetter Type { get; set; }
    public string Correspondent { get; set; }

    public override string ToString() {
        return $"Type: {Type}, \n " +
               $"Correspondent: {Correspondent}";
    }
}