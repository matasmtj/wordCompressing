using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCompressor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter word:");
            string word=Console.ReadLine();
            string compressedWord = WordCompression(word);
            Console.WriteLine("Compressed word: " + compressedWord);
            string decompressedWord=WordDecompression(compressedWord);
            Console.WriteLine("Decompressed word: " + decompressedWord);
        }
        private static string WordCompression(string word) {

            int length = word.Length;
            if (length == 0) return word;
            int count = 1; // var for counting repeating characters
            string newWord="";
            char prev=word[0]; //prev character
            for (int i = 1; i < length; i++) //cycling through the word
            {
                if (word[i] == prev) count++; // if letter repeats, increase the counter
                else
                {
                    newWord = newWord + prev + count; // if letter changed, add it and its counter to the newWord
                    prev = word[i];
                    count = 1;
                }
            }
            //checking the last letter
            if (word[length-1] == prev) newWord = newWord + prev + count;
                else newWord = newWord + word[length - 1] + 1;

            return newWord;
        }
        private static string WordDecompression(string word)
        {
            int length = word.Length;
            if (length == 0) return word;
            string newWord = "";
            for (int i = 0; i < length; i=i+2) // it's known that every second char is a letter and the other is its count
            {
                int charToInt = word[i + 1] - '0'; // since word[i+1] is taken as char from the word, to get its integer value you have to minus the '0' as char
                for (int j = 0; j < charToInt; j++)//multpiplying the letter by its count
                {
                    newWord += word[i];
                }
            }

            return newWord;
        }
    }
}
