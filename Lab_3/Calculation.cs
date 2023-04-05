using System;
using System.Threading;
using System.Windows.Forms;

namespace Lab_3
{
    public class Calculation
    {
        private readonly int _number;
        public ProgressBar ProgressBar;
        private CancellationTokenSource _cancellationTokenSource;
        public Label Label;
        private readonly bool _radioMatrix;

        public Calculation(int number, bool radioMatrix)
        {
            _number = number;
            ProgressBar = new ProgressBar();
            Label = new Label();
            _radioMatrix = radioMatrix;
        }

        private void Factorial(object state)
        {
            var n = (ulong)_number;
            var start = n;
            var token = (CancellationToken)state;
            ulong factorial = 1;

            var progress = 0;
            while (n >= 1)
            {
                factorial *= n;
                n--;
                progress++;
                if (ProgressBar.InvokeRequired)
                {
                    var progress1 = progress;
                    ProgressBar.Invoke(new MethodInvoker(delegate { ProgressBar.Value = progress1 / (int)start; }));
                }

                if (token.IsCancellationRequested)
                {
                    return;
                }
            }

            if (ProgressBar.InvokeRequired)
            {
                Label.Invoke(new MethodInvoker(delegate { Label.Text = factorial.ToString(); }));
                ProgressBar.Invoke(new MethodInvoker(delegate { ProgressBar.Value = ProgressBar.Maximum; }));
            }
        }

        private void Matrix(object state)
        {
            var token = (CancellationToken)state;
            var a = new int[_number, _number];
            var b = new int[_number, _number];
            var res = new int[_number, _number];
            a = CreateMatrix(_number, a);
            b = CreateMatrix(_number, b);
            var progress = 0;
            for (var i = 0; i < _number; i++)
            {
                for (var j = 0; j < _number; j++)
                {
                    for (var k = 0; k < _number; k++)
                    {
                        progress++;
                        res[i, j] += a[i, k] * b[k, j];
                        if (ProgressBar.InvokeRequired)
                        {
                            var progress1 = progress;
                            ProgressBar.Invoke(new MethodInvoker(delegate
                            {
                                ProgressBar.Value = progress1 / (_number * _number);
                            }));
                        }

                        if (token.IsCancellationRequested)
                        {
                            return;
                        }
                    }
                }
            }

            if (ProgressBar.InvokeRequired)
            {
                Label.Invoke(new MethodInvoker(delegate { Label.Text = res[0, 0].ToString(); }));
                ProgressBar.Invoke(new MethodInvoker(delegate { ProgressBar.Value = ProgressBar.Maximum; }));
            }
        }

        private static int[,] CreateMatrix(int count, int[,] a)
        {
            var rnd = new Random();
            for (var i = 0; i < count; i++)
            {
                for (var j = 0; j < count; j++)
                {
                    a[i, j] = rnd.Next(count);
                }
            }

            return a;
        }

        public void Start()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            if (_radioMatrix)
                ThreadPool.QueueUserWorkItem(Matrix, _cancellationTokenSource.Token);
            else
                ThreadPool.QueueUserWorkItem(Factorial, _cancellationTokenSource.Token);
        }
    }
}