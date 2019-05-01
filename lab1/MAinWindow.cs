using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace signalTranslator
{
    public partial class MainWindow : Form
    {
        LexicalAnalyser lexer;
        SyntaxAnalyser parser;

        public MainWindow()
        {
            lexer = new LexicalAnalyser();
            parser = new SyntaxAnalyser();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SyntaxTree.Nodes.Clear();
            btnSynAn.Enabled = false;
            parser.Clear();
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
            if (lexer.GetErrors().Count==0)
            {
                btnSynAn.Enabled = true;
            }
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
            Dictionary<string, int> tmpId = lexer.GetIdentifiers();
            Dictionary<string, int> tmpDates = lexer.GetDates();
            Dictionary<string, int> tmpKw = lexer.GetKeywords();

            foreach (Token token in lexer.GetTokens())
            {
                tokenBox.AppendText(String.Format("{0, -5} ({1, -2},{2, 3}) {3} ", token.tokenCode, token.row, token.col, token.tokenStr));
                tokenBox.AppendText(Environment.NewLine);
            }
        }

        private void FillErrorBox()
        {
            foreach (string err in lexer.GetErrors())
            {
                errorBox.AppendText(err);
                errorBox.AppendText(Environment.NewLine);
            }
            foreach (string err in parser.GetErrors())
            {
                errorBox.AppendText(err);
                errorBox.AppendText(Environment.NewLine);
            }
        }

        private void FillIdentifierBox()
        {
            Dictionary<string, int> tmp = lexer.GetIdentifiers();
            foreach (string str in tmp.Keys)
            {
                identBox.AppendText(tmp[str] + " " + str);
                identBox.AppendText(Environment.NewLine);
            }
            tmp = lexer.GetDates();
            //identBox.AppendText("Dates:");
            identBox.AppendText(Environment.NewLine);
            foreach (string str in tmp.Keys)
            {
                identBox.AppendText(tmp[str] + " " + str);
                identBox.AppendText(Environment.NewLine);
            }
        }

        private void FillSymbBox()
        {
            foreach (var i in lexer.GetSymbols().Where(pair => pair.Value == SymbType.dm || pair.Value == SymbType.comParenth))
            {
                symbBox.AppendText(String.Format("{0, -3} {1}", i.Key, (char)i.Key));
                symbBox.AppendText(Environment.NewLine);
            }
        }

        private void FillKeywordBox()
        {
            foreach (var i in lexer.GetKeywords())
            {
                keywordBox.AppendText(String.Format("{0, -4} {1}", i.Value, i.Key));
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
            btnLexAn.Enabled = true;
            lexer.SetPath(str);
            FillBoxWithCode(lexer.GetPathToFile());
            //folderBrowserDialog1.ShowDialog();
        }

        private void pathBox_TextChanged(object sender, EventArgs e)
        {
            // pathBox.DoDragDrop();
        }

        private void SyntaxTree_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void btnSynAn_Click(object sender, EventArgs e)
        {
            parser.Clear();
            errorBox.Clear();
            SyntaxTree.Nodes.Clear();
            parser.SetTables(lexer);
            parser.StarSyntaxisAnalysis(ref SyntaxTree);
            FillErrorBox();
            //SyntaxTree = parser.GetTree();
            SyntaxTree.ExpandAll();
        }
    }
}
