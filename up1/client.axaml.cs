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

public partial class client : Window
{
    private List<clientsss> _cli;
    private string connStr = "server=localhost;database=sed_up;port=3306;User Id=root;password=кщще";
    private MySqlConnection conn;
    public client()
    {
        InitializeComponent();
        string table = "SELECT * FROM clients";
        ShowData(table);
        //FillDostList();
    }
    
    public void ShowData(string sql)
    {
        _cli = new List<clientsss>();
        conn = new MySqlConnection(connStr);
        conn.Open();
        MySqlCommand command = new MySqlCommand(sql, conn);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var cccli = new clientsss()
            {
                id = reader.GetInt32("id"),
                name = reader.GetString("name"),
                phone = reader.GetString("phone"),
            };
            _cli.Add(cccli);
        }

        conn.Close();
        ClientGrid.ItemsSource = _cli;
    }
    
    private void Search(object? sender, TextChangedEventArgs e)
    {
        var clie = _cli;
        clie = clie.Where(x => x.name.Contains(SearchName.Text)).ToList();
        ClientGrid.ItemsSource = clie;
    }
    
    private void Back(object? sender, RoutedEventArgs e)
    {
        var menuAdm= new menuAdmin();
        menuAdm.Show();
        this.Hide();
    }
}