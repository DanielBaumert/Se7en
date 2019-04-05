#define CLOSE_ICON
using Se7en.Math;
using Se7en.UI.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;

namespace Se7en.UI
{
    public static class Icons
    {

#if CLOSE_ICON
        public static void CloseIcon(int width, int x, int y, Size2D size, ref GraphicsPath path) => CloseIcon(width, x, y, size.Width, size.Height, ref path);
        public static void CloseIcon(int width, Point2D position, int w, int h, ref GraphicsPath path) => CloseIcon(width, position.X, position.Y, w, h, ref path);
        public static void CloseIcon(int width, Point2D position, Size2D size, ref GraphicsPath path) => CloseIcon(width, position.X, position.Y, size.Width, size.Height, ref path); 
        public static void CloseIcon(int width, int x, int y, int w, int h, ref GraphicsPath path)
        {
            int ch2 = width / 2;
            using(GraphicsPath tmpPath = new GraphicsPath())
            {
                tmpPath.StartFigure();
                tmpPath.AddLine(ch2, 0, w, h - ch2);
                tmpPath.AddLine(w - ch2, h, 0, ch2);
                tmpPath.CloseFigure();

                tmpPath.StartFigure();
                tmpPath.AddLine(0, h - ch2, w - ch2, 0);
                tmpPath.AddLine(w, ch2, ch2, h);
                tmpPath.CloseFigure();
                
                Interlocked.Exchange(ref path, tmpPath);
            }
        }
        public static void CloseIcon(int width, int x, int y, int w, int h, int pl, int pr, int pt, int pb, ref GraphicsPath path)
        {
            int ch2 = width / 2;
            using (GraphicsPath tmpPath = new GraphicsPath())
            {
                tmpPath.StartFigure();
                tmpPath.AddLine(ch2 + pl, pt , w - pr, h - ch2 - pb);
                tmpPath.AddLine(w - ch2 - pr, h - pb, pl, ch2 + pt);
                tmpPath.CloseFigure();

                tmpPath.StartFigure();
                //tmpPath.AddLine(pl, h - ch2 - pb, w - ch2 - pr, );
                tmpPath.AddLine(w, ch2, ch2, h);
                tmpPath.CloseFigure();

                Interlocked.Exchange(ref path, tmpPath);
            }
        }
#endif
    }

}
