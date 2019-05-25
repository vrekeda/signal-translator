using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SignalTranslator
{
    struct Token
    {
        public int tokenCode;
        public int row;
        public int col;
        public string tokenStr;
        public Token(int _tokenCode, int _row, int _col, string _str)
        {
            this.tokenCode = _tokenCode;
            this.row = _row;
            this.col = _col;
            this.tokenStr = _str;
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

    class LexicalAnalyser
    {
        private List<Token> tokens;
        private List<string> errors;

        private string pathToFile;

        private Dictionary<int, SymbType> symbols;
        private Dictionary<string, int> keywords;

        private Dictionary<string, int> dates;
        private Dictionary<string, int> identifiers;

        
        public LexicalAnalyser(string path)
        {
            tokens = new List<Token>();
            errors = new List<string>();
            identifiers = new Dictionary<string, int>();
            dates = new Dictionary<string, int>();
            symbols = new Dictionary<int, SymbType>();

            pathToFile = path;
            CreateStartTables();
        }

        public LexicalAnalyser()
        {
            tokens = new List<Token>();
            errors = new List<string>();
            identifiers = new Dictionary<string, int>();
            dates = new Dictionary<string, int>();
            symbols = new Dictionary<int, SymbType>();
            CreateStartTables();
        }

        public void SetPath(string path)
        {
            pathToFile = path;
        }

        public Dictionary<int, SymbType> GetSymbols() => symbols;

        public Dictionary<string, int> GetKeywords() => keywords;

        public Dictionary<string, int> GetDates() => dates;

        public string GetPathToFile() => pathToFile;

        public List<Token> GetTokens() => tokens;

        public Dictionary<string, int> GetIdentifiers() => identifiers;

        public List<string> GetErrors() => errors;

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
                        tokens.Add(new Token('(', row, col, "("));
                        col++;

                    }
                    canBeComment = false;
                }

                if (symbols.ContainsKey(curSymb) && (/*symbols[curSymb] == SymbType.dig ||*/ symbols[curSymb] == SymbType.let))
                {
                    ReadToken(reader, ref curSymb, ref row, ref col);
                }
                if (symbols.ContainsKey(curSymb))
                {
                    switch (symbols[curSymb])
                    {
                        case SymbType.dig:
                            //errors.Add("Forbidden symbol \"" + (char)curSymb + "\" at line " + row + " col " + col + ".");
                            ReadData(reader, ref curSymb, ref row, ref col);
                            col++;
                            break;
                        case SymbType.comParenth:
                            canBeComment = true;
                            break;
                        case SymbType.comAsterisk:
                            errors.Add("Forbidden symbol \"" + (char)curSymb + "\" at line " + row + " col " + col + ".");
                            col++;
                            break;
                        case SymbType.dm:
                            tokens.Add(new Token(curSymb, row, col, ((char)curSymb).ToString()));
                            col++;
                            break;
                        case SymbType.ws:
                            ProcessWhitespace(reader, curSymb, ref row, ref col);
                            break;
                    }
                }
                else if (curSymb != -1)
                {
                    errors.Add("Forbidden symbol \"" + (char)curSymb + "\" at line " + row + " col " + col + ".");
                }
            }
            reader.Close();

            //foreach (Token i in tokens)
            //{
            //    Console.Write($"{i.tokenCode} {i.row} {i.col}\n");
            //}
            //foreach (string i in errors)
            //{
            //    Console.WriteLine(i);
            //}
            //Console.WriteLine(tokens.Count());
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
            
            if (keywords.ContainsKey(buff.ToUpper()))
                tokens.Add(new Token(keywords[buff.ToUpper()], row, col, buff));
            else
            {
                if (identifiers.ContainsKey(buff))
                    tokens.Add(new Token(identifiers[buff], row, col, buff));
                else
                {
                    identifiers.Add(buff, 501 + identifiers.Count());
                    tokens.Add(new Token(identifiers[buff], row, col, buff));
                }
            }
            col += buff.Length;

            firstSymb = curSymb;
        }

        private void ReadData(StreamReader reader, ref int firstSymb, ref int row, ref int col)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append((char)firstSymb);
            string buff = null;
            bool dataOk = false;
            builder.Append(ReadDigits(reader, 1));
            if (builder[builder.Length - 1] == '/')
            {
                builder.Append(ReadDigits(reader, 2));
                if (builder[builder.Length - 1] == '/')
                {
                    builder.Append(ReadDigits(reader, 3));
                    if (builder.Length == 10 && symbols.ContainsKey(builder[builder.Length - 1]) && (symbols[builder[builder.Length - 1]] == SymbType.dig))
                    {
                        dataOk = true;
                    }
                }
            }


            if (dataOk)
            {
                buff = builder.ToString();
                if (dates.ContainsKey(buff))
                    tokens.Add(new Token(dates[buff], row, col, buff));
                else
                {
                    dates.Add(buff, 2001 + dates.Count());
                    tokens.Add(new Token(dates[buff], row, col, buff));
                }
                col += buff.Length;
            }

            else
            {
                errors.Add("Ivalid date: " + row + " " + col + ".");
                col += builder.Length;
            }

            //tokens.Add(new Token(identifiers[buff], row, col));

        }

        private string ReadDigits(StreamReader reader, int nmbOfDigits)
        {
            int curSymb = reader.Read();
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < nmbOfDigits; i++)
            {
                if (symbols.ContainsKey(curSymb) && symbols[curSymb] == SymbType.dig)
                    builder.Append((char)curSymb);
                curSymb = reader.Read();
            }
            builder.Append((char)curSymb);
            return builder.ToString();
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
                errors.Add("Comment was not clossed: " + row + " " + col + ".");
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

            symbols.Add('/', SymbType.dm);
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
                { "EXT", 410 },
                { "IF", 411 },
                { "THEN", 412 },
                { "ELSE", 413 },
                { "ENDIF", 414 }
            };
        }

        public void Clear()
        {
            this.errors.Clear();
            this.identifiers.Clear();
            this.tokens.Clear();
            this.dates.Clear();
        }

    }
}