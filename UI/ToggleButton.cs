using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Se7en.UI
{
    public class ToggleButton : Control
    {
        public delegate void ToggledHandle(ToggleButton toggle);
        public delegate void PropertiesChangeEventHandle();

        #region Events
        #region PublicEvents
        public event ToggledHandle Toggled;
        public event PropertiesChangeEventHandle PropertiesChangeEvent;
        #endregion

        #region PrivateEvents

        #endregion
        #endregion

        #region Settings
        private GraphicsPath BackGraphicPath;
        private GraphicsPath ForeGraphicsPath;
        #endregion

        #region Properties
        private bool togglestate;
        [Category("States"), DisplayName("State")]
        public bool ToggleState {
            get => togglestate;
            set {
                PropertyChange<bool, EventArgs>(ref togglestate, value, OnResize, null);
                Toggled?.Invoke(this);
            }
        }

        private Color oncolor;
        [Category("Toggle"), DisplayName("On")]
        public Color OnColor {
            get => oncolor;
            set => PropertyChange(ref oncolor, value);
        }

        private Color offcolor;
        [Category("Toggle"), DisplayName("Off")]
        public Color OffColor {
            get => offcolor;
            set => PropertyChange(ref offcolor, value);
        }

        private Color togglecolor;
        [Category("Toggle"), DisplayName("Color")]
        public Color ToggleColor {
            get => togglecolor;
            set => PropertyChange(ref togglecolor, value);
        }
        #endregion

        #region HiddenProperties
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public new Color BackColor { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public new Color ForeColor { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public new Color Font { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public new string Text { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public new Image BackgroundImage { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public new ImageLayout BackgroundImageLayout { get; set; }
        #endregion

        public ToggleButton()
        {
            InitializeStyle();
            InitializeValues();
            InitializeEvents();
        }

        private void InitializeStyle()
        {
            ControlStyles styles = ControlStyles.OptimizedDoubleBuffer
                               | ControlStyles.SupportsTransparentBackColor
                               | ControlStyles.UserPaint
                               | ControlStyles.ResizeRedraw;
            SetStyle(styles, true);
        }

        private void InitializeValues()
        {
            BackColor = Color.Transparent;
            ToggleState = true;
            OnColor = Color.DodgerBlue;
            OffColor = Color.Red;
            ToggleColor = Color.White;

            BackColor = Color.Transparent;
            ForeColor = Color.Transparent;
        }

        private void InitializeEvents()
        {
            Resize += ToggleButton_Resize;
            Paint += ToggleButton_Paint;
            Click += ToggleButton_Click;
            DoubleClick += ToggleButton_Click;

            void ToggleButton_Resize(object sender, EventArgs e)
            {
                ///Setting
                ///
                int x = ToggleScanner(4, Width - Height + 4);
                ///Back
                ///
                GraphicsPath backgraphicsPath = new GraphicsPath();
                backgraphicsPath.AddArc(0, 0, Height, Height, 90, 180);
                backgraphicsPath.AddArc(Width - Height, 0, Height, Height, 270, 180);
                backgraphicsPath.CloseFigure();
                BackGraphicPath = backgraphicsPath;
                ///Fore
                ///
                GraphicsPath foregraphicsPath = new GraphicsPath();
                foregraphicsPath.StartFigure();
                foregraphicsPath.AddArc(x, 4, Height - 8, Height - 8, 0, 360);
                foregraphicsPath.CloseFigure();
                ForeGraphicsPath = foregraphicsPath;
            }

            void ToggleButton_Paint(object sender, PaintEventArgs e)
            {
                ///Setting
                ///
                Graphics graphics = e.Graphics;
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
                ///back
                ///
                if (BackGraphicPath != null)
                    graphics.FillPath(new SolidBrush(ToggleScanner(OnColor, OffColor)), BackGraphicPath);
                ///Fore
                ///
                if (ForeGraphicsPath != null)
                    graphics.FillPath(new SolidBrush(ToggleColor), ForeGraphicsPath);
            }

            void ToggleButton_Click(object sender, EventArgs e)
            {
                ToggleState = ToggleScanner(false, true);
            }

            #region EventHelper
            T ToggleScanner<T>(T argtrue, T argfalse) => ToggleState ? argtrue : argfalse;
            #endregion
        }

        private void PropertyChange<T>(ref T field, T value)
        {
            field = value;
            PropertiesChangeEvent?.Invoke();
            Invalidate();
        }

        private void PropertyChange<T, T1>(ref T field, T value, Action<T1> action, T1 arg)
        {
            PropertiesChangeEvent?.Invoke();
            field = value;
            action(arg);
            Invalidate();
        }
    }
}
