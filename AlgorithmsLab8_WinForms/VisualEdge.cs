using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsLab8_WinForms
{
    public class VisualEdge
    {
        public Point StartPoint { get; set; }

        public Point EndPoint { get; set; }

        public Color Color { get; set; }

        public VisualEdge(Point startPoint, Point endPoint, Color color)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            Color = color;
        }

        public void Draw(Graphics graphics)
        {
            Pen pen = new Pen(Color,2);

            graphics.DrawLine(pen, StartPoint, EndPoint);
        }
    }
}
