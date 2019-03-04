namespace lab1
{
    partial class MainWindow
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
            this.startBtn = new System.Windows.Forms.Button();
            this.codeBox = new System.Windows.Forms.TextBox();
            this.errorBox = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.identBox = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.tokenBox = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.openBtn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pathBox = new System.Windows.Forms.TextBox();
            this.textbox8 = new System.Windows.Forms.TextBox();
            this.symbBox = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.keywordBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // startBtn
            // 
            this.startBtn.Enabled = false;
            this.startBtn.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startBtn.Location = new System.Drawing.Point(78, 14);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(392, 66);
            this.startBtn.TabIndex = 0;
            this.startBtn.Text = "Лексичний аналіз";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // codeBox
            // 
            this.codeBox.Location = new System.Drawing.Point(78, 125);
            this.codeBox.Multiline = true;
            this.codeBox.Name = "codeBox";
            this.codeBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.codeBox.Size = new System.Drawing.Size(240, 260);
            this.codeBox.TabIndex = 1;
            this.codeBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // errorBox
            // 
            this.errorBox.Location = new System.Drawing.Point(78, 428);
            this.errorBox.Multiline = true;
            this.errorBox.Name = "errorBox";
            this.errorBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.errorBox.Size = new System.Drawing.Size(843, 70);
            this.errorBox.TabIndex = 2;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(78, 398);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(843, 22);
            this.textBox3.TabIndex = 3;
            this.textBox3.Text = "Помилки";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // identBox
            // 
            this.identBox.BackColor = System.Drawing.SystemColors.Window;
            this.identBox.Location = new System.Drawing.Point(324, 125);
            this.identBox.Multiline = true;
            this.identBox.Name = "identBox";
            this.identBox.ReadOnly = true;
            this.identBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.identBox.Size = new System.Drawing.Size(146, 259);
            this.identBox.TabIndex = 4;
            this.identBox.TextChanged += new System.EventHandler(this.identBox_TextChanged);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(78, 94);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(240, 22);
            this.textBox5.TabIndex = 5;
            this.textBox5.Text = "Вхідний текст";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(324, 94);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(146, 22);
            this.textBox6.TabIndex = 6;
            this.textBox6.Text = "Ідентифікатори";
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tokenBox
            // 
            this.tokenBox.BackColor = System.Drawing.SystemColors.Window;
            this.tokenBox.Location = new System.Drawing.Point(779, 125);
            this.tokenBox.Multiline = true;
            this.tokenBox.Name = "tokenBox";
            this.tokenBox.ReadOnly = true;
            this.tokenBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tokenBox.Size = new System.Drawing.Size(142, 259);
            this.tokenBox.TabIndex = 7;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(779, 94);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(142, 22);
            this.textBox2.TabIndex = 8;
            this.textBox2.Text = "Лексеми";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // openBtn
            // 
            this.openBtn.Location = new System.Drawing.Point(819, 504);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(102, 22);
            this.openBtn.TabIndex = 9;
            this.openBtn.Text = "Open file";
            this.openBtn.UseVisualStyleBackColor = true;
            this.openBtn.Click += new System.EventHandler(this.openBtn_Click_1);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pathBox
            // 
            this.pathBox.AllowDrop = true;
            this.pathBox.Location = new System.Drawing.Point(78, 504);
            this.pathBox.Name = "pathBox";
            this.pathBox.ReadOnly = true;
            this.pathBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.pathBox.Size = new System.Drawing.Size(725, 22);
            this.pathBox.TabIndex = 10;
            this.pathBox.TextChanged += new System.EventHandler(this.pathBox_TextChanged);
            // 
            // textbox8
            // 
            this.textbox8.Location = new System.Drawing.Point(476, 94);
            this.textbox8.Name = "textbox8";
            this.textbox8.Size = new System.Drawing.Size(136, 22);
            this.textbox8.TabIndex = 12;
            this.textbox8.Text = "Символи";
            this.textbox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // symbBox
            // 
            this.symbBox.BackColor = System.Drawing.SystemColors.Window;
            this.symbBox.Location = new System.Drawing.Point(476, 125);
            this.symbBox.Multiline = true;
            this.symbBox.Name = "symbBox";
            this.symbBox.ReadOnly = true;
            this.symbBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.symbBox.Size = new System.Drawing.Size(136, 260);
            this.symbBox.TabIndex = 11;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(618, 94);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(155, 22);
            this.textBox1.TabIndex = 14;
            this.textBox1.Text = "Ключові слова";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // keywordBox
            // 
            this.keywordBox.BackColor = System.Drawing.SystemColors.Window;
            this.keywordBox.Location = new System.Drawing.Point(618, 125);
            this.keywordBox.Multiline = true;
            this.keywordBox.Name = "keywordBox";
            this.keywordBox.ReadOnly = true;
            this.keywordBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.keywordBox.Size = new System.Drawing.Size(155, 259);
            this.keywordBox.TabIndex = 13;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 555);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.keywordBox);
            this.Controls.Add(this.textbox8);
            this.Controls.Add(this.symbBox);
            this.Controls.Add(this.pathBox);
            this.Controls.Add(this.openBtn);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.tokenBox);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.identBox);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.errorBox);
            this.Controls.Add(this.codeBox);
            this.Controls.Add(this.startBtn);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "MainWindow";
            this.Text = "Signal-translator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.TextBox codeBox;
        private System.Windows.Forms.TextBox errorBox;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox identBox;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox tokenBox;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button openBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox pathBox;
        private System.Windows.Forms.TextBox textbox8;
        private System.Windows.Forms.TextBox symbBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox keywordBox;
    }
}