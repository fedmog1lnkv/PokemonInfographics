using GalaSoft.MvvmLight;
using PokemonInfographics.Domain.Interactors;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using System.Collections.Generic;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using System.Collections.ObjectModel;
using LiveChartsCore.SkiaSharpView.Painting.Effects;
using System.Windows.Controls;
using LiveChartsCore.Kernel;

namespace PokemonInfographics.Presentation.ViewModels
{
    public class ScatterChartTabViewModel : ViewModelBase
    {
        private readonly PokemonStatisticsInteractor _pokemonStatisticsInteractor;

        private static byte _opacity = 120;

        private SKColor[] colors = new SKColor[]
        {
            new SKColor(0, 0, 255, _opacity),   // Синий
            new SKColor(0, 255, 0, _opacity),   // Зеленый
            new SKColor(255, 128, 0, _opacity), // Оранжевый
            new SKColor(255, 0, 0, _opacity),   // Красный
            new SKColor(127, 0, 255, _opacity), // Фиолетовый
            new SKColor(255, 255, 0, _opacity)  // Желтый
        };

        public List<ISeries> ScatterChartSeries { get; private set; }

        public Axis[] XAxes { get; set; } = new Axis[]
        {
            new Axis
            {
                Name = "Attack",
            }
        };

        public Axis[] YAxes { get; set; } = new Axis[]
        {
            new Axis
            {
                Name = "Speed",
            }
        };


        public ScatterChartTabViewModel(PokemonStatisticsInteractor pokemonStatisticsInteractor)
        {
            _pokemonStatisticsInteractor = pokemonStatisticsInteractor;

            var scatterData = _pokemonStatisticsInteractor.GetScatterData();
            var pokemonsByGenerations = new Dictionary<double, ObservableCollection<ObservablePoint>>();


            foreach (var po in scatterData)
            {
                var point = new ObservablePoint(po.Attack, po.Speed);
                if (pokemonsByGenerations.ContainsKey(po.Generation))
                {
                    pokemonsByGenerations[po.Generation].Add(point);
                }
                else
                {
                    pokemonsByGenerations[po.Generation] = new ObservableCollection<ObservablePoint>() { point };
                }
            }

            ScatterChartSeries = Enumerable.Range(1, 6).Select(i =>
                new ScatterSeries<ObservablePoint>
                {
                    Values = pokemonsByGenerations[i],
                    GeometrySize = i * 5,
                    Name = $"{i} Generation",
                    Fill = new SolidColorPaint(colors[i - 1]),
                    XToolTipLabelFormatter = (pointX) => $"Attack: {pointX.PrimaryValue}",
                    YToolTipLabelFormatter = (pointY) => $"Speed: {pointY.SecondaryValue}"
                } as ISeries
            ).Cast<ISeries>().ToList();
        }
    }
}