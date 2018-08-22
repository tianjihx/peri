using UnityEngine;
using UnityEditor;

namespace Peri
{
    public class Button
    {
        public Vector2 Position { get; set; }
        public Vector2 Size { get; set; }
        public string Text { get; set; }

        public delegate void OnClickDelegate();
        public event OnClickDelegate OnClick;

        public void Draw()
        {

            GUIStyle style = new GUIStyle(EditorStyles.miniButton);
            if (GUI.Button(new Rect(Position, Size), Text))
            {
                if (OnClick != null)
                    OnClick();
            }
        }
    }
}
