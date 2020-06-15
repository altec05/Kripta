using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Numerics;

namespace Ciphers
{
    public partial class Form1 : Form
    {
        string alfull = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюяABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz\n\r,.;:'#$%^&*()№%:?!-_ 0123456789";
        string numb = "0123456789";
        string dec = "0123456789,";

        List<string> result;
        List<string> RSA_out = new List<string>();

        private string RSA1(string inp)
        {
            alfull = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюяABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz\n\r,.;:'#$%^&*()№%:?!-_ 0123456789";
            var Out = "";
            if (textBox1.Text == "") //Проверка на пустое поле
            {
                MessageBox.Show("Введите текст!", "Пустое поле", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox8.Text == "") //Проверка на пустое поле
            {
                MessageBox.Show("Введите p", "Пустое поле", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox9.Text == "") //Проверка на пустое поле
            {
                MessageBox.Show("Введите q", "Пустое поле", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string All_alphabet;
                All_alphabet = Add(textBox1.Text, alfull);
                alfull = All_alphabet;
                char[] NewAll = All_alphabet.ToCharArray();

                for (int i = 0; i < textBox8.Text.Length; i++)
                {
                    int indexOfChar = -1;
                    indexOfChar = numb.IndexOf(textBox8.Text[i]);
                    if (indexOfChar < 0)
                    {
                        MessageBox.Show("Параметр 'p' должен состоять из цифр!", "Неверный ключ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return "";
                    }
                }

                for (int i = 0; i < textBox9.Text.Length; i++)
                {
                    int indexOfChar = -1;
                    indexOfChar = numb.IndexOf(textBox9.Text[i]);
                    if (indexOfChar < 0)
                    {
                        MessageBox.Show("Параметр 'q' должен состоять из цифр!", "Неверный ключ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return "";
                    }
                }

                long p = Convert.ToInt64(textBox8.Text);
                long q = Convert.ToInt64(textBox9.Text);

                if (SimpleCheck(p) == false)
                {
                    MessageBox.Show("p - не простое число!", "Неверные входные данные", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "";
                }
                else if (SimpleCheck(q) == false)
                {
                    MessageBox.Show("q - не простое число!", "Неверные входные данные", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "";
                }
                else
                {
                    Wait();
                    string text = textBox1.Text;
                    long n = p * q;
                    long m = (p - 1) * (q - 1);
                    long d = Calculate_d(m);
                    long e_ = Calculate_e(d, m);

                    if (d < 100 || n < 100)
                    {
                        if (p == 3 || q == 3)
                        {
                            if (p == 3 && q < 53)
                            {
                                MessageBox.Show("В данном случае требуется ввести значение для параметров ключа больше приведённых!\r\n Например, q >= 53", "Неверные входные данные", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return "";
                            }
                            else if (q == 3 && p < 53)
                            {
                                MessageBox.Show("В данном случае требуется ввести значение для параметров ключа больше приведённых!\r\n Например, p >= 53", "Неверные входные данные", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return "";
                            }
                        }
                        else if (p == 7 || q == 7)
                        {
                            if (p == 7 && q < 23)
                            {
                                MessageBox.Show("В данном случае требуется ввести значение для параметров ключа больше приведённых!\r\n Например, q >= 23", "Неверные входные данные", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return "";
                            }
                            else if (q == 7 && p < 23)
                            {
                                MessageBox.Show("В данном случае требуется ввести значение для параметров ключа больше приведённых!\r\n Например, p >= 23", "Неверные входные данные", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return "";
                            }
                        }
                    }
                    else if ((p == 7 && q < 23) ||(q == 7 && p < 23))
                    {
                        if (p == 7 && q < 23)
                        {
                            MessageBox.Show("В данном случае требуется ввести значение для параметров ключа больше приведённых!\r\n Например, q >= 23", "Неверные входные данные", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return "";
                        }
                        else if (q == 7 && p < 23)
                        {
                            MessageBox.Show("В данном случае требуется ввести значение для параметров ключа больше приведённых!\r\n Например, p >= 23", "Неверные входные данные", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return "";
                        }
                    }
                    else
                    {
                        if ((p > 1500 && q > 300) || (q > 1500 && p > 300))
                        {
                            const string message = "При данных значениях вычисления займут больше нескольких минут, что критично.\r\nВы уверены, что хотите продолжить?";
                            const string caption = "Предупреждение";
                            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            Wait();
                            if (result == DialogResult.No)
                            {
                                MessageBox.Show("Отмена операции.\r\nРезультат вычисления 'd' и 'n' вы увидите в выделенных для этого полях.", "Информационное сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return "";

                            }else
                            {
                                MessageBox.Show("Вычисления займут продолжительное время.\r\nВремя работы зависит от производительности вашей системы.", "Информационное сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Wait();
                            }
                        }
                        
                        result = RSA_Encode(text, e_, n, NewAll);
                        RSA_out.Clear();

                        foreach (string item in result)
                        {
                            RSA_out.Add(item);
                        }

                        textBox11.Text = d.ToString();
                        textBox10.Text = n.ToString();

                        Out = String.Join(",", RSA_out.ToArray());
                    }
                }
            }
            return Out;
        }

        public string RSA2(string inp)
        {
            var Out = "";
            if (textBox1.Text == "") //Проверка на пустое поле
            {
                MessageBox.Show("Введите текст!", "Пустое поле", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
            else if (textBox11.Text == "") //Проверка на пустое поле
            {
                MessageBox.Show("Введите d", "Пустое поле", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
            else if (textBox10.Text == "") //Проверка на пустое поле
            {
                MessageBox.Show("Введите n", "Пустое поле", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
            else
            {
                string All_alphabet = alfull;
                char[] NewAll = All_alphabet.ToCharArray();

                for (int i = 0; i < textBox11.Text.Length; i++)
                {
                    int indexOfChar = -1;
                    indexOfChar = numb.IndexOf(textBox11.Text[i]);
                    if (indexOfChar < 0)
                    {
                        MessageBox.Show("Параметр 'd' должен состоять из цифр!", "Неверный ключ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return "";
                    }
                }

                for (int i = 0; i < textBox10.Text.Length; i++)
                {
                    int indexOfChar = -1;
                    indexOfChar = numb.IndexOf(textBox10.Text[i]);
                    if (indexOfChar < 0)
                    {
                        MessageBox.Show("Параметр 'n' должен состоять из цифр!", "Неверный ключ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return "";
                    }
                }

                for (int i = 0; i < textBox1.Text.Length; i++)
                {
                    int indexOfChar = -1;
                    indexOfChar = dec.IndexOf(textBox1.Text[i]);
                    if (indexOfChar < 0)
                    {
                        MessageBox.Show("Программа при расшифровке не работает с буквами!", "Неверный шифротекст", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return "";
                    }
                }

                long d = Convert.ToInt64(textBox11.Text);
                long n = Convert.ToInt64(textBox10.Text);

                result = new List<string>();
                string text = textBox1.Text;
                result = RSA_Add(text, NewAll);

                List<string> input = new List<string>();
                //input.Clear();
                try
                {
                    foreach (string item in result)
                    {
                        input.Add(item);
                    }
                }
                catch(System.NullReferenceException)
                {
                    result = new List<string>();
                    text = textBox1.Text;
                    result = RSA_Add(text, NewAll);


                    foreach (string item in result)
                    {
                        input.Add(item);
                    }
                }

                foreach (string item in input)
                {
                    if(item == "")
                    {
                        MessageBox.Show("Некорректные входные данные!", "Неверный шифротекст", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return "";
                    }
                }

                string result_text = RSA_Decode(input, d, n, NewAll);

                Out = result_text;
                result.Clear();

            }
            return Out;
        }

        private bool SimpleCheck(long num) //проверка введённых p и q на то, простые ли числа
        {
            if (num < 2)
            {
                return false;
            }
            else if (num == 2)
            {
                return true;
            }
            else
            {
                for (long i = 2; i < num; i++)
                {
                    if (num % i == 0)
                    {
                        return false;
                    }
                }
                return true;
            }
        }


        private long Calculate_d(long m) //вычисление аргумента d
        {
            long d = m - 1;

            for (long i = 2; i <= m; i++)
                if ((m % i == 0) && (d % i == 0)) //если имеют общие делители
                {
                    d--;
                    i = 1;
                }

            return d;
        }

        private long Calculate_e(long d, long m) //вычисление аргумента e
        {
            long e = 10;

            while (true)
            {
                if ((e * d) % m == 1) //по свойству
                    break;
                else
                    e++;
            }

            return e;
        }

        private List<string> RSA_Encode(string s, long e, long n, char[] alfull)
        {

            result = new List<string>();

            BigInteger bi;
            Wait();
            for (int i = 0; i < s.Length; i++)
            {
                int index = Array.IndexOf(alfull, s[i]);

                bi = new BigInteger(index);
                if(i == 0)
                {
                    if (e > 10000)
                    {
                        const string message = "Операция с заданными параметрами может занять продолжительное время.\r\nВы уверены, что хотите продолжить?";
                        const string caption = "Предупреждение";
                        var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        Wait();
                        if (result == DialogResult.No)
                        {
                            MessageBox.Show("Отмена операции.\r\nРезультат вычисления 'd' и 'n' вы увидите в выделенных для этого полях.", "Информационное сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;

                        }
                    }
                    Wait();
                    bi = BigInteger.Pow(bi, (int)e);

                    BigInteger n_ = new BigInteger((int)n);

                    bi = bi % n_;

                    result.Add(bi.ToString());
                }
                else
                {
                    Wait();
                    bi = BigInteger.Pow(bi, (int)e);

                    BigInteger n_ = new BigInteger((int)n);

                    bi = bi % n_;

                    result.Add(bi.ToString());
                }
                
               
            }
            return result;

        }

        private List<string> RSA_Add(string s, char[] alfull)
        {

            result = new List<string>();
            char[] arr = s.ToCharArray();
            string CH = "";
            string N = ",";


            for (int i = 0; i < arr.Length; i++)
            {
                string ch = arr[i].ToString();
                if(ch != N)
                {
                    if(i == arr.Length - 1)
                    {
                        ch = arr[i].ToString();
                        CH += ch;
                        result.Add(CH.ToString());
                        CH = "";
                    }
                    else
                    {
                        CH += ch;
                    }
                    
                }
                else
                {
                    result.Add(CH.ToString());
                    CH = "";
                }
                
            }
            return result;
        }

        private string RSA_Decode(List<string> input, long d, long n, char[] alphabets)
        {
            string result = "";

            BigInteger bi;

            if (d > 10000)
            {
                const string message = "Операция с заданными параметрами может занять продолжительное время.\r\nВы уверены, что хотите продолжить?";
                const string caption = "Предупреждение";
                var res = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                Wait();
                if (res == DialogResult.No)
                {
                    return "";

                }
            }
            Wait();
            foreach (string item in input)
            {

                try
                {
                    bi = new BigInteger(Convert.ToDouble(item));
                    Wait();
                    bi = BigInteger.Pow(bi, (int)d);
                    BigInteger n_ = new BigInteger((int)n);
                    bi = bi % n_;
                    int index = Convert.ToInt32(bi.ToString());
                    result += alphabets[index].ToString();
                }
                catch (System.FormatException)
                {
                    MessageBox.Show("Некорректные входные данные!", "Неверный шифротекст", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "";
                }
                catch (System.IndexOutOfRangeException)
                {
                    bi = new BigInteger(Convert.ToDouble(item));
                    Wait();
                    bi = BigInteger.Pow(bi, (int)d);
                    BigInteger n_ = new BigInteger((int)n);
                    bi = bi % n_;
                    int index = Convert.ToInt32(bi.ToString());
                    index = index % alphabets.Length;
                    MessageBox.Show("Замечен символ, отсутствующий в алфавите!\r\n Возможны искажения!\r\n Пробуем найти ему замену.", "Предупреждение", MessageBoxButtons.OK);
                    result += alphabets[index].ToString();
                }
            }
            return result;
        }

        public string Add(string text, string alfull) //добавление символов в алфавит
        {
            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < alfull.Length; j++)
                {
                    if (alfull.IndexOf(text[i]) == -1)
                    {
                        alfull = alfull + text[i];
                    }
                }
            }
            return alfull;
        }

        public void Wait()
        {
            textBox2.Text = "Идёт обработка, подождите...";
        }
    }
}