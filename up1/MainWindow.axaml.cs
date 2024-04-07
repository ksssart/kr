using Avalonia.Controls;
using Avalonia.Interactivity;

namespace up1;

public partial class MainWindow : Window
{
    private void Autoriz(object? sender, RoutedEventArgs e)
    {
            var auto = new autoriz();
            auto.Show();
            this.Hide();
    }
    
    private void See(object? sender, RoutedEventArgs e)
    {
        var men = new menu();
        men.Show();
        this.Hide();
    }
    
    public MainWindow()
    {
        InitializeComponent();
    }
}
//<Image Source="D:/apps/pic/b1.png" Width="510" Height="230"/>