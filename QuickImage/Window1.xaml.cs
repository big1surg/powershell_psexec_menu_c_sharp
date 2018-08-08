using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace QuickImage
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        ObservableCollection<Computer> computerView = new ObservableCollection<Computer>();
        public Window1()
        {
            InitializeComponent();
            for(int i =0; i<10; i++)
            {
                computerView.Add(new Computer() { Name = "test" });
            }
            DataContext = computerView;
        }
        

        //a button for testing 
        private void Button_Click(object sender, RoutedEventArgs e)
        {



        }
    }
}
