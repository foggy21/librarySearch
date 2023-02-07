# Library Search
<b><h3>Проект для повторения и закрепления эффективных алгоритмов.</h3></b>
Приложение для выбора и добавления своих книг.<br/>
***
Задачи:<br/>
---
1.  Стелаж состоит из полок, на каждой полке помещается одинаковое количество книг. На полках могут быть пустые места.
2.  Каждая полка должна хранить упорядоченный набор книг по фамилии автора
3.  Пользователь может найти книгу по автору, а также по позиции на стелаже.
4.  Пользователь может добавить свою книгу на стелаж, если имеется пустое место на полках. Можно добавлять книгу только в соответствии со следующим форматом: **И.О.Фамилия**
---
## Алгоритмы
<br/>
<p style="font-size: 14px">Для сортировки книг на полках был использован эффективный алгоритм быстрой сортировки.</p>

```cs
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
```
<p style="font-size: 16px">Недостаток конкретно этой сортировки в том, что нет сравнения по следующим буквам фамилии, если первые буквы одинаковые</p>

><em style="font-size: 15px">Запишем это в список доработок</em>
<br/>

---

## Список доработок
<p style="font-size:14px">
1. Грамотно решить проблему сортировки книг, сравнивая следующие буквы, если первые буквы фамилии автора одинаковые.
<br/>
</p>

## Доработки
    1. Грамотно решить проблему сортировки книг, сравнивая следующие буквы, 
    если первые буквы фамилии автора одинаковые.
<p style="font-size:18px"><b>Решение</b><br/></p>
<p style="font-size:14px">Кусок кода, осуществляющий сравнение первых букв фамилии и сдвигающий индекс влево/вправо

```C#
while (books[i][4] < baseElement) i++;
```

Был заменён так, чтобы теперь условие брало в расчет совпадение букв, кроме того случая, когда имена сравниваемых авторов полностью совпадаютс по ФИО.<br/><br/>

Решение заключается в следующем: <br/>
+ Если совпадает буква в фамилиях, то идем циклом по обоим фамилиям, пока буквы не будут совпадать.
```cs
while (books[i][letterOfSurname] == baseElement)
{
    baseElement = baseAuthor[++letterOfSurname];
    if (letterOfSurname == books[i].Length - 1 || letterOfSurname == baseAuthor.Length - 1)
    {
        break;
    }
}
```
+ После этого цикла мы сверяем буквы по тому же принципу, как и раньше и в зависимости от этого сдвигаем индекс вправо/влево, либо выходим из массива.

```cs
if (books[i][letterOfSurname] < baseElement) i++;
else break;
```
<br/>
P.S. Мы выходим из цикла "насильно" с помощью <b>break</b> во избежании зацикленности алгоритма.
<br/>
<br/>

+ После цикла возвращаемся к первой букве фамилии для следующих сравнений.

```cs
letterOfSurname = 4;
baseElement = baseAuthor[letterOfSurname];
```
<br/>

Ниже представлен полный код:
```cs
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
```
</p>

---
# Спойлер
<p style="font-size:20px"> Этот проект является учебным для улучшения навыков описания репозитория и ведения документации проекта. Идея взята с <a href="https://www.youtube.com/watch?v=w8rRhAup4kg">курса</a> Романа Сакутина и немного модифицирована.</p>

---
# Spoiler
<p style="font-size:20px"> This study project is designed to upgrade skills in the description repository and record management of project. The idea of the project borrowed from Roman Sakutin's <a href="https://www.youtube.com/watch?v=w8rRhAup4kg">course</a></p>

