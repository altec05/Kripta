using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ciphers
{
    public partial class Form1 : Form
    {
        public string Richelieu1(string inp) //Расшифровка Полибий
        {
            string s = textBox1.Text; // s - связана с вводимым текстом
            string skey = textBox5.Text; //skey - ключ шифрования
            char[] key = new char[skey.Length];//key - для хранения ключа и его проверок
            string Out = ""; //Строка для зашифрованной строки
            char[] text = new char[s.Length]; //Для хранения введённых символов

            if (textBox1.Text == "") //Проверка на пустое поле
            {
                MessageBox.Show("Введите текст!", "Пустое поле");
                return "";
            }
            if (textBox5.Text == "") //Проверка на пустой ключ
            {
                MessageBox.Show("Укажите ключ шифрования!", "Пустое поле");
                return "";
            }
            else
            {
                string check = "";

                check = skey;
                check = check.Replace("(", "");
                check = check.Replace(")", "");
                check = check.Replace(",", "");

                if (check.Length > s.Length)
                {
                    MessageBox.Show("Недопустимая длина ключа!", "Ключ больше сообщения");
                    return "ОШИБКА КЛЮЧА";
                }
                else
                {
                    string numbers = "123456789(),";
                    string number = "123456789";
                    string marks = ",()";



                    //Перевод ключа в char[]
                    for (int i = 0; i < skey.Length; i++)
                    {
                        key[i] = skey[i];
                    }

                    //Проверка ключа на цифры
                    bool numb;
                    for (int i = 0; i < key.Length; i++)
                    {
                        numb = false;
                        for (int j = 0; j < numbers.Length; j++)
                        {
                            if (key[i] == numbers[j])
                            {
                                numb = true;
                            }
                        }
                        if (numb == false)
                        {
                            return "Неверный ключ!";
                        }
                    }

                    //Определить число комбинаций
                    string s0 = "(";
                    int count = (skey.Length - skey.Replace(s0, "").Length) / s0.Length;

                    //Убираем запятые
                    skey = skey.Replace(",", "");

                    for (int i = 0; i < key.Length; i++)
                    {
                        if (key[0] != '(')
                        {
                            return "Некорректный ввод ключа!";
                        }
                        else if (key[key.Length - 1] != ')')
                        {
                            return "Некорректный ввод ключа!";
                        }
                        else
                        {
                            if (key[i] == '(')
                            {
                                numb = false;
                                for (int j = 0; j < number.Length; j++)
                                {
                                    if (key[i + 1] == number[j])
                                    {
                                        numb = true;
                                    }
                                }
                                if (numb == false)
                                {
                                    return "Некорректный ввод ключа!";
                                }
                            }
                            else if (key[i] == ')')
                            {
                                if (i != key.Length - 1)
                                {
                                    numb = false;
                                    for (int j = 0; j < number.Length; j++)
                                    {

                                        if (key[i + 1] == number[j])
                                        {
                                            numb = true;
                                        }
                                        else if (key[i + 1] == '(' && key[i + 2] != '(' && key[i + 2] != ')')
                                        {
                                            numb = true;
                                        }

                                    }
                                    if (numb == false)
                                    {
                                        return "Некорректный ввод ключа!";
                                    }
                                }
                                else
                                {
                                    break;
                                }

                            }
                            else if (key[i] == ',')
                            {
                                if (key[i + 1] == ',' || key[i - 1] == ',')
                                {
                                    return "Некорректный ввод ключа!";
                                }
                            }
                        }
                    }

                    //Проверяем правильность знаков
                    for (int i = 0; i < key.Length; i++)
                    {
                        if ((key[i] == '(') && (i != 0))
                        {
                            if (key[i - 1] != ')')
                            {
                                return "Некорректный ввод ключа!";
                            }
                        }
                        else if ((key[i] == ')') && (i != key.Length - 1))
                        {
                            if (key[i + 1] != '(')
                            {
                                return "Некорректный ввод ключа!";
                            }
                        }
                        else if (key[i] == ',')
                        {
                            bool numb1 = false;
                            bool numb2 = false;
                            for (int j = 0; j < number.Length; j++)
                            {
                                if (key[i + 1] == number[j])
                                {
                                    numb1 = true;
                                }
                                if (key[i - 1] == number[j])
                                {
                                    numb2 = true;
                                }
                            }
                            if (numb1 == false || numb2 == false)
                            {
                                return "Некорректный ввод ключа!";
                            }
                        }
                    }

                    for (int i = 0; i < key.Length; i++)
                    {
                        for (int j = 0; j < number.Length; j++)
                        {
                            bool mark1 = false;
                            bool mark2 = false;
                            if (key[i] == number[j])
                            {
                                for (int m = 0; m < marks.Length; m++)
                                {
                                    if (key[i - 1] == marks[m])
                                    {
                                        mark1 = true;
                                    }
                                    if (key[i + 1] == marks[m])
                                    {
                                        mark2 = true;
                                    }
                                }
                                if (mark1 == false || mark2 == false)
                                {
                                    return "Некорректный ввод ключа!";
                                }
                            }
                        }
                    }

                    //Разделяем по скобкам
                    char[] charSeparators = new char[] { '(', ')' };
                    string[] split = skey.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
                    //Создаём массивы массивов для цифр
                    int[][] arr = new int[split.Length][];//Для проверки
                    int[][] arr2 = new int[split.Length][];//Для применения
                    //переводим в int
                    for (int i = 0; i < arr.Length; i++)
                    {
                        arr[i] = split[i].ToCharArray().Select(j => int.Parse(j.ToString())).ToArray();
                    }
                    for (int i = 0; i < arr.Length; i++)
                    {
                        arr2[i] = split[i].ToCharArray().Select(j => int.Parse(j.ToString())).ToArray();
                    }

                    //Сортировка ключа для проверки
                    for (int n = 0; n < arr.Length; n++)
                    {
                        int temp;
                        for (int i = 0; i < arr[n].Length - 1; i++)
                        {
                            for (int j = i + 1; j < arr[n].Length; j++)
                            {
                                if (arr[n][i] > arr[n][j])
                                {
                                    temp = arr[n][i];
                                    arr[n][i] = arr[n][j];
                                    arr[n][j] = temp;
                                }
                            }
                        }
                    }

                    //Проверям последовательность
                    for (int n = 0; n < arr.Length; n++)
                    {
                        if (arr[n][0] == 1)
                        {
                            bool dif;
                            for (int i = 0; i < arr[n].Length - 1; i++)
                            {
                                dif = false;
                                int Dif = arr[n][i + 1] - arr[n][i];
                                if (Dif == 1)
                                {
                                    dif = true;
                                }
                                if (dif == false)
                                {
                                    return "Ключ должен начинаться с 1 и между значениями должна быть разница в единицу!";
                                }
                            }
                        }
                        else
                        {
                            return "Ключ должен начинаться с 1 и между значениями должна быть разница в единицу!";
                        }

                    }

                    //Из string в char[] текст
                    for (int i = 0; i < s.Length; i++)
                    {
                        text[i] = s[i];
                    }

                    int k = 0;
                    if (s.Length == check.Length)
                    {
                        char[][] text2 = new char[arr2.Length][];//Для разделения текста
                        for (int i = 0; i < text2.Length; i++)
                        {
                            text2[i] = new char[arr2[i].Length];
                        }
                        for (int n = 0; n < text2.Length; n++)
                        {
                            for (int i = 0; i < arr2[n].Length; i++)
                            {
                                text2[n][i] = text[k];
                                k++;
                            }
                        }

                        swap(arr2, text2);
                        k = 0;
                        for (int i = 0; i < text2.Length; i++)
                        {
                            for (int j = 0; j < text2[i].Length; j++)
                            {
                                text[k] = text2[i][j];
                                k++;
                            }
                        }
                        Out = new string(text);
                    }
                    else if (s.Length > check.Length)
                    {
                        int size = 0;
                        for (int i = 0; i < arr2.Length; i++)
                        {
                            size = size + arr2[i].Length;
                        }

                        char[][] text2 = new char[arr2.Length + 1][];//Для разделения текста
                        for (int i = 0; i < text2.Length; i++)
                        {
                            if (i == arr2.Length)
                            {
                                text2[i] = new char[s.Length - size];
                            }
                            else
                            {
                                text2[i] = new char[arr2[i].Length];
                            }

                        }

                        for (int n = 0; n < text2.Length; n++)
                        {
                            if (k < skey.Length)
                            {
                                if (n < arr2.Length)
                                {
                                    for (int i = 0; i < arr2[n].Length; i++)
                                    {
                                        text2[n][i] = text[k];
                                        k++;
                                    }
                                }
                                else
                                {
                                    for (int i = 0; i < s.Length - size; i++)
                                    {
                                        text2[n][i] = text[k];
                                        k++;
                                    }
                                }

                            }
                            else
                            {
                                for (int i = 0; i < text.Length; i++)
                                {
                                    text2[n][i] = text[k];
                                    k++;
                                }
                            }

                        }

                        swap(arr2, text2);
                        k = 0;
                        for (int i = 0; i < text2.Length; i++)
                        {
                            for (int j = 0; j < text2[i].Length; j++)
                            {
                                text[k] = text2[i][j];
                                k++;
                            }
                        }
                        Out = new string(text);
                    }
                }
            }
            return Out;
        }

        public static char[][] swap(int[][] arr2, char[][] text2)
        {
            for (int n = 0; n < text2.Length; n++)
            {
                if (n == arr2.Length)
                {
                    break;
                }
                else
                {
                    char temp1;
                    int temp2;
                    for (int i = 0; i < arr2[n].Length - 1; i++)
                    {
                        if (i >= arr2[n].Length)
                        {
                            continue;
                        }
                        else
                        {
                            for (int j = i + 1; j < arr2[n].Length; j++)
                            {
                                if (arr2[n][i] > arr2[n][j])
                                {
                                    temp1 = text2[n][i];
                                    text2[n][i] = text2[n][j];
                                    text2[n][j] = temp1;

                                    temp2 = arr2[n][i];
                                    arr2[n][i] = arr2[n][j];
                                    arr2[n][j] = temp2;
                                }
                            }
                        }
                    }
                }
            }
            return text2;
        }

        public static char[][] swap2(int[][] arr2, char[][] text2, char[][] text3)
        {
            for (int n = 0; n < text2.Length; n++)
            {
                if (n == arr2.Length)
                {
                    break;
                }
                else
                {
                    for (int i = 0; i < text2[n].Length; i++)
                    {
                        if (i >= arr2[n].Length)
                        {
                            continue;
                        }
                        else
                        {
                            for (int j = 0; j < arr2[n].Length; j++)
                            {
                                if (i == (arr2[n][j] - 1))
                                {
                                    text3[n][j] = text2[n][i];
                                }
                            }
                        }
                    }
                }
            }
            return text2;
        }

        public string Richelieu2(string inp) //Расшифровка Полибий
        {
            string s = textBox1.Text; // s - связана с вводимым текстом
            string skey = textBox5.Text; //skey - ключ шифрования
            char[] key = new char[skey.Length];//key - для хранения ключа и его проверок
            string Out = ""; //Строка для зашифрованной строки
            char[] text = new char[s.Length]; //Для хранения введённых символов

            if (textBox1.Text == "") //Проверка на пустое поле
            {
                MessageBox.Show("Введите текст!", "Пустое поле");
                return "";
            }
            if (textBox5.Text == "") //Проверка на пустой ключ
            {
                MessageBox.Show("Укажите ключ шифрования!", "Пустое поле");
                return "";
            }
            else
            {
                string check = "";

                check = skey;
                check = check.Replace("(", "");
                check = check.Replace(")", "");
                check = check.Replace(",", "");

                if (check.Length > s.Length)
                {
                    MessageBox.Show("Недопустимая длина ключа!", "Ключ больше сообщения");
                    return "ОШИБКА КЛЮЧА";
                }
                else
                {
                    string numbers = "123456789(),";
                    string number = "123456789";
                    string marks = "(),";



                    //Перевод ключа в char[]
                    for (int i = 0; i < skey.Length; i++)
                    {
                        key[i] = skey[i];
                    }

                    //Проверка ключа на цифры
                    bool numb;
                    for (int i = 0; i < key.Length; i++)
                    {
                        numb = false;
                        for (int j = 0; j < numbers.Length; j++)
                        {
                            if (key[i] == numbers[j])
                            {
                                numb = true;
                            }
                        }
                        if (numb == false)
                        {
                            return "Неверный ключ!";
                        }
                    }

                    //Определить число комбинаций
                    string s0 = "(";
                    int count = (skey.Length - skey.Replace(s0, "").Length) / s0.Length;

                    //Убираем запятые
                    skey = skey.Replace(",", "");

                    for (int i = 0; i < key.Length; i++)
                    {
                        if (key[0] != '(')
                        {
                            return "Некорректный ввод ключа!";
                        }
                        else if (key[key.Length - 1] != ')')
                        {
                            return "Некорректный ввод ключа!";
                        }
                        else
                        {
                            if (key[i] == '(')
                            {
                                numb = false;
                                for (int j = 0; j < number.Length; j++)
                                {
                                    if (key[i + 1] == number[j])
                                    {
                                        numb = true;
                                    }
                                }
                                if (numb == false)
                                {
                                    return "Некорректный ввод ключа!";
                                }
                            }
                            else if (key[i] == ')')
                            {
                                if (i != key.Length - 1)
                                {
                                    numb = false;
                                    for (int j = 0; j < number.Length; j++)
                                    {

                                        if (key[i + 1] == number[j])
                                        {
                                            numb = true;
                                        }
                                        else if (key[i + 1] == '(' && key[i + 2] != '(' && key[i + 2] != ')')
                                        {
                                            numb = true;
                                        }

                                    }
                                    if (numb == false)
                                    {
                                        return "Некорректный ввод ключа!";
                                    }
                                }
                                else
                                {
                                    break;
                                }

                            }
                            else if (key[i] == ',')
                            {
                                if (key[i + 1] == ',' || key[i - 1] == ',')
                                {
                                    return "Некорректный ввод ключа!";
                                }
                            }
                        }
                    }

                    //Проверяем правильность знаков
                    for (int i = 0; i < key.Length; i++)
                    {
                        if ((key[i] == '(') && (i != 0))
                        {
                            if (key[i - 1] != ')')
                            {
                                return "Некорректный ввод ключа!";
                            }
                        }
                        else if ((key[i] == ')') && (i != key.Length - 1))
                        {
                            if (key[i + 1] != '(')
                            {
                                return "Некорректный ввод ключа!";
                            }
                        }
                        else if (key[i] == ',')
                        {
                            bool numb1 = false;
                            bool numb2 = false;
                            for (int j = 0; j < number.Length; j++)
                            {
                                if (key[i + 1] == number[j])
                                {
                                    numb1 = true;
                                }
                                if (key[i - 1] == number[j])
                                {
                                    numb2 = true;
                                }
                            }
                            if (numb1 == false || numb2 == false)
                            {
                                return "Некорректный ввод ключа!";
                            }
                        }
                    }

                    for (int i = 0; i < key.Length; i++)
                    {
                        for (int j = 0; j < number.Length; j++)
                        {
                            bool mark1 = false;
                            bool mark2 = false;
                            if (key[i] == number[j])
                            {
                                for (int m = 0; m < marks.Length; m++)
                                {
                                    if (key[i - 1] == marks[m])
                                    {
                                        mark1 = true;
                                    }
                                    if (key[i + 1] == marks[m])
                                    {
                                        mark2 = true;
                                    }
                                }
                                if (mark1 == false || mark2 == false)
                                {
                                    return "Некорректный ввод ключа!";
                                }
                            }
                        }
                    }

                    //Разделяем по скобкам
                    char[] charSeparators = new char[] { '(', ')' };
                    string[] split = skey.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
                    //Создаём массивы массивов для цифр
                    int[][] arr = new int[split.Length][];//Для проверки
                    int[][] arr2 = new int[split.Length][];//Для применения
                    //переводим в int
                    for (int i = 0; i < arr.Length; i++)
                    {
                        arr[i] = split[i].ToCharArray().Select(j => int.Parse(j.ToString())).ToArray();
                    }
                    for (int i = 0; i < arr.Length; i++)
                    {
                        arr2[i] = split[i].ToCharArray().Select(j => int.Parse(j.ToString())).ToArray();
                    }

                    //Сортировка ключа для проверки
                    for (int n = 0; n < arr.Length; n++)
                    {
                        int temp;
                        for (int i = 0; i < arr[n].Length - 1; i++)
                        {
                            for (int j = i + 1; j < arr[n].Length; j++)
                            {
                                if (arr[n][i] > arr[n][j])
                                {
                                    temp = arr[n][i];
                                    arr[n][i] = arr[n][j];
                                    arr[n][j] = temp;
                                }
                            }
                        }
                    }

                    //Проверям последовательность
                    for (int n = 0; n < arr.Length; n++)
                    {
                        if (arr[n][0] == 1)
                        {
                            bool dif;
                            for (int i = 0; i < arr[n].Length - 1; i++)
                            {
                                dif = false;
                                int Dif = arr[n][i + 1] - arr[n][i];
                                if (Dif == 1)
                                {
                                    dif = true;
                                }
                                if (dif == false)
                                {
                                    return "Ключ должен начинаться с 1 и между значениями должна быть разница в единицу!";
                                }
                            }
                        }
                        else
                        {
                            return "Ключ должен начинаться с 1 и между значениями должна быть разница в единицу!";
                        }

                    }

                    //Из string в char[] текст
                    for (int i = 0; i < s.Length; i++)
                    {
                        text[i] = s[i];
                    }


                    int k = 0;
                    if (s.Length == check.Length)
                    {
                        char[][] text2 = new char[arr2.Length][];//Для разделения текста
                        char[][] text3 = new char[arr2.Length][];//Для разделения текста
                        for (int i = 0; i < text2.Length; i++)
                        {
                            text2[i] = new char[arr2[i].Length];
                            text3[i] = new char[arr2[i].Length];
                        }
                        for (int n = 0; n < text2.Length; n++)
                        {
                            for (int i = 0; i < arr2[n].Length; i++)
                            {
                                text2[n][i] = text[k];
                                text3[n][i] = text[k];
                                k++;
                            }
                        }

                        swap2(arr2, text2, text3);
                        k = 0;
                        for (int i = 0; i < text2.Length; i++)
                        {
                            for (int j = 0; j < text2[i].Length; j++)
                            {
                                text[k] = text3[i][j];
                                k++;
                            }
                        }
                        Out = new string(text);
                    }
                    else if (s.Length > check.Length)
                    {
                        int size = 0;
                        for (int i = 0; i < arr2.Length; i++)
                        {
                            size = size + arr2[i].Length;
                        }

                        char[][] text2 = new char[arr2.Length + 1][];//Для разделения текста
                        char[][] text3 = new char[arr2.Length + 1][];
                        for (int i = 0; i < text2.Length; i++)
                        {
                            if (i == arr2.Length)
                            {
                                text2[i] = new char[s.Length - size];
                                text3[i] = new char[s.Length - size];
                            }
                            else
                            {
                                text2[i] = new char[arr2[i].Length];
                                text3[i] = new char[arr2[i].Length];
                            }

                        }

                        for (int n = 0; n < text2.Length; n++)
                        {
                            if (k < skey.Length)
                            {
                                if (n < arr2.Length)
                                {
                                    for (int i = 0; i < arr2[n].Length; i++)
                                    {
                                        text2[n][i] = text[k];
                                        text3[n][i] = text[k];
                                        k++;
                                    }
                                }
                                else
                                {
                                    for (int i = 0; i < s.Length - size; i++)
                                    {
                                        text2[n][i] = text[k];
                                        text3[n][i] = text[k];
                                        k++;
                                    }
                                }

                            }
                            else
                            {
                                for (int i = 0; i < text.Length; i++)
                                {
                                    text2[n][i] = text[k];
                                    text3[n][i] = text[k];
                                    k++;
                                }
                            }

                        }

                        swap2(arr2, text2, text3);
                        k = 0;
                        for (int i = 0; i < text2.Length; i++)
                        {
                            for (int j = 0; j < text2[i].Length; j++)
                            {
                                text[k] = text3[i][j];
                                k++;
                            }
                        }
                        Out = new string(text);
                    }
                }
            }
            return Out;
        }
    }
}