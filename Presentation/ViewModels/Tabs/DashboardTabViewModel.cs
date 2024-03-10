using GalaSoft.MvvmLight;
using PokemonInfographics.Domain.Interactors;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using System.Collections.Generic;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.VisualElements;
using PokemonInfographics.Presentation.ViewModels.Tabs;

namespace PokemonInfographics.Presentation.ViewModels
{
    public class DashboardTabViewModel : ViewModelBase
    {
        public PieChartTabViewModel PieChartViewModel { get; }
        public BarChartTabViewModel BarChartViewModel { get; }
        public ScatterChartTabViewModel ScatterChartViewModel { get; }

        public List<ISeries<double>> PieChartSeries { get; private set; }
        public LabelVisual PieChartTitle { get; private set; }


        public ISeries[] BarChartSeries { get; private set; }
        public LabelVisual BarChartTitle { get; private set; }
        public Axis[] BarChartXAxes { get; set; }

        public List<ISeries> ScatterChartSeries { get; private set; }
        public LabelVisual ScatterChartTitle { get; private set; }
        public Axis[] ScatterChartXAxes { get; set; }
        public Axis[] ScatterChartYAxes { get; set; }


        public DashboardTabViewModel(PieChartTabViewModel pieChartViewModel, BarChartTabViewModel barChartViewModel, ScatterChartTabViewModel scatterChartViewModel)
        {
            PieChartViewModel = pieChartViewModel;
            BarChartViewModel = barChartViewModel;
            ScatterChartViewModel = scatterChartViewModel;

            PieChartSeries = PieChartViewModel.PieChartSeries;
            PieChartTitle = PieChartViewModel.Title;

            BarChartSeries = BarChartViewModel.BarChartSeries;
            BarChartTitle = BarChartViewModel.Title;
            BarChartXAxes = BarChartViewModel.XAxes;

            ScatterChartSeries = ScatterChartViewModel.ScatterChartSeries;
            ScatterChartTitle = ScatterChartViewModel.Title;
            ScatterChartXAxes = ScatterChartViewModel.XAxes;
            ScatterChartYAxes = ScatterChartViewModel.YAxes;
        }
    }
}
