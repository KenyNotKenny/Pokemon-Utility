using System;

namespace Pokemon;

public class MainContext : PokemonContext
{
    private static MainContext instance;

    static MainContext()
    {
        instance = new MainContext();
    }
    private MainContext(){}

    public static bool Connected
    {
        get { return instance.Database.CanConnect(); }
    }

    public static void Query(Action<MainContext> onReceive, Action onFailure)
    {
        if (Connected)
        {
            onReceive(instance);
        }
        else
        {
            onFailure();
        }
    }
}