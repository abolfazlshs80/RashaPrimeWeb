
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public static class RandomExtention
{
	public static string GetShortLink(this string str)
	{
		if (string.IsNullOrEmpty(str))
		{
			return string.Empty;
		}
       /// تعریف کلمه‌ای که می‌خواهید از آن حروف انتخاب شود
        string word = "abcdefghi";

        // تولید یک رشته 5 حرفی تصادفی
        string randomString = GenerateRandomString(word, 5);

        return randomString;

    }
    static string GenerateRandomString(string source, int length)
    {
        Random random = new Random();
        char[] result = new char[length];

        for (int i = 0; i < length; i++)
        {
            // انتخاب یک شاخص تصادفی از کلمه منبع
            int randomIndex = random.Next(source.Length);
            result[i] = source[randomIndex];
        }

        return new string(result);
    }
}


