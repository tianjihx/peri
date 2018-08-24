using Peri.Description;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Peri
{
    public class MenuRegister
    {
        private static WindowPlayer Window1_instance;
        private static WindowPlayer Window2_instance;

        [MenuItem("Window/Window1")]
        static void Window1()
        {
            if (Window1_instance == null)
                Window1_instance = new WindowPlayer();
            Window1_instance.Run();
        }

        [MenuItem("Window/Window2")]
        static void Window2()
        {
            if (Window2_instance == null)
                Window2_instance = new WindowPlayer();
            Window2_instance.Run();
        }

        [MenuItem("Peri/Test Desc")]
        static void TestDesc()
        {
            var w = new Window();
            w.StartPosition = new Point(200, 200);
            w.Width = 640;
            w.Height = 480;
            w.Name = "尝试";
            w.RootContainer = new Canvas();
            Label l = new Label();
            l.Position = new Point(100, 100);
            l.Width = 200;
            l.Height = 50;
            l.Text = "这是测试的文本";
            w.RootContainer.Children.Add(l);
            w.RootContainer.Relayout();
            DescriptorGenerator dg = new DescriptorGenerator(w);
            dg.Build();
            var d = dg.GetDescriptor();
            string json = EditorJsonUtility.ToJson(d);
            Debug.Log(json);
        }
    }
}
