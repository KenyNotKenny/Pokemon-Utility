using Avalonia.Controls;

namespace Pokemon_Utility.Views;

public partial class MainInterface : StackPanel
{
    public MainInterface()
    {
        InitializeComponent();
        var browsingView = new Browsing.BrowsingView();
        var teamView = new TeamBuilder.TeamView();
        this.Children.Add(teamView);

    }
    
}