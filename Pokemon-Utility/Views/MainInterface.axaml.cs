using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Media;
using Pokemon;
using Pokemon_Utility.Views.Browsing;
using Pokemon_Utility.Views.TeamBuilder;

namespace Pokemon_Utility.Views;

public partial class MainInterface : Panel
{
    private int id = 1;
    private TextBlock tb = new TextBlock { Text = "Data"};
    private Button btn = new Button { Content = "Click"};
    
    private BrowsingView browsingView = new Browsing.BrowsingView();
    private TeamView teamView = new TeamBuilder.TeamView();
    public MainInterface()
    {
        InitializeComponent();
        SideBar.Children.Add(tb);
        SideBar.Children.Add(btn);
        TabBar.Items.Add("Browse");
        TabBar.Items.Add("Team");
        TabBar.SelectedIndex = 0;
        

        if (MainContext.Connected)
        {
            
            
            this.Children.Add(browsingView);
            MainContext.Query(
                onReceive: context =>
                {
                    tb.Text = context.Pokemons.Find(id).Name;
                },
                onFailure: () => tb.Text = "No Connection"
            );
            btn.Click += OnClick;
            TabBar.SelectionChanged += OnSelect;

        }
        else
        {
            tb.Text = "No Connection";
        }



    }

    private void OnSelect(object? sender, SelectionChangedEventArgs e)
    {
        if ((sender as ListBox).SelectedIndex == 0)
        {
            this.Children[1] = browsingView;
        }
        else
        {
            this.Children[1] = teamView;
        }
    }
    

    private void OnClick(object? sender, RoutedEventArgs e)
    {
        id++;
        MainContext.Query(
            onReceive: context =>
            {
                tb.Text = context.Pokemons.Find(id).Name;
            },
            onFailure: () => tb.Text = "No Connection"
        );
    }

}