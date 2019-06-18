using System.Runtime.InteropServices;

namespace Se7en.Graphic {
    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct Color {
        [FieldOffset(0)]
        public int Value;
        [FieldOffset(0)]
        public byte A;
        [FieldOffset(1)]
        public byte R;
        [FieldOffset(2)]
        public byte G;
        [FieldOffset(4)]
        public byte B;

        public Color(byte r, byte g, byte b, byte a = 255) : this() {
            R = r;
            G = g;
            B = b;
            A = 255;
        }

        public Color(uint value) : this() {
            Value = (int) value;
        }

        public float GetBrightness() {
            float r = (float)R / 255.0f;
            float g = (float)G / 255.0f;
            float b = (float)B / 255.0f;

            float max, min;

            max = r;
            min = r;

            if (g > max)
                max = g;
            if (b > max)
                max = b;

            if (g < min)
                min = g;
            if (b < min)
                min = b;

            return (max + min) / 2;
        }
        public float GetHue() {
            if (R == G && G == B)
                return 0; // 0 makes as good an UNDEFINED value as any

            float r = (float)R / 255.0f;
            float g = (float)G / 255.0f;
            float b = (float)B / 255.0f;

            float max, min;
            float delta;
            float hue = 0.0f;

            max = r;
            min = r;

            if (g > max)
                max = g;
            if (b > max)
                max = b;

            if (g < min)
                min = g;
            if (b < min)
                min = b;

            delta = max - min;

            if (r == max) {
                hue = (g - b) / delta;
            } else if (g == max) {
                hue = 2 + (b - r) / delta;
            } else if (b == max) {
                hue = 4 + (r - g) / delta;
            }
            hue *= 60;

            if (hue < 0.0f) {
                hue += 360.0f;
            }
            return hue;
        }
        public float GetSaturation() {
            float r = (float)R / 255.0f;
            float g = (float)G / 255.0f;
            float b = (float)B / 255.0f;

            float max, min;
            float l, s = 0;

            max = r;
            min = r;

            if (g > max)
                max = g;
            if (b > max)
                max = b;

            if (g < min)
                min = g;
            if (b < min)
                min = b;

            // if max == min, then there is no color and
            // the saturation is zero.
            //
            if (max != min) {
                l = (max + min) / 2;

                if (l <= .5) {
                    s = (max - min) / (max + min);
                } else {
                    s = (max - min) / (2 - max - min);
                }
            }
            return s;
        }

    }
}
