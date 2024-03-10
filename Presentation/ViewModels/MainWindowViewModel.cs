using GalaSoft.MvvmLight;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.Kernel.Sketches;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Drawing.Geometries;
using LiveChartsCore.SkiaSharpView.Painting;
using PokemonInfographics.Domain.Interactors;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.NetworkInformation;

namespace PokemonInfographics.Presentation.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        PokemonStatisticsInteractor _pokemonStatisticsInteractor;



        public PieChartTabViewModel PieChartTabViewModel { get; }
        public ScatterChartTabViewModel ScatterChartTabViewModel { get; }
        public PolarChartTabViewModel PolarChartTabViewModel { get; }


        public PolarAxis[] AngleAxes { get; set; } = new PolarAxis[]
        {
            new PolarAxis
            {
                Labels = new[] { "HP", "Attack", "Defense", "Speed", "Generation"},
                MinStep = 1,
                ForceStepToMin = true
            }
        };

        public MainWindowViewModel(PokemonStatisticsInteractor pokemonStatisticsInteractor)
        {
            _pokemonStatisticsInteractor = pokemonStatisticsInteractor;

            Console.WriteLine("ViewModel created");

            PieChartTabViewModel = new PieChartTabViewModel(_pokemonStatisticsInteractor);
            ScatterChartTabViewModel = new ScatterChartTabViewModel(_pokemonStatisticsInteractor);
            PolarChartTabViewModel = new PolarChartTabViewModel(_pokemonStatisticsInteractor);
        }
    }
}
