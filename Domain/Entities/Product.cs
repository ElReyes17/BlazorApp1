namespace Domain.Entities;

public class Product
{
    public int Id { get; set; }
    
    public string ProductName { get; set; }

    public int CategoryId  { get; set; }
    
    //Navigation Properties     
    
    public Category Category { get; set; }
}