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
                    textBox2.Text = Scitala1(textBox1.Text); //Зашифровать Атбаш
                    break;
                case "Квадрат Полибия":
                   // textBox2.Text = Square_P1(textBox1.Text); //Зашифровать Цезарь
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
                    textBox2.Text = Scitala2(textBox1.Text); //Зашифровать Атбаш
                    break;
                case "Квадрат Полибия":
                    //textBox2.Text = Orientation(textBox1.Text); //Зашифровать Цезарь
                    break;
            }

        }

        public string Scitala1(string inp) //Шифрование Сцитала
        {
            int diameter = -1;
            StringBuilder code = new StringBuilder();
            string s = textBox1.Text; // s - связана с вводимым текстом
            string sd = textBox5.Text; //sd-диаметр
            if (textBox1.Text == "") //Проверка на пустое поле
            {
                MessageBox.Show("Введите текст!", "Пустое поле");
            }
            if (textBox5.Text == "") //Проверка на пустой ключ
            {
                MessageBox.Show("Укажите требуемый шаг!", "Пустое поле");
            }
            else
            {
                try //Отлов исключений
                {
                    diameter = Convert.ToInt32(sd); //Перевод string в int
                }
                catch
                {
                    MessageBox.Show("В строке есть недопустимые символы!", "Ошибка ввода"); //Случай, если будут лишние символы
                }
                finally
                {
                    if (diameter < 0) //Если отрицательный шаг
                    {
                        for (int i = 0; i < 1; i++)
                        {
                            MessageBox.Show("Шаг должен быть больше 0!");
                            break;
                        }
                    }
                    else if (diameter == 0) //Если 0 шаг
                    {
                        for (int i = 0; i < 1; i++)
                        {
                            MessageBox.Show("Шаг должен быть больше 0!");
                            break;
                        }
                    }
                    else
                    {
                        if(diameter >= s.Length)//Проверка на размер диаметра
                        {
                            int length = s.Length;
                            string Out = length.ToString();
                            MessageBox.Show("Диаметр должен быть меньше длины сообщения!", "Некорректный диаметр");
                            MessageBox.Show(Out, "Длина сообщения");
                        }
                        else
                        {
                            int count = 0; //Количество добавленных пробелов
                            int col = 0; //Число столбцов
                            int del = 0; //Остаток от деления
                            string open_text = s; //Строка для хранения введённого + пробелы
                            if (s.Length % diameter != 0) //Определяем столбцы
                            {
                                col = (s.Length / diameter) + 1; //Столбцов
                                del = s.Length % diameter;//Остаток
                                for (int i = 0; i < (diameter - del); i++) //Если нужны пробелы
                                {
                                    open_text = open_text + " ";
                                    count++;//Их число
                                }
                            }
                            else//Если не нужны
                            {
                                col = s.Length / diameter;
                            }
                            //Процес шифрования
                            for (int i = 0; i < col; i++)//Проход по столбцам
                            {
                                for (int j = 0; j < diameter; j++)//Проход по символам в столбце
                                {
                                    code.Append(open_text[((j * col) + i) % open_text.Length]);
                                }
                            }
                        }
                    }
                }
            }
            return code.ToString();
        }

        public string Scitala2(string inp) //РАСШИФРОВАНИЕ Сцитала
        {
            int diameter = -1;
            StringBuilder code = new StringBuilder();
            string s = textBox1.Text; // s - связана с вводимым текстом
            string sd = textBox5.Text; //sd-диаметр
            string Out = ""; //Строка для расшифрованной строки
            var text = new char[s.Length]; //Для хранения введённых символов
            var text2 = new char[s.Length]; //Для хранения прочитанных символов
            if (textBox1.Text == "") //Проверка на пустое поле
            {
                MessageBox.Show("Введите текст!", "Пустое поле");
            }
            if (textBox5.Text == "") //Проверка на пустой ключ
            {
                MessageBox.Show("Укажите требуемый шаг!", "Пустое поле");
            }
            else
            {
                try //Отлов исключений
                {
                    diameter = Convert.ToInt32(sd); //Перевод string в int
                }
                catch
                {
                    MessageBox.Show("В строке есть недопустимые символы!", "Ошибка ввода"); //Случай, если будут лишние символы
                }
                finally
                {
                    if (diameter < 0) //Если отрицательный шаг
                    {
                        for (int i = 0; i < 1; i++)
                        {
                            MessageBox.Show("Шаг должен быть больше 0!");
                            break;
                        }
                    }
                    else if (diameter == 0) //Если 0 шаг
                    {
                        for (int i = 0; i < 1; i++)
                        {
                            MessageBox.Show("Шаг должен быть больше 0!");
                            break;
                        }
                    }
                    else
                    {
                        if (diameter >= s.Length)//Проверка на размер диаметра
                        {
                            int length = s.Length;
                            string Out1 = length.ToString();
                            MessageBox.Show("Диаметр должен быть меньше длины сообщения!", "Некорректный диаметр");
                            MessageBox.Show(Out1, "Длина сообщения");
                        }
                        else
                        {

                            int col = 0; //Число столбцов
                            col = s.Length / diameter;

                            for (int i = 0; i < s.Length; i++)
                            {
                                text[i] = s[i]; //Из введённой строки string в строку char[]
                                                //Нужно для дальнейшего перевода в двумерный массив и обработки
                            }

                            char[,] mass = new char[col, diameter]; //Двумерный массив размером[столбцы, диаметр]
                            int t = 0; //Индекс дял перехода по text
                            for (int i = 0; i < col; i++)
                            {
                                for (int j = 0; j < diameter; j++)
                                {
                                    mass[i, j] = text[t];//Записываем из строки char[] в двумерный массив
                                    t++;
                                }
                            }

                            int k = 0;//Индекс для прохода по text2
                            int Char = 0;//Индекс для перехода на конкретную строку букв
                            for (int stroka = 0; stroka < diameter; stroka++)
                            {
                                for (int i = 0; i < col; i++)
                                {
                                    for (int j = Char; j < Char + 1; j++)
                                    {
                                        text2[k] = mass[i, j];//Из массива в строку char[]
                                        k++;//Для перехода по строке char[]
                                    }
                                }
                                Char++;//Буква в массиве
                            }

                            Out = new string(text2);
                            Out = Out.Trim(); //Удаляем пробелы в начале и в конце строки, как лишние
                            code.Append(Out); //Для вывода строки
                        }
                    }
                }
            }
            return code.ToString();
        }

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
                    else if (step > 32) //Ограничение по алфавиту
                    {
                        for (int i = 0; i < 1; i++)
                        {
                            MessageBox.Show("Шаг должен быть меньше 32!");
                            break;
                        }

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
                            if (f1 == true) //Если буква, то проверки по русскому и английскому
                            {
                                for (int j = 0; j < alRu.Length; j++)
                                {
                                    if (s[i] == alRu[j])
                                    {
                                        code.Append(alRu[(j + step) % alRu.Length]);
                                    }
                                }
                                for (int j = 0; j < alEn.Length; j++)
                                {
                                    if (s[i] == alEn[j])
                                    {
                                        code.Append(alEn[(j + step) % alEn.Length]);
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
                    else if (step > 32) //Ограничение по размеру алфавита
                    {
                        for (int i = 0; i < 1; i++)
                        {
                            MessageBox.Show("Шаг должен быть меньше 32!");
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
                                        code.Append(alRu[(j - step + alRu.Length) % alRu.Length]);
                                    }
                                }
                                for (int j = 0; j < alEn.Length; j++)
                                {
                                    if (s[i] == alEn[j])
                                    {
                                        code.Append(alEn[(j - step + alEn.Length) % alEn.Length]);
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedState = comboBox1.SelectedItem.ToString();
            if (selectedState == "Шифр Цезаря") //Видимость поля для ключа
            {
                label4.Visible = true; 
                textBox3.Visible = true;
            }
            else
            {
                label4.Visible = false;
                textBox3.Visible = false;
            }
 
            if (selectedState == "Шифр Сцитала") //Видимость поля для ключа
            {
                
                label6.Visible = true;
                textBox5.Visible = true;
            }
            else
            {
                
                label6.Visible = false;
                textBox5.Visible = false;
            }
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
    }
}
