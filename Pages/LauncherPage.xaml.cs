using LearningPractice_Launcher_.Models.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
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
using static LearningPractice_Launcher_.LauncherHandler;

namespace LearningPractice_Launcher_.Pages
{
    /// <summary>
    /// Логика взаимодействия для LauncherPage.xaml
    /// </summary>
    public partial class LauncherPage : Page
    {
        private string _appZip;
        private string _appExe;
        private string _appUpdates;

        private LauncherStatus _launcherStatus;

        public LauncherPage()
        {
            InitializeComponent();

            _appZip = @$"C:\Users\{Environment.UserName}\Documents\Updates";
            _appUpdates = @$"C:\Users\{Environment.UserName}\Documents\Updates";
            _appExe = Path.Combine(_appUpdates, @"LearningPractice-app\bin\Debug\net6.0-windows\LearningPractice(App).exe");
        }

        private void InstallAppFiles(bool isUpdating)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    if (isUpdating)
                    {
                        _launcherStatus = LauncherStatus.DownloadingUpdate;
                        Mouse.OverrideCursor = Cursors.Wait;
                    }
                    else
                    {
                        _launcherStatus = LauncherStatus.DownloadingApp;
                        Mouse.OverrideCursor = Cursors.Wait;
                    }

                    webClient.DownloadFileAsync(new Uri($"https://github.com/Gandalf404/LearningPractice/archive/refs/tags/{((Models.Application.Version)VersionComboBox.SelectedItem).Version1}.zip"),
                        Path.Combine(_appZip, $"LearningPractice-{((Models.Application.Version)VersionComboBox.SelectedItem).Version1}.zip"),
                        ((Models.Application.Version)VersionComboBox.SelectedItem).Version1);
                    webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadCompletedCallback);
                }
            }
            catch (Exception ex)
            {
                NavigationService.Navigate(new ErrorReportPage(ex));
            }
        }

        private void DownloadCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                if (IsUpdateExtractedCheckBox.IsChecked == true)
                {
                    ZipFile.ExtractToDirectory(Path.Combine(_appZip, $"LearningPractice-{((Models.Application.Version)VersionComboBox.SelectedItem).Version1}.zip"), _appUpdates);
                    File.Delete(Path.Combine(_appZip, $"LearningPractice-{((Models.Application.Version)VersionComboBox.SelectedItem).Version1}.zip"));
                }
                _launcherStatus = LauncherStatus.Ready;
                Mouse.OverrideCursor = Cursors.Arrow;
                MessageBox.Show("Приложение установлено", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                StartAppButton.Content = "Запустить приложение";
                UpdateAppButton.Visibility = Visibility.Visible;
                IsUpdateExtractedCheckBox.IsChecked = false;
            }
            catch (Exception ex)
            {
                _launcherStatus = LauncherStatus.Failed;
                NavigationService.Navigate(new ErrorReportPage(ex));
            }
        }

        private void StartAppButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (((Models.Application.Version)VersionComboBox.SelectedItem).Version1 != "Выберите версию")
                {
                    if (File.Exists(Path.Combine(_appUpdates, @$"LearningPractice-{((Models.Application.Version)VersionComboBox.SelectedItem).Version1}\bin\Debug\net6.0-windows\LearningPractice(App).exe"))
                        && _launcherStatus == LauncherStatus.Ready)
                    {
                        Process.Start(new ProcessStartInfo(Path.Combine(_appUpdates, @$"LearningPractice-{((Models.Application.Version)VersionComboBox.SelectedItem).Version1}\bin\Debug\net6.0-windows\LearningPractice(App).exe")));
                        Process.GetCurrentProcess().Kill();
                    }
                    else if (File.Exists(Path.Combine(_appUpdates, @$"LearningPractice-{((Models.Application.Version)VersionComboBox.SelectedItem).Version1}\bin\Debug\net6.0-windows\LearningPractice(IE).exe"))
                        && _launcherStatus == LauncherStatus.Ready)
                    {
                        Process.Start(new ProcessStartInfo(Path.Combine(_appUpdates, @$"LearningPractice-{((Models.Application.Version)VersionComboBox.SelectedItem).Version1}\bin\Debug\net6.0-windows\LearningPractice(IE).exe")));
                        Process.GetCurrentProcess().Kill();
                    }

                    if (File.Exists(Path.Combine(_appUpdates, @$"LearningPractice-{((Models.Application.Version)VersionComboBox.SelectedItem).Version1}.zip")))
                    {
                        ZipFile.ExtractToDirectory(Path.Combine(_appUpdates, @$"LearningPractice-{((Models.Application.Version)VersionComboBox.SelectedItem).Version1}.zip"), _appUpdates);
                        File.Delete(@$"C:\Users\{Environment.UserName}\Documents\Updates\LearningPractice-{((Models.Application.Version)VersionComboBox.SelectedItem).Version1}.zip");
                        if (File.Exists(Path.Combine(_appUpdates, @$"LearningPractice-{((Models.Application.Version)VersionComboBox.SelectedItem).Version1}\bin\Debug\net6.0-windows\LearningPractice(App).exe"))
                            && _launcherStatus == LauncherStatus.Ready)
                        {
                            Process.Start(new ProcessStartInfo(Path.Combine(_appUpdates, @$"LearningPractice-{((Models.Application.Version)VersionComboBox.SelectedItem).Version1}\bin\Debug\net6.0-windows\LearningPractice(App).exe")));
                            Process.GetCurrentProcess().Kill();
                        }
                        else if (File.Exists(Path.Combine(_appUpdates, @$"LearningPractice-{((Models.Application.Version)VersionComboBox.SelectedItem).Version1}\bin\Debug\net6.0-windows\LearningPractice(IE).exe"))
                            && _launcherStatus == LauncherStatus.Ready)
                        {
                            Process.Start(new ProcessStartInfo(Path.Combine(_appUpdates, @$"LearningPractice-{((Models.Application.Version)VersionComboBox.SelectedItem).Version1}\bin\Debug\net6.0-windows\LearningPractice(IE).exe")));
                            Process.GetCurrentProcess().Kill();
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("Приложение не установлено. Установить ?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                        {
                            InstallAppFiles(false);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Выберите версию которую желаете запустить/установить.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
            catch (Exception ex)
            {
                NavigationService.Navigate(new ErrorReportPage(ex));
            }
        }

        private void UpdateAppButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (((Models.Application.Version)VersionComboBox.SelectedItem).Version1 != "Выберите версию")
                {
                    if (File.Exists(Path.Combine(_appUpdates, @$"LearningPractice-{((Models.Application.Version)VersionComboBox.SelectedItem).Version1}\bin\Debug\net6.0-windows\LearningPractice(App).exe"))
                        && _launcherStatus == LauncherStatus.Ready)
                    {
                        if (MessageBox.Show("Данная версия уже установлена, Вы хотите её переустановить ?", "Информация", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                        {
                            Directory.Delete(Path.Combine(_appUpdates, @$"LearningPractice-{((Models.Application.Version)VersionComboBox.SelectedItem).Version1}"), true);
                            InstallAppFiles(true);
                        }
                    }
                    else if (File.Exists(Path.Combine(_appUpdates, @$"LearningPractice-{((Models.Application.Version)VersionComboBox.SelectedItem).Version1}\bin\Debug\net6.0-windows\LearningPractice(IE).exe"))
                        && _launcherStatus == LauncherStatus.Ready)
                    {
                        if (MessageBox.Show("Данная версия уже установлена, Вы хотите её переустановить ?", "Информация", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                        {
                            Directory.Delete(Path.Combine(_appUpdates, @$"LearningPractice-{((Models.Application.Version)VersionComboBox.SelectedItem).Version1}"), true);
                            InstallAppFiles(true);
                        }
                    }
                    else if (File.Exists(Path.Combine(_appUpdates, @$"LearningPractice-{((Models.Application.Version)VersionComboBox.SelectedItem).Version1}.zip"))
                        && _launcherStatus == LauncherStatus.Ready)
                    {
                        if (MessageBox.Show("Данная версия уже установлена, Вы хотите её переустановить ?", "Информация", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                        {
                            File.Delete(Path.Combine(_appUpdates, @$"LearningPractice-{((Models.Application.Version)VersionComboBox.SelectedItem).Version1}.zip"));
                            InstallAppFiles(true);
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("Приложение не установлено. Установить ?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                        {
                            InstallAppFiles(false);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Выберите версию которую желаете переустановить.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                }
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
                if (!File.Exists(_appUpdates)) { Directory.CreateDirectory(_appUpdates); }
                VersionComboBox.Items.Add(new Models.Application.Version() { Version1 = "Выберите версию" });
                foreach (var item in ApplicationDB.context.Versions.ToList())
                {
                    VersionComboBox.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                NavigationService.Navigate(new ErrorReportPage(ex));
            }
        }
    }
}
