using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Se7en.UI {

    public class CircleBar : Control {

        public delegate void ValueChangeEventHandle(double value);

        public delegate void PropertyChangedEventHandler();

        #region events

        #region public

        public event ValueChangeEventHandle ValueChanged;

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion public

        #endregion events

        #region Properties

        #region Settings
        private double _MinValue = 0;
        private double _MaxValue = 100;
        private double _Value = 20;
        private int _OpenPiValue = 0;
        private Direction _OpenPiDirection = Direction.Top;
        private int _BarWidth = 10;
        private Color _BarValueColor = Color.DodgerBlue;
        private Color _BarBackColor = Color.FromArgb(36, 36, 36);
        private bool _TextVisibil = false;
        private Color _ForeColor = Color.White;
        private Color _BackColor = Color.FromArgb(64, 64, 64);
        #endregion Settings

        public double MinValue {
            get => _MinValue;
            set {
                if (MinValue == value)
                    return;
                PropertyUpdate(ref _MinValue, value, () => {
                    if (MinValue > MaxValue)
                        MinValue = MaxValue - 1;
                });
            }
        }

        public double MaxValue {
            get => _MaxValue;
            set {
                if (MinValue == value)
                    return;
                PropertyUpdate(ref _MaxValue, value, () => {
                    _MaxValue = value;
                    if (MaxValue < MinValue)
                        MaxValue = MinValue + 1;
                });
            }
        }

        public double Value {
            get => _Value;
            set {
                if (Value == value)
                    return;
                PropertyUpdate(action, ref _Value, value);

                void action() {
                    if (value > MaxValue)
                        throw new Exception("Value must be smaler then the max value");
                    if (value < MinValue)
                        throw new Exception("Value must be bigger then the min value");
                }
            }
        }

        public int OpenPiValue {
            get => _OpenPiValue;
            set {
                if (OpenPiValue == value)
                    return;
                PropertyUpdate(action, ref _OpenPiValue, value);

                void action() {
                    if (value > 360)
                        throw new Exception("Value must be smaler then 360");
                    if (value < 0)
                        throw new Exception("Value must be bigger then 0");
                }
            }
        }

        public Direction OpenPiDirection {
            get => _OpenPiDirection;
            set {
                if (OpenPiDirection == value)
                    return;
                PropertyUpdate(ref _OpenPiDirection, value);
            }
        }

        public int BarWidth {
            get => _BarWidth;
            set {
                if (BarWidth == value)
                    return;
                PropertyUpdate(ref _BarWidth, value);
            }
        }

        public Color BarValueColor {
            get => _BarValueColor;
            set {
                if (BarValueColor == value)
                    return;
                PropertyUpdate(ref _BarValueColor, value, () => BrushValuePi = new SolidBrush(BarValueColor));
            }
        }

        public Color BarBackColor {
            get => _BarBackColor;
            set {
                if (BarBackColor == value)
                    return;
                PropertyUpdate(ref _BarBackColor, value, () => BrushOuterPi = new SolidBrush(BarBackColor));
            }
        }

        public bool TextVisible {
            get => _TextVisibil;
            set {
                if (TextVisible == value)
                    return;
                PropertyUpdate(ref _TextVisibil, value);
            }
        }

        public Color ForeBarColor {
            get => _ForeColor;
            set {
                if (ForeBarColor == value)
                    return;
                PropertyUpdate(ref _ForeColor, value);
            }
        }

        public new Color BackColor {
            get => _BackColor;
            set {
                if (_BackColor == value)
                    return;
                PropertyUpdate(ref _BackColor, value, () => BrushInnaPi = new SolidBrush(value));
            }
        }

        #endregion Properties

        #region Settings
        private GraphicsPath PathInnaPi;
        private GraphicsPath PathOuterPi;
        private GraphicsPath PathValuePi;

        private SolidBrush BrushInnaPi = new SolidBrush(Color.FromArgb(36, 36, 36));
        private SolidBrush BrushOuterPi = new SolidBrush(Color.FromArgb(64, 64, 64));
        private SolidBrush BrushValuePi = new SolidBrush(Color.DodgerBlue);

        private Point TextLocation;
        private string PercentText;
        #endregion Settings

        public CircleBar() {
            InitializeStyle();
            InitializeEvents();
        }

        public void InitializeStyle() {
            ControlStyles styles = ControlStyles.OptimizedDoubleBuffer
                               | ControlStyles.SupportsTransparentBackColor
                               | ControlStyles.UserPaint
                               | ControlStyles.ResizeRedraw;
            SetStyle(styles, true);
        }

        public void InitializeEvents() {
            Resize += CircleBar_Resize;
            Paint += CircleBar_Paint;
            ValueChanged += CircleBar_ValueChanged;
            PropertyChanged += CircleBar_PropertyChanged;
        }

        private void CircleBar_Resize(object sender, EventArgs e) {
            if (Height != Width)
                Height = Width;
            ReCalcPis();
            CircleBar_ValueChanged(Value);
        }

        private void CircleBar_Paint(object sender, PaintEventArgs e) {
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;

            if (PathOuterPi != null)
                graphics.FillPath(BrushOuterPi, PathOuterPi);

            if (PathValuePi != null)
                graphics.FillPath(BrushValuePi, PathValuePi);

            if (PathInnaPi != null)
                graphics.FillPath(BrushInnaPi, PathInnaPi);

            if (TextVisible && !TextLocation.IsEmpty)
                TextRenderer.DrawText(graphics, PercentText, Font, TextLocation, ForeBarColor);
        }

        private void CircleBar_ValueChanged(double value) {
            Invalidate();
        }

        private void CircleBar_PropertyChanged() {
            ReCalcPis();
            Invalidate();
        }

        private void ReCalcPis() {
            Rectangle rect = new Rectangle(Point.Empty, Size);
            if (rect.IsEmpty)
                return;

            #region Settings
            double designeValue = MaxValue - MinValue;
            double designeValueDegressStep = (360 - OpenPiValue) / designeValue;

            double userValue = Value - MinValue;
            double userValueDegress = designeValueDegressStep * userValue;

            double outervalueDegress = designeValueDegressStep * (designeValue - userValue + 1);

            int valuePiStart = (int)OpenPiDirection - (OpenPiValue / 2);
            int valuePiEnd = -(int)userValueDegress;

            int OuterPiStart = (int)OpenPiDirection + (OpenPiValue / 2);
            int OuterPiEnd = (int)outervalueDegress;
            #endregion Settings

            #region ValuePi
            GraphicsPath valuePiPath = new GraphicsPath();
            valuePiPath.AddPie(rect, valuePiStart, valuePiEnd);
            valuePiPath.CloseFigure();
            PathValuePi = valuePiPath;
            #endregion ValuePi

            #region OuterPi
            GraphicsPath outerPiPath = new GraphicsPath();
            outerPiPath.AddPie(rect, OuterPiStart, OuterPiEnd);
            outerPiPath.CloseFigure();
            PathOuterPi = outerPiPath;
            #endregion OuterPi

            #region InnaPi
            int rectInnaPiW = rect.Width - (2 * BarWidth);
            int rectInnaPiH = rect.Height - (2 * BarWidth);

            int rectInnaPiLocVal = rect.Height - rectInnaPiH;
            int rectInnaPiX = rect.Location.X + (rectInnaPiLocVal / 2);
            int rectInnaPiY = rect.Location.Y + (rectInnaPiLocVal / 2);

            Point pointInnaPiLoc = new Point(rectInnaPiX, rectInnaPiY);
            Size sizeInnaPi = new Size(rectInnaPiW, rectInnaPiH);
            Rectangle rectInnaPi = new Rectangle(pointInnaPiLoc, sizeInnaPi);

            GraphicsPath innaPiPath = new GraphicsPath();
            innaPiPath.AddPie(rectInnaPi, 0, 360);
            innaPiPath.CloseFigure();
            PathInnaPi = innaPiPath;
            #endregion InnaPi

            if (TextVisible) {
                double percentVal = (100 * userValue) / (MaxValue - MinValue);
                PercentText = $"{System.Math.Round(percentVal, 1)}%";
                Size textSize = TextRenderer.MeasureText(PercentText, Font);
                int textX = (rect.Width - textSize.Width) / 2;
                int textY = (rect.Height - textSize.Height) / 2;
                Point textLocation = new Point(textX, textY);
                TextLocation = textLocation;
            }
        }

        [Browsable(false)]
        public void PropertyUpdate<T>(ref T field, T value) {
            field = value;
            PropertyChanged();
        }

        [Browsable(false)]
        public void PropertyUpdate<T>(ref T field, T value, Action action) {
            field = value;
            action();
            PropertyChanged();
        }

        public void PropertyUpdate<T>(Action action, ref T field, T value) {
            action();
            field = value;
            PropertyChanged();
        }
    }
}