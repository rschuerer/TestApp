﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using TestApp.Models;
using TestApp.Services;

using Windows.UI.Xaml.Controls;

namespace TestApp.Views
{
    public sealed partial class TelerikDataGrid1Page : Page, INotifyPropertyChanged
    {
        // TODO WTS: Change the grid as appropriate to your app, adjust the column definitions on TelerikDataGrid1Page.xaml.
        // For help see http://docs.telerik.com/windows-universal/controls/raddatagrid/gettingstarted
        // You may also want to extend the grid to work with the RadDataForm http://docs.telerik.com/windows-universal/controls/raddataform/dataform-gettingstarted
        public TelerikDataGrid1Page()
        {
            InitializeComponent();
        }

        public ObservableCollection<SampleOrder> Source
        {
            get
            {
                // TODO WTS: Replace this with your actual data
                return SampleDataService.GetGridSampleData();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Set<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return;
            }

            storage = value;
            OnPropertyChanged(propertyName);
        }

        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
