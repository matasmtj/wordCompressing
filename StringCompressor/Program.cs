using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StringCompressor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter word:");
            string word = Console.ReadLine();
            StringBuilder compressedWord = WordCompression(word);
            Console.WriteLine("Compressed word: " + compressedWord);
            StringBuilder decompressedWord = WordDecompression(compressedWord);
            Console.WriteLine("Decompressed word: " + decompressedWord);

        }

        private static StringBuilder WordCompression(string word)
        {

            StringBuilder newWord = new StringBuilder();
            int length = word.Length;
            if (length == 0) return newWord;
            int count = 1; // var for counting repeating characters            
            char prev = word[0];

            for (int i = 1; i < length; i++) //cycling through the word
            {
                if (word[i] == prev)
                    count++; // if letter repeats, increase the counter
                else
                {
                    newWord.Append(prev).Append(count);// if letter changed, add it and its counter to the newWord
                    prev = word[i];
                    count = 1;
                }
            }

            //appending the last letter
            newWord.Append(prev).Append(count);

            return newWord;
        }
        private static StringBuilder WordDecompression(StringBuilder word)
        {
            StringBuilder newWord = new StringBuilder();
            StringBuilder number = new StringBuilder(); // number is the string of current (possibly multidigit) number
           
            int currNumber, count;
            char lastLetter = word[0];

            for (int i = 1; i < word.Length; i++)
            {
                // TryParse is used for safety
                if (int.TryParse(word[i].ToString(), out currNumber))  // if current char is a number
                {
                    number.Append(currNumber);
                }
                else if (int.TryParse(number.ToString(), out count)) // if current char is a letter
                {
                    newWord.Append(lastLetter, count);
                    number.Clear();
                    lastLetter = word[i];
                }
            }
            int.TryParse(number.ToString(), out count);
            newWord.Append(lastLetter, count);

            return newWord;
        }
    }
}
