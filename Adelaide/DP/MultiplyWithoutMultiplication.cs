using System;

namespace Adelaide.DP
{
    class MultiplyWithoutMultiplication
    {
        int Multiply(int number1, int number2)
        {
            // validate edge cases
            int smaller = (number1 < number2) ? number1 : number2;
            int bigger = (number1 > number2) ? number1 : number2;

            return MultiplyRecurse(smaller, bigger);
        }

        int MultiplyRecurse(int smaller, int bigger)
        {
            // base cases
            if (smaller == 0) return 0; 
            if (smaller == 1) return bigger;

            int halfOfSmaller = smaller >> 1; //divide by 2
            int halfMultiplication = MultiplyRecurse(halfOfSmaller, bigger); 
            int multiplicationResult = halfMultiplication + halfMultiplication; // multiplying by 2

            if (smaller % 2 == 1) // note here to compare against smaller number & not the half of the number
                return multiplicationResult + bigger;
      
            return multiplicationResult;
        }

        // static void Main(string[] args)
        //{
        //    MultiplyWithoutMultiplication m = new MultiplyWithoutMultiplication();
        //    int number1 = 18;
        //    int number2 = 87;

        //    Console.WriteLine($"{number1} * {number2} = {m.Multiply(number1, number2)}");
        //    Console.ReadKey();
        //}
    }
}
