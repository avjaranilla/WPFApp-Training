﻿#pragma checksum "..\..\..\ItemForm.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "BF82B6A79C6EFEF9858EF935B701E951CA91193A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using WpfApp_Ui;


namespace WpfApp_Ui {
    
    
    /// <summary>
    /// ItemForm
    /// </summary>
    public partial class ItemForm : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 37 "..\..\..\ItemForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GroupBox grpItem;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\ItemForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtListID;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\ItemForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtItemID;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\..\ItemForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtItemName;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\..\ItemForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtItemDesc;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\..\ItemForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cboStatus;
        
        #line default
        #line hidden
        
        
        #line 131 "..\..\..\ItemForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSave;
        
        #line default
        #line hidden
        
        
        #line 137 "..\..\..\ItemForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancel;
        
        #line default
        #line hidden
        
        
        #line 145 "..\..\..\ItemForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvwItems;
        
        #line default
        #line hidden
        
        
        #line 161 "..\..\..\ItemForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddNew;
        
        #line default
        #line hidden
        
        
        #line 167 "..\..\..\ItemForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnModify;
        
        #line default
        #line hidden
        
        
        #line 173 "..\..\..\ItemForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRemove;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfApp_Ui;V1.0.0.0;component/itemform.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ItemForm.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\..\ItemForm.xaml"
            ((WpfApp_Ui.ItemForm)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.grpItem = ((System.Windows.Controls.GroupBox)(target));
            return;
            case 3:
            this.txtListID = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtItemID = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txtItemName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txtItemDesc = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.cboStatus = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.btnSave = ((System.Windows.Controls.Button)(target));
            
            #line 135 "..\..\..\ItemForm.xaml"
            this.btnSave.Click += new System.Windows.RoutedEventHandler(this.btnSave_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnCancel = ((System.Windows.Controls.Button)(target));
            
            #line 141 "..\..\..\ItemForm.xaml"
            this.btnCancel.Click += new System.Windows.RoutedEventHandler(this.btnCancel_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.lvwItems = ((System.Windows.Controls.ListView)(target));
            
            #line 150 "..\..\..\ItemForm.xaml"
            this.lvwItems.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lvwItems_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 150 "..\..\..\ItemForm.xaml"
            this.lvwItems.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.lvwItems_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 11:
            this.btnAddNew = ((System.Windows.Controls.Button)(target));
            
            #line 165 "..\..\..\ItemForm.xaml"
            this.btnAddNew.Click += new System.Windows.RoutedEventHandler(this.btnAddNew_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.btnModify = ((System.Windows.Controls.Button)(target));
            
            #line 171 "..\..\..\ItemForm.xaml"
            this.btnModify.Click += new System.Windows.RoutedEventHandler(this.btnModify_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.btnRemove = ((System.Windows.Controls.Button)(target));
            
            #line 177 "..\..\..\ItemForm.xaml"
            this.btnRemove.Click += new System.Windows.RoutedEventHandler(this.btnRemove_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

