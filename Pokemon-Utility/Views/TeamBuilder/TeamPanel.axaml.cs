using Avalonia;
using Avalonia.Controls;
using System.Drawing;

namespace Pokemon_Utility.Views.TeamBuilder;

public partial class CRUDButton : Panel
{
    // Chủ
    // Panel này được hiển thị ở ngay dưới Team Panel
    // Việc của ông là thêm 4 nút vào panel này như sau:
    // Add pokemon:
    //      khi ấn nút ông thêm 1 dòng vào table TeamPokemon với giá trị TeamPokemon.pokemon_id lấy từ người dùng
    //      từ 1 cái Textbox ông tự thêm và giá trị TeamPokemon.team_id từ biến team_id bên dưới
    // Remove Pokemon:
    //      Ông chỉ cần hiện cái nút, sử lý chức năng tui sẽ làm
    // Add team:
    //      khi ấn nút ông thêm 1 dòng vào table Team với giá trị Team.name lấy từ người dùng
    //      từ 1 cái Textbox ông tự thêm, id sẽ được thêm tự động ông không cần thêm
    // Remove Team:
    //      Ông chỉ cần hiện cái nút, sử lý chức năng tui sẽ làm
    
    // Note: từ bên ngoài tui đang gọi hàm constructor thứ 2 và truyền vào id là 2
    // Thao tác với database ông đọc hướng dãn tui có ghi trong README.md

    private int team_id;

    
    public Button AddPokemonButton { get; set; }
    public Button RemovePokemonButton { get; set; }
    public Button AddTeamButton { get; set; }
    public Button RemoveTeamButton { get; set; }


    public CRUDButton()
    {
        InitializeComponent();
    }
    public CRUDButton( int current_team_id) : this()
    {
        team_id = current_team_id;
        // TO-DO

        AddPokemonButton = new Button()
        {
            Content = "Add Pokemon",
            
            
        };

        Children.Add(AddPokemonButton);
        AddPokemonButton.Margin = new Thickness(20, 0, 0, 0);

        // click on AddPokemonButton will open a Textbox        // click on AddPokemonButton will open a Textbox
        // user input the Pokemon ID
        // then click on OK will add the Pokemon to the Team
        AddPokemonButton.Click += delegate
        {
            // create a textbox
            TextBox input = new TextBox()
            {
                Width = 100,
                Height = 50,
                Margin = new Thickness(10, 0, 0, 0)
            };
            // create a button
            Button ok = new Button()
            {
                Content = "OK",
                Margin = new Thickness(130, 100, 0, 0)
            };
            // create a panel to hold the textbox and the button
            Panel panel = new Panel()
            {
                Margin = new Thickness(0, 100, 0, 0)
            };
            // add the textbox and the button to the panel
            panel.Children.Add(input);
            panel.Children.Add(ok);
            // create a window to hold the panel
            Window window = new Window()
            {
                Width = 300,
                Height = 300,
                Content = panel
            };
            // click on the button will add the Pokemon to the Team
            ok.Click += delegate
            {
                // TO-DO
                // add the Pokemon to the Team
                // get the Pokemon ID from the textbox
                // and the Team ID from the variable team_id
                // then add the Pokemon to the Team
                // Note: the Pokemon ID is in the textbox
                // the Team ID is in the variable team_id

            };
            // show the window
            window.Show();
        };




        // Create and add the Remove Pokemon button
        RemovePokemonButton = new Button()
        {
            Content = "Remove Pokemon",
            
            
        };

        Children.Add(RemovePokemonButton);
        RemovePokemonButton.Margin = new Thickness(135, 0, 0, 0);

        // Create and add the Add Team button
        AddTeamButton = new Button()
        {
            Content = "Add Team",
            
        };

        Children.Add(AddTeamButton);
        AddTeamButton.Margin = new Thickness(285, 0, 0, 0);
        AddTeamButton.Click += delegate
        {
            // create a textbox
            TextBox input = new TextBox()
            {
                Width = 100,
                Height = 50,
                Margin = new Thickness(10, 0, 0, 0)
            };
            // create a button
            Button ok = new Button()
            {
                Content = "OK",
                Margin = new Thickness(130, 100, 0, 0)
            };
            // create a panel to hold the textbox and the button
            Panel panel = new Panel()
            {
                Margin = new Thickness(0, 100, 0, 0)
            };
            // add the textbox and the button to the panel
            panel.Children.Add(input);
            panel.Children.Add(ok);
            // create a window to hold the panel
            Window window = new Window()
            {
                Width = 300,
                Height = 300,
                Content = panel
            };
            // click on the button will add the Pokemon to the Team
            ok.Click += delegate
            {
                // TO-DO
                // add the Pokemon to the Team
                // get the Pokemon ID from the textbox
                // and the Team ID from the variable team_id
                // then add the Pokemon to the Team
                // Note: the Pokemon ID is in the textbox
                // the Team ID is in the variable team_id

            };
            // show the window
            window.Show();
        };



        // Create and add the Remove Team button
        RemoveTeamButton = new Button()
        {
            Content = "Remove Team",
            
        };

        Children.Add(RemoveTeamButton);
        RemoveTeamButton.Margin = new Thickness (375, 0, 0, 0);
    }
}
