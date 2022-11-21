using System;
using System.Collections;

namespace LabCalculator
{
    class CalcOperations
    {
        public enum Operation
        {
            plus,
            minus,
            multiplication,
            division
        }

        private double firstNumber = 0.0;
        private double secondNumber = 0.0;
        private Operation operation;
        Stack numbersInMemory = new Stack();

        public void saveOperation(Operation operation)
        {
            this.operation = operation;
        }

        public Operation getOperation()
        {
            return this.operation;
        }

        public void saveFirstNumber(double firstNumber)
        {
            this.firstNumber = firstNumber;
        }

        public void saveSecondNumber(double secondNumber)
        {
            this.secondNumber = secondNumber;
        }

        public void cleanFirstNumber()
        {
            firstNumber = 0.0;
        }

        public void cleanSecondNumber()
        {
            secondNumber = 0.0;
        }

        public double sum()
        {
            return firstNumber + secondNumber;
        }

        public double substr()
        {
            return firstNumber - secondNumber;
        }

        public double multiplication()
        {
            return firstNumber * secondNumber;
        }

        public double division()
        {
            if (secondNumber == 0)
                throw new Exception("Mistake");
            else
                return firstNumber / secondNumber;
        }

        public string square(string number)
        {
            return Math.Pow(double.Parse(number), 2.0).ToString();
        }

        public string sin(string number)
        {
            return Math.Sin(double.Parse(number)).ToString();
        }

        public string cos(string number)
        {
            return Math.Cos(double.Parse(number)).ToString();
        }

        public string tg(string number)
        {
            return Math.Tan(double.Parse(number)).ToString();
        }

        public string ctg(string number)
        {
            if (Math.Tan(double.Parse(number)) == 0)
                throw new Exception("Mistake");
            else
                return (1/Math.Tan(double.Parse(number))).ToString();
        }

        public string divisionOnX(string number)
        {
            if (double.Parse(number) == 0)
                throw new Exception("Mistake");
            else
                return (1 / double.Parse(number)).ToString();
        }

        public string logarithm10(string number)
        {
            if (double.Parse(number) <= 0)
                throw new Exception("Mistake");
            else
                return (Math.Log10(double.Parse(number))).ToString();
        }

        public string ln(string number)
        {
            if (double.Parse(number) <= 0)
            {
                throw new Exception("Mistake");
            }
            else
                return (Math.Log(double.Parse(number))).ToString();
        }

        public string factorial(string number)
        {
            if (number[0] == '-')
            {
                throw new Exception("Mistake");
            }
            else
            {
                double fact = 1;
                for (int i = 1; i <= double.Parse(number); i++)
                    fact *= (double)i;
                return fact.ToString();
            }
        }
        public string sqrt(string number)
        {
            if (double.Parse(number) < 0)
                throw new Exception("Mistake");
            else
                return Math.Sqrt(double.Parse(number)).ToString();
        }

        public string equal(string secondNumber)
        {
            saveSecondNumber(double.Parse(secondNumber));
            switch (getOperation())
            {
                case Operation.plus:
                    return sum().ToString();
                case Operation.minus:
                    return substr().ToString();
                case Operation.multiplication:
                    return multiplication().ToString();
                case Operation.division:
                    return division().ToString();
                default:
                    return "0";
            }
        }

        public string MR()
        {
            if (numbersInMemory.Count != 0)
                return numbersInMemory.Peek().ToString();
            else
                return "0";
        }

        public void setNumberInMemory(double number)
        {
            numbersInMemory.Push(number);
        }

        public void memoryClear()
        {
            numbersInMemory.Clear();
        }

        public void clear()
        {
            memoryClear();
            cleanFirstNumber();
            cleanSecondNumber();
        }

        public void memoryDelete()
        {
            if (numbersInMemory.Count != 0) 
                numbersInMemory.Pop();
        }

        public void memoryPlus(string number)
        {
            if (numbersInMemory.Count != 0)
            {
                string variable = numbersInMemory.Peek().ToString();
                double test = double.Parse(variable) + double.Parse(number);
                numbersInMemory.Pop();
                numbersInMemory.Push(test);
            }
            else
                numbersInMemory.Push(number);
        }

        public void memoryMinus(string number)
        {
            if (numbersInMemory.Count != 0)
            {
                string variable = numbersInMemory.Peek().ToString();
                double test = double.Parse(variable) - double.Parse(number);
                numbersInMemory.Pop();
                numbersInMemory.Push(test);
            }
            else
            {
                if (number[0] == '-')
                    numbersInMemory.Push(number);
                else
                    numbersInMemory.Push("-" + number);
            }
        }
    }
}
