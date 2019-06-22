using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Se7en.UI {

    public class CloseButton : Control {
        public Color? HoverEffect { get; set; }
        public bool ScaleOutHoverEffect { get; set; }

        public int CrossWidth {
            get => _crossWidth;
            set {
                if (_crossWidth != value) {
                    _crossWidth = value;
                    CalcSizes();
                    Invalidate();
                }
            }
        }

        public int HoverScaleOutWidth { get; set; }

        public CloseButton() {
            InitializeStyle();
            ForeColor = DefaultForeColor;
            Size = new Size(24, 24);
            Padding = new Padding(4);
            CrossWidth = 3;
            HoverScaleOutWidth = 1;
            HoverEffect = new Color?(Color.Transparent);
        }

        protected override void OnSizeChanged(EventArgs e) {
            CalcSizes();
        }

        protected override void OnPaint(PaintEventArgs e) {
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
            if (this._isMouseEnter && this.HoverEffect != null && this.HoverEffect.Value != Color.Transparent) {
                graphics.Clear(this.HoverEffect.Value);
            }
            graphics.FillPath(new SolidBrush(this.ForeColor), this._leftBlank);
            graphics.FillPath(new SolidBrush(this.ForeColor), this._rightBlank);
        }

        protected override void OnMouseEnter(EventArgs e) {
            _isMouseEnter = true;
            CalcSizes();
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e) {
            _isMouseEnter = false;
            CalcSizes();
            Invalidate();
        }

        protected override void OnPaddingChanged(EventArgs e) {
            base.OnPaddingChanged(e);
            CalcSizes();
            Invalidate();
        }

        private void InitializeStyle() {
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void CalcSizes() {
            int num = CrossWidth / 2;
            Padding padding = Padding;
            if (_isMouseEnter && ScaleOutHoverEffect) {
                padding.All = Padding.All - HoverScaleOutWidth;
            }
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.StartFigure();
            graphicsPath.AddLine(padding.Left + num, padding.Top, padding.Left, padding.Top + num);
            graphicsPath.AddLine(padding.Left, padding.Top + num, Width - num - padding.Right, Height - padding.Bottom);
            graphicsPath.AddLine(Width - num - padding.Right, Height - padding.Bottom, Width - padding.Right, Height - padding.Bottom - num);
            graphicsPath.CloseFigure();
            GraphicsPath graphicsPath2 = new GraphicsPath();
            graphicsPath2.AddLine(padding.Left, Height - padding.Bottom - num, padding.Left + num, Height - padding.Bottom);
            graphicsPath2.AddLine(padding.Left + num, Height - padding.Bottom, Width - padding.Right, padding.Top + num);
            graphicsPath2.AddLine(Width - padding.Right, padding.Top + num, Width - (padding.Right + num), padding.Top);
            graphicsPath2.CloseFigure();
            _leftBlank = graphicsPath;
            _rightBlank = graphicsPath2;
        }

        private bool _isMouseEnter;
        private GraphicsPath _leftBlank;
        private GraphicsPath _rightBlank;
        private int _crossWidth;
    }
}