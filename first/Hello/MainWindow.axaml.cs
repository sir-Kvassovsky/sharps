using Avalonia.Controls;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Hello;
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        LoadUsersAsync(); // Fire-and-forget with error handling
    }

    private async void LoadUsersAsync() // Changed to async void
    {
        try
        {
            using var db = new AppDbContext();
            UserListBox.ItemsSource = await db.Users.ToListAsync();
        }
        catch (Exception ex)
        {
            // Handle database errors
            Console.WriteLine($"Error loading users: {ex.Message}");
        }
    }
}