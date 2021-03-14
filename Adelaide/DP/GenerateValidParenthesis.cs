using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adelaide.DP
{
    class ValidParenthesis
    {

        public void GenerateValidParenthesisRecursive(List<string> parenthesisList, int leftRemaining, int rightRemaining, char[] solution, int index)
        {
            if (leftRemaining < 0 || rightRemaining < leftRemaining)
            {
                return; // invalid case
            }


            if (leftRemaining == 0 && rightRemaining == 0)
            {
                string s = new string(solution);
                parenthesisList.Add(s); // solution found
            }
            else 
            {

                if (leftRemaining > 0)
                {
                    solution[index] = '(';
                    GenerateValidParenthesisRecursive(parenthesisList, leftRemaining-1, rightRemaining, solution, index+1);
                }

                if (rightRemaining > leftRemaining)
                {
                    solution[index] = ')';
                    GenerateValidParenthesisRecursive(parenthesisList, leftRemaining, rightRemaining -1, solution, index+1);
                }
            }
        }
        


        public List<string> GenerateValidParenthesisBase(int count)
        {
            List<string> parenthesisList = new List<string>();
            char[] solution = new char[2 * count];
            GenerateValidParenthesisRecursive(parenthesisList, count, count, solution, 0);

            return parenthesisList;
        }

        public void PrintAnswer(List<string> answerList)
        {
            foreach (var answer in answerList) 
            {
                Console.WriteLine(answer);
            }
        }

        //public static void Main(string[] args)
        //{
        //    var g = new ValidParenthesis();
        //    int count = 3;
        //    var answerList = g.GenerateValidParenthesisBase(count);
        //    g.PrintAnswer(answerList);

        //    Console.ReadKey();
        //}
    }
}
