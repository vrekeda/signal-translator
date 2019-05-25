using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignalTranslator
{
    class CodeGenerator
    {
        SyntaxAnalyser syntaxAnalyser;
        public List<string> asmCode;
        private List<string> procNames;
        private List<string> varNames;
        public List<string> errors;
        public CodeGenerator()
        {
            errors = new List<string>();
            procNames = new List<string>();
            varNames = new List<string>();
            asmCode = new List<string>();
        }

        public void Clear()
        {
            asmCode.Clear();
            errors.Clear();
        }

        public CodeGenerator(SyntaxAnalyser syntaxAnalyser)
        {
            errors = new List<string>();
            procNames = new List<string>();
            varNames = new List<string>();
            asmCode = new List<string>();
            this.syntaxAnalyser = syntaxAnalyser;
        }

        public void SetSyntaxAnalyser(SyntaxAnalyser syntaxAnalyser)
        {
            asmCode = new List<string>();
            this.syntaxAnalyser = syntaxAnalyser;
        }

        public void StartCodeGeneration()
        {
            TraverseTree(syntaxAnalyser.GetTree().Nodes[0]);
            procNames.Clear();

        }

        private void TraverseTree(TreeNode curNode)
        {
            switch (curNode.Text)
            {
                case "<Procedure>":
                    TraverseProcedure(curNode);
                    return;
                default:
                    break;
            }
            foreach (TreeNode node in curNode.Nodes)
            {
                TraverseTree(node);
            }
        }

        private void TraverseProcedure(TreeNode curNode)
        {
            string curProcedureName = syntaxAnalyser.lexicalAnalyser.GetIdentifiers()
                .First(pair => pair.Value == Convert.ToInt32(curNode.Nodes[1].Nodes[0].Nodes[0].Text)).Key;
            if (!procNames.Contains(curProcedureName))
            {
                procNames.Add(curProcedureName);
            }
            else
            {
                errors.Add($"repeated procedure name {curProcedureName}");
                return;
            }
            asmCode.Add("@" + curProcedureName + " proc");
            asmCode.Add("\tpush ebp");
            asmCode.Add("\tmov ebp, esp");

            if (curNode.Nodes[2].Nodes[0].Text != "<Empty>")
            {
                TraverseDeclarations(curNode.Nodes[2].Nodes[1], 4);
                varNames.Clear();
            }

            asmCode.Add("\tpop ebp");
            asmCode.Add("\tret");
            asmCode.Add(curProcedureName + " endp");
            asmCode.Add("\n");

        }

        private void TraverseDeclarations(TreeNode curNode, int curOffset)
        {
            if (curNode.Nodes[0].Text == "<Empty>")
            {
                return;
            }

            int size = GetAttrSize(curNode.Nodes[0].Nodes[3]);
            string curVarName = syntaxAnalyser.lexicalAnalyser.GetIdentifiers()
                .First(pair => pair.Value == Convert.ToInt32(curNode.Nodes[0].Nodes[0].Nodes[0].Nodes[0].Text)).Key;
            if (!varNames.Contains(curVarName))
            {
                varNames.Add(curVarName);
            }
            else
            {
                errors.Add($"repeated parameter name {curVarName} in procedure {procNames.Last()}");
            }
            asmCode.Add($"\t@{curVarName} = {curOffset}");
            curOffset = TraverseIdntList(curNode.Nodes[0].Nodes[1], curOffset, size);
            TraverseDeclarations(curNode.Nodes[1], curOffset);
        }

        private int GetAttrSize(TreeNode curNode)
        {
            string curAttr = syntaxAnalyser.lexicalAnalyser.GetKeywords()
                .First(pair => pair.Value == Convert.ToInt32(curNode.Nodes[0].Text.ToUpper())).Key;
            return 4;
        }

        private int TraverseIdntList(TreeNode curNode, int curOffset, int size)
        {
            if (curNode.Nodes[0].Text == "<Empty>")
            {
                return curOffset + size;
            }

            string curVarName = syntaxAnalyser.lexicalAnalyser.GetIdentifiers()
                .First(pair => pair.Value == Convert.ToInt32(curNode.Nodes[1].Nodes[0].Nodes[0].Text)).Key;
            if (!varNames.Contains(curVarName))
            {
                varNames.Add(curVarName);
            }
            else
            {
                errors.Add($"repeated parameter name {curVarName} in procedure {procNames.Last()}");
            }
            curOffset = curOffset + size;
            asmCode.Add($"\t@{curVarName} = {curOffset}");
            return TraverseIdntList(curNode.Nodes[2], curOffset, size);
        }
    }
}
