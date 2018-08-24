using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Peri
{
    public class Window : Component
    {
        public Point StartPosition { get; set; }
        public Container RootContainer { get; set; }
        public Point MinSize { get; set; }
        public Point MaxSize { get; set; }
        public string Title { get; set; }

        public override string TypeName
        {
            get
            {
                return "Window";
            }
        }

        public Window()
        {
            StartPosition = new Point(100, 100);
            MinSize = new Point(100, 100);
            MaxSize = new Point(1920, 1080);
        }

        public override void Draw()
        {
            if (RootContainer != null)
                RootContainer.Draw();
        }

    }
}
