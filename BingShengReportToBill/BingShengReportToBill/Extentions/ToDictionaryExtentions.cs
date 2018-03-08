using System;
using System.Collections.Generic;

namespace BingShengReportToBill.Extentions
{
	/// <summary>
	/// ToDictionary的扩展方法
	/// </summary>
	public static class ToDictionaryExtentions
	{
		public static Dictionary<TKey,TValue> ToDictionaryEx<TElement, TKey, TValue>(this IEnumerable<TElement> source,
			Func<TElement,TKey> keyGetter,
			Func<TElement,TValue> valueGetter)
		{
			Dictionary<TKey, TValue> dict = new Dictionary<TKey, TValue>();
			foreach (var e in source)
			{
				var key = keyGetter(e);
				if (dict.ContainsKey(key))
				{
					continue;
				}
				dict.Add(key, valueGetter(e));
			}
			return dict;
		}
	}
}
