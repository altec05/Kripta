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
    }
}