using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Microsoft.IdentityModel.Tokens;
using Pokemon;

namespace Pokemon_Utility.Views.Browsing;

public partial class DetailPopupPanel : Panel
{
    private int id;
    private string name;
    private string? type1;
    private string? type2;
    private int genderRate;
    private int catchRate;
    private List<Move> moveList = new List<Move>();
    public DetailPopupPanel()
    {
        InitializeComponent();
        HeaderBar.Background = Design.Color.FgBlue;
        MoveListPanel.Background = Design.Color.BgLightGray;
        
        CloseButton.Click += (sender, args) => { (this.Parent as Panel).Children.Remove(this);};
    }

    public DetailPopupPanel(int id) : this()
    {
        this.id = id;
        QueryForData();
        HeaderTextBox.Text = string.Format("#{0} {1}",id,name);
        // testText.Text = id+" "+name +" "+catchRate+" "+ genderRate+"\nType:"+ type1+ (type2.IsNullOrEmpty()? "": type2);
        // testText.Text += "\n Moves:";
        // foreach (var move in moveList)
        // {
        //     testText.Text += move.Name+"\n";
        // }
    }

    private void QueryForData()
    {
        MainContext.Query(
            onReceive: context =>
            {
                var pokemon = context.Pokemons.Find(id);
                this.name = pokemon.Name;
                this.genderRate = (int)pokemon.GenderRate;
                this.catchRate = (int)pokemon.CaptureRate;
                var types = context.PokemonTypes.Where(s => s.PokemonId == id).ToList();
                type1 = types[0].Name;
                if (types.Count >1)
                {
                    type2 = types[1].Name;

                }


                moveList = (from pm in context.PokemonMoves.Where(s => s.PokemonId == id)
                    join m in context.Moves on pm.MoveId equals m.Id
                    select m).Distinct().ToList();
                

            },
            onFailure: () => { }
        );
    }
}