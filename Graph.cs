using System;
using System.Collections.Generic;

namespace BFS
{
    public class Graph
    {
        int[,] adjMatrix;

        Vertex[] vertexes;

        public Graph(int[,] input)
        {
            adjMatrix = input;
            int vertexCount = adjMatrix.GetLength(0);

            vertexes = new Vertex[vertexCount];

            for (int i = 0; i < vertexCount; i++)
            {
                vertexes[i] = new Vertex(Color.WHITE, null, i, int.MaxValue);
            }
        }

        public void BFS()
        {
            Queue<Vertex> queue = new Queue<Vertex>();

            vertexes[1].Color = Color.GRAY;
            vertexes[1].Distance = 0;
            vertexes[1].Parent = null;

            queue.Enqueue(vertexes[1]);

            while (queue.Count != 0)
            {
                Vertex current = queue.Dequeue();

                for (int i = 0; i < vertexes.Length; i++)
                {
                    if (adjMatrix[current.Number, i] == 1 && vertexes[i].Color == Color.WHITE)
                    {
                        queue.Enqueue(vertexes[i]);

                        vertexes[i].Color = Color.GRAY;
                        vertexes[i].Parent = current;
                        vertexes[i].Distance = current.Distance + 1;
                    }

                    current.Color = Color.BLACK;
                }
            }
        }

        public void PrintTree()
        {
            Array.Sort<Vertex>(vertexes);

            for (int i = 0; i < vertexes.Length; i++)
            {
                Vertex[] selected = Array.FindAll<Vertex>(vertexes, v => v.Distance == i);

                Console.WriteLine($"Level: {i}");

                foreach (var v in selected)
                {
                    Console.WriteLine($"{v.Label}-->{v.Parent?.Label ?? '0'}");
                }

                Console.WriteLine("---------------------------------------------");
            }
        }
    }
}
