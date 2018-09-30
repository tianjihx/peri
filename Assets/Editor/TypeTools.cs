using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Peri.Utils
{
    public static class TypeTools
    {
        public static Vector2 Point2Vector2(Point p)
        {
            return new Vector2(p.x, p.y);
        }

        public static Point ToPoint(this Vector2 v)
        {
            return new Point(v.x, v.y);
        }
    }
}
