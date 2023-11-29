using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Media;
using System;
using System.Linq;
using System.Reflection.Metadata;

namespace Pokemon_Utility.Views.Browsing
{
    public class SortingButton : Panel
    {
        Button sorter;
        string content;

        public string Content
        {
            get { return content; }
        }

        // Constructor
        public SortingButton()
        {
            //change the SortingButton class properties
            this.Height = 60;
            this.Width = 150;

            sorter = new Button();
            sorter.FontSize = 20;
            //set the sorter as the children of the SortingButton class
            this.Children.Add(sorter);

            //change the sorter properties
            content = "Sort";
            sorter.Content = content;
            sorter.VerticalContentAlignment = VerticalAlignment.Center;
            sorter.HorizontalContentAlignment = HorizontalAlignment.Center;
            sorter.VerticalAlignment = VerticalAlignment.Center;
            sorter.Height = this.Height;
            sorter.Width = this.Width;
            sorter.CornerRadius = new CornerRadius(30);
            sorter.Foreground = new SolidColorBrush(Colors.White);
            sorter.Background = Design.Color.FgBlue;
            sorter.BorderBrush = new SolidColorBrush(Colors.White);
            sorter.BorderThickness = new Thickness(1);

            // Subscribe to the button click event
            sorter.Click += ClickHandler;
        }

        private bool sortById = true;

        public void ClickHandler(object sender, RoutedEventArgs args)
        {
            if (sender is Button)
            {
                sortById = !sortById;
                if (sortById == false)
                {
                    content = "Sort by: Name";
                    sorter.Content = content;
                }
                else
                {
                    content = "Sort by: ID";
                    sorter.Content = content;
                }
            }
        }

        // Method to sort the 2D array by name
        public static string[,] SortingByName(string[,] pokemonList)
        {
            return SortArray(pokemonList, 1); // Sort by name (index 1)
        }

        // Method to sort the 2D array by ID
        public static string[,] SortingById(string[,] pokemonList)
        {
            return SortArray(pokemonList, 0); // Sort by ID (index 0)
        }

        // Helper method to sort the array by a specified column index
        private static string[,] SortArray(string[,] pokemonList, int columnIndex)
        {
            // Get the length of the second dimension 
            int numColumns = pokemonList.GetLength(1);

            // Sort the array by the values 
            var sortedList = Enumerable.Range(0, pokemonList.GetLength(0))
                .Select(i => new
                {
                    Id = pokemonList[i, 0],
                    Name = pokemonList[i, 1],
                    Type1 = pokemonList[i, 2],
                    Type2 = pokemonList[i, 3]
                })
                .OrderBy(item => columnIndex == 0 ? item.Id : item.Name, StringComparer.OrdinalIgnoreCase)
                .ToArray();

            // Update the original array with the sorted values
            for (int i = 0; i < sortedList.Length; i++)
            {
                pokemonList[i, 0] = sortedList[i].Id;
                pokemonList[i, 1] = sortedList[i].Name;
                pokemonList[i, 2] = sortedList[i].Type1;
                pokemonList[i, 3] = sortedList[i].Type2;
            }

            return pokemonList;
        }
    }
}