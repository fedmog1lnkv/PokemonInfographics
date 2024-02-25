using GalaSoft.MvvmLight;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using PokemonInfographics.Domain.Interactors;
using System;
using System.Collections.Generic;

namespace PokemonInfographics.Presentation.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        PokemonStatisticsInteractor _pokemonStatisticsInteractor;


        public List<ISeries<double>> Series1 { get; set; }

        public MainWindowViewModel(PokemonStatisticsInteractor pokemonStatisticsInteractor)
        {
            _pokemonStatisticsInteractor = pokemonStatisticsInteractor;


            Console.WriteLine("ViewModel created");
            var typeStatistics = _pokemonStatisticsInteractor.GetPokemonTypeStatistics();
            Console.WriteLine(1);

            var series = new List<ISeries<double>>();
            foreach (var po in typeStatistics)
            {
                series.Add(new PieSeries<double> {Name = po.Key, Values = new double[] { po.Value } });
            }
            Series1 = series;
        }
    }
}
