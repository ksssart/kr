using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace up1;

public partial class menuAdmin : Window
{
    
    
    public menuAdmin()
    {
        InitializeComponent();
    }
    
    private void Sotrudnik(object? sender, RoutedEventArgs e)
    {
        var sot = new admin();
        sot.Show();
        this.Hide();
    }
    private void back(object? sender, RoutedEventArgs e)
    {
        var main = new MainWindow();
        main.Show();
        this.Hide();
    }
    
    private void Client(object? sender, RoutedEventArgs e)
    {
        var ob = new client();
        ob.Show();
        this.Hide();
    }
    
    private void zakaz(object? sender, RoutedEventArgs e)
    {
        var ob = new zakaz();
        ob.Show();
        this.Hide();
    }
    
    
}