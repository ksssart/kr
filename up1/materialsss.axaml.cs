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
        FillDostList();
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
                price = reader.GetString("price"), 
                discount = reader.GetInt32("discount")
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
    
    
        private void Cmb_Dost(object? sender, SelectionChangedEventArgs e)
    {
        var ser = (ComboBox)sender;
        var currentSer = ser.SelectedItem as material;
        var filtrSer = _mat
            .Where(x => x.discount == currentSer.discount)
            .ToList();
        MatGrid.ItemsSource = filtrSer;
    }
    
    private void DiscountFilter(object? sender, SelectionChangedEventArgs e)
    {
        var discontComboBox = (ComboBox)sender;
        var selectedDiscount = discontComboBox.SelectedItem as string;
            
        int startDiscount = 0;
        int endDiscount = 0;
            
        if (selectedDiscount == "Все скидки")
        {
            MatGrid.ItemsSource = _mat;
        }
        else if (selectedDiscount == "От 0% до 5%")
        {
            startDiscount = 1;
            endDiscount = 5;
        }
        else if (selectedDiscount == "От 5% до 15%")
        {
            startDiscount = 5;
            endDiscount = 15;
        }
        else if (selectedDiscount == "От 15% до 30%")
        {
            startDiscount = 15;
            endDiscount = 30;
        }
        else if (selectedDiscount == "От 30% до 70%")
        {
            startDiscount = 30;
            endDiscount = 71;
        }
            
        if (startDiscount != 0 && endDiscount != 0)
        {
            var filteredUsers = _mat
                .Where(x => x.discount >= startDiscount && x.discount < endDiscount)
                .ToList();

            MatGrid.ItemsSource = filteredUsers;
        }
    }

    public void FillDostList()
    {
        _mat = new List<material>();
        conn = new MySqlConnection(connStr);
        conn.Open();
        MySqlCommand command = new MySqlCommand("select * from material", conn);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var currentSer = new material()
            {
                id = reader.GetInt32("id"),
                name = reader.GetString("name"),
                price = reader.GetString("price"),
                discount = reader.GetInt32("discount")

            };
            _mat.Add(currentSer);
        }

        conn.Close();

        var discontComboBox = this.Find<ComboBox>("DiscontComboBox");
        discontComboBox.ItemsSource = new List<string>
        {
            "Все скидки",
            "От 0% до 5%",
            "От 5% до 15%",
            "От 15% до 30%",
            "От 30% до 70%"
        };
    }
}