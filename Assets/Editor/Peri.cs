using UnityEngine;
using UnityEditor;

namespace Peri
{
    public class UICreator : EditorWindow
    {
        public Button button;
        public Label label;

        [MenuItem("Window/窗口编辑器")]
        static void DoIt()
        {
            Rect wr = new Rect(0, 0, 300, 300);
            var window = GetWindowWithRect<UICreator>(wr, true, "窗口编辑器");
            window.Show();
        }

        public UICreator()
        {
            ComponentInitialization();
        }

        private void ComponentInitialization()
        {
            button = new Button();
            button.Position = new Vector2(100, 100);
            button.Size = new Vector2(50, 50);
            button.Text = "click me";
            button.OnClick += () => { EditorUtility.DisplayDialog("adsf", "ad", "123"); };

            label = new Label();
            label.Position = new Vector2(100, 200);
            label.Size = new Vector2(100, 20);
            label.Text = "测试";
        }


        private void OnGUI()
        {
            
            switch (Event.current.type)
            {
                case EventType.MouseDrag:
                    var pos = Event.current.mousePosition;
                    Repaint();
                    break;
            }

        }
    }
}

