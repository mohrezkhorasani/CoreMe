using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions.Addons
{
    public static class String______Extension
    {
        /// <summary>
        /// یه آیتم رو اول لیست اضافه می‌کنه (مثل Unshift در جاوااسکریپت)
        /// استفاده: myList.AddFirst(newItem);
        /// </summary>
        public static bool IsNullOrEmptyObject(this object str)
        {
            if(str == null) return true;
            if(string.IsNullOrEmpty(str.ToString()))
            {
                return true; 
            }
            return false;
        }
        public static string ToLink(this string relativePath, string baseUrl)
        {
            if (string.IsNullOrWhiteSpace(baseUrl))
                return relativePath ?? "";

            if (string.IsNullOrWhiteSpace(relativePath))
                return baseUrl.TrimEnd('/');

            // 1. baseUrl رو تمیز کن (حذف اسلش آخر)
            baseUrl = baseUrl.TrimEnd('/');

            // 2. relativePath رو تمیز کن (حذف اسلش‌های اول)
            relativePath = relativePath.TrimStart('/');

            // 3. اگر relativePath خودش یه URL کامل بود (مثلاً http یا https داشت) → همون رو برگردون
            if (relativePath.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                relativePath.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            {
                return relativePath;
            }

            // 4. ترکیب نهایی
            return $"{baseUrl}/{relativePath}";
        }
        public static string Truncate(this string input,int count=60)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            // اگر طول بیشتر از 25 است، برش بده و "..." اضافه کن
            if (input.Length > count)
                return input.Substring(0, count) + "...";

            // اگر کمتر یا برابر بود، خودش را برگردان
            return input;
        }
    }
}
