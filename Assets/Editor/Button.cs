using UnityEngine;
using UnityEditor;
using System;

namespace Peri
{
    public class Button : RendererComponent
    {
        public string Text { get; set; }

        public delegate void OnClickDelegate();
        public event OnClickDelegate OnClick;

        public override void Draw()
        {

            GUIStyle style = new GUIStyle(EditorStyles.miniButton);
            if (GUI.Button(new Rect(PositionVector, SizeVector), Text))
            {
                if (OnClick != null)
                    OnClick();
            }
        }
    }
}
