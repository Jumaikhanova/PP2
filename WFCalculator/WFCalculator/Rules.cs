using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFCalculator
{
    class Rules
    {
        public static bool IsDigit(string text)
        {
            String[] digits = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            return digits.Contains(text);
        }
        public static bool IsNonZeroDigit(string text)
        {
            String[] digits = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            return digits.Contains(text);
        }
        public static bool IsOperation(string text)
        {
            String[] digits = new string[] { "+", "-", "÷", "×" };
            return digits.Contains(text);
        }
        public static bool IsComplexOperation(string text)
        {
            String[] digits = new string[] { "√", "x²", "sinx" };
            return digits.Contains(text);
        }
       
        public static bool IsSeparator(string text)
        {
            return text == ",";
        }
       
        public static bool IsEqual(string text)
        {
            return text == "=";
        }
        
        public static bool IsMemoryOperation(string text)
        {
            String[] digits = new string[] { "MC", "MR", "M+", "M-", "MS" };
            return digits.Contains(text);
        }
        
        public static bool IsClear(string text)
        {
            String[] digits = new string[] { "C", "CE" };
            return digits.Contains(text);
        }
        public static bool IsClearEnd(string text)
        {
            String[] digits = new string[] { "<-" };
            return digits.Contains(text);
        }
        public static bool IsNegateButton(string text)
        {
            return text == "±";
        }
    }
}
