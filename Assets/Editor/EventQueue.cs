using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Peri
{
    public enum EventType
    {
        OnMouseEnter,
        OnMouseLeave,
        OnMouseDown,
        OnMouseUp,
        OnMouseClick,
        OnMouseDrag,
        Repaint
    }

    public struct Event
    {
        public Widget Sender; //事件发出者
        public EventType Type;

        public Event(Widget sender, EventType type)
        {
            this.Sender = sender;
            this.Type = type;
        }

    }

    public class EventQueue
    {
        private Queue<Event> queue;
        private Widget repaintSender;

        public EventQueue()
        {
            queue = new Queue<Event>();
        }

        public void Enqueue(Event evt)
        {
            queue.Enqueue(evt);
        }

        public bool IsEmpty()
        {
            return queue.Count > 0;
        }

        public Event Dequeue()
        {
            if (IsEmpty())
                throw new Exception("事件队列已为空");
            return queue.Dequeue();
        }

        public Event[] ToArray()
        {
            return queue.ToArray();
        }

        public void Clear()
        {
            queue.Clear();
        }
    }

    public class EventTool
    {
        public static void InvokeEvent<T>(UnityEngine.Events.UnityAction<Widget, T> action, Widget widget, T args)
        {
            if (action != null)
                action.Invoke(widget, args);
        }
    }

}
