namespace Domain.Entities;

public class Category
{
    public int Id { get; set; }
    
    public string CategoryName { get; set; }
    
    
    //Navigation Properties
    public ICollection<Product> Products { get; set; }
    
    
    
    
}