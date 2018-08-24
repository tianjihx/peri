using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Peri.Description
{
    public class DescriptionParser
    {
        private readonly DWindow dwindow;
        private Window window;

        public DescriptionParser(DWindow dwindow)
        {
            this.dwindow = dwindow;
        }

        public Window GetWindow()
        {
            return window;
        }

        public void Parse()
        {
            window = new Window()
            {
                StartPosition = dwindow.WindowInfo.StartPosition,
                Width = dwindow.WindowInfo.Width,
                Height = dwindow.WindowInfo.Height,
                Title = dwindow.WindowInfo.Title,
                MinSize = dwindow.WindowInfo.MinSize,
                MaxSize = dwindow.WindowInfo.MaxSize
            };
            window.RootContainer = ParseFromDescription(dwindow.RootContainer) as Container;
            TranverseRoot(dwindow.RootContainer, window.RootContainer);
        }

        public void TranverseRoot(DComponent d, Container container)
        {
            Debug.Log(d.Type);
            foreach (var dchild in d.Children)
            {
                Component component = ParseFromDescription(dchild);
                Debug.Log(dchild.Type);
                //如果是容器
                if (dchild.IsContainer)
                {
                    TranverseRoot(dchild, component as Container);
                }
                container.Children.Add(component);
            }

        }

        private Component ParseFromDescription(DComponent d)
        {
            Component c;
            switch (d.Type)
            {
                case "Canvas": c = ParseCanvas(d); break;
                case "Button": c = ParseButton(d); break;
                case "Label": c = ParseLabel(d); break;
                default: throw new Exception("错误的Type：" + d.Type);
            }
            SetCommonAttribute(c, d);
            return c;
        }

        private Canvas ParseCanvas(DComponent d)
        {
            Canvas canvas = new Canvas();
            return canvas;
        }

        private Button ParseButton(DComponent d)
        {
            Button button = new Button();
            button.Text = d.Attributes["Text"].StringValue;
            return button;
        }

        private Label ParseLabel(DComponent d)
        {
            Debug.Log("parse label");
            Label label = new Label();
            label.Text = d.Attributes["Text"].StringValue;
            return label;
        }

        private void SetCommonAttribute(Component c, DComponent d)
        {
            c.Position = d.Position;
            c.RealPosition = d.RealPosition;
            c.Width = d.Width;
            c.Height = d.Height;
        }



    }
}
