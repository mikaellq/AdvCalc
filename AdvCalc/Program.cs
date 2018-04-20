using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvCalc
{
    class Program
    {
        public delegate double Calculate(double n1, char op, double n2);

        static void Main(string[] args)
        {
            double inp1, inp2;
            char op;

            Console.WriteLine("Possible calculations: + - * / and modulus %");
            do
            {
                inp1 = GetDigits();
                Console.Write("\nPlease press +-* or /: ");
                do
                {
                    op = Console.ReadKey().KeyChar;
                    if (!"+-*/%".Contains(op))
                    {
                        Console.Write('\b');
                    }
                } while (!"+-*/%".Contains(op));
                inp2 = GetDigits();
                Calculate calc = CalcMethod;
                Console.WriteLine($"\n{inp1} {op} {inp2} = {calc(inp1, op, inp2)}\n");

                Console.WriteLine("Press Enter to continue or any other key to End!");
            } while (Console.ReadKey().KeyChar == '\r');
        }

        public static double CalcMethod(double n1, char op, double n2)
        {
            double r = 0;
            switch (op)
            {
                case '+':
                    r = n1 + n2;
                    break;
                case '-':
                    r = n1 - n2;
                    break;
                case '*':
                    r = n1 * n2;
                    break;
                case '/':
                    r = n1 / n2;
                    break;
                case '%':
                    r = n1 % n2;
                    break;
                default:
                    break;
            }
            return r;
        }

        private static double GetDigits()
        {
            string s;
            double n;
            List<char> charList = new List<char>();
            char digit;
            Console.Write("\nPlease type a number, end with Enter: ");
            do
            {
                do
                {
                    digit = Console.ReadKey().KeyChar;
                } while (!Char.IsDigit(digit) && digit != '\r');
                if (digit != '\r')
                {
                    charList.Add(digit);
                }
            } while (digit != '\r');
            s = "";
            for (int i = 0; i < charList.Count; i++)
            {
                s += charList[i];
            }
            if (!Double.TryParse(s, out n))
            {
                n = 0;
            }
            return n;
        }
    }
}
