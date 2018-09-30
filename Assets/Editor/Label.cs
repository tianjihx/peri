using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Peri
{
    public class Label : RendererWidget
    {
        private string text;

        public override string TypeName
        {
            get
            {
                return "Label";
            }
        }

        
        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                if (IsAutoSize)
                {
                    AutoSize();
                }
            }
        }

        public Label() : base()
        {
            IsAutoSize = true;
            Name = TypeName;
        }

        protected override void SetStyle()
        {
            Style = new GUIStyle(EditorStyles.label);
        }

        public override void Draw()
        {
            //Debug.Log(RealPosition);
            Style.Draw(Rect, Text, false, true, false, false);
            //GUI.Label(new Rect(RealPosition, Size), Text, style);
            //UnityEngine.Event e = UnityEngine.Event.current;
        }

        protected override void AutoSize()
        {
            Width = (int)EditorStyles.label.CalcSize(new GUIContent(text)).x;
            Height = (int)EditorStyles.label.CalcSize(new GUIContent(text)).y;
        }

        
    }
}
