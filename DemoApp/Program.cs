using DemoApp.Core.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;

var logger = LogManager.Setup ().LoadConfigurationFromAppSettings ().GetCurrentClassLogger ();

try {
    var builder = WebApplication.CreateBuilder ( args );
    string demoAppConnection = builder.Configuration.GetConnectionString ( "DefaultConnection" );
    builder.Services.AddDbContextPool<ApplicationContext> ( options => options.UseSqlServer ( demoAppConnection ) );
    builder.Services.AddDatabaseDeveloperPageExceptionFilter ();

    builder.Services.AddIdentity<IdentityUser, IdentityRole> ().AddEntityFrameworkStores<ApplicationContext> ();

    builder.Services.Configure<IdentityOptions> ( options => {
        // Password settings.
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequireUppercase = true;
        options.Password.RequiredLength = 6;
        options.Password.RequiredUniqueChars = 1;

        // Lockout settings.
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes ( 5 );
        options.Lockout.MaxFailedAccessAttempts = 5;
        options.Lockout.AllowedForNewUsers = true;

        // User settings.
        options.User.AllowedUserNameCharacters =
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
        options.User.RequireUniqueEmail = false;
    } );

    builder.Logging.ClearProviders ();
    builder.Host.UseNLog ();
    builder.Services.AddControllersWithViews ();

    var app = builder.Build ();
    app.UseStaticFiles ();
    app.MapControllers ()/*.RequireAuthorization()*/;
    if(app.Environment.IsDevelopment ()) {
        app.UseDeveloperExceptionPage ();
    }
    else {
        app.UseExceptionHandler ( "/Error" );
        //app.UseHsts ();
    }
    app.UseStatusCodePagesWithReExecute ( "/Error/{0}" );

    app.UseAuthorization ();
    app.UseAuthentication ();
    app.Run ();
}
catch(Exception ex) {
    logger.Error ( ex, "Stopped program because of exception" );
    throw;
}
finally {
    LogManager.Shutdown ();
}