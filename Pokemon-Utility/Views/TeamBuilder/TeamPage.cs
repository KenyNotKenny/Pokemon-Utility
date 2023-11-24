using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using Pokemon;

namespace Pokemon_Utility.Views.TeamBuilder;

public class TeamPage : Grid
{
    private int teamID;
    private static List<PokemonInfoTeam> temp = new List<PokemonInfoTeam>
    {
        new PokemonInfoTeam(1),
        new PokemonInfoTeam(3),
        new PokemonInfoTeam(6),
        new PokemonInfoTeam(12),
        new PokemonInfoTeam(23),
        new PokemonInfoTeam(63),

    };

    private List<PokemonInfoTeam> pokemonList = new List<PokemonInfoTeam>();

    private TeamPanel _teamPanel = new TeamPanel(temp);
    private AnalysisPanel _analysisPanel = new AnalysisPanel(temp);
    public TeamPage()
    {
        // this.Children.Add(_teamPanel);
        // this.Children.Add(_analysisPanel);
        this.ColumnDefinitions = ColumnDefinitions.Parse("3*,2*");
        // Grid.SetColumn(_teamPanel,0);
        // Grid.SetColumn(_analysisPanel,1);
    }

    public TeamPage(int teamID ) : this()
    {
        this.teamID = teamID;
        this.Children.Clear();
        QueryForInfoTeam();
        // this.Children.Add( new TeamPanel());
        // this.Children.Add(_analysisPanel);
        // Grid.SetColumn(_teamPanel,0);
        // Grid.SetColumn(_analysisPanel,1);

    }

    private void QueryForInfoTeam()
    {
        MainContext.Query(
            onReceive: context =>
            {
                var team = context.TeamPokemons.Where(s => s.TeamId == this.teamID).ToList();
                foreach (var pokemon in team)
                {
                    if (pokemon.PokemonId != null)
                    {
                        pokemonList.Add( new PokemonInfoTeam((int)pokemon.PokemonId));

                    }
                }
                this.Children.Add( new TextBlock{Text = pokemonList[0].Name});

                var teamPanel = new TeamPanel(pokemonList);
                var teamAnalysis = new AnalysisPanel(pokemonList);
                this.Children.Add(teamPanel );
                this.Children.Add(teamAnalysis);
                Grid.SetColumn(teamPanel,0);
                Grid.SetColumn(teamAnalysis,1);
            },
            onFailure: () => { }
            );
    }
}