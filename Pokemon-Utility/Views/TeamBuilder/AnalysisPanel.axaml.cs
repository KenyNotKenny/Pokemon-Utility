using System;
using System.Collections.Generic;
using Avalonia.Controls;
using Microsoft.IdentityModel.Tokens;

namespace Pokemon_Utility.Views.TeamBuilder;

public partial class AnalysisPanel : Panel
{
    private List<string> teamTypeList = new List<string>();

    private List<string> typeList = new List<string>
    {
        "normal", "fire", "water", "electric", "grass", "ice", "fighting", "poison", "ground", "flying", "psychic",
        "bug", "rock", "ghost", "dragon", "dark", "steel", "fairy"
    };
    private List<int> teamTypeNumList = new List<int> {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    private List<int> coefficientlist = new List<int> {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

public AnalysisPanel(List<PokemonInfoTeam> pokemonList)
    {
        InitializeComponent();
        var testString = String.Empty;
        foreach (var pokemon in pokemonList)
        {
            teamTypeList.Add(pokemon.Type1);
            if (!pokemon.Type2.IsNullOrEmpty())
            {
                teamTypeList.Add(pokemon.Type2);

            }
        }
        foreach (var type in teamTypeList)
        {
            teamTypeNumList[typeList.IndexOf(type)]++;
        }

        foreach (var num in teamTypeNumList)
        {
            testString += num.ToString();
        }

        TestTextBlock.Text = testString;
    }


    private void setCoeffiecent(string type)
    {
        switch (type)
        {
            case "normal":
            {
                coefficientlist[typeList.IndexOf("fighting")]--;
                coefficientlist[typeList.IndexOf("ghost")]++;
            }
                break;
            case "fire":
            {
                coefficientlist[typeList.IndexOf("fire")]++;
                coefficientlist[typeList.IndexOf("water")]--;
                coefficientlist[typeList.IndexOf("grass")]++;
                coefficientlist[typeList.IndexOf("ice")]++;
                coefficientlist[typeList.IndexOf("ground")]--;
                coefficientlist[typeList.IndexOf("steel")]++;
                coefficientlist[typeList.IndexOf("fairy")]++;
            }
                break;
            case "water":
            {
                coefficientlist[typeList.IndexOf("fire")]++;
                coefficientlist[typeList.IndexOf("water")]++;
                coefficientlist[typeList.IndexOf("electric")]--;
                coefficientlist[typeList.IndexOf("grass")]--;
                coefficientlist[typeList.IndexOf("ice")]++;
                coefficientlist[typeList.IndexOf("steel")]++;
            }
                break;
            case "electric":
            {
                coefficientlist[typeList.IndexOf("electric")]++;
                coefficientlist[typeList.IndexOf("ground")]--;
                coefficientlist[typeList.IndexOf("flying")]++;
                coefficientlist[typeList.IndexOf("steel")]--;

            }
                break;
            case "grass":
            {
                coefficientlist[typeList.IndexOf("fire")]--;
                coefficientlist[typeList.IndexOf("water")]++;
                coefficientlist[typeList.IndexOf("electric")]++;
                coefficientlist[typeList.IndexOf("grass")]++;
                coefficientlist[typeList.IndexOf("ice")]--;
                coefficientlist[typeList.IndexOf("poison")]--;
                coefficientlist[typeList.IndexOf("ground")]++;
                coefficientlist[typeList.IndexOf("flying")]--;
                coefficientlist[typeList.IndexOf("bug")]--;
                
            }
                break;
            case "ice":
            {
                coefficientlist[typeList.IndexOf("fire")]--;
                coefficientlist[typeList.IndexOf("ice")]++;
                coefficientlist[typeList.IndexOf("fighting")]--;
                coefficientlist[typeList.IndexOf("rock")]--;
                coefficientlist[typeList.IndexOf("steel")]--;
                
            }
                break;
            case "fighting":
            {
                coefficientlist[typeList.IndexOf("flying")]--;
                coefficientlist[typeList.IndexOf("psychic")]--;
                coefficientlist[typeList.IndexOf("rock")]++;
                coefficientlist[typeList.IndexOf("bug")]++;
                coefficientlist[typeList.IndexOf("dark")]++;
                coefficientlist[typeList.IndexOf("fairy")]--;

            }
                break;
            case "poison":
            {
                coefficientlist[typeList.IndexOf("grass")]++;
                coefficientlist[typeList.IndexOf("fighting")]++;
                coefficientlist[typeList.IndexOf("poison")]++;
                coefficientlist[typeList.IndexOf("ground")]--;
                coefficientlist[typeList.IndexOf("psychic")]--;
                coefficientlist[typeList.IndexOf("bug")]++;
                coefficientlist[typeList.IndexOf("fairy")]++;

            }
                break;
            case "ground":
            {
                coefficientlist[typeList.IndexOf("water")]--;
                coefficientlist[typeList.IndexOf("electric")]++;
                coefficientlist[typeList.IndexOf("grass")]--;
                coefficientlist[typeList.IndexOf("ice")]--;
                coefficientlist[typeList.IndexOf("poison")]++;
                coefficientlist[typeList.IndexOf("rock")]++;

            }
                break;
            case "flying":
            {
                coefficientlist[typeList.IndexOf("electric")]--;
                coefficientlist[typeList.IndexOf("grass")]++;
                coefficientlist[typeList.IndexOf("ice")]--;
                coefficientlist[typeList.IndexOf("fighting")]++;
                coefficientlist[typeList.IndexOf("ground")]++;
                coefficientlist[typeList.IndexOf("bug")]++;
                coefficientlist[typeList.IndexOf("rock")]--;

            }
                break;
            case "psychic":
            {
                coefficientlist[typeList.IndexOf("fighting")]++;
                coefficientlist[typeList.IndexOf("psychic")]++;
                coefficientlist[typeList.IndexOf("bug")]--;
                coefficientlist[typeList.IndexOf("ghost")]--;
                coefficientlist[typeList.IndexOf("dark")]--;

            }
                break;
            case "bug":
            {
                coefficientlist[typeList.IndexOf("fire")]--;
                coefficientlist[typeList.IndexOf("grass")]++;
                coefficientlist[typeList.IndexOf("fighting")]++;
                coefficientlist[typeList.IndexOf("ground")]++;
                coefficientlist[typeList.IndexOf("flying")]--;
                coefficientlist[typeList.IndexOf("rock")]--;

            }
                break;
            case "rock":
            {
                coefficientlist[typeList.IndexOf("normal")]++;
                coefficientlist[typeList.IndexOf("fire")]++;
                coefficientlist[typeList.IndexOf("water")]--;
                coefficientlist[typeList.IndexOf("grass")]--;
                coefficientlist[typeList.IndexOf("fighting")]--;
                coefficientlist[typeList.IndexOf("poison")]++;
                coefficientlist[typeList.IndexOf("flying")]--;
                coefficientlist[typeList.IndexOf("steel")]--;

            }
                break;
            case "ghost":
            {
                coefficientlist[typeList.IndexOf("normal")]++;
                coefficientlist[typeList.IndexOf("fighting")]++;
                coefficientlist[typeList.IndexOf("poison")]++;
                coefficientlist[typeList.IndexOf("bug")]++;
                coefficientlist[typeList.IndexOf("ghost")]--;
                coefficientlist[typeList.IndexOf("dark")]--;
                
            }
                break;
            case "dragon":
            {
                coefficientlist[typeList.IndexOf("fire")]++;
                coefficientlist[typeList.IndexOf("water")]++;
                coefficientlist[typeList.IndexOf("electric")]++;
                coefficientlist[typeList.IndexOf("grass")]++;
                coefficientlist[typeList.IndexOf("ice")]--;
                coefficientlist[typeList.IndexOf("dragon")]--;
                coefficientlist[typeList.IndexOf("fairy")]--;

            }
                break;
            case "dark":
            {
                coefficientlist[typeList.IndexOf("fighting")]--;
                coefficientlist[typeList.IndexOf("psychic")]++;
                coefficientlist[typeList.IndexOf("bug")]++;
                coefficientlist[typeList.IndexOf("ghost")]++;
                coefficientlist[typeList.IndexOf("dark")]++;
                coefficientlist[typeList.IndexOf("fairy")]--;

            }
                break;
            case "steel":
            {
                coefficientlist[typeList.IndexOf("steel")]++;
                coefficientlist[typeList.IndexOf("fire")]--;
                coefficientlist[typeList.IndexOf("grass")]++;
                coefficientlist[typeList.IndexOf("ice")]++;
                coefficientlist[typeList.IndexOf("fighting")]--;
                coefficientlist[typeList.IndexOf("poison")]++;
                coefficientlist[typeList.IndexOf("ground")]--;
                coefficientlist[typeList.IndexOf("flying")]++;
                coefficientlist[typeList.IndexOf("psychic")]++;
                coefficientlist[typeList.IndexOf("bug")]++;
                coefficientlist[typeList.IndexOf("rock")]++;
                coefficientlist[typeList.IndexOf("dragon")]++;
                coefficientlist[typeList.IndexOf("steel")]++;
                coefficientlist[typeList.IndexOf("fairy")]++;

            }
                break;
            case "fairy":
            {
                coefficientlist[typeList.IndexOf("fighting")]++;
                coefficientlist[typeList.IndexOf("poison")]--;
                coefficientlist[typeList.IndexOf("bug")]++;
                coefficientlist[typeList.IndexOf("dragon")]++;
                coefficientlist[typeList.IndexOf("dark")]++;
                coefficientlist[typeList.IndexOf("steel")]--;

            }
                break;
            
            
        }
    }
}