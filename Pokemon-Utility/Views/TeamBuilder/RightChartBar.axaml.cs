using Avalonia;
using Avalonia.Controls;

namespace Pokemon_Utility.Views.TeamBuilder;

public partial class RightChartBar : Panel
{
    public RightChartBar(int value)
    {
        InitializeComponent();

        this.Width = value*20;
        
    }
}