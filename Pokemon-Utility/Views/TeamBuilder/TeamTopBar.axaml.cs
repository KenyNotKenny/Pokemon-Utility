using System.Collections.Generic;
using Avalonia.Controls;

namespace Pokemon_Utility.Views.TeamBuilder;

public partial class TeamTopBar : Panel
{
    // Cường
    // Ông tạo 1 tab bar bên trong cái Panel này
    // Cái listbox ông để public dể tui gán event
    // Lấy tên từ cái contructor thứ 2 để hiện thị cho mỗi tab
    // nhớ trang trí giống cái hình tui vẽ
    public TeamTopBar()
    {
        InitializeComponent();
    }
    public TeamTopBar( List<string> teamName) : this()
    {
        //TO-DO
    }
}