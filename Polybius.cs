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
            int alphabet1 = 0; //Для сравнения алфавитов ключа и строки
            int alphabet2 = 0; //Для сравнения алфавитов ключа и строки
            string Out = ""; //Строка для расшифрованной строки
            var text1 = new char[s.Length]; //Для хранения введённых символов

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

                                int k = 0;//Создаём таблицу шифрования
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
                                        if (s[S] == mass[m, n])
                                        {
                                            row = m;
                                            column = n;
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

                                        if (s[S] == mass[m, n])
                                        {
                                            row = m;
                                            column = n;
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

            }
            return Out;
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
                                        if (s[S] == mass[m, n])
                                        {
                                            row = m;
                                            column = n;
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
                                        if (s[S] == mass[m, n])
                                        {
                                            row = m;
                                            column = n;
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
    }
}