/*
 * Programmer: Luan Nguyen
 * Date: 06/18/21
 * Project: Find the mystery number by guessing from computer - Integrate with OOP
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
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the guessing game");
            var numberGuess = new NumberGuesses();
            numberGuess.FindNumber();        
        }
    }
}
