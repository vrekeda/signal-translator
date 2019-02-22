using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace lab1
{
    struct Token
    {
        public int TokenCode;
        public int row;
        public int col;
        public Token(int _TokenCode, int _row, int _col)
        {
            this.TokenCode = _TokenCode;
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
        private List<Token> Tokens;

        private string pathToFile;
        private Dictionary<int, SymbType> symbols;
        private Dictionary<string, int> keywords;
        private Dictionary<string, int> identifiers;
        private Dictionary<string, int> constants;

        public Lexer(string path)
        {
            Tokens = new List<Token>();
            identifiers = new Dictionary<string, int>();
            constants = new Dictionary<string, int>();
            pathToFile = path;
            CreateStartTables();
        }

        public void ReadFromFile()
        {
            int tmp;
            int row = 1, col = 1;
            StreamReader reader;
            try
            {
                reader = new StreamReader(pathToFile);
            }
            catch (Exception ex)
            {
                Console.Write($"Даруйте, такого файлу нема...\n{ex.Message}");
                return;
            }

            bool canBeComment = false, isComment = false, CommentEnds = false;
            SymbType sbType;
            while ((tmp = reader.Read()) != -1)
            {
                if (canBeComment)
                {
                    if (tmp == '*')
                        isComment = true;
                    else
                        Tokens.Add(new Token('(', row, col));
                    canBeComment = false;
                }
                if (isComment)
                {
                    if (tmp == '*')
                        CommentEnds = true;
                    else if (CommentEnds)
                    {
                        if (tmp == ')')
                            isComment = false;
                        CommentEnds = false;
                    }
                    if (tmp == 10)
                    {
                        col = 1;
                        row++;
                    }
                    else
                        col++;
                    continue;
                }

                if (symbols.ContainsKey(tmp))
                {
                    sbType = symbols[tmp];
                    switch (sbType)
                    {
                        case SymbType.dig:
                            ReadToken(reader, ref tmp, ref row, ref col);
                            break;
                        case SymbType.let:
                            ReadToken(reader, ref tmp, ref row, ref col);
                            break;
                        case SymbType.comParenth:
                            canBeComment = true;
                            col++;
                            break;
                        case SymbType.dm:
                            Tokens.Add(new Token(tmp, row, col));
                            break;
                        case SymbType.ws:
                            if (tmp == 10)
                            {
                                row++;
                                col = 1;
                            }
                            else
                                col++;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    ;//add error
                }
                if (tmp == -1)
                    break;
            }
            reader.Close();
            if (isComment)
                Console.WriteLine("Fuck, unexpected end of file!");
            foreach (Token i in Tokens)
            {
                Console.Write($"{i.TokenCode} {i.row} {i.col}\n");
            }
            Console.WriteLine(Tokens.Count());
        }

        private void ReadToken(StreamReader reader, ref int firstSymb, ref int row, ref int col)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append((char)firstSymb);
            string buff = null;
            int tmp = reader.Read();
            while (symbols.ContainsKey(tmp) && (symbols[tmp] == SymbType.let || symbols[tmp] == SymbType.dig))
            {
                builder.Append((char)tmp);
                tmp = reader.Read();
            }

            buff = builder.ToString();
            //Console.Write($"{buff}\n");

            if (symbols[firstSymb] == SymbType.dig)
            {
                if (constants.ContainsKey(buff))
                    Tokens.Add(new Token(constants[buff], row, col));
                else
                {
                    constants.Add(buff, 1001 + constants.Count());
                    Tokens.Add(new Token(constants[buff], row, col));
                }
            }
            else
            {
                if (keywords.ContainsKey(buff.ToUpper()))
                    Tokens.Add(new Token(keywords[buff.ToUpper()], row, col));
                else
                {
                    if (identifiers.ContainsKey(buff))
                        Tokens.Add(new Token(identifiers[buff], row, col));
                    else
                    {
                        identifiers.Add(buff, 501 + identifiers.Count());
                        Tokens.Add(new Token(identifiers[buff], row, col));
                    }
                }
            }
            col += buff.Length;
            if (symbols.ContainsKey(tmp) && symbols[tmp] == SymbType.dm)
                Tokens.Add(new Token(tmp, row, col));
            else if (!symbols.ContainsKey(tmp))
            {
                ;//add error
            }
            else if (tmp == 10)
            {
                row++;
                col = 1;
            }
            firstSymb = tmp;
            // Console.Write($"{buff}\n");
        }

        private void CreateStartTables()
        {
            symbols = new Dictionary<int, SymbType>();
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

            //foreach (int i in symbols.Keys)
            //    Console.WriteLine($"{(char)i} {symbols[i].ToString() }");

            //foreach (string i in keywords.Keys)
            //    Console.WriteLine($"{i} {keywords[i] }");
        }
    }
}
