using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Peri
{
    public abstract class Component
    {
        public virtual Point Position { get; set; }
        public virtual Point RealPosition { get; set; }
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }
        public abstract string TypeName { get; }

        public abstract void Draw();

    }
}
