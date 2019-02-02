// <copyright company="Danfoss A/S">
//   2015 - 2019 Danfoss A/S. All rights reserved.
// </copyright>
namespace UrlReplace.Core
{
	internal static class StringArrayExtensions
	{
		internal static string TakeAndBlank(this string[] array, int index)
		{
			if (array.Length < index)
			{
				return string.Empty;
			}

			var result = array[index];
			array[index] = string.Empty;
			return result;
		}
	}
}