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

public partial class admin : Window
{
    //подключение к бд
    private List<sotrudnik> _sotr;
    private string connStr = "server=localhost;database=sed_up;port=3306;User Id=root;password=кщще";
    private MySqlConnection conn;
    
    public admin()
    {
        InitializeComponent();
        string table = "SELECT * FROM sotrudnik";
        ShowData(table);
        FillDostList();
    }

    public void ShowData(string sql)
    {
        _sotr = new List<sotrudnik>();
        conn = new MySqlConnection(connStr);
        conn.Open();
        MySqlCommand command = new MySqlCommand(sql, conn);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var sssotr = new sotrudnik()
            {
                id = reader.GetInt32("id"),
                surname = reader.GetString("surname"),
                name = reader.GetString("name"),
                lastname = reader.GetString("lastname"),
                dolznost_id = reader.GetInt32("dolznost_id"),
            };
            _sotr.Add(sssotr);
        }

        conn.Close();
        SotrudnikGrid.ItemsSource = _sotr;
    }
    private void Search(object? sender, TextChangedEventArgs e)
    {
        var stud = _sotr;
        stud = stud.Where(x => x.surname.Contains(SearchFio.Text)).ToList();
        SotrudnikGrid.ItemsSource = stud;
    }
    
    private void Cmb_Dost(object? sender, SelectionChangedEventArgs e)
    {
        var dol = (ComboBox)sender;
        var currentDol = dol.SelectedItem as sotrudnik;
        var filtrDol = _sotr
            .Where(x => x.dolznost_id == currentDol.dolznost_id)
            .ToList();
        SotrudnikGrid.ItemsSource = filtrDol;
    }
    
    public void FillDostList()
    {
        _sotr = new List<sotrudnik>();
        conn = new MySqlConnection(connStr);
        conn.Open();
        MySqlCommand command = new MySqlCommand("select * from sotrudnik", conn);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var currentDol = new sotrudnik()
            {
                id = reader.GetInt32("id"),
                surname = reader.GetString("surname"),
                name = reader.GetString("name"),
                lastname = reader.GetString("lastname"),
                dolznost_id = reader.GetInt32("dolznost_id"),
            };
            _sotr.Add(currentDol);
        }

        conn.Close();
        var dolcmb = this.Find<ComboBox>(name: "CmbDost");
        dolcmb.ItemsSource = _sotr;
    }
    
    private void AddData(object? sender, RoutedEventArgs e)
    {
        sotrudnik newSotr = new sotrudnik();
        up1.add add = new up1.add(newSotr, _sotr);
        add.Show();
        this.Hide();
    }
    
    private void EditData(object? sender, RoutedEventArgs e)
    {
        sotrudnik sssotr = SotrudnikGrid.SelectedItem as sotrudnik;
        if (sssotr == null)
        {
            return;
        }

        up1.add add = new up1.add(sssotr, _sotr);
        add.Show();
        this.Hide();
    }

    private void dolz(object? sender, RoutedEventArgs e)
    {
        var dolz = new dolz();
        dolz.Show();
        this.Hide();
    }
    
    private void DeleteData(object? sender, RoutedEventArgs e)
    {
        try
        {
            sotrudnik sssotr = SotrudnikGrid.SelectedItem as sotrudnik;
            if (sssotr == null)
            {
                return;
            }
            conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "DELETE FROM sotrudnik WHERE id = " + sssotr.id;
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            _sotr.Remove(sssotr);
            ShowTable("SELECT id, surname, name, lastname, dolznost_id FROM sotrudnik;");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void ShowTable(string selectIdSurnameNameLastnameDolznostIdFromSotrudnik)
    {
        throw new NotImplementedException();
    }
    private void back(object? sender, RoutedEventArgs e)
    {
        var main = new MainWindow();
        main.Show();
        this.Hide();
    }
}
