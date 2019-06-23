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
using System.Windows.Forms;

namespace Se7en.UI {

    public class SimpleButton : Control {

        #region Text
        private string _text;
        private Font _textFont;
        private ContentAlignment _textAlign;
        public override string Text {
            get => _text;
            set {
                if (_text != value) {
                    _text = value;
                    Invalidate();
                }
            }
        }
        public override Font Font {
            get => _textFont;
            set {
                if (_textFont != value) {
                    _textFont = value;
                    Invalidate();
                }
            }
        }

        public ContentAlignment TextAlign {
            get => _textAlign;
            set {
                if (_textAlign != value) {
                    _textAlign = value;
                    Invalidate();
                }
            }
        }

        #endregion
 



        public SimpleButton() {
            ControlStyles style =
              ControlStyles.UserPaint |
              ControlStyles.ResizeRedraw |
              ControlStyles.OptimizedDoubleBuffer |
              ControlStyles.SupportsTransparentBackColor;

            SetStyle(style, true);
            _textFont = DefaultFont;
            _textAlign = ContentAlignment.MiddleCenter;
            _text = "SimpelButton";
        }

        protected override void OnPaint(PaintEventArgs e) {
            Size textSize = TextRenderer.MeasureText(_text, _textFont);
            Point textPoint = _textAlign switch
            {
                ContentAlignment.TopLeft => Point.Empty,
                ContentAlignment.TopCenter => new Point { X = (int)((Width - textSize.Width) * .5), Y = 0 },
                ContentAlignment.TopRight => new Point { X = Width - textSize.Width, Y = 0 },
                ContentAlignment.MiddleLeft => new Point { X = 0, Y = (int)((Height - textSize.Height) * .5) },
                ContentAlignment.MiddleCenter => new Point { X = (int)((Width - textSize.Width) * .5), Y = (int)((Height - textSize.Height) * .5) },
                ContentAlignment.MiddleRight => new Point { X = Width - textSize.Width, Y = (int)((Height - textSize.Height) * .5) },
                ContentAlignment.BottomLeft => new Point { X = 0, Y = Height - textSize.Height },
                ContentAlignment.BottomCenter => new Point { X = (int)((Width - textSize.Width) * .5), Y = Height - textSize.Height },
                ContentAlignment.BottomRight => new Point { X = Width - textSize.Width, Y = Height - textSize.Height },
                _ => throw new NotSupportedException("TextAlign")
            };


            TextRenderer.DrawText(e.Graphics, _text, _textFont, textPoint, ForeColor);
        }
    }
}