using Avalonia;
using Avalonia.Controls;

namespace Pokemon_Utility.Views.Browsing;

public partial class StatBar : Panel
{
    public StatBar(double value)
    {
        InitializeComponent();
        bar.Background = Design.Color.FgBlue;
        this.Width = value*3;
        statNumber.Text = value.ToString();
    }
}