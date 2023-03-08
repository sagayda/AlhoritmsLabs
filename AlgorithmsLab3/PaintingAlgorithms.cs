using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsLab3
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
}
