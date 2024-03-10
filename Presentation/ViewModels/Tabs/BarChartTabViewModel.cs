using GalaSoft.MvvmLight;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using PokemonInfographics.Domain.Interactors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using LiveChartsCore.SkiaSharpView.VisualElements;
using LiveChartsCore.Drawing;

namespace PokemonInfographics.Presentation.ViewModels.Tabs
{
    public class BarChartTabViewModel : ViewModelBase
    {
        private readonly PokemonStatisticsInteractor _pokemonStatisticsInteractor;

        public ISeries[] BarChartSeries { get; private set; }

        public LabelVisual Title { get; set; } = new LabelVisual
        {
            Text = "Average stats",
            TextSize = 25,
            Padding = new Padding(15),
            Paint = new SolidColorPaint(SKColors.DarkSlateGray)
        };

        public Axis[] XAxes { get; set; } =
        {
            new Axis
            {
                Labels = new string[] { "HP", "Attack", "Defense", "Sp. Atk", "Sp. Def", "Speed" },
                LabelsRotation = 0,
                SeparatorsPaint = new SolidColorPaint(new SKColor(200, 200, 200)),
                SeparatorsAtCenter = false,
                ForceStepToMin = true,
                MinStep = 1,
            }
        };


        public BarChartTabViewModel(PokemonStatisticsInteractor pokemonStatisticsInteractor)
        {
            _pokemonStatisticsInteractor = pokemonStatisticsInteractor;

            var averageStatistics = _pokemonStatisticsInteractor.GetPokemonAverageStatistic();
            var barSeries = new ISeries[]
            {
                new ColumnSeries<double>
                {
                    Values = new double[]
                    {
                        averageStatistics.AverageHP,
                        averageStatistics.AverageAttack,
                        averageStatistics.AverageDefense,
                        averageStatistics.AverageSpecialAttack,
                        averageStatistics.AverageSpecialDefense,
                        averageStatistics.AverageSpeed
                    }
                }
            };

            BarChartSeries = barSeries;
        }
    }
}
