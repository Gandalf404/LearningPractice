﻿#pragma checksum "..\..\..\..\..\Pages\LauncherPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C09BDC73A453697D4D872716504A15BE0D2A6F4E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using LearningPractice_Launcher_.Pages;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace LearningPractice_Launcher_.Pages {
    
    
    /// <summary>
    /// LauncherPage
    /// </summary>
    public partial class LauncherPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\..\..\Pages\LauncherPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox VersionComboBox;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\..\Pages\LauncherPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button StartAppButton;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\..\Pages\LauncherPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UpdateAppButton;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\..\Pages\LauncherPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox IsUpdateExtractedCheckBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/LearningPractice(Launcher);component/pages/launcherpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Pages\LauncherPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\..\..\..\Pages\LauncherPage.xaml"
            ((LearningPractice_Launcher_.Pages.LauncherPage)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.VersionComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.StartAppButton = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\..\..\Pages\LauncherPage.xaml"
            this.StartAppButton.Click += new System.Windows.RoutedEventHandler(this.StartAppButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.UpdateAppButton = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\..\..\Pages\LauncherPage.xaml"
            this.UpdateAppButton.Click += new System.Windows.RoutedEventHandler(this.UpdateAppButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.IsUpdateExtractedCheckBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

