using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Se7en.UI {

    public partial class TextBox : UserControl {

        private delegate void LineSizeStateSwitchHandle();

        #region Setting
        private Pen LinePen;
        #endregion Setting

        #region PrivateEvents

        private event LineSizeStateSwitchHandle LineStateSwitch;

        #endregion PrivateEvents

        #region Properties

        #region Line
        private Color _LineColor = Color.DodgerBlue;

        [Category("Line"), DisplayName("Color")]
        public Color LineColor {
            get => _LineColor;
            set {
                if (_LineColor != value) {
                    _LineColor = value;
                    LineStateSwitch();
                    Invalidate();
                }
            }
        }

        private int _LineHeight = 2;

        [Category("Line"), DisplayName("Height")]
        public int LineHeight {
            get => _LineHeight;
            set {
                if (_LineHeight != value) {
                    _LineHeight = value;

                    Rectangle rectText = FaceTextBoxBase.Bounds;
                    if (!Multiline)
                        Height = rectText.Height + LineMarginToText + LineHeight;
                    LineStateSwitch();

                    Invalidate();
                }
            }
        }

        private int _LineMarginLeft = 0;

        [Category("Line"), DisplayName("MarginLeft")]
        public int LineMarginLeft {
            get => _LineMarginLeft;
            set {
                if (_LineMarginLeft != value) {
                    _LineMarginLeft = value;
                    LineMarginHorizontal = -1;
                    _LineMarginLeft = value;

                    Invalidate();
                }
            }
        }

        private int _LineMarginRight = 0;

        [Category("Line"), DisplayName("MarginRight")]
        public int LineMarginRight {
            get => _LineMarginRight;
            set {
                if (_LineMarginRight != value) {
                    _LineMarginRight = value;
                    LineMarginHorizontal = -1;
                    _LineMarginRight = value;

                    Invalidate();
                }
            }
        }

        private int _LineMarginHorizontal;

        [Category("Line"), DisplayName("Horizontal")]
        public int LineMarginHorizontal {
            get => _LineMarginHorizontal;
            set {
                if (_LineMarginHorizontal != value) {
                    _LineMarginHorizontal = value;

                    if (value != -1) {
                        LineMarginLeft = value;
                        LineMarginRight = value;
                    }

                    Invalidate();
                }
            }
        }

        private int _LineMarginToText = 1;

        [Category("Line"), DisplayName("MarginToText")]
        public int LineMarginToText {
            get => _LineMarginToText;
            set {
                if (_LineMarginToText != value) {
                    _LineMarginToText = value;
                    Rectangle rectText = FaceTextBoxBase.Bounds;
                    if (!Multiline)
                        Height = rectText.Height + LineMarginToText + LineHeight;
                    LineStateSwitch();
                    Invalidate();
                }
            }
        }

        #endregion Line

        #region Text

        [Category("Text"), DisplayName("Color")]
        public new Color ForeColor {
            get => FaceTextBoxBase.ForeColor;
            set {
                if (base.ForeColor != value) {
                    base.ForeColor = value;
                    FaceTextBoxBase.ForeColor = value;
                }
            }
        }

        private string _Text;

        [Category("Text")]
        [Editor(typeof(System.ComponentModel.Design.MultilineStringEditor), typeof(UITypeEditor))]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Bindable(true)]
        public override string Text {
            get => _Text;
            set {
                if (_Text == value)
                    return;
                BeforeTextChanged?.Invoke(_Text);
                _Text = value;
                FaceTextBoxBase.Text = value;
                AfterTextChanged?.Invoke(_Text);
                if (CompareWith != null) {
                    IsCompare = _Text == CompareWith._Text;
                    CompareWith.CheckIsCompaterEvent?.Invoke(IsCompare.Value);
                }
            }
        }

        private Color? _IsntInput;

        [Category("Line")]
        public Color? IsntInput {
            get => _IsntInput;
            set {
                if (_IsntInput == value)
                    return;
                _IsntInput = value;
                Invalidate();
            }
        }

        private string _CueText = "Watermark";

        [Category("Text"), DisplayName("WaterMark")]
        public string CueText {
            get => _CueText;
            set {
                if (_CueText == value)
                    return;
                _CueText = value;
                FaceTextBoxBase.Cue = value;
                Invalidate();
            }
        }

        [Category("Text"), DisplayName("PasswortChar")]
        public char PasswortChar {
            get => FaceTextBoxBase.PasswordChar;
            set {
                if (FaceTextBoxBase.PasswordChar == value)
                    return;
                FaceTextBoxBase.PasswordChar = value;
                Invalidate();
            }
        }

        [Category("Text"), DisplayName("UseSystemPasswordChar")]
        public bool UseSystemPasswordChar {
            get => FaceTextBoxBase.UseSystemPasswordChar;
            set {
                if (FaceTextBoxBase.UseSystemPasswordChar == value)
                    return;
                FaceTextBoxBase.UseSystemPasswordChar = value;
                Invalidate();
            }
        }

        [Category("Text"), DisplayName("TextAlign")]
        public HorizontalAlignment TextAlign {
            get => FaceTextBoxBase.TextAlign;
            set => FaceTextBoxBase.TextAlign = value;
        }

        private bool _Multiline;

        [Category("Text"), DisplayName("Multiline")]
        public bool Multiline {
            get => _Multiline;
            set {
                if (_Multiline == value)
                    return;

                _Multiline = value;
                FaceTextBoxBase.Multiline = value;

                Invalidate();
            }
        }

        private bool _AutoScaleByText;

        [Category("Text")]
        [Description("Multiline == false, Ignore this")]
        public bool AutoScaleByText {
            get => _AutoScaleByText;
            set => _AutoScaleByText = value;
        }

        [Category("Text")]
        public new Font Font {
            get => base.Font;
            set {
                if (base.Font == value)
                    return;
                base.Font = value;
                FaceTextBoxBase.Font = value;
                Invalidate();
            }
        }

        private string _Patter;

        [Category("Text")]
        public string Patter {
            get => _Patter;
            set {
                if (_Patter == value)
                    return;
                _Patter = value;
                Invalidate();
            }
        }

        private Color _PatterError = Color.Red;

        [Category("Text")]
        public Color PatterError {
            get => _PatterError;
            set {
                if (_PatterError == value)
                    return;
                _PatterError = value;
                Invalidate();
            }
        }

        [Category("Text")]
        public bool IsMatch { get; private set; }

        [Category("Text")]
        public bool? IsCompare { get; private set; }

        private TextBox _CompareWith;

        [Category("Text")]
        public TextBox CompareWith {
            get => _CompareWith; set {
                _CompareWith = value;
            }
        }

        public new Color BackColor {
            get => base.BackColor;
            set {
                if (base.BackColor == value)
                    return;
                base.BackColor = value;
                FaceTextBoxBase.BackColor = value;
            }
        }

        #endregion Text

        #region Events

        public event Action<string> BeforeTextChanged;

        public event Action<string> AfterTextChanged;

        public event Action<bool> CheckIsCompaterEvent;

        public new event KeyEventHandler KeyDown {
            add => FaceTextBoxBase.KeyDown += value;
            remove => FaceTextBoxBase.KeyDown -= value;
        }

        public new event KeyEventHandler KeyUp {
            add => FaceTextBoxBase.KeyUp += value;
            remove => FaceTextBoxBase.KeyUp -= value;
        }

        public new event KeyPressEventHandler KeyPress {
            add => FaceTextBoxBase.KeyPress += value;
            remove => FaceTextBoxBase.KeyPress -= value;
        }

        #endregion Events

        #region HiddenProperties
        //[EditorBrowsable(EditorBrowsableState.Always)]

        #endregion HiddenProperties

        #endregion Properties

        public TextBox() {
            InitializeComponent();
            InitializeStyle();
            InitializeEvents();
            InitializeValues();
        }

        private void InitializeValues() {
            //LineColor = Color.DodgerBlue;
            ForeColor = Color.DodgerBlue;
            LineColor = Color.DodgerBlue;
            //BackColor = Color.FromArgb(36, 36, 36);
            Width = 140;
        }

        private void InitializeStyle() {
            ControlStyles styles = ControlStyles.ResizeRedraw
                                 | ControlStyles.SupportsTransparentBackColor;
            SetStyle(styles, true);
        }

        private void InitializeEvents() {
            Paint += PromptedTextBox_Paint;
            Resize += TextBox_Resize;
            FontChanged += TextBox_FontChanged;
            LineStateSwitch += TextBox_LineSizeStateSwitch;
            FaceTextBoxBase.TextChanged += FaceTextBoxBase_TextChanged;
            CheckIsCompaterEvent += TextBox_CheckIsCompaterEvent;

            void PromptedTextBox_Paint(object sender, PaintEventArgs e) => EventPaint(e);

            void TextBox_Resize(object sender, EventArgs e) => EventResize();

            void TextBox_FontChanged(object sender, EventArgs e) => EventResize();

            #region EventHelper
            void EventPaint(PaintEventArgs e) {
                Graphics graphics = e.Graphics;
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                Rectangle rect = Bounds;
                Rectangle rectText = FaceTextBoxBase.Bounds;

                #region UnderLine
                LinePen.Width = LineHeight;
                int lineXStart = LineMarginLeft;
                int lineXEnd = rect.Width - LineMarginRight;
                int lineYEnd = rectText.Height + LineMarginToText;
                Point lineStartLoc = new Point(lineXStart, lineYEnd);
                Point lineEndLoc = new Point(lineXEnd, lineYEnd);
                graphics.DrawLine(LinePen, lineStartLoc, lineEndLoc);
                #endregion UnderLine

                EventResize();
            }

            void TextBox_LineSizeStateSwitch() {
                Padding padding = Padding;
                padding.Bottom = LineHeight;
                Padding = padding;
                if (!string.IsNullOrEmpty(Patter) && !string.IsNullOrEmpty(Text)) {
                    IsMatch = Regex.IsMatch(Text, Patter);
                    bool tmpchoose = IsMatch;
                    if (IsCompare.HasValue) {
                        tmpchoose &= IsCompare.Value;
                    }
                    Pen tempPen = new Pen(tmpchoose ? LineColor : PatterError);
                    SetPen(tempPen);
                } else if (string.IsNullOrEmpty(Text)) {
                    Color tempColor = IsntInput != null ? IsntInput.Value : LineColor;
                    Pen tempPen = new Pen(tempColor, LineHeight);
                    SetPen(tempPen);
                } else {
                    Pen tempPen = new Pen(LineColor, LineHeight);
                    if (IsCompare.HasValue) {
                        tempPen.Color = IsCompare.Value ? LineColor : PatterError;
                    }
                    SetPen(tempPen);
                }

                void SetPen(Pen pen) {
                    if (LinePen == null) {
                        LinePen = pen;
                        Invalidate();
                        return;
                    }
                    if (LinePen.Color != pen.Color) {
                        LinePen = pen;
                        Invalidate();
                    }
                }
            }

            void FaceTextBoxBase_TextChanged(object sender, EventArgs e) {
                string value = (sender as System.Windows.Forms.TextBox).Text;
                Text = value;
                EventResize();
            }

            void EventResize() {
                if (!Multiline) {
                    int valH = FaceTextBoxBase.Height + LineMarginToText + LineHeight;
                    int valW = Width;
                    if (Height != valH || Width != valW) {
                        Size = new Size(valW, valH);
                    }
                } else {
                    if (AutoScaleByText) {
                        string text = string.IsNullOrEmpty(Text) ? " " : Text;
                        Font font = Font;
                        Size textSize = TextRenderer.MeasureText(text, font);
                        int val = textSize.Height + LineMarginToText + LineHeight;
                        if (Height != val) {
                            Height = val;
                        }
                    } else {
                        Font font = Font;
                        Size textSize = TextRenderer.MeasureText(" ", font);
                        int val = textSize.Height + LineMarginToText + LineHeight;
                        if (Height < val) {
                            Height = val;
                        }
                    }
                }
                TextBox_LineSizeStateSwitch();
            }

            void TextBox_CheckIsCompaterEvent(bool checker) {
                if (!IsCompare.HasValue) {
                    IsCompare = checker;
                    TextBox_LineSizeStateSwitch();
                    return;
                }
                if (IsCompare.Value != checker) {
                    IsCompare = checker;
                    TextBox_LineSizeStateSwitch();
                }
            }
            #endregion EventHelper
        }

        public void TriggerTextChange() {
            BeforeTextChanged?.Invoke(Text);
            AfterTextChanged?.Invoke(Text);
        }
    }
}