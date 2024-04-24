using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> context) : base(context)
    {
        
    }
    public DbSet<Category> Categories { get; set; }
    
    public DbSet<Product> Products { get; set; }
   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       //Fluent Api

       #region Creating Tables

       modelBuilder.Entity<Category>().ToTable("Category");
       
       modelBuilder.Entity<Product>().ToTable("Product");

       #endregion

       #region Primary Keys

       modelBuilder.Entity<Category>().HasKey(a => a.Id);
       
       modelBuilder.Entity<Product>().HasKey(a => a.Id);
       
       #endregion

       #region Relationships

       modelBuilder.Entity<Product>()
           .HasOne(a => a.Category)
           .WithMany(a => a.Products)
           .HasForeignKey(a => a.CategoryId)
           .OnDelete(DeleteBehavior.Cascade);


       #endregion


    }
}