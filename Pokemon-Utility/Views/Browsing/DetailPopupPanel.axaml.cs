using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PokeApiNet;
using Pokemon;
using Move = Pokemon.Move;

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
        // QueryForData();
        FetchApiForData();
        HeaderTextBox.Text = string.Format("#{0} Loading...",id);
        PokemonImage.Source = new Bitmap(AssetLoader.Open(new Uri($"avares://Pokemon-Utility/Assets/pokemon/{id}.png")));
        // testText.Text = id+" "+name +" "+catchRate+" "+ genderRate+"\nType:"+ type1+ (type2.IsNullOrEmpty()? "": type2);
        // testText.Text += "\n Moves:";
        // foreach (var move in moveList)
        // {
        //     testText.Text += move.Name+"\n";
        // }
    }

    private async Task QueryForData()
    {
        
        MainContext.Query(
            onReceive: async context =>
            {
                var pokemon = context.Pokemons.Find(id);
                this.name = pokemon.Name;
                this.genderRate = (int)pokemon.GenderRate;
                this.catchRate = (int)pokemon.CaptureRate;
                var types = await context.PokemonTypes.Where(s => s.PokemonId == id).ToListAsync();
                type1 = types[0].Name;
                if (types.Count >1)
                {
                    type2 = types[1].Name;

                }


                moveList = await (from pm in context.PokemonMoves.Where(s => s.PokemonId == id)
                    join m in context.Moves on pm.MoveId equals m.Id
                    select m).Distinct().ToListAsync();
                
                
                // Set up
                HeaderTextBox.Text = string.Format("#{0} {1}",id,name);
                Type1TextBox.Text = type1;
                Type2TextBox.Text = (type2.IsNullOrEmpty()) ? "" : type2;
                bool bgFlip = true;
                foreach (var move in moveList)
                {
                    scrollViewerContent.Children.Add(new MoveCard(move.Name,move.Type,move.Power.ToString(),move.Accuracy.ToString(),move.Pp.ToString(),bgFlip));
                    bgFlip = !bgFlip;
                }

                Debug.WriteLine("Query Done");
                HeaderBar.Background = Design.Color.FgBlue;


                
            },
            onFailure: () => { }
        );
        Debug.WriteLine("Query Loaded");
    }

    private async Task FetchApiForData()
    {
        
        PokeApiNet.Pokemon pokemon = await MainContext.ApiClient.GetResourceAsync<PokeApiNet.Pokemon>(id);
        name = pokemon.Name;
        
        type1 = pokemon.Types[0].Type.Name;
        if (pokemon.Types.Count >1)
        {
            type2 = pokemon.Types[1].Type.Name;

        }
        

        FetchMove(pokemon);
        
        // Set up
        HeaderTextBox.Text = string.Format("#{0} {1}",id,name);
        Type1TextBox.Text = type1;
        Type2TextBox.Text = (type2.IsNullOrEmpty()) ? "" : type2;
        foreach (var ability in pokemon.Abilities)
        {
            infoStackPanel.Children.Add( new TextBlock
            {
                FontWeight = FontWeight.Bold,
                FontSize = 30,
                Text = ability.Ability.Name,
            });
        }

        foreach (var stat in pokemon.Stats)
        {
            infoStackPanel.Children.Add( new TextBlock
            {
                FontWeight = FontWeight.Bold,
                FontSize = 30,
                Text = stat.Stat.Name +": " +stat.BaseStat,
            });
            
        }
        
        
        

        Debug.WriteLine("Fetch Done");
    }

    private async Task FetchMove( PokeApiNet.Pokemon pokemon)
    {
        List<PokeApiNet.Move> allMoves = await MainContext.ApiClient.GetResourceAsync(pokemon.Moves.Select(move => move.Move));
        bool bgFlip = true;
        foreach (var move in allMoves)
        {
            scrollViewerContent.Children.Add(new MoveCard(move.Name,move.Type.Name,move.Power.ToString(),move.Accuracy.ToString(),move.Pp.ToString(),bgFlip));
            bgFlip = !bgFlip;
        }

        moveTitle.Text = "Name \t Type \t Power \t Acc \t PP";

    }


}