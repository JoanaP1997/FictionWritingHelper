using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WritingHelper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_OnClosed(object sender, EventArgs e)
        {
            
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            List<String> s = new List<string>
            {
                "Page One", "Page Two", "Page Three"
            };
            navigation_list_view.ItemsSource = s;
            
        }


        private void Navigation_list_view_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ModernWpf.Controls.ListView listview = (ModernWpf.Controls.ListView) sender;
            String selectedItem = (String)listview.SelectedItem;
            //MessageBox.Show(selectedItem);
        }
    }
}