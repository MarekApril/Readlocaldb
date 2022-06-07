using System;
using System.Data;

namespace ReadingDataFromDb
{
    class Program
    {
        static void Main(string[] args)
        {
            var example = new Example();
            var result = example.GetValues(1);

            Console.WriteLine(result);
        }
    }
}


