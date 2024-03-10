using Microsoft.Extensions.DependencyInjection;
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

        public PieChartTabViewModel PieChartTabViewModel
            => App.ServiceProvider.GetRequiredService<PieChartTabViewModel>();

        public ScatterChartTabViewModel ScatterChartTabViewModel
            => App.ServiceProvider.GetRequiredService<ScatterChartTabViewModel>();

        public PolarChartTabViewModel PolarChartTabViewModel
            => App.ServiceProvider.GetRequiredService<PolarChartTabViewModel>();
    }
}
