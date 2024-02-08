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
    public partial class IncomeExpenseCPage : Page
    {
        private IncomeAndExpense _incomeAndExpense;

        public IncomeExpenseCPage()
        {
            try
            {
                InitializeComponent();
                DataContext = _incomeAndExpense = new IncomeAndExpense();
            }
            catch (Exception ex)
            {
                NavigationService.Navigate(new ErrorReportPage(ex));
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DB.context.IncomeAndExpenses.Add(_incomeAndExpense);
                DB.context.SaveChanges();
                MessageBox.Show("Запись добавлена", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                NavigationService.Navigate(new ErrorReportPage(ex));
            }
        }

        private void IncomesTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Char.IsDigit(e.Text, 0)) return;
            e.Handled = true;
        }

        private void ExpenseTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Char.IsDigit(e.Text, 0)) return;
            e.Handled = true;
        }

        private void OperationDescriptionTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Char.IsLetter(e.Text, 0)) return;
            e.Handled = true;
        }
    }
}
