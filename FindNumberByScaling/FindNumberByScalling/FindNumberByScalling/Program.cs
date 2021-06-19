/*
 * Programmer: Luan Nguyen
 * Date: 06/18/21
 * Project: Find the mystery number by guessing from computer
 */ 
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FindNumberByScalling
{
    
    class Program
    {
        // member functions to get the response from user
        static string getResponse(int guessMin, int guessMax)
        {
            Console.WriteLine($"Is your number is between {guessMin}, and {guessMax}");
            return Console.ReadLine();
        }
        // boolean function to find valid resonse
        static bool boolResponse(string response)
        {
            return response?.ToLower().FirstOrDefault() == 'y';
        }
        // function to get respone when only have two values
        static bool isNumber(int num)
        {
            Console.WriteLine($"Is {num} the number ? ");
            string response = Console.ReadLine();
            if (boolResponse(response)) { return true; }
            return false;
        }
        // fucntion to inform the last number 
        static void result(int num, int guesses)
        {
            Console.WriteLine($"Number is {num}");
            Console.WriteLine($"You have made {guesses}");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the guessing game");
            // Declares some variables
            int min = 0, guessMin = 0, guessMax = 100, guesses = 0, max = 100;
            string response;
            while (guessMin != max)
            {
                // keep tracking all the guesses
                guesses++;
                //guessMax = max;
                response = getResponse(guessMin, guessMax);
                if (boolResponse(response))
                {
                    guessMax = max - ((max - guessMin) / 2);
                    max = guessMax;
                }
                else
                {  
                    int difference = (int)(Math.Ceiling(( max - guessMin) / 2f));
                    guessMin = guessMax + 1;
                    guessMax = max + difference;
                    max = guessMax;
                }
                // When guessMax and guessMin only have 1 different in value
                if (max == guessMin + 1)
                {
                    guesses++;
                    response = getResponse(guessMin, max);
                    if (boolResponse(response))
                    {
                        if (isNumber(guessMin))
                        {
                            guesses++;
                            break;
                        }
                        else
                        {
                            guesses++;
                            guessMin = max;
                            break;
                        }
                    }
                }   
                
            }
            result(guessMin, guesses);
        }
    }
}
