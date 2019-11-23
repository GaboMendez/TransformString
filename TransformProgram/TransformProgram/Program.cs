using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            string newWord = "";

            if (input.Contains(" "))
            {
                if (char.IsUpper(input[0]))
                    newWord += char.ToLower(input[0]);
                else
                    newWord += input[0];

                for (int i = 1; i < input.Length; i++)
                {
                    if (char.IsLower(input[i]) && input[i - 1] == ' ')
                        newWord += char.ToUpper(input[i]);
                    else
                        newWord += input[i];
                }

                newWord = Regex.Replace(newWord, @"\s", "");

                return newWord;

            }
            else
            {
                if (char.IsUpper(input[0]))
                {
                    newWord += char.ToLower(input[0]);
                    for (int i = 1; i < input.Length; i++)
                        newWord += input[i];

                    return newWord;
                }
                else
                    return input;
            }
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

            return input.Replace(" ", "");

            //var ret = input;

            //var LSpace = "";
            //for (int i = 0; i < input.Length; i++)
            //{
            //    if (i + 1 == input.Length)
            //    {
            //        break;;
            //    }

            //    if (input[i].Equals(' ') && !input[i + 1].Equals(' '))
            //    {
            //        //LSpace = input.Substring(i);
            //        break;;
            //    }


            //}


            //Console.WriteLine();

            //return null;
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
            List<string> operationList = pattern.Split('-', '>').Where(y => y != string.Empty).ToList();

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

                if (item.Equals("snake"))
                {
                    ret = SnakeCase(ret);
                }
            }

            return ret;
        }

        static void Main(string[] args)
        {
          

            Console.Clear();
            Console.WriteLine("Prueba: 01");
            string input = "     hOLA profesor";
            Console.WriteLine($"INPUT: {input} ");
            string output = Transform(input, "upper->pack->Ltrim");
            Console.WriteLine($"OUTPUT: {output} ");
            Console.WriteLine();


            Console.WriteLine("Prueba: 02");
            input = "buenas AMIGOS   ";
            Console.WriteLine($"INPUT: {input} ");
            output = Transform(input, "lower->camel->Ltrim");
            Console.WriteLine($"OUTPUT: {output} ");
            Console.WriteLine();

            Console.WriteLine("Prueba: 03");
            input = "    laComputadora Azul   ";
            Console.WriteLine($"INPUT: {input} ");
            output = Transform(input, "trim->lower->pack");
            Console.WriteLine($"OUTPUT: {output} ");
            Console.WriteLine();

            Console.WriteLine("Prueba: 04");
            input = "está tareaESTA_Larga";
            Console.WriteLine($"INPUT: {input} ");
            output = Transform(input, "upper->camel->pack->lower");
            Console.WriteLine($"OUTPUT: {output} ");
            Console.WriteLine();

            Console.WriteLine("Prueba: 05");
            input = "AYUDE al estudiante      ";
            Console.WriteLine($"INPUT: {input} ");
            output = Transform(input, "upper->snake->Rtrim");
            Console.WriteLine($"OUTPUT: {output} ");
            Console.WriteLine();

            Console.WriteLine("Prueba: 06");
            input = "vamos A tRABAJAR";
            Console.WriteLine($"INPUT: {input} ");
            output = Transform(input, "pascal->snake->pack");
            Console.WriteLine($"OUTPUT: {output} ");
            Console.WriteLine();
            Console.ReadKey();
            //var x = "            a a a";
            //var y = "";



            //////////////
            //Console.WriteLine();
            //x = "A A A b";
            //y = Transform(x, "upper->pack->pascal");
            //Console.WriteLine(y);
            //Console.WriteLine("Caso 1B: " + (y == "Aaab"));
            //x = "    Hola   Mundo";
            //y = Transform(x, "pack->pascal");
            //Console.WriteLine(y);
            //Console.WriteLine("Caso 2A: " + (y == "Holamundo"));
            //x = "SALuDO";
            //y = Transform(x, "upper->pascal");
            //Console.WriteLine(y);
            //Console.WriteLine("Caso 2B: " + (y == "Saludo"));
            //x = "Esto Es Una Oracion";
            //y = Transform(x, "camel->pack->lower");
            //Console.WriteLine(y);
            //Console.WriteLine("Caso 3A: " + (y == "estoesunaoracion"));
            //x = "esto  es  una  oracion";
            //y = Transform(x, "camel->lower");
            //Console.WriteLine(y);
            //Console.WriteLine("Caso 3A: " + (y == x));

            //x = "esto es una oracion";
            //y = Transform(x, "camel");
            //Console.WriteLine(y);
            //Console.WriteLine("Caso 3A: " + (y == "Esto Es Una Oracion"));
            //Console.ReadKey();
        }
    }
}
