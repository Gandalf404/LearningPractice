using LearningPractice.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LearningPractice.Pages
{
    /// <summary>
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        List<User> users = new List<User>();

        //Выгрузка пользователей в UsersListView.
        public UserPage()
        {
            try
            {
                InitializeComponent();
                users = DB.context.Users.ToList();
                UsersListView.ItemsSource = users;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //Выгрузка пользователей в UsersListView при срабатывании события Page_Loaded.
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                users = DB.context.Users.ToList();
                UsersListView.ItemsSource = users;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
