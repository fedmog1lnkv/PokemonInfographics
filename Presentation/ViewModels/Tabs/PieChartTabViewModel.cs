using GalaSoft.MvvmLight;
using PokemonInfographics.Domain.Interactors;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using System.Collections.Generic;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using LiveChartsCore.SkiaSharpView.VisualElements;

namespace PokemonInfographics.Presentation.ViewModels
{
    public class PieChartTabViewModel : ViewModelBase
    {
        private readonly PokemonStatisticsInteractor _pokemonStatisticsInteractor;

        public List<ISeries<double>> PieChartSeries { get; private set; }

        public LabelVisual Title { get; set; } = new LabelVisual
        {
            Text = "Pokemon types",
            TextSize = 25,
            Padding = new LiveChartsCore.Drawing.Padding(15),
            Paint = new SolidColorPaint(SKColors.DarkSlateGray)
        };

        public PieChartTabViewModel(PokemonStatisticsInteractor pokemonStatisticsInteractor)
        {
            _pokemonStatisticsInteractor = pokemonStatisticsInteractor;
            var typeStatistics = _pokemonStatisticsInteractor.GetPokemonTypeStatistics();
            var pieSeries = new List<ISeries<double>>();
            foreach (var po in typeStatistics)
            {
                pieSeries.Add(new PieSeries<double> { Name = po.Key, Values = new double[] { po.Value } });
            }
            PieChartSeries = pieSeries;
        }
    }
}