﻿#pragma checksum "..\..\..\..\Pages\ErrorReportPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "64F7D5B918304E02B3BE69A68B1EA1A425299486"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using LearningPractice_App_.Pages;
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


namespace LearningPractice_App_.Pages {
    
    
    /// <summary>
    /// ErrorReportPage
    /// </summary>
    public partial class ErrorReportPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\..\Pages\ErrorReportPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox EmailTextBox;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\Pages\ErrorReportPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ErrorDescriptionTextBox;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\Pages\ErrorReportPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CancelSendReportButton;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\Pages\ErrorReportPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SendReportButton;
        
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
            System.Uri resourceLocater = new System.Uri("/LearningPractice(App);component/pages/errorreportpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\ErrorReportPage.xaml"
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
            this.EmailTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.ErrorDescriptionTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.CancelSendReportButton = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\..\Pages\ErrorReportPage.xaml"
            this.CancelSendReportButton.Click += new System.Windows.RoutedEventHandler(this.CancelSendReportButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.SendReportButton = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\..\Pages\ErrorReportPage.xaml"
            this.SendReportButton.Click += new System.Windows.RoutedEventHandler(this.SendReportButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

