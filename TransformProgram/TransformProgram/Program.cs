using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransformProgram
{
    class Program
    {
        public static string PascalCase(string input)
        {
            if (input.Equals(""))
            {
                return input;
            }

            bool prevCharSeparador = false;
            char[] characters = input.ToCharArray();


            if (input[0] == ' ')
            {
                prevCharSeparador = true;
            }
            else
            {
                characters[0] = Char.ToUpper(characters[0]);
            }

            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] == ' ')
                {
                    prevCharSeparador = true;
                }
                else if (prevCharSeparador)
                {
                    characters[i] = Char.ToUpper(characters[i]);
                    prevCharSeparador = false;
                }
                else
                {
                    characters[i] = Char.ToLower(characters[i]);
                    prevCharSeparador = false;
                }


            }
            string ret = new string(characters);

            return ret;
        }
        public static string FirstLetterToUpper(string word)
        {
            if (word.Equals(""))
            {
                return word;
            }
            return char.ToUpper(word[0]) + word.Substring(1);
        }
        public static string FirstLetterToLower(string word)
        {
            if (word.Equals(""))
            {
                return word;
            }
            return char.ToLower(word[0]) + word.Substring(1);
        }

        public static string CamelCase(string input)
        {
            var ret = string.Join("", input.Split(' ').Select(w => FirstLetterToUpper(w)));
            return FirstLetterToLower(ret);
        }

        public static string LowerCase(string input)
        {
            return input.ToLower();
        }

        public static string UpperCase(string input)
        {
            return input.ToUpper();
        }

        public static string SnakeCase(string input)
        {
            var ret = Trim(input);

            if (!ret[0].Equals(' ') && !ret[ret.Length-1].Equals(' '))
            {
                return ret.Replace(" ", "_");
            }
            return ret;
        }

        public static string Pack(string input)
        {
            return null;
        }

        public static string LTrim(string input)
        {
            return input.TrimStart();
        }

        public static string RTrim(string input)
        {
            return input.TrimEnd();
        }

        public static string Trim(string input)
        {
            return input.Trim();
        }
        public static string Transform(string input, string pattern)
        {
            List<string> operationList = input.Split('-', '>').Where(y => y != string.Empty).ToList();

            string ret = input;

            if (String.IsNullOrEmpty(input))
            {
                return input;
            }
            foreach (var item in operationList)
            {
                if (item.Equals("lower"))
                {
                    ret = LowerCase(ret);
                }
                if (item.Equals("upper"))
                {
                    ret = UpperCase(ret);
                }
                if (item.Equals("camel"))
                {
                    ret = CamelCase(ret);
                }
                if (item.Equals("pascal"))
                {
                    ret = PascalCase(ret);
                }
                if (item.Equals("pack"))
                {
                    ret = Pack(ret);
                }
                if (item.Equals("Ltrim"))
                {
                    ret = LTrim(ret);
                }
                if (item.Equals("Rtrim"))
                {
                    ret = RTrim(ret);
                }
                if (item.Equals("trim"))
                {
                    ret = Trim(ret);
                }

            }

            return ret;
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Introducir Texto:");
                string input = Console.ReadLine();

                string output = SnakeCase(input);

                Console.WriteLine(output);

                Console.ReadKey();
            }

        }
    }
}
