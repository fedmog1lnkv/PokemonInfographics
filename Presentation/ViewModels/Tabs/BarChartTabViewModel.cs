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
            Padding = new LiveChartsCore.Drawing.Padding(15),
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
                TicksPaint = new SolidColorPaint(new SKColor(35, 35, 35)),
                TicksAtCenter = true,
                ForceStepToMin = true,
                MinStep = 1
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
            /*
            var barSeries = new ISeries[]
            {
                new ColumnSeries<double>
                {
                    Name = "Average HP",
                    Values = new double[] { averageStatistics.AverageHP }
                },
                new ColumnSeries<double>
                {
                    Name = "Average Attack",
                    Values = new double[] { averageStatistics.AverageAttack }
                },
                new ColumnSeries<double>
                {
                    Name = "Average Defense",
                    Values = new double[] { averageStatistics.AverageDefense }
                },
                new ColumnSeries<double>
                {
                    Name = "Average Special Attack",
                    Values = new double[] { averageStatistics.AverageSpecialAttack }
                },
                new ColumnSeries<double>
                {
                    Name = "Average Special Defense",
                    Values = new double[] { averageStatistics.AverageSpecialDefense }
                },
                new ColumnSeries<double>
                {
                    Name = "Average Speed",
                    Values = new double[] { averageStatistics.AverageSpeed }
                }
            };
            */

        BarChartSeries = barSeries;
        }
    }
}
