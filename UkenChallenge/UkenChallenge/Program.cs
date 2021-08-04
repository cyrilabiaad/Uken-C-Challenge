using System;
using System.IO;
using System.Collections.Generic;

namespace UkenChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            String s0, s1, s2, s3, s4, s5;
           // s0 = "C:\\Users\\cyril\\source\\repos\\UkenChallenge\\UkenChallenge\\src\\test.txt";
            s1 = "C:\\Users\\cyril\\source\\repos\\UkenChallenge\\UkenChallenge\\src\\1.txt";
            s2 = "C:\\Users\\cyril\\source\\repos\\UkenChallenge\\UkenChallenge\\src\\2.txt";
            s3 = "C:\\Users\\cyril\\source\\repos\\UkenChallenge\\UkenChallenge\\src\\3.txt";
            s4 = "C:\\Users\\cyril\\source\\repos\\UkenChallenge\\UkenChallenge\\src\\4.txt";
            s5 = "C:\\Users\\cyril\\source\\repos\\UkenChallenge\\UkenChallenge\\src\\5.txt";

          //  getNumbers(s0);
            getNumbers(s1);
            getNumbers(s2);
            getNumbers(s3);
            getNumbers(s4);
            getNumbers(s5);
        }

        public static void getNumbers(string s) {
            var dict = new Dictionary<int, int>();
            int[] arr = convertToArray(s);
            foreach (var value in arr)
            {
                if (dict.ContainsKey(value))
                    dict[value]++;
                else
                    dict[value] = 1;
            }
            int largestKey = 0, largestValue = 0;
            foreach(var pair in dict)
            {
                if (pair.Value > largestValue) {
                    largestValue = pair.Value;
                    largestKey = pair.Key;
                }
                else if (pair.Value == largestValue){
                    if (pair.Key < largestKey)
                        largestKey = pair.Key;
                }
            //    Console.WriteLine("{0} = {1} time(s)", pair.Key, pair.Value);

            }
            var textfile = s.Substring(s.Length - 5);
            Console.WriteLine("For " + textfile + ", The number is: " + largestKey + " and it is repeated " + largestValue + " times");

        
        }
        public static int[] convertToArray(String path)
        {
            String line;
            int lines = File.ReadAllLines(path).Length;
            int[] result = new int[lines];
            
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(path);
            try
            {
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                int index = 0;
                while (line != null)
                {

                    int x = Int32.Parse(line);
                    result[index] = x;
                    index++;

                    //write the lie to console window
                    //Read the next line
                    line = sr.ReadLine();
                }
                sr.Close();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return result;
            }
            


        }
    }
}
