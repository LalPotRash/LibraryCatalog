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

namespace LibraryCatalog
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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
    }
}
