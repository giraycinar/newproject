using System.Text.Json.Serialization;
using StoreApp.Data.Concrete;
using StoreApp.Web.TagHelpers;

namespace StoreApp.Web.Models;

public class SessionLike:Like
{
    public static Like GetLike(IServiceProvider services)
    {
        ISession? session = services.GetRequiredService<IHttpContextAccessor>().HttpContext?.Session;
        SessionLike like = session?.GetJson<SessionLike>("Like") ?? new SessionLike();
        like.Session = session;
        return like;
    }

    [JsonIgnore]
    public ISession? Session { get; set; }

    public override void AddItem(Product product, int quantity)
    {
        base.AddItem(product, quantity);
        Session?.SetJson("Like", this);
    }

    public override void RemoveItem(Product product)
    {
        base.RemoveItem(product);
        Session?.SetJson("Like", this);
    }

    public override void Clear()
    {
        base.Clear();
        Session?.Remove("Like");
    }

}
