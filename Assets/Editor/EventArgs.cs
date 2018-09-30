using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Peri
{
    public class MouseDragEventArgs : EventArgs
    {
        public Vector2 Position { get; private set; }
        public MouseDragEventArgs(Vector2 position)
        {
            this.Position = position;
        }
    }
}
