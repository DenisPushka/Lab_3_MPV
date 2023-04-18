using System.Collections.Generic;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;

namespace Lab_3
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            timer1.Enabled = true;
            timer1.Start();
            timer1.Interval = 2000;
            inputNumber.KeyDown += InputData;
        }

        // private readonly Stack<Calculation> _lists = new Stack<Calculation>();
        private readonly List<Calculation> _lists = new List<Calculation>();

        private void InputData(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var number = int.Parse(inputNumber.Text);
                var calculation = new Calculation(number, radioButtonMatrix.Checked);
                CreateForm(number, calculation);
                _lists.Add(calculation);
                // _lists.Push(calculation);
            }
        }

        private int _countPanel;
        private const ushort WidthM = 200;
        private const ushort HeightH = 100;
        private int _y;
        private int _level;

        private void CreateForm(int number, Calculation calculation)
        {
            var panel = new Panel();
            panel.BackColor = Color.Beige;
            var c = _countPanel != 0 ? 10 : 0;

            if (20 + _countPanel * WidthM + c * _countPanel > Width)
            {
                _level++;
                _countPanel = 0;
                _y = 100 * _level + 10 * _level;
            }

            panel.Location = new Point(20 + _countPanel * WidthM + c * _countPanel, 20 + _y);
            panel.Height = HeightH;
            panel.Width = WidthM;
            panel.BorderStyle = BorderStyle.Fixed3D;
            _countPanel++;

            var label = new Label();
            label.Location = new Point(0, 0);
            label.TextAlign = ContentAlignment.TopCenter;
            label.Width = WidthM;
            label.Height = 20;
            label.Font = new Font("Microsoft Sans Serif", 8);
            if (!radioButtonMatrix.Checked)
                label.Text = @"Вычисление факториала: " + number;
            else
                label.Text = @"Размер матрицы: " + number;
            panel.Controls.Add(label);

            var button = new Button();
            button.AutoSize = true;
            button.Text = @"Результаты";
            button.Tag = calculation;
            button.Dock = DockStyle.Bottom;
            button.Click += calculation.Result;
            panel.Controls.Add(button);

            var value = new Label();
            value.Location = new Point(0, 30);
            value.Height = 20;
            value.Width = WidthM;
            value.TextAlign = ContentAlignment.TopCenter;
            value.BackColor = Color.Gray;
            panel.Controls.Add(value);

            var progressbar = new ProgressBar();
            progressbar.Location = new Point(0, 85);
            progressbar.Dock = DockStyle.Bottom;
            progressbar.Height = 10;
            progressbar.Width = WidthM;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Controls.Add(progressbar);

            Controls.Add(panel);
            calculation.ProgressBar = progressbar;
        }

        private void timer1_Elapsed(object sender, ElapsedEventArgs e)
        {
            foreach (var list in _lists)
            {
                if (list.IsDo)
                    continue;
                
                if (list.IsRun)
                    return;

                list.Start();
                return;
            }
        }
    }
}