using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    class Heap
    {
        public Heap() { }
        public static void Create(ref int[] array)
        {
            int left, right;
            bool chkVal = true;
            Stopwatch s = Stopwatch.StartNew();
            Console.WriteLine("Creating Heap...");
            int counter = 0;
            while (chkVal)
            {
                counter++;
                if(counter == 5 || counter == 10 || counter == 15 )
                {
                    Console.Write("Heap approximately ");
                    switch (counter)
                    {
                        case 5:
                            Console.Write("25% done\n");
                            break;
                        case 10:
                            Console.Write("50% done\n");
                            break;
                        case 15:
                            Console.Write("75% done\n");
                            break;
                    }
                }
                chkVal = false;
                for (int i = 0; i < array.Length; i++)
                {
                    left = 2 * i + 1;
                    right = 2 * i + 2;
                    if (left < array.Length - 1)
                    {
                        if (array[left] > array[i])
                        {
                            Swap(ref array[left], ref array[i]);
                            chkVal = true;
                        }
                    }
                    if (right < array.Length - 1)
                    {
                        if (array[right] > array[i])
                        {
                            Swap(ref array[right], ref array[i]);
                            chkVal = true;
                        }
                    }

                }
            }
            s.Stop();
            double elapsedTime = s.ElapsedMilliseconds;
            elapsedTime = elapsedTime / 1000;
            Console.WriteLine("Took " + elapsedTime + " seconds to create heap");


        }
        
        private static void Swap(ref int a, ref int b)
        {
            a = a + b;
            b = a - b;
            a = -1*(b - a);
        }

        public static void Sort(ref int[] array)
        {
            Stopwatch s = Stopwatch.StartNew();
            
            int sortedIndex = array.Length - 1;
            double furthestLeft, furthestRight;
            int left, right;
            int sortedIndexRef;
            Console.WriteLine("Sorting Heap");
            while (sortedIndex > 0)
            {
                //push largest value to the sorted pile
                Swap(ref array[0], ref array[sortedIndex]);
                sortedIndex--;
                sortedIndexRef = sortedIndex;
                for (int i = 0; i <= sortedIndex; i++)
                {
                    left = 2 * i + 1;
                    right = 2 * i + 2;
                    furthestLeft = (sortedIndex - 1) / 2;
                    furthestRight = (sortedIndex - 2) / 2;
                    
                    if (left <= sortedIndex/* -1 */)
                    {
                        if (array[left] > array[i])
                        {
                            Swap(ref array[left], ref array[i]);
                        }
                    }
                    if (right <= sortedIndex/* -1 */)
                    {
                        if (array[right] > array[i])
                        {
                            Swap(ref array[right], ref array[i]);
                        }
                    }
                }
            }


            s.Stop();
            Console.WriteLine("Took " + s.ElapsedMilliseconds + " ms to sort heap");
        }
    }
}
