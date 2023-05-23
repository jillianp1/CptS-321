namespace Spreadsheet_Jillian_Plahn
{
    partial class Form1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.A = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.B = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.demoButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.A,
            this.B,
            this.C,
            this.D});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(776, 426);
            this.dataGridView1.TabIndex = 0;
            // 
            // A
            // 
            this.A.HeaderText = "A";
            this.A.MinimumWidth = 8;
            this.A.Name = "A";
            this.A.Width = 150;
            // 
            // B
            // 
            this.B.HeaderText = "B";
            this.B.MinimumWidth = 8;
            this.B.Name = "B";
            this.B.Width = 150;
            // 
            // C
            // 
            this.C.HeaderText = "C";
            this.C.MinimumWidth = 8;
            this.C.Name = "C";
            this.C.Width = 150;
            // 
            // D
            // 
            this.D.HeaderText = "D";
            this.D.MinimumWidth = 8;
            this.D.Name = "D";
            this.D.Width = 150;
            // 
            // demoButton
            // 
            this.demoButton.Location = new System.Drawing.Point(649, 392);
            this.demoButton.Name = "demoButton";
            this.demoButton.Size = new System.Drawing.Size(139, 46);
            this.demoButton.TabIndex = 1;
            this.demoButton.Text = "Demo";
            this.demoButton.UseVisualStyleBackColor = true;
            this.demoButton.Click += new System.EventHandler(this.demoButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(244, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(10, 19);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 437);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.demoButton);
            this.Controls.Add(this.dataGridView1);
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn A;
        private System.Windows.Forms.DataGridViewTextBoxColumn B;
        private System.Windows.Forms.DataGridViewTextBoxColumn C;
        private System.Windows.Forms.DataGridViewTextBoxColumn D;
        private System.Windows.Forms.Button demoButton;
        private System.Windows.Forms.Button button2;
    }
}

