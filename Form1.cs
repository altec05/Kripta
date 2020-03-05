﻿using System;
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
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        //Алфавиты
        string alRu = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        string alEn = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        string al = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюяABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        string Numbers = "1234567890!@#$%^&*()_+!~`№;%:?*-=[]{};:',./<>\0|";

        private void button1_Click(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "Шифр Атбаш":
                    textBox2.Text = Atbash1(textBox1.Text); //Зашифровать Атбаш
                    break;
                case "Шифр Цезаря":
                    textBox2.Text = Orientation(textBox1.Text); //Зашифровать Цезарь
                    break;
                case "Шифр Сцитала":
                    textBox2.Text = Scitala1(textBox1.Text); //Зашифровать Сцитала
                    break;
                case "Квадрат Полибия":
                    textBox2.Text = Polybius1(textBox1.Text); //Расшифровать Полибий
                    break;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "Шифр Атбаш":
                    textBox2.Text = Atbash2(textBox1.Text); //Расшифровать Атбаш
                    break;

                case "Шифр Цезаря":
                    textBox2.Text = Orientation2(textBox1.Text); //Расшифровать Цезарь
                    break;
                case "Шифр Сцитала":
                    textBox2.Text = Scitala2(textBox1.Text); //Зашифровать Сцитала
                    break;
                case "Квадрат Полибия":
                    textBox2.Text = Polybius2(textBox1.Text); //Зашифровать Полибий
                    break;
            }

        }

        public string Scitala1(string inp) //Шифрование Сцитала
        {
            int diameter = -1;
            StringBuilder code = new StringBuilder();
            string s = textBox1.Text; // s - связана с вводимым текстом
            string sd = textBox3.Text; //sd-диаметр
            if (textBox1.Text == "") //Проверка на пустое поле
            {
                MessageBox.Show("Введите текст!", "Пустое поле");
            }
            if (textBox3.Text == "") //Проверка на пустой ключ
            {
                MessageBox.Show("Укажите требуемый шаг!", "Пустое поле");
            }
            else
            {
                try //Отлов исключений
                {
                    diameter = Convert.ToInt32(sd); //Перевод string в int
                }
                catch
                {
                    MessageBox.Show("В строке есть недопустимые символы!", "Ошибка ввода"); //Случай, если будут лишние символы
                }
                finally
                {
                    if (diameter < 0) //Если отрицательный шаг
                    {
                        for (int i = 0; i < 1; i++)
                        {
                            MessageBox.Show("Шаг должен быть больше 0!");
                            break;
                        }
                    }
                    else if (diameter == 0) //Если 0 шаг
                    {
                        for (int i = 0; i < 1; i++)
                        {
                            MessageBox.Show("Шаг должен быть больше 0!");
                            break;
                        }
                    }
                    else
                    {
                        if (diameter >= s.Length)//Проверка на размер диаметра
                        {
                            int length = s.Length;
                            string Out = length.ToString();
                            MessageBox.Show("Диаметр должен быть меньше длины сообщения!", "Некорректный диаметр");
                            MessageBox.Show(Out, "Длина сообщения");
                        }
                        else
                        {
                            int count = 0; //Количество добавленных пробелов
                            int col = 0; //Число столбцов
                            int del = 0; //Остаток от деления
                            string open_text = s; //Строка для хранения введённого + пробелы
                            if (s.Length % diameter != 0) //Определяем столбцы
                            {
                                col = (s.Length / diameter) + 1; //Столбцов
                                del = s.Length % diameter;//Остаток
                                for (int i = 0; i < (diameter - del); i++) //Если нужны пробелы
                                {
                                    //open_text = open_text + " ";
                                    //count++;//Их число
                                }
                            }
                            else//Если не нужны
                            {
                                col = s.Length / diameter;
                            }
                            //Процес шифрования
                            int numbers = 0;
                            for (int i = 0; i < col; i++)//Проход по столбцам
                            {
                                for (int j = 0; j < diameter; j++)//Проход по символам в столбце
                                {
                                    if (open_text.Length < (col * diameter))
                                    {
                                        if (numbers >= open_text.Length)
                                        {
                                            numbers++;
                                            continue;
                                        }
                                        else
                                        {
                                            code.Append(open_text[((j * col) + i) % open_text.Length]);
                                            numbers++;
                                        }
                                    }
                                    else
                                    {
                                        code.Append(open_text[((j * col) + i) % open_text.Length]);
                                        numbers++;
                                    }


                                }
                            }
                        }
                    }
                }
            }
            return code.ToString();
        }

        public string Scitala2(string inp) //РАСШИФРОВАНИЕ Сцитала
        {
            int diameter = -1;
            StringBuilder code = new StringBuilder();
            string s = textBox1.Text; // s - связана с вводимым текстом
            string sd = textBox3.Text; //sd-диаметр
            string Out = ""; //Строка для расшифрованной строки
            var text = new char[s.Length]; //Для хранения введённых символов
            var text2 = new char[s.Length]; //Для хранения прочитанных символов
            if (textBox1.Text == "") //Проверка на пустое поле
            {
                MessageBox.Show("Введите текст!", "Пустое поле");
            }
            if (textBox3.Text == "") //Проверка на пустой ключ
            {
                MessageBox.Show("Укажите требуемый шаг!", "Пустое поле");
            }
            else
            {
                try //Отлов исключений
                {
                    diameter = Convert.ToInt32(sd); //Перевод string в int
                }
                catch
                {
                    MessageBox.Show("В строке есть недопустимые символы!", "Ошибка ввода"); //Случай, если будут лишние символы
                }
                finally
                {
                    if (diameter < 0) //Если отрицательный шаг
                    {
                        for (int i = 0; i < 1; i++)
                        {
                            MessageBox.Show("Шаг должен быть больше 0!");
                            break;
                        }
                    }
                    else if (diameter == 0) //Если 0 шаг
                    {
                        for (int i = 0; i < 1; i++)
                        {
                            MessageBox.Show("Шаг должен быть больше 0!");
                            break;
                        }
                    }
                    else
                    {
                        if (diameter >= s.Length)//Проверка на размер диаметра
                        {
                            int length = s.Length;
                            string Out1 = length.ToString();
                            MessageBox.Show("Диаметр должен быть меньше длины сообщения!", "Некорректный диаметр");
                            MessageBox.Show(Out1, "Длина сообщения");
                        }
                        else
                        {

                            int col = 0; //Число столбцов
                            int del = 0; //Остаток от деления
                            if (s.Length % diameter != 0) //Определяем столбцы
                            {
                                col = (s.Length / diameter) + 1; //Столбцов
                                del = s.Length % diameter;//Остаток
                            }
                            else//Если без остатка
                            {
                                col = s.Length / diameter;
                            }

                            for (int i = 0; i < s.Length; i++)
                            {
                                text[i] = s[i]; //Из введённой строки string в строку char[]
                                                //Нужно для дальнейшего перевода в двумерный массив и обработки
                            }

                            int numbers = 0;
                            char[,] mass = new char[col, diameter]; //Двумерный массив размером[столбцы, диаметр]
                            int t = 0; //Индекс дял перехода по text
                            for (int i = 0; i < col; i++)
                            {
                                for (int j = 0; j < diameter; j++)
                                {
                                    if (text.Length < (col * diameter))
                                    {
                                        if (numbers >= text.Length)
                                        {
                                            //numbers++;
                                            continue;
                                        }
                                        else
                                        {
                                            mass[i, j] = text[t];//Записываем из строки char[] в двумерный массив
                                            t++;
                                            numbers++;
                                        }
                                    }
                                    else
                                    {
                                        mass[i, j] = text[t];//Записываем из строки char[] в двумерный массив
                                        t++;
                                        numbers++;
                                    }
                                }
                            }

                            int k = 0;//Индекс для прохода по text2
                            int Char = 0;//Индекс для перехода на конкретную строку букв
                            for (int stroka = 0; stroka < diameter; stroka++)
                            {
                                for (int i = 0; i < col; i++)
                                {
                                    for (int j = Char; j < Char + 1; j++)
                                    {
                                        if (k < numbers)
                                        {
                                            text2[k] = mass[i, j];//Из массива в строку char[]
                                            k++;//Для перехода по строке char[]
                                        }
                                        else
                                        {
                                            break;
                                        }

                                    }
                                }
                                Char++;//Буква в массиве
                            }

                            Out = new string(text2);
                            code.Append(Out); //Для вывода строки
                        }
                    }
                }
            }
            return code.ToString();
        }

        public string Polybius1(string inp) //Шифрование Сцитала
        {
            string alRu1 = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            string alru1 = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            string alEn1 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string alen1 = "abcdefghijklmnopqrstuvwxyz";
            StringBuilder code = new StringBuilder();
            string s = textBox1.Text; // s - связана с вводимым текстом
            string skey = textBox4.Text; //skey - ключ шифрования
            char[] key = new char[skey.Length];//key - для хранения ключа и его проверок
            var text = new char[s.Length]; //Для хранения введённых символов
            //string table; //Для хранения таблицы шифрования
            int alphabet1 = 0; //Для сравнения алфавитов ключа и строки
            int alphabet2 = 0; //Для сравнения алфавитов ключа и строки
            string Out = ""; //Строка для расшифрованной строки
            var text1 = new char[s.Length]; //Для хранения введённых символов
            string s1 = "";

            if (textBox1.Text == "") //Проверка на пустое поле
            {
                MessageBox.Show("Введите текст!", "Пустое поле");
                return "";
            }
            if (textBox4.Text == "") //Проверка на пустой ключ
            {
                MessageBox.Show("Укажите ключ шифрования!", "Пустое поле");
                return "";
            }
            else
            {
                for (int i = 0; i < skey.Length; i++)//Ключ из string в char[]
                {
                    key[i] = skey[i];
                }

                bool bukva = true;

                for (int i = 0; i < key.Length; i++)//Проверка ключа
                {


                    int indexOfChar = -1;
                    indexOfChar = al.IndexOf(key[i]);
                    if (indexOfChar < 0)//Если любой из символов ключа не буква
                    {
                        MessageBox.Show("Ключ должен быть буквенным!", "Неверный ключ");
                        bukva = false;
                        return "";
                    }
                }
                if (bukva == false)
                {
                    MessageBox.Show("Тут не только буквы!", "Ошибка ключа");
                    return "";
                }//Проверка на одинаковый алфавит и регистр
                else
                {
                    int indexOfChar1 = -1;
                    int indexOfChar2 = -1;
                    int indexOfChar3 = -1;
                    int indexOfChar4 = -1;
                    indexOfChar1 = alRu1.IndexOf(key[0]);
                    indexOfChar2 = alru1.IndexOf(key[0]);
                    indexOfChar3 = alEn1.IndexOf(key[0]);
                    indexOfChar4 = alen1.IndexOf(key[0]);
                    int R1 = 0;
                    int r1 = 0;
                    int E1 = 0;
                    int e1 = 0;
                    bool Ru1 = false;
                    bool ru1 = false;
                    bool En1 = false;
                    bool en1 = false;

                    //Определение алфавита для первого символа и сравнение других
                    if (indexOfChar1 >= 0)
                    {
                        for (int i = 0; i < key.Length; i++)
                        {
                            indexOfChar1 = -1;
                            indexOfChar1 = alRu1.IndexOf(key[i]);
                            if (indexOfChar1 >= 0)
                            {
                                R1++;
                            }
                        }
                        if (R1 == key.Length)
                        {
                            Ru1 = true;
                            alphabet1 = 1;
                        }
                        else
                        {
                            Ru1 = false;
                            MessageBox.Show("Введите буквы одинакового алфавита и регистра!", "Ошибка ключа");
                            return "";
                        }
                    }
                    else if (indexOfChar2 >= 0)
                    {
                        for (int i = 0; i < key.Length; i++)
                        {
                            indexOfChar2 = -1;
                            indexOfChar2 = alru1.IndexOf(key[i]);
                            if (indexOfChar2 >= 0)
                            {
                                r1++;
                            }
                        }
                        if (r1 == key.Length)
                        {
                            ru1 = true;
                            alphabet1 = 2;
                        }
                        else
                        {
                            ru1 = false;
                            MessageBox.Show("Введите буквы одинакового алфавита и регистра!", "Ошибка ключа");
                            return "";
                        }
                    }
                    else if (indexOfChar3 >= 0)
                    {
                        for (int i = 0; i < key.Length; i++)
                        {
                            indexOfChar3 = -1;
                            indexOfChar3 = alEn1.IndexOf(key[i]);
                            if (indexOfChar3 >= 0)
                            {
                                E1++;
                            }
                        }
                        if (E1 == key.Length)
                        {
                            En1 = true;
                            alphabet1 = 3;
                        }
                        else
                        {
                            Ru1 = false;
                            MessageBox.Show("Введите буквы одинакового алфавита и регистра!", "Ошибка ключа");
                            return "";
                        }
                    }
                    else if (indexOfChar4 >= 0)
                    {
                        for (int i = 0; i < key.Length; i++)
                        {
                            indexOfChar4 = -1;
                            indexOfChar4 = alen1.IndexOf(key[i]);
                            if (indexOfChar4 >= 0)
                            {
                                e1++;
                            }
                        }
                        if (e1 == key.Length)
                        {
                            en1 = true;
                            alphabet1 = 4;
                        }
                        else
                        {
                            en1 = false;
                            MessageBox.Show("Введите буквы одинакового алфавита и регистра!", "Ошибка ключа");
                            return "";
                        }
                    }
                }

                for (int i = 0; i < s.Length; i++)//Текст из string в char[]
                {
                    text[i] = s[i];
                }
                int check = 0;
                for (int i = 0; i < s.Length; i++)//Число подходящих символов
                {
                    int indexOfChar = -1;
                    indexOfChar = al.IndexOf(s[i]);
                    if (indexOfChar >= 0)
                    {
                        check++;
                    }
                }
                int j = 0;
                var text_check = new char[check];//Для хранения строки для проверки
                for (int i = 0; i < s.Length; i++)//Текст из string в char[] для проверки алфавита и регистра
                {
                    int indexOfChar = -1;
                    indexOfChar = al.IndexOf(s[i]);
                    if (indexOfChar >= 0)
                    {
                        text_check[j] = s[i];
                        j++;
                    }
                }

                //Проверка text_check на регистр и алфавит
                int indexOfChar5 = -1;
                int indexOfChar6 = -1;
                int indexOfChar7 = -1;
                int indexOfChar8 = -1;
                indexOfChar5 = alRu1.IndexOf(key[0]);
                indexOfChar6 = alru1.IndexOf(key[0]);
                indexOfChar7 = alEn1.IndexOf(key[0]);
                indexOfChar8 = alen1.IndexOf(key[0]);
                int R = 0;
                int r = 0;
                int E = 0;
                int e = 0;
                bool Ru2 = false;
                bool ru2 = false;
                bool En2 = false;
                bool en2 = false;

                //Определение алфавита для первого символа и сравнение других
                if (indexOfChar5 >= 0)
                {
                    for (int i = 0; i < text_check.Length; i++)
                    {
                        indexOfChar5 = -1;
                        indexOfChar5 = alRu1.IndexOf(text_check[i]);
                        if (indexOfChar5 >= 0)
                        {
                            R++;
                        }
                    }
                    if (R == text_check.Length)
                    {
                        Ru2 = true;
                        alphabet2 = 1;
                    }
                    else
                    {
                        Ru2 = false;
                        MessageBox.Show("В строке должны быть буквы одинакового регистра и алфавита!", "Некорректная строка");
                        return "";
                    }
                }
                else if (indexOfChar6 >= 0)
                {
                    for (int i = 0; i < text_check.Length; i++)
                    {
                        indexOfChar6 = -1;
                        indexOfChar6 = alru1.IndexOf(text_check[i]);
                        if (indexOfChar6 >= 0)
                        {
                            r++;
                        }
                    }
                    if (r == text_check.Length)
                    {
                        ru2 = true;
                        alphabet2 = 2;
                    }
                    else
                    {
                        ru2 = false;
                        MessageBox.Show("В строке должны быть буквы одинакового регистра и алфавита!", "Некорректная строка");
                        return "";
                    }
                }
                else if (indexOfChar7 >= 0)
                {
                    for (int i = 0; i < text_check.Length; i++)
                    {
                        indexOfChar7 = -1;
                        indexOfChar7 = alEn1.IndexOf(text_check[i]);
                        if (indexOfChar7 >= 0)
                        {
                            E++;
                        }
                    }
                    if (E == text_check.Length)
                    {
                        En2 = true;
                        alphabet2 = 3;
                    }
                    else
                    {
                        Ru2 = false;
                        MessageBox.Show("В строке должны быть буквы одинакового регистра и алфавита!", "Некорректная строка");
                        return "";
                    }
                }
                else if (indexOfChar8 >= 0)
                {
                    for (int i = 0; i < text_check.Length; i++)
                    {
                        indexOfChar8 = -1;
                        indexOfChar8 = alen1.IndexOf(text_check[i]);
                        if (indexOfChar8 >= 0)
                        {
                            e++;
                        }
                    }
                    if (e == text_check.Length)
                    {
                        en2 = true;
                        alphabet2 = 4;
                    }
                    else
                    {
                        en2 = false;
                        MessageBox.Show("В строке должны быть буквы одинакового регистра и алфавита!", "Некорректная строка");
                        return "";
                    }
                }
                
                for (int S = 0; S < s.Length; S++)
                {//ПРОВЕРКА НА БУКВУ
                    int index = -1;
                    index = al.IndexOf(s[S]);
                    if (index < 0)
                    {
                        text1[S] = s[S];
                        Out = new string(text1);
                        
                    }
                    else
                    {
                        //Создаём массив для квадрата Полибия
                        char[,] mass;
                        switch (alphabet1)
                        {
                            case 1://Русские большие
                                mass = new char[6, 6];
                                string t = skey + alRu1;
                                for (int i = 0; i < skey.Length; i++)
                                {
                                    int indexOfChar = -1;
                                    indexOfChar = t.LastIndexOf(skey[i]);
                                    if (indexOfChar >= 0)
                                    {
                                        t = t.Remove(indexOfChar, 1);
                                    }
                                }
                                var table = new char[t.Length];
                                for (int i = 0; i < t.Length; i++)//Текст из string в char[]
                                {
                                    table[i] = t[i];
                                }

                                int k = 0;
                                for (int i = 0; i < 6; i++)
                                {
                                    for (int n = 0; n < 6; n++)
                                    {
                                        if (k > 32)
                                        {
                                            k++;
                                            continue;
                                        }
                                        else
                                        {
                                            mass[i, n] = table[k];
                                            k++;
                                        }
                                    }
                                }

                                int column = 0;
                                int row = 0;

                                for (int m = 0; m < 6; m++)
                                {
                                    for (int n = 0; n < 6; n++)
                                    {
                                        if(S == 6)
                                        {
                                            if (s[S - 1] == mass[m, n])
                                            {
                                                row = m;
                                                column = n;
                                            }
                                        }
                                        else
                                        {
                                            if (s[S] == mass[m, n])
                                            {
                                                row = m;
                                                column = n;
                                            }
                                        }
                                        
                                    }
                                }

                                if (row < 5)
                                {
                                    if((row == 4)&&(column > 2))
                                    {
                                        row = 0;
                                        text1[S] = mass[row, column];
                                    }
                                    else
                                    {
                                        text1[S] = mass[row + 1, column];
                                    }
                                }
                                else
                                {
                                    row = 0;
                                    text1[S] = mass[row, column];
                                }


                                Out = new string(text1);//Для вывода строки
                               //code.Append(text1); //Для вывода строки
                                break;
                            case 2://Русские маленькие
                                mass = new char[6, 6];
                                t = skey + alru1;
                                for (int i = 0; i < skey.Length; i++)
                                {
                                    int indexOfChar = -1;
                                    indexOfChar = t.LastIndexOf(skey[i]);
                                    if (indexOfChar >= 0)
                                    {
                                        t = t.Remove(indexOfChar, 1);
                                    }
                                }
                                table = new char[t.Length];
                                for (int i = 0; i < t.Length; i++)//Текст из string в char[]
                                {
                                    table[i] = t[i];
                                }

                                k = 0;
                                for (int i = 0; i < 6; i++)
                                {
                                    for (int n = 0; n < 6; n++)
                                    {
                                        if (k > 32)
                                        {
                                            k++;
                                            continue;
                                        }
                                        else
                                        {
                                            mass[i, n] = table[k];
                                            k++;
                                        }
                                    }
                                }

                                column = 0;
                                row = 0;

                                for (int m = 0; m < 6; m++)
                                {
                                    for (int n = 0; n < 6; n++)
                                    {
                                        if (S == 6)
                                        {
                                            if (s[S - 1] == mass[m, n])
                                            {
                                                row = m;
                                                column = n;
                                            }
                                        }
                                        else
                                        {
                                            if (s[S] == mass[m, n])
                                            {
                                                row = m;
                                                column = n;
                                            }
                                        }

                                    }
                                }

                                if (row < 5)
                                {
                                    if ((row == 4) && (column > 2))
                                    {
                                        row = 0;
                                        text1[S] = mass[row, column];
                                    }
                                    else
                                    {
                                        text1[S] = mass[row + 1, column];
                                    }
                                }
                                else
                                {
                                    row = 0;
                                    text1[S] = mass[row, column];
                                }


                                Out = new string(text1);//Для вывода строки
                                break;
                            case 3:
                                mass = new char[5, 5];
                                t = skey + alEn1;
                                for (int i = 0; i < skey.Length; i++)
                                {
                                    int indexOfChar = -1;
                                    indexOfChar = t.LastIndexOf(skey[i]);
                                    if (indexOfChar >= 0)
                                    {
                                        t = t.Remove(indexOfChar, 1);
                                    }
                                }

                                index = -1;
                                index = t.LastIndexOf('J');
                                if (index >= 0)
                                {
                                    t = t.Remove(index, 1);
                                }

                                table = new char[t.Length];

                                for (int i = 0; i < t.Length; i++)//Текст из string в char[]
                                {
                                    table[i] = t[i];
                                }

                                k = 0;
                                for (int i = 0; i < 5; i++)
                                {
                                    for (int n = 0; n < 5; n++)
                                    {
                                        mass[i, n] = table[k];
                                        k++;
                                    }
                                }

                                column = 0;
                                row = 0;

                                for (int m = 0; m < 5; m++)
                                {
                                    for (int n = 0; n < 5; n++)
                                    {
                                        if (s[S] == 'J')
                                        {
                                            if(mass[m,n] == 'I')
                                            {
                                                row = m;
                                                column = n;
                                            }
                                        }
                                        else
                                        {
                                            if (s[S] == mass[m, n])
                                            {
                                                row = m;
                                                column = n;
                                            }
                                        }
                                    }
                                }

                                if (row < 4)
                                {
                                    text1[S] = mass[row + 1, column];
                                }
                                else
                                {
                                    row = 0;
                                    text1[S] = mass[row, column];
                                }


                                Out = new string(text1);//Для вывода строки
                                break;
                            case 4:
                                mass = new char[5, 5];
                                t = skey + alen1;
                                for (int i = 0; i < skey.Length; i++)
                                {
                                    int indexOfChar = -1;
                                    indexOfChar = t.LastIndexOf(skey[i]);
                                    if (indexOfChar >= 0)
                                    {
                                        t = t.Remove(indexOfChar, 1);
                                    }
                                }

                                index = -1;
                                index = t.LastIndexOf('j');
                                if (index >= 0)
                                {
                                    t = t.Remove(index, 1);
                                }

                                table = new char[t.Length];

                                for (int i = 0; i < t.Length; i++)//Текст из string в char[]
                                {
                                    table[i] = t[i];
                                }
                                k = 0;
                                for (int i = 0; i < 5; i++)
                                {
                                    for (int n = 0; n < 5; n++)
                                    {
                                            mass[i, n] = table[k];
                                            k++;
                                    }
                                }

                                column = 0;
                                row = 0;

                                for (int m = 0; m < 5; m++)
                                {
                                    for (int n = 0; n < 5; n++)
                                    {
                                        if (s[S] == 'j')
                                        {
                                            if (mass[m, n] == 'i')
                                            {
                                                row = m;
                                                column = n;
                                            }
                                        }
                                        else
                                        {
                                            if (s[S] == mass[m, n])
                                            {
                                                row = m;
                                                column = n;
                                            }
                                        }
                                    }
                                }

                                if (row < 4)
                                {
                                    text1[S] = mass[row + 1, column];
                                }
                                else
                                {
                                    row = 0;
                                    text1[S] = mass[row, column];
                                }


                                Out = new string(text1);//Для вывода строки
                                break;
                        }
                    }
                    

                }


                ////Создаём массив для квадрата Полибия
                //char[,] mass;
                ////Создаём массивы для индексов букв вводимого текста
                //int[,] index1 = new int[s.Length, 2];
                //int[,] index2 = new int[s.Length, 2];
                //int[] index12;

                //switch (alphabet1)
                //{
                //    case 1://Русские большие
                //        mass = new char[6,6];
                //        string t = skey + alRu1;
                //        for (int i = 0; i < skey.Length; i++)
                //        {
                //            int indexOfChar = -1;
                //            indexOfChar = t.LastIndexOf(skey[i]);
                //            if (indexOfChar >= 0)
                //            {
                //                t = t.Remove(indexOfChar, 1);
                //            }
                //        }
                //        var table = new char[t.Length];
                //        for (int i = 0; i < t.Length; i++)//Текст из string в char[]
                //        {
                //            table[i] = t[i];
                //        }

                //        int k = 0;
                //        for (int i = 0; i < 6; i++)
                //        {
                //            for (int n = 0; n < 6; n++)
                //            {
                //                if(k > 32)
                //                {
                //                    if(k == 33)
                //                    {
                //                        mass[i, n] = '.';
                //                        k++;
                //                    }
                //                    else if (k == 34)
                //                    {
                //                        mass[i, n] = ',';
                //                        k++;
                //                    }else if (k == 35)
                //                    {
                //                        mass[i, n] = '?';
                //                        k++;
                //                    }
                //                }
                //                else
                //                {
                //                    mass[i, n] = table[k];
                //                    k++;
                //                }
                //            }
                //        }
                //        int ind1 = 0;
                //        //Ищем индексы введённого текста
                //        for (k = 0; k < s.Length; k++)
                //        {
                //            for (int i = 0; i < 6; i++)
                //            {
                //                for (int n = 0; n < 6; n++)
                //                {
                //                    if (s[k] == mass[i, n])
                //                    {
                //                        index1[ind1, 1] = i;
                //                        index1[ind1, 0] = n;
                //                        ind1++;
                //                    }
                //                }
                //            }
                //        }

                //        k = 0;
                //        index12 = new int[s.Length * 2];
                //        //Преобразуем координаты
                //        for(int i = 0; i < s.Length; i++)//Первая строка
                //        {
                //            index12[k] = index1[i, 0];
                //            k++;
                //        }
                //        for (int i = 0; i < s.Length; i++)//Вторая строка
                //        {
                //            index12[k] = index1[i, 1];
                //            k++;
                //        }
                //        //Заполняем
                //        k = 0;
                //        for(int i = 0; i < s.Length; i++)
                //        {
                //            for (int l = 0; l < 2; l++)
                //            {
                //                index2[i, l] = index12[k];
                //                k++;
                //            }
                //        }
                //        //Ищем буквы по индексам
                //        int g = 0;
                //        for (int i = 0; i < s.Length; i++)
                //        {
                //            text1[i] = mass[index2[g,1],index2[g,0]];
                //            g++;
                //        }
                //        Out = new string(text1);//Для вывода строки
                //        code.Append(Out); //Для вывода строки
                //        break;
                //    case 2://Русские маленькие
                //        mass = new char[6,6];
                //        t = skey + alru1;
                //        for (int i = 0; i < skey.Length; i++)
                //        {
                //            int indexOfChar = -1;
                //            indexOfChar = t.LastIndexOf(skey[i]);
                //            if (indexOfChar >= 0)
                //            {
                //                t = t.Remove(indexOfChar, 1);
                //            }
                //        }
                //        table = new char[t.Length];
                //        for (int i = 0; i < t.Length; i++)//Текст из string в char[]
                //        {
                //            table[i] = t[i];
                //        }

                //        k = 0;
                //        for (int i = 0; i < 6; i++)//Заполнение таблицы шифрования
                //        {
                //            for (int n = 0; n < 6; n++)
                //            {
                //                if (k > 32)
                //                {
                //                    if (k == 33)
                //                    {
                //                        mass[i, n] = '.';
                //                        k++;
                //                    }
                //                    else if (k == 34)
                //                    {
                //                        mass[i, n] = ',';
                //                        k++;
                //                    }
                //                    else if (k == 35)
                //                    {
                //                        mass[i, n] = '?';
                //                        k++;
                //                    }
                //                }
                //                else
                //                {
                //                    mass[i, n] = table[k];
                //                    k++;
                //                }
                //            }
                //        }

                //        ind1 = 0;
                //        //Ищем индексы введённого текста
                //        for (k = 0; k < s.Length; k++)
                //        {
                //            for (int i = 0; i < 6; i++)
                //            {
                //                for (int n = 0; n < 6; n++)
                //                {
                //                    if (s[k] == mass[i, n])
                //                    {
                //                        index1[ind1, 1] = i;
                //                        index1[ind1, 0] = n;
                //                        ind1++;
                //                    }
                //                }
                //            }
                //        }

                //        k = 0;
                //        index12 = new int[s.Length * 2];
                //        //Преобразуем координаты
                //        for (int i = 0; i < s.Length; i++)//Первая строка
                //        {
                //            index12[k] = index1[i, 0];
                //            k++;
                //        }
                //        for (int i = 0; i < s.Length; i++)//Вторая строка
                //        {
                //            index12[k] = index1[i, 1];
                //            k++;
                //        }
                //        //Заполняем
                //        k = 0;
                //        for (int i = 0; i < s.Length; i++)
                //        {
                //            for (int l = 0; l < 2; l++)
                //            {
                //                index2[i, l] = index12[k];
                //                k++;
                //            }
                //        }
                //        //Ищем буквы по индексам
                //        g = 0;
                //        for (int i = 0; i < s.Length; i++)
                //        {
                //            text1[i] = mass[index2[g, 1], index2[g, 0]];
                //            g++;
                //        }
                //        Out = new string(text1);//Для вывода строки
                //        break;
                //    case 3:
                //        mass = new char[5,5];
                //        t = skey + alEn1;
                //        for (int i = 0; i < skey.Length; i++)
                //        {
                //            int indexOfChar = -1;
                //            indexOfChar = t.LastIndexOf(skey[i]);
                //            if (indexOfChar >= 0)
                //            {
                //                t = t.Remove(indexOfChar, 1);
                //            }
                //        }

                //        int index = -1;
                //        index = t.LastIndexOf('J');
                //        if (index >= 0)
                //        {
                //            t = t.Remove(index, 1);
                //        }

                //        table = new char[t.Length];

                //        for (int i = 0; i < t.Length; i++)//Текст из string в char[]
                //        {
                //            table[i] = t[i];
                //        }

                //        k = 0;
                //        for (int i = 0; i < 5; i++)//Заполнение таблицы шифрования
                //        {
                //            for (int n = 0; n < 5; n++)
                //            {
                //                mass[i, n] = table[k];
                //                k++;
                //            }
                //        }

                //        int count = 0; //Считаем число "НЕБУКВ"
                //        for (int i = 0; i < s.Length; i++)
                //        {
                //            int indexOfCh = -1;
                //            for (int J = 0; J < al.Length; J++)
                //            {
                //                indexOfCh = al.IndexOf(s[i]);
                //            }
                //            if (indexOfCh >= 0)
                //            {
                //                count++;
                //            }
                //        }
                //        ////Находим индексы "НЕБУКВ"
                //        int[] index3 = new int[count+1];
                //        //int I = 0;
                //        //for (int i = 0; i < s.Length; i++)
                //        //{
                //        //    int indexOfCh = -1;
                //        //    for (int J = 0; J < al.Length; J++)
                //        //    {
                //        //        indexOfCh = al.IndexOf(s[i]);
                //        //    }
                //        //    if (indexOfCh < 0)
                //        //    {
                //        //        index3[I] = i;
                //        //        I++;
                //        //    }
                //        //}
                //        //s1 = s;
                //        //for(int i = 0; i < index3.Length; i++)
                //        //{
                //        //    s = s.Remove(index3[i], 1);
                //        //}


                //        ind1 = 0;
                //        int f = 0;
                //        //Ищем индексы введённого текста
                //        for (k = 0; k < s.Length; k++)
                //        {
                //            int indexOfCh = -1;//Проверка на букву
                //            for (int J = 0; J < al.Length; J++)
                //            {
                //                indexOfCh = al.IndexOf(s[k]);
                //            }
                //            if (indexOfCh < 0)
                //            {
                //                index3[f] = k;
                //                f++;

                //                continue;
                //            }
                //            else
                //            {
                //                for (int i = 0; i < 5; i++)
                //                {
                //                    for (int n = 0; n < 5; n++)
                //                    {

                //                        if (s[k] == mass[i, n])
                //                        {/////////////////////поменял индексы
                //                            index1[ind1, 1] = i;
                //                            index1[ind1, 0] = n;
                //                            ind1++;
                //                        }
                //                        else if (s[k] == 'J')
                //                        {
                //                            if (mass[i, n] == 'I')
                //                            {
                //                                index1[ind1, 1] = i;
                //                                index1[ind1, 0] = n;
                //                                ind1++;
                //                            }
                //                        }
                //                    }
                //                }
                //            }

                //        }

                //        k = 0;
                //        index12 = new int[s.Length * 2];
                //        //Преобразуем координаты
                //        for (int i = 0; i < s.Length; i++)//Первая строка
                //        {
                //            index12[k] = index1[i, 0];
                //            k++;
                //        }
                //        for (int i = 0; i < s.Length; i++)//Вторая строка
                //        {
                //            index12[k] = index1[i, 1];
                //            k++;
                //        }
                //        //Заполняем
                //        k = 0;
                //        for (int i = 0; i < s.Length; i++)
                //        {
                //            for (int l = 0; l < 2; l++)
                //            {
                //                index2[i, l] = index12[k];
                //                k++;
                //            }
                //        }
                //        //Ищем буквы по индексам
                //        g = 0;
                //        for (int i = 0; i < s.Length; i++)
                //        {
                //            text1[i] = mass[index2[g, 1], index2[g, 0]];
                //            g++;
                //        }
                //        Out = new string(text1);//Для вывода строки
                //        break;
                //    case 4:
                //        mass = new char[5,5];
                //        t = skey + alen1;
                //        for (int i = 0; i < skey.Length; i++)
                //        {
                //            int indexOfChar = -1;
                //            indexOfChar = t.LastIndexOf(skey[i]);
                //            if (indexOfChar >= 0)
                //            {
                //                t = t.Remove(indexOfChar, 1);
                //            }
                //        }

                //        index = -1;
                //        index = t.LastIndexOf('j');
                //        if (index >= 0)
                //        {
                //            t = t.Remove(index, 1);
                //        }

                //        table = new char[t.Length];

                //        for (int i = 0; i < t.Length; i++)//Текст из string в char[]
                //        {
                //            table[i] = t[i];
                //        }
                //        k = 0;
                //        for (int i = 0; i < 5; i++)//Заполнение таблицы шифрования
                //        {
                //            for (int n = 0; n < 5; n++)
                //            {
                //                mass[i, n] = table[k];
                //                k++;
                //            }
                //        }

                //        ind1 = 0;
                //        //Ищем индексы введённого текста
                //        for (k = 0; k < s.Length; k++)
                //        {
                //            for (int i = 0; i < 5; i++)
                //            {
                //                for (int n = 0; n < 5; n++)
                //                {
                //                    if (s[k] == mass[i, n])
                //                    {/////////////////////поменял индексы
                //                        index1[ind1, 1] = i;
                //                        index1[ind1, 0] = n;
                //                        ind1++;
                //                    }
                //                    else if (s[k] == 'j')
                //                    {
                //                        if (mass[i, n] == 'i')
                //                        {
                //                            index1[ind1, 1] = i;
                //                            index1[ind1, 0] = n;
                //                            ind1++;
                //                        }
                //                    }
                //                }
                //            }
                //        }

                //        k = 0;
                //        index12 = new int[s.Length * 2];
                //        //Преобразуем координаты
                //        for (int i = 0; i < s.Length; i++)//Первая строка
                //        {
                //            index12[k] = index1[i, 0];
                //            k++;
                //        }
                //        for (int i = 0; i < s.Length; i++)//Вторая строка
                //        {
                //            index12[k] = index1[i, 1];
                //            k++;
                //        }
                //        //Заполняем
                //        k = 0;
                //        for (int i = 0; i < s.Length; i++)
                //        {
                //            for (int l = 0; l < 2; l++)
                //            {
                //                index2[i, l] = index12[k];
                //                k++;
                //            }
                //        }
                //        //Ищем буквы по индексам
                //        g = 0;
                //        for (int i = 0; i < s.Length; i++)
                //        {
                //            text1[i] = mass[index2[g, 1], index2[g, 0]];
                //            g++;
                //        }
                //        Out = new string(text1);//Для вывода строки
                //        break;
                //}

            }
            return Out;//code.ToString();
        }

        public string Polybius2(string inp) //Расшифровка Полибий
        {
            string alRu1 = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            string alru1 = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            string alEn1 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string alen1 = "abcdefghijklmnopqrstuvwxyz";
            StringBuilder code = new StringBuilder();
            string s = textBox1.Text; // s - связана с вводимым текстом
            string skey = textBox4.Text; //skey - ключ шифрования
            char[] key = new char[skey.Length];//key - для хранения ключа и его проверок
            var text = new char[s.Length]; //Для хранения введённых символов
            //string table; //Для хранения таблицы шифрования
            int alphabet1 = 0; //Для сравнения алфавитов ключа и строки
            int alphabet2 = 0; //Для сравнения алфавитов ключа и строки
            string Out = ""; //Строка для расшифрованной строки
            var text1 = new char[s.Length]; //Для хранения введённых символов

            if (textBox1.Text == "") //Проверка на пустое поле
            {
                MessageBox.Show("Введите текст!", "Пустое поле");
                return "";
            }
            //if (textBox4.Text == "") //Проверка на пустой ключ
            //{
            //    MessageBox.Show("Укажите ключ шифрования!", "Пустое поле");
            //    return "";
            //}
            else
            {
                for (int i = 0; i < skey.Length; i++)//Ключ из string в char[]
                {
                    key[i] = skey[i];
                }

                bool bukva = true;

                for (int i = 0; i < key.Length; i++)//Проверка ключа
                {


                    int indexOfChar = -1;
                    indexOfChar = al.IndexOf(key[i]);
                    if (indexOfChar < 0)//Если любой из символов ключа не буква
                    {
                        MessageBox.Show("Ключ должен быть буквенным!", "Неверный ключ");
                        bukva = false;
                        return "";
                    }
                }
                if (bukva == false)
                {
                    MessageBox.Show("Тут не только буквы!", "Ошибка ключа");
                    return "";
                }//Проверка на одинаковый алфавит и регистр
                else
                {
                    int indexOfChar1 = -1;
                    int indexOfChar2 = -1;
                    int indexOfChar3 = -1;
                    int indexOfChar4 = -1;
                    indexOfChar1 = alRu1.IndexOf(key[0]);
                    indexOfChar2 = alru1.IndexOf(key[0]);
                    indexOfChar3 = alEn1.IndexOf(key[0]);
                    indexOfChar4 = alen1.IndexOf(key[0]);
                    int R1 = 0;
                    int r1 = 0;
                    int E1 = 0;
                    int e1 = 0;
                    bool Ru1 = false;
                    bool ru1 = false;
                    bool En1 = false;
                    bool en1 = false;

                    //Определение алфавита для первого символа и сравнение других
                    if (indexOfChar1 >= 0)
                    {
                        for (int i = 0; i < key.Length; i++)
                        {
                            indexOfChar1 = -1;
                            indexOfChar1 = alRu1.IndexOf(key[i]);
                            if (indexOfChar1 >= 0)
                            {
                                R1++;
                            }
                        }
                        if (R1 == key.Length)
                        {
                            Ru1 = true;
                            alphabet1 = 1;
                        }
                        else
                        {
                            Ru1 = false;
                            MessageBox.Show("Введите буквы одинакового алфавита и регистра!", "Ошибка ключа");
                            return "";
                        }
                    }
                    else if (indexOfChar2 >= 0)
                    {
                        for (int i = 0; i < key.Length; i++)
                        {
                            indexOfChar2 = -1;
                            indexOfChar2 = alru1.IndexOf(key[i]);
                            if (indexOfChar2 >= 0)
                            {
                                r1++;
                            }
                        }
                        if (r1 == key.Length)
                        {
                            ru1 = true;
                            alphabet1 = 2;
                        }
                        else
                        {
                            ru1 = false;
                            MessageBox.Show("Введите буквы одинакового алфавита и регистра!", "Ошибка ключа");
                            return "";
                        }
                    }
                    else if (indexOfChar3 >= 0)
                    {
                        for (int i = 0; i < key.Length; i++)
                        {
                            indexOfChar3 = -1;
                            indexOfChar3 = alEn1.IndexOf(key[i]);
                            if (indexOfChar3 >= 0)
                            {
                                E1++;
                            }
                        }
                        if (E1 == key.Length)
                        {
                            En1 = true;
                            alphabet1 = 3;
                        }
                        else
                        {
                            Ru1 = false;
                            MessageBox.Show("Введите буквы одинакового алфавита и регистра!", "Ошибка ключа");
                            return "";
                        }
                    }
                    else if (indexOfChar4 >= 0)
                    {
                        for (int i = 0; i < key.Length; i++)
                        {
                            indexOfChar4 = -1;
                            indexOfChar4 = alen1.IndexOf(key[i]);
                            if (indexOfChar4 >= 0)
                            {
                                e1++;
                            }
                        }
                        if (e1 == key.Length)
                        {
                            en1 = true;
                            alphabet1 = 4;
                        }
                        else
                        {
                            en1 = false;
                            MessageBox.Show("Введите буквы одинакового алфавита и регистра!", "Ошибка ключа");
                            return "";
                        }
                    }
                }

                for (int i = 0; i < s.Length; i++)//Текст из string в char[]
                {
                    text[i] = s[i];
                }
                int check = 0;
                for (int i = 0; i < s.Length; i++)//Число подходящих символов
                {
                    int indexOfChar = -1;
                    indexOfChar = al.IndexOf(s[i]);
                    if (indexOfChar >= 0)
                    {
                        check++;
                    }
                }
                int j = 0;
                var text_check = new char[check];//Для хранения строки для проверки
                for (int i = 0; i < s.Length; i++)//Текст из string в char[] для проверки алфавита и регистра
                {
                    int indexOfChar = -1;
                    indexOfChar = al.IndexOf(s[i]);
                    if (indexOfChar >= 0)
                    {
                        text_check[j] = s[i];
                        j++;
                    }
                }

                //Проверка text_check на регистр и алфавит
                int indexOfChar5 = -1;
                int indexOfChar6 = -1;
                int indexOfChar7 = -1;
                int indexOfChar8 = -1;
                indexOfChar5 = alRu1.IndexOf(key[0]);
                indexOfChar6 = alru1.IndexOf(key[0]);
                indexOfChar7 = alEn1.IndexOf(key[0]);
                indexOfChar8 = alen1.IndexOf(key[0]);
                int R = 0;
                int r = 0;
                int E = 0;
                int e = 0;
                bool Ru2 = false;
                bool ru2 = false;
                bool En2 = false;
                bool en2 = false;

                //Определение алфавита для первого символа и сравнение других
                if (indexOfChar5 >= 0)
                {
                    for (int i = 0; i < text_check.Length; i++)
                    {
                        indexOfChar5 = -1;
                        indexOfChar5 = alRu1.IndexOf(text_check[i]);
                        if (indexOfChar5 >= 0)
                        {
                            R++;
                        }
                    }
                    if (R == text_check.Length)
                    {
                        Ru2 = true;
                        alphabet2 = 1;
                    }
                    else
                    {
                        Ru2 = false;
                        MessageBox.Show("В строке должны быть буквы одинакового регистра и алфавита!", "Некорректная строка");
                        return "";
                    }
                }
                else if (indexOfChar6 >= 0)
                {
                    for (int i = 0; i < text_check.Length; i++)
                    {
                        indexOfChar6 = -1;
                        indexOfChar6 = alru1.IndexOf(text_check[i]);
                        if (indexOfChar6 >= 0)
                        {
                            r++;
                        }
                    }
                    if (r == text_check.Length)
                    {
                        ru2 = true;
                        alphabet2 = 2;
                    }
                    else
                    {
                        ru2 = false;
                        MessageBox.Show("В строке должны быть буквы одинакового регистра и алфавита!", "Некорректная строка");
                        return "";
                    }
                }
                else if (indexOfChar7 >= 0)
                {
                    for (int i = 0; i < text_check.Length; i++)
                    {
                        indexOfChar7 = -1;
                        indexOfChar7 = alEn1.IndexOf(text_check[i]);
                        if (indexOfChar7 >= 0)
                        {
                            E++;
                        }
                    }
                    if (E == text_check.Length)
                    {
                        En2 = true;
                        alphabet2 = 3;
                    }
                    else
                    {
                        Ru2 = false;
                        MessageBox.Show("В строке должны быть буквы одинакового регистра и алфавита!", "Некорректная строка");
                        return "";
                    }
                }
                else if (indexOfChar8 >= 0)
                {
                    for (int i = 0; i < text_check.Length; i++)
                    {
                        indexOfChar8 = -1;
                        indexOfChar8 = alen1.IndexOf(text_check[i]);
                        if (indexOfChar8 >= 0)
                        {
                            e++;
                        }
                    }
                    if (e == text_check.Length)
                    {
                        en2 = true;
                        alphabet2 = 4;
                    }
                    else
                    {
                        en2 = false;
                        MessageBox.Show("В строке должны быть буквы одинакового регистра и алфавита!", "Некорректная строка");
                        return "";
                    }
                }
                for (int S = 0; S < s.Length; S++)
                {//ПРОВЕРКА НА БУКВУ
                    int index = -1;
                    index = al.IndexOf(s[S]);
                    if (index < 0)
                    {
                        text1[S] = s[S];
                        Out = new string(text1);

                    }
                    else
                    {
                        //Создаём массив для квадрата Полибия
                        char[,] mass;
                        switch (alphabet1)
                        {
                            case 1://Русские большие
                                mass = new char[6, 6];
                                string t = skey + alRu1;
                                for (int i = 0; i < skey.Length; i++)
                                {
                                    int indexOfChar = -1;
                                    indexOfChar = t.LastIndexOf(skey[i]);
                                    if (indexOfChar >= 0)
                                    {
                                        t = t.Remove(indexOfChar, 1);
                                    }
                                }
                                var table = new char[t.Length];
                                for (int i = 0; i < t.Length; i++)//Текст из string в char[]
                                {
                                    table[i] = t[i];
                                }

                                int k = 0;
                                for (int i = 0; i < 6; i++)
                                {
                                    for (int n = 0; n < 6; n++)
                                    {
                                        if (k > 32)
                                        {
                                            k++;
                                            continue;
                                        }
                                        else
                                        {
                                            mass[i, n] = table[k];
                                            k++;
                                        }
                                    }
                                }

                                int column = 0;
                                int row = 0;

                                for (int m = 0; m < 6; m++)
                                {
                                    for (int n = 0; n < 6; n++)
                                    {
                                        if (S == 6)
                                        {
                                            if (s[S - 1] == mass[m, n])
                                            {
                                                row = m;
                                                column = n;
                                            }
                                        }
                                        else
                                        {
                                            if (s[S] == mass[m, n])
                                            {
                                                row = m;
                                                column = n;
                                            }
                                        }

                                    }
                                }

                                if (row == 0)
                                {
                                    if (column > 2)
                                    {
                                        row = 4;
                                        text1[S] = mass[row, column];
                                    }
                                    else
                                    {
                                        row = 5;
                                        text1[S] = mass[row, column];
                                    }
                                }
                                else
                                {
                                    text1[S] = mass[row - 1, column];
                                }


                                Out = new string(text1);//Для вывода строки
                                                        //code.Append(text1); //Для вывода строки
                                break;
                            case 2://Русские маленькие
                                mass = new char[6, 6];
                                t = skey + alru1;
                                for (int i = 0; i < skey.Length; i++)
                                {
                                    int indexOfChar = -1;
                                    indexOfChar = t.LastIndexOf(skey[i]);
                                    if (indexOfChar >= 0)
                                    {
                                        t = t.Remove(indexOfChar, 1);
                                    }
                                }
                                table = new char[t.Length];
                                for (int i = 0; i < t.Length; i++)//Текст из string в char[]
                                {
                                    table[i] = t[i];
                                }

                                k = 0;
                                for (int i = 0; i < 6; i++)
                                {
                                    for (int n = 0; n < 6; n++)
                                    {
                                        if (k > 32)
                                        {
                                            k++;
                                            continue;
                                        }
                                        else
                                        {
                                            mass[i, n] = table[k];
                                            k++;
                                        }
                                    }
                                }

                                column = 0;
                                row = 0;

                                for (int m = 0; m < 6; m++)
                                {
                                    for (int n = 0; n < 6; n++)
                                    {
                                        if (S == 6)
                                        {
                                            if (s[S - 1] == mass[m, n])
                                            {
                                                row = m;
                                                column = n;
                                            }
                                        }
                                        else
                                        {
                                            if (s[S] == mass[m, n])
                                            {
                                                row = m;
                                                column = n;
                                            }
                                        }

                                    }
                                }

                                if (row == 0)
                                {
                                    if (column > 2)
                                    {
                                        row = 4;
                                        text1[S] = mass[row, column];
                                    }
                                    else
                                    {
                                        row = 5;
                                        text1[S] = mass[row, column];
                                    }
                                }
                                else
                                {
                                    text1[S] = mass[row - 1, column];
                                }


                                Out = new string(text1);//Для вывода строки
                                break;
                            case 3:
                                mass = new char[5, 5];
                                t = skey + alEn1;
                                for (int i = 0; i < skey.Length; i++)
                                {
                                    int indexOfChar = -1;
                                    indexOfChar = t.LastIndexOf(skey[i]);
                                    if (indexOfChar >= 0)
                                    {
                                        t = t.Remove(indexOfChar, 1);
                                    }
                                }

                                index = -1;
                                index = t.LastIndexOf('J');
                                if (index >= 0)
                                {
                                    t = t.Remove(index, 1);
                                }

                                table = new char[t.Length];

                                for (int i = 0; i < t.Length; i++)//Текст из string в char[]
                                {
                                    table[i] = t[i];
                                }

                                k = 0;
                                for (int i = 0; i < 5; i++)
                                {
                                    for (int n = 0; n < 5; n++)
                                    {
                                        mass[i, n] = table[k];
                                        k++;
                                    }
                                }

                                column = 0;
                                row = 0;

                                for (int m = 0; m < 5; m++)
                                {
                                    for (int n = 0; n < 5; n++)
                                    {
                                        if (s[S] == 'J')
                                        {
                                            if (mass[m, n] == 'I')
                                            {
                                                row = m;
                                                column = n;
                                            }
                                        }
                                        else
                                        {
                                            if (s[S] == mass[m, n])
                                            {
                                                row = m;
                                                column = n;
                                            }
                                        }
                                    }
                                }

                                if (row == 0)
                                {
                                    row = 4;
                                    text1[S] = mass[row, column];
                                }
                                else
                                {
                                    text1[S] = mass[row - 1, column];
                                }


                                Out = new string(text1);//Для вывода строки
                                break;
                            case 4:
                                mass = new char[5, 5];
                                t = skey + alen1;
                                for (int i = 0; i < skey.Length; i++)
                                {
                                    int indexOfChar = -1;
                                    indexOfChar = t.LastIndexOf(skey[i]);
                                    if (indexOfChar >= 0)
                                    {
                                        t = t.Remove(indexOfChar, 1);
                                    }
                                }

                                index = -1;
                                index = t.LastIndexOf('j');
                                if (index >= 0)
                                {
                                    t = t.Remove(index, 1);
                                }

                                table = new char[t.Length];

                                for (int i = 0; i < t.Length; i++)//Текст из string в char[]
                                {
                                    table[i] = t[i];
                                }
                                k = 0;
                                for (int i = 0; i < 5; i++)
                                {
                                    for (int n = 0; n < 5; n++)
                                    {
                                        mass[i, n] = table[k];
                                        k++;
                                    }
                                }

                                column = 0;
                                row = 0;

                                for (int m = 0; m < 5; m++)
                                {
                                    for (int n = 0; n < 5; n++)
                                    {
                                        if (s[S] == 'j')
                                        {
                                            if (mass[m, n] == 'i')
                                            {
                                                row = m;
                                                column = n;
                                            }
                                        }
                                        else
                                        {
                                            if (s[S] == mass[m, n])
                                            {
                                                row = m;
                                                column = n;
                                            }
                                        }
                                    }
                                }

                                if (row == 0)
                                {
                                    row = 4;
                                    text1[S] = mass[row, column];
                                }
                                else
                                {
                                    text1[S] = mass[row - 1, column];
                                }

                                Out = new string(text1);//Для вывода строки
                                break;
                        }
                    }


                }
            }
            return Out;
        }

        public string Atbash1(string inp) //Зашифровать Атбаш
        {
            StringBuilder code = new StringBuilder();
            string s = textBox1.Text; // s - связана с вводимым текстом
            if (textBox1.Text == "") //Проверка на пустое поле
            {
                MessageBox.Show("Введите текст!", "Пустое поле");
            }
            else
            {
                for (int i = 0; i < s.Length; i++)
                {
                    bool f1 = false; //Проверка на букву
                    for (int k = 0; k < al.Length; k++)
                    {
                        if (s[i] == al[k])
                        {
                            f1 = true;
                        }
                    }
                    if (f1 == true) //Если буква, то прогоняем проверку по алфавитам
                    {
                        for (int j = 0; j < alRu.Length; j++)
                        {
                            if (s[i] == alRu[j])
                            {
                                if (j < 33)
                                {
                                    code.Append(alRu[32 - j - 1 + 1]);//А
                                }
                                else
                                {
                                    code.Append(alRu[65 - j + 32 + 1]);//а
                                }

                            }
                        }

                        for (int j = 0; j < alEn.Length; j++)
                        {
                            if (s[i] == alEn[j])
                            {
                                if (j < 26)
                                {
                                    code.Append(alEn[25 - j - 1 + 1]);//А
                                }
                                else
                                {
                                    code.Append(alEn[51 - j + 25 + 1]);//а
                                }

                            }

                        }
                    }
                    else code.Append(s[i]); //Если символ (не буква), то просто остаётся

                }
            }
            return code.ToString();
        }

        public string Atbash2(string inp)
        {
            StringBuilder code = new StringBuilder();
            string s = textBox1.Text; // s - связана с вводимым текстом
            if (textBox1.Text == "") //Проверка на пустую строку
            {
                MessageBox.Show("Введите текст!", "Ошибка ввода данных");
            }
            else
            {
                for (int i = 0; i < s.Length; i++)
                {
                    bool f1 = false;
                    for (int k = 0; k < al.Length; k++) //Проверка на букву
                    {
                        if (s[i] == al[k])
                        {
                            f1 = true;
                        }
                    }
                    if (f1 == true) //Если буква, то обрабатываем
                    {
                        for (int j = 0; j < alRu.Length; j++) //Проверка по русскому
                        {
                            if (s[i] == alRu[j])
                            {
                                if (j < 33)
                                {
                                    code.Append(alRu[32 - j - 1 + 1]);
                                }
                                else
                                {
                                    code.Append(alRu[65 - j + 32 + 1]);
                                }

                            }
                        }

                        for (int j = 0; j < alEn.Length; j++) //Проверка по английскому
                        {
                            if (s[i] == alEn[j])
                            {
                                if (j < 26)
                                {
                                    code.Append(alEn[25 - j - 1 + 1]);
                                }
                                else
                                {
                                    code.Append(alEn[51 - j + 25 + 1]);
                                }

                            }

                        }
                    }
                    else code.Append(s[i]);

                }
            }
            return code.ToString();
        }

        public string Orientation(string inp) //Шифрование Цезарь
        {
            int step = -1;
            StringBuilder code = new StringBuilder(); //Класс для string
            string s = textBox1.Text; // s - связана с вводимым текстом
            if (textBox1.Text == "") //Проверка на пустое поле
            {
                MessageBox.Show("Введите текст!", "Пустое поле");
            }
            string sd = textBox3.Text; //sd-количество шагов шифра (ключ шифрования)
            if (textBox3.Text == "") //Проверка на пустой ключ
            {
                MessageBox.Show("Укажите требуемый шаг!", "Пустое поле");
            }
            else
            {
                try //Отлов исключений
                {
                    step = Convert.ToInt32(sd); //Перевод string в int
                }
                catch
                {
                    MessageBox.Show("В строке есть недопустимые символы!", "Ошибка ввода"); //Случай, если будут лишние символы
                }
                finally
                {
                    if (step < 0) //Если отрицательный шаг
                    {
                        for (int i = 0; i < 1; i++)
                        {
                            //MessageBox.Show("Шаг должен быть больше 0!");
                            break;
                        }
                    }
                    else if (step > 32) //Ограничение по алфавиту
                    {
                        for (int i = 0; i < 1; i++)
                        {
                            MessageBox.Show("Шаг должен быть меньше 32!");
                            break;
                        }

                    }
                    else
                    {
                        for (int i = 0; i < s.Length; i++)
                        {
                            bool f1 = false; //Проверка на букву
                            for (int k = 0; k < al.Length; k++)
                            {
                                if (s[i] == al[k])
                                {
                                    f1 = true;
                                }
                            }
                            if (f1 == true) //Если буква, то проверки по русскому и английскому
                            {
                                for (int j = 0; j < alRu.Length; j++)
                                {
                                    if (s[i] == alRu[j])
                                    {
                                        code.Append(alRu[(j + step) % alRu.Length]);
                                    }
                                }
                                for (int j = 0; j < alEn.Length; j++)
                                {
                                    if (s[i] == alEn[j])
                                    {
                                        code.Append(alEn[(j + step) % alEn.Length]);
                                    }
                                }
                            }
                            else code.Append(s[i]);
                        }
                    }
                }
            }
            return code.ToString();
        }

        public string Orientation2(string inp) //ori - для обозачения боока в котором происходит шифрование
        {
            int step = -1;
            StringBuilder code = new StringBuilder();
            string s = textBox1.Text; // s - связана с вводимым текстом
            if (textBox1.Text == "") //Проверка на пустое поле
            {
                MessageBox.Show("Введите текст!", "Пустое поле");
            }
            string sd = textBox3.Text; //sd-количество шагов шифра (ключ шифрования)
            if (textBox3.Text == "") //Проверка на пустой шаг 
            {
                MessageBox.Show("Укажите требуемый шаг!", "Пустое поле");
            }
            else
            {
                try // Отлов случая с лишними символами
                {
                    step = Convert.ToInt32(sd);
                }
                catch
                {
                    MessageBox.Show("В строке есть недопустимые символы!", "Ошибка ввода"); //Сообщение о лишних символах
                }
                finally
                {
                    if (step < 0) //Проверка на отрицательный шаг
                    {
                        for (int i = 0; i < 1; i++)
                        {
                            //MessageBox.Show("Шаг должен быть больше 0!");
                            break;
                        }
                    }
                    else if (step > 32) //Ограничение по размеру алфавита
                    {
                        for (int i = 0; i < 1; i++)
                        {
                            MessageBox.Show("Шаг должен быть меньше 32!");
                            break;
                        }

                    }
                    else
                    {
                        for (int i = 0; i < s.Length; i++)
                        {
                            bool f1 = false;
                            for (int k = 0; k < al.Length; k++) //Проверка на букву
                            {
                                if (s[i] == al[k])
                                {
                                    f1 = true;
                                }
                            }
                            if (f1 == true) //Если буква, то проверяем по алфавитам
                            {
                                for (int j = 0; j < alRu.Length; j++)
                                {
                                    if (s[i] == alRu[j])
                                    {
                                        code.Append(alRu[(j - step + alRu.Length) % alRu.Length]);
                                    }
                                }
                                for (int j = 0; j < alEn.Length; j++)
                                {
                                    if (s[i] == alEn[j])
                                    {
                                        code.Append(alEn[(j - step + alEn.Length) % alEn.Length]);
                                    }
                                }
                            }
                            else code.Append(s[i]); // Если символ, то просто выводим
                        }
                    }
                }
            }
            return code.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedState = comboBox1.SelectedItem.ToString();
            if ((selectedState == "Шифр Цезаря") || (selectedState == "Шифр Сцитала")) //Видимость поля для ключа
            {
                textBox3.Visible = true;
                if ((selectedState == "Шифр Цезаря"))
                {
                    label4.Visible = true;
                    label6.Visible = false;
                }
                if (selectedState == "Шифр Сцитала")
                {
                    label6.Visible = true;
                    label4.Visible = false;
                }
            }
            else
            {
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                textBox3.Visible = false;
            }

            if (selectedState == "Квадрат Полибия") //Видимость поля для ключа
            {
                label5.Visible = true;
                textBox4.Visible = true;
            }
            else
            {
                label5.Visible = false;
                textBox4.Visible = false;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
