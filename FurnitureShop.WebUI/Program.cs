using FurnitureShop.Core;
using FurnitureShop.WebUI.MappingProfile;
using FurnitureShop.Infrastructure.Data;
using System.Reflection;
using System.Globalization;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddStorage(builder.Configuration);
builder.Services.AddCore();
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
});

builder.Services.AddLocalization(
    options => options.ResourcesPath = "Resources"
    );


builder.Services.AddControllersWithViews()
    .AddDataAnnotationsLocalization()
    .AddViewLocalization();
const string defaultCulture = "ua";
var supportedCultures = new[]
{
    new CultureInfo(defaultCulture),
    new CultureInfo("en"),
    new CultureInfo("de")
};
builder.Services.Configure<RequestLocalizationOptions>(op =>
{
    op.SetDefaultCulture(defaultCulture);
    op.SupportedCultures=supportedCultures;
    op.SupportedUICultures=supportedCultures;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetService<ApplicationDbContext>();
    dbContext.Database.EnsureCreated();
}



app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Views}/{action=Index}/{id?}");

app.Run();
