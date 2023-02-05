using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace librarySearch
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            string[,] books = new string[5, 4] {
                { "А.П.Чехов", "А.С.Пушкин", "Ф.М.Достоевский", "C.А.Есенин" },
                { "М.Ю.Лермонтов", "И.С.Тургенев", "Н.В.Гоголь", "Н.А.Некрасов" },
                { "В.В.Маяковский", "И.А.Бунин", "Б.Л.Постернак", "А.И.Куприн" }, 
                { "Ф.И.Тютчев", "В.А.Жуковский", "И.А.Крылов", "М.В.Ломоносов" }, 
                { "Пустая полка", "Пустая полка", "Пустая полка", "Пустая полка" },
            };
            const int booksInRow = 4;

            bool isOpen = true;
            int rowIterator = 0;
            int columnIterator = 0;
            string userInput;

            string[] rowOfBooks = new string[booksInRow];
            foreach (string book in books)
            {
                rowOfBooks[columnIterator++] = book;
                if (columnIterator >= booksInRow)
                {
                    quickSort(rowOfBooks, 0, booksInRow - 1);
                    for (int i = 0; i < booksInRow; i++)
                    {
                        books[rowIterator, i] = rowOfBooks[i];
                    }
                    rowIterator++;
                    columnIterator = 0;
                }
            }

            while(isOpen) { 
                Console.SetCursorPosition(0, 21);
                Console.Write("Стелаж с книгами:\n");
                foreach(string book in books)
                {
                    Console.Write($"{book}, ");
                    if ( ++columnIterator % booksInRow == 0 ) Console.WriteLine();
                }


                columnIterator = 0;
                Console.SetCursorPosition(0, 0);
                Console.Write("Библиотека\n\nВведите команду:\n\n1 - Поиск книги по автору\n\n2 - Поиск книги по стелажу\n\n3 - Добавление книги\n\nВвод команды:");
                //quickSort(books, 0, books.Length - 1);
                Console.ReadKey();
                Console.Clear();
            }
        }
        static void quickSort(string[] books, int left, int right)
        {
            if (left >= right) return;
            int baseElement = books[(left + right) / 2][4]; // Choose first letter in surname.
            int i = left;
            int j = right;
            while (i <= j)
            {
                while (books[i][4] < baseElement) i++;
                while (books[j][4] > baseElement) j--;
                if (i <= j)
                {
                    string tempBook = books[i];
                    books[i] = books[j];
                    books[j] = tempBook;
                    i++;
                    j--;
                }
            }
            quickSort(books, left, j);
            quickSort(books, i, right);
        }
    }
}
