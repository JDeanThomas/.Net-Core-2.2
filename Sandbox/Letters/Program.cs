using System;

namespace Letters
{
    class Program
    {
        public static string Reversal(string s)
        {
            var letters = s.ToCharArray();
            var firstLetter = letters[0];
            var lastLetter = letters[letters.Length -1];

            Array.Reverse(letters);
            letters[0] = firstLetter;
            letters[letters.Length - 1] = lastLetter;
            Console.WriteLine(new string(letters));
            return new string(letters);
        }

        static void Main(string[] args)
        {
            var s = "abcad";
            Reversal(s);
        }
    }
}
