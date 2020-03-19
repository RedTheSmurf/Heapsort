using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            //generate random inputs to sort
            //int[] sort = new int[100000000];
            int[] sort = new int[100];
            Random r = new Random();
            for (int i = 1; i < sort.Length; i++)
            {
                sort[i] = r.Next(65536);
            }
            
            Heap.Create(ref sort);

            Heap.Sort(ref sort);
            CheckSort(sort);
            Console.Write("\n\n\n");
            

            Console.ReadLine();

        }

        public static void CheckHeap(int[] sort)
        {
            bool left, right;
            int leftInt, rightInt;
            int counter = 0;

            for (int i = 0; i < sort.Length; i++)
            {
                counter++;
                left = false;
                right = false;
                leftInt = 2 * i + 1;
                rightInt = 2 * i + 2;
                if (leftInt > sort.Length - 1 && rightInt > sort.Length - 1)
                {
                    break;
                }
                if (leftInt > sort.Length - 1) Console.Write(sort[i] + " has no left child\n");
                if (rightInt > sort.Length - 1) Console.Write(sort[i] + " has no right child\n");
                if (leftInt < sort.Length - 1)
                {
                    left = sort[i] > sort[leftInt];
                    Console.Write(sort[i] + " is greater than " + sort[leftInt] + " ");
                    Console.Write("\t\t" + left + "\n");
                }
                if (rightInt < sort.Length - 1)
                {
                    right = sort[i] > sort[rightInt];
                    Console.Write(sort[i] + " is greater than " + sort[rightInt] + " ");
                    Console.Write("\t\t" + right + "\n");
                }
            }

            Console.WriteLine(counter);
        }

        public static void CheckSort(int[] sort)
        {
            string outputString = "Sorted";
            for(int i = 0; i < sort.Length; i++)
            {
                try
                {
                    if (sort[i] > sort[i + 1])
                    {
                        outputString = "Failed";
                    }
                }
                catch(Exception e)
                {

                }
            }
            Console.Write(outputString);
        }
    }
}
