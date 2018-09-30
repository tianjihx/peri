using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using Peri.Utils;

namespace Peri
{
    public abstract class RendererWidget : Widget
    {
        protected GUIStyle Style;

        public UnityAction<Widget> OnClick;
        public UnityAction<Widget> OnDragBegin;
        public UnityAction<Widget, Point> OnDrag;
        public UnityAction<Widget> OnDragEnd;

        public Vector2 Size
        {
            get
            {
                return new Vector2(Width, Height);
            }
        }

        public RendererWidget() : base()
        {
            SetStyle();
        }

        public override void HandleEvent()
        {
            base.HandleEvent();
        }

        protected abstract void SetStyle();
        public abstract override void Draw();

    }
}
