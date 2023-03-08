namespace AlhoritmsLab3
{
    public class Vertex
    {
        public string Name { get; set; }
        public int TarIndex { get; set; }
        public int LowLink { get; set; }
        public bool IsOnStack { get; set; }
        public List<Vertex> Neighbours { get; set; }
        public Vertex(string name)
        {
            Name = name;
            Neighbours = new List<Vertex>();
        }

    }

    public class Tarjan
    {
        private Stack<Vertex> stack;
        private int index;
        private int sccCount;
        private Vertex[] graph;
        private List<List<Vertex>> sccList;

        public List<List<Vertex>> SCC(Vertex[] recievedGraph)
        {
            graph = recievedGraph;
            index = 0;
            sccCount = 0;
            stack = new Stack<Vertex>();
            sccList = new List<List<Vertex>>();

            for (int i = 0; i < graph.Length; i++)
            {
                if (graph[i].TarIndex == 0)
                {
                    StrongConnect(graph[i]);
                }
            }

            return sccList;
        }

        private void StrongConnect(Vertex vertexV)
        {
            vertexV.TarIndex = index;
            vertexV.LowLink = index;
            index++;
            stack.Push(vertexV);
            vertexV.IsOnStack = true;

            foreach (var vertexW in vertexV.Neighbours)
            {
                if (vertexW.TarIndex == 0)
                {
                    StrongConnect(vertexW);
                    vertexV.LowLink = Math.Min(vertexV.LowLink, vertexW.LowLink);
                }
                else if (vertexW.IsOnStack)
                {
                    vertexV.LowLink = Math.Min(vertexV.LowLink, vertexW.TarIndex);
                }
            }

            if (vertexV.LowLink == vertexV.TarIndex)
            {
                List<Vertex> scc = new List<Vertex>();
                Vertex w;
                do
                {
                    w = stack.Pop();
                    w.IsOnStack = false;
                    scc.Add(w);
                } while (w != vertexV);

                sccList.Add(scc);
                sccCount++;
            }
        }
    }

    internal class Program
    {
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
                        if (float.Parse(temp[j]) <= 0)
                        {
                            array[i, j] = 0;
                            continue;
                        }

                        if (float.Parse(temp[j]) > 0)
                        {
                            array[i, j] = 1;
                            continue;
                        }
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
        public static bool TrySetVerticesNames(Vertex[] vertices)
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

                if (strings.Length != vertices.Length)
                {
                    Console.WriteLine("The number of vertices and the number of names do not match!");
                    return false;
                }

                for (int i = 0; i < vertices.Length; i++)
                {
                    vertices[i].Name = strings[i];
                }
                return true;
            }
            catch (Exception e)
            {
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
            List<Vertex> temp = new List<Vertex>();
            for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
                temp.Add(new Vertex(i.ToString()));

            Vertex[] graph = temp.ToArray();


            //set nighbours
            for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
                for (int j = 0; j < adjacencyMatrix.GetLength(1); j++)
                    if (adjacencyMatrix[i, j] == 1)
                        graph[i].Neighbours.Add(graph[j]);

            Console.WriteLine("\tSuccessfully created vertecies!");

            //set names
            Console.WriteLine("Type Y if you want to set names for vertices: ");
            if (Console.ReadLine() == "Y")
            {
                while (true)
                    if (TrySetVerticesNames(graph))
                        break;

                Console.WriteLine("\tSuccessfully setted names!");
            }


            Tarjan tarjan = new();
            List<List<Vertex>> sccList = tarjan.SCC(graph);

            foreach (var scc in sccList)
            {
                Console.WriteLine($"--SCC:");
                foreach (var vertex in scc)
                    Console.WriteLine($"\tVertex name: {vertex.Name}");
            }

        }
    }
}