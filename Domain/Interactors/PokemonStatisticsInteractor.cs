using PokemonInfographics.Domain.Models;
using PokemonInfographics.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace PokemonInfographics.Domain.Interactors
{
    public class PokemonStatisticsInteractor
    {
        private readonly IPokemonRepository _pokemonRepository;

        public PokemonStatisticsInteractor(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        public IDictionary<string, int> GetPokemonTypeStatistics()
        {
            var allPokemons = _pokemonRepository.GetAllPokemons();

            var typeStatistics = new Dictionary<string, int>();

            foreach (var pokemon in allPokemons)
            {
                IncreaseTypeCount(typeStatistics, pokemon.Type1);
                IncreaseTypeCount(typeStatistics, pokemon.Type2);
            }

            return typeStatistics;
        }

        public AverageStatistic GetPokemonAverageStatistic()
        {
            var allPokemons = _pokemonRepository.GetAllPokemons();

            int totalPokemons = allPokemons.Count();
            double totalHP = allPokemons.Sum(pokemon => pokemon.HP);
            double totalAttack = allPokemons.Sum(pokemon => pokemon.Attack);
            double totalDefense = allPokemons.Sum(pokemon => pokemon.Defense);
            double totalSpAtk = allPokemons.Sum(pokemon => pokemon.SpecialAttack);
            double totalSpDef = allPokemons.Sum(pokemon => pokemon.SpecialDefense);
            double totalSpeed = allPokemons.Sum(pokemon => pokemon.Speed);

            return new AverageStatistic
            {
                AverageHP = totalHP / totalPokemons,
                AverageAttack = totalAttack / totalPokemons,
                AverageDefense = totalDefense / totalPokemons,
                AverageSpecialAttack = totalSpAtk / totalPokemons,
                AverageSpecialDefense = totalSpDef / totalPokemons,
                AverageSpeed = totalSpeed / totalPokemons
            };

        }

        public List<ScatterDataPoint> GetScatterData()
        {
            var scatterData = new List<ScatterDataPoint>();

            var allPokemons = _pokemonRepository.GetAllPokemons();

            foreach (var pokemon in allPokemons)
            {
                var point = new ScatterDataPoint
                {
                    Attack = pokemon.Attack,
                    Speed = pokemon.Speed,
                    Generation = pokemon.Generation
                };

                scatterData.Add(point);
            }

            return scatterData;

        }

        public List<String> GetPokemonNames()
        {
            var allPokemons = _pokemonRepository.GetAllPokemons();
            return new List<string>(allPokemons.Select(x => x.Name));
        }

        public PokemonModel GetPokemonByName(string name)
        {
            var allPokemons = _pokemonRepository.GetAllPokemons();
            return allPokemons.FirstOrDefault(x => x.Name == name);
        }

        private void IncreaseTypeCount(IDictionary<string, int> typeStatistics, string type)
        {
            if (string.IsNullOrEmpty(type)) return;
            if (typeStatistics.ContainsKey(type))
            {
                typeStatistics[type]++;
            }
            else
            {
                typeStatistics[type] = 1;
            }
        }
    }
}
