using System;

namespace NestDepth
{
    class Program
    {

        public static int DepthOfNesting(string s)
        {
            int open = 0;
            int closed = 0;
            foreach (char c in s) {
                if (c == '(') {
                    open++;
                } else if (c == '(') { 
                    closed++;
                }
             }

            // Check the open and close parenthesis count. if they
            // are not equal we have an unmatched parenthesis.
            // Note: This is the first phase of mismatch checking.
            if(open != closed)
            {
                Console.WriteLine("0");
                return 0;
            }
            int highestDepthCount = 0;
            int currentDepthCount = 0;
            foreach(char letter in s){
                if(letter == '('){
                    currentDepthCount++;
                }else if(letter == ')'){
                    // if the current depth count is zero or below
                    // then we have a mismatched closed parenthesis.
                    if(currentDepthCount <= 0){
                        Console.WriteLine("0");
                        return 0;
                    }else{
                        currentDepthCount--;
                    }
                }

                if(highestDepthCount < currentDepthCount){
                    highestDepthCount = currentDepthCount;
                }
            }

            Console.WriteLine(highestDepthCount);
            return highestDepthCount;
        }


        static void Main(string[] args)
        {
            string s = "a(())b()";
            DepthOfNesting(s);
        }
    }
}
