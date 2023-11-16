namespace Creational_FactoryMethod.Core;

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