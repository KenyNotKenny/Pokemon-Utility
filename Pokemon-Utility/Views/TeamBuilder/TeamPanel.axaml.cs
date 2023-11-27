using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;
using System.Collections.Generic;

namespace Pokemon_Utility.Views.TeamBuilder
{
    public partial class TeamPanel : Panel
    {
        private CRUDButton _crudButton = new CRUDButton(2);
        private List<PokemonInfoTeam> _pokemonList;

        public TeamPanel()
        {
            InitializeComponent();
            this.Children.Add(_crudButton);
        }

        public TeamPanel(List<PokemonInfoTeam> pokemonList) : this()
        {
            _pokemonList = pokemonList;
            InitUI();
        }

        private void InitUI()
        {
            // Xóa các controls cũ nếu có
            this.Children.Clear();

            // Tạo WrapPanel để chứa các Pokemon
            WrapPanel wrapPanel = new WrapPanel();
            wrapPanel.Orientation = Orientation.Horizontal;

            foreach (var pokemon in _pokemonList)
            {
                // Tạo control hiển thị hình ảnh
                Image imgPokemon = new Image();
                Bitmap pokemonImage = new Bitmap(AssetLoader.Open(new Uri($"avares://Pokemon-Utility/Assets/pokemon/{pokemon.Id}.png")));
                imgPokemon.Source = pokemonImage;
                imgPokemon.Width = 120;
                imgPokemon.Height = 120;

                // Tạo control hiển thị tên Pokemon
                Label lblPokemonName = new Label();
                lblPokemonName.Content = pokemon.Name;
                lblPokemonName.FontSize = 14;
                lblPokemonName.HorizontalAlignment = HorizontalAlignment.Center;

                // Thêm các controls vào một StackPanel
                StackPanel stackPanel = new StackPanel();
                stackPanel.Children.Add(imgPokemon);
                stackPanel.Children.Add(lblPokemonName);

                // Thêm StackPanel vào WrapPanel
                wrapPanel.Children.Add(stackPanel);
            }

            // Thêm WrapPanel vào TeamPanel
            this.Children.Add(wrapPanel);

            // Chừa 80 pixel ở bên dưới
            this.Height = this.Children.Count * 120 + 80;
        }
    }
}