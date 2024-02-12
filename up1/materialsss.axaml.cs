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

public partial class materialsss : Window
{
    private List<material> _mat;
    private string connStr = "server=localhost;database=sed_up;port=3306;User Id=root;password=кщще";
    private MySqlConnection conn;
    public materialsss()
    {   
        InitializeComponent();
        string table = "SELECT * FROM material";
        ShowData(table);
    }
    
    public void ShowData(string sql)
    {
        _mat = new List<material>();
        conn = new MySqlConnection(connStr);
        conn.Open();
        MySqlCommand command = new MySqlCommand(sql, conn);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var mmmat = new material()
            {
                id = reader.GetInt32("id"),
                name = reader.GetString("name"),
                price = reader.GetString("price")  
            };
            _mat.Add(mmmat);
        }
        conn.Close();
        MatGrid.ItemsSource = _mat;
    }
    private void back(object? sender, RoutedEventArgs e)
    {
        var menu = new menu();
        menu.Show();
        this.Hide();
    }
}