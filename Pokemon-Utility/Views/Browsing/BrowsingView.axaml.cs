using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Layout;
using System;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace Pokemon_Utility.Views.Browsing;
/// <summary>
/// BrowsingView
///     browsingBar
///         searchBar
///         searchButton
///         filter
///         sorter
///     pokemonFound_Textblock
///     pokemonList_ScrollViewer
///         pokemonList
///             pokemonRow
///                 dataCard_Border
///                 dataCard_Border
///                 dataCard_Border
///                 ...
///             pokemonRow
///                 dataCard_Border
///                 dataCard_Border
///                 dataCard_Border
///                 ...
///             pokemonRow
///                 dataCard_Border
///                 dataCard_Border
///                 dataCard_Border
///                 ...
///             ...
/// </summary>
public partial class BrowsingView : Panel
{
    StackPanel browsingBar;
    TextBox searchBar;
    Button searchButton;
    Image searchIcon;
    Filter filter;
    SortingButton sorter;
    TextBlock pokemonFound_Textblock;
    ScrollViewer pokemonList_ScrollViewer;
    StackPanel pokemonList;
    StackPanel pokemonRow;

    public BrowsingView()
    {
        InitializeComponent();

        //set the column and row to auto size
        GridView.ColumnDefinitions.Add(new ColumnDefinition(1, GridUnitType.Star));
        GridView.RowDefinitions.Add(new RowDefinition(1, GridUnitType.Auto));
        GridView.RowDefinitions.Add(new RowDefinition(2, GridUnitType.Auto));
        GridView.RowDefinitions.Add(new RowDefinition(3, GridUnitType.Star));

        //set up the UI
        string[,] pokemons = new string[1, 1];
        int nOfPokemon = 0;

        this.BrowsingBar();
        this.PokemonFoundTextblock(nOfPokemon);
        this.PokemonList(nOfPokemon, pokemons);
    }



    //method to create BrowsingBar
    void BrowsingBar()
    {
        browsingBar = new StackPanel();
        //set the browsingBar as the children of the BrowsingView
        GridView.Children.Add(browsingBar);
        //set the browsingBar as the 1st row of the BrowsingView
        Grid.SetRow(browsingBar, 0);

        //change the browsingBar properties
        browsingBar.Height = 80;
        browsingBar.HorizontalAlignment = HorizontalAlignment.Stretch;
        browsingBar.Background = Brushes.Gray;
        browsingBar.Orientation = Orientation.Horizontal;

        searchBar = new TextBox();
        //set the searchBar as the children of the browsingBar
        browsingBar.Children.Add(searchBar);

        //change the searchBar properties
        searchBar.Height = browsingBar.Height/1.5;
        searchBar.Width = 900;
        searchBar.CornerRadius = CornerRadius.Parse("30");
        searchBar.Margin = new Thickness(10, 13, 10, 10);
        searchBar.VerticalAlignment = VerticalAlignment.Center;
        searchBar.HorizontalAlignment = HorizontalAlignment.Left;
        searchBar.VerticalContentAlignment = VerticalAlignment.Center;

        searchButton = new Button();
        //set the searchButton as the children of the browsingBar
        browsingBar.Children.Add(searchButton);

        //change the searchButton properties
        searchButton.Width = searchButton.Height = 40;
        searchButton.Background = Design.Color.FgBlue;

        //create an event when the user input key word and click the searchButton
        searchButton.Click += (sender, e) =>
        {
            GridView.Children.RemoveAt(1);
            GridView.Children.RemoveAt(1);

            string userInput = searchBar.Text;

            BrowsingQuery a = new BrowsingQuery();
            string[,] pokemons = a.PokemonQuery_byName(userInput,filter.SelectedItem);
            int nOfPokemon = a.NOfPokemonFound;

            this.PokemonFoundTextblock(nOfPokemon);
            this.PokemonList(nOfPokemon, pokemons);
            //filter.SelectedItem = "null";
        };

        searchIcon = new Image();
        searchIcon.Source = new Bitmap(AssetLoader.Open(new Uri("avares://Pokemon-Utility/Assets/search_icon.png")));
        //set the searchIcon as the children of the searchButton
        searchButton.Content = searchIcon;

        filter = new Filter();
        //set the filter as the children of the browsingBar
        browsingBar.Children.Add(filter);

        sorter = new SortingButton();
        //set the sorter as the children of the browsingBar
        browsingBar.Children.Add(sorter);
    }

    void PokemonFoundTextblock(int nOfPokemonFound)
    {
        pokemonFound_Textblock = new TextBlock();
        //set the pokemonList_ScrollViewer as the children of the BrowsingView
        GridView.Children.Add(pokemonFound_Textblock);
        //set the pokemonList_ScrollViewer as the 3rd row of the BrowsingView
        Grid.SetRow(pokemonFound_Textblock, 1);

        //change the PokemonFound_Textblock properties
        pokemonFound_Textblock.Background = Brushes.White;
        pokemonFound_Textblock.Text = $"\n{nOfPokemonFound} Pokemon found";
        pokemonFound_Textblock.Foreground = Brushes.Black;
        pokemonFound_Textblock.TextAlignment = TextAlignment.Center;
    }

    //method to create the PokemonList
    void PokemonList(int nOfPokemonFound, string[,] pokemonFound)
    {
        pokemonList_ScrollViewer = new ScrollViewer();
        //set the pokemonList_ScrollViewer as the children of the BrowsingView
        GridView.Children.Add(pokemonList_ScrollViewer);
        //set the pokemonList_ScrollViewer as the 3rd row of the BrowsingView
        Grid.SetRow(pokemonList_ScrollViewer, 2);

        //change the pokemonList_ScrollViewer properties
        pokemonList_ScrollViewer.Background = Brushes.White;
        pokemonList_ScrollViewer.VerticalAlignment = VerticalAlignment.Stretch;
        pokemonList_ScrollViewer.HorizontalAlignment = HorizontalAlignment.Stretch;
        
        pokemonList = new StackPanel();
        //show the dataCards on the pokemonList
        int nOfDataCardRow = nOfPokemonFound % 4 == 0 ? (nOfPokemonFound / 4) : (nOfPokemonFound / 4 + 1);
        int index = 0;
        for (int i = 0; i < nOfDataCardRow; i++)
        {
            pokemonRow = new StackPanel();

            //change the pokemonRow properties
            pokemonRow.HorizontalAlignment = HorizontalAlignment.Center;
            pokemonRow.Orientation = Orientation.Horizontal;

            //add the dataCards to the pokemonRow
            for (int y = 0; y < 4; y++)
            {
                if (nOfPokemonFound == 0)
                {
                    break;
                }
                DataCard dataCard_Border = new DataCard(pokemonFound[index, 2], pokemonFound[index, 3], int.Parse(pokemonFound[index,0]), pokemonFound[index,1]);
                dataCard_Border.PointerPressed += (sender, args) => { this.Children.Add( new  DetailPopupPanel(dataCard_Border.ID));};
                pokemonRow.Children.Add(dataCard_Border);

                //update index
                nOfPokemonFound--;
                index++;
            }
            pokemonList.Children.Add(pokemonRow);
        }

        //set the pokemonList as the children of the pokemonList_ScrollViewer
        pokemonList_ScrollViewer.Content = pokemonList;
    }
}