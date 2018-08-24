using Peri.Description;
using Peri.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Peri
{
    public class WindowPlayer
    {
        private WindowPlayerCore core;
        Window currentWindow;

        public WindowPlayer(Window window)
        {
            currentWindow = window;
        }

        public void Run()
        {
            if (core != null)
                return;
            core = ScriptableObject.CreateInstance<WindowPlayerCore>() as WindowPlayerCore;
            core.RenderWindow = currentWindow;
            core.position = new Rect(currentWindow.StartPosition.x, currentWindow.StartPosition.y, currentWindow.Width, currentWindow.Height);
            core.minSize = TypeTools.Point2Vector2(currentWindow.MinSize);
            core.maxSize = TypeTools.Point2Vector2(currentWindow.MaxSize);
            
            core.titleContent = new GUIContent(currentWindow.Title);
            core.ShowUtility();
            core.Focus();
            core.Show();
        }

        //public void LoadFromJson()
        //{
        //    w = new Window();
        //    w.StartPosition = new Point(200, 200);
        //    w.Width = 640;
        //    w.Height = 480;
        //    w.Title = "尝试";
        //    w.RootContainer = new Canvas();
        //    Label l = new Label();
        //    l.Position = new Point(100, 100);
        //    l.Width = 200;
        //    l.Height = 50;
        //    l.Text = "这是测试的文本";
        //    w.RootContainer.Children.Add(l);
        //    w.RootContainer.Relayout();
        //}


        public class WindowPlayerCore : EditorWindow
        {
            public Window RenderWindow { private get; set; }
            private void OnGUI()
            {
                if (RenderWindow != null)
                {
                    RenderWindow.Draw();
                }
            }
        }
    }
}
