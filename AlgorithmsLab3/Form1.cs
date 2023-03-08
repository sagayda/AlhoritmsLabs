namespace AlgorithmsLab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static bool TryGetAdjacencyMatrix(out int[,] matrix, string path)
        {
            matrix = null;

            if (!File.Exists(path))
            {
                MessageBox.Show("File doesnt exist!", "ERROR!");
                return false;
            }

            List<string> tempList = new List<string>();
            tempList = File.ReadAllLines(path).ToList();
            int xCount = tempList.Count;
            if (xCount <= 0)
            {
                MessageBox.Show("Invalid matrix!", "ERROR!");
                return false;
            }

            int yCount = tempList[0].Split(" ").Length;
            if (yCount == 0)
            {
                MessageBox.Show("Empty matrix!", "ERROR!");
                return false;
            }

            if (xCount != yCount)
            {
                MessageBox.Show("Matrix is not square!", "ERROR!");
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
                        MessageBox.Show("Matrix is not square!", "ERROR!");
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
                MessageBox.Show($"Error: {e.Message}", "ERROR!");
                return false;
            }
        }
        public static bool TrySetVerticesNames(out string[] names, string path, Vertex[] graph)
        {
            names = null;

            if (!File.Exists(path))
            {
                MessageBox.Show("File doesnt exist!", "ERROR!");
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

        private void button1_Click(object sender, EventArgs e)
        {
            int[,] adjacencyMatrix;

            if (!TryGetAdjacencyMatrix(out adjacencyMatrix, textBox1.Text))
                return;

            //Console.WriteLine("\tSuccessfully introduced adjacency matrix!");


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

            //Console.WriteLine("\tSuccessfully created vertecies!");

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