using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using Pokemon_Utility.Models.Context;

namespace Pokemon_Utility.Views.TeamBuilder;

public class TeamPage : Grid
{
    private int teamID;


    private List<PokemonInfoTeam> pokemonList = new List<PokemonInfoTeam>();
    
    public TeamPage()
    {
        // this.Children.Add(_teamPanel);
        // this.Children.Add(_analysisPanel);
        this.ColumnDefinitions = ColumnDefinitions.Parse("3*,2*");
        this.RowDefinitions = RowDefinitions.Parse("1*,160");
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
                        pokemonList.Add( new PokemonInfoTeam((int)pokemon.PokemonId, pokemon.MovesetId));

                    }
                }

                var teamPanel = new TeamPanel(pokemonList);
                this.Children.Add(teamPanel );
                Grid.SetColumn(teamPanel,0);
                var teamAnalysis = new AnalysisPanel(pokemonList);
                this.Children.Add(teamAnalysis);
                Grid.SetColumn(teamAnalysis,1);
                Grid.SetRowSpan(teamAnalysis,2);
                var cRUDbutton = new CRUDButton(teamID);
                this.Children.Add(cRUDbutton );
                Grid.SetColumn(cRUDbutton,0);
                Grid.SetRow(cRUDbutton,1);


            },
            onFailure: () => { }
            );
    }
}