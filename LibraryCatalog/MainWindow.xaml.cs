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
using LibraryCatalogLibrary;

namespace LibraryCatalog
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string filePath;
        List<string> details = new List<string>();
        List<TextBox> boxes = new List<TextBox>();

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
            details.Clear();
            details.Add(BookName.Text);
            details.Add(BookAuthor.Text);
            details.Add(BookIllustrator.Text);
            details.Add(BookPublisher.Text);
            details.Add(BookYear.Text);
            details.Add(PuzzleName.Text);
            details.Add(PuzzleElements.Text);
            details.Add(PuzzleCompany.Text);
            details.Add(TableName.Text);
            details.Add(TableDeveloper.Text);
            details.Add(TableGameplay.Text);
            details.Add(TablePlayers.Text);

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text file (*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == true)
            {
                filePath = saveFileDialog.FileName;
                using (StreamWriter sw = new StreamWriter(filePath, false, System.Text.Encoding.Default))
                {
                    foreach (string detail in details)
                        sw.WriteLine(detail);
                }
            }
        }

        private void OpenBtn_Click(object sender, RoutedEventArgs e)
        {
            boxes.Clear();
            boxes.Add(BookName);
            boxes.Add(BookAuthor);
            boxes.Add(BookIllustrator);
            boxes.Add(BookPublisher);
            boxes.Add(BookYear);
            boxes.Add(PuzzleName);
            boxes.Add(PuzzleElements);
            boxes.Add(PuzzleCompany);
            boxes.Add(TableName);
            boxes.Add(TableDeveloper);
            boxes.Add(TableGameplay);
            boxes.Add(TablePlayers);

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text file (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == true)
            {
                filePath = openFileDialog.FileName;
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    int i = 0;
                    while ((line = sr.ReadLine()) != null)
                    {
                        boxes[i].Text = line;
                        ++i;
                    }
                }
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (filePath != null)
                File.Delete(filePath);
        }
    }
}
