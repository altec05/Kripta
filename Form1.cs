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
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        string alRu = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        string alEn = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        private void button1_Click(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "Шифр Атбаш":
                    textBox2.Text = Atbash1(textBox1.Text);
                    break;
                case "Шифр Цезаря":
                    textBox2.Text = Orientation(textBox1.Text); //Введённое в tb1 попадёт потом в tb2
                    break;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "Шифр Атбаш":
                    textBox2.Text = Atbash2(textBox1.Text);
                    break;

                case "Шифр Цезаря":
                    textBox2.Text = Orientation2(textBox1.Text); //Введённое в tb1 попадёт потом в tb2
                    break;
            }
            
        }

        public string Atbash1(string inp)
        {
            StringBuilder code = new StringBuilder();
            string s = textBox1.Text; // s - связана с вводимым текстом
            if (textBox1.Text == "")
            {
                MessageBox.Show("Введите текст!", "Пустое поле");
            }
            else
            {
                string al = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюяABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
                
                for (int i = 0; i < s.Length; i++)
                {
                    bool f1 = false;
                    for (int k = 0; k < al.Length; k++)
                    {
                        if (s[i] == al[k])
                        {
                            f1 = true;
                        }
                    }
                    if(f1 == true)
                    {
                        for (int j = 0; j < alRu.Length; j++)
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

                        for (int j = 0; j < alEn.Length; j++)
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
                    }else code.Append(s[i]);

                }
            }
            return code.ToString();
        }

        public string Atbash2(string inp)
        {
            StringBuilder code = new StringBuilder();
            string s = textBox1.Text; // s - связана с вводимым текстом
            if (textBox1.Text == "")
            {
                MessageBox.Show("Введите текст!", "Ошибка ввода данных");
            }
            else
            {
                for (int i = 0; i < s.Length; i++)
                {
                    for (int j = 0; j < alRu.Length; j++)
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
                    for (int j = 0; j < alEn.Length; j++)
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
            }
                return code.ToString();
        }

        public string Orientation(string inp) //ori - для обозачения боока в котором происходит шифрование
        {
            int step = 0;
            StringBuilder code = new StringBuilder();
            string s = textBox1.Text; // s - связана с вводимым текстом
            string sd = textBox3.Text; //sd-количество шагов шифра (ключ шифрования)
            if (textBox3.Text == "")
            {
                MessageBox.Show("Укажите требуемый шаг!");
            }
            else
            {
                //step = Convert.ToInt32(sd);
                //for (int i = 0; i < s.Length; i++)
                //    for (int j = 0; j < al.Length; j++)
                //        if (s[i] == al[j]) code.Append(al[(j + step) % al.Length]);
            }
            return code.ToString();
        }

        public string Orientation2(string inp) //ori - для обозачения боока в котором происходит шифрование
        {
            int step = 0;
            StringBuilder code = new StringBuilder();
            string s = textBox1.Text; // s - связана с вводимым текстом
            string sd = textBox3.Text; //sd-количество шагов шифра (ключ шифрования)
            if (textBox3.Text == "")
            {
                MessageBox.Show("Укажите требуемый шаг!");
            }
            else
            {
                //step = Convert.ToInt32(sd);
                //for (int i = 0; i < s.Length; i++)
                //    for (int j = 0; j < al.Length; j++)
                //        if (s[i] == al[j]) code.Append(al[(j - step + al.Length) % al.Length]);
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
            if(selectedState != "Шифр Цезаря")
            {
                label4.Visible = false;
                textBox3.Visible = false;
            }
            else
            {
                label4.Visible = true;
                textBox3.Visible = true;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
