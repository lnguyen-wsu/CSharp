// Programmer: Luan Nguyen
/* App Requirements:
Must be created using C#
Allow user string input up to 256 characters
Take the user input and print out a list of the English alphabet minus any character used in the user input
Provide a total count of how many letters are printed in the list
 */
using System;
namespace Find_Number_Input
{
    class Program
    {
        // member function (1) to get user input
        static string getInput()
        {
            Console.WriteLine("Please input below:::");
            string userInput = Console.ReadLine();
            string subInput = "";
            // run the loop to get 256 characters in the userInput
            for (int i = 0; i < userInput.Length; i++)
            {    if (i < 256)
                {
                    subInput = subInput + userInput[i];
                }
            }
            return subInput;
        }
        // member function (2) to check each character to make sure it is not in the userInput
        static bool check(string userInput, char y)
        {
            for ( int i = 0; i < userInput.Length; i++)
            {
                if (y == userInput[i]) { return false; }                 // false if it is same 
            }
            return true;                                                 // true if it is different 
        }
        // member function (3) to print out the remaining of alphabet after eliminating userInput and count number also 
        static void printOut(string userInput)
        {
            string alphabet = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz";
            string result = "";
            for (int i = 0; i < alphabet.Length; i++)
            {
                if (check(userInput, alphabet[i])) { result = result + alphabet[i]; }
            }
            Console.Write("After eliminating, we have remaining English Alphabet as::: ");
            Console.WriteLine(result);
            Console.Write("Length of result is : ");
            Console.WriteLine(result.Length);
        }
        static void Main(string[] args)
        {
            string userInput = getInput();
            Console.Write("User input is:: ");
            Console.WriteLine(userInput);
            printOut(userInput);
        }

    }
}
