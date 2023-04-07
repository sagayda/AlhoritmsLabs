namespace AlgorithmsLab3_WinForms
{
    public partial class FormGraph : Form
    {
        private List<VisualVertex> drawedVertecies = new List<VisualVertex>();
        private List<VisualEdge> drawedEdges = new List<VisualEdge>();
        private readonly int _vertexRadius = 16;
        Dictionary<int, Color> colors = new Dictionary<int, Color>();

        public FormGraph(string name)
        {
            InitializeComponent();
            this.Text = name;
        }

        class VisualVertex : Control
        {
            public Vertex Vertex { get; private set; }
            public string Name => Vertex == null ? "EMPTY" : Vertex.Name;
            public int X { get; set; }
            public int Y { get; set; }
            public Color Color { get; set; }
            public VisualVertex(Vertex vertex)
            {
                Vertex = vertex;
            }

            public override string ToString()
            {
                return Name;
            }
        }
        class VisualEdge
        {
            public Edge Edge { get; private set; }
            public string Name => Edge == null ? "EMPTY" : Edge.Name;

            public VisualEdge(Edge edge)
            {
                Edge = edge;
            }

            public override string ToString()
            {
                return Name;
            }
        }
        private void DrawVertex(Vertex vertex, int x, int y, Color color)
        {
            VisualVertex visualVertex = new VisualVertex(vertex)
            {
                X = x,
                Y = y,
                Size = new Size(_vertexRadius * 2, _vertexRadius * 2),
                Location = new Point(x + _vertexRadius, y - _vertexRadius),
                Parent = this,
                Color = color,
            };
            visualVertex.Paint += OnVertexPaint;

            drawedVertecies.Add(visualVertex);
        }
        private void OnVertexPaint(object sender, PaintEventArgs e)
        {
            var vertex = (VisualVertex)sender;
            var gr = vertex.CreateGraphics();
            gr.DrawRectangle(new Pen(vertex.Color, 4), 2, 2, _vertexRadius * 2 - 4, _vertexRadius * 2 - 4);
            var gr2 = CreateGraphics();

            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            FontStyle fontStyle = FontStyle.Bold;
            gr2.DrawString(vertex.Name, new Font("Serif", 8, fontStyle), new SolidBrush(Color.Black), vertex.X + _vertexRadius * 2, vertex.Y - _vertexRadius * 2 - 3, stringFormat);
        }
        private void DrawEdge(Edge edge)
        {
            VisualEdge visulaEdge = new VisualEdge(edge);
            drawedEdges.Add(visulaEdge);
        }
        private void FormGraph_Paint(object sender, PaintEventArgs e)
        {
            var gr = CreateGraphics();

            Random rn = new Random();

            foreach (var edge in drawedEdges)
            {
                Color color = Color.LightGray;

                var cVertecies = edge.Edge.ConnectedVertecies;
                var fromVertex = drawedVertecies.Find(vertex => vertex.Vertex.Id == cVertecies[0].Id);
                var toVertex = drawedVertecies.Find(vertex => vertex.Vertex.Id == cVertecies[1].Id);
                gr.DrawLine(new Pen(color, 4), fromVertex.X + _vertexRadius * 2, fromVertex.Y, toVertex.X + _vertexRadius * 2, toVertex.Y);
            }

        }
        //graph drawing methods
        public void CircleDraw(Vertex[] graph, Edge[] edges, List<List<Vertex>> scc)
        {
            int start = 350;
            int mainRadius = scc.Count * 50;

            foreach (var item in scc)
            {
                mainRadius += (int)Math.Pow(item.Count, 2.5);
            }

            float mainStep = 360 / scc.Count;

            Random rn = new Random();

            for (int i = 0; i < scc.Count; i++)
            {
                int radius = scc.ElementAt(i).Count() * 35;
                float step = 360 / scc.ElementAt(i).Count();

                var sortedVertevies = (from vertex in scc.ElementAt(i) orderby vertex.Degree descending select vertex).ToArray<Vertex>();

                Color color;

                if (!colors.TryGetValue(i, out color))
                {
                    colors.Add(i, Color.FromArgb(rn.Next(0, 255), rn.Next(0, 255), rn.Next(0, 255)));
                    colors.TryGetValue(i, out color);
                }

                for (int j = 0; j < sortedVertevies.Length; j++)
                {
                    var gr = CreateGraphics();

                    float circleX = (float)(start + radius + (mainRadius * Math.Cos(mainStep * i * 0.0174533)));
                    float circleY = (float)(start + radius + (mainRadius * Math.Sin(mainStep * i * 0.0174533)));

                    int x = (int)(start + radius + (mainRadius * Math.Cos(mainStep * i * 0.0174533) ) + (radius * Math.Cos(step * j * 0.0174533)));
                    int y = (int)(start + radius + (mainRadius * Math.Sin(mainStep * i * 0.0174533) ) + (radius * Math.Sin(step * j * 0.0174533)));

                    DrawVertex(sortedVertevies[j], x, y, color);
                }

                for (int j = 0; j < edges.Length; j++)
                {
                    DrawEdge(edges[j]);
                }
            }



            //int radius = graph.Length * 25;
            //float step = 360 / graph.Length;

            //var sortedVertevies = (from vertex in graph orderby vertex.Degree descending select vertex).ToArray<Vertex>();

            //for (int i = 0; i < sortedVertevies.Length; i++)
            //{
            //    int x = (int)(radius + 100 + (radius * Math.Cos(step * i * 0.0174533)));
            //    int y = (int)(radius + 100 + (radius * Math.Sin(step * i * 0.0174533)));

            //    DrawVertex(sortedVertevies[i], x, y);
            //}

            //for (int i = 0; i < edges.Length; i++)
            //{
            //    DrawEdge(edges[i]);
            //}

        }
    }
}
