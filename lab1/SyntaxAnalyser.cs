using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;

namespace signalTranslator
{
    class SyntaxAnalyser
    {
        private List<Token> tokens;
        private List<string> syntaxErrors;
        private TreeView syntaxTree;

        public TreeView GetTree() => syntaxTree;

        public void Clear()
        {
            //syntaxTree.Nodes.Clear();
        }

        public SyntaxAnalyser()
        {
            //syntaxTree = new TreeView();
            syntaxErrors = new List<string>();
        }
        public SyntaxAnalyser(LexicalAnalyser lexer)
        {
            //syntaxTree = new TreeView();
            tokens = lexer.GetTokens().ToList();
            syntaxErrors = new List<string>();
        }

        public void SetTables(LexicalAnalyser lexer)
        {
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

            if (tokens.Count != 0 && tokens[0].tokenStr.ToUpper() == "PROGRAM")
            {
                curNode.Nodes.Add(tokens[0].tokenStr);
                tokens.RemoveAt(0);
            }
            ProcedureIdnt(curNode);
            if (tokens.Count != 0 && tokens[0].tokenStr == ";")
            {
                curNode.Nodes.Add(tokens[0].tokenStr);
                tokens.RemoveAt(0);
            }
            Block(curNode);
            if (tokens.Count != 0 && tokens[0].tokenStr == ";")
            {
                curNode.Nodes.Add(tokens[0].tokenStr);
                tokens.RemoveAt(0);
            }
        }

        private void Block(TreeNode parNode)
        {
            TreeNode curNode = parNode.Nodes.Add("<Block>");
            Declarations(curNode);
            if (tokens.Count != 0 && tokens[0].tokenStr.ToUpper() == "BEGIN")
            {
                curNode.Nodes.Add(tokens[0].tokenStr);
                tokens.RemoveAt(0);
            }
            StmtLst(curNode);
            if (tokens.Count != 0 && tokens[0].tokenStr.ToUpper() == "END")
            {
                curNode.Nodes.Add(tokens[0].tokenStr);
                tokens.RemoveAt(0);
            }
        }

        private void StmtLst(TreeNode parNode)
        {
            parNode.Nodes.Add("<Statement List>");
        }

        private void Declarations(TreeNode parNode)
        {
            TreeNode curNode = parNode.Nodes.Add("<Declarations>");
            ProcedureDeclarations(curNode);
        }

        private void ProcedureDeclarations(TreeNode parNode)
        {
            TreeNode curNode = parNode.Nodes.Add("<Procedure declarations>");
            while (tokens.Count != 0 && tokens[0].tokenStr.ToUpper() == "PROCEDURE")
            {
                Procedure(curNode);
            }
        }
        private void Procedure(TreeNode parNode)
        {
            TreeNode curNode = parNode.Nodes.Add("<Procedure>");
            if (tokens.Count != 0 && tokens[0].tokenStr.ToUpper() == "PROCEDURE")
            {
                curNode.Nodes.Add(tokens[0].tokenStr);
                tokens.RemoveAt(0);
            }
            ProcedureIdnt(curNode);
            ParametersLst(curNode);
            if (tokens.Count != 0 && tokens[0].tokenStr == ";")
            {
                curNode.Nodes.Add(tokens[0].tokenStr);
                tokens.RemoveAt(0);
            }
        }

        private void ParametersLst(TreeNode parNode)
        {
            TreeNode curNode = parNode.Nodes.Add("<Parameters list>");
            if (tokens.Count != 0 && tokens[0].tokenStr == "(")
            {
                curNode.Nodes.Add(tokens[0].tokenStr);
                tokens.RemoveAt(0);
            }
            DeclarationsLst(curNode);
            if (tokens.Count != 0 && tokens[0].tokenStr == ")")
            {
                curNode.Nodes.Add(tokens[0].tokenStr);
                tokens.RemoveAt(0);
            }
        }

        private void DeclarationsLst(TreeNode parNode)
        {
            TreeNode curNode = parNode.Nodes.Add("<Declarations list>");
            while (tokens.Count != 0 && tokens[0].tokenCode > 500 && tokens[0].tokenCode <= 600)
            {
                Declaration(curNode);
            }
        }

        private void Declaration(TreeNode parNode)
        {
            TreeNode curNode = parNode.Nodes.Add("<Declaration>");
            VariableIdnt(curNode);
            IdentifiersLst(curNode);
            if (tokens.Count != 0 && tokens[0].tokenStr == ":")
            {
                curNode.Nodes.Add(tokens[0].tokenStr);
                tokens.RemoveAt(0);
            }
            Attribute(curNode);
            AttributesLst(curNode);
            if (tokens.Count != 0 && tokens[0].tokenStr == ";")
            {
                curNode.Nodes.Add(tokens[0].tokenStr);
                tokens.RemoveAt(0);
            }
        }

        private void IdentifiersLst(TreeNode parNode)
        {
            TreeNode curNode = parNode.Nodes.Add("<Identifiers list>");
            while (tokens.Count != 0 && tokens[0].tokenCode == ',')
            {
                curNode.Nodes.Add(tokens[0].tokenStr);
                tokens.RemoveAt(0);
                VariableIdnt(curNode);
            }
        }

        private void AttributesLst(TreeNode parNode)
        {
            TreeNode curNode = parNode.Nodes.Add("<Attributes list>");
            while (Attribute(curNode)) { }
        }

        private bool Attribute(TreeNode parNode)
        {
            TreeNode curNode = parNode.Nodes.Add("<Attribute>");
            if (tokens.Count != 0 && tokens[0].tokenCode >= 405 && tokens[0].tokenCode <= 410)
            {
                curNode.Nodes.Add(tokens[0].tokenStr);
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
            TreeNode curNode = parNode.Nodes.Add("<Identifier>");
            if (tokens.Count != 0 && tokens[0].tokenCode > 500 && tokens[0].tokenCode <= 600)
            {
                curNode.Nodes.Add(tokens[0].tokenStr);
                tokens.RemoveAt(0);
            }
        }
    }
}
