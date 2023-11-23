using Avalonia;
using Avalonia.Controls;

namespace Pokemon_Utility.Views.TeamBuilder;

public partial class LeftChartBar : Panel
{
    public LeftChartBar(int value)
    {
        InitializeComponent();

        this.Width = value*20;
        
    }
}