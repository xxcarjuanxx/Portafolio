﻿#pragma checksum "..\..\..\form\OlvidoContrasenia.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3BEBC36D0EF11EB4CCB578665A6DF4F8B6BCFE03"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using Arriendo.Presentacion.form;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace Arriendo.Presentacion.form {
    
    
    /// <summary>
    /// OlvidoContrasenia
    /// </summary>
    public partial class OlvidoContrasenia : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\form\OlvidoContrasenia.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtUsuario;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\form\OlvidoContrasenia.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.RepeatButton btnOlvidoContraseña;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\form\OlvidoContrasenia.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton btn_Salir;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Arriendo.Presentacion;component/form/olvidocontrasenia.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\form\OlvidoContrasenia.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\..\form\OlvidoContrasenia.xaml"
            ((Arriendo.Presentacion.form.OlvidoContrasenia)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtUsuario = ((System.Windows.Controls.TextBox)(target));
            
            #line 18 "..\..\..\form\OlvidoContrasenia.xaml"
            this.txtUsuario.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TxtUsuario_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnOlvidoContraseña = ((System.Windows.Controls.Primitives.RepeatButton)(target));
            
            #line 21 "..\..\..\form\OlvidoContrasenia.xaml"
            this.btnOlvidoContraseña.Click += new System.Windows.RoutedEventHandler(this.BtnEnviar_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_Salir = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 29 "..\..\..\form\OlvidoContrasenia.xaml"
            this.btn_Salir.Click += new System.Windows.RoutedEventHandler(this.Btn_Salir_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

