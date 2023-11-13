using Avalonia.Controls;
using Pokemon_Utility.Views;

namespace Pokemon_Utility;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        MainInterface mainInterface = new MainInterface();
        RootPanel.Children.Add(mainInterface);
        //comment
    }
}