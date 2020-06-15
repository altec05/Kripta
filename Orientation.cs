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
                string alRu = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
                string alru = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
                string alEn = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                string alen = "abcdefghijklmnopqrstuvwxyz";

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
                    //else if (step > 32) //Ограничение по алфавиту
                    //{
                    //    for (int i = 0; i < 1; i++)
                    //    {
                    //        MessageBox.Show("Шаг должен быть меньше 32!");
                    //        break;
                    //    }

                    //}
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
                                for (int j = 0; j < alru.Length; j++)
                                {
                                    if (s[i] == alru[j])
                                    {
                                        code.Append(alru[(j + step) % alru.Length]);
                                    }
                                }
                                for (int j = 0; j < alEn.Length; j++)
                                {
                                    if (s[i] == alEn[j])
                                    {
                                        code.Append(alEn[(j + step) % alEn.Length]);
                                    }
                                }
                                for (int j = 0; j < alen.Length; j++)
                                {
                                    if (s[i] == alen[j])
                                    {
                                        code.Append(alen[(j + step) % alen.Length]);
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
                string alRu = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
                string alru = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
                string alEn = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                string alen = "abcdefghijklmnopqrstuvwxyz";

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
                                        if (j - step < 0)
                                        {
                                            code.Append(alRu[((j - step) % alRu.Length) + alRu.Length]);
                                        }
                                        else
                                        {
                                            code.Append(alRu[(j - step) % alRu.Length]);
                                        }

                                    }
                                }
                                for (int j = 0; j < alru.Length; j++)
                                {
                                    if (s[i] == alru[j])
                                    {
                                        if (j - step < 0)
                                        {
                                            code.Append(alru[((j - step) % alru.Length) + alru.Length]);
                                        }
                                        else
                                        {
                                            code.Append(alru[(j - step) % alru.Length]);
                                        }
                                    }
                                }
                                for (int j = 0; j < alEn.Length; j++)
                                {
                                    if (s[i] == alEn[j])
                                    {
                                        if (j - step < 0)
                                        {
                                            code.Append(alEn[((j - step) % alEn.Length) + alEn.Length]);
                                        }
                                        else
                                        {
                                            code.Append(alEn[(j - step) % alEn.Length]);
                                        }
                                    }
                                }
                                for (int j = 0; j < alen.Length; j++)
                                {
                                    if (s[i] == alen[j])
                                    {
                                        if (j - step < 0)
                                        {
                                            code.Append(alen[((j - step) % alen.Length) + alen.Length]);
                                        }
                                        else
                                        {
                                            code.Append(alen[(j - step) % alen.Length]);
                                        }
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
    }
}