/* using System.Collections.Generic;
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
} */

using System;
using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace Pokemon_Utility.Views.TeamBuilder
{
    public partial class TeamPanel : Panel
    {
        private readonly CRUDButton _crudButton = new CRUDButton(2);

        public TeamPanel()
        {
            InitializeComponent();
            this.Children.Add(_crudButton);
        }

        public TeamPanel(List<PokemonInfoTeam> pokemonList) : this()
        {
            DisplayPokemonList(pokemonList);
        }

        private void DisplayPokemonList(List<PokemonInfoTeam> pokemonList)
        {
            const int maxPokemonDisplayed = 6;
            int displayedPokemonCount = Math.Min(pokemonList.Count, maxPokemonDisplayed);

            for (int i = 0; i < displayedPokemonCount; i++)
            {
                PokemonInfoTeam pokemon = pokemonList[i];

                // Tạo hình ảnh của Pokémon từ tên file ảnh dựa trên ID của Pokémon
                Bitmap pokemonImage = new Bitmap(AssetLoader.Open(new Uri($"avares://Pokemon-Utility/Assets/pokemon/{pokemon.Id}.png")));

                // Hiển thị hình ảnh Pokémon trong một Control (ở đây là Image)
                Image pokemonImageView = new Image
                {
                    Source = pokemonImage,
                    Width = 100, // Thiết lập kích thước ảnh (có thể điều chỉnh)
                    Height = 100, // Thiết lập kích thước ảnh (có thể điều chỉnh)
                    Margin = new Avalonia.Thickness(10) // Khoảng cách giữa các hình ảnh
                };

                // Thêm hình ảnh Pokémon vào TeamPanel
                this.Children.Add(pokemonImageView);
            }
        }
    }

}
