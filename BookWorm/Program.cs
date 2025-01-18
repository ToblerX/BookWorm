using BookWorm.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Add Identity services with email-related functionality disabled
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false; // Disable email confirmation
    options.SignIn.RequireConfirmedEmail = false;  // Allows login without confirmed email
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

// Register No-Op EmailSender to bypass email functionality
builder.Services.AddSingleton<IEmailSender, NoOpEmailSender>();

// Add Razor Pages
builder.Services.AddRazorPages();

builder.Services.AddControllersWithViews();

// Configure default culture to "en-US" to use period as decimal separator
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var cultureInfo = new CultureInfo("en-US");
    options.DefaultRequestCulture = new RequestCulture(cultureInfo);
    options.SupportedCultures = new[] { cultureInfo };
    options.SupportedUICultures = new[] { cultureInfo };
});

var app = builder.Build();

// Ensure roles are created
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

    // Ensure "Admin" role exists
    var roleExist = await roleManager.RoleExistsAsync("Admin");
    if (!roleExist)
    {
        var role = new IdentityRole("Admin");
        await roleManager.CreateAsync(role);
    }

    // Optionally, create an admin user
    var user = await userManager.FindByEmailAsync("admin@example.com");
    if (user == null)
    {
        user = new IdentityUser { UserName = "admin@example.com", Email = "admin@example.com" };
        await userManager.CreateAsync(user, "AdminPassword123!");
    }

    if (!await userManager.IsInRoleAsync(user, "Admin"))
    {
        await userManager.AddToRoleAsync(user, "Admin");
    }
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Add MapRazorPages here
app.MapRazorPages();

app.Run();
