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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;

namespace LibraryCatalog
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string filePath;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BookBtn_Click(object sender, RoutedEventArgs e)
        {
            BookGrid.Visibility = Visibility.Visible;
            PuzzleGrid.Visibility = Visibility.Hidden;
            TableGrid.Visibility = Visibility.Hidden;
        }

        private void PuzzleBtn_Click(object sender, RoutedEventArgs e)
        {
            BookGrid.Visibility = Visibility.Hidden;
            PuzzleGrid.Visibility = Visibility.Visible;
            TableGrid.Visibility = Visibility.Hidden;
        }

        private void TableBtn_Click(object sender, RoutedEventArgs e)
        {
            BookGrid.Visibility = Visibility.Hidden;
            PuzzleGrid.Visibility = Visibility.Hidden;
            TableGrid.Visibility = Visibility.Visible;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text file (*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, "testTEXT");
        }

        private void OpenBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text file (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == true)
            {
                File.ReadAllText(openFileDialog.FileName);
                filePath = openFileDialog.FileName;
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (filePath != null)
                File.Delete(filePath);
        }
    }
}
