using System;
using System.Collections.Generic;

namespace BalancedParentheses
{
    public class Program
    {
        static void Main()
        {
            string[] testler = { "([]){}", "()[]", "((()))", "", "{[()]}" };
            foreach (var ifade in testler)
                Console.WriteLine($"{ifade} -> {IsBalanced(ifade)}");
        }

        public static bool IsBalanced(string s)
        {
            var stack = new Stack<char>();
            foreach (char c in s)
            {
                if (c == '(' || c == '{' || c == '[')
                {
                    stack.Push(c);
                }
                else if (c == ')' || c == '}' || c == ']')
                {
                    if (stack.Count == 0)
                        return false;

                    char top = stack.Pop();
                    if (!Matches(top, c))
                        return false;
                }
                // Diğer karakterler varsa onları göz ardı ediyoruz
            }
            return stack.Count == 0;
        }

        private static bool Matches(char open, char close) =>
            (open == '(' && close == ')')
         || (open == '{' && close == '}')
         || (open == '[' && close == ']');
    }
}
