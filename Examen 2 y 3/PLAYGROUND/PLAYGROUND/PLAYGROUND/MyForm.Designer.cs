namespace PLAYGROUND
{
    partial class MyForm
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.PNL_MAIN = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BUTTON7 = new System.Windows.Forms.Button();
            this.BUTTON5 = new System.Windows.Forms.Button();
            this.BUTTON3 = new System.Windows.Forms.Button();
            this.VIDAS = new System.Windows.Forms.Label();
            this.PCT_CANVAS = new System.Windows.Forms.PictureBox();
            this.TIMER = new System.Windows.Forms.Timer(this.components);
            this.PNL_MAIN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PCT_CANVAS)).BeginInit();
            this.SuspendLayout();
            // 
            // PNL_MAIN
            // 
            this.PNL_MAIN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.PNL_MAIN.Controls.Add(this.label2);
            this.PNL_MAIN.Controls.Add(this.label1);
            this.PNL_MAIN.Controls.Add(this.BUTTON7);
            this.PNL_MAIN.Controls.Add(this.BUTTON5);
            this.PNL_MAIN.Controls.Add(this.BUTTON3);
            this.PNL_MAIN.Controls.Add(this.VIDAS);
            this.PNL_MAIN.Controls.Add(this.PCT_CANVAS);
            this.PNL_MAIN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PNL_MAIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PNL_MAIN.ForeColor = System.Drawing.Color.Silver;
            this.PNL_MAIN.Location = new System.Drawing.Point(0, 0);
            this.PNL_MAIN.Margin = new System.Windows.Forms.Padding(4);
            this.PNL_MAIN.Name = "PNL_MAIN";
            this.PNL_MAIN.Size = new System.Drawing.Size(1283, 675);
            this.PNL_MAIN.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Agency FB", 70.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(358, 335);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(513, 139);
            this.label2.TabIndex = 13;
            this.label2.Text = "PLAY AGAIN";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Agency FB", 70.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(376, 139);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(527, 139);
            this.label1.TabIndex = 12;
            this.label1.Text = "SUMO FIGHT";
            // 
            // BUTTON7
            // 
            this.BUTTON7.BackColor = System.Drawing.Color.Black;
            this.BUTTON7.Font = new System.Drawing.Font("Agency FB", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BUTTON7.ForeColor = System.Drawing.Color.Transparent;
            this.BUTTON7.Location = new System.Drawing.Point(848, 523);
            this.BUTTON7.Margin = new System.Windows.Forms.Padding(2);
            this.BUTTON7.Name = "BUTTON7";
            this.BUTTON7.Size = new System.Drawing.Size(152, 100);
            this.BUTTON7.TabIndex = 11;
            this.BUTTON7.Text = "5";
            this.BUTTON7.UseVisualStyleBackColor = false;
            this.BUTTON7.Click += new System.EventHandler(this.BUTTON7_Click);
            // 
            // BUTTON5
            // 
            this.BUTTON5.BackColor = System.Drawing.Color.Black;
            this.BUTTON5.Font = new System.Drawing.Font("Agency FB", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BUTTON5.ForeColor = System.Drawing.Color.Transparent;
            this.BUTTON5.Location = new System.Drawing.Point(561, 523);
            this.BUTTON5.Margin = new System.Windows.Forms.Padding(2);
            this.BUTTON5.Name = "BUTTON5";
            this.BUTTON5.Size = new System.Drawing.Size(152, 100);
            this.BUTTON5.TabIndex = 10;
            this.BUTTON5.Text = "3";
            this.BUTTON5.UseVisualStyleBackColor = false;
            this.BUTTON5.Click += new System.EventHandler(this.BUTTON5_Click);
            // 
            // BUTTON3
            // 
            this.BUTTON3.BackColor = System.Drawing.Color.Black;
            this.BUTTON3.Font = new System.Drawing.Font("Agency FB", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BUTTON3.ForeColor = System.Drawing.Color.Transparent;
            this.BUTTON3.Location = new System.Drawing.Point(259, 523);
            this.BUTTON3.Margin = new System.Windows.Forms.Padding(2);
            this.BUTTON3.Name = "BUTTON3";
            this.BUTTON3.Size = new System.Drawing.Size(152, 100);
            this.BUTTON3.TabIndex = 9;
            this.BUTTON3.Text = "1";
            this.BUTTON3.UseVisualStyleBackColor = false;
            this.BUTTON3.Click += new System.EventHandler(this.BUTTON3_Click);
            // 
            // VIDAS
            // 
            this.VIDAS.AutoSize = true;
            this.VIDAS.BackColor = System.Drawing.Color.Transparent;
            this.VIDAS.Font = new System.Drawing.Font("Agency FB", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VIDAS.ForeColor = System.Drawing.Color.White;
            this.VIDAS.Location = new System.Drawing.Point(566, 384);
            this.VIDAS.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.VIDAS.Name = "VIDAS";
            this.VIDAS.Size = new System.Drawing.Size(125, 61);
            this.VIDAS.TabIndex = 8;
            this.VIDAS.Text = "VIDAS";
            // 
            // PCT_CANVAS
            // 
            this.PCT_CANVAS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.PCT_CANVAS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PCT_CANVAS.Location = new System.Drawing.Point(0, 0);
            this.PCT_CANVAS.Margin = new System.Windows.Forms.Padding(4);
            this.PCT_CANVAS.Name = "PCT_CANVAS";
            this.PCT_CANVAS.Size = new System.Drawing.Size(1283, 675);
            this.PCT_CANVAS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PCT_CANVAS.TabIndex = 6;
            this.PCT_CANVAS.TabStop = false;
            this.PCT_CANVAS.Click += new System.EventHandler(this.PCT_CANVAS_Click);
            // 
            // TIMER
            // 
            this.TIMER.Interval = 10;
            this.TIMER.Tick += new System.EventHandler(this.TIMER_Tick);
            // 
            // MyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1283, 675);
            this.Controls.Add(this.PNL_MAIN);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MyForm";
            this.Text = "SUMO FIGHT";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.SizeChanged += new System.EventHandler(this.MyForm_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MyForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MyForm_KeyUp);
            this.PNL_MAIN.ResumeLayout(false);
            this.PNL_MAIN.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PCT_CANVAS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PNL_MAIN;
        private System.Windows.Forms.PictureBox PCT_CANVAS;
        private System.Windows.Forms.Timer TIMER;
        private System.Windows.Forms.Label VIDAS;
        private System.Windows.Forms.Button BUTTON3;
        private System.Windows.Forms.Button BUTTON7;
        private System.Windows.Forms.Button BUTTON5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

