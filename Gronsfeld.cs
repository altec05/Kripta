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
        public string Gronsfeld1(string inp)
        {
            string s = textBox1.Text; // s - связана с вводимым текстом
            string Out = "";
            char[] text = new char[s.Length];
            string skey = textBox3.Text; //skey - ключ шифрования
            string number = "0123456789";
            int[] key;
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
                    bool numb;
                    for (int i = 0; i < skey.Length; i++)
                    {
                        numb = false;
                        for (int j = 0; j < number.Length; j++)
                        {
                            if (skey[i] == number[j])
                            {
                                numb = true;
                            }
                        }
                        if (numb == false)
                        {
                            return "Неверный ключ!";
                        }
                    }

                    key = new int[s.Length];
                    int k = 0;
                    for (int i = 0; i < s.Length; i++)
                    {
                        int indexOfChar = -1;
                        indexOfChar = al.IndexOf(s[i]);
                        if (indexOfChar < 0)//Если любой из символов ключа не буква
                        {
                            key[i] = -1;
                            continue;
                        }
                        else
                        {
                            if (k < skey.Length)
                            {
                                key[i] = Convert.ToInt32(skey[k]) - 48; //Перевод string в int
                                k++;
                            }
                            else
                            {
                                k = 0;
                                key[i] = Convert.ToInt32(skey[k]) - 48; //Перевод string в int
                                k++;
                            }
                        }
                    }

                    string alRu = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
                    string alru = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
                    string alEn = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    string alen = "abcdefghijklmnopqrstuvwxyz";

                    for (int i = 0; i < s.Length; i++)
                    {

                        if (key[i] < 0)//Если любой из символов ключа не буква
                        {
                            text[i] = s[i];
                        }
                        else
                        {
                            int indexOfChar = -1;
                            indexOfChar = alRu.IndexOf(s[i]);
                            if (indexOfChar >= 0)
                            {
                                text[i] = alRu[(indexOfChar + key[i]) % alRu.Length];
                            }
                            else
                            {
                                indexOfChar = -1;
                                indexOfChar = alru.IndexOf(s[i]);
                                if (indexOfChar >= 0)
                                {
                                    text[i] = alru[(indexOfChar + key[i]) % alru.Length];
                                }
                                else
                                {
                                    indexOfChar = -1;
                                    indexOfChar = alEn.IndexOf(s[i]);
                                    if (indexOfChar >= 0)
                                    {
                                        text[i] = alEn[(indexOfChar + key[i]) % alEn.Length];
                                    }
                                    else
                                    {
                                        indexOfChar = -1;
                                        indexOfChar = alen.IndexOf(s[i]);
                                        if (indexOfChar >= 0)
                                        {
                                            text[i] = alen[(indexOfChar + key[i]) % alen.Length];
                                        }
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

        public string Gronsfeld2(string inp)
        {
            string s = textBox1.Text; // s - связана с вводимым текстом
            string Out = "";
            char[] text = new char[s.Length];
            string skey = textBox3.Text; //skey - ключ шифрования
            string number = "0123456789";
            int[] key;
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
                    bool numb;
                    for (int i = 0; i < skey.Length; i++)
                    {
                        numb = false;
                        for (int j = 0; j < number.Length; j++)
                        {
                            if (skey[i] == number[j])
                            {
                                numb = true;
                            }
                        }
                        if (numb == false)
                        {
                            return "Неверный ключ!";
                        }
                    }

                    key = new int[s.Length];
                    int k = 0;
                    for (int i = 0; i < s.Length; i++)
                    {
                        int indexOfChar = -1;
                        indexOfChar = al.IndexOf(s[i]);
                        if (indexOfChar < 0)//Если любой из символов ключа не буква
                        {
                            key[i] = -1;
                            continue;
                        }
                        else
                        {
                            if (k < skey.Length)
                            {
                                key[i] = Convert.ToInt32(skey[k]) - 48; //Перевод string в int
                                k++;
                            }
                            else
                            {
                                k = 0;
                                key[i] = Convert.ToInt32(skey[k]) - 48; //Перевод string в int
                                k++;
                            }
                        }
                    }

                    string alRu = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
                    string alru = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
                    string alEn = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    string alen = "abcdefghijklmnopqrstuvwxyz";

                    for (int i = 0; i < s.Length; i++)
                    {

                        if (key[i] < 0)//Если любой из символов ключа не буква
                        {
                            text[i] = s[i];
                        }
                        else
                        {
                            int indexOfChar = -1;
                            indexOfChar = alRu.IndexOf(s[i]);
                            if (indexOfChar >= 0)
                            {
                                if ((indexOfChar - key[i]) % alRu.Length < 0)
                                {
                                    text[i] = alRu[alRu.Length + (indexOfChar - key[i]) % alRu.Length];
                                }
                                else
                                {
                                    text[i] = alRu[(indexOfChar - key[i]) % alRu.Length];
                                }
                            }
                            else
                            {
                                indexOfChar = -1;
                                indexOfChar = alru.IndexOf(s[i]);
                                if (indexOfChar >= 0)
                                {
                                    if ((indexOfChar - key[i]) % alru.Length < 0)
                                    {
                                        text[i] = alru[alru.Length + (indexOfChar - key[i]) % alru.Length];
                                    }
                                    else
                                    {
                                        text[i] = alru[(indexOfChar - key[i]) % alru.Length];
                                    }
                                }
                                else
                                {
                                    indexOfChar = -1;
                                    indexOfChar = alEn.IndexOf(s[i]);
                                    if (indexOfChar >= 0)
                                    {
                                        if ((indexOfChar - key[i]) % alEn.Length < 0)
                                        {
                                            text[i] = alEn[alEn.Length + (indexOfChar - key[i]) % alEn.Length];
                                        }
                                        else
                                        {
                                            text[i] = alEn[(indexOfChar - key[i]) % alEn.Length];
                                        }
                                    }
                                    else
                                    {
                                        indexOfChar = -1;
                                        indexOfChar = alen.IndexOf(s[i]);
                                        if (indexOfChar >= 0)
                                        {
                                            if ((indexOfChar - key[i]) % alen.Length < 0)
                                            {
                                                text[i] = alen[alen.Length + (indexOfChar - key[i]) % alen.Length];
                                            }
                                            else
                                            {
                                                text[i] = alen[(indexOfChar - key[i]) % alen.Length];
                                            }
                                        }
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