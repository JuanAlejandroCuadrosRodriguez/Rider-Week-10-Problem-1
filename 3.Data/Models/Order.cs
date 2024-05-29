namespace _3.Data.Models;

public class Order : BaseModel
{
    public int ClientId {get; set;}
    public DateTime Date {get; set;}
    public int Total {get; set;}
}