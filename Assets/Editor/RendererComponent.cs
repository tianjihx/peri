using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Peri
{
    public abstract class RendererComponent : Component
    {
        public Vector2 PositionVector
        {
            get
            {
                return new Vector2(Position.x, Position.y);
            }
        }

        public Vector2 SizeVector
        {
            get
            {
                return new Vector2(Width, Height);
            }
        }
    }
}
