using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lab16
{
    public partial class Form1 : Form
    {
        private Vector3D v1, v2;

        public Form1()
        {
            InitializeComponent();
            label1.Text = "x1= ";
            label2.Text = "y1= ";
            label3.Text = "z1= ";
            label4.Text = "Довжина 1 вектора: ";
            label9.Text = "Довжина 2 вектора: ";
            label5.Text = "x2= ";
            label6.Text = "y2= ";
            label7.Text = "z2= ";
            button1.Text = "Довжина 1 вектора";
            button2.Text = "Довжина 2 вектора";
            button3.Text = "Сума векторів";
            button4.Text = "Віднімання векторів";
            button5.Text = "Косинус кута між векторами";
            button6.Text = "Скалярний добуток";
            label12.Text = $"Вектор1: ";
            label13.Text = $"Вектор2: ";
            label14.Text = "Сума двох векторів: ";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Отримуємо координати вектора з текстових полів
            double x1 = textBox1.Text.Trim() == "" ? 0 : double.Parse(textBox1.Text);
            double y1 = textBox2.Text.Trim() == "" ? 0 : double.Parse(textBox2.Text);
            double z1 = textBox3.Text.Trim() == "" ? 0 : double.Parse(textBox3.Text);
            // Створюємо об'єкт вектора з отриманих координат
            Vector3D v1 = new Vector3D(x1, y1, z1);

            // Обчислюємо довжину вектора та виводимо результат в текстове поле
            double length = v1.Length();
            label4.Text = "Довжина 1 вектора: " + length.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Отримуємо координати вектора з текстових полів
            double x2 = textBox4.Text.Trim() == "" ? 0 : double.Parse(textBox4.Text);
            double y2 = textBox5.Text.Trim() == "" ? 0 : double.Parse(textBox5.Text);
            double z2 = textBox6.Text.Trim() == "" ? 0 : double.Parse(textBox6.Text);

            // Створюємо об'єкт вектора з отриманих координат
            Vector3D v2 = new Vector3D(x2, y2, z2);

            // Обчислюємо довжину вектора та виводимо результат в текстове поле
            double length = v2.Length();
            label9.Text = "Довжина 2 вектора: " + length.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double x1 = textBox1.Text.Trim() == "" ? 0 : double.Parse(textBox1.Text);
            double y1 = textBox2.Text.Trim() == "" ? 0 : double.Parse(textBox2.Text);
            double z1 = textBox3.Text.Trim() == "" ? 0 : double.Parse(textBox3.Text);

            double x2 = textBox4.Text.Trim() == "" ? 0 : double.Parse(textBox4.Text);
            double y2 = textBox5.Text.Trim() == "" ? 0 : double.Parse(textBox5.Text);
            double z2 = textBox6.Text.Trim() == "" ? 0 : double.Parse(textBox6.Text);

            v1 = new Vector3D(x1, y1, z1);
            v2 = new Vector3D(x2, y2, z2);

            label12.Text = $"Вектор1: ({v1.X}, {v1.Y}, {v1.Z})";
            label13.Text = $"Вектор2: ({v2.X}, {v2.Y}, {v2.Z})";
            Vector3D minus = v1 - v2;
            label14.Text = $"Віднімання цих векторів: ({minus.X}, {minus.Y}, {minus.Z})";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double x1 = textBox1.Text.Trim() == "" ? 0 : double.Parse(textBox1.Text);
            double y1 = textBox2.Text.Trim() == "" ? 0 : double.Parse(textBox2.Text);
            double z1 = textBox3.Text.Trim() == "" ? 0 : double.Parse(textBox3.Text);

            double x2 = textBox4.Text.Trim() == "" ? 0 : double.Parse(textBox4.Text);
            double y2 = textBox5.Text.Trim() == "" ? 0 : double.Parse(textBox5.Text);
            double z2 = textBox6.Text.Trim() == "" ? 0 : double.Parse(textBox6.Text);

            v1 = new Vector3D(x1, y1, z1);
            v2 = new Vector3D(x2, y2, z2);

            label12.Text = $"Вектор1: ({v1.X}, {v1.Y}, {v1.Z})";
            label13.Text = $"Вектор2: ({v2.X}, {v2.Y}, {v2.Z})";
            double cosine = v1.Cosine(v2);
            label14.Text = $"Косінус: {cosine}";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            double x1 = textBox1.Text.Trim() == "" ? 0 : double.Parse(textBox1.Text);
            double y1 = textBox2.Text.Trim() == "" ? 0 : double.Parse(textBox2.Text);
            double z1 = textBox3.Text.Trim() == "" ? 0 : double.Parse(textBox3.Text);

            double x2 = textBox4.Text.Trim() == "" ? 0 : double.Parse(textBox4.Text);
            double y2 = textBox5.Text.Trim() == "" ? 0 : double.Parse(textBox5.Text);
            double z2 = textBox6.Text.Trim() == "" ? 0 : double.Parse(textBox6.Text);

            v1 = new Vector3D(x1, y1, z1);
            v2 = new Vector3D(x2, y2, z2);

            label12.Text = $"Вектор1: ({v1.X}, {v1.Y}, {v1.Z})";
            label13.Text = $"Вектор2: ({v2.X}, {v2.Y}, {v2.Z})";
            double scalar = v1 * v2;
            label14.Text = $"Скалярний добуток: {scalar}";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                // цифра
                return;
            }
            if (e.KeyChar == '.')
            {
                // крапку замінемо комою
                e.KeyChar = ',';
            }
            if (e.KeyChar == ',')
            {
                if (textBox1.Text.IndexOf(',') != -1)
                {
                    // кома вже є в полі редагування
                    e.Handled = true;
                }
                return;
            }
            if (Char.IsControl(e.KeyChar))
            {
                // <Enter>, <Backspace>, <Esc>
                if (e.KeyChar == (char)Keys.Enter)
                    // натиснута клавіша <Enter>
                    // встановити курсор на кнопку OK
                    textBox1.Focus();
                return;
            }
            // інші символи заборонені
            e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                // цифра
                return;
            }
            if (e.KeyChar == '.')
            {
                // крапку замінемо комою
                e.KeyChar = ',';
            }
            if (e.KeyChar == ',')
            {
                if (textBox2.Text.IndexOf(',') != -1)
                {
                    // кома вже є в полі редагування
                    e.Handled = true;
                }
                return;
            }
            if (Char.IsControl(e.KeyChar))
            {
                // <Enter>, <Backspace>, <Esc>
                if (e.KeyChar == (char)Keys.Enter)
                    // натиснута клавіша <Enter>
                    // встановити курсор на кнопку OK
                    textBox2.Focus();
                return;
            }
            // інші символи заборонені
            e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                // цифра
                return;
            }
            if (e.KeyChar == '.')
            {
                // крапку замінемо комою
                e.KeyChar = ',';
            }
            if (e.KeyChar == ',')
            {
                if (textBox3.Text.IndexOf(',') != -1)
                {
                    // кома вже є в полі редагування
                    e.Handled = true;
                }
                return;
            }
            if (Char.IsControl(e.KeyChar))
            {
                // <Enter>, <Backspace>, <Esc>
                if (e.KeyChar == (char)Keys.Enter)
                    // натиснута клавіша <Enter>
                    // встановити курсор на кнопку OK
                    textBox3.Focus();
                return;
            }
            // інші символи заборонені
            e.Handled = true;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                // цифра
                return;
            }
            if (e.KeyChar == '.')
            {
                // крапку замінемо комою
                e.KeyChar = ',';
            }
            if (e.KeyChar == ',')
            {
                if (textBox4.Text.IndexOf(',') != -1)
                {
                    // кома вже є в полі редагування
                    e.Handled = true;
                }
                return;
            }
            if (Char.IsControl(e.KeyChar))
            {
                // <Enter>, <Backspace>, <Esc>
                if (e.KeyChar == (char)Keys.Enter)
                    // натиснута клавіша <Enter>
                    // встановити курсор на кнопку OK
                    textBox4.Focus();
                return;
            }
            // інші символи заборонені
            e.Handled = true;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                // цифра
                return;
            }
            if (e.KeyChar == '.')
            {
                // крапку замінемо комою
                e.KeyChar = ',';
            }
            if (e.KeyChar == ',')
            {
                if (textBox5.Text.IndexOf(',') != -1)
                {
                    // кома вже є в полі редагування
                    e.Handled = true;
                }
                return;
            }
            if (Char.IsControl(e.KeyChar))
            {
                // <Enter>, <Backspace>, <Esc>
                if (e.KeyChar == (char)Keys.Enter)
                    // натиснута клавіша <Enter>
                    // встановити курсор на кнопку OK
                    textBox5.Focus();
                return;
            }
            // інші символи заборонені
            e.Handled = true;
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                // цифра
                return;
            }
            if (e.KeyChar == '.')
            {
                // крапку замінемо комою
                e.KeyChar = ',';
            }
            if (e.KeyChar == ',')
            {
                if (textBox6.Text.IndexOf(',') != -1)
                {
                    // кома вже є в полі редагування
                    e.Handled = true;
                }
                return;
            }
            if (Char.IsControl(e.KeyChar))
            {
                // <Enter>, <Backspace>, <Esc>
                if (e.KeyChar == (char)Keys.Enter)
                    // натиснута клавіша <Enter>
                    // встановити курсор на кнопку OK
                    textBox6.Focus();
                return;
            }
            // інші символи заборонені
            e.Handled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double x1 = textBox1.Text.Trim() == "" ? 0 : double.Parse(textBox1.Text);
            double y1 = textBox2.Text.Trim() == "" ? 0 : double.Parse(textBox2.Text);
            double z1 = textBox3.Text.Trim() == "" ? 0 : double.Parse(textBox3.Text);

            double x2 = textBox4.Text.Trim() == "" ? 0 : double.Parse(textBox4.Text);
            double y2 = textBox5.Text.Trim() == "" ? 0 : double.Parse(textBox5.Text);
            double z2 = textBox6.Text.Trim() == "" ? 0 : double.Parse(textBox6.Text);

            v1 = new Vector3D(x1, y1, z1);
            v2 = new Vector3D(x2, y2, z2);

            label12.Text = $"Вектор1: ({v1.X}, {v1.Y}, {v1.Z})";
            label13.Text = $"Вектор2: ({v2.X}, {v2.Y}, {v2.Z})";
            Vector3D sum = v1 + v2;

            label14.Text = $"Сума цих векторів: ({sum.X}, {sum.Y}, {sum.Z})";
        }
    }
}