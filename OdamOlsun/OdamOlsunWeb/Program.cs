using Microsoft.EntityFrameworkCore;
using OdamOlsun.BL.Managers.Abstract;
using OdamOlsun.BL.Managers.Concrete;
using OdamOlsun.Entities.DbContexts.OdamOlsun.Entities.DbContexts;
using Microsoft.AspNetCore.Identity;
using OdamOlsun.Utilities;
using Microsoft.AspNetCore.Identity.UI.Services;
using OdamOlsun.Entities.Models.Concrete;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);




        // Add services to the container.
        builder.Services.AddControllersWithViews();

        builder.Services.AddScoped<IIlanManager, IlanManager>();
        builder.Services.AddScoped<IResimManager, ResimManager>();


        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");



        builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

        //bu kod identityden sonra yazılmalı!!!
        builder.Services.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = $"/Identity/Account/Login";
            options.LogoutPath = $"/Identity/Account/Logout";
            options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
        });

        //Email Confirm gerekli
        //builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<OdamOlsunWebIdentityDbContext>();

        builder.Services.AddRazorPages();
        builder.Services.AddScoped<IEmailSender, EmailSender>();
        builder.Services.AddDbContext<AppDbContext>(option => option.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        var app = builder.Build();

        // Seed işlemi için scope oluşturma
        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;

            try
            {
                var context = services.GetRequiredService<AppDbContext>();
                var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                await DbInitializer.Seed(userManager, roleManager, context);
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "Veritabanı seed işlemi sırasında bir hata oluştu.");
            }
        }


        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapRazorPages();



        app.MapControllerRoute(
            name: "default",
            pattern: "{area=User}/{controller=Home}/{action=Index}/{id?}");
        app.Run();
    }
}
