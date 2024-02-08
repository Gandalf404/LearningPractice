using LearningPractice_App_.Models.Update;
using System;
using System.Collections.Generic;
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

namespace LearningPractice_App_.Pages
{
    /// <summary>
    /// Логика взаимодействия для UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        List<User> users = new List<User>();

        //Выгрузка пользователей в UsersListView.
        public UsersPage()
        {
            try
            {
                InitializeComponent();
                users = DB.context.Users.ToList();
                UsersListView.ItemsSource = users;
            }
            catch (Exception ex)
            {
                NavigationService.Navigate(new ErrorReportPage(ex));
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
                NavigationService.Navigate(new ErrorReportPage(ex));
            }
        }
    }
}
