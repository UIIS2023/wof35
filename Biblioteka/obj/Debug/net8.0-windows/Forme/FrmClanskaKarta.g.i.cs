﻿#pragma checksum "..\..\..\..\Forme\FrmClanskaKarta.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B88906E925150928C0B31AE93ECF978A75F13DC4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Biblioteka.Forme;
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


namespace Biblioteka.Forme {
    
    
    /// <summary>
    /// FrmClanskaKarta
    /// </summary>
    public partial class FrmClanskaKarta : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\..\Forme\FrmClanskaKarta.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpDatumUclanjenja;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Forme\FrmClanskaKarta.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCenaKarte;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\Forme\FrmClanskaKarta.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbKorisnik;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\Forme\FrmClanskaKarta.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbKnjiga;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\Forme\FrmClanskaKarta.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSacuvaj;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\Forme\FrmClanskaKarta.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOtkazi;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Biblioteka;component/forme/frmclanskakarta.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Forme\FrmClanskaKarta.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.dpDatumUclanjenja = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 2:
            this.txtCenaKarte = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.cbKorisnik = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.cbKnjiga = ((System.Windows.Controls.ComboBox)(target));
            
            #line 22 "..\..\..\..\Forme\FrmClanskaKarta.xaml"
            this.cbKnjiga.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbKnjiga_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnSacuvaj = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\..\Forme\FrmClanskaKarta.xaml"
            this.btnSacuvaj.Click += new System.Windows.RoutedEventHandler(this.btnSacuvaj_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnOtkazi = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\..\Forme\FrmClanskaKarta.xaml"
            this.btnOtkazi.Click += new System.Windows.RoutedEventHandler(this.btnOtkazi_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

