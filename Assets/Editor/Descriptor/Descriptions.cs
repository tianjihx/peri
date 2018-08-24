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
        public string Title;
        public Point MinSize;
        public Point MaxSize;
    }

    [Serializable]
    public class DComponent
    {
        public string Type;
        public Point Position;
        public Point RealPosition;
        public int Width;
        public int Height;
        public bool IsContainer;
        public DComponent[] Children;
        public Dictionary<string, DAttributeValue> Attributes;
        public DEvent[] Events;
    }
    
    [Serializable]
    public class DAttributeValue
    {
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

    

    public class DAttributeTool
    {
        private static Dictionary<string, DAttributeValue> attrDict = new Dictionary<string, DAttributeValue>();

        public static void Set(string name, string stringValue, int intValue, float floatValue, bool boolValue)
        {
            DAttributeValue attr = new DAttributeValue()
            {
                StringValue = stringValue,
                IntValue = intValue,
                FloatValue = floatValue,
                BoolValue = boolValue
            };
            if (attrDict.ContainsKey(name))
                attrDict[name] = attr;
            else
                attrDict.Add(name, attr);
        }

        public static void Set(string name, string value)
        {
            Set(name, value, 0, 0f, false);
        }

        public static void Set(string name, int value)
        {
            Set(name, null, value, 0f, false);
        }

        public static void Set(string name, float value)
        {
            Set(name, null, 0, value, false);
        }

        public static void Set(string name, bool value)
        {
            Set(name, null, 0, 0f, value);
        }

        public static Dictionary<string, DAttributeValue> CutDict()
        {
            var rtn = attrDict;
            attrDict = new Dictionary<string, DAttributeValue>();
            return rtn;
        }
    }

}
