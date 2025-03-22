using Avalonia.Controls;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Hello
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Загружаем данные из базы сразу после инициализации окна
            LoadUsersAsync();
        }

        // Асинхронный метод для загрузки пользователей
        private async Task LoadUsersAsync()
        {
            using var db = new AppDbContext();
            // Получаем список пользователей из базы данных
            var users = await db.Users.ToListAsync();
            // Устанавливаем полученный список как источник данных для ListBox
            UserListBox.ItemsSource = users;
        }
    }
}
