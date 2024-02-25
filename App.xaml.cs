using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PokemonInfographics.Domain.Interactors;
using PokemonInfographics.Domain.Repositories;
using PokemonInfographics.Infrastructure;
using PokemonInfographics.Presentation.ViewModels;
using System;
using System.Windows;

namespace PokemonInfographics
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost host;
        public static IServiceProvider ServiceProvider { get; private set; }

        public App()
        {
            host = Host.CreateDefaultBuilder().ConfigureServices((context, services) =>
                    {
                        ConfigureServices(services);
                    })
                    .Build();

            ServiceProvider = host.Services;
            Console.WriteLine("Service provider created");
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            await host.StartAsync();
            var window = ServiceProvider.GetRequiredService<MainWindow>();
            window.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // Регистрация репозитория и других зависимостей
            services.AddSingleton<IPokemonRepository>(_ => CsvPokemonRepository.Instance);
            services.AddScoped<MainWindow>();

            // Регистрация ViewModel и интерактора с указанием их зависимостей
            services.AddScoped<MainWindowViewModel>();
            services.AddTransient<PokemonStatisticsInteractor>();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using (host)
            {
                await host.StopAsync(TimeSpan.FromSeconds(5));
            }

            base.OnExit(e);
        }
    }
}