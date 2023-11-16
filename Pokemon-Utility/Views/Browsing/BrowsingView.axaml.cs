using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Shapes;
using Avalonia.Controls.Templates;
using Avalonia.Media;
using Avalonia.Layout;
using Avalonia.Platform;
using System.Xml.Linq;

namespace Pokemon_Utility.Views.Browsing;

public partial class BrowsingView : Grid
{
    public BrowsingView()
    {
        InitializeComponent();

        //set the column and row to auto size
        this.ColumnDefinitions.Add(new ColumnDefinition(GridLength.Auto));
        this.RowDefinitions.Add(new RowDefinition(GridLength.Auto));
        this.RowDefinitions.Add(new RowDefinition(GridLength.Star));

        //set up the UI
        this.BrowsingBar();
        this.PokemonList();
    }

    //method to create BrowsingBar
    void BrowsingBar()
    {
        StackPanel browsingBar = new StackPanel();
        //set the browsingBar as the children of the BrowsingView
        this.Children.Add(browsingBar);
        //set the browsingBar as the 1st row of the BrowsingView
        Grid.SetRow(browsingBar, 0);

        //change the browsingBar properties
        browsingBar.Height = 120;
        browsingBar.HorizontalAlignment = HorizontalAlignment.Stretch;
        browsingBar.Background = Brushes.Gray;

        TextBox searchBar = new TextBox();
        //set the searchBar as the children of the browsingBar
        browsingBar.Children.Add(searchBar);

        //change the searchBar properties
        searchBar.Height = (browsingBar.Height-10)/2;
        searchBar.Width = 900;
        searchBar.CornerRadius = CornerRadius.Parse("30");
        searchBar.Margin = Thickness.Parse("10");
        searchBar.VerticalAlignment = VerticalAlignment.Top;
        searchBar.HorizontalAlignment = HorizontalAlignment.Left;
        searchBar.VerticalContentAlignment = VerticalAlignment.Center;

        //create an event when the user input key word
        searchBar.TextChanged += userInbutKeyWord;

        TextBlock pokemonFound_Textblock = PokemonFoundTextblock(123);
        browsingBar.Children.Add(pokemonFound_Textblock);
        pokemonFound_Textblock.Height= browsingBar.Height / 2;
        pokemonFound_Textblock.TextAlignment = TextAlignment.Center;
    }

    //the event when the user input key word
    private void userInbutKeyWord(object? sender, TextChangedEventArgs e)
    {
        TextBox textBox = (TextBox)sender;
        string userInput = textBox.Text;
    }

    TextBlock PokemonFoundTextblock(int nOfPokemonFound)
    {
        TextBlock pokemonFound_Textblock = new TextBlock();

        //change the PokemonFound_Textblock properties
        pokemonFound_Textblock.Background = Brushes.White;
        pokemonFound_Textblock.Text = $"\n{nOfPokemonFound} Pokemon found";
        pokemonFound_Textblock.Foreground = Brushes.Black;

        return pokemonFound_Textblock;
    }

    //method to create the DataCard
    Border DataCard(string Type,int id,string name)
    {
        Border dataCard_Border = new Border();

        //change the datacard properties
        dataCard_Border.Margin = Thickness.Parse("30");
        dataCard_Border.CornerRadius = CornerRadius.Parse("5");
        dataCard_Border.Width = 700 / 3;
        dataCard_Border.Height = 150;
        switch (Type)
        {
            //the color according to the type of pokemon
            case "Fire":
                dataCard_Border.Background = Brushes.Red;
                break;
            case "Water":
                dataCard_Border.Background = Brushes.Blue;
                break;
            case "Electric":
                dataCard_Border.Background = Brushes.Yellow;
                break;
            case "Grass":
                dataCard_Border.Background = Brushes.LightGreen;
                break;
            case "Ice":
                dataCard_Border.Background = Brushes.PowderBlue;
                break;
            case "Fighting":
                dataCard_Border.Background = Brushes.Brown;
                break;
            case "Poison":
                dataCard_Border.Background = Brushes.Purple;
                break;
            case "Ground":
                dataCard_Border.Background = Brushes.LightGoldenrodYellow;
                break;
            case "Flying":
                dataCard_Border.Background = Brushes.Lavender;
                break;
            case "Psychic":
                dataCard_Border.Background = Brushes.DeepPink;
                break;
            case "Bug":
                dataCard_Border.Background = Brushes.DarkOliveGreen;
                break;
            case "Rock":
                dataCard_Border.Background = Brushes.AntiqueWhite;
                break;
            case "Ghost":
                dataCard_Border.Background = Brushes.DarkMagenta;
                break;
            case "Dragon":
                dataCard_Border.Background = Brushes.MediumPurple;
                break;
            case "Dark":
                dataCard_Border.Background = Brushes.SaddleBrown;
                break;
            case "Steel":
                dataCard_Border.Background = Brushes.LightGray;
                break;
            case "Fairy":
                dataCard_Border.Background = Brushes.Pink;
                break;
            default:
                dataCard_Border.Background = Brushes.Gray;
                break;
        }

        StackPanel dataCard = new StackPanel();
        //set the dataCard as the children of the dataCard_Border
        dataCard_Border.Child = dataCard;

        //change the dataCard properties
        dataCard.Orientation = Orientation.Horizontal;

        StackPanel pic = new StackPanel();
        //set the pic as the children of the dataCard
        dataCard.Children.Add(pic);

        //change the pic properties
        pic.Width = dataCard_Border.Width / 2;
        pic.VerticalAlignment = VerticalAlignment.Stretch;

        Border id_name_icon_Border = new Border();
        //set the id_name_icon_Border as the children of the dataCard
        dataCard.Children.Add(id_name_icon_Border);

        //change the id_name_icon_border properties
        id_name_icon_Border.Background = Brushes.WhiteSmoke;
        id_name_icon_Border.CornerRadius = new CornerRadius(0, 5, 5, 0);

        StackPanel id_name_icon = new StackPanel();
        //set the id_name_icon as the children of the id_name_icon_Border
        id_name_icon_Border.Child = id_name_icon;

        //change the id_name_icon properties
        id_name_icon.Width = dataCard_Border.Width / 2;
        id_name_icon.VerticalAlignment = VerticalAlignment.Stretch;
        id_name_icon.Orientation = Orientation.Vertical;

        TextBlock id_name = new TextBlock();
        //set the id_name as the children of the id_name_icon
        id_name_icon.Children.Add(id_name);

        //change the id_name properties
        id_name.Foreground = Brushes.Black;
        id_name.Margin = Thickness.Parse("10");
        id_name.Text = $"#{id}\n{name}";

        return dataCard_Border;
    }

    //method to create the PokemonList
    void PokemonList()
    {
        ScrollViewer pokemonList_ScrollViewer = new ScrollViewer();
        //set the pokemonList_ScrollViewer as the children of the BrowsingView
        this.Children.Add(pokemonList_ScrollViewer);
        //set the pokemonList_ScrollViewer as the 3rd row of the BrowsingView
        Grid.SetRow(pokemonList_ScrollViewer, 2);

        //change the pokemonList_ScrollViewer properties
        pokemonList_ScrollViewer.Background = Brushes.White;
        //pokemonList_ScrollViewer.VerticalAlignment = VerticalAlignment.Bottom;
        pokemonList_ScrollViewer.HorizontalAlignment = HorizontalAlignment.Stretch;
        
        StackPanel pokemonList = new StackPanel();
        //show the dataCards on the pokemonList
        for (int i = 0; i < 20; i++)
        {
            StackPanel pokemonRow = new StackPanel();
            pokemonRow.Orientation = Orientation.Horizontal;
            for (int y = 0; y < 4; y++)
            {
                Border dataCard = DataCard("Fairy", i, "Pokemon");
                pokemonRow.Children.Add(dataCard);
            }
            pokemonList.Children.Add(pokemonRow);
        }

        ////set the pokemonList as the children of the pokemonList_ScrollViewer
        pokemonList_ScrollViewer.Content = pokemonList;
    }
}