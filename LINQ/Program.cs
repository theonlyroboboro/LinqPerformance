using System.ComponentModel;
using System.Diagnostics;

namespace LINQ
{
    internal class Program
    {
        private static Random random = new Random();
        private static int[] ints = new int[] { };
        private static Stopwatch stopWatch = new Stopwatch();
      
        static void Main(string[] args)
        {
            Spinner.Start();

            GetIntegers(10000000);

            stopWatch.Reset();
            LinqExIt();

            stopWatch.Reset();
            LinqIt();
                       
            Spinner.Stop();

            Console.Read();
        }

        static void LinqIt()
        {
            stopWatch.Start();

            //var result = from i in ints
            //             where i > 500
            //             select i;
            var result = from i in ints
                         where i > 500
                         select new { id = Guid.NewGuid(), value = i };

            stopWatch.Stop();


            Console.WriteLine();
            Console.WriteLine($"It took {stopWatch.Elapsed.ToString("mm\\:ss\\.ff")} for linq");
        }

        static void LinqExIt()
        {
            stopWatch.Start();

            //var result = ints.Where(i => i > 500).Select(i => i).ToList();
            
            //var result = ints.Where(i => i > 500).ToList();
            
            var result = ints.Where(i => i > 500).Select(i => new { id = Guid.NewGuid(), value = i }).ToList();

            stopWatch.Stop();

            Console.WriteLine();
            Console.WriteLine($"It took {stopWatch.Elapsed.ToString("mm\\:ss\\.ff")} for linq ex");
        }

        static void GetIntegers(int numberOfInts)
        {
            ints = new int[numberOfInts];
            for (var i = 0; i < numberOfInts; i++)
            {
                ints[i] = random.Next(1, numberOfInts);
            }
        }
    }
}