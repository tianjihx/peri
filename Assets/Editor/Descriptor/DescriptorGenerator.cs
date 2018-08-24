using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Peri.Description
{
    public class DescriptorGenerator
    {
        private DWindow dwindow;
        private Window window;

        public DescriptorGenerator(Window window)
        {
            this.window = window;
        }

        private void TranverseRoot(Container currentContainer, DComponent d)
        {
            d.Children = new DComponent[currentContainer.Children.Count];
            int i = 0;
            foreach (var component in currentContainer.Children)
            {
                DComponent newD = new DComponent();
                newD.Position = component.Position;
                newD.RealPosition = component.RealPosition;
                newD.Width = component.Width;
                newD.Height = component.Height;
                newD.Attributes = component.GetAttributes();
                var container = component as Container;
                if (container != null)
                {
                    TranverseRoot(container, newD);
                }
                d.Children[i] = newD;
            }
        }

        public void Build()
        {
            dwindow = new DWindow();
            dwindow.WindowInfo.StartPosition = window.StartPosition;
            dwindow.WindowInfo.Width = window.Width;
            dwindow.WindowInfo.Height = window.Height;
            TranverseRoot(window.RootContainer, dwindow.RootContainer);
        }
        
        public DWindow GetDescriptor()
        {
            return dwindow;
        }
    }
}
