namespace SignalTranslator
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
            this.btnLexAn = new System.Windows.Forms.Button();
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
            this.SyntaxTree = new System.Windows.Forms.TreeView();
            this.btnSynAn = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.asmCodeBox = new System.Windows.Forms.TextBox();
            this.CodeGenButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLexAn
            // 
            this.btnLexAn.Enabled = false;
            this.btnLexAn.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnLexAn.Location = new System.Drawing.Point(24, 11);
            this.btnLexAn.Margin = new System.Windows.Forms.Padding(4);
            this.btnLexAn.Name = "btnLexAn";
            this.btnLexAn.Size = new System.Drawing.Size(257, 34);
            this.btnLexAn.TabIndex = 0;
            this.btnLexAn.Text = "Lexical Analysis";
            this.btnLexAn.UseVisualStyleBackColor = true;
            this.btnLexAn.Click += new System.EventHandler(this.button1_Click);
            // 
            // codeBox
            // 
            this.codeBox.Location = new System.Drawing.Point(24, 84);
            this.codeBox.Margin = new System.Windows.Forms.Padding(4);
            this.codeBox.Multiline = true;
            this.codeBox.Name = "codeBox";
            this.codeBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.codeBox.Size = new System.Drawing.Size(345, 367);
            this.codeBox.TabIndex = 1;
            this.codeBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // errorBox
            // 
            this.errorBox.Location = new System.Drawing.Point(24, 489);
            this.errorBox.Margin = new System.Windows.Forms.Padding(4);
            this.errorBox.Multiline = true;
            this.errorBox.Name = "errorBox";
            this.errorBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.errorBox.Size = new System.Drawing.Size(830, 69);
            this.errorBox.TabIndex = 2;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(24, 459);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(830, 23);
            this.textBox3.TabIndex = 3;
            this.textBox3.Text = "Errors";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // identBox
            // 
            this.identBox.BackColor = System.Drawing.SystemColors.Window;
            this.identBox.Location = new System.Drawing.Point(375, 84);
            this.identBox.Margin = new System.Windows.Forms.Padding(4);
            this.identBox.Multiline = true;
            this.identBox.Name = "identBox";
            this.identBox.ReadOnly = true;
            this.identBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.identBox.Size = new System.Drawing.Size(147, 165);
            this.identBox.TabIndex = 4;
            this.identBox.TextChanged += new System.EventHandler(this.identBox_TextChanged);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(24, 53);
            this.textBox5.Margin = new System.Windows.Forms.Padding(4);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(345, 23);
            this.textBox5.TabIndex = 5;
            this.textBox5.Text = "Input";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(375, 53);
            this.textBox6.Margin = new System.Windows.Forms.Padding(4);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(147, 23);
            this.textBox6.TabIndex = 6;
            this.textBox6.Text = "Identificators";
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tokenBox
            // 
            this.tokenBox.BackColor = System.Drawing.SystemColors.Window;
            this.tokenBox.Location = new System.Drawing.Point(683, 84);
            this.tokenBox.Margin = new System.Windows.Forms.Padding(4);
            this.tokenBox.Multiline = true;
            this.tokenBox.Name = "tokenBox";
            this.tokenBox.ReadOnly = true;
            this.tokenBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tokenBox.Size = new System.Drawing.Size(171, 165);
            this.tokenBox.TabIndex = 7;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(683, 52);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(171, 23);
            this.textBox2.TabIndex = 8;
            this.textBox2.Text = "Tokens";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // openBtn
            // 
            this.openBtn.Location = new System.Drawing.Point(746, 566);
            this.openBtn.Margin = new System.Windows.Forms.Padding(4);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(108, 23);
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
            this.pathBox.Location = new System.Drawing.Point(24, 566);
            this.pathBox.Margin = new System.Windows.Forms.Padding(4);
            this.pathBox.Name = "pathBox";
            this.pathBox.ReadOnly = true;
            this.pathBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.pathBox.Size = new System.Drawing.Size(714, 23);
            this.pathBox.TabIndex = 10;
            this.pathBox.TextChanged += new System.EventHandler(this.pathBox_TextChanged);
            // 
            // textbox8
            // 
            this.textbox8.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textbox8.Location = new System.Drawing.Point(377, 257);
            this.textbox8.Margin = new System.Windows.Forms.Padding(4);
            this.textbox8.Name = "textbox8";
            this.textbox8.ReadOnly = true;
            this.textbox8.Size = new System.Drawing.Size(145, 23);
            this.textbox8.TabIndex = 12;
            this.textbox8.Text = "Symbols";
            this.textbox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // symbBox
            // 
            this.symbBox.BackColor = System.Drawing.SystemColors.Window;
            this.symbBox.Location = new System.Drawing.Point(377, 286);
            this.symbBox.Margin = new System.Windows.Forms.Padding(4);
            this.symbBox.Multiline = true;
            this.symbBox.Name = "symbBox";
            this.symbBox.ReadOnly = true;
            this.symbBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.symbBox.Size = new System.Drawing.Size(145, 165);
            this.symbBox.TabIndex = 11;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(530, 53);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(146, 23);
            this.textBox1.TabIndex = 14;
            this.textBox1.Text = "Keywords";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // keywordBox
            // 
            this.keywordBox.BackColor = System.Drawing.SystemColors.Window;
            this.keywordBox.Location = new System.Drawing.Point(530, 84);
            this.keywordBox.Margin = new System.Windows.Forms.Padding(4);
            this.keywordBox.Multiline = true;
            this.keywordBox.Name = "keywordBox";
            this.keywordBox.ReadOnly = true;
            this.keywordBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.keywordBox.Size = new System.Drawing.Size(146, 165);
            this.keywordBox.TabIndex = 13;
            // 
            // SyntaxTree
            // 
            this.SyntaxTree.Location = new System.Drawing.Point(861, 11);
            this.SyntaxTree.Name = "SyntaxTree";
            this.SyntaxTree.Size = new System.Drawing.Size(397, 612);
            this.SyntaxTree.TabIndex = 15;
            this.SyntaxTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.SyntaxTree_AfterSelect);
            // 
            // btnSynAn
            // 
            this.btnSynAn.Enabled = false;
            this.btnSynAn.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSynAn.Location = new System.Drawing.Point(289, 11);
            this.btnSynAn.Margin = new System.Windows.Forms.Padding(4);
            this.btnSynAn.Name = "btnSynAn";
            this.btnSynAn.Size = new System.Drawing.Size(233, 36);
            this.btnSynAn.TabIndex = 16;
            this.btnSynAn.Text = "Syntax Analysis";
            this.btnSynAn.UseVisualStyleBackColor = true;
            this.btnSynAn.Click += new System.EventHandler(this.btnSynAn_Click);
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox4.Location = new System.Drawing.Point(529, 257);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(325, 23);
            this.textBox4.TabIndex = 17;
            this.textBox4.Text = "Asm code";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // asmCodeBox
            // 
            this.asmCodeBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.asmCodeBox.Location = new System.Drawing.Point(530, 286);
            this.asmCodeBox.Multiline = true;
            this.asmCodeBox.Name = "asmCodeBox";
            this.asmCodeBox.ReadOnly = true;
            this.asmCodeBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.asmCodeBox.Size = new System.Drawing.Size(323, 164);
            this.asmCodeBox.TabIndex = 18;
            // 
            // CodeGenButton
            // 
            this.CodeGenButton.Enabled = false;
            this.CodeGenButton.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CodeGenButton.Location = new System.Drawing.Point(529, 11);
            this.CodeGenButton.Name = "CodeGenButton";
            this.CodeGenButton.Size = new System.Drawing.Size(324, 35);
            this.CodeGenButton.TabIndex = 19;
            this.CodeGenButton.Text = "Code Generation";
            this.CodeGenButton.UseVisualStyleBackColor = true;
            this.CodeGenButton.Click += new System.EventHandler(this.CodeGenButton_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1270, 635);
            this.Controls.Add(this.CodeGenButton);
            this.Controls.Add(this.asmCodeBox);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.btnSynAn);
            this.Controls.Add(this.SyntaxTree);
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
            this.Controls.Add(this.btnLexAn);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainWindow";
            this.Text = "Signal-translator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLexAn;
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
        private System.Windows.Forms.TreeView SyntaxTree;
        private System.Windows.Forms.Button btnSynAn;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox asmCodeBox;
        private System.Windows.Forms.Button CodeGenButton;
    }
}