using UnityEngine;
using UnityEditor;
using System;

namespace Peri
{
    public class Grid : Container
    {
        private int column;
        private int row;

        public int Column
        {
            get
            {
                return column;
            }

            set
            {
                column = value;
            }
        }

        public int Row
        {
            get
            {
                return row;
            }
            set
            {
                row = value;
            }
        }

        public override string TypeName
        {
            get
            {
                return "Grid";
            }
        }

        public override void Relayout()
        {
            //foreach (var child in Childrens)
            //{
            //    child.RealPosition = child.Position + Position;
            //}
        }

        public override void Draw()
        {

        }

        public override void UpdateDraw()
        {
            base.UpdateDraw();
        }
    }
}
