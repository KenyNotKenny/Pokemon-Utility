using Avalonia.Controls;

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
    public CRUDButton()
    {
        InitializeComponent();
    }
    public CRUDButton( int current_team_id) : this()
    {
        team_id = current_team_id;
        // TO-DO
    }
}