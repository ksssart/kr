using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
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

public partial class object_t : Window
{
    private List<objects> _ob;
    private string connStr = "server=localhost;database=sed_up;port=3306;User Id=root;password=кщще";
    private MySqlConnection conn;
    
    public object_t()
    {
        InitializeComponent();
        string table = "SELECT * FROM objects";
        ShowData(table);
    }
    public void ShowData(string sql)
    {
        _ob = new List<objects>();
        conn = new MySqlConnection(connStr);
        conn.Open();
        MySqlCommand command = new MySqlCommand(sql, conn);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var obb = new objects()
            {
                id = reader.GetInt32("id"),
                name = reader.GetString("name"),
                sotrudnik_id = reader.GetInt32("sotrudnik_id"),
                status_id = reader.GetInt32("status_id")
            };
            _ob.Add(obb);
        }
        conn.Close();
        ObjectsGrid.ItemsSource = _ob;
    }
    private void back(object? sender, RoutedEventArgs e)
    {
        var menu = new menu();
        menu.Show();
        this.Hide();
    }
}