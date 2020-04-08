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
            }

        }

        public string Richelieu1(string inp) //Расшифровка Полибий
        {
            string s = textBox1.Text; // s - связана с вводимым текстом
            string skey = textBox5.Text; //skey - ключ шифрования
            char[] key = new char[skey.Length];//key - для хранения ключа и его проверок
            string Out = ""; //Строка для зашифрованной строки
            char[] text = new char[s.Length]; //Для хранения введённых символов

            if (textBox1.Text == "") //Проверка на пустое поле
            {
                MessageBox.Show("Введите текст!", "Пустое поле");
                return "";
            }
            if (textBox5.Text == "") //Проверка на пустой ключ
            {
                MessageBox.Show("Укажите ключ шифрования!", "Пустое поле");
                return "";
            }
            else
            {
                string check = "";

                check = skey;
                check = check.Replace("(", "");
                check = check.Replace(")", "");
                check = check.Replace(",", "");

                if (check.Length > s.Length)
                {
                    MessageBox.Show("Недопустимая длина ключа!", "Ключ больше сообщения");
                    return "ОШИБКА КЛЮЧА";
                }
                else
                {
                    string numbers = "123456789(),";
                    string number = "123456789";
                    string marks = ",()";



                    //Перевод ключа в char[]
                    for (int i = 0; i < skey.Length; i++)
                    {
                        key[i] = skey[i];
                    }
                    
                    //Проверка ключа на цифры
                    bool numb;
                    for (int i = 0; i < key.Length; i++)
                    {
                        numb = false;
                        for(int j = 0; j < numbers.Length; j++)
                        {
                            if (key[i] == numbers[j])
                            {
                                numb = true;
                            }
                        }
                        if (numb == false)
                        {
                            return "Неверный ключ!";
                        }
                    }

                    //Определить число комбинаций
                    string s0 = "(";
                    int count = (skey.Length - skey.Replace(s0, "").Length) / s0.Length;
                    
                    //Убираем запятые
                    skey = skey.Replace(",", "");

                    for (int i = 0; i < key.Length; i++)
                    {
                        if (key[0] != '(')
                        {
                            return "Некорректный ввод ключа!";
                        }
                        else if (key[key.Length - 1] != ')')
                        {
                            return "Некорректный ввод ключа!";
                        }
                        else
                        {
                            if (key[i] == '(')
                            {
                                numb = false;
                                for (int j = 0; j < number.Length; j++)
                                {
                                    if (key[i + 1] == number[j])
                                    {
                                        numb = true;
                                    }
                                }
                                if (numb == false)
                                {
                                    return "Некорректный ввод ключа!";
                                }
                            }
                            else if (key[i] == ')')
                            {
                                if (i != key.Length - 1)
                                {
                                    numb = false;
                                    for (int j = 0; j < number.Length; j++)
                                    {

                                        if (key[i + 1] == number[j])
                                        {
                                            numb = true;
                                        }
                                        else if (key[i + 1] == '(' && key[i + 2] != '(' && key[i + 2] != ')')
                                        {
                                            numb = true;
                                        }

                                    }
                                    if (numb == false)
                                    {
                                        return "Некорректный ввод ключа!";
                                    }
                                }
                                else
                                {
                                    break;
                                }

                            }
                            else if (key[i] == ',')
                            {
                                if (key[i + 1] == ',' || key[i - 1] == ',')
                                {
                                    return "Некорректный ввод ключа!";
                                }
                            }
                        }
                    }

                    //Проверяем правильность знаков
                    for (int i = 0; i < key.Length; i++)
                    {
                        if ((key[i] == '(') && (i != 0))
                        {
                            if (key[i - 1] != ')')
                            {
                                return "Некорректный ввод ключа!";
                            }
                        }
                        else if ((key[i] == ')') && (i != key.Length - 1))
                        {
                            if (key[i + 1] != '(')
                            {
                                return "Некорректный ввод ключа!";
                            }
                        }
                        else if (key[i] == ',')
                        {
                            bool numb1 = false;
                            bool numb2 = false;
                            for (int j = 0; j < number.Length; j++)
                            {
                                if (key[i + 1] == number[j])
                                {
                                    numb1 = true;
                                }
                                if (key[i - 1] == number[j])
                                {
                                    numb2 = true;
                                }
                            }
                            if (numb1 == false || numb2 == false)
                            {
                                return "Некорректный ввод ключа!";
                            }
                        }
                    }

                    for (int i = 0; i < key.Length; i++)
                    {
                        for (int j = 0; j < number.Length; j++)
                        {
                            bool mark1 = false;
                            bool mark2 = false;
                            if (key[i] == number[j])
                            {
                                for (int m = 0; m < marks.Length; m++)
                                {
                                    if (key[i - 1] == marks[m])
                                    {
                                        mark1 = true;
                                    }
                                    if (key[i + 1] == marks[m])
                                    {
                                        mark2 = true;
                                    }
                                }
                                if (mark1 == false || mark2 == false)
                                {
                                    return "Некорректный ввод ключа!";
                                }
                            }
                        }
                    }

                    //Разделяем по скобкам
                    char[] charSeparators = new char[] { '(', ')' };
                    string[] split = skey.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
                    //Создаём массивы массивов для цифр
                    int[][] arr = new int[split.Length][];//Для проверки
                    int[][] arr2 = new int[split.Length][];//Для применения
                    //переводим в int
                    for (int i = 0; i < arr.Length; i++)
                    {
                        arr[i] = split[i].ToCharArray().Select(j => int.Parse(j.ToString())).ToArray();
                    }
                    for (int i = 0; i < arr.Length; i++)
                    {
                        arr2[i] = split[i].ToCharArray().Select(j => int.Parse(j.ToString())).ToArray();
                    }

                    //Сортировка ключа для проверки
                    for (int n = 0; n < arr.Length; n++)
                    {
                        int temp;
                        for (int i = 0; i < arr[n].Length - 1; i++)
                        {
                            for (int j = i + 1; j < arr[n].Length; j++)
                            {
                                if (arr[n][i] > arr[n][j])
                                {
                                    temp = arr[n][i];
                                    arr[n][i] = arr[n][j];
                                    arr[n][j] = temp;
                                }
                            }
                        }
                    }

                    //Проверям последовательность
                    for (int n = 0; n < arr.Length; n++)
                    {
                        if(arr[n][0] == 1)
                        {
                            bool dif;
                            for (int i = 0; i < arr[n].Length - 1; i++)
                            {
                                dif = false;
                                int Dif = arr[n][i + 1] - arr[n][i];
                                if (Dif == 1)
                                {
                                    dif = true;
                                }
                                if (dif == false)
                                {
                                    return "Ключ должен начинаться с 1 и между значениями должна быть разница в единицу!";
                                }
                            }
                        }
                        else
                        {
                            return "Ключ должен начинаться с 1 и между значениями должна быть разница в единицу!";
                        }
                        
                    }

                    //Из string в char[] текст
                    for(int i = 0; i < s.Length; i++)
                    {
                        text[i] = s[i];
                    }

                        int k = 0;
                    if(s.Length == check.Length)
                    {
                        char [][]text2 = new char[arr2.Length][];//Для разделения текста
                        for(int i = 0; i < text2.Length; i++)
                        {
                            text2[i] = new char[arr2[i].Length];
                        }
                        for (int n = 0; n < text2.Length; n++)
                        {
                            for (int i = 0; i < arr2[n].Length; i++)
                            {
                                text2[n][i] = text[k];
                                k++;
                            }
                        }

                        swap(arr2, text2);
                        k = 0;
                        for (int i = 0; i < text2.Length; i++)
                        {
                            for (int j = 0; j < text2[i].Length; j++)
                            {
                                text[k] = text2[i][j];
                                k++;
                            }
                        }
                        Out = new string(text);
                    }
                    else if(s.Length > check.Length)
                    {
                        int size = 0;
                        for(int i = 0; i < arr2.Length; i++)
                        {
                            size = size + arr2[i].Length;
                        }
                        
                        char[][]text2 = new char[arr2.Length + 1][];//Для разделения текста
                        for (int i = 0; i < text2.Length; i++)
                        {
                            if(i == arr2.Length)
                            {
                                text2[i] = new char[s.Length - size];
                            }
                            else
                            {
                                text2[i] = new char[arr2[i].Length];
                            }
                            
                        }

                        for (int n = 0; n < text2.Length; n++)
                        {
                            if(k < skey.Length)
                            {
                                if(n < arr2.Length)
                                {
                                    for (int i = 0; i < arr2[n].Length; i++)
                                    {
                                        text2[n][i] = text[k];
                                        k++;
                                    }
                                }
                                else
                                {
                                    for (int i = 0; i < s.Length - size; i++)
                                    {
                                        text2[n][i] = text[k];
                                        k++;
                                    }
                                }
                                
                            }
                            else
                            {
                                for (int i = 0; i < text.Length; i++)
                                {
                                    text2[n][i] = text[k];
                                    k++;
                                }
                            }
                            
                        }

                        swap(arr2, text2);
                        k = 0;
                        for (int i = 0; i < text2.Length; i++)
                        {
                            for(int j = 0; j < text2[i].Length; j++)
                            {
                                text[k] = text2[i][j];
                                k++;
                            }
                        }
                        Out = new string(text);
                    }
                }
            }
                return Out;
        }

        public static char[][] swap(int[][] arr2, char[][]text2 )
        {
            for (int n = 0; n < text2.Length; n++)
            {
                if (n == arr2.Length)
                {
                    break;
                }
                else
                {
                    char temp1;
                    int temp2;
                    for (int i = 0; i < arr2[n].Length - 1; i++)
                    {
                        if (i >= arr2[n].Length)
                        {
                            continue;
                        }
                        else
                        {
                            for (int j = i + 1; j < arr2[n].Length; j++)
                            {
                                if (arr2[n][i] > arr2[n][j])
                                {
                                    temp1 = text2[n][i];
                                    text2[n][i] = text2[n][j];
                                    text2[n][j] = temp1;

                                    temp2 = arr2[n][i];
                                    arr2[n][i] = arr2[n][j];
                                    arr2[n][j] = temp2;
                                }
                            }
                        }
                    }
                }
            }
            return text2;
        }

        public static char[][] swap2(int[][] arr2, char[][] text2, char[][] text3)
        {
            for (int n = 0; n < text2.Length; n++)
            {
                if (n == arr2.Length)
                {
                    break;
                }
                else
                {
                    for (int i = 0; i < text2[n].Length; i++)
                    {
                        if (i >= arr2[n].Length)
                        {
                            continue;
                        }
                        else
                        {
                            for (int j = 0; j < arr2[n].Length; j++)
                            {
                                if (i == (arr2[n][j]-1))
                                {
                                    text3[n][j] = text2[n][i];
                                }
                            }
                        }
                    }
                }
            }
            return text2;
        }
            public string Richelieu2(string inp) //Расшифровка Полибий
        {
            string s = textBox1.Text; // s - связана с вводимым текстом
            string skey = textBox5.Text; //skey - ключ шифрования
            char[] key = new char[skey.Length];//key - для хранения ключа и его проверок
            string Out = ""; //Строка для зашифрованной строки
            char[] text = new char[s.Length]; //Для хранения введённых символов

            if (textBox1.Text == "") //Проверка на пустое поле
            {
                MessageBox.Show("Введите текст!", "Пустое поле");
                return "";
            }
            if (textBox5.Text == "") //Проверка на пустой ключ
            {
                MessageBox.Show("Укажите ключ шифрования!", "Пустое поле");
                return "";
            }
            else
            {
                string check = "";

                check = skey;
                check = check.Replace("(", "");
                check = check.Replace(")", "");
                check = check.Replace(",", "");

                if (check.Length > s.Length)
                {
                    MessageBox.Show("Недопустимая длина ключа!", "Ключ больше сообщения");
                    return "ОШИБКА КЛЮЧА";
                }
                else
                {
                    string numbers = "123456789(),";
                    string number = "123456789";
                    string marks = "(),";



                    //Перевод ключа в char[]
                    for (int i = 0; i < skey.Length; i++)
                    {
                        key[i] = skey[i];
                    }

                    //Проверка ключа на цифры
                    bool numb;
                    for (int i = 0; i < key.Length; i++)
                    {
                        numb = false;
                        for (int j = 0; j < numbers.Length; j++)
                        {
                            if (key[i] == numbers[j])
                            {
                                numb = true;
                            }
                        }
                        if (numb == false)
                        {
                            return "Неверный ключ!";
                        }
                    }

                    //Определить число комбинаций
                    string s0 = "(";
                    int count = (skey.Length - skey.Replace(s0, "").Length) / s0.Length;

                    //Убираем запятые
                    skey = skey.Replace(",", "");

                    for (int i = 0; i < key.Length; i++)
                    {
                        if (key[0] != '(')
                        {
                            return "Некорректный ввод ключа!";
                        }
                        else if (key[key.Length - 1] != ')')
                        {
                            return "Некорректный ввод ключа!";
                        }
                        else
                        {
                            if (key[i] == '(')
                            {
                                numb = false;
                                for (int j = 0; j < number.Length; j++)
                                {
                                    if (key[i + 1] == number[j])
                                    {
                                        numb = true;
                                    }
                                }
                                if (numb == false)
                                {
                                    return "Некорректный ввод ключа!";
                                }
                            }
                            else if (key[i] == ')')
                            {
                                if (i != key.Length - 1)
                                {
                                    numb = false;
                                    for (int j = 0; j < number.Length; j++)
                                    {

                                        if (key[i + 1] == number[j])
                                        {
                                            numb = true;
                                        }
                                        else if (key[i + 1] == '(' && key[i + 2] != '(' && key[i + 2] != ')')
                                        {
                                            numb = true;
                                        }

                                    }
                                    if (numb == false)
                                    {
                                        return "Некорректный ввод ключа!";
                                    }
                                }
                                else
                                {
                                    break;
                                }

                            }
                            else if (key[i] == ',')
                            {
                                if (key[i + 1] == ',' || key[i - 1] == ',')
                                {
                                    return "Некорректный ввод ключа!";
                                }
                            }
                        }
                    }

                    //Проверяем правильность знаков
                    for (int i = 0; i < key.Length; i++)
                    {
                        if ((key[i] == '(') && (i != 0))
                        {
                            if (key[i - 1] != ')')
                            {
                                return "Некорректный ввод ключа!";
                            }
                        }
                        else if ((key[i] == ')') && (i != key.Length - 1))
                        {
                            if (key[i + 1] != '(')
                            {
                                return "Некорректный ввод ключа!";
                            }
                        }
                        else if (key[i] == ',')
                        {
                            bool numb1 = false;
                            bool numb2 = false;
                            for (int j = 0; j < number.Length; j++)
                            {
                                if (key[i + 1] == number[j])
                                {
                                    numb1 = true;
                                }
                                if (key[i - 1] == number[j])
                                {
                                    numb2 = true;
                                }
                            }
                            if (numb1 == false || numb2 == false)
                            {
                                return "Некорректный ввод ключа!";
                            }
                        }
                    }

                    for (int i = 0; i < key.Length; i++)
                    {
                        for (int j = 0; j < number.Length; j++)
                        {
                            bool mark1 = false;
                            bool mark2 = false;
                            if (key[i] == number[j])
                            {
                                for (int m = 0; m < marks.Length; m++)
                                {
                                    if (key[i - 1] == marks[m])
                                    {
                                        mark1 = true;
                                    }
                                    if (key[i + 1] == marks[m])
                                    {
                                        mark2 = true;
                                    }
                                }
                                if (mark1 == false || mark2 == false)
                                {
                                    return "Некорректный ввод ключа!";
                                }
                            }
                        }
                    }

                    //Разделяем по скобкам
                    char[] charSeparators = new char[] { '(', ')' };
                    string[] split = skey.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
                    //Создаём массивы массивов для цифр
                    int[][] arr = new int[split.Length][];//Для проверки
                    int[][] arr2 = new int[split.Length][];//Для применения
                    //переводим в int
                    for (int i = 0; i < arr.Length; i++)
                    {
                        arr[i] = split[i].ToCharArray().Select(j => int.Parse(j.ToString())).ToArray();
                    }
                    for (int i = 0; i < arr.Length; i++)
                    {
                        arr2[i] = split[i].ToCharArray().Select(j => int.Parse(j.ToString())).ToArray();
                    }

                    //Сортировка ключа для проверки
                    for (int n = 0; n < arr.Length; n++)
                    {
                        int temp;
                        for (int i = 0; i < arr[n].Length - 1; i++)
                        {
                            for (int j = i + 1; j < arr[n].Length; j++)
                            {
                                if (arr[n][i] > arr[n][j])
                                {
                                    temp = arr[n][i];
                                    arr[n][i] = arr[n][j];
                                    arr[n][j] = temp;
                                }
                            }
                        }
                    }

                    //Проверям последовательность
                    for (int n = 0; n < arr.Length; n++)
                    {
                        if (arr[n][0] == 1)
                        {
                            bool dif;
                            for (int i = 0; i < arr[n].Length - 1; i++)
                            {
                                dif = false;
                                int Dif = arr[n][i + 1] - arr[n][i];
                                if (Dif == 1)
                                {
                                    dif = true;
                                }
                                if (dif == false)
                                {
                                    return "Ключ должен начинаться с 1 и между значениями должна быть разница в единицу!";
                                }
                            }
                        }
                        else
                        {
                            return "Ключ должен начинаться с 1 и между значениями должна быть разница в единицу!";
                        }

                    }

                    //Из string в char[] текст
                    for (int i = 0; i < s.Length; i++)
                    {
                        text[i] = s[i];
                    }


                    int k = 0;
                    if (s.Length == check.Length)
                    {
                        char[][] text2 = new char[arr2.Length][];//Для разделения текста
                        char[][] text3 = new char[arr2.Length][];//Для разделения текста
                        for (int i = 0; i < text2.Length; i++)
                        {
                            text2[i] = new char[arr2[i].Length];
                            text3[i] = new char[arr2[i].Length];
                        }
                        for (int n = 0; n < text2.Length; n++)
                        {
                            for (int i = 0; i < arr2[n].Length; i++)
                            {
                                text2[n][i] = text[k];
                                text3[n][i] = text[k];
                                k++;
                            }
                        }

                        swap2(arr2, text2, text3);
                        k = 0;
                        for (int i = 0; i < text2.Length; i++)
                        {
                            for (int j = 0; j < text2[i].Length; j++)
                            {
                                text[k] = text3[i][j];
                                k++;
                            }
                        }
                        Out = new string(text);
                    }
                    else if (s.Length > check.Length)
                    {
                        int size = 0;
                        for (int i = 0; i < arr2.Length; i++)
                        {
                            size = size + arr2[i].Length;
                        }

                        char[][] text2 = new char[arr2.Length + 1][];//Для разделения текста
                        char[][] text3 = new char[arr2.Length + 1][];
                        for (int i = 0; i < text2.Length; i++)
                        {
                            if (i == arr2.Length)
                            {
                                text2[i] = new char[s.Length - size];
                                text3[i] = new char[s.Length - size];
                            }
                            else
                            {
                                text2[i] = new char[arr2[i].Length];
                                text3[i] = new char[arr2[i].Length];
                            }

                        }

                        for (int n = 0; n < text2.Length; n++)
                        {
                            if (k < skey.Length)
                            {
                                if (n < arr2.Length)
                                {
                                    for (int i = 0; i < arr2[n].Length; i++)
                                    {
                                        text2[n][i] = text[k];
                                        text3[n][i] = text[k];
                                        k++;
                                    }
                                }
                                else
                                {
                                    for (int i = 0; i < s.Length - size; i++)
                                    {
                                        text2[n][i] = text[k];
                                        text3[n][i] = text[k];
                                        k++;
                                    }
                                }

                            }
                            else
                            {
                                for (int i = 0; i < text.Length; i++)
                                {
                                    text2[n][i] = text[k];
                                    text3[n][i] = text[k];
                                    k++;
                                }
                            }

                        }

                        swap2(arr2, text2, text3);
                        k = 0;
                        for (int i = 0; i < text2.Length; i++)
                        {
                            for (int j = 0; j < text2[i].Length; j++)
                            {
                                text[k] = text3[i][j];
                                k++;
                            }
                        }
                        Out = new string(text);
                    }
                }
            }
            return Out;
        }

        public string Cardano1(string inp)
        {
            string s = textBox1.Text; // s - введённый текст
            char[] text = new char[s.Length]; //Для хранения введённых символов
            char[] text2; //Для хранения изменённых символов
            string Out = ""; //Строка для расшифрованной строки

            if (textBox1.Text == "") //Проверка на пустое поле
            {
                MessageBox.Show("Введите текст!", "Пустое поле");
                return "ОШИБКА ВВОДА";
            }
            else
            {
                if(s.Length > 48 || s.Length < 4)
                {
                    MessageBox.Show("Текст должен быть длиной меньше 48 и больше 4 символов!", "Недопустимая длина текста");
                    return "ОШИБКА ВВОДА";
                }
                else
                {
                    for(int i = 0; i < s.Length; i++)
                    {
                        text[i] = s[i];
                    }

                    int ciphertext = s.Length / 16; //Таблиц
                    int mod = s.Length % 16; //Остаток

                    //Создаём трафарет
                    const int SIZE = 4;
                    int[,] grid = new int[SIZE, SIZE]{
                          {0, 1, 0, 0},
                          {1, 0, 0, 0},
                          {0, 0, 1, 0},
                          {0, 0, 0, 1}
                    };
                    //Инициализируем массивы под шифротекст
                    if (mod == 0)
                    {
                        text2 = new char[s.Length]; //Выделение памяти
                        //Массив массивов
                        if (ciphertext == 1)
                        {
                            char[][,] Array = new char[1][,]
                            {
                            new char[4,4]
                            };
                            //Его обработка
                            Init(SIZE, Array, grid, text, text2, s);

                        }
                        else if (ciphertext == 2)
                        {
                            char[][,] Array = new char[2][,]
                            {
                            new char[4,4],
                            new char[4,4]
                            };

                            Init(SIZE, Array, grid, text, text2, s);
                        }
                        else if (ciphertext == 3)
                        {
                            char[][,] Array = new char[3][,]
                            {
                            new char[4,4],
                            new char[4,4],
                            new char[4,4]
                            };

                            Init(SIZE, Array, grid, text, text2, s);
                        }
                    }
                    else
                    {

                        ciphertext = ciphertext + 1;
                        text2 = new char[ciphertext * 16];

                        if (ciphertext == 1)
                        {
                            char[][,] Array = new char[1][,]
                               {
                            new char[4,4]
                               };

                            Init(SIZE, Array, grid, text, text2, s);

                        }
                        else if (ciphertext == 2)
                        {
                            char[][,] Array = new char[2][,]
                            {
                            new char[4,4],
                            new char[4,4]
                            };

                            Init(SIZE, Array, grid, text, text2, s);
                        }
                        else if (ciphertext == 3)
                        {
                            char[][,] Array = new char[3][,]
                            {
                            new char[4,4],
                            new char[4,4],
                            new char[4,4]
                            };

                            Init(SIZE, Array, grid, text, text2, s);                          
                        }
                    }
                    Out = new string(text2);
                }
            }
            return Out;
        }
        //Функция для обработки таблиц
        public static char[] Init(int SIZE, char[][,] Array, int[,] grid, char[] text, char[] text2, string s)
        {
            int c = Array.Length;
            int k = 0;
            for (int n = 0; n < c; n++) //Для каждого массива
            {
                //Повернули трафарет на 0 градусов
                for (int i = 0; i < SIZE; i++)
                {
                    for (int j = 0; j < SIZE; j++)
                    {
                        if (grid[i, j] == 1)
                        {
                            if(k < s.Length)
                            {
                                Array[n][i, j] = text[k];
                                k++;
                            }
                            else
                            {
                                Array[n][i, j] = '*';
                                k++;
                            }
                            
                        }
                    }
                }
                //90
                for (int i = 0; i < SIZE; i++)
                {
                    for (int j = 0; j < SIZE; j++)
                    {
                        if (grid[SIZE - j - 1, i] == 1)
                        {
                            if (k < s.Length)
                            {
                                Array[n][i, j] = text[k];
                                k++;
                            }
                            else
                            {
                                Array[n][i, j] = '*';
                                k++;
                            }
                            
                        }
                    }
                }
                //180
                for (int i = 0; i < SIZE; i++)
                {
                    for (int j = 0; j < SIZE; j++)
                    {
                        if (grid[SIZE - i - 1, SIZE - j - 1] == 1)
                        {
                            if (k < s.Length)
                            {
                                Array[n][i, j] = text[k];
                                k++;
                            }
                            else
                            {
                                Array[n][i, j] = '*';
                                k++;
                            }
                            
                        }
                    }
                }
                //270
                for (int i = 0; i < SIZE; i++)
                {
                    for (int j = 0; j < SIZE; j++)
                    {
                        if (grid[j, SIZE - i - 1] == 1)
                        {
                            if (k < s.Length)
                            {
                                Array[n][i, j] = text[k];
                                k++;
                            }
                            else
                            {
                                Array[n][i, j] = '*';
                                k++;
                            }
                            
                        }
                    }
                }
            }
            //Считываем из таблиц построчно
            int count = 0;
            for (int m = 0; m < c; m++)
            {
                for (int i = 0; i < SIZE; i++)
                {
                    for (int j = 0; j < SIZE; j++)
                    {
                            text2[count] = Array[m][i, j];
                            count++;
                    }
                }
            }
                return text2;
        }

        public string Cardano2(string inp)
        {
            string s = textBox1.Text; // s - введённый текст
            string s1; //Для выписывания символов
            char[] text = new char[s.Length]; //Для хранения введённых символов
            char[] text2; //Для хранения изменённых символов
            string Out = ""; //Строка для расшифрованной строки

            if (textBox1.Text == "") //Проверка на пустое поле
            {
                MessageBox.Show("Введите текст!", "Пустое поле");
                return "ОШИБКА ВВОДА";
            }
            else
            {
                if (s.Length > 48 || s.Length < 4)
                {
                    MessageBox.Show("Текст должен быть длиной меньше 48 и больше 4 символов!", "Недопустимая длина текста");
                    return "ОШИБКА ВВОДА";
                }
                else
                {
                    //Переводим в char[]
                    for (int i = 0; i < s.Length; i++)
                    {
                        text[i] = s[i];
                    }

                    int ciphertext = s.Length / 16;

                    //Создаём трафарет
                    const int SIZE = 4;
                    int[,] grid = new int[SIZE, SIZE]{
                          {0, 1, 0, 0},
                          {1, 0, 0, 0},
                          {0, 0, 1, 0},
                          {0, 0, 0, 1}
                    };
                    //Выделяем память
                        text2 = new char[s.Length];
                    //Массив массивов
                        if (ciphertext == 1)
                        {
                            char[][,] Array = new char[1][,]
                            {
                            new char[4,4]
                            };
                        //Его обработка
                            Init2(SIZE, Array, grid, text, text2, s);

                        }
                        else if (ciphertext == 2)
                        {
                            char[][,] Array = new char[2][,]
                            {
                            new char[4,4],
                            new char[4,4]
                            };

                            Init2(SIZE, Array, grid, text, text2, s);
                        }
                        else if (ciphertext == 3)
                        {
                            char[][,] Array = new char[3][,]
                            {
                            new char[4,4],
                            new char[4,4],
                            new char[4,4]
                            };

                            Init2(SIZE, Array, grid, text, text2, s);
                        }

                    Out = new string(text2);
                    //Удаляем из полученного звёздочки в конце, т.к они идут для шифрования с "мусором"
                    char[] MyChar = { '*' };
                    s1 = Out.TrimEnd(MyChar);

                }
            }
            return s1;
        }
        //Обработка массива
        public static char[] Init2(int SIZE, char[][,] Array, int[,] grid, char[] text, char[] text2, string s)
        {
            int c = Array.Length; //Сколько массивов в массиве
            int k = 0;//Счётчики
            int count = 0;

            for (int n = 0; n < c; n++)//Заполняем массивы построчно
            {
                for (int i = 0; i < SIZE; i++)
                {
                    for (int j = 0; j < SIZE; j++)
                    {
                        Array[n][i, j] = text[count];
                        count++;
                    }
                }
            }

            //Читаем массивы через трафарет
            for (int n = 0; n < c; n++) //Для каждого массива
            {
                //0
                for (int i = 0; i < SIZE; i++)
                {
                    for (int j = 0; j < SIZE; j++)
                    {
                        if (grid[i, j] == 1)
                        {
                                text2[k] = Array[n][i, j];
                                k++;
                        }
                    }
                }
                //90
                for (int i = 0; i < SIZE; i++)
                {
                    for (int j = 0; j < SIZE; j++)
                    {
                        if (grid[SIZE - j - 1, i] == 1)
                        {
                            text2[k] = Array[n][i, j];
                                k++;
                        }
                    }
                }
                //180
                for (int i = 0; i < SIZE; i++)
                {
                    for (int j = 0; j < SIZE; j++)
                    {
                        if (grid[SIZE - i - 1, SIZE - j - 1] == 1)
                        {
                                text2[k] = Array[n][i, j];
                                k++;
                        }
                    }
                }
                //270
                for (int i = 0; i < SIZE; i++)
                {
                    for (int j = 0; j < SIZE; j++)
                    {
                        if (grid[j, SIZE - i - 1] == 1)
                        {
                                text2[k] = Array[n][i, j];
                                k++;
                        }
                    }
                }
            }

            return text2;
        }

        public string Scitala1(string inp) //Шифрование Сцитала
        {
            int diameter = -1;
            StringBuilder code = new StringBuilder();
            string s = textBox1.Text; // s - связана с вводимым текстом
            string sd = textBox3.Text; //sd-диаметр
            if (textBox1.Text == "") //Проверка на пустое поле
            {
                MessageBox.Show("Введите текст!", "Пустое поле");
            }
            if (textBox3.Text == "") //Проверка на пустой ключ
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
                            string Out = length.ToString();
                            MessageBox.Show("Диаметр должен быть меньше длины сообщения!", "Некорректный диаметр");
                            MessageBox.Show(Out, "Длина сообщения");
                        }
                        else
                        {
                            int col = 0; //Число столбцов
                            string open_text = s; //Строка для хранения введённого
                            if (s.Length % diameter != 0) //Определяем столбцы
                            {
                                col = (s.Length / diameter) + 1; //Столбцов
                            }
                            else
                            {
                                col = s.Length / diameter;
                            }
                            //Процес шифрования
                            int numbers = 0; //Подсчёт пройденных букв
                            for (int i = 0; i < col; i++)//Проход по столбцам
                            {
                                for (int j = 0; j < diameter; j++)//Проход по символам в столбце
                                {
                                    //if (open_text.Length < (col * diameter))
                                    if (open_text.Length > (col * j + i))
                                    {
                                        if (numbers >= open_text.Length)
                                        {
                                            numbers++;
                                            continue;
                                        }
                                        else
                                        {
                                            code.Append(open_text[((j * col) + i) % open_text.Length]);
                                            numbers++;
                                        }
                                    }
                                    else
                                    {
                                        continue;
                                    }


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
            string sd = textBox3.Text; //sd-диаметр
            string Out = ""; //Строка для расшифрованной строки
            var text = new char[s.Length]; //Для хранения введённых символов
            var text2 = new char[s.Length]; //Для хранения прочитанных символов
            if (textBox1.Text == "") //Проверка на пустое поле
            {
                MessageBox.Show("Введите текст!", "Пустое поле");
            }
            if (textBox3.Text == "") //Проверка на пустой ключ
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
                            if (s.Length % diameter != 0) //Определяем столбцы
                            {
                                col = (s.Length / diameter) + 1; //Столбцов
                            }
                            else//Если без остатка
                            {
                                col = s.Length / diameter;
                            }

                            for (int i = 0; i < s.Length; i++)
                            {
                                text[i] = s[i]; //Из введённой строки string в строку char[]
                                                //Нужно для дальнейшего перевода в двумерный массив и обработки
                            }

                            int numbers = 0;
                            char[,] mass = new char[col, diameter]; //Двумерный массив размером[столбцы, диаметр]
                            int t = 0; //Индекс дял перехода по text
                            for (int i = 0; i < col; i++)
                            {
                                for (int j = 0; j < diameter; j++)
                                {
                                    if (text.Length > (col * j + i))
                                    {
                                        if (numbers >= text.Length)
                                        {
                                            //numbers++;
                                            continue;
                                        }
                                        else
                                        {
                                            mass[i, j] = text[t];//Записываем из строки char[] в двумерный массив
                                            t++;
                                            numbers++;
                                        }
                                    }
                                    else
                                    {
                                        //mass[i, j] = text[t];//Записываем из строки char[] в двумерный массив
                                        continue;
                                        t++;
                                        numbers++;
                                    }
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
                                        if (k < numbers)
                                        {
                                            text2[k] = mass[i, j];//Из массива в строку char[]
                                            k++;//Для перехода по строке char[]
                                        }
                                        else
                                        {
                                            break;
                                        }

                                    }
                                }
                                Char++;//Буква в массиве
                            }

                            Out = new string(text2);
                            code.Append(Out); //Для вывода строки
                        }
                    }
                }
            }
            return code.ToString();
        }

        public string Polybius1(string inp) //Шифрование Сцитала
        {
            string alRu1 = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            string alru1 = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            string alEn1 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string alen1 = "abcdefghijklmnopqrstuvwxyz";
            StringBuilder code = new StringBuilder();
            string s = textBox1.Text; // s - связана с вводимым текстом
            string skey = textBox4.Text; //skey - ключ шифрования
            char[] key = new char[skey.Length];//key - для хранения ключа и его проверок
            var text = new char[s.Length]; //Для хранения введённых символов
            int alphabet1 = 0; //Для сравнения алфавитов ключа и строки
            int alphabet2 = 0; //Для сравнения алфавитов ключа и строки
            string Out = ""; //Строка для расшифрованной строки
            var text1 = new char[s.Length]; //Для хранения введённых символов

            if (textBox1.Text == "") //Проверка на пустое поле
            {
                MessageBox.Show("Введите текст!", "Пустое поле");
                return "";
            }
            if (textBox4.Text == "") //Проверка на пустой ключ
            {
                MessageBox.Show("Укажите ключ шифрования!", "Пустое поле");
                return "";
            }
            else
            {
                for (int i = 0; i < skey.Length; i++)//Ключ из string в char[]
                {
                    key[i] = skey[i];
                }

                bool bukva = true;

                for (int i = 0; i < key.Length; i++)//Проверка ключа
                {


                    int indexOfChar = -1;
                    indexOfChar = al.IndexOf(key[i]);
                    if (indexOfChar < 0)//Если любой из символов ключа не буква
                    {
                        MessageBox.Show("Ключ должен быть буквенным!", "Неверный ключ");
                        bukva = false;
                        return "";
                    }
                }
                if (bukva == false)
                {
                    MessageBox.Show("Тут не только буквы!", "Ошибка ключа");
                    return "";
                }//Проверка на одинаковый алфавит и регистр
                else
                {
                    int indexOfChar1 = -1;
                    int indexOfChar2 = -1;
                    int indexOfChar3 = -1;
                    int indexOfChar4 = -1;
                    indexOfChar1 = alRu1.IndexOf(key[0]);
                    indexOfChar2 = alru1.IndexOf(key[0]);
                    indexOfChar3 = alEn1.IndexOf(key[0]);
                    indexOfChar4 = alen1.IndexOf(key[0]);
                    int R1 = 0;
                    int r1 = 0;
                    int E1 = 0;
                    int e1 = 0;
                    bool Ru1 = false;
                    bool ru1 = false;
                    bool En1 = false;
                    bool en1 = false;

                    //Определение алфавита для первого символа и сравнение других
                    if (indexOfChar1 >= 0)
                    {
                        for (int i = 0; i < key.Length; i++)
                        {
                            indexOfChar1 = -1;
                            indexOfChar1 = alRu1.IndexOf(key[i]);
                            if (indexOfChar1 >= 0)
                            {
                                R1++;
                            }
                        }
                        if (R1 == key.Length)
                        {
                            Ru1 = true;
                            alphabet1 = 1;
                        }
                        else
                        {
                            Ru1 = false;
                            MessageBox.Show("Введите буквы одинакового алфавита и регистра!", "Ошибка ключа");
                            return "";
                        }
                    }
                    else if (indexOfChar2 >= 0)
                    {
                        for (int i = 0; i < key.Length; i++)
                        {
                            indexOfChar2 = -1;
                            indexOfChar2 = alru1.IndexOf(key[i]);
                            if (indexOfChar2 >= 0)
                            {
                                r1++;
                            }
                        }
                        if (r1 == key.Length)
                        {
                            ru1 = true;
                            alphabet1 = 2;
                        }
                        else
                        {
                            ru1 = false;
                            MessageBox.Show("Введите буквы одинакового алфавита и регистра!", "Ошибка ключа");
                            return "";
                        }
                    }
                    else if (indexOfChar3 >= 0)
                    {
                        for (int i = 0; i < key.Length; i++)
                        {
                            indexOfChar3 = -1;
                            indexOfChar3 = alEn1.IndexOf(key[i]);
                            if (indexOfChar3 >= 0)
                            {
                                E1++;
                            }
                        }
                        if (E1 == key.Length)
                        {
                            En1 = true;
                            alphabet1 = 3;
                        }
                        else
                        {
                            Ru1 = false;
                            MessageBox.Show("Введите буквы одинакового алфавита и регистра!", "Ошибка ключа");
                            return "";
                        }
                    }
                    else if (indexOfChar4 >= 0)
                    {
                        for (int i = 0; i < key.Length; i++)
                        {
                            indexOfChar4 = -1;
                            indexOfChar4 = alen1.IndexOf(key[i]);
                            if (indexOfChar4 >= 0)
                            {
                                e1++;
                            }
                        }
                        if (e1 == key.Length)
                        {
                            en1 = true;
                            alphabet1 = 4;
                        }
                        else
                        {
                            en1 = false;
                            MessageBox.Show("Введите буквы одинакового алфавита и регистра!", "Ошибка ключа");
                            return "";
                        }
                    }
                }

                for (int i = 0; i < s.Length; i++)//Текст из string в char[]
                {
                    text[i] = s[i];
                }
                int check = 0;
                for (int i = 0; i < s.Length; i++)//Число подходящих символов
                {
                    int indexOfChar = -1;
                    indexOfChar = al.IndexOf(s[i]);
                    if (indexOfChar >= 0)
                    {
                        check++;
                    }
                }
                int j = 0;
                var text_check = new char[check];//Для хранения строки для проверки
                for (int i = 0; i < s.Length; i++)//Текст из string в char[] для проверки алфавита и регистра
                {
                    int indexOfChar = -1;
                    indexOfChar = al.IndexOf(s[i]);
                    if (indexOfChar >= 0)
                    {
                        text_check[j] = s[i];
                        j++;
                    }
                }

                //Проверка text_check на регистр и алфавит
                int indexOfChar5 = -1;
                int indexOfChar6 = -1;
                int indexOfChar7 = -1;
                int indexOfChar8 = -1;
                indexOfChar5 = alRu1.IndexOf(key[0]);
                indexOfChar6 = alru1.IndexOf(key[0]);
                indexOfChar7 = alEn1.IndexOf(key[0]);
                indexOfChar8 = alen1.IndexOf(key[0]);
                int R = 0;
                int r = 0;
                int E = 0;
                int e = 0;
                bool Ru2 = false;
                bool ru2 = false;
                bool En2 = false;
                bool en2 = false;

                //Определение алфавита для первого символа и сравнение других
                if (indexOfChar5 >= 0)
                {
                    for (int i = 0; i < text_check.Length; i++)
                    {
                        indexOfChar5 = -1;
                        indexOfChar5 = alRu1.IndexOf(text_check[i]);
                        if (indexOfChar5 >= 0)
                        {
                            R++;
                        }
                    }
                    if (R == text_check.Length)
                    {
                        Ru2 = true;
                        alphabet2 = 1;
                    }
                    else
                    {
                        Ru2 = false;
                        MessageBox.Show("В строке должны быть буквы одинакового регистра и алфавита!", "Некорректная строка");
                        return "";
                    }
                }
                else if (indexOfChar6 >= 0)
                {
                    for (int i = 0; i < text_check.Length; i++)
                    {
                        indexOfChar6 = -1;
                        indexOfChar6 = alru1.IndexOf(text_check[i]);
                        if (indexOfChar6 >= 0)
                        {
                            r++;
                        }
                    }
                    if (r == text_check.Length)
                    {
                        ru2 = true;
                        alphabet2 = 2;
                    }
                    else
                    {
                        ru2 = false;
                        MessageBox.Show("В строке должны быть буквы одинакового регистра и алфавита!", "Некорректная строка");
                        return "";
                    }
                }
                else if (indexOfChar7 >= 0)
                {
                    for (int i = 0; i < text_check.Length; i++)
                    {
                        indexOfChar7 = -1;
                        indexOfChar7 = alEn1.IndexOf(text_check[i]);
                        if (indexOfChar7 >= 0)
                        {
                            E++;
                        }
                    }
                    if (E == text_check.Length)
                    {
                        En2 = true;
                        alphabet2 = 3;
                    }
                    else
                    {
                        Ru2 = false;
                        MessageBox.Show("В строке должны быть буквы одинакового регистра и алфавита!", "Некорректная строка");
                        return "";
                    }
                }
                else if (indexOfChar8 >= 0)
                {
                    for (int i = 0; i < text_check.Length; i++)
                    {
                        indexOfChar8 = -1;
                        indexOfChar8 = alen1.IndexOf(text_check[i]);
                        if (indexOfChar8 >= 0)
                        {
                            e++;
                        }
                    }
                    if (e == text_check.Length)
                    {
                        en2 = true;
                        alphabet2 = 4;
                    }
                    else
                    {
                        en2 = false;
                        MessageBox.Show("В строке должны быть буквы одинакового регистра и алфавита!", "Некорректная строка");
                        return "";
                    }
                }

                for (int S = 0; S < s.Length; S++)
                {//ПРОВЕРКА НА БУКВУ
                    int index = -1;
                    index = al.IndexOf(s[S]);
                    if (index < 0)
                    {
                        text1[S] = s[S];
                        Out = new string(text1);

                    }
                    else
                    {
                        //Создаём массив для квадрата Полибия
                        char[,] mass;
                        switch (alphabet1)
                        {
                            case 1://Русские большие
                                mass = new char[6, 6];
                                string t = skey + alRu1;
                                for (int i = 0; i < skey.Length; i++)
                                {
                                    int indexOfChar = -1;
                                    indexOfChar = t.LastIndexOf(skey[i]);
                                    if (indexOfChar >= 0)
                                    {
                                        t = t.Remove(indexOfChar, 1);
                                    }
                                }
                                var table = new char[t.Length];
                                for (int i = 0; i < t.Length; i++)//Текст из string в char[]
                                {
                                    table[i] = t[i];
                                }

                                int k = 0;//Создаём таблицу шифрования
                                for (int i = 0; i < 6; i++)
                                {
                                    for (int n = 0; n < 6; n++)
                                    {
                                        if (k > 32)
                                        {
                                            k++;
                                            continue;
                                        }
                                        else
                                        {
                                            mass[i, n] = table[k];
                                            k++;
                                        }
                                    }
                                }

                                int column = 0;
                                int row = 0;

                                for (int m = 0; m < 6; m++)
                                {
                                    for (int n = 0; n < 6; n++)
                                    {
                                        if (s[S] == mass[m, n])
                                        {
                                            row = m;
                                            column = n;
                                        }

                                    }
                                }

                                if (row < 5)
                                {
                                    if ((row == 4) && (column > 2))
                                    {
                                        row = 0;
                                        text1[S] = mass[row, column];
                                    }
                                    else
                                    {
                                        text1[S] = mass[row + 1, column];
                                    }
                                }
                                else
                                {
                                    row = 0;
                                    text1[S] = mass[row, column];
                                }


                                Out = new string(text1);//Для вывода строки
                                                        //code.Append(text1); //Для вывода строки
                                break;
                            case 2://Русские маленькие
                                mass = new char[6, 6];
                                t = skey + alru1;
                                for (int i = 0; i < skey.Length; i++)
                                {
                                    int indexOfChar = -1;
                                    indexOfChar = t.LastIndexOf(skey[i]);
                                    if (indexOfChar >= 0)
                                    {
                                        t = t.Remove(indexOfChar, 1);
                                    }
                                }
                                table = new char[t.Length];
                                for (int i = 0; i < t.Length; i++)//Текст из string в char[]
                                {
                                    table[i] = t[i];
                                }

                                k = 0;
                                for (int i = 0; i < 6; i++)
                                {
                                    for (int n = 0; n < 6; n++)
                                    {
                                        if (k > 32)
                                        {
                                            k++;
                                            continue;
                                        }
                                        else
                                        {
                                            mass[i, n] = table[k];
                                            k++;
                                        }
                                    }
                                }

                                column = 0;
                                row = 0;

                                for (int m = 0; m < 6; m++)
                                {
                                    for (int n = 0; n < 6; n++)
                                    {

                                        if (s[S] == mass[m, n])
                                        {
                                            row = m;
                                            column = n;
                                        }
                                    }
                                }

                                if (row < 5)
                                {
                                    if ((row == 4) && (column > 2))
                                    {
                                        row = 0;
                                        text1[S] = mass[row, column];
                                    }
                                    else
                                    {
                                        text1[S] = mass[row + 1, column];
                                    }
                                }
                                else
                                {
                                    row = 0;
                                    text1[S] = mass[row, column];
                                }


                                Out = new string(text1);//Для вывода строки
                                break;
                            case 3:
                                mass = new char[5, 5];
                                t = skey + alEn1;
                                for (int i = 0; i < skey.Length; i++)
                                {
                                    int indexOfChar = -1;
                                    indexOfChar = t.LastIndexOf(skey[i]);
                                    if (indexOfChar >= 0)
                                    {
                                        t = t.Remove(indexOfChar, 1);
                                    }
                                }

                                index = -1;
                                index = t.LastIndexOf('J');
                                if (index >= 0)
                                {
                                    t = t.Remove(index, 1);
                                }

                                table = new char[t.Length];

                                for (int i = 0; i < t.Length; i++)//Текст из string в char[]
                                {
                                    table[i] = t[i];
                                }

                                k = 0;
                                for (int i = 0; i < 5; i++)
                                {
                                    for (int n = 0; n < 5; n++)
                                    {
                                        mass[i, n] = table[k];
                                        k++;
                                    }
                                }

                                column = 0;
                                row = 0;

                                for (int m = 0; m < 5; m++)
                                {
                                    for (int n = 0; n < 5; n++)
                                    {
                                        if (s[S] == 'J')
                                        {
                                            if (mass[m, n] == 'I')
                                            {
                                                row = m;
                                                column = n;
                                            }
                                        }
                                        else
                                        {
                                            if (s[S] == mass[m, n])
                                            {
                                                row = m;
                                                column = n;
                                            }
                                        }
                                    }
                                }

                                if (row < 4)
                                {
                                    text1[S] = mass[row + 1, column];
                                }
                                else
                                {
                                    row = 0;
                                    text1[S] = mass[row, column];
                                }


                                Out = new string(text1);//Для вывода строки
                                break;
                            case 4:
                                mass = new char[5, 5];
                                t = skey + alen1;
                                for (int i = 0; i < skey.Length; i++)
                                {
                                    int indexOfChar = -1;
                                    indexOfChar = t.LastIndexOf(skey[i]);
                                    if (indexOfChar >= 0)
                                    {
                                        t = t.Remove(indexOfChar, 1);
                                    }
                                }

                                index = -1;
                                index = t.LastIndexOf('j');
                                if (index >= 0)
                                {
                                    t = t.Remove(index, 1);
                                }

                                table = new char[t.Length];

                                for (int i = 0; i < t.Length; i++)//Текст из string в char[]
                                {
                                    table[i] = t[i];
                                }
                                k = 0;
                                for (int i = 0; i < 5; i++)
                                {
                                    for (int n = 0; n < 5; n++)
                                    {
                                        mass[i, n] = table[k];
                                        k++;
                                    }
                                }

                                column = 0;
                                row = 0;

                                for (int m = 0; m < 5; m++)
                                {
                                    for (int n = 0; n < 5; n++)
                                    {
                                        if (s[S] == 'j')
                                        {
                                            if (mass[m, n] == 'i')
                                            {
                                                row = m;
                                                column = n;
                                            }
                                        }
                                        else
                                        {
                                            if (s[S] == mass[m, n])
                                            {
                                                row = m;
                                                column = n;
                                            }
                                        }
                                    }
                                }

                                if (row < 4)
                                {
                                    text1[S] = mass[row + 1, column];
                                }
                                else
                                {
                                    row = 0;
                                    text1[S] = mass[row, column];
                                }


                                Out = new string(text1);//Для вывода строки
                                break;
                        }
                    }


                }

            }
            return Out;
        }

        public string Polybius2(string inp) //Расшифровка Полибий
        {
            string alRu1 = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            string alru1 = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            string alEn1 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string alen1 = "abcdefghijklmnopqrstuvwxyz";
            StringBuilder code = new StringBuilder();
            string s = textBox1.Text; // s - связана с вводимым текстом
            string skey = textBox4.Text; //skey - ключ шифрования
            char[] key = new char[skey.Length];//key - для хранения ключа и его проверок
            var text = new char[s.Length]; //Для хранения введённых символов
            //string table; //Для хранения таблицы шифрования
            int alphabet1 = 0; //Для сравнения алфавитов ключа и строки
            int alphabet2 = 0; //Для сравнения алфавитов ключа и строки
            string Out = ""; //Строка для расшифрованной строки
            var text1 = new char[s.Length]; //Для хранения введённых символов

            if (textBox1.Text == "") //Проверка на пустое поле
            {
                MessageBox.Show("Введите текст!", "Пустое поле");
                return "";
            }
            if (textBox4.Text == "") //Проверка на пустой ключ
            {
                MessageBox.Show("Укажите ключ шифрования!", "Пустое поле");
                return "";
            }
            else
            {
                for (int i = 0; i < skey.Length; i++)//Ключ из string в char[]
                {
                    key[i] = skey[i];
                }

                bool bukva = true;

                for (int i = 0; i < key.Length; i++)//Проверка ключа
                {


                    int indexOfChar = -1;
                    indexOfChar = al.IndexOf(key[i]);
                    if (indexOfChar < 0)//Если любой из символов ключа не буква
                    {
                        MessageBox.Show("Ключ должен быть буквенным!", "Неверный ключ");
                        bukva = false;
                        return "";
                    }
                }
                if (bukva == false)
                {
                    MessageBox.Show("Тут не только буквы!", "Ошибка ключа");
                    return "";
                }//Проверка на одинаковый алфавит и регистр
                else
                {
                    int indexOfChar1 = -1;
                    int indexOfChar2 = -1;
                    int indexOfChar3 = -1;
                    int indexOfChar4 = -1;
                    indexOfChar1 = alRu1.IndexOf(key[0]);
                    indexOfChar2 = alru1.IndexOf(key[0]);
                    indexOfChar3 = alEn1.IndexOf(key[0]);
                    indexOfChar4 = alen1.IndexOf(key[0]);
                    int R1 = 0;
                    int r1 = 0;
                    int E1 = 0;
                    int e1 = 0;
                    bool Ru1 = false;
                    bool ru1 = false;
                    bool En1 = false;
                    bool en1 = false;

                    //Определение алфавита для первого символа и сравнение других
                    if (indexOfChar1 >= 0)
                    {
                        for (int i = 0; i < key.Length; i++)
                        {
                            indexOfChar1 = -1;
                            indexOfChar1 = alRu1.IndexOf(key[i]);
                            if (indexOfChar1 >= 0)
                            {
                                R1++;
                            }
                        }
                        if (R1 == key.Length)
                        {
                            Ru1 = true;
                            alphabet1 = 1;
                        }
                        else
                        {
                            Ru1 = false;
                            MessageBox.Show("Введите буквы одинакового алфавита и регистра!", "Ошибка ключа");
                            return "";
                        }
                    }
                    else if (indexOfChar2 >= 0)
                    {
                        for (int i = 0; i < key.Length; i++)
                        {
                            indexOfChar2 = -1;
                            indexOfChar2 = alru1.IndexOf(key[i]);
                            if (indexOfChar2 >= 0)
                            {
                                r1++;
                            }
                        }
                        if (r1 == key.Length)
                        {
                            ru1 = true;
                            alphabet1 = 2;
                        }
                        else
                        {
                            ru1 = false;
                            MessageBox.Show("Введите буквы одинакового алфавита и регистра!", "Ошибка ключа");
                            return "";
                        }
                    }
                    else if (indexOfChar3 >= 0)
                    {
                        for (int i = 0; i < key.Length; i++)
                        {
                            indexOfChar3 = -1;
                            indexOfChar3 = alEn1.IndexOf(key[i]);
                            if (indexOfChar3 >= 0)
                            {
                                E1++;
                            }
                        }
                        if (E1 == key.Length)
                        {
                            En1 = true;
                            alphabet1 = 3;
                        }
                        else
                        {
                            Ru1 = false;
                            MessageBox.Show("Введите буквы одинакового алфавита и регистра!", "Ошибка ключа");
                            return "";
                        }
                    }
                    else if (indexOfChar4 >= 0)
                    {
                        for (int i = 0; i < key.Length; i++)
                        {
                            indexOfChar4 = -1;
                            indexOfChar4 = alen1.IndexOf(key[i]);
                            if (indexOfChar4 >= 0)
                            {
                                e1++;
                            }
                        }
                        if (e1 == key.Length)
                        {
                            en1 = true;
                            alphabet1 = 4;
                        }
                        else
                        {
                            en1 = false;
                            MessageBox.Show("Введите буквы одинакового алфавита и регистра!", "Ошибка ключа");
                            return "";
                        }
                    }
                }

                for (int i = 0; i < s.Length; i++)//Текст из string в char[]
                {
                    text[i] = s[i];
                }
                int check = 0;
                for (int i = 0; i < s.Length; i++)//Число подходящих символов
                {
                    int indexOfChar = -1;
                    indexOfChar = al.IndexOf(s[i]);
                    if (indexOfChar >= 0)
                    {
                        check++;
                    }
                }
                int j = 0;
                var text_check = new char[check];//Для хранения строки для проверки
                for (int i = 0; i < s.Length; i++)//Текст из string в char[] для проверки алфавита и регистра
                {
                    int indexOfChar = -1;
                    indexOfChar = al.IndexOf(s[i]);
                    if (indexOfChar >= 0)
                    {
                        text_check[j] = s[i];
                        j++;
                    }
                }

                //Проверка text_check на регистр и алфавит
                int indexOfChar5 = -1;
                int indexOfChar6 = -1;
                int indexOfChar7 = -1;
                int indexOfChar8 = -1;
                indexOfChar5 = alRu1.IndexOf(key[0]);
                indexOfChar6 = alru1.IndexOf(key[0]);
                indexOfChar7 = alEn1.IndexOf(key[0]);
                indexOfChar8 = alen1.IndexOf(key[0]);
                int R = 0;
                int r = 0;
                int E = 0;
                int e = 0;
                bool Ru2 = false;
                bool ru2 = false;
                bool En2 = false;
                bool en2 = false;

                //Определение алфавита для первого символа и сравнение других
                if (indexOfChar5 >= 0)
                {
                    for (int i = 0; i < text_check.Length; i++)
                    {
                        indexOfChar5 = -1;
                        indexOfChar5 = alRu1.IndexOf(text_check[i]);
                        if (indexOfChar5 >= 0)
                        {
                            R++;
                        }
                    }
                    if (R == text_check.Length)
                    {
                        Ru2 = true;
                        alphabet2 = 1;
                    }
                    else
                    {
                        Ru2 = false;
                        MessageBox.Show("В строке должны быть буквы одинакового регистра и алфавита!", "Некорректная строка");
                        return "";
                    }
                }
                else if (indexOfChar6 >= 0)
                {
                    for (int i = 0; i < text_check.Length; i++)
                    {
                        indexOfChar6 = -1;
                        indexOfChar6 = alru1.IndexOf(text_check[i]);
                        if (indexOfChar6 >= 0)
                        {
                            r++;
                        }
                    }
                    if (r == text_check.Length)
                    {
                        ru2 = true;
                        alphabet2 = 2;
                    }
                    else
                    {
                        ru2 = false;
                        MessageBox.Show("В строке должны быть буквы одинакового регистра и алфавита!", "Некорректная строка");
                        return "";
                    }
                }
                else if (indexOfChar7 >= 0)
                {
                    for (int i = 0; i < text_check.Length; i++)
                    {
                        indexOfChar7 = -1;
                        indexOfChar7 = alEn1.IndexOf(text_check[i]);
                        if (indexOfChar7 >= 0)
                        {
                            E++;
                        }
                    }
                    if (E == text_check.Length)
                    {
                        En2 = true;
                        alphabet2 = 3;
                    }
                    else
                    {
                        Ru2 = false;
                        MessageBox.Show("В строке должны быть буквы одинакового регистра и алфавита!", "Некорректная строка");
                        return "";
                    }
                }
                else if (indexOfChar8 >= 0)
                {
                    for (int i = 0; i < text_check.Length; i++)
                    {
                        indexOfChar8 = -1;
                        indexOfChar8 = alen1.IndexOf(text_check[i]);
                        if (indexOfChar8 >= 0)
                        {
                            e++;
                        }
                    }
                    if (e == text_check.Length)
                    {
                        en2 = true;
                        alphabet2 = 4;
                    }
                    else
                    {
                        en2 = false;
                        MessageBox.Show("В строке должны быть буквы одинакового регистра и алфавита!", "Некорректная строка");
                        return "";
                    }
                }
                for (int S = 0; S < s.Length; S++)
                {//ПРОВЕРКА НА БУКВУ
                    int index = -1;
                    index = al.IndexOf(s[S]);
                    if (index < 0)
                    {
                        text1[S] = s[S];
                        Out = new string(text1);

                    }
                    else
                    {
                        //Создаём массив для квадрата Полибия
                        char[,] mass;
                        switch (alphabet1)
                        {
                            case 1://Русские большие
                                mass = new char[6, 6];
                                string t = skey + alRu1;
                                for (int i = 0; i < skey.Length; i++)
                                {
                                    int indexOfChar = -1;
                                    indexOfChar = t.LastIndexOf(skey[i]);
                                    if (indexOfChar >= 0)
                                    {
                                        t = t.Remove(indexOfChar, 1);
                                    }
                                }
                                var table = new char[t.Length];
                                for (int i = 0; i < t.Length; i++)//Текст из string в char[]
                                {
                                    table[i] = t[i];
                                }

                                int k = 0;
                                for (int i = 0; i < 6; i++)
                                {
                                    for (int n = 0; n < 6; n++)
                                    {
                                        if (k > 32)
                                        {
                                            k++;
                                            continue;
                                        }
                                        else
                                        {
                                            mass[i, n] = table[k];
                                            k++;
                                        }
                                    }
                                }

                                int column = 0;
                                int row = 0;

                                for (int m = 0; m < 6; m++)
                                {
                                    for (int n = 0; n < 6; n++)
                                    {
                                        if (s[S] == mass[m, n])
                                        {
                                            row = m;
                                            column = n;
                                        }

                                    }
                                }

                                if (row == 0)
                                {
                                    if (column > 2)
                                    {
                                        row = 4;
                                        text1[S] = mass[row, column];
                                    }
                                    else
                                    {
                                        row = 5;
                                        text1[S] = mass[row, column];
                                    }
                                }
                                else
                                {
                                    text1[S] = mass[row - 1, column];
                                }


                                Out = new string(text1);//Для вывода строки
                                                        //code.Append(text1); //Для вывода строки
                                break;
                            case 2://Русские маленькие
                                mass = new char[6, 6];
                                t = skey + alru1;
                                for (int i = 0; i < skey.Length; i++)
                                {
                                    int indexOfChar = -1;
                                    indexOfChar = t.LastIndexOf(skey[i]);
                                    if (indexOfChar >= 0)
                                    {
                                        t = t.Remove(indexOfChar, 1);
                                    }
                                }
                                table = new char[t.Length];
                                for (int i = 0; i < t.Length; i++)//Текст из string в char[]
                                {
                                    table[i] = t[i];
                                }

                                k = 0;
                                for (int i = 0; i < 6; i++)
                                {
                                    for (int n = 0; n < 6; n++)
                                    {
                                        if (k > 32)
                                        {
                                            k++;
                                            continue;
                                        }
                                        else
                                        {
                                            mass[i, n] = table[k];
                                            k++;
                                        }
                                    }
                                }

                                column = 0;
                                row = 0;

                                for (int m = 0; m < 6; m++)
                                {
                                    for (int n = 0; n < 6; n++)
                                    {
                                        if (s[S] == mass[m, n])
                                        {
                                            row = m;
                                            column = n;
                                        }

                                    }
                                }

                                if (row == 0)
                                {
                                    if (column > 2)
                                    {
                                        row = 4;
                                        text1[S] = mass[row, column];
                                    }
                                    else
                                    {
                                        row = 5;
                                        text1[S] = mass[row, column];
                                    }
                                }
                                else
                                {
                                    text1[S] = mass[row - 1, column];
                                }


                                Out = new string(text1);//Для вывода строки
                                break;
                            case 3:
                                mass = new char[5, 5];
                                t = skey + alEn1;
                                for (int i = 0; i < skey.Length; i++)
                                {
                                    int indexOfChar = -1;
                                    indexOfChar = t.LastIndexOf(skey[i]);
                                    if (indexOfChar >= 0)
                                    {
                                        t = t.Remove(indexOfChar, 1);
                                    }
                                }

                                index = -1;
                                index = t.LastIndexOf('J');
                                if (index >= 0)
                                {
                                    t = t.Remove(index, 1);
                                }

                                table = new char[t.Length];

                                for (int i = 0; i < t.Length; i++)//Текст из string в char[]
                                {
                                    table[i] = t[i];
                                }

                                k = 0;
                                for (int i = 0; i < 5; i++)
                                {
                                    for (int n = 0; n < 5; n++)
                                    {
                                        mass[i, n] = table[k];
                                        k++;
                                    }
                                }

                                column = 0;
                                row = 0;

                                for (int m = 0; m < 5; m++)
                                {
                                    for (int n = 0; n < 5; n++)
                                    {
                                        if (s[S] == 'J')
                                        {
                                            if (mass[m, n] == 'I')
                                            {
                                                row = m;
                                                column = n;
                                            }
                                        }
                                        else
                                        {
                                            if (s[S] == mass[m, n])
                                            {
                                                row = m;
                                                column = n;
                                            }
                                        }
                                    }
                                }

                                if (row == 0)
                                {
                                    row = 4;
                                    text1[S] = mass[row, column];
                                }
                                else
                                {
                                    text1[S] = mass[row - 1, column];
                                }


                                Out = new string(text1);//Для вывода строки
                                break;
                            case 4:
                                mass = new char[5, 5];
                                t = skey + alen1;
                                for (int i = 0; i < skey.Length; i++)
                                {
                                    int indexOfChar = -1;
                                    indexOfChar = t.LastIndexOf(skey[i]);
                                    if (indexOfChar >= 0)
                                    {
                                        t = t.Remove(indexOfChar, 1);
                                    }
                                }

                                index = -1;
                                index = t.LastIndexOf('j');
                                if (index >= 0)
                                {
                                    t = t.Remove(index, 1);
                                }

                                table = new char[t.Length];

                                for (int i = 0; i < t.Length; i++)//Текст из string в char[]
                                {
                                    table[i] = t[i];
                                }
                                k = 0;
                                for (int i = 0; i < 5; i++)
                                {
                                    for (int n = 0; n < 5; n++)
                                    {
                                        mass[i, n] = table[k];
                                        k++;
                                    }
                                }

                                column = 0;
                                row = 0;

                                for (int m = 0; m < 5; m++)
                                {
                                    for (int n = 0; n < 5; n++)
                                    {
                                        if (s[S] == 'j')
                                        {
                                            if (mass[m, n] == 'i')
                                            {
                                                row = m;
                                                column = n;
                                            }
                                        }
                                        else
                                        {
                                            if (s[S] == mass[m, n])
                                            {
                                                row = m;
                                                column = n;
                                            }
                                        }
                                    }
                                }

                                if (row == 0)
                                {
                                    row = 4;
                                    text1[S] = mass[row, column];
                                }
                                else
                                {
                                    text1[S] = mass[row - 1, column];
                                }

                                Out = new string(text1);//Для вывода строки
                                break;
                        }
                    }


                }
            }
            return Out;
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedState = comboBox1.SelectedItem.ToString();
            if ((selectedState == "Шифр Цезаря") || (selectedState == "Шифр Сцитала")) //Видимость поля для ключа
            {
                textBox3.Visible = true;
                if ((selectedState == "Шифр Цезаря"))
                {
                    label4.Visible = true;
                    label6.Visible = false;
                }
                if (selectedState == "Шифр Сцитала")
                {
                    label6.Visible = true;
                    label4.Visible = false;
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
    }
}
