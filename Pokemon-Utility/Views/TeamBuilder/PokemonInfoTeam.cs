using System.Linq;
using System.Threading.Tasks;
using Pokemon;

namespace Pokemon_Utility.Views.TeamBuilder;

public class PokemonInfoTeam
{
    public int Id;
    public string Name;
    public string Type1;
    public string? Type2 = null;

    public PokemonInfoTeam(int id)
    {
        MainContext.Query(
            onReceive: context =>
            {
                Name = context.Pokemons.Find(id).Name;
                var types = context.PokemonTypes.Where(s => s.PokemonId == id).ToList();
                Type1 = types[0].Name;
                if (types.Count >1)
                {
                    Type2 = types[1].Name;
                }
            },
            onFailure: () => { }
        );
    }

    
}