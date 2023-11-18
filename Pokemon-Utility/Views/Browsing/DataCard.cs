using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media;

namespace PokemonUtility.Views.Browsing
{
    /// <summary>
    /// DataCard
    ///     dataCard
    ///         pic
    ///         id_name_icon_Border
    ///             id_name_icon
    /// </summary>
	public class DataCard : Border
    {
        StackPanel dataCard;
        StackPanel pic;
        TextBlock id_name;
        Border id_name_icon_Border;
        StackPanel id_name_icon;

        public DataCard(string Type, int id, string name)
		{
            //change the datacard properties
            this.Margin = Thickness.Parse("30");
            this.CornerRadius = CornerRadius.Parse("5");
            this.Width = 700 / 3;
            this.Height = 150;
            switch (Type)
            {
                //the color according to the type of pokemon
                case "fire":
                    this.Background = Brushes.Red;
                    break;
                case "ater":
                    this.Background = Brushes.Blue;
                    break;
                case "electric":
                    this.Background = Brushes.Yellow;
                    break;
                case "grass":
                    this.Background = Brushes.LightGreen;
                    break;
                case "ice":
                    this.Background = Brushes.PowderBlue;
                    break;
                case "lighting":
                    this.Background = Brushes.Brown;
                    break;
                case "poison":
                    this.Background = Brushes.Purple;
                    break;
                case "ground":
                    this.Background = Brushes.LightGoldenrodYellow;
                    break;
                case "flying":
                    this.Background = Brushes.Lavender;
                    break;
                case "psychic":
                    this.Background = Brushes.DeepPink;
                    break;
                case "bug":
                    this.Background = Brushes.DarkOliveGreen;
                    break;
                case "rock":
                    this.Background = Brushes.AntiqueWhite;
                    break;
                case "ghost":
                    this.Background = Brushes.DarkMagenta;
                    break;
                case "fragon":
                    this.Background = Brushes.MediumPurple;
                    break;
                case "dark":
                    this.Background = Brushes.SaddleBrown;
                    break;
                case "steel":
                    this.Background = Brushes.LightGray;
                    break;
                case "fairy":
                    this.Background = Brushes.Pink;
                    break;
                default:
                    this.Background = Brushes.Gray;
                    break;
            }

            dataCard = new StackPanel();
            //set the dataCard as the children of the dataCard_Border
            this.Child = dataCard;

            //change the dataCard properties
            dataCard.Orientation = Orientation.Horizontal;

            pic = new StackPanel();
            //set the pic as the children of the dataCard
            dataCard.Children.Add(pic);

            //change the pic properties
            pic.Width = this.Width / 2;
            pic.VerticalAlignment = VerticalAlignment.Stretch;

            id_name_icon_Border = new Border();
            //set the id_name_icon_Border as the children of the dataCard
            dataCard.Children.Add(id_name_icon_Border);

            //change the id_name_icon_border properties
            id_name_icon_Border.Background = Brushes.WhiteSmoke;
            id_name_icon_Border.CornerRadius = new CornerRadius(0, 5, 5, 0);

            id_name_icon = new StackPanel();
            //set the id_name_icon as the children of the id_name_icon_Border
            id_name_icon_Border.Child = id_name_icon;

            //change the id_name_icon properties
            id_name_icon.Width = this.Width / 2;
            id_name_icon.VerticalAlignment = VerticalAlignment.Stretch;
            id_name_icon.Orientation = Orientation.Vertical;

            id_name = new TextBlock();
            //set the id_name as the children of the id_name_icon
            id_name_icon.Children.Add(id_name);

            //change the id_name properties
            id_name.Foreground = Brushes.Black;
            id_name.Margin = Thickness.Parse("10");
            id_name.Text = $"#{id}\n{name}";

            this.PointerPressed += (sender, e) =>
            {
                id_name.Text = id_name.Text + "\ncliked";
            };
        }
    }
}