namespace Colision2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            PCT_CANVAS = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            AmountText = new TextBox();
            Amount = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)PCT_CANVAS).BeginInit();
            SuspendLayout();
            // 
            // PCT_CANVAS
            // 
            PCT_CANVAS.Location = new Point(12, 58);
            PCT_CANVAS.Name = "PCT_CANVAS";
            PCT_CANVAS.Size = new Size(2500, 1380);
            PCT_CANVAS.TabIndex = 0;
            PCT_CANVAS.TabStop = false;
            PCT_CANVAS.Click += pictureBox1_Click;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 60;
            timer1.Tick += timer1_Tick;
            // 
            // AmountText
            // 
            AmountText.BackColor = SystemColors.ScrollBar;
            AmountText.ForeColor = Color.Black;
            AmountText.Location = new Point(318, 9);
            AmountText.Name = "AmountText";
            AmountText.Size = new Size(200, 39);
            AmountText.TabIndex = 1;
            // 
            // Amount
            // 
            Amount.AutoSize = true;
            Amount.ForeColor = SystemColors.ButtonHighlight;
            Amount.Location = new Point(189, 9);
            Amount.Name = "Amount";
            Amount.Size = new Size(100, 32);
            Amount.TabIndex = 2;
            Amount.Text = "Amount";
            Amount.Click += Amount_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Red;
            button1.Location = new Point(12, 6);
            button1.Name = "button1";
            button1.Size = new Size(150, 46);
            button1.TabIndex = 3;
            button1.Text = "Play";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(1893, 955);
            Controls.Add(button1);
            Controls.Add(Amount);
            Controls.Add(AmountText);
            Controls.Add(PCT_CANVAS);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)PCT_CANVAS).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox PCT_CANVAS;
        private System.Windows.Forms.Timer timer1;
        private TextBox AmountText;
        private Label Amount;
        private Button button1;
    }
}
