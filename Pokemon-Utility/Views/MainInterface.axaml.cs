using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Media;
using Avalonia.Styling;
using Pokemon;
using Pokemon_Utility.Views.Browsing;
using Pokemon_Utility.Views.TeamBuilder;

namespace Pokemon_Utility.Views;

public partial class MainInterface : Panel
{
   
    
    private BrowsingView browsingView = new Browsing.BrowsingView();
    private TeamView teamView = new TeamBuilder.TeamView();
    public MainInterface()
    {
        InitializeComponent();
        TabBar.Items.Add("Browse");
        TabBar.Items.Add("Team");
        TabBar.Foreground = Design.Color.FgBlue;
        TabBar.SelectedIndex = 0;
        LogoBox.Background = Design.Color.FgBlue;
        SideBar.Background = Design.Color.FgLightBlue;
        

        if (MainContext.Connected)
        {

            this.Children.Add(browsingView);

            TabBar.SelectionChanged += OnSelect;

        }
        else
        {

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
    

}