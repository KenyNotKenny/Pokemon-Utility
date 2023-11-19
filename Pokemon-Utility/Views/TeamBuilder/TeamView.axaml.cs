using Avalonia.Controls;

namespace Pokemon_Utility.Views.TeamBuilder;

public partial class TeamView : Panel
{
    private TeamTopBar _teamTopBar = new TeamTopBar();
    private TeamPanel _teamPanel = new TeamPanel();
    private AnalysisPanel _analysisPanel = new AnalysisPanel();
    public TeamView()
    {
        InitializeComponent();
        grid.Children.Add(_teamTopBar);
        grid.Children.Add(_teamPanel);
        grid.Children.Add(_analysisPanel);

        
        Grid.SetRow(_teamTopBar,0);
        Grid.SetColumnSpan(_teamTopBar,2);

        Grid.SetRow(_teamPanel,1);
        Grid.SetColumn(_teamPanel,0);
        
        Grid.SetRow(_analysisPanel,1);
        Grid.SetColumn(_analysisPanel,1);


    }
}