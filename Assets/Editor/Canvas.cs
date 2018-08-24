using UnityEngine;
using UnityEditor;
using System;

namespace Peri
{
    public class Canvas : Container
    {
        public override string TypeName
        {
            get
            {
                return "Canvas";
            }
        }

        public override void Relayout()
        {
            foreach (var child in Children)
            {
                child.RealPosition = child.Position + Position;
            }
        }

    }
}
