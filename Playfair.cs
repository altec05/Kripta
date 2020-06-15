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
        public string Playfair1(string inp)
        {
            string s = textBox1.Text; // s - связана с вводимым текстом
            string Out = "";
            string skey = textBox3.Text; //skey - ключ шифрования
            char[] key = new char[s.Length];
            char[] text = new char[s.Length];

            string alfull = "абвгдеёжзийклмнопрстуфхцчшщъыьэюяabcdefghijklmnopqrstuvwxyz ";
            string alBIG = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string cript = " ";
            string alru = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            string alen = "abcdefghijklmnopqrstuvwxyz";

            if (textBox1.Text == "") //Проверка на пустое поле
            {
                MessageBox.Show("Введите текст!", "Пустое поле");
                return "";
            }

            if (textBox3.Text == "") //Проверка на пустой ключ
            {
                MessageBox.Show("Укажите требуемый шаг!", "Пустое поле");
                return "";
            }
            else
            {
                //Проверка ключа на цифры
                bool check;
                for (int i = 0; i < skey.Length; i++)
                {
                    check = false;
                    for (int j = 0; j < al.Length; j++)
                    {
                        if (skey[i] == al[j])
                        {
                            check = true;
                        }
                    }
                    if (check == false)
                    {
                        return "Неверный ключ!";
                    }
                }
                //Делим ключ на русские и английские для добавления в алфавит
                string ru = " ";
                string en = " ";
                skey = skey.ToLower();

                for (int i = 0; i < skey.Length; i++)
                {
                    bool Ru = false;
                    int indexOfChar = -1;
                    indexOfChar = alru.IndexOf(skey[i]);
                    if (indexOfChar >= 0)
                    {
                        Ru = true;
                    }
                    if (Ru == true)
                    {
                        ru += skey[i];
                    }
                }

                for (int i = 0; i < skey.Length; i++)
                {
                    bool En = false;
                    int indexOfChar = -1;
                    indexOfChar = alen.IndexOf(skey[i]);
                    if (indexOfChar >= 0)
                    {
                        En = true;
                    }
                    if (En == true)
                    {
                        en += skey[i];
                    }
                }

                string con1 = ru + alru;
                string con2 = en + alen;

                con1 = con1.Replace(" ", "");
                con2 = con2.Replace(" ", "");


                for (int i = 0; i < con1.Length; i++)
                {
                    while (con1.LastIndexOf(con1[i]) != i)
                    {
                        int indexOfChar = -1;
                        indexOfChar = con1.LastIndexOf(con1[i]);
                        if (indexOfChar >= 0)
                        {
                            if (indexOfChar != i)
                            {
                                con1 = con1.Remove(indexOfChar, 1);
                            }
                        }
                    }
                }
                for (int i = 0; i < con2.Length; i++)
                {
                    while (con2.LastIndexOf(con2[i]) != i)
                    {
                        int indexOfChar = -1;
                        indexOfChar = con2.LastIndexOf(con2[i]);
                        if (indexOfChar >= 0)
                        {
                            if (indexOfChar != i)
                            {
                                con2 = con2.Remove(indexOfChar, 1);
                            }
                        }
                    }
                }
                //Получаем алфавит
                cript = con1 + con2 + " ";
                //Создаём таблицу с русскими, английскими буквами и разделителем
                char[][] mas = new char[6][];
                int k = 0;
                for (int i = 0; i < mas.Length; i++)
                {
                    mas[i] = new char[10];
                    for (int j = 0; j < mas[i].Length; j++)
                    {
                        mas[i][j] = cript[k];
                        k++;
                    }
                }
                //Необходимо разделить строку на биграммы
                string temp = s.ToLower();//Временная строка

                int numbofp = 0;//Число биграмм
                int count = temp.Length;//Число символов
                for (int i = 0; i < temp.Length - 1; i++)
                {
                    if (temp[i] == temp[i + 1])
                    {
                        count = count + 1;
                    }
                }
                if (count % 2 == 0)
                {
                    numbofp = count / 2;
                }
                else
                {
                    numbofp = (count + 1) / 2;
                }

                //Создаём массив для биграмм (число биграмм * 2 буквы)
                char[][] bigr = new char[numbofp][];//Биграммы
                char[][] bigr2 = new char[numbofp][];//Закодированные биграммы
                int[][] BIG = new int[numbofp][];
                k = 0;
                for (int i = 0; i < bigr.Length; i++)
                {
                    bigr[i] = new char[2];
                    BIG[i] = new int[2];
                    bigr2[i] = new char[2];
                    for (int j = 0; j < bigr[i].Length; j++)
                    {
                        if (j == 1 && k < s.Length && bigr[i][0] == s.ToLower()[k])
                        {
                            bigr[i][j] = ' ';
                            BIG[i][j] = 0;

                        }
                        else if (k == s.Length)
                        {
                            bigr[i][j] = ' ';
                            BIG[i][j] = 0;
                        }
                        else
                        {
                            bigr[i][j] = s.ToLower()[k];
                            int indexOfChar = -1;
                            indexOfChar = alBIG.LastIndexOf(s[k]);
                            if (indexOfChar >= 0)
                            {
                                BIG[i][j] = 1;
                            }
                            else
                            {
                                BIG[i][j] = 0;
                            }
                            k++;
                        }

                    }
                }
                //Шифруем биграммы
                for (int i = 0; i < bigr.Length; i++)
                {
                    for (int j = 0; j < bigr[i].Length - 1; j++)
                    {

                        int indexOfChar1 = -1;
                        indexOfChar1 = alfull.LastIndexOf(bigr[i][j]);

                        int indexOfChar2 = -1;
                        indexOfChar2 = alfull.LastIndexOf(bigr[i][j + 1]);
                        if (indexOfChar1 >= 0 && indexOfChar2 >= 0)
                        {
                            //Первая буква биграммы
                            int str1 = -1;
                            int sto1 = -1;
                            for (int n = 0; n < mas.Length; n++)
                            {
                                for (int m = 0; m < mas[n].Length; m++)
                                {
                                    if (bigr[i][j] == mas[n][m])
                                    {
                                        str1 = n;
                                        sto1 = m;
                                    }
                                }
                            }
                            //Вторая буква биграммы
                            int str2 = -1;
                            int sto2 = -1;
                            for (int n = 0; n < mas.Length; n++)
                            {
                                for (int m = 0; m < mas[n].Length; m++)
                                {
                                    if (bigr[i][j + 1] == mas[n][m])
                                    {
                                        str2 = n;
                                        sto2 = m;
                                    }
                                }
                            }
                            if (str1 > -1 && str2 > -1 && sto1 > -1 && sto2 > -1)
                            {
                                if (str1 == str2)//Если в одной строке
                                {
                                    if (sto1 + 1 <= mas[0].Length - 1)
                                    {
                                        bigr2[i][j] = mas[str1][sto1 + 1];
                                    }
                                    else
                                    {
                                        bigr2[i][j] = mas[str1][0];
                                    }

                                    if (sto2 + 1 <= mas[0].Length - 1)
                                    {
                                        bigr2[i][j + 1] = mas[str2][sto2 + 1];
                                    }
                                    else
                                    {
                                        bigr2[i][j + 1] = mas[str2][0];
                                    }
                                }
                                else if (sto1 == sto2)//Если в одном столбце
                                {
                                    if (str1 + 1 <= mas.Length - 1)
                                    {
                                        bigr2[i][j] = mas[str1 + 1][sto1];

                                    }
                                    else
                                    {
                                        bigr2[i][j] = mas[0][sto1];
                                    }

                                    if (str2 + 1 <= mas.Length - 1)
                                    {
                                        bigr2[i][j + 1] = mas[str2 + 1][sto2];

                                    }
                                    else
                                    {
                                        bigr2[i][j + 1] = mas[0][sto2];
                                    }
                                }
                                else //Разные столбцы и строки
                                {
                                    bigr2[i][j] = mas[str1][sto2];
                                    bigr2[i][j + 1] = mas[str2][sto1];
                                }
                            }
                        }
                        else
                        {
                            bigr2[i][j] = bigr[i][j];
                            bigr2[i][j + 1] = bigr[i][j + 1];
                        }

                    }
                }
                //Переводим в строку для вывода
                k = 0;
                for (int i = 0; i < bigr2.Length; i++)
                {
                    for (int j = 0; j < bigr2[i].Length; j++)
                    {//Если был верхний регистр, то переводим в верхний
                        if (BIG[i][j] == 1)
                        {
                            string ch = "";
                            ch += bigr2[i][j];
                            ch = ch.ToUpper();
                            Out += ch;
                        }
                        else
                        {
                            Out += bigr2[i][j];
                        }

                    }
                }
            }
            return Out;
        }

        public string Playfair2(string inp)
        {
            string s = textBox1.Text; // s - связана с вводимым текстом
            string Out = "";
            string skey = textBox3.Text; //skey - ключ шифрования
            char[] key = new char[s.Length];
            char[] text = new char[s.Length];

            string alfull = "абвгдеёжзийклмнопрстуфхцчшщъыьэюяabcdefghijklmnopqrstuvwxyz ";
            string alBIG = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string cript = " ";
            string alru = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            string alen = "abcdefghijklmnopqrstuvwxyz";

            if (textBox1.Text == "") //Проверка на пустое поле
            {
                MessageBox.Show("Введите текст!", "Пустое поле");
                return "";
            }

            if (textBox3.Text == "") //Проверка на пустой ключ
            {
                MessageBox.Show("Укажите требуемый шаг!", "Пустое поле");
                return "";
            }
            else
            {
                //Проверка ключа на цифры
                bool check;
                for (int i = 0; i < skey.Length; i++)
                {
                    check = false;
                    for (int j = 0; j < al.Length; j++)
                    {
                        if (skey[i] == al[j])
                        {
                            check = true;
                        }
                    }
                    if (check == false)
                    {
                        return "Неверный ключ!";
                    }
                }
                //Делим ключ на русские и английские для добавления в алфавит
                string ru = " ";
                string en = " ";
                skey = skey.ToLower();

                for (int i = 0; i < skey.Length; i++)
                {
                    bool Ru = false;
                    int indexOfChar = -1;
                    indexOfChar = alru.IndexOf(skey[i]);
                    if (indexOfChar >= 0)
                    {
                        Ru = true;
                    }
                    if (Ru == true)
                    {
                        ru += skey[i];
                    }
                }

                for (int i = 0; i < skey.Length; i++)
                {
                    bool En = false;
                    int indexOfChar = -1;
                    indexOfChar = alen.IndexOf(skey[i]);
                    if (indexOfChar >= 0)
                    {
                        En = true;
                    }
                    if (En == true)
                    {
                        en += skey[i];
                    }
                }

                string con1 = ru + alru;
                string con2 = en + alen;

                con1 = con1.Replace(" ", "");
                con2 = con2.Replace(" ", "");

                for (int i = 0; i < con1.Length; i++)
                {
                    while (con1.LastIndexOf(con1[i]) != i)
                    {
                        int indexOfChar = -1;
                        indexOfChar = con1.LastIndexOf(con1[i]);
                        if (indexOfChar >= 0)
                        {
                            if (indexOfChar != i)
                            {
                                con1 = con1.Remove(indexOfChar, 1);
                            }
                        }
                    }
                }
                for (int i = 0; i < con2.Length; i++)
                {
                    while (con2.LastIndexOf(con2[i]) != i)
                    {
                        int indexOfChar = -1;
                        indexOfChar = con2.LastIndexOf(con2[i]);
                        if (indexOfChar >= 0)
                        {
                            if (indexOfChar != i)
                            {
                                con2 = con2.Remove(indexOfChar, 1);
                            }
                        }
                    }
                }
                //Получаем алфавит
                cript = con1 + con2 + " ";
                //Создаём таблицу с русскими, английскими буквами и разделителем
                char[][] mas = new char[6][];
                int k = 0;
                for (int i = 0; i < mas.Length; i++)
                {
                    mas[i] = new char[10];
                    for (int j = 0; j < mas[i].Length; j++)
                    {
                        mas[i][j] = cript[k];
                        k++;
                    }
                }
                //Необходимо разделить строку на биграммы
                string temp = s.ToLower();//Временная строка

                int numbofp = 0;//Число биграмм
                int count = temp.Length;//Число символов
                for (int i = 0; i < temp.Length - 1; i++)
                {
                    if (temp[i] == temp[i + 1])
                    {
                        count = count + 1;
                    }
                }
                if (count % 2 == 0)
                {
                    numbofp = count / 2;
                }
                else
                {
                    numbofp = (count + 1) / 2;
                }

                //Создаём массив для биграмм (число биграмм * 2 буквы)
                char[][] bigr = new char[numbofp][];//Биграммы
                char[][] bigr2 = new char[numbofp][];//Закодированные биграммы
                int[][] BIG = new int[numbofp][];
                k = 0;
                for (int i = 0; i < bigr.Length; i++)
                {
                    bigr[i] = new char[2];
                    BIG[i] = new int[2];
                    bigr2[i] = new char[2];
                    for (int j = 0; j < bigr[i].Length; j++)
                    {
                        if (j == 1 && k < s.Length && bigr[i][0] == s.ToLower()[k])
                        {
                            bigr[i][j] = ' ';
                            BIG[i][j] = 0;

                        }
                        else if (k == s.Length)
                        {
                            bigr[i][j] = ' ';
                            BIG[i][j] = 0;
                        }
                        else
                        {
                            bigr[i][j] = s.ToLower()[k];
                            int indexOfChar = -1;
                            indexOfChar = alBIG.LastIndexOf(s[k]);
                            if (indexOfChar >= 0)
                            {
                                BIG[i][j] = 1;
                            }
                            else
                            {
                                BIG[i][j] = 0;
                            }
                            k++;
                        }

                    }
                }
                //Шифруем биграммы
                for (int i = 0; i < bigr.Length; i++)
                {
                    for (int j = 0; j < bigr[i].Length - 1; j++)
                    {

                        int indexOfChar1 = -1;
                        indexOfChar1 = alfull.LastIndexOf(bigr[i][j]);

                        int indexOfChar2 = -1;
                        indexOfChar2 = alfull.LastIndexOf(bigr[i][j + 1]);
                        if (indexOfChar1 >= 0 && indexOfChar2 >= 0)
                        {
                            //Первая буква биграммы
                            int str1 = -1;
                            int sto1 = -1;
                            for (int n = 0; n < mas.Length; n++)
                            {
                                for (int m = 0; m < mas[n].Length; m++)
                                {
                                    if (bigr[i][j] == mas[n][m])
                                    {
                                        str1 = n;
                                        sto1 = m;
                                    }
                                }
                            }
                            //Вторая буква биграммы
                            int str2 = -1;
                            int sto2 = -1;
                            for (int n = 0; n < mas.Length; n++)
                            {
                                for (int m = 0; m < mas[n].Length; m++)
                                {
                                    if (bigr[i][j + 1] == mas[n][m])
                                    {
                                        str2 = n;
                                        sto2 = m;
                                    }
                                }
                            }
                            if (str1 > -1 && str2 > -1 && sto1 > -1 && sto2 > -1)
                            {
                                if (str1 == str2)//Если в одной строке
                                {
                                    if (sto1 - 1 >= 0)
                                    {
                                        bigr2[i][j] = mas[str1][sto1 - 1];
                                    }
                                    else
                                    {
                                        bigr2[i][j] = mas[str1][mas[0].Length - 1];
                                    }

                                    if (sto2 - 1 >= 0)
                                    {
                                        bigr2[i][j + 1] = mas[str2][sto2 - 1];
                                    }
                                    else
                                    {
                                        bigr2[i][j + 1] = mas[str2][mas[0].Length - 1];
                                    }
                                }
                                else if (sto1 == sto2)//Если в одном столбце
                                {
                                    if (str1 - 1 >= 0)
                                    {
                                        bigr2[i][j] = mas[str1 - 1][sto1];
                                    }
                                    else
                                    {
                                        bigr2[i][j] = mas[mas.Length - 1][sto1];
                                    }

                                    if (str2 - 1 >= 0)
                                    {
                                        bigr2[i][j + 1] = mas[str2 - 1][sto2];

                                    }
                                    else
                                    {
                                        bigr2[i][j + 1] = mas[mas.Length - 1][sto2];
                                    }
                                }
                                else //Разные столбцы и строки
                                {
                                    bigr2[i][j] = mas[str1][sto2];
                                    bigr2[i][j + 1] = mas[str2][sto1];
                                }
                            }
                        }
                        else
                        {
                            bigr2[i][j] = bigr[i][j];
                            bigr2[i][j + 1] = bigr[i][j + 1];
                        }
                    }
                }
                //Переводим в строку для вывода
                k = 0;
                for (int i = 0; i < bigr2.Length; i++)
                {
                    for (int j = 0; j < bigr2[i].Length; j++)
                    {//Если был верхний регистр, то переводим в верхний
                        if (BIG[i][j] == 1)
                        {
                            string ch = "";
                            ch += bigr2[i][j];
                            ch = ch.ToUpper();
                            Out += ch;
                        }
                        else
                        {
                            Out += bigr2[i][j];
                        }

                    }
                }

                Out = Out.Replace(" ", "");
            }
            return Out;
        }
    }
}