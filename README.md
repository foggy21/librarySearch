# Library Search
<b><h3>Проект для повторения и закрепления эффективных алгоритмов.</h3></b>
Приложение для выбора и добавления своих книг.</br>
***
Задачи:</br>
---
1.  Стелаж состоит из полок, на каждой полке помещается одинаковое количество книг. На полках могут быть пустые места.
2.  Каждая полка должна хранить упорядоченный набор книг по фамилии автора
3.  Пользователь может найти книгу по автору, а также по позиции на стелаже.
4.  Пользователь может добавить свою книгу на стелаж, если имеется пустое место на полках. Можно добавлять книгу только в соответствии со следующим форматом: **И.О.Фамилия**
---
## Алгоритмы
</br>
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
</br>

---

## Список доработок
<p style="font-size:14px">
1. Грамотно решить проблему сортировки книг, сравнивая следующие буквы, если первые буквы фамилии автора одинаковые.
</br>
</p>

---
# Спойлер
<p style="font-size:20px"> Этот проект является учебным для улучшения навыков описания репозитория и ведения документации проекта. Идея взята с <a href="https://www.youtube.com/watch?v=w8rRhAup4kg">курса</a> Романа Сакутина и немного модифицирована.</p>

---
# Spoiler
<p style="font-size:20px"> This study project is designed to upgrade skills in the description repository and record management of project. The idea of the project borrowed from Roman Sakutin's <a href="https://www.youtube.com/watch?v=w8rRhAup4kg">course</a></p>

