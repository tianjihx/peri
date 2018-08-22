using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Peri
{
    public class Label
    {
        public Vector2 Position { get; set; }
        public Vector2 Size { get; set; }
        public string Text { get; set; }

        public void Draw()
        {

            GUIStyle style = new GUIStyle(EditorStyles.label);
            GUI.Label(new Rect(Position, Size), Text, style);
        }
    }
}
