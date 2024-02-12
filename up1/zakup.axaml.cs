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

public partial class zakup : Window
{
    private List<zacup> _zak;
    private string connStr = "server=localhost;database=sed_up;port=3306;User Id=root;password=кщще";
    private MySqlConnection conn;
    
    public zakup()
    {
        InitializeComponent();
        string table = "SELECT * FROM zacup";
        ShowData(table);
       
    }
    

    public void ShowData(string sql)
    {
        _zak = new List<zacup>();
        conn = new MySqlConnection(connStr);
        conn.Open();
        MySqlCommand command = new MySqlCommand(sql, conn);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var zzzak = new zacup()
            {
                id = reader.GetInt32("id"),
                object_id = reader.GetInt32("object_id"),
                material_id = reader.GetInt32("material_id"),  
            };
            _zak.Add(zzzak);
        }
        conn.Close();
        ZakupGrid.ItemsSource = _zak;
        
        
    }
    
    private void back(object? sender, RoutedEventArgs e)
    {
        var menu = new menu();
        menu.Show();
        this.Hide();
    }
}