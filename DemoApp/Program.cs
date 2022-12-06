using DemoApp.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;

var logger = NLog.LogManager.Setup ().LoadConfigurationFromAppSettings ().GetCurrentClassLogger ();

try {
    var builder = WebApplication.CreateBuilder ( args );
    string demoAppConnection = builder.Configuration.GetConnectionString ( "DefaultConnection" );
    builder.Services.AddDbContextPool<ApplicationContext> ( options => options.UseSqlServer ( demoAppConnection ) );
    builder.Services.AddIdentity<IdentityUser, IdentityRole> ( options => {
        options.Password.RequiredLength = 12;
    } ).AddEntityFrameworkStores<ApplicationContext> ();
    builder.Services.AddAuthorization ();
    builder.Services.AddAuthentication ( CookieAuthenticationDefaults.AuthenticationScheme )
        .AddCookie ( options => {
            options.ExpireTimeSpan = TimeSpan.FromMinutes ( 20 );
            options.SlidingExpiration = true;
            options.LoginPath = "/LoginMain/Login";
        } );
    builder.Logging.ClearProviders ();
    builder.Host.UseNLog ();
    builder.Services.AddControllersWithViews ();
    var app = builder.Build ();
    app.UseStaticFiles();
    app.MapControllers ();
    if(app.Environment.IsDevelopment ()) {
        app.UseDeveloperExceptionPage ();
    }
    else {
        app.UseExceptionHandler ( "/Error" );
        //app.UseHsts ();
    }
    app.UseStatusCodePagesWithReExecute ( "/Error/{0}" );

    app.UseAuthentication ();
    app.Run ();
}
catch(Exception ex) {
    logger.Error ( ex, "Stopped program because of exception" );
    throw ( ex );
}
finally {
    LogManager.Shutdown ();
}