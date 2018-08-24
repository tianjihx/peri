using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Peri.Description
{
    public static class ComponentAttributeExtension
    {
        public static DAttribute[] GetAttributes(this Component component)
        {
            if (component is Button)
                return (component as Button).GetAttributes();
            if (component is Label)
            {
                return (component as Label).GetAttributes();
            }
            return null;
        }
        
        //RendererCompontent
        public static DAttribute[] GetAttributes(this Button button)
        {
            AttributeTool.Add("Text", button.Text);
            return AttributeTool.ToArray();
        }

        public static DAttribute[] GetAttributes(this Label label)
        {
            AttributeTool.Add("Text", label.Text);
            return AttributeTool.ToArray();
        }

        //Canvas
        public static DAttribute[] GetAttributes(this Canvas canvas)
        {
            return AttributeTool.ToArray();
        }
    }
}
