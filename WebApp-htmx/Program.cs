using WebApp_htmx.DB;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

try
{
    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    app.MapControllerRoute(
        name: "contacts",
        pattern: "/examples",
        defaults: new { controller = "Examples", action = "Index" });

    app.MapControllerRoute(
        name: "contacts",
        pattern: "/examples/get",
        defaults: new { controller = "Examples", action = "Get" });

    app.MapControllerRoute(
        name: "contacts",
        pattern: "/examples/dog",
        defaults: new { controller = "Examples", action = "Dog" });

    app.MapControllerRoute(
        name: "contacts",
        pattern: "/examples/{id}/email",
        defaults: new { controller = "Examples", action = "Email" });

    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;

        try
        {
            var context = services.GetRequiredService<Context>();
            context.SeedData(context);
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occurred while seeding the database.");
        }
    }
    app.Run();

}
catch (Exception e)
{
    var s = e;
}