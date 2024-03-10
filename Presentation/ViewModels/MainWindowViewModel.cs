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


        public List<ISeries<double>> PieChartSeries { get; set; }
        public List<ISeries> ScatterChartSeries { get; set; }
        public List<ISeries> PolarChartSeries { get; set; }

        public PolarAxis[] AngleAxes { get; set; } = new PolarAxis[]
        {
            new PolarAxis
            {
                Labels = new[] { "HP", "Attack", "Defense", "Speed", "Generation"},
                MinStep = 1,
                ForceStepToMin = true
            }
        };


        private byte _opacity = 120;


        public MainWindowViewModel(PokemonStatisticsInteractor pokemonStatisticsInteractor)
        {
            _pokemonStatisticsInteractor = pokemonStatisticsInteractor;

            Console.WriteLine("ViewModel created");
            GeneratePieChart();
            GenerateScatterChart();

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

        private void GenerateScatterChart()
        {
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

            // Определение массива цветов с прозрачностью
            SKColor[] colors = new SKColor[]
            {
                new SKColor(0, 0, 255, _opacity),   // Синий
                new SKColor(0, 255, 0, _opacity),   // Зеленый
                new SKColor(255, 128, 0, _opacity), // Оранжевый
                new SKColor(255, 0, 0, _opacity),   // Красный
                new SKColor(127, 0, 255, _opacity), // Фиолетовый
                new SKColor(255, 255, 0, _opacity)  // Желтый
            };


            ScatterChartSeries = Enumerable.Range(1, 6).Select(i =>
                new ScatterSeries<ObservablePoint>
                {
                    Values = pokemonsByGenerations[i],
                    GeometrySize = i * 5,
                    Name = $"{i} Generation",
                    Fill = new SolidColorPaint(colors[i - 1])
                } as ISeries
            ).Cast<ISeries>().ToList();

        }

        private void GeneratePieChart()
        {
            var typeStatistics = _pokemonStatisticsInteractor.GetPokemonTypeStatistics();
            Console.WriteLine(1);

            var pieSeries = new List<ISeries<double>>();
            foreach (var po in typeStatistics)
            {
                pieSeries.Add(new PieSeries<double> { Name = po.Key, Values = new double[] { po.Value } });
            }
            PieChartSeries = pieSeries;
        }
    }
}
