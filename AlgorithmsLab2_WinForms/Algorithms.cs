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
        public int Degree { get; private set; }
        public string Name { get; set; }
        public int Color { get; set; }
        public List<Vertex> Neighbours { get; set; }
        public List<Edge> Edges { get; set; }
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
        public bool HasNeighboursWithColour(int color)
        {
            foreach (var neighbor in Neighbours)
            {
                if (neighbor.Color == color)
                    return true;
            }
            return false;
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
        public int Id => ConnectedVertecies == null ? -1 : ConnectedVertecies[0].Id;
        public string Name => ConnectedVertecies == null ? "EMPTY" : $"{ConnectedVertecies[0].Name} - {ConnectedVertecies[1].Name}";
        public Vertex[] ConnectedVertecies { get; private set; }
        public int Color { get; set;}
        public int NeighbourEdgesCount => ConnectedVertecies[0].Neighbours.Count - 1;
        public Edge(Vertex fromVertex, Vertex toVertex)
        {
            ConnectedVertecies = new Vertex[2];
            ConnectedVertecies[0] = fromVertex;
            ConnectedVertecies[1] = toVertex;
            Color = -1;
        }
        public bool HasNeighbourEdgesWithColour(int colour)
        {
            for (int i = 0; i < ConnectedVertecies[0].Neighbours.Count; i++)
                if (ConnectedVertecies[0].Neighbours[i].Color == colour)
                    return true;

            for (int i = 0; i < ConnectedVertecies[1].Neighbours.Count; i++)
                if (ConnectedVertecies[1].Neighbours[i].Color == colour)
                    return true;
            
            return false;
        }
    }
    public static class WelshPowellAlgorithm
    {
        public static Edge[] Paint(Edge[] edges)
        {
            Edge[] paintedEdges = (Edge[])edges.Clone();
            var sortedEdges = from edge in paintedEdges orderby edge.NeighbourEdgesCount descending select edge;

            for (int i = 0; i < paintedEdges.Length; i++)
            {
                if (i == 0)
                    sortedEdges.ElementAt(0).Color = 0;

                for (int j = 0; j < paintedEdges.Length; j++)
                    if (sortedEdges.ElementAt(j).Color == -1 && !sortedEdges.ElementAt(j).HasNeighbourEdgesWithColour(i))
                        sortedEdges.ElementAt(j).Color = 1;
            }

            return paintedEdges;
        }


        //vertex mode

        //public static Vertex[] Paint(Vertex[] graph)
        //{
        //    Vertex[] paintedGraph = (Vertex[])graph.Clone();

        //    var sortedVertevies = from vertex in paintedGraph orderby vertex.Degree descending select vertex;
        //    for (int i = 0; i < paintedGraph.Length; i++)
        //    {
        //        if (i == 0)
        //            sortedVertevies.ElementAt(0).Color = 0;

        //        for (int j = i; j < sortedVertevies.Count(); j++)
        //            if (!sortedVertevies.ElementAt(j).HasNeighboursWithColour(i) && sortedVertevies.ElementAt(j).Color == -1)
        //                sortedVertevies.ElementAt(j).Color = i;
        //    }
        //    return paintedGraph;
        //}

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
                    if (!vertex.HasNeighboursWithColour(i))
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
}
