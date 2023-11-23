using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia;
using Avalonia.Controls.Shapes;


namespace Pokemon_Utility.Views.TeamBuilder;

public partial class TeamTopBar : Panel
{
    // Cường
    // Ông tạo 1 tab bar bên trong cái Panel này
    // Cái listbox ông để public dể tui gán event
    // Lấy tên từ cái contructor thứ 2 để hiện thị cho mỗi tab
    // nhớ trang trí giống cái hình tui vẽ
        public ListBox TeamListBox { get; }
        public TabControl TabControl { get; }
        private Grid AddTabButtonGrid { get; }
    public TeamTopBar()
    {
            TeamListBox = new ListBox();
            Children.Add(TeamListBox);
            TabControl = new TabControl();
            Children.Add(TabControl);

            // Thêm tab Sweaping Team
            var sweapingTabItem = new TabItem
            {
                Header = "Sweaping Team"
            };
            TabControl.Items.Add(sweapingTabItem);

            // Thêm tab Trolling Team
            var trollingTabItem = new TabItem
            {
                Header = "Trolling Team"
            };
            TabControl.Items.Add(trollingTabItem);

            // Tạo dấu cộng để thêm tab
            AddTabButtonGrid = CreateAddTabButtonGrid();
            Children.Add(AddTabButtonGrid);
    }
    public TeamTopBar(List<string> teamNames) : this()
    {
        foreach (var teamName in teamNames)
        {
            TeamListBox.Items.Add(teamName);
        }
    }

    // Phương thức để tạo một TabItem mới với trang trí đẹp
    private TabItem CreateTabItem(string tabName)
    {
        var tabItem = new TabItem
        {
            Header = tabName
        };

        var tabGrid = new Grid();
        tabGrid.Background = Brushes.White;
        tabGrid.ColumnDefinitions.Add(new ColumnDefinition(1, GridUnitType.Star));
        tabGrid.ColumnDefinitions.Add(new ColumnDefinition(20, GridUnitType.Pixel));

        var tabTextBlock = new TextBlock
        {
            Text = tabName,
            HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
            VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center
        };
        Grid.SetColumn(tabTextBlock, 0);

        var closeIcon = new Path
        {
            Data = Geometry.Parse("M 0 0 L 6 6 M 0 6 L 6 0"),
            Stroke = Brushes.Red,
            StrokeThickness = 2,
            HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
            VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center,
            Width = 12,
            Height = 12
        };
        Grid.SetColumn(closeIcon, 1);

        tabGrid.Children.Add(tabTextBlock);
        tabGrid.Children.Add(closeIcon);

        tabItem.Header = tabGrid;

        return tabItem;
    }

    // Phương thức để tạo Grid chứa dấu cộng để thêm tab
    private Grid CreateAddTabButtonGrid()
    {
        var grid = new Grid();
        grid.ColumnDefinitions.Add(new ColumnDefinition(1, GridUnitType.Auto));
        grid.ColumnDefinitions.Add(new ColumnDefinition(20, GridUnitType.Pixel));

        var addButton = new Path
        {
            Data = Geometry.Parse("M 0 4 H 8 M 4 0 V 8"),
            Stroke = Brushes.Black,
            StrokeThickness = 2,
            HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
            VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center,
            Width = 8,
            Height = 8
        };
        Grid.SetColumn(addButton, 0);

        grid.Children.Add(addButton);

        return grid;
    }
    // Phương thức để thêm một tab mới
    public void AddTab(string tabName)
    {
        var newTabItem = new TabItem
        {
            Header = tabName
        };
        TabControl.Items.Add(newTabItem);
    }
}