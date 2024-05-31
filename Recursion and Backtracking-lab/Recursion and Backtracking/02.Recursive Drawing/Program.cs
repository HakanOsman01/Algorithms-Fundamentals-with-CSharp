using System;
using System.Linq;
using System.Text;

namespace _02.Recursive_Drawing
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int n=int.Parse(Console.ReadLine());
           StringBuilder sb = new StringBuilder();
            DrawFigure(n,sb);
        }

        private static void DrawFigure(int n, StringBuilder sb)
        {

            if (n <= 0)
            {
                return;
            }
            string topFigure = new string('*', n);
            Console.WriteLine(topFigure);
            DrawFigure(n-1,sb);
            string downFigure = new string('#', n);
            Console.WriteLine(downFigure);

        }
    }
}