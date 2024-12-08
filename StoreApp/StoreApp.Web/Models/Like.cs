using StoreApp.Data.Concrete;

namespace StoreApp.Web.Models;

public class Like
{
    public List<LikeItem> Items { get; set; } = new List<LikeItem>();

    public virtual void AddItem(Product product, int quantity)
    {
        var item = Items.Where(p => p.Product.Id == product.Id).FirstOrDefault();

        if (item == null)
        {
            Items.Add(new LikeItem { Product = product, Quantity = quantity });
        }
        else
        {
            item.Quantity += quantity;
        }
    }

    public virtual void RemoveItem(Product product)
    {
        Items.RemoveAll(i => i.Product.Id == product.Id);
    }

    public decimal CalculateTotal()
    {
        return Items.Sum(i => i.Product.Price * i.Quantity);
    }

    public virtual void Clear()
    {
        Items.Clear();    
    }
}

public class LikeItem
{
    public int LikeItemId { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; } = new();
    public int Quantity { get; set; }
}
