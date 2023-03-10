using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsLab2_WinForms
{
    public class Vertex
    {
        public int Id { get; private set; }
        public int Degree => Neighbours == null ? 0 : Neighbours.Count;
        public string Name { get; set; }
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
        public bool HasNeighbourWithId(int id)
        {
            for (int i = 0; i < Neighbours.Count; i++)
                if (Neighbours[i].Id == id)
                    return true;
            
            return false;
        }
    }
    public class Edge
    {
        public string Name => ConnectedVertecies == null ? "EMPTY" : $"{ConnectedVertecies[0].Name} - {ConnectedVertecies[1].Name}";
        public Vertex[] ConnectedVertecies { get; private set; }
        public int Color { get; set;}
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
    public static class WelshPowellAlgorithm
    {
        public static Edge[] Paint(Edge[] edges)
        {
            Edge[] paintedEdges = (Edge[])edges.Clone();
            var sortedEdges = from edge in paintedEdges orderby edge.Neighbours.Count descending select edge;
            
            for (int i = 0; i < paintedEdges.Length; i++)
            {
                if (i == 0)
                    sortedEdges.ElementAt(0).Color = 0;

                for (int j = 0; j < paintedEdges.Length; j++)
                    if (sortedEdges.ElementAt(j).Color == -1 && !sortedEdges.ElementAt(j).HasNeighbourEdgesWithColour(i))
                        sortedEdges.ElementAt(j).Color = i;
            }

            return paintedEdges;
        }
    }
    public static class InTurnAlgorithm
    {
        public static Edge[] Paint(Edge[] edges) 
        {
            Edge[] paintedEdges = (Edge[])edges.Clone();
            foreach (var edge in paintedEdges)
            {
                int i = 0;
                while (edge.Color == -1)
                {
                    if (!edge.HasNeighbourEdgesWithColour(i))
                    {
                        edge.Color= i;
                        break;
                    }
                    i++;
                }
            }

            return paintedEdges;
        }
    }
}
