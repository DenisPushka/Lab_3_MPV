namespace Lab_3
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.inputNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButtonMatrix = new System.Windows.Forms.RadioButton();
            this.radioButtonFactorail = new System.Windows.Forms.RadioButton();
            this.timer1 = new System.Timers.Timer();
            ((System.ComponentModel.ISupportInitialize)(this.timer1)).BeginInit();
            this.SuspendLayout();
            // 
            // inputNumber
            // 
            this.inputNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.inputNumber.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.inputNumber.Location = new System.Drawing.Point(162, 653);
            this.inputNumber.Name = "inputNumber";
            this.inputNumber.Size = new System.Drawing.Size(144, 27);
            this.inputNumber.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.label1.Location = new System.Drawing.Point(12, 653);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(144, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Введите число:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // radioButtonMatrix
            // 
            this.radioButtonMatrix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButtonMatrix.Location = new System.Drawing.Point(332, 655);
            this.radioButtonMatrix.Name = "radioButtonMatrix";
            this.radioButtonMatrix.Size = new System.Drawing.Size(104, 24);
            this.radioButtonMatrix.TabIndex = 2;
            this.radioButtonMatrix.TabStop = true;
            this.radioButtonMatrix.Text = "Матрица";
            this.radioButtonMatrix.UseVisualStyleBackColor = true;
            // 
            // radioButtonFactorail
            // 
            this.radioButtonFactorail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButtonFactorail.Location = new System.Drawing.Point(402, 655);
            this.radioButtonFactorail.Name = "radioButtonFactorail";
            this.radioButtonFactorail.Size = new System.Drawing.Size(104, 24);
            this.radioButtonFactorail.TabIndex = 3;
            this.radioButtonFactorail.TabStop = true;
            this.radioButtonFactorail.Text = "Факториал";
            this.radioButtonFactorail.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500D;
            this.timer1.SynchronizingObject = this;
            this.timer1.Elapsed += new System.Timers.ElapsedEventHandler(this.timer1_Elapsed);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1248, 685);
            this.Controls.Add(this.radioButtonFactorail);
            this.Controls.Add(this.radioButtonMatrix);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inputNumber);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Lab_3";
            ((System.ComponentModel.ISupportInitialize)(this.timer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Timers.Timer timer1;

        private System.Windows.Forms.RadioButton radioButtonMatrix;
        private System.Windows.Forms.RadioButton radioButtonFactorail;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.TextBox inputNumber;

        #endregion
    }
}