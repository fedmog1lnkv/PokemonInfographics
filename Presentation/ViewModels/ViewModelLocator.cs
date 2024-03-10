using Microsoft.Extensions.DependencyInjection;
using PokemonInfographics.Presentation.ViewModels.Tabs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonInfographics.Presentation.ViewModels
{
    public class ViewModelLocator
    {
        public MainWindowViewModel MainWindowViewModel
            => App.ServiceProvider.GetRequiredService<MainWindowViewModel>();

        public DashboardTabViewModel DashboardTabViewModel
            => App.ServiceProvider.GetRequiredService<DashboardTabViewModel>();

        public PieChartTabViewModel PieChartTabViewModel
            => App.ServiceProvider.GetRequiredService<PieChartTabViewModel>();

        public BarChartTabViewModel BarChartTabViewModel
            => App.ServiceProvider.GetRequiredService<BarChartTabViewModel>();

        public ScatterChartTabViewModel ScatterChartTabViewModel
            => App.ServiceProvider.GetRequiredService<ScatterChartTabViewModel>();

        public PolarChartTabViewModel PolarChartTabViewModel
            => App.ServiceProvider.GetRequiredService<PolarChartTabViewModel>();
    }
}
