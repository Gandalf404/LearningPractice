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
    public partial class IEPage : Page
    {
        private List<IndividualEntrepreneur> _individualEntrepreneurs;

        public IEPage()
        {
            try
            {
                InitializeComponent();
                _individualEntrepreneurs = DB.context.IndividualEntrepreneurs.ToList();
                IEDataGrid.ItemsSource = _individualEntrepreneurs;
            }
            catch (Exception ex)
            {
                NavigationService.Navigate(new ErrorReportPage(ex));
            }
        }

        private void IEUpdateMenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IndividualEntrepreneur currentIndividualEntrepreneur = (IndividualEntrepreneur)IEDataGrid.SelectedItem;
                if (currentIndividualEntrepreneur != null)
                {
                    NavigationService.Navigate(new IEUpdatePage(currentIndividualEntrepreneur));
                }
                else
                {
                    MessageBox.Show("Выберите ИП для изменения", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                NavigationService.Navigate(new ErrorReportPage(ex));
            }
        }
    }
}
