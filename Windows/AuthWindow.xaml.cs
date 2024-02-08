using LearningPractice_IE_.Models.IE;
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
using System.Windows.Shapes;

namespace LearningPractice_IE_.Windows
{
    public partial class AuthWindow : Window
    {
        private IndividualEntrepreneur _individualEntrepreneur;
        private MainWindow _mainWindow;

        public AuthWindow()
        {
            InitializeComponent();
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _individualEntrepreneur = DB.context.IndividualEntrepreneurs.FirstOrDefault(c => c.EntrepreneurLogin == LoginTextBox.Text && c.EntrepreneurPassword == PasswordBox.Password);
                if (_individualEntrepreneur != null)
                {
                    _mainWindow = new MainWindow(_individualEntrepreneur);
                    _mainWindow.Show();
                    Close();
                }
                else
                {
                    throw new Exception("Неверный логин или пароль");
                }
            }
            catch when (String.IsNullOrWhiteSpace(LoginTextBox.Text) && String.IsNullOrWhiteSpace(PasswordBox.Password))
            {
                MessageBox.Show("Введите логин и пароль для того чтобы войти", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch when (String.IsNullOrWhiteSpace(LoginTextBox.Text))
            {
                MessageBox.Show("Введите логин", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch when (String.IsNullOrWhiteSpace(PasswordBox.Password))
            {
                MessageBox.Show("Введите пароль", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
