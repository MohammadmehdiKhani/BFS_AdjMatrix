using System.IO;

namespace BFS
{
    public static class GraphHelper
    {
        public static int[,] Parse(string path)
        {
            string input = File.ReadAllText(path);
            string[] rows = input.Split('\n');
            int vertexCount = rows.Length;

            int[,] result = new int[vertexCount, vertexCount];

            for (int i = 0; i < vertexCount; i++)
            {
                string[] cols = rows[i].Split(' ');

                for (int j = 0; j < vertexCount; j++)
                {
                    result[i, j] = int.Parse(cols[j]);
                }
            }
            return result;
        }
    }
}