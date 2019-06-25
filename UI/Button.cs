#region MIT License

// Copyright (c) 2019 se7en- Daniel Baumert
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

#endregion

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Se7en.UI {
    public class Button : Control {

        #region Base

        private Color? _backColorHover;

        public Color? BackColorHover {
            get => _backColorHover;
            set {
                if (_backColorHover != value) {
                    _backColorHover = value;
                    Invalidate();
                }
            }
        }

        #endregion

        #region Text
        private string _text;
        private Font _textFont;
        private Color? _foreColorHover;
        private ContentAlignment _textAlign;

        private Size _textSize;
        private Point _textPoint;

        public override string Text {
            get => _text;
            set {
                if (_text != value) {
                    _text = value;
                    _textSize = TextRenderer.MeasureText(_text, _textFont);
                    CalcTextPos();
                    Invalidate();
                }
            }
        }
        public override Font Font {
            get => _textFont;
            set {
                if (_textFont != value) {
                    _textFont = value;
                    _textSize = TextRenderer.MeasureText(_text, _textFont);
                    CalcTextPos();
                    Invalidate();
                }
            }
        }

        public Color? ForeColorHover {
            get => _foreColorHover;
            set {
                if (_foreColorHover != value) {
                    _foreColorHover = value;
                    Invalidate();
                }
            }
        }

        public ContentAlignment TextAlign {
            get => _textAlign;
            set {
                if (_textAlign != value) {
                    _textAlign = value;
                    CalcTextPos();
                    Invalidate();
                }
            }
        }

        #endregion

        #region Marker

        private bool _markerDisplayed;
        private DockStyle _markerDockStyle;
        private Size _markerSize;
        private Point _markerOffset;


        private ColorFadeItem[] _markerColors;
        private ColorFadeItem[] _markerColorsHover;
        private ColorBlend _markerColorBlend;
        private ColorBlend _markerColorBlendHover;

        private Orientation _markerOrientation;
        private Point _markerAnchorStart;
        private Point _markerAnchorEnd;

        private Rectangle _markerRect;
        private bool _isHover;

        public bool MarkerDisplayed {
            get => _markerDisplayed;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {
                if (_markerDisplayed != value) {
                    _markerDisplayed = value;
                    if (_markerDisplayed) {
                        Invalidate();
                    }
                }
            }
        }

        public DockStyle MarkerDockStyle {
            get => _markerDockStyle;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {
                if (_markerDockStyle != value) {
                    _markerDockStyle = value;
                    if (_markerDisplayed) {
                        CalcMarkerRect();
                        Invalidate();
                    }
                }
            }
        }

        public Size MarkerSize {
            get => _markerSize;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {
                if (_markerSize != value) {
                    _markerSize = value;
                    if (_markerDisplayed) {
                        CalcMarkerRect();
                        Invalidate();
                    }
                }
            }
        }

        public Point MarkerOffset {
            get => _markerOffset;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {
                if (_markerOffset != value) {
                    _markerOffset = value;
                    if (_markerDisplayed) {
                        CalcMarkerRect();
                        Invalidate();
                    }
                }
            }
        }

        public Orientation MarkerBlendOrientation {
            get => _markerOrientation;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {
                if (_markerOrientation != value) {
                    _markerOrientation = value;
                    CalcMarkerAnchor();
                    Invalidate();
                }
            }
        }

        public ColorFadeItem[] MarkerColors {
            get => _markerColors;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {
                if (_markerColors != value) {
                    _markerColors = SortFadeColos(value);
                    CalcColorBlends(ref _markerColorBlend, ref _markerColors);
                    Invalidate();
                }
            }
        }
        public ColorFadeItem[] MarkerColorsHover {
            get => _markerColorsHover;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {
                if (_markerColorsHover != value) {
                    _markerColorsHover = SortFadeColos(value);
                    CalcColorBlends(ref _markerColorBlendHover, ref _markerColorsHover);
                    Invalidate();
                }
            }
        }


        #endregion

        public Button() {
            _isHover = false;
            ControlStyles style =
              ControlStyles.UserPaint |
              ControlStyles.ResizeRedraw |
              ControlStyles.OptimizedDoubleBuffer |
              ControlStyles.SupportsTransparentBackColor;

            SetStyle(style, true);

            _textAlign = ContentAlignment.MiddleCenter;
            _textFont = DefaultFont;

            _markerOffset = Point.Empty;
            _markerDockStyle = DockStyle.Left;
            _markerSize = new Size(2, 2);
            _markerOrientation = Orientation.Horizontal;
            _markerColors = new[] {
                new ColorFadeItem( Color.Transparent,0),
                new ColorFadeItem( Color.DodgerBlue, 1f),
            };

            _markerColorsHover = new ColorFadeItem[0];
            CalcMarkerRect();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ColorFadeItem[] SortFadeColos(ColorFadeItem[] items) {
            int count = items.Length;
            if (count > 1)
            {
                float[] key = items.Select(x => x.Position).ToArray();
                Array.Sort(key, items);

                if (items[0].Position != 0)
                    items[0].Position = 0;

                int lastIndex = count - 1;
                if (items[lastIndex].Position != 1f)
                    items[lastIndex].Position = 1f;
            }
            return items;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void CalcMarkerAnchor() {
            if (_markerOrientation == Orientation.Vertical) {
                int halfW = _markerRect.X + (int)(_markerRect.Width * .5f);
                _markerAnchorStart = new Point(halfW, _markerRect.Y);
                _markerAnchorEnd = new Point(halfW, _markerRect.Y + _markerRect.Height);
            } else {
                int halfH = _markerRect.Y + (int)(_markerRect.Height * .5f);
                _markerAnchorStart = new Point(_markerRect.X, halfH);
                _markerAnchorEnd = new Point(_markerRect.Y + _markerRect.Width, halfH);
            }

            CalcColorBlends(ref _markerColorBlend, ref _markerColors);
            CalcColorBlends(ref _markerColorBlendHover, ref _markerColorsHover);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void CalcColorBlends(ref ColorBlend blend, ref ColorFadeItem[] colors) {
            int count = colors.Length;
            if (count > 1) {
                blend = new ColorBlend(count) {
                    Colors = colors.Select(x => x.Color).ToArray(),
                    Positions = colors.Select(x => x.Position).ToArray()
                };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void CalcMarkerRect() { //TODO offset
            _markerRect = _markerDockStyle switch
            {
                DockStyle.Left => new Rectangle(0, 0, _markerSize.Width, Height),
                DockStyle.Right => new Rectangle(Width - _markerSize.Width, 0, _markerSize.Width, Height),
                DockStyle.Top => new Rectangle(0, 0, Width, _markerSize.Height),
                DockStyle.Bottom => new Rectangle(0, Height - _markerRect.Height, Width, _markerSize.Height),

                DockStyle.None => new Rectangle(_markerOffset, _markerSize),
                DockStyle.Fill => throw new NotSupportedException("DockSytle.Fill"),
                _ => throw new NotSupportedException("MarkerDockStyle")
            };
            CalcTextPos();
            CalcMarkerAnchor();
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void CalcTextPos() { //TODO MArker Offsets

            int width = _markerDockStyle == DockStyle.Left || _markerDockStyle == DockStyle.Right ? Width - _markerRect.Width : Width;
            int height = _markerDockStyle == DockStyle.Top || _markerDockStyle == DockStyle.Bottom ? Height - _markerRect.Height : Height;
            int xOffset = _markerDockStyle == DockStyle.Left ? _markerRect.Width : 0;
            int yOffset = _markerDockStyle == DockStyle.Top ? _markerRect.Height : 0;

            _textPoint = _textAlign switch
            {
                ContentAlignment.TopLeft => new Point { X = xOffset, Y = yOffset },
                ContentAlignment.TopCenter => new Point { X = xOffset + (int)((width - _textSize.Width) * .5), Y = yOffset },
                ContentAlignment.TopRight => new Point { X = xOffset + width - _textSize.Width, Y = yOffset },
                ContentAlignment.MiddleLeft => new Point { X = xOffset, Y = yOffset + (int)((height - _textSize.Height) * .5) },
                ContentAlignment.MiddleCenter => new Point { X = xOffset + (int)((width - _textSize.Width) * .5), Y = yOffset + (int)((height - _textSize.Height) * .5) },
                ContentAlignment.MiddleRight => new Point { X = xOffset + width - _textSize.Width, Y = yOffset + (int)((height - _textSize.Height) * .5) },
                ContentAlignment.BottomLeft => new Point { X = xOffset + 0, Y = yOffset + height - _textSize.Height },
                ContentAlignment.BottomCenter => new Point { X = xOffset + (int)((width - _textSize.Width) * .5), Y = yOffset + height - _textSize.Height },
                ContentAlignment.BottomRight => new Point { X = xOffset + width - _textSize.Width, Y = yOffset + height - _textSize.Height },
                _ => throw new NotSupportedException("TextAlign")
            };

        }

        protected override void OnSizeChanged(EventArgs e) {
            CalcTextPos();
            CalcMarkerRect();
        }

        protected override void OnMouseEnter(EventArgs e) {
            _isHover = true;
            Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e) {
            if (!_isHover) {
                _isHover = true;
                Invalidate();
            }
        }
        protected override void OnMouseLeave(EventArgs e) {
            _isHover = false;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e) {
            if (_isHover) {
                DrawEveryThing(e.Graphics, _foreColorHover ?? ForeColor , _backColorHover ?? BackColor , _markerColorsHover, _markerColorBlendHover);
            } else {
                DrawEveryThing(e.Graphics, ForeColor, BackColor, _markerColors, _markerColorBlend);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void DrawEveryThing(Graphics graphics, Color foreColor, Color bgColor, ColorFadeItem[] colors, ColorBlend blend) {
            if (_markerDisplayed) {
                if (colors.Length > 1) {
                    if (_markerAnchorStart != _markerAnchorEnd) {
                        using LinearGradientBrush brush = new LinearGradientBrush(_markerAnchorStart, _markerAnchorEnd, BackColor, ForeColor) {
                            InterpolationColors = blend
                        };
                        graphics.FillRectangle(brush, _markerRect);
                    }
                } else
                {
                    if (colors.Any())
                    {
                        Color color = colors[0].Color;
                        if (color != null)
                        {
                            using SolidBrush brush = new SolidBrush(color);
                            graphics.FillRectangle(brush, _markerRect);
                        }
                    } 
                }
            }
            TextRenderer.DrawText(graphics, _text, _textFont, _textPoint, foreColor);
        }
    }
}