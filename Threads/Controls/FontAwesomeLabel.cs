namespace Threads.Controls
{
    public class FontAwesomeLabel : Label
    {
        const string FAS = "FAS";
        const string FAR = "FAR";
        const string FAB = "FAB";

        public FontAwesomeLabel(FontAwesomeStyle style, string icon)
        {
            FontFamily = style switch
            {
                FontAwesomeStyle.Brand => FAB,
                FontAwesomeStyle.Solid => FAS,
                FontAwesomeStyle.Regular => FAR,
                _  => throw new NotImplementedException()
            };

            Text = icon;
        }
    }

    public enum FontAwesomeStyle
    {
        Regular,
        Solid,
        Brand
    }
}
