using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adelaide.DP
{
    class PermutationStringNoDups
    {
        public List<string> GeneratePermutations(string str)
        {
            List<string> result = new List<string>();

            if (String.IsNullOrEmpty(str)) 
            {
                result.Add("");
                return result;
            }

            for (int i = 0; i < str.Length; i++)
            {
                string before = str.Substring(0, i);
                string after = str.Substring(i + 1, str.Length-(i + 1));

                var partialResults = GeneratePermutations(before+after);

                foreach (var partialResult in partialResults) 
                {
                    result.Add(str[i] + partialResult);
                }
            }

            return result;
        }

        public void Test()
        {
            Console.Write("test");
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
        //    var p = new PermutationStringNoDups();
        //    string s = "abc";
        //    var answerList = p.GeneratePermutations(s);
        //    Console.WriteLine($"Total permutations:{answerList.Count}");
        //    p.PrintAnswer(answerList);
        //    Console.ReadKey();
        //}

        
    }
}
