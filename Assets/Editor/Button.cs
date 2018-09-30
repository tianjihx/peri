using UnityEngine;
using UnityEditor;
using System;

namespace Peri
{
    public class Button : RendererWidget
    {
        private string text;
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                if (IsAutoSize)
                {
                    AutoSize();
                }
            }
        }

        public override string TypeName
        {
            get
            {
                return "Button";
            }
        }

        public Button() : base()
        {
            IsAutoSize = true;
            Name = TypeName;
        }

        protected override void SetStyle()
        {
            Style = new GUIStyle(EditorStyles.miniButton);
        }

        public override void Draw()
        {
            //GUI.Button(Rect, Text);
            
            Style.Draw(Rect, Text, false, true, IsMouseDown, false);
            //GUI.Button(new Rect(200, 100, 100, 50), "测试");
        }

        protected override void AutoSize()
        {
            Debug.Log("button 的文字内容为" + text);
            Width = (int)EditorStyles.miniButton.CalcSize(new GUIContent(text)).x;
            Height = (int)EditorStyles.miniButton.CalcSize(new GUIContent(text)).y;
            Debug.Log("autosize后的大小为" + new Point(Width, Height));
        }

        
    }
}
