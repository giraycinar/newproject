##
 **1- Libman Kurulumu**

- dotnet tool list -g
- dotnet tool uninstall --global Microsoft.Web.LibraryManager.Cli
- dotnet tool install --global Microsoft.Web.LibraryManager.Cli --version 2.1.175

**2- Libman Configuration File**
- cd storeApp.Web
- libman init -p cdnjs

**3- Kütüphane Kurulumu**
- libman ile kütüphaneleri kolayca dahil edip yönetebiliriz.
- libman install bootstrap@5.3.2 -d wwwroot/lib/bootstrap

**4- Css Kütaphanesinin Dahil Edilmesi**
-  \<link  href="/lib/bootstrap/css/bootstrap.min.css"  rel="stylesheet"  />

**5- Projenin Başlatılması ve Kullanılması**
- cd storeapp --> cd storeapp.web içine girilip dotnet watch ile proje localhost:5174 te çalışır.
- Veriler Concrete/StoreDbContext.cs içerisinde oluşturulan veriler Migrations ile SQLite Db içerisine kaydedildi.
- Veriler proje indirildikten sonra StoreApp/StoreApp.Web/storeApp dizinindeki storeApp dosyasının SQLite içerisine atılması ile ürünlere, siparişi verek kişi bilgileri, adres e-mail bilgileri vs ulaşılabilir.
