using System;
using System.Drawing;
using System.Windows.Forms;

namespace Se7en.UI
{
    public class Processbar : Control
    {
        private event Action<Processbar, double> ValueChange;

        private Point _textloc;
        private double _deltaValue;
        private Rectangle _processRect;
        private string _text;

        #region Properties
        private double _maxValue = 100;
        public double MaxValue {
            get => _maxValue;
            set {
                if (MaxValue < Value)
                {
                    _maxValue = Value;
                }
                else
                {
                    _maxValue = value;
                }
                UpdateDeltaValue();
                Invalidate();
            }
        }

        private double _minValue = 0;
        public double MinValue {
            get => _minValue;
            set {
                if (MinValue > Value)
                {
                    _minValue = Value;
                }
                else
                {
                    _minValue = value;
                }
                UpdateDeltaValue();
                Invalidate();
            }
        }

        private double _Value;
        public double Value {
            get => _Value;
            set {
                if (Value < MinValue)
                    throw new IndexOutOfRangeException();
                if (Value > MaxValue)
                    throw new IndexOutOfRangeException();
                _Value = value;
                ValueChange?.Invoke(this, value);
                Invalidate();
            }
        }

        private Color _ProcessColor;
        public Color ProcessColor {
            get => _ProcessColor;
            set {
                _ProcessColor = value;
                BrushProcess = new SolidBrush(value);
                Invalidate();
            }
        }

        private bool _ValueVisible;
        public bool ValueVisible {
            get => _ValueVisible;
            set {
                _ValueVisible = value;
                Invalidate();
            }
        }
        #endregion

        #region Settings
        private SolidBrush BrushProcess;
        #endregion

        public Processbar()
        {
            ControlStyles styles = ControlStyles.ResizeRedraw
                                | ControlStyles.SupportsTransparentBackColor
                                | ControlStyles.UserPaint;
            SetStyle(styles, true);

            MaxValue = 100;
            MinValue = 0;
            Value = 20;
            ValueVisible = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            if (BrushProcess != null)
            {
                graphics.FillRectangle(BrushProcess, _processRect);
                if (ValueVisible)
                {
                    TextRenderer.DrawText(graphics, _text, Font, _textloc, ForeColor);
                }
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            UpdateRect();
        }
        private void UpdateRect()
        {
            double step = Width / _deltaValue;
            double width = (Value - MinValue) * step;
            Point topcorner = Point.Empty;
            Size progressSize = new Size((int)width, Height);
            _processRect = new Rectangle(Point.Empty, progressSize);
            UpdateText();
        }

        private void UpdateDeltaValue()
        {
            _deltaValue = MaxValue - MinValue;
            UpdateText();
        }

        private void UpdateText()
        {
            double textValue = 100 * Value / _deltaValue;
            _text = $"{System.Math.Round(textValue, 1)}%";

            Size sizeText = TextRenderer.MeasureText(_text, Font);
            int textX = (Width - sizeText.Width) / 2;
            int textY = (Height - sizeText.Height) / 2;
            _textloc = new Point(textX, textY);
        }
    }
}
