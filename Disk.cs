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
        public string Disk1(string inp)
        {
            string s = textBox1.Text; // s - связана с вводимым текстом
            char[] sizm = new char[s.Length]; //Для шифротекста
            char[] text = new char[s.Length]; //Для ключа под буквами
            int[] textind = new int[s.Length]; //Для индексов под буквами
            string skey1 = textBox6.Text; //skey - ключ шифрования
            string skey2 = textBox7.Text; //skey - ключ шифрования
            char[] key = new char[skey1.Length];//key - для хранения ключа и его проверок
            char[] key1 = new char[skey1.Length];//key - для хранения ключа и его проверок
            char[] key2 = new char[skey2.Length];//key - для хранения ключа и его проверок
            string Out = ""; //Строка для зашифрованной строки   

            if (textBox1.Text == "") //Проверка на пустое поле
            {
                MessageBox.Show("Введите текст!", "Пустое поле");
                return "";
            }
            if (textBox6.Text == "") //Проверка на пустое поле
            {
                MessageBox.Show("Введите текст!", "Пустое поле");
                return "";
            }
            if (textBox7.Text == "") //Проверка на пустое поле
            {
                MessageBox.Show("Введите текст!", "Пустое поле");
                return "";
            }

            string AlRuOut = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            string AlruOut = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            string AlEnOut = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string AlenOut = "abcdefghijklmnopqrstuvwxyz";
            string AlNumOut = "0123456789";
            string alREN = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюяABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
            //Проверка на то чтоб только буквы и цифры в ключе
            for (int i = 0; i < skey1.Length; i++)
            {
                for (int j = 0; j < alREN.Length; j++)
                {
                    int indexOfChar = -1;
                    indexOfChar = alREN.IndexOf(skey1[i]);
                    if (indexOfChar < 0)
                    {
                        return "Некорректный ключ";
                    }
                }
                key1[i] = skey1[i];
            }

            for (int i = 0; i < skey2.Length; i++)
            {
                for (int j = 0; j < alREN.Length; j++)
                {
                    int indexOfChar = -1;
                    indexOfChar = alREN.IndexOf(skey2[i]);
                    if (indexOfChar < 0)
                    {
                        return "Некорректный ключ";
                    }
                }
                key2[i] = skey2[i];
            }

            int countRu = 0;
            int countEn = 0;
            int countru = 0;
            int counten = 0;
            int countNum = 0;

            //Число букв из ключа для каждого алфавита
            for (int i = 0; i < skey1.Length; i++)
            {
                for (int j = 0; j < AlRuOut.Length; j++)
                {
                    if (key1[i] == AlRuOut[j])
                    {
                        countRu++;
                    }
                }
                for (int j = 0; j < AlruOut.Length; j++)
                {
                    if (key1[i] == AlruOut[j])
                    {
                        countru++;
                    }
                }
                for (int j = 0; j < AlEnOut.Length; j++)
                {
                    if (key1[i] == AlEnOut[j])
                    {
                        countEn++;
                    }
                }
                for (int j = 0; j < AlenOut.Length; j++)
                {
                    if (key1[i] == AlenOut[j])
                    {
                        counten++;
                    }
                }
                for (int j = 0; j < AlNumOut.Length; j++)
                {
                    if (key1[i] == AlNumOut[j])
                    {
                        countNum++;
                    }
                }
            }
            //Создаём внутренние алфавиты для рус, англ, цифр
            char[] skRu = new char[countRu];
            char[] skEn = new char[countEn];
            char[] skru = new char[countru];
            char[] sken = new char[counten];
            char[] skNum = new char[countNum];

            int k1 = 0;
            int k2 = 0;
            int k3 = 0;
            int k4 = 0;
            int k5 = 0;

            for (int i = 0; i < skey1.Length; i++)
            {
                for (int j = 0; j < AlRuOut.Length; j++)
                {
                    if (key1[i] == AlRuOut[j])
                    {
                        skRu[k1] = key1[i];
                        k1++;
                    }
                }
                for (int j = 0; j < AlruOut.Length; j++)
                {
                    if (key1[i] == AlruOut[j])
                    {
                        skru[k2] = key1[i];
                        k2++;
                    }
                }
                for (int j = 0; j < AlEnOut.Length; j++)
                {
                    if (skey1[i] == AlEnOut[j])
                    {
                        skEn[k3] = key1[i];
                        k3++;
                    }
                }
                for (int j = 0; j < AlenOut.Length; j++)
                {
                    if (skey1[i] == AlenOut[j])
                    {
                        sken[k4] = key1[i];
                        k4++;
                    }
                }
                for (int j = 0; j < AlNumOut.Length; j++)
                {
                    if (skey1[i] == AlNumOut[j])
                    {
                        skNum[k5] = key1[i];
                        k5++;
                    }
                }
            }

            string skR = new string(skRu);
            string skE = new string(skEn);
            string skr = new string(skru);
            string ske = new string(sken);
            string skN = new string(skNum);
            //Заполняем и удаляем повторы
            string AlRuIn = skR + AlRuOut;
            for (int i = 0; i < skR.Length; i++)
            {
                int indexOfChar = -1;
                indexOfChar = AlRuIn.LastIndexOf(skR[i]);
                if (indexOfChar >= 0)
                {
                    AlRuIn = AlRuIn.Remove(indexOfChar, 1);
                }
            }

            string AlruIn = skr + AlruOut;
            for (int i = 0; i < skr.Length; i++)
            {
                int indexOfChar = -1;
                indexOfChar = AlruIn.LastIndexOf(skr[i]);
                if (indexOfChar >= 0)
                {
                    AlruIn = AlruIn.Remove(indexOfChar, 1);
                }
            }

            string AlEnIn = skE + AlEnOut;
            for (int i = 0; i < skE.Length; i++)
            {
                int indexOfChar = -1;
                indexOfChar = AlEnIn.LastIndexOf(skE[i]);
                if (indexOfChar >= 0)
                {
                    AlEnIn = AlEnIn.Remove(indexOfChar, 1);
                }
            }

            string AlenIn = ske + AlenOut;
            for (int i = 0; i < ske.Length; i++)
            {
                int indexOfChar = -1;
                indexOfChar = AlenIn.LastIndexOf(ske[i]);
                if (indexOfChar >= 0)
                {
                    AlenIn = AlenIn.Remove(indexOfChar, 1);
                }
            }

            string AlNumIn = skN + AlNumOut;
            for (int i = 0; i < skN.Length; i++)
            {
                int indexOfChar = -1;
                indexOfChar = AlNumIn.LastIndexOf(skN[i]);
                if (indexOfChar >= 0)
                {
                    AlNumIn = AlNumIn.Remove(indexOfChar, 1);
                }
            }

            //Пишем ключ под сообщением (под пробелами не пишем)
            int k = 0;
            for (int i = 0; i < s.Length; i++)
            {
                bool good = true;

                for (int j = 0; j < alREN.Length; j++)
                {
                    int indexOfChar = -1;
                    indexOfChar = alREN.IndexOf(s[i]);
                    if (indexOfChar < 0)
                    {
                        good = false;
                    }
                }

                if (good == false)
                {
                    text[i] = s[i];
                }
                else
                {
                    if (k < key2.Length)
                    {
                        text[i] = key2[k];
                        k++;
                    }
                    else
                    {
                        k = 0;
                        text[i] = key2[k];
                        k++;
                    }
                }

            }
            //Пишем индексы ключа под ключом (под пробелами не пишем)
            for (int i = 0; i < textind.Length; i++)
            {
                bool good = true;

                for (int j = 0; j < alREN.Length; j++)
                {
                    int indexOfChar = -1;
                    indexOfChar = alREN.IndexOf(s[i]);
                    if (indexOfChar < 0)
                    {
                        good = false;
                    }
                }

                if (good == false)
                {
                    textind[i] = -1;
                }
                else
                {
                    for (int j = 0; j < AlRuOut.Length; j++)
                    {
                        if (text[i] == AlRuOut[j])
                        {
                            textind[i] = j;
                        }
                    }
                    for (int j = 0; j < AlruOut.Length; j++)
                    {
                        if (text[i] == AlruOut[j])
                        {
                            textind[i] = j;
                        }
                    }
                    for (int j = 0; j < AlEnOut.Length; j++)
                    {
                        if (text[i] == AlEnOut[j])
                        {
                            textind[i] = j;
                        }
                    }
                    for (int j = 0; j < AlenOut.Length; j++)
                    {
                        if (text[i] == AlenOut[j])
                        {
                            textind[i] = j;
                        }
                    }
                    for (int j = 0; j < AlNumOut.Length; j++)
                    {
                        if (text[i] == AlNumOut[j])
                        {
                            textind[i] = j;
                        }
                    }
                }
            }
            //Выбираем букву из текста и ищем её во внешнем алф и её индекс там
            for (int i = 0; i < s.Length; i++)
            {
                char[] temp;
                int tind;
                char symbol;
                bool good = true;

                for (int j = 0; j < alREN.Length; j++)
                {
                    int indexOfChar = -1;
                    indexOfChar = alREN.IndexOf(s[i]);
                    if (indexOfChar < 0)
                    {
                        good = false;
                    }
                }

                if (good == false)
                {
                    if (s[i] == ' ')
                    {
                        sizm[i] = ' ';
                    }
                    else
                    {
                        sizm[i] = s[i];
                    }
                }
                else
                {
                    //Поиск буквы в алфавитах и запись её индекса в нём
                    for (int j = 0; j < AlRuOut.Length; j++)
                    {
                        if (s[i] == AlRuOut[j])
                        {
                            tind = j;
                            temp = new char[AlRuIn.Length];
                            for (int n = 0; n < AlRuIn.Length; n++)
                            {
                                temp[n] = AlRuIn[n];
                            }
                            if (tind - (textind[i] % temp.Length) >= 0)
                            {
                                symbol = temp[tind - (textind[i] % temp.Length)];
                                sizm[i] = symbol;
                            }
                            else
                            {
                                symbol = temp[temp.Length + (tind - (textind[i] % temp.Length))];
                                sizm[i] = symbol;
                            }

                        }
                    }
                    for (int j = 0; j < AlruOut.Length; j++)
                    {
                        if (s[i] == AlruOut[j])
                        {
                            tind = j;
                            temp = new char[AlruIn.Length];
                            for (int n = 0; n < AlruIn.Length; n++)
                            {
                                temp[n] = AlruIn[n];
                            }
                            if (tind - (textind[i] % temp.Length) >= 0)
                            {
                                symbol = temp[tind - (textind[i] % temp.Length)];
                                sizm[i] = symbol;
                            }
                            else
                            {
                                symbol = temp[temp.Length + (tind - (textind[i] % temp.Length))];
                                sizm[i] = symbol;
                            }

                        }
                    }
                    for (int j = 0; j < AlEnOut.Length; j++)
                    {
                        if (s[i] == AlEnOut[j])
                        {
                            tind = j;
                            temp = new char[AlEnIn.Length];
                            for (int n = 0; n < AlEnIn.Length; n++)
                            {
                                temp[n] = AlEnIn[n];
                            }
                            if (tind - (textind[i] % temp.Length) >= 0)
                            {
                                symbol = temp[tind - (textind[i] % temp.Length)];
                                sizm[i] = symbol;
                            }
                            else
                            {
                                symbol = temp[temp.Length + (tind - (textind[i] % temp.Length))];
                                sizm[i] = symbol;
                            }
                        }
                    }
                    for (int j = 0; j < AlenOut.Length; j++)
                    {
                        if (s[i] == AlenOut[j])
                        {
                            tind = j;
                            temp = new char[AlenIn.Length];
                            for (int n = 0; n < AlenIn.Length; n++)
                            {
                                temp[n] = AlenIn[n];
                            }
                            if (tind - (textind[i] % temp.Length) >= 0)
                            {
                                symbol = temp[tind - (textind[i] % temp.Length)];
                                sizm[i] = symbol;
                            }
                            else
                            {
                                symbol = temp[temp.Length + (tind - (textind[i] % temp.Length))];
                                sizm[i] = symbol;
                            }
                        }
                    }
                    for (int j = 0; j < AlNumOut.Length; j++)
                    {
                        if (s[i] == AlNumOut[j])
                        {
                            tind = j;
                            temp = new char[AlNumIn.Length];
                            for (int n = 0; n < AlNumIn.Length; n++)
                            {
                                temp[n] = AlNumIn[n];
                            }
                            if (tind - (textind[i] % temp.Length) >= 0)
                            {
                                symbol = temp[tind - (textind[i] % temp.Length)];
                                sizm[i] = symbol;
                            }
                            else
                            {
                                symbol = temp[temp.Length + (tind - (textind[i] % temp.Length))];
                                sizm[i] = symbol;
                            }
                        }
                    }
                }
            }
            Out = new string(sizm);
            return Out;
        }

        public string Disk2(string inp)
        {
            string s = textBox1.Text; // s - связана с вводимым текстом
            char[] sizm = new char[s.Length]; //Для шифротекста
            char[] text = new char[s.Length]; //Для ключа под буквами
            int[] textind = new int[s.Length]; //Для индексов под буквами
            string skey1 = textBox6.Text; //skey - ключ шифрования
            string skey2 = textBox7.Text; //skey - ключ шифрования
            char[] key = new char[skey1.Length];//key - для хранения ключа и его проверок
            char[] key1 = new char[skey1.Length];//key - для хранения ключа и его проверок
            char[] key2 = new char[skey2.Length];//key - для хранения ключа и его проверок
            string Out = ""; //Строка для зашифрованной строки   

            if (textBox1.Text == "") //Проверка на пустое поле
            {
                MessageBox.Show("Введите текст!", "Пустое поле");
                return "";
            }
            if (textBox6.Text == "") //Проверка на пустое поле
            {
                MessageBox.Show("Введите текст!", "Пустое поле");
                return "";
            }
            if (textBox7.Text == "") //Проверка на пустое поле
            {
                MessageBox.Show("Введите текст!", "Пустое поле");
                return "";
            }

            string AlRuOut = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            string AlruOut = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            string AlEnOut = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string AlenOut = "abcdefghijklmnopqrstuvwxyz";
            string AlNumOut = "0123456789";
            string alREN = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюяABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
            //Проверка на то чтоб только буквы и цифры в ключе
            for (int i = 0; i < skey1.Length; i++)
            {
                for (int j = 0; j < alREN.Length; j++)
                {
                    int indexOfChar = -1;
                    indexOfChar = alREN.IndexOf(skey1[i]);
                    if (indexOfChar < 0)
                    {
                        return "Некорректный ключ";
                    }
                }
                key1[i] = skey1[i];
            }

            for (int i = 0; i < skey2.Length; i++)
            {
                for (int j = 0; j < alREN.Length; j++)
                {
                    int indexOfChar = -1;
                    indexOfChar = alREN.IndexOf(skey2[i]);
                    if (indexOfChar < 0)
                    {
                        return "Некорректный ключ";
                    }
                }
                key2[i] = skey2[i];
            }

            int countRu = 0;
            int countEn = 0;
            int countru = 0;
            int counten = 0;
            int countNum = 0;

            //Число букв из ключа для каждого алфавита
            for (int i = 0; i < skey1.Length; i++)
            {
                for (int j = 0; j < AlRuOut.Length; j++)
                {
                    if (key1[i] == AlRuOut[j])
                    {
                        countRu++;
                    }
                }
                for (int j = 0; j < AlruOut.Length; j++)
                {
                    if (key1[i] == AlruOut[j])
                    {
                        countru++;
                    }
                }
                for (int j = 0; j < AlEnOut.Length; j++)
                {
                    if (key1[i] == AlEnOut[j])
                    {
                        countEn++;
                    }
                }
                for (int j = 0; j < AlenOut.Length; j++)
                {
                    if (key1[i] == AlenOut[j])
                    {
                        counten++;
                    }
                }
                for (int j = 0; j < AlNumOut.Length; j++)
                {
                    if (key1[i] == AlNumOut[j])
                    {
                        countNum++;
                    }
                }
            }
            //Создаём внутренние алфавиты для рус, англ, цифр
            char[] skRu = new char[countRu];
            char[] skEn = new char[countEn];
            char[] skru = new char[countru];
            char[] sken = new char[counten];
            char[] skNum = new char[countNum];

            int k1 = 0;
            int k2 = 0;
            int k3 = 0;
            int k4 = 0;
            int k5 = 0;

            for (int i = 0; i < skey1.Length; i++)
            {
                for (int j = 0; j < AlRuOut.Length; j++)
                {
                    if (key1[i] == AlRuOut[j])
                    {
                        skRu[k1] = key1[i];
                        k1++;
                    }
                }
                for (int j = 0; j < AlruOut.Length; j++)
                {
                    if (key1[i] == AlruOut[j])
                    {
                        skru[k2] = key1[i];
                        k2++;
                    }
                }
                for (int j = 0; j < AlEnOut.Length; j++)
                {
                    if (skey1[i] == AlEnOut[j])
                    {
                        skEn[k3] = key1[i];
                        k3++;
                    }
                }
                for (int j = 0; j < AlenOut.Length; j++)
                {
                    if (skey1[i] == AlenOut[j])
                    {
                        sken[k4] = key1[i];
                        k4++;
                    }
                }
                for (int j = 0; j < AlNumOut.Length; j++)
                {
                    if (skey1[i] == AlNumOut[j])
                    {
                        skNum[k5] = key1[i];
                        k5++;
                    }
                }
            }

            string skR = new string(skRu);
            string skE = new string(skEn);
            string skr = new string(skru);
            string ske = new string(sken);
            string skN = new string(skNum);
            //Заполняем и удаляем повторы
            string AlRuIn = skR + AlRuOut;
            for (int i = 0; i < skR.Length; i++)
            {
                int indexOfChar = -1;
                indexOfChar = AlRuIn.LastIndexOf(skR[i]);
                if (indexOfChar >= 0)
                {
                    AlRuIn = AlRuIn.Remove(indexOfChar, 1);
                }
            }

            string AlruIn = skr + AlruOut;
            for (int i = 0; i < skr.Length; i++)
            {
                int indexOfChar = -1;
                indexOfChar = AlruIn.LastIndexOf(skr[i]);
                if (indexOfChar >= 0)
                {
                    AlruIn = AlruIn.Remove(indexOfChar, 1);
                }
            }

            string AlEnIn = skE + AlEnOut;
            for (int i = 0; i < skE.Length; i++)
            {
                int indexOfChar = -1;
                indexOfChar = AlEnIn.LastIndexOf(skE[i]);
                if (indexOfChar >= 0)
                {
                    AlEnIn = AlEnIn.Remove(indexOfChar, 1);
                }
            }

            string AlenIn = ske + AlenOut;
            for (int i = 0; i < ske.Length; i++)
            {
                int indexOfChar = -1;
                indexOfChar = AlenIn.LastIndexOf(ske[i]);
                if (indexOfChar >= 0)
                {
                    AlenIn = AlenIn.Remove(indexOfChar, 1);
                }
            }

            string AlNumIn = skN + AlNumOut;
            for (int i = 0; i < skN.Length; i++)
            {
                int indexOfChar = -1;
                indexOfChar = AlNumIn.LastIndexOf(skN[i]);
                if (indexOfChar >= 0)
                {
                    AlNumIn = AlNumIn.Remove(indexOfChar, 1);
                }
            }

            //Пишем ключ под сообщением (под пробелами не пишем)
            int k = 0;
            for (int i = 0; i < s.Length; i++)
            {
                bool good = true;

                for (int j = 0; j < alREN.Length; j++)
                {
                    int indexOfChar = -1;
                    indexOfChar = alREN.IndexOf(s[i]);
                    if (indexOfChar < 0)
                    {
                        good = false;
                    }
                }

                if (good == false)
                {
                    text[i] = s[i];
                }
                else
                {
                    if (k < key2.Length)
                    {
                        text[i] = key2[k];
                        k++;
                    }
                    else
                    {
                        k = 0;
                        text[i] = key2[k];
                        k++;
                    }
                }

            }
            //Пишем индексы ключа под ключом (под пробелами не пишем)
            for (int i = 0; i < textind.Length; i++)
            {
                bool good = true;

                for (int j = 0; j < alREN.Length; j++)
                {
                    int indexOfChar = -1;
                    indexOfChar = alREN.IndexOf(s[i]);
                    if (indexOfChar < 0)
                    {
                        good = false;
                    }
                }

                if (good == false)
                {
                    textind[i] = -1;
                }
                else
                {
                    for (int j = 0; j < AlRuOut.Length; j++)
                    {
                        if (text[i] == AlRuOut[j])
                        {
                            textind[i] = j;
                        }
                    }
                    for (int j = 0; j < AlruOut.Length; j++)
                    {
                        if (text[i] == AlruOut[j])
                        {
                            textind[i] = j;
                        }
                    }
                    for (int j = 0; j < AlEnOut.Length; j++)
                    {
                        if (text[i] == AlEnOut[j])
                        {
                            textind[i] = j;
                        }
                    }
                    for (int j = 0; j < AlenOut.Length; j++)
                    {
                        if (text[i] == AlenOut[j])
                        {
                            textind[i] = j;
                        }
                    }
                    for (int j = 0; j < AlNumOut.Length; j++)
                    {
                        if (text[i] == AlNumOut[j])
                        {
                            textind[i] = j;
                        }
                    }
                }
            }
            //Выбираем букву из текста и ищем её во внешнем алф и её индекс там
            for (int i = 0; i < s.Length; i++)
            {
                char[] temp;
                int tind;
                char symbol;
                bool good = true;

                for (int j = 0; j < alREN.Length; j++)
                {
                    int indexOfChar = -1;
                    indexOfChar = alREN.IndexOf(s[i]);
                    if (indexOfChar < 0)
                    {
                        good = false;
                    }
                }

                if (good == false)
                {
                    if (s[i] == ' ')
                    {
                        sizm[i] = ' ';
                    }
                    else
                    {
                        sizm[i] = s[i];
                    }
                }
                else
                {
                    //Поиск буквы в алфавитах и запись её индекса в нём
                    for (int j = 0; j < AlRuIn.Length; j++)
                    {
                        if (s[i] == AlRuIn[j])
                        {
                            if (j + (textind[i] % AlRuIn.Length) < AlRuIn.Length)
                            {
                                sizm[i] = AlRuOut[j + (textind[i] % AlRuIn.Length)];
                            }
                            else
                            {
                                sizm[i] = AlRuOut[0 - (AlRuIn.Length - (j + (textind[i] % AlRuIn.Length)))];
                            }
                        }
                    }
                    for (int j = 0; j < AlruIn.Length; j++)
                    {
                        if (s[i] == AlruIn[j])
                        {
                            if (j + (textind[i] % AlruIn.Length) < AlruIn.Length)
                            {
                                sizm[i] = AlruOut[j + (textind[i] % AlruIn.Length)];
                            }
                            else
                            {
                                sizm[i] = AlruOut[0 - (AlruIn.Length - (j + (textind[i] % AlruIn.Length)))];
                            }
                        }
                    }
                    for (int j = 0; j < AlEnIn.Length; j++)
                    {
                        if (s[i] == AlEnIn[j])
                        {
                            if (j + (textind[i] % AlEnIn.Length) < AlEnIn.Length)
                            {
                                sizm[i] = AlEnOut[j + (textind[i] % AlEnIn.Length)];
                            }
                            else
                            {
                                sizm[i] = AlEnOut[0 - (AlEnIn.Length - (j + (textind[i] % AlEnIn.Length)))];
                            }
                        }
                    }
                    for (int j = 0; j < AlenIn.Length; j++)
                    {
                        if (s[i] == AlenIn[j])
                        {
                            if (j + (textind[i] % AlenIn.Length) < AlenIn.Length)
                            {
                                sizm[i] = AlenOut[j + (textind[i] % AlenIn.Length)];
                            }
                            else
                            {
                                sizm[i] = AlenOut[0 - (AlenIn.Length - (j + (textind[i] % AlenIn.Length)))];
                            }
                        }
                    }
                    for (int j = 0; j < AlNumIn.Length; j++)
                    {
                        if (s[i] == AlNumIn[j])
                        {
                            if (j + (textind[i] % AlNumIn.Length) < AlNumIn.Length)
                            {
                                sizm[i] = AlNumOut[j + (textind[i] % AlNumIn.Length)];
                            }
                            else
                            {
                                sizm[i] = AlNumOut[0 - (AlNumIn.Length - (j + (textind[i] % AlNumIn.Length)))];
                            }
                        }
                    }
                }
            }
            Out = new string(sizm);
            return Out;
        }
    }
}