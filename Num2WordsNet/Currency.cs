namespace Num2WordsNet
{
    internal class Currency
    {
        // 解析货币的整数部分、小数部分（分）和正负号
        public static (int integer, int cents, bool negative) ParseCurrencyParts(decimal value, bool isIntWithCents = true)
        {
            bool negative = value < 0;
            value = Math.Abs(value);

            int integer;
            int cents;

            if (value % 1 == 0 && isIntWithCents)
            {
                // 假设整数是带有分的
                integer = (int)(value / 100);
                cents = (int)(value % 100);
            }
            else
            {
                value = Math.Round(value, 2, MidpointRounding.AwayFromZero);
                integer = (int)value;
                cents = (int)((value - integer) * 100);
            }

            return (integer, cents, negative);
        }

        // 为每个基础字符串添加前缀
        public static string[] PrefixCurrency(string prefix, string[] baseArray)
        {
            string[] result = new string[baseArray.Length];
            for (int i = 0; i < baseArray.Length; i++)
            {
                result[i] = $"{prefix} {baseArray[i]}";
            }
            return result;
        }
    }
}