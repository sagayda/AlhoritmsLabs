namespace AlgorithmsLab3_WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static bool TrySetVerticesNames(Vertex[] graph, string path)
        {
            if (!File.Exists(path))
            {
                MessageBox.Show("Names file doesnt exist", "ERROR!");
                return false;
            }

            try
            {
                string[] strings = File.ReadAllLines(path);

                if (strings.Length != graph.Length)
                {
                    MessageBox.Show("The number of vertices and the number of names do not match!", "ERROR!");
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
                MessageBox.Show(e.Message, "NAME SETTING ERROR!");
                return false;
            }
        }
        public static bool TryGetAdjacencyMatrix(out int[,] matrix, string path)
        {
            matrix = null;

            if (!File.Exists(path))
            {
                MessageBox.Show("Matrix file doesnt exist", "ERROR!");
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
                MessageBox.Show("Invalid matrix!", "ERROR!");
                return false;
            }

            if (xCount != yCount)
            {
                MessageBox.Show("Ìatrix is not square!", "ERROR!");
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
                        MessageBox.Show("Ìatrix is not square!", "ERROR!");
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
                MessageBox.Show(e.Message, "MATRIX SETTING ERROR!");
                return false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int[,] adjacencyMatrix;

            if (!TryGetAdjacencyMatrix(out adjacencyMatrix, textBox1.Text))
                return;

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
                verticesList.Add(new Vertex(i));
            }
            Vertex[] graph = verticesList.ToArray();

            //set nighbours for vertecies
            for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
                for (int j = 0; j < adjacencyMatrix.GetLength(1); j++)
                    if (adjacencyMatrix[i, j] == 1)
                        graph[i].Neighbours.Add(graph[j]);

            //set vertecies names
            if (textBox2.Text != null && textBox2.Text != "")
                if (!TrySetVerticesNames(graph, textBox2.Text))
                    return;

            //create edges
            List<Edge> edgesList = new List<Edge>();
            for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < adjacencyMatrix.GetLength(1); j++)
                {
                    if (adjacencyMatrix[i, j] != 1)
                        continue;

                    if (adjacencyMatrix[i, j] != adjacencyMatrix[j, i])
                    {
                        edgesList.Add(new Edge(graph[i], graph[j]));
                        continue;
                    }

                    if (i <= j)
                        edgesList.Add(new Edge(graph[i], graph[j]));
                }
            }

            //set neighbours for edges
            for (int i = 0; i < edgesList.Count; i++)
            {
                List<Edge> vertex1Neighbours = edgesList.FindAll(edge => edge.ConnectedVertecies[0].Id == edgesList[i].ConnectedVertecies[0].Id || edge.ConnectedVertecies[1].Id == edgesList[i].ConnectedVertecies[0].Id);
                List<Edge> vertex2Neighbours = edgesList.FindAll(edge => edge.ConnectedVertecies[0].Id == edgesList[i].ConnectedVertecies[1].Id || edge.ConnectedVertecies[1].Id == edgesList[i].ConnectedVertecies[1].Id);
                edgesList[i].Neighbours.AddRange(vertex1Neighbours);
                edgesList[i].Neighbours.AddRange(vertex2Neighbours);
            }
            Edge[] edges = edgesList.ToArray();

            var tarjan = new Tarjan();
            var FormTar = new FormGraph("Tar");
            FormTar.Show();
            FormTar.CircleDraw(graph, edges, tarjan.SCC(graph));

            var sfw = new SearchBehindPaths();
            var FormSfw = new FormGraph("SFW");
            FormSfw.Show();
            FormSfw.CircleDraw(graph, edges, sfw.FindSCCs(graph));


        }
    }
}