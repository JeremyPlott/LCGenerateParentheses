using System;
using System.Collections.Generic;

namespace LCGenerateParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<string> solution = GenerateParenthesis(3);

            foreach (var permutation in solution)
            {
                Console.WriteLine(permutation);
            }

           
            IList<string> GenerateParenthesis(int n)
            {
                List<string> parenPermutations = new List<string>();

                GetPermutations(n, string.Empty, 0, 0, parenPermutations);

                return parenPermutations;
            }

            void GetPermutations(int numOfSets, string permutation, int openParens, int closingParens, IList<string> parenPermutations)
            {
                //break condition
                if (permutation.Length == numOfSets * 2)
                {
                    parenPermutations.Add(permutation);
                    return;
                }

                //recursive function
                if (openParens < numOfSets)
                {
                    GetPermutations(numOfSets, permutation + "(", openParens + 1, closingParens, parenPermutations);
                }

                if (closingParens < openParens)
                {
                    GetPermutations(numOfSets, permutation + ")", openParens, closingParens + 1, parenPermutations);
                }
            }
        }
    }
}
