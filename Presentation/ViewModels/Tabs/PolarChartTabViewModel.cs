using GalaSoft.MvvmLight;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.VisualElements;
using PokemonInfographics.Domain.Interactors;
using SkiaSharp;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using LiveChartsCore.Defaults;

namespace PokemonInfographics.Presentation.ViewModels
{
    public class PolarChartTabViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly PokemonStatisticsInteractor _pokemonStatisticsInteractor;
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<ObservableValue> _polarChartValues;

        public ISeries[] PolarChartSeries { get; private set; }


        public PolarAxis[] AngleAxes { get; set; } =
        {
            new PolarAxis
            {
                LabelsRotation = LiveCharts.TangentAngle,
                Labels = new[] { "HP", "Attack", "Defense", "Speed" }
            }
        };

        public PolarAxis[] RadialAxes { get; set; } =
        {
            new PolarAxis
            {
                MaxLimit = 150
            }
        };

        public LabelVisual Title { get; set; } =
        new LabelVisual
        {
            Text = "Polar Chart",
            TextSize = 25,
            Padding = new LiveChartsCore.Drawing.Padding(15),
            Paint = new SolidColorPaint(SKColors.DarkSlateGray)
        };

        private ObservableCollection<string> _pokemonNamesList;
        public ObservableCollection<string> PokemonNamesList
        {
            get => _pokemonNamesList;
            set
            {
                _pokemonNamesList = value;
                RaisePropertyChanged(nameof(PokemonNamesList));
            }
        }

        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                RaisePropertyChanged(nameof(SearchText));
                Search();
            }
        }

        private string _nameOfSelectedPokemon;
        public string NameOfSelectedPokemon
        {
            get => _nameOfSelectedPokemon;
            set
            {
                _nameOfSelectedPokemon = value;
                RaisePropertyChanged(nameof(NameOfSelectedPokemon));

                Title.Text = _nameOfSelectedPokemon;
                RaisePropertyChanged(nameof(Title));
                DrawPolarChart();
            }
        }


        private IEnumerable<string> _allPokemonNames;

        public PolarChartTabViewModel(PokemonStatisticsInteractor pokemonStatisticsInteractor)
        {
            _pokemonStatisticsInteractor = pokemonStatisticsInteractor;
            _allPokemonNames = _pokemonStatisticsInteractor.GetPokemonNames();
            PokemonNamesList = new ObservableCollection<string>(_allPokemonNames);

            _polarChartValues = new ObservableCollection<ObservableValue>();

            PolarChartSeries = new ISeries[]
            {
                new PolarLineSeries<ObservableValue>
                {
                    Values = _polarChartValues,
                    LineSmoothness = 0,
                    GeometrySize= 0,
                    Fill = new SolidColorPaint(SKColors.Blue.WithAlpha(90))
                }
            };
        }

        private void DrawPolarChart()
        {
            if (string.IsNullOrEmpty(NameOfSelectedPokemon))
            {
                return;
            }
            var pokemon = _pokemonStatisticsInteractor.GetPokemonByName(NameOfSelectedPokemon);
            _polarChartValues.Clear();
            _polarChartValues.Add(new ObservableValue(pokemon.HP));
            _polarChartValues.Add(new ObservableValue(pokemon.Attack));
            _polarChartValues.Add(new ObservableValue(pokemon.Defense));
            _polarChartValues.Add(new ObservableValue(pokemon.Speed));
            RaisePropertyChanged(nameof(PolarChartSeries));
        }

        private void Search()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(SearchText))
                {
                    PokemonNamesList = new ObservableCollection<string>(_allPokemonNames);
                }
                else
                {
                    string searchTerm = SearchText.ToLower();
                    var filteredNames = _allPokemonNames.Where(name => name.ToLower().Contains(searchTerm)).ToList();
                    PokemonNamesList = new ObservableCollection<string>(filteredNames);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error while searching");
            }
        }

        protected virtual void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
