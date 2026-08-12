using ShippingCalculator.BusinessLogic.Dependency;
using ShippingCalculator.Data.Dependency;

var builder = WebApplication.CreateBuilder(args);

// Registramos los módulos de cada capa por separado
builder.Services.AddData(builder.Configuration);
builder.Services.AddBusinessLogic();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Tariff}/{action=Index}/{id?}");

app.Run();