using Se7en.Math;
using Se7en.UI.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Se7en.UI
{
    public class ScrollView : Control
    {

        private ListViewControl[] _Items;
        public ListViewControl[] Items {
            get => _Items;
            set {
                if (!Enumerable.SequenceEqual(value, _Items))
                {
                    _Items = value;
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {

        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {

        }
    }

    public abstract class ListViewControl
    {
        private int _index;
        public int Index {
            get => _index;
            set {
                if (value != _index)
                {
                    _index = value;
                    //TODO: Redraw
                }
            }
        }
        private Rectangle2D _Client;
        public Rectangle2D Client {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _Client;
            set {
                if (value != _Client)
                {
                    _Client = value;
                }
            }
        }
        public Point2D Position {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _Client.Position;
            set {
                if (value != _Client.Position)
                {
                    _Client.Position = value;
                }
            }
        }
        public int X {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _Client.X;
            set {
                if (value != _Client.X)
                {
                    _Client.X = value;
                }
            }
        }
        public int Y {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _Client.Y;
            set {
                if (value != _Client.Y)
                {
                    _Client.Y = value;
                }
            }
        }
        public Size2D Size {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _Client.Size;
            set {
                if (value != _Client.Size)
                {
                    _Client.Size = value;
                    OnSizeChanged(Size);
                }
            }
        }
        public int Width {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _Client.Width;
            set {
                if (value != _Client.Width)
                {
                    _Client.Width = value;
                    OnSizeChanged(Size);
                }
            }
        }
        public int Height {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _Client.Height;
            set {
                if (value != _Client.Height)
                {
                    _Client.Height = value;
                    OnSizeChanged(Size);
                }
            }
        }


        public abstract void OnPaint(PaintEventArgs args);
        public abstract void OnSizeChanged(Size2D newSize);
        public abstract void OnPositionChanged(Point2D newSize);
    }

}
