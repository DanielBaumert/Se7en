#if Windows
using Microsoft.Win32;
using Se7en.Windows.Api.Enum;
using Se7en.Windows.Api.Native;
using System.IO;

namespace Se7en.Windows
{
    public static class Wallpaper
    {
        /// <summary>
        /// set the desktop background image
        /// </summary>
        /// <param name="fileName">the path of image</param>
        /// <returns></returns>
        public unsafe static bool SetBackgroud(string fileName)
        {
            if (File.Exists(fileName))
            {
                fixed (char* fileNamePtr = fileName)
                {
                    return User32.SystemParametersInfo(SPI.SPI_SETDESKWALLPAPER, 0, fileNamePtr, (int)(SPIF.SPIF_SENDWININICHANGE | SPIF.SPIF_UPDATEINIFILE));
                }
            }
            return false;
        }

        /// <summary>
        /// set the desktop background image
        /// </summary>
        /// <param name="fileName">the path of image</param>
        /// <returns></returns>
        public static bool SetBackgroud(string fileName, WallpaperStyle wallpaperStyle)
        {
            if (SetBackgroud(fileName))
            {
                SetWallpaperStyle(wallpaperStyle);
                return true;
            }
            return false;
        }

        public unsafe static string GetPath()
        {
            string s = new string((char)0x0, 300);
            fixed (char* sPtr = s)
            {
                User32.SystemParametersInfo(SPI.SPI_SETDESKWALLPAPER, 300, sPtr, 0);
            }
            return s.ToString();
        }

        private static void SetWallpaperStyle(WallpaperStyle style)
        {
            if (style == WallpaperStyle.Fill)
            {
                SetOptions(@"WallpaperStyle", 10.ToString());
                SetOptions(@"TileWallpaper", 0.ToString());
            }
            if (style == WallpaperStyle.Fit)
            {
                SetOptions(@"WallpaperStyle", 6.ToString());
                SetOptions(@"TileWallpaper", 0.ToString());
            }
            if (style == WallpaperStyle.Span) // Windows 8 or newer only!
            {
                SetOptions(@"WallpaperStyle", 22.ToString());
                SetOptions(@"TileWallpaper", 0.ToString());
            }
            if (style == WallpaperStyle.Stretch)
            {
                SetOptions(@"WallpaperStyle", 2.ToString());
                SetOptions(@"TileWallpaper", 0.ToString());
            }
            if (style == WallpaperStyle.Tile)
            {
                SetOptions(@"WallpaperStyle", 0.ToString());
                SetOptions(@"TileWallpaper", 1.ToString());
            }
            if (style == WallpaperStyle.Center)
            {
                SetOptions(@"WallpaperStyle", 0.ToString());
                SetOptions(@"TileWallpaper", 0.ToString());
            }
        }

        /// <summary>
        /// set the option of registry
        /// </summary>
        /// <param name="optionsName">the name of registry</param>
        /// <param name="optionsData">set the data of registry</param>
        /// <param name="msg"></param>
        /// <returns></returns>
        private static bool SetOptions(string optionsName, string optionsData)
        {
            bool returnBool = true;
            RegistryKey classesRoot = Registry.CurrentUser;
            RegistryKey registryKey = classesRoot.OpenSubKey(@"Control Panel\Desktop", true);
            try
            {
                if (registryKey != null)
                {
                    registryKey.SetValue(optionsName.ToUpper(), optionsData);
                }
                else
                {
                    returnBool = false;
                }
            }
            catch
            {
                returnBool = false;
            }
            finally
            {
                classesRoot.Close();
                registryKey.Close();
            }
            return returnBool;
        }

    }
}
#endif