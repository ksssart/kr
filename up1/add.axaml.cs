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

public partial class add : Window
{
    private List<sotrudnik> Sssotr;
    private string connStr = "server=localhost;database=sed_up;port=3306;User Id=root;password=кщще";
    private MySqlConnection conn;
    private sotrudnik _Sotr;
    
    public add(sotrudnik sssotr, List<sotrudnik> _sotr)
    {
        InitializeComponent();
        _Sotr = sssotr;
        this.DataContext = _Sotr;
        Sssotr = _sotr;
    }
    
    private void Save_OnClick(object? sender, RoutedEventArgs e)
    {
        var zzz = Sssotr.FirstOrDefault(x => x.id == _Sotr.id);
        if (zzz == null)
        {
            try
            {
                conn = new MySqlConnection(connStr);
                conn.Open();
                string add = "INSERT INTO sotrudnik (id, surname, name, lastname, dolznost_id) VALUES (" + Convert.ToInt32(id.Text) + ", '" + surname.Text + "', '"+ name.Text + "', '"+ lastname.Text + "', " + Convert.ToInt32(dolznost_id.Text) + ");";
                MySqlCommand cmd = new MySqlCommand(add, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error" + exception);
            }
        }
        else
        {
            try
            {
                conn = new MySqlConnection(connStr);
                conn.Open();
                string upd = "UPDATE sotrudnik SET surname = '" + surname.Text + "', '"+ name.Text + "', '"+ lastname.Text + "', " + Convert.ToInt32(dolznost_id.Text) + " WHERE id = " + Convert.ToInt32(id.Text) + ";";
                MySqlCommand cmd = new MySqlCommand(upd, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception exception)
            {
                Console.Write("Error" + exception);
            }
        }
    }
    
    private void GoBack(object? sender, RoutedEventArgs e)
    {
        var adm = new admin();
        adm.Show();
        this.Hide();
    }

    
}