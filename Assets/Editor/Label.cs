using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Peri
{
    public class Label : RendererComponent
    {
        public string Text { get; set; }

        public override void Draw()
        {

            GUIStyle style = new GUIStyle(EditorStyles.label);
            GUI.Label(new Rect(PositionVector, SizeVector), Text, style);
        }

    }
}
