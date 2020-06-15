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
        public string Hill1(string inp)
        {
            string OpenText = textBox1.Text;// Вводимый текст
            string Out = "";                // Вывод зашифрованного сообщения
            string Key = textBox3.Text;     //Key - ключ шифрования

            if (textBox1.Text == "") //Проверка на пустое поле
            {
                MessageBox.Show("Введите текст!", "Пустое поле");
                return "";
            }
            else
            {
                if (textBox3.Text == "") //Проверка на пустой ключ
                {
                    MessageBox.Show("Укажите требуемый шаг!", "Пустое поле", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "";
                }
                else
                {
                    //проверяем символы на соответсвие алфавиту
                    foreach (var s in OpenText)
                    {
                        if (Alphabet.IndexOf(s) < 0)
                        {
                            MessageBox.Show("Шифрование не может быть выполнено! Шифртекст содержит символы не из алфавита = " + "'" + s + "'", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return "";
                        }
                    }

                    for (int i = 0; i < Key.Length; i++)
                    {
                        int indexOfChar = -1;
                        indexOfChar = al.IndexOf(Key[i]);
                        if (indexOfChar < 0)
                        {
                            MessageBox.Show("Ключ должен состоять из букв!", "Неверный ключ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return "";
                        }
                    }
                }
            }

            double Rang_Matrix = Math.Ceiling(Math.Sqrt(Convert.ToDouble(Key.Length)));
            AddText(ref Key, Convert.ToInt32(Math.Pow(Rang_Matrix, 2)));
            AddText(ref OpenText, Convert.ToInt32(Rang_Matrix));

            int[,] Key_Matrix = CreateMatrix(Key, Convert.ToInt32(Rang_Matrix));
            int det = Determinant(Key_Matrix);
            if (det == 0)
            {
                MessageBox.Show("Определитель матрицы равен нулю!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
            if (GCD(Alphabet.Length, det) != 1)
            {
                MessageBox.Show("Определитель матрицы и модуль алфавита не являются взаимно простыми!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }

            Out = Encryption(OpenText, Key_Matrix);
            return Out;
        }

        public string Hill2(string inp)
        {
            string EncryptText = textBox1.Text; // s - связана с вводимым текстом
            string Out = "";
            string Key = textBox3.Text; //key - ключ шифрования

            if (textBox1.Text == "") //Проверка на пустое поле
            {
                MessageBox.Show("Введите текст!", "Пустое поле", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
            else
            {
                if (textBox3.Text == "") //Проверка на пустой ключ
                {
                    MessageBox.Show("Укажите требуемый шаг!", "Пустое поле", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "";
                }
                else
                {
                    //проверяем символы на соответсвие алфавиту
                    foreach (var s in EncryptText)
                    {
                        if (Alphabet.IndexOf(s) < 0)
                        {
                            MessageBox.Show("Расшифрование не может быть выполнено! Шифртекст содержит символы не из алфавита = " + "'" + s + "'", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return "";
                        }
                    }

                    for (int i = 0; i < Key.Length; i++)
                    {
                        int indexOfChar = -1;
                        indexOfChar = Alphabet.IndexOf(Key[i]);
                        if (indexOfChar < 0)
                        {
                            MessageBox.Show("Ключ должен состоять из букв!", "Неверный ключ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return "";
                        }
                    }
                }
            }

            // т.к.умножаем строку матрицы ключа на столбец шифротекста
            // и если бы шифровали, то дополнили пробелами текст, тут такого мы сделать не можем
            double Rang_Matrix = Math.Ceiling(Math.Sqrt(Convert.ToDouble(Key.Length)));
            if (EncryptText.Length % Rang_Matrix != 0)
            {
                MessageBox.Show("Шифртекст не кратен длине блока! Расшифрование не может быть выполнено.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }

            //дополняем ключ пробелами для квадртности матрицы ключа
            AddText(ref Key, Convert.ToInt32(Math.Pow(Rang_Matrix, 2)));
            //заполняем матрицу
            int[,] Key_Matrix = CreateMatrix(Key, Convert.ToInt32(Rang_Matrix));
            //теперь првоеряем условия матрицы ключа
            int det = Determinant(Key_Matrix);
            if (det == 0)
            {
                MessageBox.Show("Определитель матрицы равен нулю!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
            if (GCD(Alphabet.Length, det) != 1)
            {
                MessageBox.Show("Определитель матрицы и модуль алфавита не являются взаимно простыми!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }

            Out = Decryption(EncryptText, Key_Matrix);
            return Out;
        }

        int GCD(int a, int b)
        {
            //наибольший общий делитель(Алгоритм Евклида); 
            //a - модуль алфавита, b - определитель матрицы
            while (b != 0)
            {
                b = a % (a = b);
            }
            return a;
        }

        int ExtendedEuclid(int a, int b)//Расширенный алгоритм Евклида; a - модуль алфавита, b - определитель матрицы
        {
            int x2 = 1, x1 = 0, y2 = 0, y1 = 1, q, r, x, y;

            while (b > 0)
            {
                q = a / b;
                r = a % b;
                x = x2 - q * x1;
                y = y2 - q * y1;
                a = b;
                b = r;
                x2 = x1;
                x1 = x;
                y2 = y1;
                y1 = y;
            }
            while (y2 < 0)
            {
                y2 += Alphabet.Length;
            }
            return y2;
        }

        private int[,] CreateMatrix(string Key, int Rang_Matrix)
        {
            //создаём квадратную матрицу
            int[,] Key_Matrix = new int[Rang_Matrix, Rang_Matrix];
            int[] Key_Mass = new int[Key.Length];
            //переводим символы в индексы до 127
            for (int i = 0; i < Key.Length; i++)
            {
                for (int j = 0; j < Alphabet.Length; j++)
                {
                    if (Key[i] == Alphabet[j])
                    {
                        Key_Mass[i] = j;
                        break;
                    }
                }
            }

            int index = 0;
            for (int i = 0; i < Rang_Matrix; i++)
            {
                for (int j = 0; j < Rang_Matrix; j++)
                {
                    Key_Matrix[i, j] = Key_Mass[index];
                    index++;
                }
            }

            return Key_Matrix;
        }

        private void AddText(ref string Text, int Rang_Matrix)
        {
            //дополняем ключ или шифруемый текст до кратности ранга матрицы
            //пробелами
            if (Text.Length % Rang_Matrix != 0)
            {
                int number_of_characters = Rang_Matrix - (Text.Length % Rang_Matrix);
                for (int i = 0; i < number_of_characters; i++)
                {
                    Text += " ";
                }
            }
        }

        private int Determinant(int[,] Key_Matrix)
        {
            //с помощью минора вырезаем 
            //небходимую матрицу
            int det = 0;
            int Rank = Key_Matrix.GetLength(0);
            if (Rank == 1)
            {
                det = Key_Matrix[0, 0];
            }

            if (Rank == 2)
            {
                det = (Key_Matrix[0, 0] * Key_Matrix[1, 1] - Key_Matrix[0, 1] * Key_Matrix[1, 0]);
            }

            if (Rank > 2)
            {

                for (int i = 0; i < Key_Matrix.GetLength(1); i++)
                {
                    det += ((int)Math.Pow(-1, i) * Key_Matrix[0, i] * Determinant(GetMinor(Key_Matrix, 0, i)));
                }
            }

            det %= Alphabet.Length;
            if (det < 0)
            {
                det += Alphabet.Length;
            }
            return det;
        }

        int[,] GetMinor(int[,] Key_Matrix, int row, int column)
        {
            //минор  - часть матрицы без строки и столбца
            //нужен для поиска детерминанта любого порядка
            int[,] buf = new int[Key_Matrix.GetLength(0) - 1, Key_Matrix.GetLength(0) - 1];
            for (int i = 0; i < Key_Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Key_Matrix.GetLength(1); j++)
                {
                    if ((i != row) || (j != column))
                    {
                        if (i > row && j < column) buf[i - 1, j] = Key_Matrix[i, j];
                        if (i < row && j > column) buf[i, j - 1] = Key_Matrix[i, j];
                        if (i > row && j > column) buf[i - 1, j - 1] = Key_Matrix[i, j];
                        if (i < row && j < column) buf[i, j] = Key_Matrix[i, j];
                    }
                }
            }
            return buf;
        }

        private int[] Vector_X_Matrix(int[] Vector, int[,] Key_Matrix)
        {
            //перемножение матрицы ключа и вектора текста
            int[] Result_Vector = new int[Key_Matrix.GetLength(0)];
            for (int i = 0; i < Key_Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Key_Matrix.GetLength(0); j++)
                {
                    Result_Vector[i] += (Vector[j] * Key_Matrix[j, i]);
                }
                Result_Vector[i] %= Alphabet.Length;
            }
            return Result_Vector;
        }

        int[,] InverseMatrix(int[,] Key_Matrix)
        {
            //обратная матрица - все единички при умножении на исходную
            int[,] New_Matrix = new int[Key_Matrix.GetLength(0), Key_Matrix.GetLength(1)];
            int[,] Minor = new int[Key_Matrix.GetLength(0) - 1, Key_Matrix.GetLength(1) - 1];
            int determinant = Determinant(Key_Matrix);
            int inverse_determinant = ExtendedEuclid(Alphabet.Length, determinant);

            for (int i = 0; i < Key_Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Key_Matrix.GetLength(1); j++)
                {
                    Minor = GetMinor(Key_Matrix, i, j);
                    New_Matrix[j, i] = (int)Math.Pow(-1, i + j) * (inverse_determinant * Determinant(Minor));
                    New_Matrix[j, i] %= Alphabet.Length;
                    if (New_Matrix[j, i] < 0)
                    {
                        New_Matrix[j, i] += Alphabet.Length;
                    }
                }
            }

            return New_Matrix;
        }

        private string Encryption(string OpenText, int[,] Key_Matrix)
        {

            string EncryptText = null;
            int[] Index_Mass = new int[OpenText.Length];
            //переводим символы текста в индексы
            for (int i = 0; i < OpenText.Length; i++)
            {
                for (int j = 0; j < Alphabet.Length; j++)
                {
                    if (OpenText[i] == Alphabet[j])
                    {
                        Index_Mass[i] = j;
                        break;
                    }
                }
            }
            //шифруем по блокам, значит нужен размер одного блока и его количество
            int[] Vector = new int[Key_Matrix.GetLength(0)];
            int amount_of_blocks = OpenText.Length / Key_Matrix.GetLength(0);

            for (int n = 0; n < amount_of_blocks; n++)
            {
                int index = 0;
                //формируем блок индексов исходного текста
                for (int k = n * Key_Matrix.GetLength(0); k < n * Key_Matrix.GetLength(0) + Key_Matrix.GetLength(0); k++)
                {
                    Vector[index] = Index_Mass[k];
                    index++;
                }
                //отправляем этот блок на умножение 
                Vector = Vector_X_Matrix(Vector, Key_Matrix);
                for (int i = 0; i < Key_Matrix.GetLength(0); i++)
                {
                    EncryptText += Alphabet[Vector[i]];
                }
            }

            return EncryptText;
        }

        private string Decryption(string EncryptText, int[,] Key_Matrix)
        {
            string DecryptText = null;
            int[] Index_Mass = new int[EncryptText.Length];
            for (int i = 0; i < EncryptText.Length; i++)
            {
                for (int j = 0; j < Alphabet.Length; j++)
                {
                    if (EncryptText[i] == Alphabet[j])
                    {
                        Index_Mass[i] = j;
                        break;
                    }
                }
            }
            //создаёем обратную матрицу 
            Key_Matrix = InverseMatrix(Key_Matrix);
            //шифруем по блокам, значит нужен размер одного блока и его количество
            int[] Vector = new int[Key_Matrix.GetLength(0)];
            int amount_of_blocks = EncryptText.Length / Key_Matrix.GetLength(0);

            for (int n = 0; n < amount_of_blocks; n++)
            {
                int index = 0;
                //формируем блок индексов исходного текста

                for (int k = n * Key_Matrix.GetLength(0); k < n * Key_Matrix.GetLength(0) + Key_Matrix.GetLength(0); k++)
                {
                    Vector[index] = Index_Mass[k];
                    index++;
                }
                //отправляем на умножение с ключом
                Vector = Vector_X_Matrix(Vector, Key_Matrix);
                for (int i = 0; i < Key_Matrix.GetLength(0); i++)
                {
                    DecryptText += Alphabet[Vector[i]];
                }
            }

            return DecryptText;
        }
    }
}