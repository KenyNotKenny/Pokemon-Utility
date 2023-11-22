using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;

namespace Pokemon_Utility.Views.Browsing;

public class MoveCard : StackPanel
{
    public MoveCard()
    {
        this.Orientation = Orientation.Horizontal;
        this.Margin = new Thickness(20,5,5,20);
        this.Background = Design.Color.BgLightGray;
    }
    public MoveCard(string name, string type, string power, string accuracy, string pp , bool odd ) : this()
    {
        if (odd) this.Background = Design.Color.BgGray;
        this.Children.Add( new TextBlock{ Text = name +"\t"+ type+"\t"+power+"\t"+accuracy+"\t"+pp , FontSize = 30});
    }
}