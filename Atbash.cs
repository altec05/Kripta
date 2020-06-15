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
    } 
}
