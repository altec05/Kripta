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
        public string Vizhener1(string inp)
        {
            string s = textBox1.Text; // s - связана с вводимым текстом
            string Out = "";
            string skey = textBox3.Text; //skey - ключ шифрования
            char[] key = new char[s.Length];
            int[] indkey = new int[s.Length];
            char[] text = new char[s.Length];
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
                if (skey.Length > s.Length)
                {
                    MessageBox.Show("Недопустимая длина ключа!", "Ключ больше сообщения");
                    return "Длина ключа не должна быть больше длины сообщения";
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

                    //Пишем ключ под сообщением (под пробелами не пишем)
                    int k = 0;
                    for (int i = 0; i < s.Length; i++)
                    {
                        bool good = false;

                        for (int j = 0; j < al.Length; j++)
                        {
                            int indexOfChar = -1;
                            indexOfChar = al.IndexOf(s[i]);
                            if (indexOfChar >= 0)
                            {
                                good = true;
                            }
                        }

                        if (good == false)
                        {
                            key[i] = s[i];
                        }
                        else
                        {
                            if (k < skey.Length)
                            {
                                key[i] = skey[k];
                                k++;
                            }
                            else
                            {
                                k = 0;
                                key[i] = skey[k];
                                k++;
                            }
                        }

                    }

                    string alRu = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
                    string alru = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
                    string alEn = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    string alen = "abcdefghijklmnopqrstuvwxyz";

                    k = 0;
                    //Пишем индексы под ключом
                    for (int i = 0; i < key.Length; i++)
                    {
                        bool good = false;

                        for (int j = 0; j < al.Length; j++)
                        {
                            int indexOfChar = -1;
                            indexOfChar = al.IndexOf(key[i]);
                            if (indexOfChar >= 0)
                            {
                                good = true;
                            }
                        }

                        if (good == false)
                        {
                            indkey[i] = -1;
                        }
                        else
                        {
                            int index = -1;
                            index = alRu.IndexOf(key[i]);
                            if (index >= 0)
                            {
                                indkey[i] = index;
                            }
                            else
                            {
                                index = alru.IndexOf(key[i]);
                                if (index >= 0)
                                {
                                    indkey[i] = index;
                                }
                                else
                                {
                                    index = alEn.IndexOf(key[i]);
                                    if (index >= 0)
                                    {
                                        indkey[i] = index;
                                    }
                                    else
                                    {
                                        index = alen.IndexOf(key[i]);
                                        if (index >= 0)
                                        {
                                            indkey[i] = index;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    for (int i = 0; i < s.Length; i++)
                    {
                        int index = -1;
                        index = alRu.IndexOf(s[i]);
                        if (index >= 0)
                        {
                            text[i] = alRu[(index + indkey[i]) % alRu.Length];
                        }
                        else
                        {
                            index = alru.IndexOf(s[i]);
                            if (index >= 0)
                            {
                                text[i] = alru[(index + indkey[i]) % alru.Length];
                            }
                            else
                            {
                                index = alEn.IndexOf(s[i]);
                                if (index >= 0)
                                {
                                    text[i] = alEn[(index + indkey[i]) % alEn.Length];
                                }
                                else
                                {
                                    index = alen.IndexOf(s[i]);
                                    if (index >= 0)
                                    {
                                        text[i] = alen[(index + indkey[i]) % alen.Length];
                                    }
                                    else
                                    {
                                        text[i] = s[i];
                                    }
                                }
                            }
                        }
                    }
                    Out = new string(text);
                }
            }
            return Out;
        }

        public string Vizhener2(string inp)
        {
            string s = textBox1.Text; // s - связана с вводимым текстом
            string Out = "";
            string skey = textBox3.Text; //skey - ключ шифрования
            char[] key = new char[s.Length];
            int[] indkey = new int[s.Length];
            char[] text = new char[s.Length];
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
                if (skey.Length > s.Length)
                {
                    MessageBox.Show("Недопустимая длина ключа!", "Ключ больше сообщения");
                    return "Длина ключа не должна быть больше длины сообщения";
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

                    //Пишем ключ под сообщением (под пробелами не пишем)
                    int k = 0;
                    for (int i = 0; i < s.Length; i++)
                    {
                        bool good = false;

                        for (int j = 0; j < al.Length; j++)
                        {
                            int indexOfChar = -1;
                            indexOfChar = al.IndexOf(s[i]);
                            if (indexOfChar >= 0)
                            {
                                good = true;
                            }
                        }

                        if (good == false)
                        {
                            key[i] = s[i];
                        }
                        else
                        {
                            if (k < skey.Length)
                            {
                                key[i] = skey[k];
                                k++;
                            }
                            else
                            {
                                k = 0;
                                key[i] = skey[k];
                                k++;
                            }
                        }

                    }

                    string alRu = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
                    string alru = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
                    string alEn = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    string alen = "abcdefghijklmnopqrstuvwxyz";

                    k = 0;
                    //Пишем индексы под ключом
                    for (int i = 0; i < key.Length; i++)
                    {
                        bool good = false;

                        for (int j = 0; j < al.Length; j++)
                        {
                            int indexOfChar = -1;
                            indexOfChar = al.IndexOf(key[i]);
                            if (indexOfChar >= 0)
                            {
                                good = true;
                            }
                        }

                        if (good == false)
                        {
                            indkey[i] = -1;
                        }
                        else
                        {
                            int index = -1;
                            index = alRu.IndexOf(key[i]);
                            if (index >= 0)
                            {
                                indkey[i] = index;
                            }
                            else
                            {
                                index = alru.IndexOf(key[i]);
                                if (index >= 0)
                                {
                                    indkey[i] = index;
                                }
                                else
                                {
                                    index = alEn.IndexOf(key[i]);
                                    if (index >= 0)
                                    {
                                        indkey[i] = index;
                                    }
                                    else
                                    {
                                        index = alen.IndexOf(key[i]);
                                        if (index >= 0)
                                        {
                                            indkey[i] = index;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    for (int i = 0; i < s.Length; i++)
                    {
                        int index = -1;
                        index = alRu.IndexOf(s[i]);
                        if (index >= 0)
                        {
                            if (index - indkey[i] < 0)
                            {
                                text[i] = alRu[((index - indkey[i]) % alRu.Length) + alRu.Length];
                            }
                            else
                            {
                                text[i] = alRu[(index - indkey[i]) % alRu.Length];
                            }

                        }
                        else
                        {
                            index = alru.IndexOf(s[i]);
                            if (index >= 0)
                            {
                                if (index - indkey[i] < 0)
                                {
                                    text[i] = alru[((index - indkey[i]) % alru.Length) + alru.Length];
                                }
                                else
                                {
                                    text[i] = alru[(index - indkey[i]) % alru.Length];
                                }
                            }
                            else
                            {
                                index = alEn.IndexOf(s[i]);
                                if (index >= 0)
                                {
                                    if (index - indkey[i] < 0)
                                    {
                                        text[i] = alEn[((index - indkey[i]) % alEn.Length) + alEn.Length];
                                    }
                                    else
                                    {
                                        text[i] = alEn[(index - indkey[i]) % alEn.Length];
                                    }
                                }
                                else
                                {
                                    index = alen.IndexOf(s[i]);
                                    if (index >= 0)
                                    {
                                        if (index - indkey[i] < 0)
                                        {
                                            text[i] = alen[((index - indkey[i]) % alen.Length) + alen.Length];
                                        }
                                        else
                                        {
                                            text[i] = alen[(index - indkey[i]) % alen.Length];
                                        }
                                    }
                                    else
                                    {
                                        text[i] = s[i];
                                    }
                                }
                            }
                        }
                    }
                    Out = new string(text);
                }
            }
            return Out;
        }
    }
}