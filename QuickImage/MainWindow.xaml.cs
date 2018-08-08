using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuickImage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //event delegate to cancel button
        public delegate void CloseOptionsWindow();
        public event CloseOptionsWindow CloseOptionsWindowEvent;
        //event delegate to save host file

        public string CompName { get; set; }
        public string DialogBox { get; set; }
        ObservableCollection<Computer> computerView; 

        public MainWindow(){
            InitializeComponent();
            computerView = new ObservableCollection<Computer>();
            listComputers.ItemsSource = computerView;
        }

        private void Add_Click(object sender, RoutedEventArgs e){
            PrintLoop();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            computerView.Clear();
            dialogBox.AppendText("All items cleared.\n");

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e){}

        public void PrintLoop(){
            int count = 1;
            string compNames = compName.Text.ToString();
            char[] delimiterChars = { ',', ' ' };
            string[] compNamesArray = compNames.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
            foreach(var computer in compNamesArray){
                dialogBox.AppendText(count+". Pc Name: " + computer + "\n");
                Computer newPc = new Computer();
                newPc.Name = computer;
                Boolean doesPCExist = newPc.CheckIfExist();
                if(doesPCExist == true)
                {
                    computerView.Add(newPc);
                    dialogBox.AppendText("  PC " + computer + " is pinging with IPAddr: "+newPc.Addr +"\n");
                }
                else
                {
                    dialogBox.AppendText("************* " +computer+ " isn't pinging *************\n");
                }
                if (chkBoxHost.IsChecked.GetValueOrDefault()){
                    GetHostFile(computer);
                }
                if (chkBoxPrinter.IsChecked.GetValueOrDefault()){
                    GetPrinterFile(computer);
                }
                count++;
            }

        }

        public void GetHostFile(string comp){
            string pathOfHostOnComputers = ("\\\\" + comp + "\\c$\\Windows\\System32\\drivers\\etc\\");
            dialogBox.AppendText("  Adding Host File... to " + comp + "\n");
            string hostFile = hostFilePath.GetLineText(0).ToString();
            dialogBox.AppendText("  Your Host File Path:" +hostFile+ "\n");
            dialogBox.AppendText("  Computer Host File Path:" + pathOfHostOnComputers + ", being deleted\n");
            DeleteHostFile(pathOfHostOnComputers);
            AddingNewHostFile(hostFile, pathOfHostOnComputers);
            dialogBox.AppendText("  New Host File Added\n");
        }

        public void DeleteHostFile(string path)
        {
            File.Delete(path + "hosts");
        }

        public void AddingNewHostFile(string pathToFile, string destination)
        {
            File.Copy(System.IO.Path.Combine(pathToFile, "hosts"), System.IO.Path.Combine(destination, "hosts"));
        }

        public void GetPrinterFile(string comp){
            dialogBox.AppendText("  Adding Printer File... to " + comp + "\n");
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            //try to loop over the checkbox and bind it to the computer name 
            /*foreach (var computer in computerView)
            {
                if (computer.){

                }
            }*/
        }

        private void Cancel_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void CancelAll_Click_2(object sender, RoutedEventArgs e)
        {

        }

        //options for host file
        private void Options_Click(object sender, RoutedEventArgs e)
        {
            dialogBox.AppendText("Options Menu Opened\n");
            OptionsWindow win1 = new OptionsWindow();
            CloseOptionsWindowEvent += new CloseOptionsWindow(CloseOptionsWindowView); //initialize
            win1.UpdateOptionsWindowDialogBox = CloseOptionsWindowEvent; //this will assign event to delegate
            win1.Show();

        }

        //event for delegate
        private void CloseOptionsWindowView()
        {
            //code to print to dialog box
            dialogBox.AppendText("Options Menu Close\n");
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            dialogBox.Clear();
            computerView.Clear();
        }
    }
}
