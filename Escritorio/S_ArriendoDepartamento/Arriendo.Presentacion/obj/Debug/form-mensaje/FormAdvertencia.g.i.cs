﻿#pragma checksum "..\..\..\form-mensaje\FormAdvertencia.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E4FC6A6AF6E2F1A4AB36C6423C8F781AE70567D8B53D9E48DB816A1748A562E8"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using Arriendo.Presentacion.form_mensaje;
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


namespace Arriendo.Presentacion.form_mensaje {
    
    
    /// <summary>
    /// FormAdvertencia
    /// </summary>
    public partial class FormAdvertencia : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\form-mensaje\FormAdvertencia.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\form-mensaje\FormAdvertencia.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton btn_Salir;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\form-mensaje\FormAdvertencia.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblMensaje;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\form-mensaje\FormAdvertencia.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSi;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\form-mensaje\FormAdvertencia.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNo;
        
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
            System.Uri resourceLocater = new System.Uri("/Arriendo.Presentacion;component/form-mensaje/formadvertencia.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\form-mensaje\FormAdvertencia.xaml"
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
            
            #line 9 "..\..\..\form-mensaje\FormAdvertencia.xaml"
            ((Arriendo.Presentacion.form_mensaje.FormAdvertencia)(target)).StateChanged += new System.EventHandler(this.Window_StateChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.label = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.btn_Salir = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 21 "..\..\..\form-mensaje\FormAdvertencia.xaml"
            this.btn_Salir.Click += new System.Windows.RoutedEventHandler(this.Btn_Salir_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.lblMensaje = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.btnSi = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\form-mensaje\FormAdvertencia.xaml"
            this.btnSi.Click += new System.Windows.RoutedEventHandler(this.BtnSi_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnNo = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\form-mensaje\FormAdvertencia.xaml"
            this.btnNo.Click += new System.Windows.RoutedEventHandler(this.BtnNo_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

