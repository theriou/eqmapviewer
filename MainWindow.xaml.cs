using Microsoft.Win32;
using System.Windows;

namespace eqmaps
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public static string loadFile = string.Empty;

        private void MenuItem_Open(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog = new()
            {
                Filter = "txt files (*.txt)|*.txt"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                myCanvas.Children.Clear();
                loadFile = openFileDialog.FileName;
                MapProcess.ProcessMapData(myCanvas, loadFile);
            }
        }

        private void MenuItem_Refresh(object sender, RoutedEventArgs e)
        {

            if (loadFile != string.Empty)
            {
                myCanvas.Children.Clear();
                MapProcess.ProcessMapData(myCanvas, loadFile);
            }
            else
            {
                MessageBox.Show("No File is Open.");
            }
        }
    }
}
