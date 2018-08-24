using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Peri.Description
{
    public static class ComponentAttributeExtension
    {
        public static Dictionary<string, DAttributeValue> GetAttributes(this Component component)
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
        public static Dictionary<string, DAttributeValue> GetAttributes(this Button button)
        {
            DAttributeTool.Set("Text", button.Text);
            return DAttributeTool.CutDict();
        }

        public static Dictionary<string, DAttributeValue> GetAttributes(this Label label)
        {
            DAttributeTool.Set("Text", label.Text);
            return DAttributeTool.CutDict();
        }

        //Canvas
        public static Dictionary<string, DAttributeValue> GetAttributes(this Canvas canvas)
        {
            return DAttributeTool.CutDict();
        }
    }
}
