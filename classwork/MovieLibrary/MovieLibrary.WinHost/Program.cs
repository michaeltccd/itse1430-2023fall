using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MovieLibrary.WinHost;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        var host = Host.CreateDefaultBuilder().Build();
        s_configuration = host.Services.GetRequiredService<IConfiguration>();

        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }

    public static string GetConnectionString ( string name ) => s_configuration.GetConnectionString(name);

    private static IConfiguration s_configuration;
}