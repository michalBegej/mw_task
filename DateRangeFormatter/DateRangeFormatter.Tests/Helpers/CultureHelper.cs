using System.Globalization;

namespace DateRangeFormatter.Tests.Helpers
{
    static class CultureHelper
    {
        public static void SetCultureInfoPl_PL()
        {
            CultureInfo.CurrentCulture = new CultureInfo("pl-PL");
        }

        public static void SetCultureInfoEn_Us()
        {
            CultureInfo.CurrentCulture = new CultureInfo("en-US");
        }
    }
}
