using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_3
{
    public class Calculation
    {
        private readonly int _number;
        public ProgressBar ProgressBar;
        private CancellationTokenSource _cancellationTokenSource;
        private readonly bool _radioMatrix;

        public bool IsRun;
        public bool IsDo;

        public Calculation(int number, bool radioMatrix)
        {
            _number = number;
            ProgressBar = new ProgressBar();
            _radioMatrix = radioMatrix;
        }

        private ulong _factorial;

        private void Factorial(object state)
        {
            var n = (ulong)_number;
            var start = n;
            var token = (CancellationToken)state;
            _factorial = 1;

            var progress = 0;
            while (n >= 1)
            {
                _factorial *= n;
                n--;
                progress++;
                if (ProgressBar.InvokeRequired)
                {
                    var progress1 = progress;
                    ProgressBar.Invoke(new MethodInvoker(delegate { ProgressBar.Value = progress1 / (int)start; }));
                }

                if (token.IsCancellationRequested)
                    return;
            }

            IsDo = true;
            if (ProgressBar.InvokeRequired)
            {
                ProgressBar.Invoke(new MethodInvoker(delegate { ProgressBar.Value = ProgressBar.Maximum; }));
            }
        }

        private int[,] _a;
        private int[,] _b;
        private int[,] _res;

        private void CalculationMatrix(object state)
        {
            var token = (CancellationToken)state;
            _a = new int[_number, _number];
            _b = new int[_number, _number];
            _res = new int[_number, _number];
            _a = CreateMatrix(_number, _a);
            _b = CreateMatrix(_number, _b);
            var progress = 0;
            for (var i = 0; i < _number; i++)
            for (var j = 0; j < _number; j++)
            for (var k = 0; k < _number; k++)
            {
                progress++;
                _res[i, j] += _a[i, k] * _b[k, j];
                if (ProgressBar.InvokeRequired)
                {
                    var progress1 = progress;
                    ProgressBar.Invoke(new MethodInvoker(delegate
                    {
                        ProgressBar.Value = progress1 / (_number * _number);
                    }));
                }

                if (token.IsCancellationRequested)
                    return;
            }

            IsDo = true;
            if (ProgressBar.InvokeRequired)
            {
                // Label.Invoke(new MethodInvoker(delegate { Label.Text = _res[0, 0].ToString(); }));
                ProgressBar.Invoke(new MethodInvoker(delegate { ProgressBar.Value = ProgressBar.Maximum; }));
            }
        }

        private static int[,] CreateMatrix(int count, int[,] matrix)
        {
            var rnd = new Random();
            for (var i = 0; i < count; i++)
            for (var j = 0; j < count; j++)
                matrix[i, j] = rnd.Next(count);

            return matrix;
        }


        public async Task Start()
        {
            IsRun = true;
            _cancellationTokenSource = new CancellationTokenSource();
            if (_radioMatrix)
            {
                // lists.Add(new Thread(CalculationMatrix));
                ThreadPool.QueueUserWorkItem(CalculationMatrix, _cancellationTokenSource.Token);
            }
            else
            {
                ThreadPool.QueueUserWorkItem(Factorial, _cancellationTokenSource.Token);
                // lists.Add(new Thread(Factorial));
            }
        }

        public void Result(object sender, EventArgs e)
        {
            var form = new Form();
            form.Width = 1200;
            form.Height = 800;
            var label = new Label();
            form.Controls.Add(label);
            label.AutoSize = true;
            if (_radioMatrix)
            {
                label.Text = "Матрица А:\n" + ResultMatrixToString(_a)
                                            + "\nМатрица В:\n" + ResultMatrixToString(_b)
                                            + "\nМатрица результирующая:\n" + ResultMatrixToString(_res);
            }
            else
            {
                label.Text = "\n \t Факториал числа " + _number + " = " + _factorial;
            }

            form.Visible = true;
        }

        private string ResultMatrixToString(int[,] matrix)
        {
            var str = new StringBuilder();
            for (var i = 0; i < _number; i++)
            {
                for (var j = 0; j < _number; j++)
                {
                    str.Append(matrix[i, j] + " ");
                }

                str.Append('\n');
            }

            return str.ToString();
        }
    }
}