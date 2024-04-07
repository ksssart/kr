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
                number = reader.GetInt32("number"),
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
    
    private void DeleteData(object? sender, RoutedEventArgs e)
    {
        try
        {
            zakazsss zzzak = ZakazGrid.SelectedItem as zakazsss;
            if (zzzak == null)
            {
                return;
            }
            conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "DELETE FROM zakaz WHERE number = " + zzzak.number;
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            _zakaz.Remove(zzzak);
            ShowTable("SELECT id, number, client_id, object_id FROM zakaz;");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }

    private void ShowTable(string selectIdNumberClientIdObjectIdFromZakaz)
    {
        throw new NotImplementedException();
    }
}