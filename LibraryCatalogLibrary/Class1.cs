using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace LibraryCatalogLibrary
{

    public static class ObjectMaker
    {
        public static StorageObject Make(string pieceCode, string Name, List<TextBox> boxes)
        {
            StorageObject obj = null;

            switch (pieceCode)
            {
                case "Book":
                    obj = new Book(Name, boxes);
                    break;

                case "Puzzle":
                    obj = new Puzzle(Name, boxes);
                    break;

                case "Table":
                    obj = new TableGame(Name, boxes);
                    break;
            }
            return obj;
        }
    }

    public abstract class StorageObject
    {
        protected string name;

        public StorageObject(string newName)
        {
            name = newName;
        }
        public abstract bool Check(string newName);
    }

    class Book : StorageObject
    {
        private string bookName;
        private string bookAuthor;
        private string bookIllustrator;
        private string bookPublisher;
        private int bookYear;

        public Book(string newName, List<TextBox> boxes) : base(newName)
        {
            bookName = boxes[0].Text;
            bookAuthor = boxes[1].Text;
            bookIllustrator = boxes[2].Text;
            bookPublisher = boxes[3].Text;
            bookYear = Convert.ToInt32(boxes[4].Text);
        }

        public override bool Check(string newName)
        {
            if (bookName != "" && bookAuthor != "" && bookPublisher != "")
                return true;
            else
                return false;
        }
    }

    class Puzzle : StorageObject
    {
        private string puzzleName;
        private int puzzleElements;
        private string puzzleCompany;

        public Puzzle(string newName, List<TextBox> boxes) : base(newName)
        {
            puzzleName = boxes[5].Text;
            puzzleElements = Convert.ToInt32(boxes[6].Text);
            puzzleCompany = boxes[7].Text;
        }

        public override bool Check(string newName)
        {
            if (puzzleName != "" && puzzleCompany != "")
                return true;
            else
                return false;
        }
    }

    class TableGame : StorageObject
    {
        private string tableName;
        private string tableDeveloper;
        private string tableGameplay;
        private string tablePlayers;

        public TableGame(string newName, List<TextBox> boxes) : base(newName)
        {
            tableName = boxes[8].Text;
            tableDeveloper = boxes[9].Text;
            tableGameplay = boxes[10].Text;
            tablePlayers = boxes[11].Text;
        }

        public override bool Check(string newName)
        {
            if (tableName != "" && tableDeveloper != "" && tableGameplay != "" && tablePlayers != "")
                return true;
            else
                return false;
        }
    }
}
