using Microsoft.EntityFrameworkCore;
using StoreApp.Data.Abstract;
using StoreApp.Data.Concrete;
using StoreApp.Web.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);

builder.Services.AddDbContext<StoreDbContext>(options => {
    options.UseSqlite(builder.Configuration["ConnectionStrings:StoreDbConnection"], b =>b.MigrationsAssembly("StoreApp.Web"));
});

builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();
builder.Services.AddScoped<IOrderRepository, EfOrderRepository>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<Cart>(sc => SessionCart.GetCart(sc));
builder.Services.AddScoped<Like>(sc => SessionLike.GetLike(sc));


var app = builder.Build();

app.UseStaticFiles();
app.UseSession();







// products/gitar-pc => kategori urun listesi
app.MapControllerRoute("products_in_category", "products/{category?}", new { controller = "Home", action = "Index" });

// gitar-pc => urun detay
app.MapControllerRoute("product_details", "{name}", new { controller = "Home", action = "Details" });

app.MapDefaultControllerRoute();
app.MapRazorPages();

app.Run();
