using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomataForCalculator
{
    internal class DFAModel
    {
        int currentState = 0;
        bool isFinal;
        readonly char[] digits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        readonly char[] operators = { '+', '-', 'x', '/' };
        readonly int[] finalStates = { 7, 9, 21 };
        public bool IsFinal { get { return isFinal; } }
        public int State(char c)
        {
            switch (currentState)
            {
                case 0: //***************************************************************************************
                    if (c == '-')
                    {
                        currentState = 1;
                        break;
                    }
                    else if (digits.Contains(c))
                    {
                        currentState = 2;
                        break;
                    }
                    else if (c == '(')
                    {
                        currentState = 11;
                        break;
                    }
                    else { currentState = -1; break; }
                case 1: //***************************************************************************************
                    if (digits.Contains(c))
                    {
                        currentState = 2;
                        break;
                    }
                    else { currentState = -1; break; }
                case 2: //***************************************************************************************
                    if (digits.Contains(c))
                    {
                        currentState = 2;
                        break;
                    }
                    else if (c == '.')
                    {
                        currentState = 3;
                        break;
                    }
                    else if (operators.Contains(c))
                    {
                        currentState = 5;
                        break;
                    }
                    else { currentState = -1; break; }
                case 3: //***************************************************************************************
                    if (digits.Contains(c))
                    {
                        currentState = 4;
                        break;
                    }
                    else { currentState = -1; break; }
                case 4: //***************************************************************************************
                    if (digits.Contains(c))
                    {
                        currentState = 4;
                        break;
                    }
                    else if (operators.Contains(c))
                    {
                        currentState = 5;
                        break;
                    }
                    else { currentState = -1; break; }
                case 5: //***************************************************************************************
                    if (c == '-')
                    {
                        currentState = 6;
                        break;
                    }
                    else if (digits.Contains(c))
                    {
                        currentState = 7;
                        break; //7 is final state
                    }
                    else if (c == '(')
                    {
                        currentState = 11;
                        break;
                    }
                    else { currentState = -1; break; }
                case 6: //***************************************************************************************
                    if (digits.Contains(c))
                    {
                        currentState = 7;
                        break; //7 is final state
                    }
                    else { currentState = -1; break; }
                case 7: //***************************************************************************************
                    if (digits.Contains(c))
                    {
                        currentState = 7; 
                        break; //7 is final state
                    }
                    else if (c == '.')
                    {
                        currentState = 8;
                        break;
                    }
                    else if (operators.Contains(c))
                    {
                        currentState = 10;
                        break;
                    }
                    else { currentState = -1; break; }
                case 8: //***************************************************************************************
                    if (digits.Contains(c))
                    {
                        currentState = 9;
                        break; //9 is final state
                    }
                    else { currentState = -1; break; }
                case 9: //***************************************************************************************
                    if (digits.Contains(c))
                    {
                        currentState = 9;
                        break; //9 is final state
                    }
                    else if (operators.Contains(c))
                    {
                        currentState = 10;
                        break;
                    }
                    else { currentState = -1; break; }
                case 10: //***************************************************************************************
                    if (c == '-')
                    {
                        currentState = 6;
                        break;
                    }
                    else if (digits.Contains(c))
                    {
                        currentState = 7;
                        break; //7 is final state
                    }
                    else if (c == '(')
                    {
                        currentState = 11;
                        break;
                    }
                    else { currentState = -1; break; }
                case 11: //***************************************************************************************
                    if (c == '-')
                    {
                        currentState = 12;
                        break;
                    }
                    else if (digits.Contains(c))
                    {
                        currentState = 13;
                        break;
                    }
                    else { currentState = -1; break; }
                case 12: //***************************************************************************************
                    if (digits.Contains(c))
                    {
                        currentState = 13;
                        break;
                    }
                    else { currentState = -1; break; }
                case 13: //***************************************************************************************
                    if (digits.Contains(c))
                    {
                        currentState = 13;
                        break;
                    }
                    else if (c == '.')
                    {
                        currentState = 14;
                        break;
                    }
                    else if (operators.Contains(c))
                    {
                        currentState = 16;
                        break;
                    }
                    else { currentState = -1; break; }
                case 14: //***************************************************************************************
                    if (digits.Contains(c))
                    {
                        currentState = 15;
                        break;
                    }
                    else { currentState = -1; break; }
                case 15: //***************************************************************************************
                    if (digits.Contains(c))
                    {
                        currentState = 15;
                        break;
                    }
                    else if (operators.Contains(c))
                    {
                        currentState = 16;
                        break;
                    }
                    else { currentState = -1; break; }
                case 16: //***************************************************************************************
                    if (c == '-')
                    {
                        currentState = 17;
                        break;
                    }
                    else if (digits.Contains(c))
                    {
                        currentState = 18;
                        break;
                    }
                    else { currentState = -1; break; }
                case 17: //***************************************************************************************
                    if (digits.Contains(c))
                    {
                        currentState = 18;
                        break;
                    }
                    else { currentState = -1; break; }
                case 18: //***************************************************************************************
                    if (operators.Contains(c))
                    {
                        currentState = 16;
                        break;
                    }
                    else if (digits.Contains(c))
                    {
                        currentState = 18;
                        break;
                    }
                    else if (c == '.')
                    {
                        currentState = 19;
                        break;
                    }
                    else if (c == ')')
                    {
                        currentState = 21;
                        break; //21 is final state
                    }
                    else { currentState = -1; break; }
                case 19: //***************************************************************************************
                    if (digits.Contains(c))
                    {
                        currentState = 20;
                        break;
                    }
                    else { currentState = -1; break; }
                case 20: //***************************************************************************************
                    if (digits.Contains(c))
                    {
                        currentState = 20;
                        break;  
                    }
                    else if (operators.Contains(c))
                    {
                        currentState = 16;
                        break;
                    }
                    else if (c == ')')
                    {
                        currentState = 21;
                        break; //21 is final state
                    }
                    else { currentState = -1; break; }
                case 21: //***************************************************************************************
                    if (operators.Contains(c))
                    {
                        currentState = 0;
                        break;
                    }
                    else { currentState = -1; break; }
                default:
                    break;
            }
            if (finalStates.Contains(currentState))
            {
                isFinal = true;
            }
            else
            {
                isFinal = false;
            }
            return currentState;
        }
        public void SetStartState()
        {
            currentState = 0;
        }
    }
}