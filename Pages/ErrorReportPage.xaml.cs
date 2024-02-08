using LearningPractice_Launcher_.Models.ErrorReportDep;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
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

namespace LearningPractice_Launcher_.Pages
{
    /// <summary>
    /// Логика взаимодействия для ErrorReportPage.xaml
    /// </summary>
    public partial class ErrorReportPage : Page
    {
        private Exception _exception;
        private Error _error;

        public ErrorReportPage(Exception exception)
        {
            InitializeComponent();
            _exception = exception;
        }

        private void SendReportButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(EmailTextBox.Text))
                {
                    if (!ValidateEmail(EmailTextBox.Text))
                    {
                        MessageBox.Show("Введенные данные не соответствуют формату эл.почты", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    _error = new Error();
                    if (_exception.StackTrace != null)
                    {
                        _error.ErrorDescription = $"{ErrorDescriptionTextBox.Text} {_exception.StackTrace} {_exception.Source}";
                        _error.ErrorStatus = "Не начато";
                    }
                    else
                    {
                        _error.ErrorDescription = $"{ErrorDescriptionTextBox.Text}";
                        _error.ErrorStatus = "Не начато";
                    }
                    ErrorReportDepDB.context.Errors.Add(_error);
                    ErrorReportDepDB.context.SaveChanges();
                    Feedback();
                    Process.GetCurrentProcess().Kill();
                }
                else
                {
                    MessageBox.Show("Введите адрес эл.почты", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Во время отправки отчета произошла ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelSendReportButton_Click(object sender, RoutedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private bool ValidateEmail(string email)
        {
            return Regex.IsMatch(email, "[a-zA-Z0-9._%+-]+@[a-zA-z.]+[a-zA-Z]");
        }
         
        private void Feedback()
        {
            using (SmtpClient smtpClient = new SmtpClient("smtp.mail.ru", 587))
            {
                smtpClient.Credentials = new NetworkCredential("levchuk.2004@internet.ru", "XRsmLzZbeEwVyY7Qi7eB");
                smtpClient.EnableSsl = true;
                using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress("levchuk.2004@internet.ru");
                    mailMessage.To.Add(EmailTextBox.Text);
                    mailMessage.Subject = "Доброго времени суток. Ваше ошибка успешно отправлена в центр решения ошибок.";
                    smtpClient.Send(mailMessage);
                }
            }
            MessageBox.Show("Отчет об ошибке был успешно отправлен ! \nПроверяйте вашу эл.почту в течение дня", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}