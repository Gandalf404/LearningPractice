using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows;
using System.Windows.Input;
using static LearningPractice_Launcher_.LauncherHandler;
using LearningPractice_Launcher_.Pages;

namespace LearningPractice_Launcher_
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new LauncherPage());
        } 
    }
}