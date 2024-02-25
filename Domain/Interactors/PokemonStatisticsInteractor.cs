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
