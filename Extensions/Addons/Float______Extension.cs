using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions.Addons
{
    public static class Float______Extension
    {
        /// <summary>
        /// عدد رو به ۲ رقم اعشار گرد می‌کنه
        /// مثال: 12.3456 → 12.35
        ///       12.3412 → 12.34
        /// </summary>
        public static float ToTwoDecimal(this float value)
        {
            return (float)Math.Round(value, 2);
        }

        public static double ToTwoDecimal(this double value)
        {
            return Math.Round(value, 2);
        }

        // اگه بخوای به string هم تبدیل کنه (برای نمایش)
        public static string ToTwoDecimalString(this float value)
        {
            return value.ToString("F2"); // F2 یعنی Fixed-point با ۲ رقم اعشار
        }

        public static string ToTwoDecimalString(this double value)
        {
            return value.ToString("F2");
        }
    }
}
