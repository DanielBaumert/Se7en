using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Se7en.UI
{
    public class SButton : Button
    {
        private Bitmap _Buffer;
        private bool _MouseEntered;
        private Color? _HoverColor;
        public Color? HoverColor {
            get => _HoverColor;
            set {
                if (value != _HoverColor)
                {
                    _HoverColor = value;
                    Invalidate();
                }
            }
        }
        public override string Text {
            get => base.Text;
            set {
                if (value != base.Text)
                {
                    base.Text = value;
                    DrawingText();
                    Invalidate();
                }
            }
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            if (_MouseEntered)
            {
                if (HoverColor.HasValue) pevent.Graphics.Clear(HoverColor.Value);
            }
            else
            {
                pevent.Graphics.Clear(BackColor);
            }
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics graphics = pevent.Graphics;
            if (_Buffer != null) graphics.DrawImage(_Buffer, Point.Empty);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            _MouseEntered = true;
            Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            _MouseEntered = false;
            Invalidate();
        }

        private void DrawingText()
        {
            using (Bitmap bmp = Image.FromHbitmap(Handle))
            {
                using (Graphics graphics = Graphics.FromImage(bmp))
                {
                    Size textSize = TextRenderer.MeasureText(Text, Font);
                    switch (TextAlign)
                    {
                        case ContentAlignment.TopLeft:
                            TextRenderer.DrawText(graphics, Text, Font, Point.Empty, ForeColor);
                            break;
                        case ContentAlignment.TopCenter:
                            TextRenderer.DrawText(graphics, Text, Font, new Point((Width - textSize.Width) / 2, 0), ForeColor);
                            break;
                        case ContentAlignment.TopRight:
                            TextRenderer.DrawText(graphics, Text, Font, new Point(Width - textSize.Width, 0), ForeColor);
                            break;
                        case ContentAlignment.MiddleLeft:
                            TextRenderer.DrawText(graphics, Text, Font, new Point(0, (Height - textSize.Height) / 2), ForeColor);
                            break;
                        case ContentAlignment.MiddleCenter:
                            TextRenderer.DrawText(graphics, Text, Font, new Point((Width - textSize.Width) / 2, (Height - textSize.Height) / 2), ForeColor);
                            break;
                        case ContentAlignment.MiddleRight:
                            TextRenderer.DrawText(graphics, Text, Font, new Point(Width - textSize.Width, (Height - textSize.Height) / 2), ForeColor);
                            break;
                        case ContentAlignment.BottomLeft:
                            TextRenderer.DrawText(graphics, Text, Font, new Point(0, Height - textSize.Height), ForeColor);
                            break;
                        case ContentAlignment.BottomCenter:
                            TextRenderer.DrawText(graphics, Text, Font, new Point((Width - textSize.Width) / 2, Height - textSize.Height), ForeColor);
                            break;
                        case ContentAlignment.BottomRight:
                            TextRenderer.DrawText(graphics, Text, Font, new Point(Width - textSize.Width, Height - textSize.Height), ForeColor);
                            break;
                    }
                }
                Interlocked.Exchange(ref _Buffer, bmp);
            }
        }
    }
}
