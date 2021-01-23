using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUILibrary
{
    public struct EasyCW
    {
        /// <summary>
        /// Write all member of the array in Console.Writeline()
        /// </summary>
        public void CWStringArray(string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }

        /// <summary>
        /// Wants to user enter a name and checks for confirmation
        /// </summary>
        /// <returns>Input name</returns>
        public string GetUserName()
        {
            ConsoleKey response;
            string userName;
            do
            {
                Console.Write("Please Enter Your Name: ");
                userName = Console.ReadLine();
                do
                {
                    Console.Write($"Do you want to change this name? [{ userName }] [y/n] ");
                    response = Console.ReadKey(false).Key;
                    if (response != ConsoleKey.Enter)
                        Console.WriteLine("\n");
                } while (response != ConsoleKey.Y && response != ConsoleKey.N);
                Console.Clear();
            } while (response != ConsoleKey.N);

            return userName;
        }
    }
}