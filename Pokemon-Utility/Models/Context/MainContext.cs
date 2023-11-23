using System;
using System.Threading.Tasks;
using PokeApiNet;

namespace Pokemon;

public class MainContext : PokemonContext
{
    private static MainContext instance;
    public static PokeApiClient ApiClient = new PokeApiClient();

    static MainContext()
    {
        instance = new MainContext();
    }
    private MainContext(){}

    public static bool Connected
    {
        get { return  instance.Database.CanConnect(); }
    }

    // public static async Task<bool> HaveConected()
    // {
    //     return await instance.Database.CanConnectAsync();
    // }

    public static async Task Query(Func<MainContext,Task> onReceive, Action onFailure)
    {
        if ( Connected)
        {
            onReceive(instance);
        }
        else
        {
            onFailure();
        }
    }
}