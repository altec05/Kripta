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
                if (s.Length > 48 || s.Length < 4)
                {
                    MessageBox.Show("Текст должен быть длиной меньше 48 и больше 4 символов!", "Недопустимая длина текста");
                    return "ОШИБКА ВВОДА";
                }
                else
                {
                    for (int i = 0; i < s.Length; i++)
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
    }
}