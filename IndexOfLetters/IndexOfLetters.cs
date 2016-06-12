using System;

    class IndexOfLetters
    {
        static void Main()
        {

            string[] alphabetArray = new string[26];
            Console.WriteLine("Please enter a word:");
            string word = Console.ReadLine();

            for (int i = 0; i < 26; i++)
            {
                alphabetArray[i] = Convert.ToString(Convert.ToChar(i + 65));
            }
            Console.WriteLine();
            for (int i = 0; i < word.Length; i++)
            {
                PrintIndexOfLetter(alphabetArray, word, i);
            }
        }
        private static void PrintIndexOfLetter(string[] alphabetArray, string word, int indexToStart)
        {
            word = word.ToUpper();
            for (int i = 0; i < 26; i++)
            {
                if (Convert.ToString(word[indexToStart]) == alphabetArray[i])
                {
                    Console.WriteLine("{0}->{1}", word[indexToStart], i);
                    return;
                }
            }
            Console.WriteLine("Error - Not a letter!");
        }
    }
