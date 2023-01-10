using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp
{
    class MathOps
    {
        public long AddFunc(int value1,int value2)
        {
            long result = value1 + value2;
            return result;
        }
        public void MathFunc(double v1, double v2, out double addedValue, out double subtractedValue, out double multipliedValue, out double divValue)
        {
            addedValue = v1 + v2;
            subtractedValue = v1 - v2;
            multipliedValue = v1 * v2;
            if (v2 != 0)
                divValue = v1 / v2;
            else
                throw new DivideByZeroException();
        }
        public  int Add(params int[] ListNumbers)
        {
            int total = 0;

            // foreach loop
            foreach (int i in ListNumbers)
            {
                total += i;
            }
            return total;
        }


        public void SquareBasedFunc(int inputValue, ref double squareValue, ref double sqrRoot)
        {
            squareValue = inputValue * inputValue;
            sqrRoot = Math.Sqrt(inputValue);
        }
    }
    class ExFunc
    {
        static void Main(string[] args)
        {
            MathOps operations = new MathOps();
           long value= operations.AddFunc(13, 12);
            Console.WriteLine(value);
            int iVal1 = 9;
            double fVal = 0, sVal = 0;
            operations.SquareBasedFunc(iVal1, ref fVal, ref sVal);
            Console.WriteLine($"The fVal : {fVal} and sVal : {sVal}");

            int firstValue = 123, secondValue = 12;
            double addedVal, subVal, mulVal, divVal;
            operations.MathFunc(firstValue, secondValue, out addedVal, out subVal, out mulVal, out divVal);
            Console.WriteLine($"The Added value: {addedVal}\nSubtracted Value: {subVal}\nThe multiplied Value: {mulVal}\nThe Divided Value: {divVal}");

            int y = operations.Add(12, 13, 10, 15, 56);
            Console.WriteLine(y);

        }
    }
}


