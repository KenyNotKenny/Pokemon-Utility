using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media;

namespace PokemonUtility.Views.Browsing
{
	public class DataCard
	{
		public DataCard()
		{
		}

        //method to create the DataCard
        public Border SetDataCard(string Type, int id, string name)
        {
            Border dataCard_Border = new Border();

            //change the datacard properties
            dataCard_Border.Margin = Thickness.Parse("30");
            dataCard_Border.CornerRadius = CornerRadius.Parse("5");
            dataCard_Border.Width = 700 / 3;
            dataCard_Border.Height = 150;
            switch (Type)
            {
               //the color according to the type of pokemon
               case "fire":
                    dataCard_Border.Background = Brushes.Red;
                    break;
               case "ater":
                    dataCard_Border.Background = Brushes.Blue;
                    break;
               case "electric":
                    dataCard_Border.Background = Brushes.Yellow;
                    break;
               case "grass":
                    dataCard_Border.Background = Brushes.LightGreen;
                    break;
               case "ice":
                    dataCard_Border.Background = Brushes.PowderBlue;
                    break;
               case "lighting":
                    dataCard_Border.Background = Brushes.Brown;
                    break;
               case "poison":
                    dataCard_Border.Background = Brushes.Purple;
                    break;
               case "ground":
                    dataCard_Border.Background = Brushes.LightGoldenrodYellow;
                    break;
               case "flying":
                    dataCard_Border.Background = Brushes.Lavender;
                    break;
               case "psychic":
                    dataCard_Border.Background = Brushes.DeepPink;
                    break;
               case "bug":
                    dataCard_Border.Background = Brushes.DarkOliveGreen;
                    break;
               case "rock":
                    dataCard_Border.Background = Brushes.AntiqueWhite;
                    break;
               case "ghost":
                    dataCard_Border.Background = Brushes.DarkMagenta;
                    break;
               case "fragon":
                    dataCard_Border.Background = Brushes.MediumPurple;
                    break;
               case "dark":
                    dataCard_Border.Background = Brushes.SaddleBrown;
                    break;
               case "steel":
                    dataCard_Border.Background = Brushes.LightGray;
                    break;
               case "fairy":
                    dataCard_Border.Background = Brushes.Pink;
                    break;
               default:
                    dataCard_Border.Background = Brushes.Gray;
                    break;
            }
            StackPanel dataCard = new StackPanel();
            //set the dataCard as the children of the dataCard_Border
            dataCard_Border.Child = dataCard;

            //change the dataCard properties
            dataCard.Orientation = Orientation.Horizontal;

            StackPanel pic = new StackPanel();
            //set the pic as the children of the dataCard
            dataCard.Children.Add(pic);

            //change the pic properties
            pic.Width = dataCard_Border.Width / 2;
            pic.VerticalAlignment = VerticalAlignment.Stretch;

            Border id_name_icon_Border = new Border();
            //set the id_name_icon_Border as the children of the dataCard
            dataCard.Children.Add(id_name_icon_Border);

            //change the id_name_icon_border properties
            id_name_icon_Border.Background = Brushes.WhiteSmoke;
            id_name_icon_Border.CornerRadius = new CornerRadius(0, 5, 5, 0);

            StackPanel id_name_icon = new StackPanel();
            //set the id_name_icon as the children of the id_name_icon_Border
            id_name_icon_Border.Child = id_name_icon;

            //change the id_name_icon properties
            id_name_icon.Width = dataCard_Border.Width / 2;
            id_name_icon.VerticalAlignment = VerticalAlignment.Stretch;
            id_name_icon.Orientation = Orientation.Vertical;

            TextBlock id_name = new TextBlock();
            //set the id_name as the children of the id_name_icon
            id_name_icon.Children.Add(id_name);

            //change the id_name properties
            id_name.Foreground = Brushes.Black;
            id_name.Margin = Thickness.Parse("10");
            id_name.Text = $"#{id}\n{name}";

            return dataCard_Border;
        }
    }

}

