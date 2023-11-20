using System.Collections.Generic;
using Avalonia.Controls;

namespace Pokemon_Utility.Views.TeamBuilder;

public class TeamPage : Grid
{
    private TeamPanel _teamPanel = new TeamPanel();
    private AnalysisPanel _analysisPanel = new AnalysisPanel();
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