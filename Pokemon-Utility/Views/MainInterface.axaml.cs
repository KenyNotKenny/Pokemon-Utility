using Avalonia.Controls;

namespace Pokemon_Utility.Views;

public partial class MainInterface : StackPanel
{
    public MainInterface()
    {
        InitializeComponent();
        var browsingView = new BrowsingView();
        var teamView = new TeamView();
        this.Children.Add(teamView);

    }
    
}