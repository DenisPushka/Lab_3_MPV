using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Lab_3
{
    public partial class MainForm : Form
    {
        public readonly Stack<Thread> Stack = new Stack<Thread>();
        public MainForm()
        {
            InitializeComponent();
            inputNumber.KeyDown += InputData;
        }

        private async void InputData(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var number = int.Parse(inputNumber.Text);
                var calculation = new Calculation(number);
                await calculation.Start(this, Stack.Count);
                var a = Stack.Peek();
                a.Start();
                a.Join();
                calculation.Label.Text = calculation.Result.ToString();
            }
        }
    }
}