using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using Avalonia.Input;

namespace ControlCatalog
{
    public class DecoratedWindow : Window
    {
        public DecoratedWindow()
        {
            this.InitializeComponent();
        }

        void SetupSide(string name, StandardCursorType cursor, WindowEdge edge)
        {
            var ctl = this.Get<Control>(name);
            ctl.Cursor = new Cursor(cursor);
            ctl.PointerPressed += (i, e) =>
            {
                BeginResizeDrag(edge, e);
            };
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            this.Get<Control>("TitleBar").PointerPressed += (i, e) =>
            {
                BeginMoveDrag(e);
            };
            SetupSide("Left", StandardCursorType.LeftSide, WindowEdge.West);
            SetupSide("Right", StandardCursorType.RightSide, WindowEdge.East);
            SetupSide("Top", StandardCursorType.TopSide, WindowEdge.North);
            SetupSide("Bottom", StandardCursorType.BottomSide, WindowEdge.South);
            SetupSide("TopLeft", StandardCursorType.TopLeftCorner, WindowEdge.NorthWest);
            SetupSide("TopRight", StandardCursorType.TopRightCorner, WindowEdge.NorthEast);
            SetupSide("BottomLeft", StandardCursorType.BottomLeftCorner, WindowEdge.SouthWest);
            SetupSide("BottomRight", StandardCursorType.BottomRightCorner, WindowEdge.SouthEast);
            this.Get<Button>("MinimizeButton").Click += delegate { this.WindowState = WindowState.Minimized; };
            this.Get<Button>("MaximizeButton").Click += delegate
            {
                WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
            };
            this.Get<Button>("CloseButton").Click += delegate
            {
                Close();
            };
        }
    }
}
