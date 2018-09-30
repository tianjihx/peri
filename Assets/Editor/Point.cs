using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Peri
{
    public struct Point
    {
        public static readonly Point One = new Point(0, 0);
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Point(Point source) : this(source.x, source.y) { }
        public Point(float x, float y) : this((int)x, (int)y) { }
        
        public static Point operator +(Point a, Point b)
        {
            return new Point(a.x + b.x, a.y + b.y);
        }

        public static Point operator -(Point a, Point b)
        {
            return new Point(a.x - b.x, a.y - b.y);
        }

        public static Point operator *(Point a, int b)
        {
            return new Point(a.x * b, a.y * b);
        }

        public static Point operator /(Point a, int b)
        {
            return new Point(a.x / b, a.y / b);
        }

        public static float Distance(Point a, Point b)
        {
            return (float)Math.Sqrt(Math.Pow(a.x - b.x, 2) + Math.Pow(a.y - b.y, 2)); 
        }

        public override string ToString()
        {
            return string.Format("({0},{1})", x, y);
        }

        public Vector2 ToVector2()
        {
            return new Vector2(x, y);
        }

    }
}
