using LearningPractice_IE_.Models.IE;
using LearningPractice_IE_.Pages;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LearningPractice_IE_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IndividualEntrepreneur _individualEntrepreneur;

        public MainWindow(IndividualEntrepreneur individualEntrepreneur)
        {
            try
            {
                InitializeComponent();
                _individualEntrepreneur = individualEntrepreneur;
                MainFrame.Navigate(new IEPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void IEButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainFrame.Navigate(new IEPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void IncomeExpensesButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DB.context.IndividualEntrepreneurs.Where(c => c.EntrepreneurId == _individualEntrepreneur.EntrepreneurId) != null)
                {
                    MainFrame.Navigate(new IncomeExpensesPage());
                }
                else
                {
                    MessageBox.Show("Для того чтобы просматривать доходы/расходы необходимо зарегистрировать книгу учета доходов и расходов, нажав на кнопку \"Зарегистрировать\"", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}