using LearningPractice_IE_.Models.IE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using Excel = Microsoft.Office.Interop.Excel;

namespace LearningPractice_IE_.Pages
{
    public partial class IncomeExpensesPage : Page
    {
        private List<IncomeAndExpense> _incomeAndExpenses;
        private Excel.Application _application;
        private Excel.Worksheet _worksheet;
        private Excel.Range _range;
        private TextBlock _textBlock;

        public IncomeExpensesPage()
        {
            try
            {
                InitializeComponent();
                _incomeAndExpenses = DB.context.IncomeAndExpenses.ToList();
                IncomeExpensesDataGrid.ItemsSource = _incomeAndExpenses;
            }
            catch (Exception ex)
            {
                NavigationService.Navigate(new ErrorReportPage(ex));
            }
        }

        private void AddIncomeExpenseButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigationService.Navigate(new IncomeExpenseCPage());
            }
            catch (Exception ex)
            {
                NavigationService.Navigate(new ErrorReportPage(ex));
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                _incomeAndExpenses = DB.context.IncomeAndExpenses.ToList();
                IncomeExpensesDataGrid.ItemsSource = _incomeAndExpenses;
            }
            catch (Exception ex)
            {
                NavigationService.Navigate(new ErrorReportPage(ex));
            }
        }

        private void PrintIncomeAndExpensesButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _application = new Excel.Application();
                _application.Visible = true;
                Excel.Workbook workbook = _application.Workbooks.Add(System.Reflection.Missing.Value);
                _worksheet = (Excel.Worksheet)_application.ActiveSheet;
                for (int j = 0; j < IncomeExpensesDataGrid.Columns.Count; j++)
                {
                    _range = (Excel.Range)_worksheet.Cells[1, j + 1];
                    _range.Value2 = IncomeExpensesDataGrid.Columns[j].Header;
                }
                for (int i = 0; i < IncomeExpensesDataGrid.Items.Count; i++)
                {
                    for (int j = 0; j < IncomeExpensesDataGrid.Columns.Count; j++)
                    {
                        _textBlock = (TextBlock)IncomeExpensesDataGrid.Columns[j].GetCellContent(IncomeExpensesDataGrid.Items[i]);
                        _range = (Excel.Range)_worksheet.Cells[i + 2, j + 1];
                        _range.Value2 = _textBlock.Text;
                    }
                }
            }
            catch (Exception ex)
            {
                NavigationService.Navigate(new ErrorReportPage(ex));
            }
        }
    }
}
