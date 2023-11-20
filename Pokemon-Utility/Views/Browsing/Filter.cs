using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{
    public class Filter: ComboBox
    {
        string selectedItem = string.Empty;
        public Filter()
        {
            this.Width = this.Height = 40;
            
            this.Items.Add("water");
            this.Items.Add("electric");
            this.Items.Add("grass");
            this.Items.Add("ice");
            this.Items.Add("fighting");
            this.Items.Add("poison");
            this.Items.Add("ground");
            this.Items.Add("flying");
            this.Items.Add("psychic");
            this.Items.Add("bug");
            this.Items.Add("rock");
            this.Items.Add("ghost");
            this.Items.Add("dragon");
            this.Items.Add("dark");
            this.Items.Add("steel");
            this.Items.Add("fairy");

                // Handle the SelectionChanged event of the ComboBox
                this.SelectionChanged += (sender, args) =>
                {
                    if (args.Source is ComboBox cb)
                    {
                        if (cb.SelectedItem != null)
                        {
                            selectedItem = cb.SelectedItem.ToString();

                        }
                    }
                };
        
      
        }

    }

}
