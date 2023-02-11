using System;
using System.Collections.Generic;
using System.Linq;

namespace WordRemover
{
    class Reference
    {
        private string _referenceText;

        public Reference(string referenceText)
        {
            _referenceText = referenceText;
        }

        public string GetReferenceText()
        {
            return _referenceText;
        }
    }

    class Scripture
    {
        private string _scriptureText;

        public Scripture(string scriptureText)
        {
            _scriptureText = scriptureText;
        }

        public string GetScriptureText()
        {
            return _scriptureText;
        }
    }

    class Word
    {
        private List<string> _words;

        public Word(string scriptureText)
        {
            _words = scriptureText.Split(' ').ToList();
        }

        public List<string> GetWords()
        {
            return _words;
        }

        public void RemoveWords(int count)
        {
            Random random = new Random();

            for (int i = 0; i < count; i++)
            {
                int index = random.Next(_words.Count);
                _words[index] = "___";
            }
        }

        public void ReplaceWords()
        {
            Console.WriteLine(string.Join(" ", _words));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Reference reference = new Reference("Jeremiah 17:7");
            Scripture scripture = new Scripture("Blessed is the man that trusteth in the Lord, and whose hope the Lord is.");
            Word word = new Word(scripture.GetScriptureText());

            Console.WriteLine("Reference: " + reference.GetReferenceText());
            Console.WriteLine("Scripture: " + scripture.GetScriptureText());

            int count = word.GetWords().Count;

            while (count > 0)
            {
                Console.WriteLine("Enter the number of words to remove (or 'quit' to exit):");
                string input = Console.ReadLine();

                if (input.ToLower() == "quit")
                {
                    break;
                }

                int numberOfWords;
                if (int.TryParse(input, out numberOfWords) && numberOfWords >= 0 && numberOfWords <= count)
                {
                    word.RemoveWords(numberOfWords);
                    count -= numberOfWords;
                    word.ReplaceWords();
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 0 and " + count + " or 'quit'.");
                }
            }
        }
    }
}