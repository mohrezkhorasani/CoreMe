using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions.Addons
{
    public static class List______Extension
    {
        /// <summary>
        /// یه آیتم رو اول لیست اضافه می‌کنه (مثل Unshift در جاوااسکریپت)
        /// استفاده: myList.AddFirst(newItem);
        /// </summary>
        public static void AddFirst<T>(this List<T> list, T item)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));
            list.Insert(0, item);
        }

        /// <summary>
        /// چند تا آیتم رو اول لیست اضافه می‌کنه (از آخر به اول)
        /// استفاده: myList.AddFirstRange(item1, item2, item3);
        /// </summary>
        public static void AddFirstRange<T>(this List<T> list, params T[] items)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));
            if (items == null || items.Length == 0) return;

            // از آخر به اول اضافه می‌کنیم تا ترتیب درست بمونه
            for (int i = items.Length - 1; i >= 0; i--)
            {
                list.Insert(0, items[i]);
            } 
        }

        /// <summary>
        /// چند تا آیتم رو اول لیست اضافه می‌کنه (از آخر به اول)
        /// استفاده: myList.AddFirstRange(item1, item2, item3);
        /// </summary>
        public static void AddFirstRange<T>(this List<T> list, List<T> items)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));
            if (items == null || items.Count == 0) return;

            // از آخر به اول اضافه می‌کنیم تا ترتیب درست بمونه
            for (int i = items.Count - 1; i >= 0; i--)
            {
                list.Insert(0, items[i]);
            }
        }

        /// <summary>
        /// یه مجموعه (مثل IEnumerable) رو اول لیست اضافه می‌کنه
        /// </summary>
        public static void AddFirstRange<T>(this List<T> list, IEnumerable<T> items)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));
            if (items == null) return;

            var temp = items.ToList();
            for (int i = temp.Count - 1; i >= 0; i--)
            {
                list.Insert(0, temp[i]);
            }
        }
    }
}
