using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Peri
{
    public abstract class Container : Component
    {
        public List<Component> Children { get; private set; }

        public Container()
        {
            Children = new List<Component>();
        }

        public abstract void Relayout();

        public override void Draw()
        {
            foreach (var child in Children)
            {
                child.Draw();
            }
        }
    }
}