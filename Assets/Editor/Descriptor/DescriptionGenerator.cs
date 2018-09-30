using Peri.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Peri.Description
{
    public class DescriptionGenerator
    {
        private DWindow dwindow;
        private readonly Window window;

        public DescriptionGenerator(Window window)
        {
            this.window = window;
        }

        private void TranverseRoot(Container currentContainer, DWidget d)
        {
            d.Children = new DWidget[currentContainer.Childrens.Length];
            int i = 0;
            foreach (var component in currentContainer.Childrens)
            {
                DWidget newD = GenerateFromComponent(component);
                if (newD.IsContainer)
                {
                    TranverseRoot(component as Container, newD);
                }
                d.Children[i++] = newD;
            }
        }

        public void Generate()
        {
            dwindow = new DWindow();
            dwindow.WindowInfo = new DWindowInfo()
            {
                StartPosition = window.StartPosition,
                Width = window.Width,
                Height = window.Height,
                Title = window.Title,
                MinSize = window.MinSize,
                MaxSize = window.MaxSize
            };
            dwindow.RootContainer = GenerateFromComponent(window.RootContainer);
            TranverseRoot(window.RootContainer, dwindow.RootContainer);
        }

        private DWidget GenerateFromComponent(Widget component)
        {
            DWidget d = new DWidget
            {
                Type = component.TypeName,
                Position = component.Position.ToPoint(),
                //RealPosition = component.RealPosition.ToPoint(),
                Width = component.Width,
                Height = component.Height,
                IsContainer = false,
                Attributes = component.GetAttributes()
            };
            if (component is Container)
                d.IsContainer = true;
            return d;
        }
        
        public DWindow GetDescription()
        {
            return dwindow;
        }
    }
}
