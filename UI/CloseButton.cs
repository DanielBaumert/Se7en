using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Se7en.UI
{
    public class CloseButton : Control
    {
        public Color? HoverEffect { get; set; }
        public bool ScaleOutHoverEffect { get; set; }
        public int CrossWidth {
            get => _CrossWidth;
            set {
                if (_CrossWidth != value)
                {
                    _CrossWidth = value;
                    CalcSizes();
                    Invalidate();
                }
            }
        }

        public int HoverScaleOutWidth { get; set; }

        public CloseButton()
        {
            InitializeStyle();
            ForeColor = DefaultForeColor;
            Size = new Size(24, 24);
            Padding = new Padding(4);
            CrossWidth = 3;
            HoverScaleOutWidth = 1;
            HoverEffect = new Color?(Color.Transparent);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            CalcSizes();
            base.OnSizeChanged(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
            if (this.IsMouseEnter && this.HoverEffect != null && this.HoverEffect.Value != Color.Transparent)
            {
                graphics.Clear(this.HoverEffect.Value);
            }
            graphics.FillPath(new SolidBrush(this.ForeColor), this.LeftBlank);
            graphics.FillPath(new SolidBrush(this.ForeColor), this.RightBlank);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            IsMouseEnter = true;
            CalcSizes();
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            IsMouseEnter = false;
            CalcSizes();
            Invalidate();
        }

        protected override void OnPaddingChanged(EventArgs e)
        {
            base.OnPaddingChanged(e);
            CalcSizes();
            Invalidate();
        }

        private void InitializeStyle()
        {
            ControlStyles flag = ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.OptimizedDoubleBuffer;
            SetStyle(flag, true);
        }

        private void CalcSizes()
        {
            int num = CrossWidth / 2;
            Padding padding = Padding;
            if (IsMouseEnter && ScaleOutHoverEffect)
            {
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
            LeftBlank = graphicsPath;
            RightBlank = graphicsPath2;
        }

        private bool IsMouseEnter;
        private GraphicsPath LeftBlank;
        private GraphicsPath RightBlank;
        private int _CrossWidth;
    }
}
