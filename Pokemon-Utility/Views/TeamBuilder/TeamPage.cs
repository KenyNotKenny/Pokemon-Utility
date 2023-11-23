using System.Collections.Generic;
using Avalonia.Controls;

namespace Pokemon_Utility.Views.TeamBuilder;

public class TeamPage : Grid
{
    private static List<PokemonInfoTeam> temp = new List<PokemonInfoTeam>
    {
        new PokemonInfoTeam(1),
        new PokemonInfoTeam(3),
        new PokemonInfoTeam(6),
        new PokemonInfoTeam(12),
        new PokemonInfoTeam(23),
        new PokemonInfoTeam(63),

    };
    private TeamPanel _teamPanel = new TeamPanel(temp);
    private AnalysisPanel _analysisPanel = new AnalysisPanel(temp);
    public TeamPage()
    {
        this.Children.Add(_teamPanel);
        this.Children.Add(_analysisPanel);
        this.ColumnDefinitions = ColumnDefinitions.Parse("3*,2*");
        Grid.SetColumn(_teamPanel,0);
        Grid.SetColumn(_analysisPanel,1);
    }

    public TeamPage(List<PokemonInfoTeam> pokemonList ) : this()
    {
        this.Children.Clear();
        this.Children.Add( new TeamPanel());
        this.Children.Add(_analysisPanel);
        Grid.SetColumn(_teamPanel,0);
        Grid.SetColumn(_analysisPanel,1);

    }
}