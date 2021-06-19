using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FindNumberByScalling
{
    /// <summary>
    /// Ask users about whether number is corrected until get to their numbers
    /// </summary>
    class NumberGuesses
    {
        #region Public Properties
        /// <summary>
        /// Minimum number is assigned from the beginning
        /// </summary>
        public int MinimumNumber { get; set; }
        /// <summary>
        /// Current minimum number while program is running 
        /// </summary>
        public int CurrentGuessMin { get; set; }
        /// <summary>
        /// Current Maximum number while program is running  
        /// </summary>
        public int CurrentGuessMax { get; set; }
        /// <summary>
        /// Total number of guesses in the program
        /// </summary>
        public int TotalGuesses { get; set; }
        /// <summary>
        /// Maximum number is assigned from the beginning 
        /// </summary>
        public int MaximumNumber { get; set; }
        #endregion

        #region Ctor
        public NumberGuesses()
        {
            this.MaximumNumber = 100;
        }
        #endregion
        #region Methods
        public string getResponse(int guessMin, int guessMax)
        {
            Console.WriteLine($"Is your number is between {guessMin}, and {guessMax}");
            return Console.ReadLine();
        }
        /// <summary>
        /// boolean function to find valid resonse
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>

        public bool boolResponse(string response)
        {
            return response?.ToLower().FirstOrDefault() == 'y';
        }
        /// <summary>
        /// function to get respone when only have two values
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        
        public bool isNumber(int num)
        {
            Console.WriteLine($"Is {num} the number ? ");
            string response = Console.ReadLine();
            if (boolResponse(response)) { return true; }
            return false;
        }
        /// <summary>
        /// fucntion to inform the last number 
        /// </summary>
        /// <param name="num"></param>
        /// <param name="guesses"></param>
        
        public void result(int num, int guesses)
        {
            Console.WriteLine($"Number is {num}");
            Console.WriteLine($"You have made {guesses}");
        }
        /// <summary>
        /// Program to find the user Number
        /// </summary>
        public void FindNumber()
        {
            this.MaximumNumber = 100;
            this.CurrentGuessMax = 0;
            this.CurrentGuessMin = 0;
            this.MinimumNumber = 0;
            this.TotalGuesses = 0;
            string response;
            while (this.CurrentGuessMin != this.MaximumNumber)
            {
                // keep tracking all the guesses
                this.TotalGuesses++;
                this.CurrentGuessMax = this.MaximumNumber;
                response = getResponse(this.CurrentGuessMin, this.CurrentGuessMax);
                if (boolResponse(response))
                {
                    this.CurrentGuessMax = this.MaximumNumber - ((this.MaximumNumber - this.CurrentGuessMin) / 2);
                    this.MaximumNumber = this.CurrentGuessMax;
                }
                else
                {
                    int difference = (int)(Math.Ceiling((this.MaximumNumber - this.CurrentGuessMin) / 2f));
                    this.CurrentGuessMin = this.CurrentGuessMax + 1;
                    this.CurrentGuessMax = this.MaximumNumber + difference;
                    this.MaximumNumber = this.CurrentGuessMax;
                }
                // When guessMax and guessMin only have 1 different in value
                if (this.MaximumNumber == this.CurrentGuessMin + 1)
                {
                    this.TotalGuesses++;
                    response = getResponse(this.CurrentGuessMin, this.MaximumNumber);
                    if (boolResponse(response))
                    {
                        if (isNumber(this.CurrentGuessMin))
                        {
                            this.TotalGuesses++;
                            break;
                        }
                        else
                        {
                            this.TotalGuesses++;
                            this.CurrentGuessMin = this.MaximumNumber;
                            break;
                        }
                    }
                }

            }
            result(this.CurrentGuessMin, this.TotalGuesses);
        }
        #endregion
    }
}
