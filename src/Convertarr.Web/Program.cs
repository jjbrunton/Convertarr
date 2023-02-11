using Convertarr.Core;
using Convertarr.Data;
using Convertarr.Web.Data;
using Hangfire;
using Hangfire.Dashboard;
using Microsoft.EntityFrameworkCore;

namespace Convertarr.Web;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();
        builder.Services.AddSingleton<WeatherForecastService>();
        builder.Services.AddTransient<ConvertarrContext>();
        builder.Services.AddTransient<FileScannerService>();
        builder.Services.AddTransient<MediaInfoService>();
        builder.Services.AddHangfire(c => c.UseInMemoryStorage());
        builder.Services.AddHangfireServer();

        GlobalConfiguration.Configuration.UseInMemoryStorage();


        var app = builder.Build();
        var context = app.Services.GetService<ConvertarrContext>();
        context.Database.Migrate();

        app.UseHangfireDashboard("/hangfire",
            new DashboardOptions
            {
                AppPath = null,
                Authorization = Array.Empty<IDashboardAuthorizationFilter>(),
            });



        //app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseRouting();

        app.MapBlazorHub();
        app.MapFallbackToPage("/_Host");



        var fileScanner = app.Services.GetService<FileScannerService>();
        var mediaService = app.Services.GetService<MediaInfoService>();
        RecurringJob.AddOrUpdate("fileScan", () => fileScanner.Scan(), Cron.Minutely);
        RecurringJob.AddOrUpdate("mediaAnalysis", () => mediaService.UpdateMediaAnalysis(), Cron.Hourly);
        app.Run();
    }

    [DisableConcurrentExecution(timeoutInSeconds: 600)]
    public static void SomeJob()
    {
        Console.WriteLine("Test");
    }
}