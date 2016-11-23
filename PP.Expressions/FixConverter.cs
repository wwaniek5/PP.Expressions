using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace PP.Expressions
{
    public class FixConverter
    {
        private Dictionary<char, int> _operatorImportance = new Dictionary<char, int>
        {
            {'*', 3},
            {'/', 3},
            {'+', 2},
            {'-', 2},
            {'(', 1}
        };

        private char[] _allowedCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToArray();
        private char[] operators = "*/+-".ToCharArray();

        public string ConvertInfixToPostFix(string infix)
        {
            var infixList = infix.ToList();
            var stack = new Stack<char>();
            List<char> postfixList = new List<char>();

            try
            {
                for (int i = 0; i < infixList.Count; i++)
                {
                    var currentSymbol = infixList[i];
                    if (_allowedCharacters.Contains(currentSymbol))
                    {
                        postfixList.Add(currentSymbol);
                    }
                    else if (currentSymbol == '(')
                    {
                        stack.Push(currentSymbol);
                    }
                    else if (currentSymbol == ')')
                    {
                        var topSymbol = stack.Pop();
                        while (topSymbol != '(')
                        {
                            postfixList.Add(topSymbol);
                            topSymbol = stack.Pop();
                        }
                    }
                    else if (operators.Contains(currentSymbol))
                    {
                        while (stack.Count != 0 &&
                               _operatorImportance[stack.Peek()] >= _operatorImportance[currentSymbol])
                        {
                            postfixList.Add(stack.Pop());
                        }
                        stack.Push(currentSymbol);
                    }
                    else
                    {
                        throw new ArgumentException("Symbol not allowed");
                    }
                }
            }
            catch (InvalidOperationException e)
            {
                throw new ArgumentException("Incorrect form");
            }


            while (stack.Count != 0)
            {
                postfixList.Add(stack.Pop());
            }

            return string.Join("", postfixList);
        }

        public string ConvertPostfixToPrefix(string postfix)
        {
            var postfixList = postfix.ToList();
            var stack = new Stack<string>();

            try
            {
                for (int i = 0; i < postfixList.Count; i++)
                {
                    var currentSymbol = postfixList[i];
                    if (_allowedCharacters.Contains(currentSymbol))
                    {
                        stack.Push(currentSymbol.ToString());
                    }
                    else if (operators.Contains(currentSymbol))
                    {
                        var stackTop = stack.Pop();
                        var expression = currentSymbol + stack.Pop() + stackTop;
                        stack.Push(expression);
                    }
                    else
                    {
                        throw new ArgumentException("Symbol not allowed");
                    }
                }

                if (stack.Count != 1)
                {
                    throw new ArgumentException("Incorrect form");
                }
                return stack.Pop();
            }
            catch (InvalidOperationException e)
            {
                throw new ArgumentException("Incorrect form");
            }
        }

        public string ConvertPrefixToInfix(string prefix)
        {
            var prefixList = prefix.ToList();
            var stack = new Stack<string>();

            try
            {
                for (int i = prefixList.Count - 1; i >= 0; i--)
                {
                    var currentSymbol = prefixList[i];
                    if (_allowedCharacters.Contains(currentSymbol))
                    {
                        stack.Push(currentSymbol.ToString());
                    }
                    else if (operators.Contains(currentSymbol))
                    {
                        var stackTop = stack.Pop();
                        var expression = $"({stackTop}{currentSymbol}{stack.Pop()})";
                        stack.Push(expression);
                    }
                    else
                    {
                        throw new ArgumentException("Symbol not allowed");
                    }
                }

                if (stack.Count != 1)
                {
                    throw new ArgumentException("Incorrect form");
                }

                return stack.Pop();
            }
            catch (InvalidOperationException e)
            {
                throw new ArgumentException("Incorrect form");
            }
        }
    }
}