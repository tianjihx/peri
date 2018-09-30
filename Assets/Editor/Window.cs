using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace Peri
{
    public class Window : Widget
    {
        public EventQueue EventQueue;
        public Point StartPosition { get; set; }
        public Container RootContainer { get; set; }
        public Point MinSize { get; set; }
        public Point MaxSize { get; set; }
        public string Title { get; set; }
        private bool repaintFlag;

        public event UnityAction<Widget, EventArgs> OnRepaint;

        public override string TypeName
        {
            get
            {
                return "Window";
            }
        }

        public Window()
        {
            EventQueue = new EventQueue();
            StartPosition = new Point(100, 100);
            MinSize = new Point(100, 100);
            MaxSize = new Point(1920, 1080);
            RootContainer = new Canvas();
            RootContainer.WindowIn = this;
            RootContainer.Name = "RootCanvas";
            RootContainer.IsRoot = true;
            RootContainer.IsAutoSize = false;
            Width = 640;
            Height = 480;
        }

        

        public override void CheckEvent()
        {

        }

        public override void HandleEvent()
        {
            //foreach (var evt in EventQueue.ToArray())
            //{
            //    if (evt.Type == EventType.Repaint)
            //    {
            //        EventTool.InvokeEvent(OnRepaint, this, new EventArgs());
            //    }
            //}
            //Debug.Log("window Handle Event");
            //Debug.Log("repaintFlag is " + repaintFlag);
            if (repaintFlag)
            {
                EventTool.InvokeEvent(OnRepaint, this, new EventArgs());
            }
        }

        public override void UpdateDraw()
        {
            CheckEvent();
            
            RootContainer.UpdateDraw();

            HandleEvent();
            EventQueue.Clear();
            repaintFlag = false;
        }

        public override void Draw()
        {
        }

        public void RepaintEvent()
        {
            repaintFlag = true;
        }
    }
}
