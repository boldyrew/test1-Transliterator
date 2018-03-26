using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transliterator;

namespace TransliteratorClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Transliterator.Transliterator tl = new Transliterator.Transliterator();

            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            Console.Write("Input: ");
            string inp = Console.ReadLine();

            

            string result = tl.GetTransliteratedWord(inp);

            Console.Write("\nOutput: " + result);

            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
