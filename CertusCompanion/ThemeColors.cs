using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertusCompanion
{
    [Serializable]
    class ThemeColors
    {
        private Color itemDefault = Color.FromArgb(56, 159, 99);
        private Color itemMonotone = Color.FromArgb(56, 159, 99);
        private Color mainThemeLight = Color.FromArgb(102, 210, 160);
        private Color mainTheme = Color.FromArgb(46, 200, 150);
        private Color mainThemeDark = Color.FromArgb(39, 174, 96);
        private Color mainThemeDarker = Color.FromArgb(28, 137, 74);
        private Color spaceLightest = Color.FromArgb(64, 64, 64);
        private Color spaceLighter = Color.FromArgb(40, 40, 40);
        private Color spaceLight = Color.FromArgb(27, 27, 27);
        private Color spaceLightOff = Color.FromArgb(27, 35, 50);
        private Color space = Color.FromArgb(20, 20, 20);
        private Color spaceDark = Color.FromArgb(15, 15, 15);

        public Color ItemDefault { get => itemDefault; set => itemDefault = value; }
        public Color ItemMonotone { get => itemMonotone; set => itemMonotone = value; }
        public Color MainThemeLight { get => mainThemeLight; set => mainThemeLight = value; }
        public Color MainTheme { get => mainTheme; set => mainTheme = value; }
        public Color MainThemeDark { get => mainThemeDark; set => mainThemeDark = value; }
        public Color MainThemeDarker { get => mainThemeDarker; set => mainThemeDarker = value; }
        public Color SpaceLightest { get => spaceLightest; set => spaceLightest = value; }
        public Color SpaceLighter { get => spaceLighter; set => spaceLighter = value; }
        public Color SpaceLight { get => spaceLight; set => spaceLight = value; }
        public Color SpaceLightOff { get => spaceLightOff; set => spaceLightOff = value; }
        public Color Space { get => space; set => space = value; }
        public Color SpaceDark { get => spaceDark; set => spaceDark = value; }
    }
}
