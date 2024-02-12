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

public partial class zakaz : Window
{
    private List<zakazsss> _zakaz;
    private string connStr = "server=localhost;database=sed_up;port=3306;User Id=root;password=кщще";
    private MySqlConnection conn;
    
    public zakaz()
    {
        InitializeComponent();
        string table = "SELECT * FROM zakaz";
        ShowData(table);
    }
    public void ShowData(string sql)
    {
        _zakaz = new List<zakazsss>();
        conn = new MySqlConnection(connStr);
        conn.Open();
        MySqlCommand command = new MySqlCommand(sql, conn);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var zzzak = new zakazsss()
            {
                id = reader.GetInt32("id"),
                client_id = reader.GetInt32("client_id"),
                object_id = reader.GetInt32("object_id")
            };
            _zakaz.Add(zzzak);
        }
        conn.Close();
        ZakazGrid.ItemsSource = _zakaz;
    }
    
    private void Back(object? sender, RoutedEventArgs e)
    {
        var menuAdm= new menuAdmin();
        menuAdm.Show();
        this.Hide();
    }
}