using System.Drawing;

namespace AlhoritmsLab2
{
    public class Vertex
    {
        public int Id { get; private set; }
        public int Degree { get; private set; }
        public string Name { get; set; }
        public int Color { get; set; }
        public List<Vertex> Neighbours { get; set; }
        public Vertex(int id, int degree, string name)
        {
            Id = id;

            if (degree < 0)
                degree = 0;

            Degree = degree;
            Name = name;
            Color = -1;
            Neighbours = new List<Vertex>();
        }
        public Vertex(int id, int degree)
        {
            Id = id;

            if (degree < 0)
                degree = 0;

            Degree = degree;
            Name = id.ToString();
            Color = -1;
            Neighbours = new List<Vertex>();
        }
        public bool HasNeighborsWithColour(int color)
        {
            foreach (var neighbor in Neighbours)
            {
                if (neighbor.Color == color)
                    return true;
            }
            return false;
        }
    }
    public static class WelshPowellAlgorithm
    {
        public static Vertex[] Paint(Vertex[] graph)
        {
            Vertex[] paintedGraph = (Vertex[])graph.Clone();

            var sortedVertevies = from vertex in paintedGraph orderby vertex.Degree descending select vertex;
            for (int i = 0; i < paintedGraph.Length; i++)
            {
                if (i == 0)
                    sortedVertevies.ElementAt(0).Color = 0;

                for (int j = i; j < sortedVertevies.Count(); j++)
                    if(!sortedVertevies.ElementAt(j).HasNeighborsWithColour(i) && sortedVertevies.ElementAt(j).Color == -1)
                        sortedVertevies.ElementAt(j).Color = i;
            }
            return paintedGraph;
        }
    }
    public static class InTurnAlgorithm
    {
        public static Vertex[] Paint(Vertex[] graph)
        {
            Vertex[] paintedGraph = (Vertex[])graph.Clone();
            foreach (var vertex in paintedGraph)
            {
                int i = 0;
                while (vertex.Color == -1)
                {
                    if (!vertex.HasNeighborsWithColour(i))
                    {
                        vertex.Color = i;
                        break;
                    }
                    i++;
                }
            }

            return paintedGraph;
        }
    }

    internal class Program
    {
        public static bool TrySetVerticesNames(Vertex[] graph)
        {
            Console.WriteLine("File path: ");
            string path = Console.ReadLine();

            if (!File.Exists(path))
            {
                Console.WriteLine("File doesnt exist");
                return false;
            }

            try
            {
                string[] strings = File.ReadAllLines(path);

                if (strings.Length != graph.Length)
                {
                    Console.WriteLine("The number of vertices and the number of names do not match!");
                    return false;
                }

                for (int i = 0; i < graph.Length; i++)
                {
                    graph[i].Name = strings[i];
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        public static bool TryGetAdjacencyMatrix(out int[,] matrix)
        {
            Console.WriteLine("Input adjacency matrix file path (vertex indices will depend on it): ");
            string path = Console.ReadLine();
            matrix = null;

            if (!File.Exists(path))
            {
                Console.WriteLine("File doesnt exist");
                return false;
            }

            List<string> tempList = new List<string>();
            tempList = File.ReadAllLines(path).ToList();
            int xCount = tempList.Count;
            if (xCount <= 0)
            {
                Console.WriteLine("Invalid matrix!");
                return false;
            }

            int yCount = tempList[0].Split(" ").Length;
            if (yCount == 0)
            {
                Console.WriteLine("Invalid matrix!");
                return false;
            }

            if (xCount != yCount)
            {
                Console.WriteLine("Мatrix is not square!");
                return false;
            }

            int[,] array = new int[xCount, yCount];

            try
            {
                for (int i = 0; i < xCount; i++)
                {
                    var temp = tempList[i].Split(" ");

                    if (temp.Length != yCount)
                    {
                        Console.WriteLine("Мatrix is not square!");
                        return false;
                    }

                    for (int j = 0; j < temp.Length; j++)
                    {
                        array[i, j] = int.Parse(temp[j]);

                        if (array[i, j] > 1)
                            array[i, j] = 1;

                        if (array[i, j] < 1 && array[i, j] != 0)
                            array[i, j] = 0;
                    }
                }
                matrix = array;
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Matrix reading failed!");
                Console.WriteLine(e.Message);
                return false;
            }
        }
        static void Main(string[] args)
        {
            int[,] adjacencyMatrix;

            while (true)
                if (TryGetAdjacencyMatrix(out adjacencyMatrix))
                    break;
            Console.WriteLine("\tSuccessfully introduced adjacency matrix!");

            //create graph
            List<Vertex> verticesList = new List<Vertex>();
            for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
            {
                int vertexDegree = 0;
                for (int j = 0; j < adjacencyMatrix.GetLength(1); j++)
                {
                    if (adjacencyMatrix[i, j] > 0)
                        vertexDegree++;
                }
                verticesList.Add(new Vertex(i, vertexDegree));
            }
            Vertex[] graph = verticesList.ToArray();
            Console.WriteLine("\tSuccessfully created graph!");


            //set nighbours
            for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
                for (int j = 0; j < adjacencyMatrix.GetLength(1); j++)
                    if (adjacencyMatrix[i, j] == 1)
                        graph[i].Neighbours.Add(graph[j]);
            Console.WriteLine("\tSuccessfully setted neighbours!");


            //set names
            Console.WriteLine("Type Y if you want to set names for vertices: ");
            if (Console.ReadLine() == "Y")
            {
                while (true)
                    if (TrySetVerticesNames(graph))
                        break;
                Console.WriteLine("\tSuccessfully seted vertecies!");
            }

            Console.WriteLine("In Turn Algorithm:");
            foreach (var vertex in InTurnAlgorithm.Paint(graph))
            {
                Console.WriteLine($"\tName - {vertex.Name}, \t\tColor - {vertex.Color}");
            }

            Console.WriteLine("\nWelsh Powell Algorithm:");
            foreach (var vertex in WelshPowellAlgorithm.Paint(graph))
            {
                Console.WriteLine($"\tName - {vertex.Name}, \t\tColor - {vertex.Color}");
            }
        }
    }
}