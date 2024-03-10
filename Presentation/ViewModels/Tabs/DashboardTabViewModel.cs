using GalaSoft.MvvmLight;
using PokemonInfographics.Domain.Interactors;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using System.Collections.Generic;
using LiveChartsCore.SkiaSharpView;

namespace PokemonInfographics.Presentation.ViewModels
{
    public class DashboardTabViewModel : ViewModelBase
    {
        public PieChartTabViewModel PieChartViewModel { get; }
        public ScatterChartTabViewModel ScatterChartViewModel { get; }

        public List<ISeries<double>> PieChartSeries { get; private set; }
        public List<ISeries> ScatterChartSeries { get; private set; }


        public DashboardTabViewModel(PieChartTabViewModel pieChartViewModel, ScatterChartTabViewModel scatterChartViewModel)
        {
            PieChartViewModel = pieChartViewModel;
            ScatterChartViewModel = scatterChartViewModel;

            PieChartSeries = PieChartViewModel.PieChartSeries;
            ScatterChartSeries = ScatterChartViewModel.ScatterChartSeries;
        }
    }

}