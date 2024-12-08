using Microsoft.EntityFrameworkCore;

namespace StoreApp.Data.Concrete;

public class StoreDbContext:DbContext
{
    public StoreDbContext(DbContextOptions<StoreDbContext> options): base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>()
            .HasMany(e => e.Categories)
            .WithMany(e => e.Products)
            .UsingEntity<ProductCategory>();

        modelBuilder.Entity<Category>()
            .HasIndex(u => u.Url)
            .IsUnique();

        modelBuilder.Entity<Product>().HasData(
            new List<Product>() {
                new() { Id=1, Name="Ibanez-1", Price=15000, Description="nota"},
                new() { Id=2, Name="Ibanez-2", Price=20000, Description="nota"},
                new() { Id=3, Name="Ibanez-3", Price=30000, Description="nota"},
                new() { Id=4, Name="Ibanez-4", Price=40000, Description="nota"},
                new() { Id=5, Name="Ibanez-5", Price=50000, Description="nota"},
                new() { Id=6, Name="Ibanez-6", Price=60000, Description="nota"},
                new() { Id=7, Name="Ibanez-11", Price=11000, Description="nota"},
                new() { Id=8, Name="Ibanez-21", Price=21000, Description="nota"},
                new() { Id=9, Name="Ibanez-31", Price=31000, Description="nota"},
                new() { Id=10, Name="Ibanez-41", Price=41000, Description="nota"},
                new() { Id=11, Name="Ibanez-51", Price=51000, Description="nota"},
                new() { Id=12, Name="Ibanez-61", Price=61000, Description="nota"},
                new() { Id=13, Name="Mouse-1", Price=2000, Description="mouse"},
                new() { Id=14, Name="Gpu-2", Price=7000, Description="gpu"},
                new() { Id=15, Name="Cpu-3", Price=8000, Description="cpu"},
                new() { Id=16, Name="Cpu-4", Price=9000, Description="cpu"},
                new() { Id=17, Name="Power-5", Price=4000, Description="power"},
                new() { Id=18, Name="Power-6", Price=5000, Description="power"},
                new() { Id=19, Name="Ram-11", Price=4000, Description="ram"},
                new() { Id=20, Name="Ram-21", Price=5000, Description="ram"},
                new() { Id=21, Name="Anakart-31", Price=11000, Description="anakart"},
                new() { Id=22, Name="Anakart-41", Price=21000, Description="anakart"},
                new() { Id=23, Name="Fan-51", Price=1200, Description="fan"},
                new() { Id=24, Name="Ssd-61", Price=1000, Description="ssd"},
                new() { Id=25, Name="Bilgisayar-1", Price=105000, Description="bilgisayar"},
                new() { Id=26, Name="Bilgisayar-2", Price=200000, Description="bilgisayar"},
                new() { Id=27, Name="Kasa-3", Price=60000, Description="kasa"},
                new() { Id=28, Name="Kasa-4", Price=80000, Description="kasa"},
                new() { Id=29, Name="Klavye-5", Price=4000, Description="klavye"},
                new() { Id=30, Name="Klavye-6", Price=8000, Description="klavye"},
                new() { Id=31, Name="Mouse-11", Price=11000, Description="mouse"},
                new() { Id=32, Name="Ssd-21", Price=7500, Description="ssd"},
                new() { Id=33, Name="Kasa-31", Price=50000, Description="kasa"},
                new() { Id=34, Name="Kasa-41", Price=45000, Description="kasa"},
                new() { Id=35, Name="Kulaklık-51", Price=8000, Description="kulaklık"},
                new() { Id=36, Name="Kulaklık-61", Price=6000, Description="kulaklık"},
                new() { Id=37, Name="Kulaklık-62", Price=2000, Description="kulaklık"},
                new() { Id=38, Name="Fan-2", Price=7000, Description="fan"},
                new() { Id=39, Name="Fan-3", Price=8000, Description="fan"},
                new() { Id=40, Name="Cpu-4", Price=9000, Description="cpu"}
            }
        );

        modelBuilder.Entity<Category>().HasData(
            new List<Category>() {
                new () { Id = 1,  Name = "Elektrogitar", Url = "elektrogitar"},
                new () { Id = 2,  Name = "Kulaklık", Url = "kulaklık"},
                new () { Id = 3,  Name = "Bilgisayar", Url = "bilgisayar"}, 
                new () { Id = 4,  Name = "Kasa", Url = "kasa"},
                new () { Id = 5,  Name = "Klavye", Url = "klavye"},
                new () { Id = 6,  Name = "Mouse", Url = "mouse"},
                new () { Id = 7,  Name = "Anakart", Url = "anakart"},
                new () { Id = 8,  Name = "Ram", Url = "ram"},
                new () { Id = 9,  Name = "Power", Url = "power"},
                new () { Id = 10,  Name = "Gpu", Url = "gpu"},
                new () { Id = 11,  Name = "Cpu", Url = "cpu"},
                new () { Id = 12,  Name = "Fan", Url = "fan"},
                new () { Id = 13,  Name = "Ssd", Url = "ssd"}
            }
        );

        modelBuilder.Entity<ProductCategory>().HasData(
            new List<ProductCategory>() {
                new ProductCategory() { ProductId=1, CategoryId=1},
                new ProductCategory() { ProductId=2, CategoryId=1},
                new ProductCategory() { ProductId=3, CategoryId=1},
                new ProductCategory() { ProductId=4, CategoryId=1},
                new ProductCategory() { ProductId=5, CategoryId=1},
                new ProductCategory() { ProductId=6, CategoryId=1},
                new ProductCategory() { ProductId=7, CategoryId=1},
                new ProductCategory() { ProductId=8, CategoryId=1},
                new ProductCategory() { ProductId=9, CategoryId=1},
                new ProductCategory() { ProductId=10, CategoryId=1},
                new ProductCategory() { ProductId=11, CategoryId=1},
                new ProductCategory() { ProductId=12, CategoryId=1},
                new ProductCategory() { ProductId=13, CategoryId=6},
                new ProductCategory() { ProductId=14, CategoryId=10},
                new ProductCategory() { ProductId=15, CategoryId=11},
                new ProductCategory() { ProductId=16, CategoryId=11},
                new ProductCategory() { ProductId=17, CategoryId=9},
                new ProductCategory() { ProductId=18, CategoryId=9},
                new ProductCategory() { ProductId=19, CategoryId=8},
                new ProductCategory() { ProductId=20, CategoryId=8},
                new ProductCategory() { ProductId=21, CategoryId=7},
                new ProductCategory() { ProductId=22, CategoryId=7},
                new ProductCategory() { ProductId=23, CategoryId=12},
                new ProductCategory() { ProductId=24, CategoryId=13},
                new ProductCategory() { ProductId=25, CategoryId=3},
                new ProductCategory() { ProductId=26, CategoryId=3},
                new ProductCategory() { ProductId=27, CategoryId=4},
                new ProductCategory() { ProductId=28, CategoryId=4},
                new ProductCategory() { ProductId=29, CategoryId=5},
                new ProductCategory() { ProductId=30, CategoryId=5},
                new ProductCategory() { ProductId=31, CategoryId=6},
                new ProductCategory() { ProductId=32, CategoryId=13},
                new ProductCategory() { ProductId=33, CategoryId=4},
                new ProductCategory() { ProductId=34, CategoryId=4},
                new ProductCategory() { ProductId=35, CategoryId=2},
                new ProductCategory() { ProductId=36, CategoryId=2},
                new ProductCategory() { ProductId=37, CategoryId=2},
                new ProductCategory() { ProductId=38, CategoryId=12},
                new ProductCategory() { ProductId=39, CategoryId=12},
                new ProductCategory() { ProductId=40, CategoryId=11},
            }
        );

    }
}