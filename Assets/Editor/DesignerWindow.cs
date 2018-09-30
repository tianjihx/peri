using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Peri
{
    class DesignerWindow : EditorWindow
    {
        private static DesignerWindow editorWindow;
        //private Window window;

        [MenuItem("Window/编辑器")]
        public static void MenuRegister()
        {
            editorWindow = EditorWindow.CreateInstance<DesignerWindow>();
            
            //editorWindow.BuildWindow();
            editorWindow.Show();
            //if (editorWindow.window == null)
        }

        //private void BuildWindow()
        //{
        //    window = new Window();
        //    window.OnRepaint += (sender, arg) =>
        //    {
        //        Debug.Log("重绘");
        //        Repaint();
        //    };
        //    window.Title = "编辑器";
        //    var canvas = window.RootContainer;
        //    Label label = new Label();
        //    label.Name = "label1";
        //    label.Text = "测试啦啦啦";
        //    label.WindowIn = window;
        //    canvas.Add(label);

        //    Label label2 = new Label();
        //    label2.Position = new Vector2(300, 300);
        //    label2.Name = "label2";
        //    label2.Text = "测试测试";
        //    label2.WindowIn = window;
        //    label2.OnMouseDrag += (sender, args) =>
        //    {
        //        label2.Position = args.Position;
        //    };
        //    canvas.Add(label2);

        //    Button btn = new Button();
        //    btn.Name = "button";
        //    btn.Text = "测试按钮";
        //    btn.Position = new Vector2(100, 100);
        //    btn.WindowIn = window;
        //    btn.OnMouseClick += (sender, args) =>
        //    {
        //        Label label3 = new Label();
        //        label3.WindowIn = window;
        //        label3.Position = new Vector2(200, 200);
        //        label3.Text = "弹出按钮！";
        //        canvas.Add(label3);
        //    };
        //    canvas.Add(btn);

        //}

        bool a = false;
        float toolBarWidth = 100;
        float topBarHeight = 40;
        float attributePanelWidth = 200;
        private void OnGUI()
        {
            //if (window != null)
            //    window.UpdateDraw();
            //顶部栏

            //工具栏
            GUILayout.BeginArea(new Rect(0, topBarHeight, toolBarWidth, editorWindow.position.height));
            GUILayout.BeginVertical();
            GUILayout.Button("Button");
            GUILayout.Button("Label");
            GUILayout.EndVertical();
            GUILayout.EndArea();
            //绘图区

            //属性栏
        }

    }
}
