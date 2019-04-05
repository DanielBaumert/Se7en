using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Se7en.UI
{
    [ComVisible(true)]
    public class SmoothLine : Panel
    {

        private Point _startAnchor;
        private Point _endAnchor;

        private LinearGradientBrush _linearGradientBrush;
        private ColorBlend _colorBlend;

        private ColorFadeItem[] _colors;
        public ColorFadeItem[] Colors {
            get => _colors;
            set {
                if (_colors != value)
                {
                    _colors = value;

                    float[] key = _colors.Select(x => x.Position).ToArray();
                    int count = _colors.Length;
                    Array.Sort(key, _colors);


                    if (_colors[0].Position != 0)
                        _colors[0].Position = 0;

                    int lastIndex = count - 1;
                    if (_colors[lastIndex].Position != 1f)
                        _colors[lastIndex].Position = 1f;

                    _colorBlend = new ColorBlend(count)
                    {
                        Colors = _colors.Select(x => x.Color).ToArray(),
                        Positions = _colors.Select(x => x.Position).ToArray()
                    };

                    UpdateLinearGrandientBrush();
                    Invalidate();
                }
            }
        }

        private Orientation _orientation;
        public Orientation Orientation {
            get => _orientation;
            set {
                if (_orientation != value)
                {
                    _orientation = value;
                    UpdateAnchor();
                    Invalidate();
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void UpdateLinearGrandientBrush()
        {
            if (_startAnchor != _endAnchor)
            {
                _linearGradientBrush?.Dispose();
                _linearGradientBrush = new LinearGradientBrush(_startAnchor, _endAnchor, BackColor, ForeColor)
                {
                    InterpolationColors = _colorBlend
                };
            }
        }


        public SmoothLine()
        {
            ControlStyles style =
               ControlStyles.UserPaint |
               ControlStyles.ResizeRedraw |
               ControlStyles.OptimizedDoubleBuffer |
               ControlStyles.SupportsTransparentBackColor;

            SetStyle(style, true);

            Colors = new ColorFadeItem[] {
                new ColorFadeItem( Color.Transparent,0),
                new ColorFadeItem( Color.DodgerBlue, 0.5f),
                new ColorFadeItem( Color.Transparent,  1f)
            };

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            switch (_colors.Length)
            {
                case 0:
                    graphics.Clear(BackColor);
                    break;
                case 1:
                    graphics.Clear(_colors[0].Color);
                    break;
                default:
                    if (_linearGradientBrush != null)
                    {
                        graphics.FillRectangle(_linearGradientBrush, ClientRectangle);
                    }
                    else
                    {
                        graphics.Clear(BackColor);
                    }
                    break;
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            UpdateAnchor();
            UpdateLinearGrandientBrush();
            Invalidate();
        }

        private void UpdateAnchor()
        {
            if (_orientation == Orientation.Vertical)
            {
                int halfWidth = (int)(Width * .5);
                _startAnchor = new Point(halfWidth, 0);
                _endAnchor = new Point(halfWidth, Height);
            }
            else
            {
                int halfHeight = (int)(Height * .5);
                _startAnchor = new Point(0, halfHeight);
                _endAnchor = new Point(Width, halfHeight);
            }
        }
    }
}
