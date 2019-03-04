﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace lab1
{
    struct Token
    {
        public int tokenCode;
        public int row;
        public int col;
        public Token(int _tokenCode, int _row, int _col)
        {
            this.tokenCode = _tokenCode;
            this.row = _row;
            this.col = _col;
        }
    }

    enum SymbType
    {
        dig,
        let,
        comParenth,
        comAsterisk,
        dm,
        ws
    };

    class Lexer
    {
        private List<Token> tokens;
        private List<string> errors;

        private string pathToFile;

        private Dictionary<int, SymbType> symbols;
        private Dictionary<string, int> keywords;

        private Dictionary<string, int> identifiers;

        public Lexer(string path)
        {
            tokens = new List<Token>();
            errors = new List<string>();
            identifiers = new Dictionary<string, int>();
            symbols = new Dictionary<int, SymbType>();

            pathToFile = path;
            CreateStartTables();
        }

        public Lexer()
        {
            tokens = new List<Token>();
            errors = new List<string>();
            identifiers = new Dictionary<string, int>();
            symbols = new Dictionary<int, SymbType>();
            CreateStartTables();
        }

        public void SetPath(string path)
        {
            pathToFile = path;
        }

        public Dictionary<int, SymbType> GetSymbols()
        {
            return symbols;
        }

        public Dictionary<string, int> GetKeywords()
        {
            return keywords;
        }

        public string GetPathToFile()
        {
            return pathToFile;
        }

        public List<Token> GetTokens()
        {
            return tokens;
        }

        public Dictionary<string, int> getIdentifiers()
        {
            return identifiers;
        }

        public List<string> getErrors()
        {
            return errors;
        }

        public void ReadFile()
        {
            int curSymb;
            int row = 1, col = 1;
            StreamReader reader;
            try
            {
                reader = new StreamReader(pathToFile);
            }
            catch (Exception ex)
            {
                Console.Write($"File not found\n{ex.Message}");
                return;
            }

            bool canBeComment = false;

            while ((curSymb = reader.Read()) != -1)
            {
                if (canBeComment)
                {
                    if (curSymb == '*')
                    {
                        col += 2;
                        ProcessComment(reader, ref row, ref col);
                        canBeComment = false;
                        continue;
                    }
                    else
                    {
                        tokens.Add(new Token('(', row, col));
                        col++;

                    }
                    canBeComment = false;
                }

                if (symbols.ContainsKey(curSymb) && (symbols[curSymb] == SymbType.dig || symbols[curSymb] == SymbType.let))
                {
                    ReadToken(reader, ref curSymb, ref row, ref col);
                }
                if (symbols.ContainsKey(curSymb))
                {
                    switch (symbols[curSymb])
                    {
                        case SymbType.comParenth:
                            canBeComment = true;
                            break;
                        case SymbType.comAsterisk:
                            errors.Add("Forbidden symbol at line " + row + " col " + col + ".");
                            col++;
                            break;
                        case SymbType.dm:
                            tokens.Add(new Token(curSymb, row, col));
                            col++;
                            break;
                        case SymbType.ws:
                            ProcessWhitespace(reader, curSymb, ref row, ref col);
                            break;
                    }
                }
                else
                {
                    errors.Add("Forbidden symbol at line " + row + " col " + col + ".");
                }
            }
            reader.Close();

            foreach (Token i in tokens)
            {
                Console.Write($"{i.tokenCode} {i.row} {i.col}\n");
            }
            foreach (string i in errors)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine(tokens.Count());
        }

        private void ReadToken(StreamReader reader, ref int firstSymb, ref int row, ref int col)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append((char)firstSymb);
            string buff = null;
            int curSymb = reader.Read();
            while (symbols.ContainsKey(curSymb) && (symbols[curSymb] == SymbType.let || symbols[curSymb] == SymbType.dig))
            {
                builder.Append((char)curSymb);
                curSymb = reader.Read();
            }

            buff = builder.ToString();

            if (symbols[firstSymb] == SymbType.dig)
            {
                errors.Add("Identifier can't begin with digit at line " + row + " column " + col + ".");
            }
            else
            {
                if (keywords.ContainsKey(buff.ToUpper()))
                    tokens.Add(new Token(keywords[buff.ToUpper()], row, col));
                else
                {
                    if (identifiers.ContainsKey(buff))
                        tokens.Add(new Token(identifiers[buff], row, col));
                    else
                    {
                        identifiers.Add(buff, 501 + identifiers.Count());
                        tokens.Add(new Token(identifiers[buff], row, col));
                    }
                }
            }
            col += buff.Length;

            firstSymb = curSymb;
        }

        private void ProcessComment(StreamReader reader, ref int row, ref int col)
        {
            int curSymb;
            bool CommentEnds = false, CommentOk = false; ;

            while ((curSymb = reader.Read()) != -1)
            {
                col++;
                if (CommentEnds && curSymb == ')')
                {
                    CommentOk = true;
                    break;
                }
                else
                {
                    CommentEnds = false;
                }
                if (curSymb == '*')
                {
                    CommentEnds = true;
                }
                if (curSymb == 10)
                {
                    row++;
                    col = 1;
                }
            }

            if (!CommentOk)
                errors.Add("Comment was not clossed.");
        }

        private void ProcessWhitespace(StreamReader reader, int curWs, ref int row, ref int col)
        {
            if (curWs == 10)
            {
                row++;
                col = 1;
            }
            else
            {
                col++;
            }
        }

        private void CreateStartTables()
        {
            for (int i = 48; i <= 57; i++)
                symbols.Add(i, SymbType.dig); //digits

            for (int i = 65; i <= 90; i++)
                symbols.Add(i, SymbType.let);
            for (int i = 97; i <= 122; i++)
                symbols.Add(i, SymbType.let); //letters

            for (int i = 8; i <= 13; i++)
                symbols.Add(i, SymbType.ws);
            symbols.Add(32, SymbType.ws);  //whitespaces

            symbols.Add(';', SymbType.dm);
            symbols.Add(':', SymbType.dm);
            symbols.Add(',', SymbType.dm);
            symbols.Add(')', SymbType.dm); //delimeteres

            symbols.Add('(', SymbType.comParenth);
            symbols.Add('*', SymbType.comAsterisk);

            keywords = new Dictionary<string, int>
            {
                { "PROGRAM", 401 },
                { "BEGIN", 402 },
                { "END", 403 },
                { "PROCEDURE", 404 },
                { "SIGNAL", 405 },
                { "COMPLEX", 406 },
                { "INTEGER", 407 },
                { "FLOAT", 408 },
                { "BLOCKFLOAT", 409 },
                { "EXT", 410 }
            };
        }

        public void Clear()
        {
            this.errors.Clear();
            this.identifiers.Clear();
            this.tokens.Clear();
        }

    }
}
