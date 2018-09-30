using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Peri
{
    public abstract class Container : Widget
    {
        private List<Widget> childrenList;
        public bool IsRoot;

        public Container()
        {
            childrenList = new List<Widget>();
            IsRoot = false;
        }

        public override Vector2 RealPosition
        {
            get
            {
                if (IsRoot)
                    return Position;
                else
                    return base.RealPosition;
            }
        }

        public abstract void Relayout();

        public override void CheckEvent()
        {
            base.CheckEvent();
            foreach (var child in Childrens)
            {
                child.CheckEvent();
            }
        }

        public override void HandleEvent()
        {
            //Debug.Log("container HandleEvent");
            base.HandleEvent();
            foreach (var child in Childrens)
            {
                child.HandleEvent();
            }
        }

        public override void Draw()
        {
            //Debug.Log("container draw");
            if (UnityEngine.Event.current.type == UnityEngine.EventType.Repaint)
            {
                foreach (var child in Childrens)
                {
                    child.Draw();
                }
            }
        }

        //public override void UpdateDraw()
        //{
        //    //Debug.Log("个数：" + Childrens.Length);
        //    foreach (var child in Childrens)
        //    {
        //        child.CheckEvent();
        //        //Debug.Log("绘制 :" + child.TypeName + ":");
        //    }
        //    foreach (var child in Childrens)
        //    {
        //        child.HandleEvent();
        //        //Debug.Log("绘制 :" + child.TypeName + ":");
        //    }
        //    foreach (var child in Childrens)
        //    {
        //        child.Draw();
        //        //Debug.Log("绘制 :" + child.TypeName + ":");
        //    }

        //}

        public void Add(Widget widget)
        {
            if (childrenList == null)
            {
                throw new Exception("[Peri Inner Error] ChildList为Null");
            }
            childrenList.Add(widget);
            widget.CanvasIn = this;
            widget.WindowIn = WindowIn;
            Relayout();
        }

        public Widget[] Childrens
        {
            get
            {
                return childrenList.ToArray();
            }
        }
    }
}