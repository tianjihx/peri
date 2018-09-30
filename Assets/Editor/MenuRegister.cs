using Peri.Description;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;
using Newtonsoft.Json;

namespace Peri
{
    public class MenuRegister
    {
        private static WindowPlayer Window1_instance;
        private static WindowPlayer Window2_instance;

        //[MenuItem("Window/Window1")]
        //static void Window1()
        //{
        //    if (Window1_instance == null)
        //        Window1_instance = new WindowPlayer();
        //    Window1_instance.Run();
        //}

        //[MenuItem("Window/Window2")]
        //static void Window2()
        //{
        //    if (Window2_instance == null)
        //        Window2_instance = new WindowPlayer();
        //    Window2_instance.Run();
        //}

        [MenuItem("Peri/创建test.json")]
        static void WriteJson()
        {
            var w = new Window
            {
                StartPosition = new Point(200, 200),
                Width = 640,
                Height = 480,
                Title = "尝试",
                RootContainer = new Canvas()
            };
            Label l = new Label
            {
                Position = new Vector2(100, 100),
                Width = 200,
                Height = 50,
                Text = "这是测试的文本"
            };
            w.RootContainer.Add(l);
            w.RootContainer.Relayout();
            DescriptionGenerator dg = new DescriptionGenerator(w);
            dg.Generate();
            var d = dg.GetDescription();
            string json = JsonConvert.SerializeObject(d);
            //string json = EditorJsonUtility.ToJson(d);
            var sw = File.CreateText(Application.dataPath + "/Editor/data/test.json");
            sw.WriteLine(json);
            sw.Flush();
            sw.Close();
            Debug.Log(json);

        }

        [MenuItem("Peri/读取test.json并显示")]
        static void LoadJsonShow()
        {
            string json = File.ReadAllText(Application.dataPath + "/Editor/data/test.json");
            var d = JsonConvert.DeserializeObject<DWindow>(json);
            DescriptionParser parser = new DescriptionParser(d);
            parser.Parse();
            var w = parser.GetWindow();
            if (Window2_instance == null)
                Window2_instance = WindowPlayer.New(w);
            Window2_instance.Show();
        }
    }
}
