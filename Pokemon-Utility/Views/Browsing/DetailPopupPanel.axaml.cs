using Avalonia.Controls;

namespace Pokemon_Utility.Views.Browsing;

public partial class DetailPopupPanel : Panel
{
    public DetailPopupPanel()
    {
        InitializeComponent();
    }

    public DetailPopupPanel(int id) : this()
    {
        testText.Text = id.ToString();
    }
}