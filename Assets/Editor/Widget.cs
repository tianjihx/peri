using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEditor;
using UnityEngine.Events;

namespace Peri
{
    public abstract class Widget
    {
        public Window WindowIn { get; set; }
        public Container CanvasIn { get; set; }
        public string Name;
        public virtual bool IsAutoSize { get; set; }
        private Vector2 position;
        public virtual Vector2 Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
                if (WindowIn != null)
                {
                    WindowIn.RepaintEvent();
                }
            }
        }
        public virtual Vector2 RealPosition
        {
            get
            {
                if (CanvasIn == null)
                {
                    throw new Exception("[Inner Error] " + Name + " 控件的CanvasIn为null");
                }
                return Position + CanvasIn.RealPosition;
            }
        }

        public virtual int Width { get; set; }
        public virtual int Height { get; set; }
        public Rect Rect { get { return new Rect(RealPosition, new Vector2(Width, Height)); } }
        public abstract string TypeName { get; }
        protected int Id;
        protected bool IsMouseDown;

        public abstract void Draw();

        protected virtual void AutoSize() { }

        #region 事件
        public event UnityAction<Widget, EventArgs> OnMouseDown;
        public event UnityAction<Widget, EventArgs> OnMouseUp;
        public event UnityAction<Widget, EventArgs> OnMouseClick;
        public event UnityAction<Widget, MouseDragEventArgs> OnMouseDrag;
        #endregion

        public Widget()
        {
            IsAutoSize = false;
            AutoSize();
            Id = GUIUtility.GetControlID(FocusType.Passive);
            IsMouseDown = false;
        }

        public virtual void UpdateDraw()
        {
            CheckEvent();

            HandleEvent();

            if (UnityEngine.Event.current.type == UnityEngine.EventType.Repaint)
                Draw();

        }

        public virtual void CheckEvent()
        {
            var unityEvent = UnityEngine.Event.current;
            if (Rect.Contains(UnityEngine.Event.current.mousePosition))
            {
                //Debug.Log(UnityEngine.Event.current.type);
                switch (unityEvent.type)
                {
                    case UnityEngine.EventType.MouseDown:
                        WindowIn.EventQueue.Enqueue(new Event(this, EventType.OnMouseDown));
                        IsMouseDown = true;
                        unityEvent.Use();
                        break;
                    case UnityEngine.EventType.MouseUp:
                        WindowIn.EventQueue.Enqueue(new Event(this, EventType.OnMouseClick));
                        WindowIn.EventQueue.Enqueue(new Event(this, EventType.OnMouseUp));
                        IsMouseDown = false;
                        unityEvent.Use();
                        break;
                    case UnityEngine.EventType.MouseDrag:
                        WindowIn.EventQueue.Enqueue(new Event(this, EventType.OnMouseDrag));
                        unityEvent.Use();
                        break;
                    
                }
            }
            else
            {
                if (IsMouseDown)
                {
                    switch (unityEvent.type)
                    {
                        case UnityEngine.EventType.MouseUp:
                            WindowIn.EventQueue.Enqueue(new Event(this, EventType.OnMouseUp));
                            IsMouseDown = false;
                            unityEvent.Use();
                            break;
                        case UnityEngine.EventType.MouseDrag:
                            WindowIn.EventQueue.Enqueue(new Event(this, EventType.OnMouseDrag));
                            unityEvent.Use();
                            break;
                    }
                }
            }
                

        }

        public virtual void HandleEvent()
        {
            if (WindowIn == null)
            {
                throw new Exception("控件" + Name + "没有挂载Window");
            }
            foreach (var evt in WindowIn.EventQueue.ToArray())
            {
                if (evt.Sender.Id == Id)
                {
                    switch (evt.Type)
                    {
                        case EventType.OnMouseDown:
                            EventTool.InvokeEvent(OnMouseDown, this, new EventArgs());
                            break;
                        case EventType.OnMouseClick:
                            EventTool.InvokeEvent(OnMouseClick, this, new EventArgs());
                            break;
                        case EventType.OnMouseUp:
                            EventTool.InvokeEvent(OnMouseUp, this, new EventArgs());
                            break;
                        case EventType.OnMouseDrag:
                            EventTool.InvokeEvent(OnMouseDrag, this, new MouseDragEventArgs(UnityEngine.Event.current.mousePosition));
                            break;
                    }
                }
            }
        }

    }
}
