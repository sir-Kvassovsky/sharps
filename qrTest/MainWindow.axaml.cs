using Avalonia.Controls;

namespace qrTest;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainViewModel();  // Убедитесь, что DataContext установлен
    }
}