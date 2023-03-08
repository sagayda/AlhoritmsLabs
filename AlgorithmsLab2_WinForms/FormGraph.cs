namespace AlgorithmsLab2_WinForms
{
    public partial class FormGraph : Form
    {
        private List<VisualVertex> drawedVertecies = new List<VisualVertex>();
        private List<VisualEdge> drawedEdges = new List<VisualEdge>();
        private readonly int _vertexRadius = 16;

        public FormGraph()
        {
            InitializeComponent();
        }

        class VisualVertex : Control
        {
            public Vertex Vertex { get; private set; }
            public int Id => Vertex == null ? -1 : Vertex.Id;
            public string Name => Vertex == null ? "EMPTY" : Vertex.Name;
            public int X { get; set; }
            public int Y { get; set; }

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
            public int Id => Edge == null ? -1 : Edge.Id;
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
        private void DrawVertex(Vertex vertex, int x, int y)
        {
            VisualVertex visualVertex = new VisualVertex(vertex)
            {
                X = x,
                Y = y,
                Size = new Size(_vertexRadius * 2, _vertexRadius * 2),
                Location = new Point(x + _vertexRadius, y - _vertexRadius),
                Parent = this,
            };
            visualVertex.Paint += OnVertexPaint;

            drawedVertecies.Add(visualVertex);
        }
        private void OnVertexPaint(object sender, PaintEventArgs e)
        {
            var vertex = (VisualVertex)sender;
            var gr = vertex.CreateGraphics();
            gr.DrawRectangle(new Pen(Color.Red, 4), 2, 2, _vertexRadius * 2 - 4, _vertexRadius * 2 - 4);
            var gr2 = CreateGraphics();

            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            gr2.DrawString(vertex.Name, new Font("Serif", 9), new SolidBrush(Color.Black), vertex.X + _vertexRadius * 2, vertex.Y - _vertexRadius * 2 - 3, stringFormat);

        }
        private void DrawEdge(Edge edge)
        {
            VisualEdge visulaEdge = new VisualEdge(edge);
            drawedEdges.Add(visulaEdge);
        }
        private void FormGraph_Paint(object sender, PaintEventArgs e)
        {
            var gr = CreateGraphics();
            foreach (var edge in drawedEdges)
            {
                var cVertecies = edge.Edge.ConnectedVertecies;
                var fromVertex = drawedVertecies.Find(vertex => vertex.Vertex.Id == cVertecies[0].Id);
                var toVertex = drawedVertecies.Find(vertex => vertex.Vertex.Id == cVertecies[1].Id);
                gr.DrawLine(new Pen(Color.FromArgb(edge.Edge.Color * 20, 50,50), 2), fromVertex.X + _vertexRadius * 2, fromVertex.Y, toVertex.X + _vertexRadius * 2, toVertex.Y);
            }
        }

        //graph drawing methods
        public void CircleDraw(Vertex[] graph, Edge[] edges)
        {
            int radius = graph.Length * 20;
            double step = 360 / graph.Length;

            var sortedVertevies = (from vertex in graph orderby vertex.Degree descending select vertex).ToArray<Vertex>();

            for (int i = 0; i < sortedVertevies.Length; i++)
            {
                int x = radius + 100 + (int)(radius * Math.Cos(step * i));
                int y = radius + 100 + (int)(radius * Math.Sin(step * i));

                DrawVertex(sortedVertevies[i], x, y);
            }

            for (int i = 0; i < edges.Length; i++)
            {
                DrawEdge(edges[i]);
            }
        }
    }
}
