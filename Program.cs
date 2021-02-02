using System;

namespace BFS
{
    class Program
    {
        static void Main(string[] args)
        {

            int[,] input = GraphHelper.Parse(@".\input.txt");
            Graph graph = new Graph(input);

            graph.BFS();
            graph.PrintTree();
        }
    }
}