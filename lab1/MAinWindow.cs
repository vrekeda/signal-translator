﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace lab1
{
    public partial class MainWindow : Form
    {
        Lexer lexer;

        public MainWindow()
        {
            lexer = new Lexer();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lexer.Clear();
            RefreshFile();
            codeBox.Clear();
            errorBox.Clear();
            identBox.Clear();
            tokenBox.Clear();
            symbBox.Clear();
            keywordBox.Clear();
            FillBoxWithCode(lexer.GetPathToFile());
            lexer.ReadFile();
            FillErrorBox();
            FillSymbBox();
            FillKeywordBox();
            FillIdentifierBox();
            FillTokensBox();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void FillBoxWithCode(string path)
        {
            string tmp;
            StreamReader reader;
            try
            {
                reader = new StreamReader(path);
            }
            catch (Exception ex)
            {
                Console.Write($"File not found\n{ex.Message}");
                return;
            }
            while ((tmp = reader.ReadLine()) != null)
            {
                codeBox.AppendText(tmp);
                codeBox.AppendText(Environment.NewLine);
            }
            reader.Close();
        }

        private void FillTokensBox()
        {
            foreach (Token token in lexer.GetTokens())
            {
                tokenBox.AppendText(token.tokenCode + " (" + token.row + ", " + token.col+")");
                tokenBox.AppendText(Environment.NewLine);
            }
        }

        private void FillErrorBox()
        {
            foreach (string str in lexer.getErrors())
            {
                errorBox.AppendText(str);
                errorBox.AppendText(Environment.NewLine);
            }
        }

        private void FillIdentifierBox()
        {
            Dictionary<string, int> tmp = lexer.getIdentifiers();
            foreach (string str in tmp.Keys)
            {
                identBox.AppendText(tmp[str] + " " + str);
                identBox.AppendText(Environment.NewLine);
            }
        }

        private void FillSymbBox()
        {
            foreach (var i in lexer.GetSymbols().Where(pair => pair.Value == SymbType.dm  || pair.Value==SymbType.comParenth))
            {
                symbBox.AppendText(i.Key + " " + (char)i.Key );
                symbBox.AppendText(Environment.NewLine);
            }
        }

        private void FillKeywordBox()
        {
            foreach (var i in lexer.GetKeywords())
            {
                keywordBox.AppendText(i.Value + " " + i.Key);
                keywordBox.AppendText(Environment.NewLine);
            }
        }

        private void RefreshFile()
        {
            StreamWriter writer = new StreamWriter(lexer.GetPathToFile());
            writer.Write(codeBox.Text);
            writer.Close();
        }

        private void identBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void openBtn_Click_1(object sender, EventArgs e)
        {
            string str;
            codeBox.Clear();
            errorBox.Clear();
            identBox.Clear();
            tokenBox.Clear();
            symbBox.Clear();
            keywordBox.Clear();
            lexer.Clear();
            openFileDialog1.ShowDialog();
            str = openFileDialog1.FileName;
            pathBox.Text = str;
            startBtn.Enabled = true;
            lexer.SetPath(str);
            FillBoxWithCode(lexer.GetPathToFile());
            //folderBrowserDialog1.ShowDialog();
        }

        private void pathBox_TextChanged(object sender, EventArgs e)
        {
           // pathBox.DoDragDrop();
        }
    }
}