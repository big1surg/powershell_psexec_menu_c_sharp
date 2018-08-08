using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QuickImage {
    /// <summary>
    /// Interaction logic for OptionsWindow.xaml
    /// </summary>
    public partial class OptionsWindow : Window {
        public Delegate UpdateOptionsWindowDialogBox;

        public OptionsWindow()
        {
            InitializeComponent();
        }

        //cancel
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            UpdateOptionsWindowDialogBox.DynamicInvoke(); //will call closeoptionswidnowsview
            this.Close();
        }

        //save, will save name to file
        private void Save_Click_1(object sender, RoutedEventArgs e)
        {
            string host = GetHostFile();
            MessageBoxButton buttons = MessageBoxButton.OK;
            MessageBox.Show(host, "caption", buttons);
        }

        public string GetHostFile()
        {
            string fileName = "Paths.txt";
            string path = System.IO.Path.Combine(Environment.CurrentDirectory, @"QuickImage\", fileName);
            string hostText = System.IO.File.ReadAllText(path);
            return hostText;
        }
    }
}
