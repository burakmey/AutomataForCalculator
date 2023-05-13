using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AutomataForCalculator
{
    static internal class InfixToPostfix
    {
        static Stack<char> stack;
        static readonly char[] operators = { '+', '-', 'x', '/' };
        static string output;
        static int stackPriority;
        public static string Convert(string input)
        {
            stack = new Stack<char>();
            output = "";
            stackPriority = (int)Operators.Any;
            while (input.Length > 0)
            {
                if (Char.IsDigit(input[0]) || (input[0] == '-' && Char.IsDigit(input[1])))
                {
                    while (input.Length > 0 && input[0] != '(' && input[0] != ')' && input[0] != ' ')
                    {
                        output += input[0];
                        input = input.Remove(0, 1);
                    }
                    output += " ";
                    if (input.Length > 0 && input[0] == ' ')
                    {
                        input = input.Remove(0, 1);
                    }
                }
                else if (operators.Contains(input[0])) 
                {
                    if (stackPriority == (int)Operators.Any) //stack.Count = 0, stack.Peek() = '('
                    {
                        if (input[0] == '+' || input[0] == '-')
                            stackPriority = (int)Operators.AdditionSubstraction;
                        else if (input[0] == 'x' || input[0] == '/')
                            stackPriority = (int)Operators.MultiplicationDivision;
                        stack.Push(input[0]);
                        input = input.Remove(0, 1); //Removes operator
                        input = input.Remove(0, 1); //Removes space
                    }
                    else if (input[0] == '+' || input[0] == '-')
                    {
                        if (stackPriority == (int)Operators.Any)
                        {
                            stackPriority = (int)Operators.AdditionSubstraction;
                            stack.Push(input[0]);
                            input = input.Remove(0, 1); //Removes operator
                            input = input.Remove(0, 1); //Removes space
                        }
                        else
                        {
                            while (stack.Count > 0 && operators.Contains(stack.Peek()))
                            {
                                output += stack.Pop().ToString() + " ";
                            }
                            stackPriority = (int)Operators.AdditionSubstraction;
                            stack.Push(input[0]);
                            input = input.Remove(0, 1); //Removes operator
                            input = input.Remove(0, 1); //Removes space
                        }
                    }
                    else if (input[0] == 'x' || input[0] == '/')
                    {
                        if (stackPriority == (int)Operators.AdditionSubstraction || stackPriority == (int)Operators.Any)
                        {
                            stackPriority = (int)Operators.MultiplicationDivision;
                            stack.Push(input[0]);
                            input = input.Remove(0, 1); //Removes operator
                            input = input.Remove(0, 1); //Removes space
                        }
                        else if (stackPriority == (int)Operators.MultiplicationDivision)
                        {
                            while (stack.Count > 0 && (stack.Peek() == 'x' || stack.Peek() == '/'))
                            {
                                output += stack.Pop().ToString() + " ";
                            }
                            stackPriority = (int)Operators.MultiplicationDivision;
                            stack.Push(input[0]);
                            input = input.Remove(0, 1); //Removes operator
                            input = input.Remove(0, 1); //Removes space
                        }
                    }
                }
                else if (input[0] == '(')
                {
                    stackPriority = (int)Operators.Any;
                    stack.Push(input[0]);
                    input = input.Remove(0, 1); //Removes parentheses
                }
                else if (input[0] == ')')
                {
                    while (stack.Peek() != '(')
                    {
                        output += stack.Pop().ToString() + " ";
                    }
                    stack.Pop();
                    input = input.Remove(0, 1); //Removes parentheses
                    if (input.Length > 0)
                        input = input.Remove(0, 1); //Removes space
                    if (stack.Count == 0)
                        stackPriority = (int)Operators.Any;
                    else if (stack.Peek() == '+' || stack.Peek() == '-')
                        stackPriority = (int)Operators.AdditionSubstraction;
                    else if (stack.Peek() == 'x' || stack.Peek() == '/')
                        stackPriority = (int)Operators.MultiplicationDivision;
                }
                if (input.Length == 0)
                {
                    while (stack.Count > 0)
                    {
                        output += stack.Pop().ToString() + " ";
                    }
                    output = output.Remove(output.Length - 1, 1);
                }
            }
            return GetResult(output).ToString();
        }
        static float GetResult(string result)
        {
            string[] operators = { "+", "-", "x", "/" };
            result = result.Replace('.', ',');
            List<string> list = new List<string>(result.Split(' '));
            for (int i = 0; ; i++)
            {
                if (operators.Contains(list[i]))
                {
                    float a = float.Parse(list[i - 2]);
                    float b = float.Parse(list[i - 1]);
                    switch (list[i])
                    {
                        case "+":
                            list[i] = (a + b).ToString();
                            break; 
                        case "-":
                            list[i] = (a - b).ToString();
                            break; 
                        case "x":
                            list[i] = (a * b).ToString();
                            break;
                        case "/":
                            list[i] = (a / b).ToString();
                            break;
                        default:
                            break;
                    }
                    list.RemoveAt(i - 1);
                    i--;
                    list.RemoveAt(i - 1);
                    if (list.Count == 1)
                    {
                        break;
                    }
                    i = 0;
                }
            }
            return float.Parse(list[0]);
        }
    }
    enum Operators
    {
        MultiplicationDivision,
        AdditionSubstraction,
        Any,
    }
}
