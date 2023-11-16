namespace Creational_FactoryMethod.Core; 
public enum BaseDocType {
    Letter,
    Order,
    Disposal
}
public class BaseDoc {
    public int Id { get; set; }
    public string? Number { get; set; }
    public DateTime Date { get; set; }
    public string? BriefContent { get; set; }
    
    /// <summary>
    /// BaseDocType  :
    /// Letter, Order, Disposal 
    /// </summary>
    public BaseDocType DocType { get; set; }

    public override string ToString() {
        return $"Number: {Number}, \n " +
               $"Date: {Date}, \n " +
               $"BriefContent: {BriefContent}\n";
    }
}