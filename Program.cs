using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();                 // For API Controllers
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();// Razor Views
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//// Dependency Injection (Repositories, Services, UseCases)
//builder.Services.AddScoped<IProductRepository, ProductRepository>();
//builder.Services.AddScoped<IProductService, ProductService>();
//builder.Services.AddScoped<CreateProductUseCase>();
//builder.Services.AddScoped<GetAllProductsUseCase>();

// Repeat for other domain models: Orders, Cart, Customers, Categories

var app = builder.Build();

// Configure middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles(); // serve /wwwroot
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.MapControllers();  // Map API endpoints

app.Run();
