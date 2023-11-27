using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Interactivity;
using Avalonia.Media;
using Pokemon_Utility.Models.Context;

namespace Pokemon_Utility.Views.TeamBuilder
{
    public partial class TeamPanel : Panel
    {
        private List<PokemonInfoTeam> _pokemonList;

        public TeamPanel()
        {
            InitializeComponent();
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
            wrapPanel.VerticalAlignment = VerticalAlignment.Center;

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
                
                // Create delete button
                Button deleteButton = new Button
                {
                    Content = "x",
                    Background = Design.Color.BgGray,
                    Foreground = Brushes.White,
                    Height = 28,
                    Width = 28,
                    CornerRadius = new CornerRadius(16),
                    HorizontalAlignment = HorizontalAlignment.Right,
                    VerticalAlignment = VerticalAlignment.Top,
                };
                deleteButton.Click += (sender, args) =>
                {
                    MainContext.Query(
                        onReceive: context =>
                        {
                            context.TeamPokemons.Remove(context.TeamPokemons.Find(pokemon.MovesetId));
                            context.SaveChanges();
                        },
                        onFailure: () => { });
                };
                

                // Thêm các controls vào một StackPanel
                StackPanel stackPanel = new StackPanel();
                stackPanel.Children.Add(deleteButton);
                stackPanel.Children.Add(imgPokemon);
                stackPanel.Children.Add(lblPokemonName);

                

                // Thêm StackPanel vào WrapPanel
                wrapPanel.Children.Add(stackPanel);
            }

            // Thêm WrapPanel vào TeamPanel
            this.Children.Add(wrapPanel);
            
            
        }
        
    }
}