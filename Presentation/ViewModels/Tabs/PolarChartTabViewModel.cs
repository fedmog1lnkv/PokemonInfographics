using GalaSoft.MvvmLight;
using PokemonInfographics.Domain.Interactors;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using System.Collections.Generic;
using LiveChartsCore.SkiaSharpView;

namespace PokemonInfographics.Presentation.ViewModels
{
    public class PolarChartTabViewModel : ViewModelBase
    {
        private readonly PokemonStatisticsInteractor _pokemonStatisticsInteractor;

        public List<ISeries> PolarChartSeries { get; private set; }

        public PolarChartTabViewModel(PokemonStatisticsInteractor pokemonStatisticsInteractor)
        {
            _pokemonStatisticsInteractor = pokemonStatisticsInteractor;
            PolarChartSeries = new List<ISeries>
            {
                new PolarLineSeries<double>
                {
                    Values = new double[] { 10, 3, 7, 4, 5 },
                    Fill = null,
                    IsClosed = false
                }
            };
        }
    }
}