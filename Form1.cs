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

            //comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        static string al = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя0123456789 ,.!?-+_=№#'$%^:*()";

        private void button1_Click(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "Шифр Цезаря":
                    textBox2.Text = Orientation(textBox1.Text); //Введённое в tb1 попадёт потом в tb2
                    break;
                case "Шифр 2":
                    textBox2.Text = "ВЕДЁТСЯ РАЗРАБОТКА ШИФРОВКИ ДЛЯ ЭТОГО ШИФРА!";
                    break;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "Шифр Цезаря":
                    textBox2.Text = Orientation2(textBox1.Text); //Введённое в tb1 попадёт потом в tb2
                    break;
                case "Шифр 2":
                    textBox2.Text = "ВЕДЁТСЯ РАЗРАБОТКА ДЕШИФРОВКИ ДЛЯ ЭТОГО ШИФРА!";
                    break;
            }
            
        }

        public string Orientation(string inp) //ori - для обозачения боока в котором происходит шифрование
        {
            int step = 0;
            StringBuilder code = new StringBuilder();
            string s = textBox1.Text; // s - связана с вводимым текстом
            string sd = textBox3.Text; //sd-количество шагов шифра (ключ шифрования)
            if(textBox3.Text == "")
            {
                MessageBox.Show("Укажите требуемый шаг!");
            }
            else
            {
                step = Convert.ToInt32(sd);
                for (int i = 0; i < s.Length; i++)
                    for (int j = 0; j < al.Length; j++)
                        if (s[i] == al[j]) code.Append(al[(j + step) % al.Length]);
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
                step = Convert.ToInt32(sd);
                for (int i = 0; i < s.Length; i++)
                    for (int j = 0; j < al.Length; j++)
                        if (s[i] == al[j]) code.Append(al[(j - step + al.Length) % al.Length]);
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
            //MessageBox.Show(selectedState);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
