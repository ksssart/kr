using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace up1;

public partial class menu : Window
{
    private void Objects(object? sender, RoutedEventArgs e)
    {
        var ob = new object_t();
        ob.Show();
        this.Hide();
    }
    private void Material(object? sender, RoutedEventArgs e)
    {
        var mat = new materialsss();
        mat.Show();
        this.Hide();
    }
    private void Zacups(object? sender, RoutedEventArgs e)
    {
        var zak = new zakup();
        zak.Show();
        this.Hide();
    }
    private void back(object? sender, RoutedEventArgs e)
    {
        var main = new MainWindow();
        main.Show();
        this.Hide();
    }
    
    public menu()
    {
        InitializeComponent();
    }
}