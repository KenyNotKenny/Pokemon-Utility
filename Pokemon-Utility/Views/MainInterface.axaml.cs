using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Media;
using Pokemon;

namespace Pokemon_Utility.Views;

public partial class MainInterface : Panel
{
    private int id = 1;
    private TextBlock tb = new TextBlock { Text = "Data"};
    private Button btn = new Button { Content = "Click"};
    public MainInterface()
    {
        InitializeComponent();
        SideBar.Children.Add(tb);
        SideBar.Children.Add(btn);

        if (MainContext.Connected)
        {
            var browsingView = new Browsing.BrowsingView();
            var teamView = new TeamBuilder.TeamView();
            
            this.Children.Add(browsingView);
            MainContext.Query(
                onReceive: context =>
                {
                    tb.Text = context.Pokemons.Find(id).Name;
                },
                onFailure: () => tb.Text = "No Connection"
            );
            btn.Click += OnClick;

        }
        else
        {
            tb.Text = "No Connection";
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