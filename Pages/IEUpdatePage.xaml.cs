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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LearningPractice_IE_.Pages
{
    public partial class IEUpdatePage : Page
    {
        private IndividualEntrepreneur _individualEntrepreneur;

        public IEUpdatePage(IndividualEntrepreneur individualEntrepreneur)
        {
            try
            {
                InitializeComponent();
                _individualEntrepreneur = individualEntrepreneur;
                DataContext = _individualEntrepreneur;
            }
            catch (Exception ex)
            {
                NavigationService.Navigate(new ErrorReportPage(ex));
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DB.context.SaveChanges();
                MessageBox.Show("Изменения сохранены", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                NavigationService.Navigate(new ErrorReportPage(ex));
            }
        }

        private void IESurnameTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Char.IsLetter(e.Text, 0)) return;
            e.Handled = true;
        }

        private void IENameTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Char.IsLetter(e.Text, 0)) return;
            e.Handled = true;
        }

        private void IEPatronymic_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Char.IsLetter(e.Text, 0)) return;
            e.Handled = true;
        }

        private void IEITNTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Char.IsDigit(e.Text, 0)) return;
            e.Handled = true;
        }

        private void IEAddressTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Char.IsLetter(e.Text, 0)) return;
            e.Handled = true;
        }

        private void IEAccountNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Char.IsDigit(e.Text, 0)) return;
            e.Handled = true;
        }

        private void IEAccountBankTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Char.IsLetter(e.Text, 0)) return;
            e.Handled = true;
        }
    }
}
