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
            
        }

        public UICreator()
        {
            ComponentInitialization();
        }

        private void ComponentInitialization()
        {
            Window w = new Window();
            w.StartPosition = new Point(200, 200);
            w.Width = 640;
            w.Height = 480;
        }


        private void OnGUI()
        {
            

        }
    }
}

