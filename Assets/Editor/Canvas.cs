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

        //public override void Draw()
        //{
        //    Debug.Log("canvas 的一些绘制");
        //}

        public override void Relayout()
        {
            //foreach (var child in Childrens)
            //{
            //    child.RealPosition = child.Position + this.Position;
            //    Debug.Log("更新位置 :" + child.TypeName + ":" + child.RealPosition);
            //}
        }

    }
}
