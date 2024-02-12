using Avalonia.Controls;
using Avalonia;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using MySql.Data.MySqlClient;
using System;
using Tmds.DBus.Protocol;

namespace up1;

public partial class autoriz : Window
{
    private void login(object? sender, RoutedEventArgs e)
    {
        if (password.Text == "1234") // Здесь можно задать правильный пароль
        {
            // Открыть вторую форму
            var adm = new menuAdmin();
            adm.Show();
            this.Hide();
        }
    }
    
    private void Back(object? sender, RoutedEventArgs e)
    {
        var main = new MainWindow();
        main.Show();
        this.Hide();
    }
    
    public autoriz()
    {
        InitializeComponent();
    }
}