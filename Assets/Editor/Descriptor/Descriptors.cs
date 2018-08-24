using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Peri.Description
{
    [Serializable]
    public class DWindow
    {
        public DWindowInfo WindowInfo;
        public DComponent RootContainer;

        public DWindow()
        {
            WindowInfo = new DWindowInfo();
            RootContainer = new DComponent();
        }
    }

    [Serializable]
    public class DWindowInfo
    {
        public Point StartPosition;
        public int Width;
        public int Height;
    }

    [Serializable]
    public class DComponent
    {
        public string Type;
        public Point Position;
        public Point RealPosition;
        public int Width;
        public int Height;
        public DComponent[] Children;
        public DAttribute[] Attributes;
        public DEvent[] Events;
    }
    
    [Serializable]
    public class DAttribute
    {
        public string Name;
        public string StringValue;
        public int IntValue;
        public float FloatValue;
        public bool BoolValue;
    }

    [Serializable]
    public class DEvent
    {
        public string EventName;
        public string EventCallBack;
    }

    

    public class AttributeTool
    {
        private static List<DAttribute> attributeList = new List<DAttribute>();

        public static void Add(string name, string stringValue, int intValue, float floatValue, bool boolValue)
        {
            DAttribute attr = new DAttribute()
            {
                Name = name,
                StringValue = stringValue,
                IntValue = intValue,
                FloatValue = floatValue,
                BoolValue = boolValue
            };
            attributeList.Add(attr);
        }

        public static void Add(string name, string value)
        {
            Add(name, value, 0, 0f, false);
        }

        public static void Add(string name, int value)
        {
            Add(name, null, value, 0f, false);
        }

        public static void Add(string name, float value)
        {
            Add(name, null, 0, value, false);
        }

        public static void Add(string name, bool value)
        {
            Add(name, null, 0, 0f, value);
        }

        public static DAttribute[] ToArray()
        {
            var attrs = attributeList.ToArray();
            attributeList.Clear();
            return attrs;
        }
    }

}
