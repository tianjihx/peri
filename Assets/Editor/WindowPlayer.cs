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
    public class WindowPlayer : EditorWindow
    {
        private Window renderWindow;

        public WindowPlayer(Window window)
        {
            renderWindow = window;
            
        }

        private static void RenderWindow_OnRepaint(Widget widget, EventArgs arg1)
        {
            Debug.Log("重绘");
        }

        public static WindowPlayer New(Window w)
        {
            WindowPlayer player = CreateInstance<WindowPlayer>();
            player.renderWindow = w;
            player.renderWindow.OnRepaint += (widget, arg) =>
            {
                Debug.Log("重绘");
                player.Repaint();
            };
            player.position = new Rect(w.StartPosition.x, w.StartPosition.y, w.Width, w.Height);
            player.minSize = TypeTools.Point2Vector2(w.MinSize);
            player.maxSize = TypeTools.Point2Vector2(w.MaxSize);

            player.titleContent = new GUIContent(w.Title);
            player.ShowUtility();
            player.Focus();
            return player;
        }

        public void OnGUI()
        {
            if (renderWindow != null)
            {
                renderWindow.UpdateDraw();
                Repaint();
            }
            
            
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



    }
}
