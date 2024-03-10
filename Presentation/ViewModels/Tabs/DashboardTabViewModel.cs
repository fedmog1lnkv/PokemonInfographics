using GalaSoft.MvvmLight;
using PokemonInfographics.Domain.Interactors;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using System.Collections.Generic;
using LiveChartsCore.SkiaSharpView;
using PokemonInfographics.Presentation.ViewModels.Tabs;

namespace PokemonInfographics.Presentation.ViewModels
{
    public class DashboardTabViewModel : ViewModelBase
    {
        public PieChartTabViewModel PieChartViewModel { get; }
        public BarChartTabViewModel BarChartViewModel { get; }
        public ScatterChartTabViewModel ScatterChartViewModel { get; }

        public List<ISeries<double>> PieChartSeries { get; private set; }

        public ISeries[] BarChartSeries { get; private set; }
        public Axis[] BarChartXAxes { get; set; }

        public List<ISeries> ScatterChartSeries { get; private set; }


        public DashboardTabViewModel(PieChartTabViewModel pieChartViewModel, BarChartTabViewModel barChartViewModel, ScatterChartTabViewModel scatterChartViewModel)
        {
            PieChartViewModel = pieChartViewModel;
            BarChartViewModel = barChartViewModel;
            ScatterChartViewModel = scatterChartViewModel;

            PieChartSeries = PieChartViewModel.PieChartSeries;

            BarChartSeries = BarChartViewModel.BarChartSeries;
            BarChartXAxes = BarChartViewModel.XAxes;

            ScatterChartSeries = ScatterChartViewModel.ScatterChartSeries;
        }
    }
}
