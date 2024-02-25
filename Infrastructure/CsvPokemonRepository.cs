using PokemonInfographics.Domain.Models;
using PokemonInfographics.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.IO;

namespace PokemonInfographics.Infrastructure
{
    public class CsvPokemonRepository : IPokemonRepository
    {
        private readonly string _filePath;
        private readonly IEnumerable<PokemonModel> _pokemonsData;

        private static CsvPokemonRepository? _instance;

        private CsvPokemonRepository(string filePath)
        {
            _filePath = filePath;
            _pokemonsData = LoadPokemons();
        }

        public static CsvPokemonRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CsvPokemonRepository("C:\\Users\\Fedor Kuznetsov\\Desktop\\PokemonInfographics\\raw\\Pokemon.csv");
                }
                return _instance;
            }
        }

        public IEnumerable<PokemonModel> GetAllPokemons()
        {
            return _pokemonsData;
        }

        private IEnumerable<PokemonModel> LoadPokemons()
        {
            List<PokemonModel> pokemons = new List<PokemonModel>();

            using (StreamReader reader = new StreamReader(_filePath))
            {
                // Пропускаем заголовок
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] fields = line.Split(',');

                    pokemons.Add(new PokemonModel
                    {
                        Id = int.Parse(fields[0]),
                        Name = fields[1],
                        Type1 = fields[2],
                        Type2 = fields[3],
                        Total = int.Parse(fields[4]),
                        HP = int.Parse(fields[5]),
                        Attack = int.Parse(fields[6]),
                        Defense = int.Parse(fields[7]),
                        SpecialAttack = int.Parse(fields[8]),
                        SpecialDefense = int.Parse(fields[9]),
                        Speed = int.Parse(fields[10]),
                        Generation = int.Parse(fields[11]),
                        Legendary = bool.Parse(fields[12])
                    });
                }
            }
            Console.WriteLine("Loaded {0} pokemons", pokemons.Count);
            return pokemons;
        }
    }
}
