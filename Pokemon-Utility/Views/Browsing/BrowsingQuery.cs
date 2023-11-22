using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using Pokemon;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PokemonUtility.Views.Browsing
{
    public class BrowsingQuery
	{
        int nOfPokemonFound;

        public BrowsingQuery()
		{
            nOfPokemonFound = 0;
        }

        public int NOfPokemonFound
        {
            get { return nOfPokemonFound; }
            set { nOfPokemonFound = value; }
        }

        //this is the query when the user input the keyword(name) in the search bar
        public string[,] PokemonQuery_byName(string name, string filter = "all")
        {
            nOfPokemonFound = 0;
            //get the number of pokemons found
            MainContext.Query(
                onReceive: async context =>
                {
                    var pokemon = from t1 in context.PokemonTypes
                                  join t2 in context.Pokemons on t1.PokemonId equals t2.Id
                                  where t2.Name.Contains(name) && t1.Slot == 1 && t1.Name == (filter == "all" ? t1.Name : filter)
                                  select new
                                  {
                                      Id = t2.Id,
                                      Name = t2.Name,
                                      Type = t1.Name
                                  };
                    foreach (var entity in pokemon)
                    {
                        nOfPokemonFound++;
                    }
                },
                onFailure: () => nOfPokemonFound = 0
            );

            string[] pokemonName = new string[nOfPokemonFound];
            string[] pokemonType = new string[nOfPokemonFound];
            int[] pokemonId = new int[nOfPokemonFound];
            //get the name, id, type of the pokemons found
            MainContext.Query(
                onReceive: async context =>
                {
                    var pokemon = from t1 in context.PokemonTypes
                                  join t2 in context.Pokemons on t1.PokemonId equals t2.Id
                                  where t2.Name.Contains(name) && t1.Slot == 1 && t1.Name == (filter == "all" ? t1.Name : filter)
                                  select new
                                {
                                    Id=t2.Id,
                                    Name=t2.Name,
                                    Type=t1.Name
                                };
                    int index = 0;
                    foreach (var entity in pokemon)
                    {
                        pokemonName[index] = entity.Name;
                        pokemonId[index] = entity.Id;
                        pokemonType[index] = entity.Type;
                        index++;
                    }
                },
                onFailure: () => nOfPokemonFound = 0
            );

            //save the query infomation
            string[,] pokemonList = new string[nOfPokemonFound, 3];
            for(int i = 0; i < nOfPokemonFound; i++)
            {
                pokemonList[i, 0] = pokemonId[i].ToString();
                pokemonList[i, 1] = pokemonName[i];
                pokemonList[i, 2] = pokemonType[i];
            }

            return pokemonList;
        }
    }
}

