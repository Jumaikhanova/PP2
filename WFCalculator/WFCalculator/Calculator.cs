using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFCalculator
{
    public delegate void ChangeTextDelegate(string text);
    enum CalcState//состояния
    {
        Zero,
        AccumulateDigit,
        Separator,
        Operation, 
        ComplexOperation,
        Result,
        Clear,
        ClearEnd,
        Negate,
        MemoryOperations,

    }
    class Calculator
    {
        public CalcState state;
        public string tempNumber;
        public string resultNumber;
        public string operation;
        public string resultNumOfComplexOperation;
        public string extraNumber;
        public string numberInMemory;
        public ChangeTextDelegate textDelegate;

        public Calculator(ChangeTextDelegate textDelegate)
        {
            state = CalcState.Zero;
            this.textDelegate = textDelegate;
            textDelegate.Invoke("0");            
            tempNumber = "";
            resultNumber = "";
            operation = "";
            resultNumOfComplexOperation = "";
            extraNumber = "";
            numberInMemory = "";
    }
        public void Process(string input)
        {
            switch (state)
            {
                case CalcState.Separator:
                    Separator(input, false);
                    break;
                case CalcState.Zero:
                    Zero(input, false);
                    break;
                case CalcState.AccumulateDigit:
                    AccumulateDigit(input, false);
                    break;
                case CalcState.Operation:
                    Operation(input, false);
                    break;
                case CalcState.ComplexOperation:
                    ComplexOperation(input, false);
                    break;
                case CalcState.Result:
                    Result(input, false);
                    break;
                case CalcState.ClearEnd:
                    ClearEnd(input, false);
                    break;
                case CalcState.Negate:
                    Negate(input, false);
                    break;
                case CalcState.MemoryOperations:
                    MemoryOperations(input, false);
                    break;
                default:
                    break;
            }
        }
        public void Separator(string msg, bool input)
        {
            if (input)
            {

                if (!(tempNumber.Contains(",")))  
                {
                    state = CalcState.Separator;
                    tempNumber += msg;
                    textDelegate.Invoke(tempNumber);
                }
                
            }
            else
            {
                if (Rules.IsDigit(msg))
                    AccumulateDigit(msg, true);
                if (Rules.IsClear(msg))
                    Clear(msg, true);
            }
        }
        public void Zero(string msg, bool input)
        {
            if (input)//переход в эту операцию
            {
                state = CalcState.Zero;
                textDelegate.Invoke(msg);
            }
            else//пеерход из данной операции в другую
            {
                if (Rules.IsNonZeroDigit(msg))
                    AccumulateDigit(msg, true);
                if (Rules.IsSeparator(msg))
                {
                    tempNumber = "0";
                    Separator(msg, true);
                }
                if (Rules.IsMemoryOperation(msg))
                    MemoryOperations(msg, true);
            }
        }
        public void AccumulateDigit(string msg, bool input)
        {
            if (input)
            {
                state = CalcState.AccumulateDigit;
                tempNumber += msg;
                textDelegate.Invoke(tempNumber);
            }
            else
            {
                if (Rules.IsDigit(msg))
                    AccumulateDigit(msg, true);
                if (Rules.IsOperation(msg))
                    Operation(msg, true);
                if (Rules.IsEqual(msg))
                    Result(msg, true);
                if (Rules.IsClear(msg))
                    Clear(msg, true);
                if (Rules.IsSeparator(msg))
                    Separator(msg, true);
                if (Rules.IsComplexOperation(msg))
                    ComplexOperation(msg, true);
                if (Rules.IsClearEnd(msg))
                    ClearEnd(msg, true);
                if (Rules.IsNegateButton(msg))
                    Negate(msg, true);
                if (Rules.IsMemoryOperation(msg))
                {
                    extraNumber = tempNumber;
                    MemoryOperations(msg, true);
                }
            }

        }
        public void Operation(string msg, bool input)
        {
            if (input)
            {
                state = CalcState.Operation;
                if (operation.Length > 0)//если была предыдущая операция
                {
                    Calculate();
                    textDelegate.Invoke(resultNumber);
                    extraNumber = resultNumber;
                }
                else
                {
                    resultNumber = tempNumber;
                    extraNumber = resultNumber;
                }       
                tempNumber = "";
                operation = msg;
            }
            else
            {
                if (Rules.IsDigit(msg))
                    AccumulateDigit(msg, true);
                if (Rules.IsClear(msg))
                    Clear(msg, true);
                if (Rules.IsNegateButton(msg))
                {
                    tempNumber = resultNumber;
                    Negate(msg, true);
                }
                if (Rules.IsMemoryOperation(msg))
                    MemoryOperations(msg, true);
                if (Rules.IsEqual(msg))
                {
                    tempNumber = resultNumber;
                    Result(msg, true);
                }
            }
        }
        public void ComplexOperation(string msg, bool input)
        {
            if (input)
            {
                if (msg == "√")
                    resultNumOfComplexOperation = Math.Sqrt(double.Parse(tempNumber)).ToString();
                if (msg == "x²")
                   resultNumOfComplexOperation = (double.Parse(tempNumber) * double.Parse(tempNumber)).ToString();
                if (msg == "sinx")
                    resultNumOfComplexOperation = Math.Sin(((double.Parse(tempNumber))*Math.PI/180)).ToString();
                textDelegate.Invoke(resultNumOfComplexOperation);
                tempNumber = resultNumOfComplexOperation;
                extraNumber = resultNumOfComplexOperation;
            }
            else
            {
                if (Rules.IsOperation(msg))
                    Operation(msg, true);
                if (Rules.IsComplexOperation(msg))
                    ComplexOperation(msg, true);
                if (Rules.IsDigit(msg))
                {
                    tempNumber = "";
                    AccumulateDigit(msg, true);
                }
                if (Rules.IsNegateButton(msg))
                    Negate(msg, true);
                if (Rules.IsMemoryOperation(msg))
                    MemoryOperations(msg, true);

            }
        }
        public void Result(string msg, bool input)
        {
            if (input)
            {
                state = CalcState.Result;
                Calculate();
                textDelegate.Invoke(resultNumber);
                extraNumber = resultNumber;
            }
            else
            {
                if (Rules.IsDigit(msg))
                    AccumulateDigit(msg, true);
                if (Rules.IsOperation(msg))
                {
                    operation = "";
                    tempNumber = resultNumber;
                    Operation(msg, true);
                }
                if (Rules.IsClear(msg))
                    Clear(msg, true);
                if (Rules.IsSeparator(msg))
                    Separator(msg, true);
                if (Rules.IsEqual(msg))
                    Result(msg, true);
                if (Rules.IsSeparator(msg))
                {
                    tempNumber = "";
                    resultNumber = "";
                    operation = "";
                    tempNumber = "0";
                    Separator(msg, true);
                }
                if (Rules.IsComplexOperation(msg))
                {
                    tempNumber = resultNumber;
                    ComplexOperation(msg, true);
                }
                if (Rules.IsNegateButton(msg))
                {
                    tempNumber = resultNumber;
                    Negate(msg, true);
                }
                if (Rules.IsMemoryOperation(msg))                
                    MemoryOperations(msg, true);
            }
        }
        public void Clear(string msg, bool input)
        {            
            if (msg == "C")
            {
                tempNumber = "";
                resultNumber = "";
                operation = "";
                msg = "0";
                Zero(msg, true);
            }
            if (msg == "CE")
            {
                tempNumber = "";
                msg = "0";
                Zero(msg, true);
            }
        }
        public void ClearEnd(string msg, bool input)
        {
            if (input)
            {
                state = CalcState.ClearEnd;
                int ind = tempNumber.Length - 1;
                tempNumber = tempNumber.Remove(ind);
                textDelegate.Invoke(tempNumber);
                extraNumber = tempNumber;
                if (tempNumber.Length == 0)
                {
                    msg = "0";
                    Zero(msg, true);
                }
            }
            else
            {
                if (Rules.IsDigit(msg))
                    AccumulateDigit(msg, true);
                if (Rules.IsClear(msg))
                    Clear(msg, true);
                if (Rules.IsClearEnd(msg))
                    ClearEnd(msg, true);
                if (Rules.IsOperation(msg))
                    Operation(msg, true);
                if (Rules.IsComplexOperation(msg))
                    ComplexOperation(msg, true);
                if (Rules.IsNegateButton(msg))       
                    Negate(msg, true);
                if (Rules.IsMemoryOperation(msg))
                    MemoryOperations(msg, true);
                
            }
        }
        public void Negate(string msg, bool input)
        {
            if (input)
            {
                state = CalcState.Negate;
                tempNumber = (-1 * (double.Parse(tempNumber))).ToString();
                textDelegate.Invoke(tempNumber);
                extraNumber = tempNumber;
            }
            else
            {
                if (Rules.IsDigit(msg))
                    AccumulateDigit(msg, true);
                if (Rules.IsOperation(msg))
                    Operation(msg, true);
                if (Rules.IsEqual(msg))
                    Result(msg, true);
                if (Rules.IsClear(msg))
                    Clear(msg, true);
                if (Rules.IsSeparator(msg))
                    Separator(msg, true);
                if (Rules.IsMemoryOperation(msg))
                {
                    extraNumber = tempNumber;
                    MemoryOperations(msg, true);
                }

                if (Rules.IsClearEnd(msg))
                    ClearEnd(msg, true);
                if (Rules.IsComplexOperation(msg))
                    ComplexOperation(msg, true);
                if (Rules.IsNegateButton(msg))
                    Negate(msg, true);
                if (Rules.IsMemoryOperation(msg))
                    MemoryOperations(msg, true);
            }

        }
        public void MemoryOperations(string msg, bool input)
        {
            if (input)
            {
                state = CalcState.MemoryOperations;
                if (msg == "MS")
                {
                    numberInMemory = extraNumber;
                }
                if (msg == "MC")
                {
                    numberInMemory = "";
                }
                if (msg == "M+")
                {
                    numberInMemory = (double.Parse(numberInMemory) + double.Parse(tempNumber)).ToString();
                }
                if (msg == "M-")
                {
                    numberInMemory = (double.Parse(numberInMemory) - double.Parse(tempNumber)).ToString();
                }
                if (msg == "MR")
                {
                    textDelegate.Invoke(numberInMemory);
                }
            }
            else
            {
                if (Rules.IsClear(msg))
                    Clear(msg, true);
                if (Rules.IsEqual(msg))
                    Result(msg, true);
                if (Rules.IsComplexOperation(msg))
                {
                    tempNumber = numberInMemory;
                    ComplexOperation(msg, true);
                }
                if (Rules.IsNegateButton(msg))
                {
                    tempNumber = numberInMemory;
                    Negate(msg, true);
                }
                if (Rules.IsDigit(msg))
                {
                    tempNumber = "";
                    resultNumber = "";
                    if (msg == "0")
                        Zero(msg, true);
                    else
                        AccumulateDigit(msg, true);                                       
                }
                if (Rules.IsOperation(msg))
                {
                    tempNumber = numberInMemory;
                    Operation(msg, true);
                }
                if (Rules.IsMemoryOperation(msg))
                    MemoryOperations(msg, true);
            }
        }
        public void Calculate()
        {
            if (operation == "+")
                resultNumber = (double.Parse(resultNumber) + double.Parse(tempNumber)).ToString();
            if (operation == "-")
                resultNumber = (double.Parse(resultNumber) - double.Parse(tempNumber)).ToString();
            if (operation == "÷")
                resultNumber = (double.Parse(resultNumber) / double.Parse(tempNumber)).ToString();
            if (operation == "×")
                resultNumber = (double.Parse(resultNumber) * double.Parse(tempNumber)).ToString();
            
        }
    }
}
