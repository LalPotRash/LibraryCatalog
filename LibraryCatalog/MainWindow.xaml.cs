using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
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
        private string filePath;
        private List<TextBox> boxes = new List<TextBox>();

        public MainWindow()
        {
            InitializeComponent();

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
            try
            {
                Convert.ToInt32(BookYear.Text);
                Convert.ToInt32(PuzzleElements.Text);

                StorageObject bookObj = ObjectMaker.Make("Book", boxes[0].Text, boxes);
                StorageObject puzzleObj = ObjectMaker.Make("Puzzle", boxes[5].Text, boxes);
                StorageObject tableObj = ObjectMaker.Make("Table", boxes[8].Text, boxes);

                if (bookObj.Check(boxes[0].Text) && puzzleObj.Check(boxes[5].Text) && tableObj.Check(boxes[8].Text))
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Text file (*.txt)|*.txt";
                    if (saveFileDialog.ShowDialog() == true)
                    {
                        filePath = saveFileDialog.FileName;
                        using (StreamWriter sw = new StreamWriter(filePath, false, System.Text.Encoding.Default))
                        {
                            foreach (TextBox detail in boxes)
                            {
                                sw.WriteLine($"{detail.Name} : {detail.Text}");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please, fill all fields!");
                }
            }
            catch(FormatException)
            {
                MessageBox.Show("Please, use INT, not STRING!");
            }
        }

        private void OpenBtn_Click(object sender, RoutedEventArgs e)
        {
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
                        boxes[i].Text = line.Split(':')[1].Trim();
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
