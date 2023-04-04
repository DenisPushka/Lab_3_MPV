﻿using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_3
{
    public class Calculation
    {
        public ulong Result;
        private readonly int _number;
        private const ushort Width = 200;
        private const short Height = 100;
        public readonly Label Label = new Label();

        public Calculation(int number)
        {
            _number = number;
        }

        private void Factorial()
        {
            var n = ulong.Parse(_number.ToString());
            ulong factorial = 1;

            while (n >= 1)
            {
                factorial *= n;
                n--;
            }

            Result = factorial;
        }

        public Task Start(MainForm main, int countPanel)
        {
            var panel = new Panel();
            panel.BackColor = Color.Beige;
            var c = countPanel != 0 ? 10 : 0;
            panel.Location = new Point(20 + countPanel * Width + c * countPanel, 20);
            panel.Height = Height;
            panel.Width = Width;
            panel.BorderStyle = BorderStyle.Fixed3D;
            main.Controls.Add(panel);

            var label = new Label();
            label.Location = new Point(0, 0);
            label.Width = Width;
            label.Font = new Font("Microsoft Sans Serif", 8);
            label.Text = "Вычисление факториала: " + _number;
            panel.Controls.Add(label);
            main.Stack.Push(new Thread(Factorial));
            Label.Location = new Point(0, 70);
            Label.Height = 20;
            Label.Width = Width;
            Label.TextAlign = ContentAlignment.TopCenter;
            Label.BackColor = Color.Gray;
            Label.Text = Result.ToString();
            panel.Controls.Add(Label);
            return Task.CompletedTask;
        }
    }
}