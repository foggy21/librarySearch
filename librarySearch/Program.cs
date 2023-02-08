using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                Console.Write("Библиотека\n\nВведите команду:\n\n1 - Поиск книги по автору\n\n2 - Поиск книги по стелажу\n\n3 - Добавление книги\n\n4 - Выход из программы\n\nВвод команды:");
                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        Console.Write("Введите имя автора (Формат И.О.Фамилия): ");
                        userInput = Console.ReadLine();
                        if (checkFormatName(userInput))
                        {
                            findBookByAuthor(books, userInput);
                        } 
                        else
                        {
                            Console.Write("Неправильный формат ввода имени.\nНажмите любую клавишу для продолжения...");
                        }
                        break;
                    case "2":
                        Console.Write("Введите первую позицую полки (от 1 до 5): ");
                        userInput = Console.ReadLine();
                        int posY = Convert.ToInt32(userInput);

                        Console.Write("\nВведите позицую книги на полке (от 1 до 4): ");
                        userInput = Console.ReadLine();
                        int posX = Convert.ToInt32(userInput);

                        if (1 <= posY && posY <= 5 && 1 <= posX && posX <= 4)
                        {
                            findBookByPosition(books, posY, posX);
                        }
                        else
                        {
                            Console.WriteLine("Ошибка! Неверна выбрана позиция книги!\nНажмите любую клавшиу для продолжения...");
                        }
                        break;
                    case "3":
                        Console.Write("Введите имя автора книги (Формат И.О.Фамилия): ");
                        userInput = Console.ReadLine();
                        if (checkFormatName(userInput))
                        {
                            setBook(books, userInput);
                        }
                        else
                        {
                            Console.Write("Неправильный формат ввода имени.\nНажмите любую клавишу для продолжения...");
                        }
                        break;
                    case "4":
                        isOpen = false;
                        break;
                    default:
                        Console.WriteLine("Неверная команда.\nНажмите любую клавишу для продолжения...");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void quickSort(string[] books, int left, int right)
        {
            if (left >= right) return;
            int letterOfSurname = 4;
            string baseAuthor = books[(left + right) / 2]; // Choose middle author from array.
            int baseElement = baseAuthor[letterOfSurname]; // Choose first letter in surname.
            int i = left;
            int j = right;
            while (i <= j)
            {
                while (books[i][letterOfSurname] <= baseElement)
                {
                    if (books[i] == baseAuthor) break;
                    while (books[i][letterOfSurname] == baseElement)
                    {
                        baseElement = baseAuthor[++letterOfSurname];
                        if (letterOfSurname == books[i].Length - 1 || letterOfSurname == baseAuthor.Length - 1)
                        {
                            break;
                        }
                    }
                    if (books[i][letterOfSurname] < baseElement) i++;
                    else break;
                }
                letterOfSurname = 4;
                baseElement = baseAuthor[letterOfSurname];
                while (books[j][letterOfSurname] >= baseElement)
                {
                    if (books[j] == baseAuthor) break;
                    while (books[j][letterOfSurname] == baseElement)
                    {
                        baseElement = baseAuthor[++letterOfSurname];
                        if (letterOfSurname == books[j].Length - 1 || letterOfSurname == baseAuthor.Length - 1)
                        {
                            break;
                        }
                    }
                    if (books[j][letterOfSurname] > baseElement) j--;
                    else break;
                }
                letterOfSurname = 4;
                baseElement = baseAuthor[letterOfSurname];
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

        static void setBook(string[,] books, string book)
        {
            int lengthOfColumns = books.GetUpperBound(0);
            int lengthOfRows = books.Length / lengthOfColumns;
            const string emptyShelf = "Пустая полка";
            for (int i = 0; i < lengthOfRows; ++i)
            {
                for (int j = 0; j < lengthOfColumns; ++j)
                {
                    if (books[i, j] == emptyShelf)
                    {
                        books[i, j] = book;
                        Console.WriteLine($"Книга автора {book} поставлена на позиции {i + 1}, {j + 1}");
                        return;
                    }
                }
            }
            Console.WriteLine("Не найдено пустой полки.");
        }

        static void findBookByAuthor(string[,] books, string author)
        {
            int lengthOfColumns = books.GetUpperBound(0);
            int lengthOfRows = books.Length / lengthOfColumns;
            for (int i = 0; i < lengthOfRows; ++i)
            {
                for (int j = 0; j < lengthOfColumns; ++j) 
                {
                    if (books[i,j] == author)
                    {
                        Console.WriteLine($"Книга автора {author} находится на позиции {i + 1}, {j + 1}");
                        return;
                    }
                }
            }
            Console.WriteLine($"Книга автора {author} не найдена.");
        }

        static bool checkFormatName(string author)
        {
            const int letterInName = 5;
            const int letterOfSurname = 4;
            const string formatName = "N.P.S"; // N - name, P - patronymic, S - surname

            bool isRight = false;
            if (author.Length >= letterInName)
            {
                isRight = true;
                for (int i = 0; i < letterOfSurname; ++i)
                {
                    if (char.IsLetter(author[i]) && char.IsLetter(formatName[i]))
                    {
                        continue;
                    } 
                    else if (author[i] == '.' && formatName[i] == '.')
                    {
                        continue;
                    } 
                    else
                    {
                        isRight = false;
                        break;
                    }
                }
            }

            return isRight;
        }

        static void findBookByPosition(string[,] books, int posY, int posX)
        {
            Console.WriteLine($"На позиции {posY}, {posX} находится книга автора {books[posY - 1, posX - 1]}");
        }
    }
}
