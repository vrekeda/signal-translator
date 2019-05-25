using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;

namespace SignalTranslator
{
    class SyntaxAnalyser
    {
        public LexicalAnalyser lexicalAnalyser;
        private List<Token> tokens;
        private List<string> syntaxErrors;
        private TreeView syntaxTree;
        private int curLine;
        public TreeView GetTree() => syntaxTree;
        public List<string> GetErrors() => syntaxErrors;

        public void Clear()
        {
            syntaxErrors.Clear();
        }

        public SyntaxAnalyser()
        {
            //syntaxTree = new TreeView();
            syntaxErrors = new List<string>();
            curLine = 1;
        }
        public SyntaxAnalyser(LexicalAnalyser lexer)
        {
            lexicalAnalyser = lexer;
            //syntaxTree = new TreeView();
            tokens = lexer.GetTokens().ToList();
            syntaxErrors = new List<string>();
            curLine = 1;
        }

        public void SetTables(LexicalAnalyser lexer)
        {
            lexicalAnalyser = lexer;
            tokens = lexer.GetTokens().ToList();
        }

        public void StarSyntaxisAnalysis(ref TreeView tree)
        {
            syntaxTree = tree;
            SignalProgram();
        }

        private void SignalProgram()
        {
            TreeNode curNode = syntaxTree.Nodes.Add("<Signal Program>");
            Program(curNode);
        }

        private void Program(TreeNode parNode)
        {
            TreeNode curNode = parNode.Nodes.Add("<PROGRAM>");
            if (tokens.Count != 0)
            {
                curLine = tokens[0].row;
            }
            if (tokens.Count != 0 && tokens[0].tokenStr.ToUpper() == "PROGRAM")
            {
                curNode.Nodes.Add(tokens[0].tokenCode.ToString());
                tokens.RemoveAt(0);
            }
            else
            {
                syntaxErrors.Add($"Expected 'Program' at line: {curLine}");
            }
            ProcedureIdnt(curNode);
            if (tokens.Count != 0)
            {
                curLine = tokens[0].row;
            }
            if (tokens.Count != 0 && tokens[0].tokenStr == ";")
            {
                curNode.Nodes.Add(tokens[0].tokenCode.ToString());
                tokens.RemoveAt(0);
            }
            else
            {
                syntaxErrors.Add($"Expected ';' at line: {curLine}");
            }
            Block(curNode);
            if (tokens.Count != 0)
            {
                curLine = tokens[0].row;
            }
            if (tokens.Count != 0 && tokens[0].tokenStr == ";")
            {
                curNode.Nodes.Add(tokens[0].tokenCode.ToString());
                tokens.RemoveAt(0);
            }
            else
            {
                syntaxErrors.Add($"Expected ';' at line: {curLine}");
            }
        }

        private void Block(TreeNode parNode)
        {
            if (tokens.Count != 0)
            {
                curLine = tokens[0].row;
            }
            TreeNode curNode = parNode.Nodes.Add("<Block>");
            Declarations(curNode);
            if (tokens.Count != 0)
            {
                curLine = tokens[0].row;
            }
            if (tokens.Count != 0 && tokens[0].tokenStr.ToUpper() == "BEGIN")
            {
                curNode.Nodes.Add(tokens[0].tokenCode.ToString());
                tokens.RemoveAt(0);
            }
            else
            {
                syntaxErrors.Add($"Expected 'BEGIN' at line: {curLine}");
            }
            StmtLst(curNode);
            if (tokens.Count != 0)
            {
                curLine = tokens[0].row;
            }
            if (tokens.Count != 0 && tokens[0].tokenStr.ToUpper() == "END")
            {
                curNode.Nodes.Add(tokens[0].tokenCode.ToString());
                tokens.RemoveAt(0);
            }
            else
            {
                syntaxErrors.Add($"Expected 'END' at line: {curLine}");
            }
        }

        private void StmtLst(TreeNode parNode)
        {
            TreeNode curNode = parNode.Nodes.Add("<Statement List>");
            bool isEmpty = true;
            if (tokens.Count != 0 && tokens[0].tokenStr.ToUpper() == "IF")
            {
                ifStmt(curNode);
                isEmpty = false;
            }
            if (isEmpty)
            {
                curNode.Nodes.Add("<Empty>");
                return;
            }
            StmtLst(curNode);
        }

        private void Declarations(TreeNode parNode)
        {
            TreeNode curNode = parNode.Nodes.Add("<Declarations>");
            ProcedureDeclarations(curNode);
        }

        private void ProcedureDeclarations(TreeNode parNode)
        {
            TreeNode curNode = parNode.Nodes.Add("<Procedure declarations>");
            bool isEmpty = true;
            if (tokens.Count != 0 && tokens[0].tokenStr.ToUpper() == "PROCEDURE")
            {
                Procedure(curNode);
                isEmpty = false;
            }
            if (isEmpty)
            {
                curNode.Nodes.Add("<Empty>");
                return;
            }
            ProcedureDeclarations(curNode);
        }
        private void Procedure(TreeNode parNode)
        {
            if (tokens.Count != 0)
            {
                curLine = tokens[0].row;
            }
            TreeNode curNode = parNode.Nodes.Add("<Procedure>");
            if (tokens.Count != 0 && tokens[0].tokenStr.ToUpper() == "PROCEDURE")
            {
                curNode.Nodes.Add(tokens[0].tokenCode.ToString());
                tokens.RemoveAt(0);
            }
            else
            {
                syntaxErrors.Add($"Expected 'PROCEDURE' at line: {curLine}");
            }
            ProcedureIdnt(curNode);
            ParametersLst(curNode);
            if (tokens.Count != 0 && tokens[0].tokenStr == ";")
            {
                curLine = tokens[0].row;
                curNode.Nodes.Add(tokens[0].tokenCode.ToString());
                tokens.RemoveAt(0);
            }
            else
            {
                syntaxErrors.Add($"Expected ';' at line: {curLine}");
            }
        }

        private void ParametersLst(TreeNode parNode)
        {
            if (tokens.Count != 0)
            {
                curLine = tokens[0].row;
            }
            TreeNode curNode = parNode.Nodes.Add("<Parameters list>");
            if (tokens.Count != 0 && tokens[0].tokenStr == "(")
            {
                curNode.Nodes.Add(tokens[0].tokenCode.ToString());
                tokens.RemoveAt(0);
            }
            else
            {
                curNode.Nodes.Add("<Empty>");
                return;
            }
            DeclarationsLst(curNode);
            if (tokens.Count != 0 && tokens[0].tokenStr == ")")
            {
                curLine = tokens[0].row;
                curNode.Nodes.Add(tokens[0].tokenCode.ToString());
                tokens.RemoveAt(0);
            }
            else
            {
                syntaxErrors.Add($"Expected ')' at line: {curLine}");
            }
        }

        private void DeclarationsLst(TreeNode parNode)
        {
            TreeNode curNode = parNode.Nodes.Add("<Declarations list>");
            bool isEmpty = true;
            if (tokens.Count != 0 && tokens[0].tokenCode > 500 && tokens[0].tokenCode <= 600)
            {
                Declaration(curNode);
                isEmpty = false;
            }
            if (isEmpty)
            {
                curNode.Nodes.Add("<Empty>");
                return;
            }
            DeclarationsLst(curNode);
        }

        private void Declaration(TreeNode parNode)
        {
            if (tokens.Count != 0)
            {
                curLine = tokens[0].row;
            }
            TreeNode curNode = parNode.Nodes.Add("<Declaration>");
            VariableIdnt(curNode);
            IdentifiersLst(curNode);
            if (tokens.Count != 0 && tokens[0].tokenStr == ":")
            {
                curLine = tokens[0].row;
                curNode.Nodes.Add(tokens[0].tokenCode.ToString());
                tokens.RemoveAt(0);
            }
            else
            {
                syntaxErrors.Add($"Expected ':' at line: {curLine}");
            }
            Attribute(curNode);
            AttributesLst(curNode);
            if (tokens.Count != 0 && tokens[0].tokenStr == ";")
            {
                curLine = tokens[0].row;
                curNode.Nodes.Add(tokens[0].tokenCode.ToString());
                tokens.RemoveAt(0);
            }
            else
            {
                syntaxErrors.Add($"Expected ';' at line: {curLine}");
            }
        }

        private void IdentifiersLst(TreeNode parNode)
        {
            TreeNode curNode = parNode.Nodes.Add("<Identifiers list>");
            bool isEmpty = true;
            if (tokens.Count != 0 && tokens[0].tokenCode == ',')
            {
                curLine = tokens[0].row;
                curNode.Nodes.Add(tokens[0].tokenCode.ToString());
                tokens.RemoveAt(0);
                VariableIdnt(curNode);
                isEmpty = false;
            }
            if (isEmpty)
            {
                curNode.Nodes.Add("<Empty>");
                return;
            }
            IdentifiersLst(curNode);
        }

        private void AttributesLst(TreeNode parNode)
        {
            TreeNode curNode = parNode.Nodes.Add("<Attributes list>");
            bool isEmpty = true;
            if (Attribute(curNode)) { isEmpty = false; }
            if (isEmpty)
            {
                curNode.Nodes.Add("<Empty>");
                return;
            }
            AttributesLst(curNode);
        }

        private bool Attribute(TreeNode parNode)
        {
            if (tokens.Count != 0)
            {
                curLine = tokens[0].row;
            }
            if (tokens.Count != 0 && tokens[0].tokenCode >= 405 && tokens[0].tokenCode <= 410)
            {
                TreeNode curNode = parNode.Nodes.Add("<Attribute>");
                curNode.Nodes.Add(tokens[0].tokenCode.ToString());
                tokens.RemoveAt(0);
                return true;
            }
            return false;
        }

        private void VariableIdnt(TreeNode parNode)
        {
            TreeNode curNode = parNode.Nodes.Add("<Variable identifier>");
            Identfier(curNode);
        }

        private void ProcedureIdnt(TreeNode parNode)
        {
            TreeNode curNode = parNode.Nodes.Add("<Procedure identifier>");
            Identfier(curNode);
        }

        private void Identfier(TreeNode parNode)
        {
            if (tokens.Count != 0)
            {
                curLine = tokens[0].row;
            }
            TreeNode curNode = parNode.Nodes.Add("<Identifier>");
            if (tokens.Count != 0 && tokens[0].tokenCode > 500 && tokens[0].tokenCode <= 600)
            {
                curNode.Nodes.Add(tokens[0].tokenCode.ToString());
                tokens.RemoveAt(0);
            }
            else
            {
                syntaxErrors.Add($"Expected identifier at line: {curLine}");
            }
        }

        private void ifStmt(TreeNode parNode)
        {
            TreeNode curNode = parNode.Nodes.Add("<if-stmt>");
            if (tokens.Count != 0 && tokens[0].tokenStr.ToUpper()=="IF")
            {
                curLine = tokens[0].row;
                curNode.Nodes.Add(tokens[0].tokenCode.ToString());
                tokens.RemoveAt(0);
            }
            VariableIdnt(curNode);
            if (tokens.Count != 0 && tokens[0].tokenStr.ToUpper() == "THEN")
            {
                curLine = tokens[0].row;
                curNode.Nodes.Add(tokens[0].tokenCode.ToString());
                tokens.RemoveAt(0);
            }
            else
            {
                syntaxErrors.Add($"Expected 'THEN' at line: {curLine}");
            }
            StmtLst(curNode);
            ifTail(curNode);
        }

        private void ifTail(TreeNode parNode)
        {
            TreeNode curNode = parNode.Nodes.Add("<if-tail>");
            if (tokens.Count != 0 && tokens[0].tokenStr.ToUpper() == "ENDIF")
            {
                curLine = tokens[0].row;
                curNode.Nodes.Add(tokens[0].tokenCode.ToString());
                tokens.RemoveAt(0);
                return;
            }
            if (tokens.Count != 0 && tokens[0].tokenStr.ToUpper() == "ELSE")
            {
                curLine = tokens[0].row;
                curNode.Nodes.Add(tokens[0].tokenCode.ToString());
                tokens.RemoveAt(0);
            }
            StmtLst(curNode);
            if (tokens.Count != 0 && tokens[0].tokenStr.ToUpper() == "ENDIF")
            {
                curLine = tokens[0].row;
                curNode.Nodes.Add(tokens[0].tokenCode.ToString());
                tokens.RemoveAt(0);
            }
            else
            {
                syntaxErrors.Add($"Expected 'ENDIF' at line: {curLine}");
            }
        }
    }
}
