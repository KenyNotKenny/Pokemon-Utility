using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{
    internal class Filter
{
        //event when user choose item in comboBox  
        string GetSelectedItemString(ComboBox comboBox)
        {
            string selectedItem = string.Empty;

            // Handle the SelectionChanged event of the ComboBox
            comboBox.SelectionChanged += (sender, args) =>
            {
                if (args.Source is ComboBox cb)
                {
                    if (cb.SelectedItem != null)
                    {
                        selectedItem = cb.SelectedItem.ToString();

                    }
                }
            };

            return selectedItem;
        }
    }
}
