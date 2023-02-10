using System;
using System.Collections.Generic;

namespace CollectionsMasterConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: Follow the steps provided in the comments under each region.
            //Make the console formatted to display each section well
            //Utlilize the method stubs at the bottom for the methods you must create ⬇⬇⬇

            #region Arrays
            //TODO: Create an integer Array of size 50
            int[] fiftyIntArray = new int[50];

            //TODO: Create a method to populate the number array with 50 random numbers that are between 0 and 50
            //SEE LINE  (Populator)
            Populater(fiftyIntArray);

            //TODO: Print the first number of the array
            Console.WriteLine(fiftyIntArray[0]);

            //TODO: Print the last number of the array            
            Console.WriteLine(fiftyIntArray[49]);

            Console.WriteLine("All Numbers Original");
            //UNCOMMENT this method to print out your numbers from arrays or lists
            NumberPrinter(fiftyIntArray);
            Console.WriteLine("-------------------");

            //TODO: Reverse the contents of the array and then print the array out to the console.
            //Try for 2 different ways
            /*  1) First way, using a custom method => Hint: Array._____(); 
                2) Second way, Create a custom method (scroll to bottom of page to find ⬇⬇⬇)
            */
            //SEE LINE  (ReverseArray)
            Array.Reverse(fiftyIntArray);

            Console.WriteLine("All Numbers Reversed:");

            NumberPrinter(fiftyIntArray);
            //ReverseArray(fiftyIntArray);

            Console.WriteLine("-------------------");

            //TODO: Create a method that will set numbers that are a multiple of 3 to zero then print to the console all numbers
            //SEE LINE  (ThreeKiller)
            Console.WriteLine("Multiple of three = 0: ");
            ThreeKiller(fiftyIntArray);

            Console.WriteLine("-------------------");

            //TODO: Sort the array in order now
            /*      Hint: Array.____()      */
            Console.WriteLine("Sorted numbers:");
            Array.Sort(fiftyIntArray);
            NumberPrinter(fiftyIntArray);

            Console.WriteLine("\n************End Arrays*************** \n");
            #endregion

            #region Lists
            Console.WriteLine("************Start Lists**************");

            /*   Set Up   */
            //TODO: Create an integer List
            List<int> listOfInts = new List<int>();

            //TODO: Print the capacity of the list to the console
            Console.WriteLine(listOfInts.Capacity);

            //TODO: Populate the List with 50 random numbers between 0 and 50 you will need a method for this            
            Populater(listOfInts);

            //TODO: Print the new capacity
            Console.WriteLine(listOfInts.Capacity);

            Console.WriteLine("---------------------");

            //TODO: Create a method that prints if a user number is present in the list
            //Remember: What if the user types "abc" accident your app should handle that!
            Console.WriteLine("What number will you search for in the number list?");

            bool canParse = false;
            do
            {
                canParse = int.TryParse(Console.ReadLine(), out int userNumber);
                if (canParse == true)
                {
                    NumberChecker(listOfInts, userNumber);
                }
                else
                {
                    Console.WriteLine("This is not a valid number. Try again");
                }
            } while (canParse == false);
            

            Console.WriteLine("-------------------");

            Console.WriteLine("All Numbers:");
            //UNCOMMENT this method to print out your numbers from arrays or lists
            NumberPrinter(listOfInts);
            Console.WriteLine("-------------------");


            //TODO: Create a method that will remove all odd numbers from the list then print results
            Console.WriteLine("Evens Only!!");
            OddKiller(listOfInts);
            
            Console.WriteLine("------------------");

            //TODO: Sort the list then print results
            Console.WriteLine("Sorted Evens!!");
            listOfInts.Sort();
            foreach (int num in listOfInts)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("------------------");

            //TODO: Convert the list to an array and store that into a variable
            int[] listArray = listOfInts.ToArray();

            //TODO: Clear the list
            listOfInts.Clear();

            #endregion
        }

        private static void ThreeKiller(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 3 == 0)
                {
                    numbers[i] = 0;
                }
                Console.WriteLine(numbers[i]);
            }
        }

        private static void OddKiller(List<int> numberList)
        {
            //for (int i = 0; i < numberList.Count; i++)
            //{
            //    if (numberList[i] % 2 != 0)
            //    {
            //        numberList.Remove(numberList[i]);
            //    }
            //    else
            //    {
            //        Console.WriteLine(numberList[i]);
            //    }
                
            //}



            //List<int> temp = new List<int>();
            //for (int i = 0; i < numberList.Count; i++)
            //{
            //    if (numberList[i] % 2 == 0)
            //    {
            //        temp.Add(numberList[i]);
            //    }
            //}
            //numberList = temp;
            //foreach (int num in numberList)
            //{
            //    Console.WriteLine(num);
            //}



            List<int> temp = new List<int>();
            for (int i = 0; i < numberList.Count; i++)
            {
                if (numberList[i] % 2 != 0)
                {
                    temp.Add(numberList[i]);
                }
            }
            for (int i = 0; i < temp.Count; i++)
            {
                numberList.Remove(temp[i]);
            }
            foreach (int num in numberList)
            {
                Console.WriteLine(num);
            }
        }

        private static void NumberChecker(List<int> numberList, int searchNumber)
        {
            int timesInList = 0;

            
                if (searchNumber >= 0 && searchNumber < 51)
                {
                    foreach (int num in numberList)
                    {
                        if (searchNumber == num)
                        {
                            timesInList++;
                        }
                    }
                    if (timesInList == 1)
                    {
                        Console.WriteLine($"Your number was in the list {timesInList} time");
                    }
                    else
                    {
                        Console.WriteLine($"Your number was in the list {timesInList} times");
                    }
                }
            else
            {
                Console.WriteLine("This is not a valid number");
            }
        }

        private static void Populater(List<int> numberList)
        {
            Random rng = new Random();
            for (int i = 0; i < 50; i++)
            {
                numberList.Add(rng.Next(0, 51));
            }

        }

        private static void Populater(int[] numbers)
        {
            Random rng = new Random();
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rng.Next(0, 51);
            }
            

        }        

        private static void ReverseArray(int[] array)
        {
            for (int i = 49; i >= 0; i--)
            {
                Console.WriteLine(array[i]);
            }
        }

        /// <summary>
        /// Generic print method will iterate over any collection that implements IEnumerable<T>
        /// </summary>
        /// <typeparam name="T"> Must conform to IEnumerable</typeparam>
        /// <param name="collection"></param>
        private static void NumberPrinter<T>(T collection) where T : IEnumerable<int>
        {
            //STAY OUT DO NOT MODIFY!!
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
