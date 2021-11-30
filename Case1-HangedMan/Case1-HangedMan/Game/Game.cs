// !!! No using other than System are authorized !!!

using System;

namespace Case1_HangedMan.Game
{
    public static class Game
    {
        // This is a private global variable accessible from everywhere within this file
        // You can give as an argument of Loader.GetWord() the path to the word_bank.txt
        // By default if no argument is given the path will be at the root of the TP1 folder
        // If you want to have a go at reading from another word bank file, give as an 
        // argument the path of that file. (ex: to use the word bank with the ACDC's logins,
        // call the function Loader.GetWord with the argument "../../../Game/acdc_logins.txt")
        private static readonly string WordToGuess = Loader.GetWord();
        
        /*
         * TODO implement this function
         * This function gets the user input from the console and return a char
         * The input must be a single letter (upper or lowercase)
         * The output must be a single lowercase letter (you can use Char.IsLetter() or your own functions)
         * In the case of an error, you must print an error message on the stderr and return 0 using an explicit cast
         */
        public static char GetInput()
        {
            string input = Console.ReadLine();
            char inputchar = Convert.ToChar(input);
            {
                if (input.Length is > 1 or 0 || !char.IsLetter(input[0]))
                {
                    Console.Error.WriteLine("Invalid Argument");
                    return '0';
                }
                
                if (inputchar <= 90)
                {
                    inputchar = (char) (@inputchar + 32);
                    return inputchar;
                }
                return inputchar;

            }
        }

        /*
         * TODO implement this function
         * This function clears the console and prints the 2 arguments
         * You should loop through the array guessedWord and print each char.
         */
        public static void DisplayWord(char[] guessedWord, string usedLetters)
        {
            Console.Clear();
            int len = guessedWord.Length;
            int i = 0;
            Console.Write("Your guess : ");
            while (i < len)
            {
                Console.Write(guessedWord[i]);
                i++;
            }
            Console.Write(" " + ", Used Letters: " + usedLetters);
        }

        /*
         * TODO implement this function
         * This function displays the hangman according to the gameState and the current errorCount (usedLetters.Length)
         * The hangman ascii is found in Loader.Ascii, it is an array with the different states to display
         *      case gameState Loader.GameState.RUNNING: print the hangman according to the number of wrong letters
         *      case gameState Loader.GameState.LOST: print the the hangman at index Loader.DEFEAT in Loader.Ascii
         *      case gameState Loader.GameState.WON: print the the hangman at index Loader.VICTORY in Loader.Ascii
         */
        public static void DisplayHangman(string usedLetters, Loader.GameState gameState)
        {
            int count = usedLetters.Length;
            Console.WriteLine(Loader.Ascii[count]);
            if (gameState == Loader.GameState.WON)
                Console.WriteLine(Loader.Ascii[Loader.Defeat]);
            else if (gameState == Loader.GameState.LOST)
                Console.WriteLine(Loader.GameState.LOST);
        }

        /*
         * TODO implement this function
         * This function returns a bool whether the letter is contained in guessedWord
         */
        public static bool ContainsLetter(char[] guessedWord, char letter)
        {
            int i = 0;
            int len = WordToGuess.Length;
            while (i < len)
            {
                if (guessedWord[i] == letter)
                {
                    return true;
                }

                i++;
            }
            return false;
        }
        
        /*
         * TODO implement this function
         * This function returns the string of usedLetters updated
         * If the letter was already guess or if the letter was already used, print an error on stderr and return
         * usedLetters unchanged
         * If the letter is in the the WordToGuess, update the guessedWord array and leaves usedLetters unchanged
         * else add it to the usedLetters string
         * To check if the letter is contained in usedLetter you can use String.Contains() function 
         * To check if the letter is contained in guessedWord you should use ContainLetter
         * (you may also use 'new string()' but ContainsLetter will be expected and tested)
         * At the end call DisplayWord and DisplayHangman and return usedLetters
         */
        public static string ValidateLetter(char[] guessedWord, string usedLetters, char letter,
            Loader.GameState gameState)
        {
            int n = 0;
            int len = WordToGuess.Length;
            if (usedLetters.Contains(letter))
            {
                Console.Error.Write("This letter was already used");
                return usedLetters;
            }

            if (ContainsLetter(guessedWord, letter))
                Console.Error.Write("This letter was already guessed");
            else
            {
                while (n < len)
                {
                    if (WordToGuess[n] == letter)
                        guessedWord[n] = letter;
                    n++;
                }

            }

            if (!WordToGuess.Contains(letter))
                usedLetters += letter;

            DisplayWord(guessedWord, usedLetters);
            DisplayHangman(usedLetters, gameState);
            return usedLetters;
        }

        /*
         * TODO implement this function
         * This function returns the state of the game
         * If the number of letters in usedLetters is greater or equal to the number of attempts then the user lost
         * If the WordToGuess and guessedWord are equal then the user won
         * Otherwise, keep running the game
         */
        public static Loader.GameState GameStatus(char[] guessedWord, string usedLetters, int attempts)
        {
            int len = usedLetters.Length;
            string wordGuessed = new string(guessedWord); ;
            int length = WordToGuess.Length;
            if (8<=attempts+len)
                return Loader.GameState.LOST;
            if (wordGuessed == WordToGuess)
                return Loader.GameState.WON;
            return Loader.GameState.RUNNING;
        }

        /*
         * TODO implement this function
         * This function calls DisplayWord, DisplayHangman and displays a victory or defeat message
         * In case of a defeat, print the WordToGuess
         */
        public static void EndScreen(char[] guessedWord, string usedLetters, Loader.GameState gameState)
        {
            Console.WriteLine("The word was "+WordToGuess);
            if (gameState == Loader.GameState.WON)
                Console.WriteLine("Congrats ! You found the word !");
            if (gameState == Loader.GameState.LOST)
                Console.WriteLine("Bruh, you lost...");
            
        }
        
        /*
         * TODO implement this function
         * This function must initialise the variables used in the game:
         *      The gameState must be initialized to Loader.GameState.RUNNING
         *      The number of attempts is defined in Loader.Attempts
         *      The errorCount (usedLetters) must be initialized to an empty string
         *      Moreover, guessedWord can be initialised using Loader.GetEmptyDuplicate(WordToGuess);
         * The game must run as follows:
         *      Print the word and the hangman. While the game has to run, ask for an input.
         *      If the output is invalid, loop again else and update the variables.
         *      Upon exiting the loop, print the correct end message according to the gameState
         */
        public static void LaunchGame()
        {
            int len = WordToGuess.Length;
            char[] guessedWord = Loader.GetEmptyDuplicate(WordToGuess);
            string usedLetters = "";
            Loader.GameState gameState = Loader.GameState.RUNNING;
            int attempts = Loader.Attempts-Loader.Attempts;
            

            DisplayWord(guessedWord, usedLetters);
            DisplayHangman(usedLetters, gameState);
            while (gameState == Loader.GameState.RUNNING)
            {
                Console.Write("Guess a letter: ");
                char letter = GetInput();
                if (letter != '\0')
                {
                    usedLetters = ValidateLetter(guessedWord, usedLetters, letter, gameState);
                    gameState = GameStatus(guessedWord, usedLetters, attempts);
                }

            }

            EndScreen(guessedWord, usedLetters, gameState);
        }
    }
}