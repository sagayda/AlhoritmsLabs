using System;
using System.ComponentModel;
using System.Linq;

namespace AlgorithmsLab3_WinForms
{
    public class Vertex
    {
        public int Id { get; private set; }
        public int Degree => Neighbours == null ? 0 : Neighbours.Count;
        public string Name { get; set; }
        public int TarIndex { get; set; }
        public int LowLink { get; set; }
        public bool IsOnStack { get; set; }
        public bool Visited { get; set; }
        public List<Vertex> Neighbours { get; set; }
        public Vertex(int id, string name)
        {
            Id = id;
            Name = name;
            Neighbours = new List<Vertex>();
        }
        public Vertex(int id)
        {
            Id = id;
            Name = id.ToString();
            Neighbours = new List<Vertex>();
        }
    }
    public class Edge
    {
        public string Name => ConnectedVertecies == null ? "EMPTY" : $"{ConnectedVertecies[0].Name} - {ConnectedVertecies[1].Name}";
        public Vertex[] ConnectedVertecies { get; private set; }
        public int Color { get; set; }
        public List<Edge> Neighbours { get; set; }
        public Edge(Vertex fromVertex, Vertex toVertex)
        {
            ConnectedVertecies = new Vertex[2];
            ConnectedVertecies[0] = fromVertex;
            ConnectedVertecies[1] = toVertex;
            Color = -1;
            Neighbours = new List<Edge>();
        }
        public bool HasNeighbourEdgesWithColour(int colour)
        {
            for (int i = 0; i < Neighbours.Count; i++)
                if (Neighbours[i].Color == colour)
                    return true;

            return false;
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

            sccList = (from scc in sccList orderby scc.Count descending select scc).ToList<List<Vertex>>();
            return sccList;
        }

        private void StrongConnect(Vertex vertexV)
        {
            vertexV.TarIndex = index;
            vertexV.LowLink = index;
            index++;
            stack.Push(vertexV);
            vertexV.    IsOnStack = true;

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
    public class SearchBehindPaths
    {
        private Stack<Vertex> stack1, stack2;

        public List<List<Vertex>> FindSCCs(Vertex[] graph)
        {

            List<List<Vertex>> sccList = new List<List<Vertex>>();

            stack1 = new Stack<Vertex>();
            for (int i = 0; i < graph.Length; ++i)
            {
                if (!graph[i].Visited)
                    FillStacks(graph[i]);
            }

            foreach (var item in graph)
                item.Visited = false;

            stack2 = new Stack<Vertex>();

            while (stack1.Count > 0)
            {
                var v = stack1.Pop();

                if (!v.Visited)
                {
                    DFS(v);

                    List<Vertex> scc = new List<Vertex>();
                    while (stack2.Count > 0)
                    {
                        var w = stack2.Pop();
                        scc.Add(w);
                    }
                    sccList.Add(scc);
                }
            }

            sccList = (from scc in sccList orderby scc.Count descending select scc).ToList<List<Vertex>>();

            return sccList;
        }
        private void FillStacks(Vertex v)
        {
            v.Visited = true;

            foreach (Vertex w in v.Neighbours) 
                if (!w.Visited)
                    FillStacks(w);

            stack1.Push(v);
        }
        private void DFS(Vertex v)
        {
            v.Visited = true;
            stack2.Push(v);

            foreach (var w in v.Neighbours)
                if (!w.Visited)
                    DFS(w);
        }
    }
}
