using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Layout;
using PokemonUtility;
using PokemonUtility.Views.Browsing;

namespace Pokemon_Utility.Views.Browsing;

public partial class BrowsingView : Panel
{
    public BrowsingView()
    {
        InitializeComponent();

        //set the column and row to auto size
        GridView.ColumnDefinitions.Add(new ColumnDefinition(GridLength.Auto));
        GridView.RowDefinitions.Add(new RowDefinition(GridLength.Auto));
        GridView.RowDefinitions.Add(new RowDefinition(GridLength.Star));

        //set up the UI
        this.BrowsingBar(123);
        BrowsingQuery a = new BrowsingQuery();
        string[,] b = a.PokemonQuery_byName("P");
        this.PokemonList(a.NOfPokemonFound, b);

        //string[] b = {"1", "1", "1", "1", "1", "1", "1", "1", "1", "1",
        //"1","1","1","1","1","1","1","1","1","1"};
        //this.PokemonList(20,b);
    }

    //method to create BrowsingBar
    void BrowsingBar(int nOfPokemonFound)
    {
        StackPanel browsingBar = new StackPanel();
        //set the browsingBar as the children of the BrowsingView
        GridView.Children.Add(browsingBar);
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

        TextBlock pokemonFound_Textblock = PokemonFoundTextblock(nOfPokemonFound);
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

    //method to create the PokemonList
    void PokemonList(int nOfPokemonFound, string[,] pokemonFound)
    {
        ScrollViewer pokemonList_ScrollViewer = new ScrollViewer();
        //set the pokemonList_ScrollViewer as the children of the BrowsingView
        GridView.Children.Add(pokemonList_ScrollViewer);
        //set the pokemonList_ScrollViewer as the 3rd row of the BrowsingView
        Grid.SetRow(pokemonList_ScrollViewer, 2);

        //change the pokemonList_ScrollViewer properties
        pokemonList_ScrollViewer.Background = Brushes.White;
        //pokemonList_ScrollViewer.VerticalAlignment = VerticalAlignment.Bottom;
        pokemonList_ScrollViewer.HorizontalAlignment = HorizontalAlignment.Stretch;
        
        StackPanel pokemonList = new StackPanel();
        //show the dataCards on the pokemonList
        int nOfDataCardRow = nOfPokemonFound % 4 == 0 ? (nOfPokemonFound / 4) : (nOfPokemonFound / 4 + 1);
        int index = 0;
        for (int i = 0; i < nOfDataCardRow; i++)
        {
            StackPanel pokemonRow = new StackPanel();
            pokemonRow.Orientation = Orientation.Horizontal;
            for (int y = 0; y < 4; y++)
            {
                if (nOfPokemonFound == 0)
                {
                    break;
                }
                DataCard dataCard = new DataCard();
                Border dataCard_Border = dataCard.SetDataCard(pokemonFound[i,2], int.Parse(pokemonFound[index,0]), pokemonFound[index,1]);
                pokemonRow.Children.Add(dataCard_Border);
                nOfPokemonFound--;
                index++;
            }
            pokemonList.Children.Add(pokemonRow);
        }

        ////set the pokemonList as the children of the pokemonList_ScrollViewer
        pokemonList_ScrollViewer.Content = pokemonList;
    }
}