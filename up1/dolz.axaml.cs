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

public partial class dolz : Window
{
    private List<dolznost> _dol;
    private string connStr = "server=localhost;database=sed_up;port=3306;User Id=root;password=кщще";
    private MySqlConnection conn;
    
    public void ShowData(string sql)
    {
        _dol = new List<dolznost>();
        conn = new MySqlConnection(connStr);
        conn.Open();
        MySqlCommand command = new MySqlCommand(sql, conn);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var dddol = new dolznost()
            {
                id = reader.GetInt32("id"),
                name = reader.GetString("name"),
                zp = reader.GetString("zp"),
            };
            _dol.Add(dddol);
        }

        conn.Close();
        DolznostGrid.ItemsSource = _dol;
    }
    
    private void Back(object? sender, RoutedEventArgs e)
    {
        var adm = new admin();
        adm.Show();
        this.Hide();
    }
    
    public dolz()
    {
        InitializeComponent();
        string table = "SELECT * FROM dolznost";
        ShowData(table);
    }
}