using System;
using System.Drawing;

namespace CertusCompanion
{
    [Serializable]
    public struct ThemeColors
    {
        public static Color ItemDefault { get; } = Color.FromArgb(46, 204, 113);
        public static Color ItemMonotone { get; } = Color.FromArgb(46, 204, 113);
        public static Color MainThemeLight { get; } = Color.FromArgb(102, 210, 160);
        public static Color MainTheme { get; } = Color.FromArgb(46, 200, 150);
        public static Color MainThemeDark { get; } = Color.FromArgb(39, 174, 96);
        public static Color MainThemeDarker { get; } = Color.FromArgb(28, 137, 74);
        public static Color SpaceLightest { get; } = Color.FromArgb(64, 64, 64);
        public static Color SpaceLighter { get; } = Color.FromArgb(40, 40, 40);
        public static Color SpaceLight { get; } = Color.FromArgb(27, 27, 27);
        public static Color SpaceLightOff { get; } = Color.FromArgb(27,50,55);
        public static Color Space { get; } = Color.FromArgb(20, 20, 20);
        public static Color SpaceDark { get; } = Color.FromArgb(15, 15, 15);
    }
}
