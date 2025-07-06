using Scalar.AspNetCore;
using WebApi.Infrastructure.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


// Servis bağımlılıklarını yapılandırma
builder.Services.ConfigureCustomServices();

// Controller ve OpenAPI tanımlamaları
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Veritabanı yapılandırması
builder.Services.ConfigureDbContext(builder.Configuration);

// Routing ayarları (lower-case vs.)
builder.Services.ConfigureRouting();

WebApplication app = builder.Build();

// Geliştirme ortamı için Swagger/OpenAPI görünürlüğü
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Scalar UI Ayarları - RentaCar API Dokümantasyonu
app.MapScalarApiReference(opt =>
{
    opt.Title = "RentaCar | Araç Kiralama RESTful API";
    opt.HeadContent = @"
        <script>
            document.addEventListener('DOMContentLoaded', function () {
                setTimeout(() => {
                    const logo = document.querySelector('#RentaCarLogo');
                    const badges = document.querySelector('.badges');

                    if (logo && badges) {
                        badges.after(logo);
                        logo.style.opacity = '1';
                    }
                }, 100);
            });
        </script>
    ";
    opt.CustomCss = @"
        #RentaCarLogo { position: relative; z-index: 99; margin: 15px 0; opacity: 0; }
        .section-content > .download, .section-content > .badges { display: none; }
    ";
    opt.Theme = ScalarTheme.BluePlanet;
    opt.ForceThemeMode = ThemeMode.Dark;
    opt.HideDarkModeToggle = true;
    opt.Favicon = "https://images.unsplash.com/photo-1494905998402-395d579af36f?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=32&q=80";
    opt.DefaultHttpClient = new(ScalarTarget.CSharp, ScalarClient.HttpClient);
    opt.Layout = ScalarLayout.Classic;
});

// HTTPS ve Yetkilendirme ayarları
app.UseHttpsRedirection();
app.UseAuthorization();

// DB Migration kontrol ve uygulama
app.ConfigureAndCheckMigration();

// Controller route mapping
app.MapControllers();

// Uygulama çalıştırma
app.Run();
