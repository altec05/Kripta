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

        //Алфавиты
        string alRu = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        string alEn = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        string al = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюяABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

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
                    textBox2.Text = Polybius1(textBox1.Text); //Зашифровать Полибий
                    break;
                case "Шифр Кардано":
                    textBox2.Text = Cardano1(textBox1.Text); //Зашифровать Кардано
                    break;
                case "Шифр Ришелье":
                    textBox2.Text = Richelieu1(textBox1.Text); //Зашифровать Ришелье
                    break;
                case "Диск Альберти":
                    textBox2.Text = Disk1(textBox1.Text); //Зашифровать Альберти
                    break;
                case "Шифр Гронсфельда":
                    textBox2.Text = Gronsfeld1(textBox1.Text); //Зашифровать Гронсфельд
                    break;
                case "Шифр Виженера":
                    textBox2.Text = Vizhener1(textBox1.Text); //Зашифровать Виженер
                    break;
                case "Шифр Плейфера":
                    textBox2.Text = Playfair1(textBox1.Text); //Зашифровать Плейфер
                    break;
                case "Шифр Хилла":
                    textBox2.Text = Hill1(textBox1.Text); //Зашифровать Хилл
                    break;
                case "Шифр RSA":
                    textBox2.Text = RSA1(textBox1.Text);
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
                case "Шифр Кардано":
                    textBox2.Text = Cardano2(textBox1.Text); //Расшифровать Кардано
                    break;
                case "Шифр Ришелье":
                    textBox2.Text = Richelieu2(textBox1.Text); //Расшифровать Ришелье
                    break;
                case "Диск Альберти":
                    textBox2.Text = Disk2(textBox1.Text); //Расшифровать Ришелье
                    break;
                case "Шифр Гронсфельда":
                    textBox2.Text = Gronsfeld2(textBox1.Text); //Расшифровать Гронсфельд
                    break;
                case "Шифр Виженера":
                    textBox2.Text = Vizhener2(textBox1.Text); //Расшифровать Виженера
                    break;
                case "Шифр Плейфера":
                    textBox2.Text = Playfair2(textBox1.Text); //Зашифровать Плейфера
                    break;
                case "Шифр Хилла":
                    textBox2.Text = Hill2(textBox1.Text); //Расшифровать Хилл
                    break;
                case "Шифр RSA":
                    textBox2.Text = RSA2(textBox1.Text);
                    break;
            }

        }

        string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя,.!?-;:' ";

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedState = comboBox1.SelectedItem.ToString();
            if(selectedState == "Шифр RSA")
            {
                button1.Location = new Point(468, 165);
                button2.Location = new Point(468, 293);
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = true;
                label12.Visible = true;
                label13.Visible = true;
                label14.Visible = true;
                label15.Visible = true;

                textBox3.Visible = false;
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                textBox7.Visible = false;
                textBox8.Visible = true;
                textBox9.Visible = true;
                textBox10.Visible = true;
                textBox11.Visible = true;
            }
            else
            {
                button1.Location = new Point (337,88);
                button2.Location = new Point(482, 88);
                label12.Visible = false;
                label11.Visible = false;
                label13.Visible = false;
                label14.Visible = false;
                label15.Visible = false;
                textBox8.Visible = false;
                textBox9.Visible = false;
                textBox10.Visible = false;
                textBox11.Visible = false;
                if ((selectedState == "Шифр Цезаря") || (selectedState == "Шифр Сцитала") || (selectedState == "Шифр Гронсфельда") || (selectedState == "Шифр Виженера") || (selectedState == "Шифр Плейфера") || (selectedState == "Шифр Хилла")) //Видимость поля для ключа
                {
                    textBox3.Visible = true;
                    if ((selectedState == "Шифр Цезаря"))
                    {
                        label4.Visible = true;
                        label6.Visible = false;
                        textBox3.Visible = true;
                    }
                    if (selectedState == "Шифр Сцитала")
                    {
                        label6.Visible = true;
                        label4.Visible = false;
                        textBox3.Visible = true;
                    }
                    if (selectedState == "Шифр Гронсфельда" || selectedState == "Шифр Виженера" || selectedState == "Шифр Плейфера" || selectedState == "Шифр Хилла") //Видимость поля для ключа
                    {
                        textBox3.Visible = true;
                        label4.Visible = true;
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

                if (selectedState == "Шифр Ришелье") //Видимость поля для ключа
                {
                    textBox5.Visible = true;
                    label7.Visible = true;
                    label8.Visible = true;
                }
                else
                {
                    textBox5.Visible = false;
                    label7.Visible = false;
                    label8.Visible = false;
                }

                if (selectedState == "Диск Альберти") //Видимость полей для ключей
                {
                    label9.Visible = true;
                    label10.Visible = true;
                    textBox6.Visible = true;
                    textBox7.Visible = true;
                }
                else
                {
                    label9.Visible = false;
                    label10.Visible = false;
                    textBox6.Visible = false;
                    textBox7.Visible = false;
                }
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

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
        private void label7_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
