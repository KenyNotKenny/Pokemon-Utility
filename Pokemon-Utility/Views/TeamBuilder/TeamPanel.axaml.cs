using System.Collections.Generic;
using Avalonia.Controls;

namespace Pokemon_Utility.Views.TeamBuilder;

public partial class TeamPanel : Panel
{
    // Đức
    // Ông tạo 1 giao điện hiển thị max 6 con pokemon hoặc có thể it hơn
    // Trong contructor thứ 2 ông có thể lấy ra các thông tin của pokemon để vẽ giao diện
    // Ông phải có hiện hình của pokemon, tất cả file hình có trong Assests/pokemon
    // tên hình là id của con poekmon đó + ".png"
    // Trang trí sao cho đẹp là đc, nhớ chừa 80 pixel ở bên dưới để người khác thêm các nút chức năng khác
    private CRUDButton _crudButton = new CRUDButton(2); // mấy cái button này sẽ hiện bên dưới, đừng đụng vào
    public TeamPanel()
    {
        InitializeComponent();
        this.Children.Add(_crudButton);
    }
    public TeamPanel( List<PokemonInfoTeam> pokemonList ) : this()
    {

    }
}