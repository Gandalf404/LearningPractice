using System;
using System.Management;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows;
using System.Windows.Input;
using static LearningPractice_Launcher_.LauncherHandler;

namespace LearningPractice_Launcher_
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _rootPath;
        private string _versionFile;
        private string _appZip;
        private string _appExe;

        private LauncherStatus _launcherStatus;

        public MainWindow()
        {
            InitializeComponent();

            _rootPath = @$"C:\Users\{Environment.UserName}\source\repos\";
            _versionFile = Path.Combine(_rootPath, @"LearningPractice-app\LearningPractice\Resources\Version.txt");
            _appZip = @$"C:\Users\{Environment.UserName}\Downloads\LearningPractice-app.zip";
            _appExe = Path.Combine(_rootPath, @"LearningPractice-app\LearningPractice\bin\Debug\net6.0-windows\LearningPractice.exe");
        }

        private void InstallAppFiles(bool isUpdating, AppVersion repoVersion)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    if (isUpdating)
                    {
                        _launcherStatus = LauncherStatus.DownloadingUpdate;
                        Mouse.OverrideCursor = Cursors.Wait;
                        DownloadStatus.Text = "Установка обновления...";
                    }
                    else
                    {
                        _launcherStatus = LauncherStatus.DownloadingApp;
                        Mouse.OverrideCursor = Cursors.Wait;
                        DownloadStatus.Text = "Установка приложения...";
                        repoVersion = new AppVersion(webClient.DownloadString("https://raw.githubusercontent.com/Gandalf404/LearningPractice/app/LearningPractice/Resources/Version.txt"));
                    }

                    webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadCompletedCallback);
                    webClient.DownloadFileAsync(new Uri("https://github.com/Gandalf404/LearningPractice/archive/app.zip"), _appZip, repoVersion);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при установке файлов", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DownloadCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                string repoVersion = ((AppVersion)e.UserState).ToString();
                ZipFile.ExtractToDirectory(_appZip, _rootPath, true);
                File.Delete(_appZip);
                File.WriteAllText(_versionFile, repoVersion);
                VersionTextBlock.Text = repoVersion;
                _launcherStatus = LauncherStatus.Ready;
                Mouse.OverrideCursor = Cursors.Arrow;
                DownloadStatus.Text = "Приложение установлено";
                StartAppButton.Content = "Запустить приложение";
                UpdateAppButton.Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                _launcherStatus = LauncherStatus.Failed;
                MessageBox.Show(ex.Message, "Ошибка при установке", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CheckForUpdates()
        {
            try
            {
                AppVersion currentVersion = new AppVersion(File.ReadAllText(_versionFile));
                AppVersion repoVersion = new AppVersion();
                VersionTextBlock.Text = currentVersion.ToString();
                using (WebClient webClient = new WebClient())
                {
                    repoVersion = new AppVersion(webClient.DownloadString("https://raw.githubusercontent.com/Gandalf404/LearningPractice/app/LearningPractice/Resources/Version.txt"));
                }

                if (repoVersion.IsVersionDifferent(currentVersion))
                {
                    if (MessageBox.Show("Доступно новое обновление. Установить ?", "Информация", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        InstallAppFiles(true, repoVersion);                       
                    }
                    else
                    {
                        DownloadStatus.Text = "Доступно обновление";
                        UpdateAppButton.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    _launcherStatus = LauncherStatus.Ready;                    
                }
            }
            catch (Exception ex)
            {
                _launcherStatus = LauncherStatus.Failed;
                MessageBox.Show(ex.Message, "Ошибка при проверке обновлений", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void StartAppButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (File.Exists(_appExe) && _launcherStatus == LauncherStatus.Ready)
                {
                    Process.Start(new ProcessStartInfo(_appExe));
                    Close();
                }
                else
                {
                    if (MessageBox.Show("Приложение не установлено. Установить ?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        InstallAppFiles(false, AppVersion.zeroVersion);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при запуске приложения", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            if (File.Exists(_appExe) && _launcherStatus == LauncherStatus.Ready) 
            {
                DownloadStatus.Text = "Приложение установлено";
                StartAppButton.Content = "Запустить приложение";
                CheckForUpdates();
            }
            else
            {
                DownloadStatus.Text = "Приложение не установлено";
                StartAppButton.Content = "Установить приложение";
                if (MessageBox.Show("Приложение не установлено. Установить ?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    InstallAppFiles(false, AppVersion.zeroVersion);
                }
            }
        }

        private void ConfigInfoButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"{GetHardwareInfo("Win32_Processor", "Name")[0]}\n{GetHardwareInfo("Win32_VideoController", "Name")[0]}\n{GetHardwareInfo("Win32_DiskDrive", "Caption")[0]}", "Конфигурация ПК", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void UpdateAppButton_Click(object sender, RoutedEventArgs e)
        {
            AppVersion repoVersion = new AppVersion();
            using (WebClient webClient = new WebClient())
            {
                repoVersion = new AppVersion(webClient.DownloadString("https://raw.githubusercontent.com/Gandalf404/LearningPractice/app/LearningPractice/Resources/Version.txt"));
            }
            InstallAppFiles(true, repoVersion);
        }
    }
}