using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Num2WordsNet
{
    // 自定义异常类，用于处理数字过大的情况
    public class NumberTooLargeError : Exception
    {
        public NumberTooLargeError(string message) : base(message) { }
    }

    public class Lang_BN : Num2Word_Base
    {
        // 排名数组，用于表示序数词
        private static readonly string[] RANKING = { "", "প্রথম", "দ্বিতীয়", "তৃতীয়", "চতুর্থ", "পঞ্চম", "ষষ্ঠ", "সপ্তম", "অষ্টম", "নবম", "দশম" };
        // 个位数字对应的孟加拉语单词数组
        private static readonly string[] AKOK = { "", "এক", "দুই", "তিন", "চার", "পাঁচ", "ছয়", "সাত", "আট", "নয়" };
        // 两位数对应的孟加拉语单词数组
        private static readonly string[] DOSOK = {
            "দশ", "এগারো", "বারো", "তেরো", "চৌদ্দ", "পনের",
            "ষোল", "সতের", "আঠারো", "উনিশ",
            "বিশ", "একুশ", "বাইশ", "তেইশ", "চব্বিশ", "পঁচিশ",
            "ছাব্বিশ", "সাতাশ", "আটাশ", "উনত্রিশ",
            "ত্রিশ", "একত্রিশ", "বত্রিশ", "তেত্রিশ", "চৌত্রিশ", "পঁইত্রিশ",
            "ছত্রিশ", "সাতত্রিশ", "আটত্রিশ", "উনচল্লিশ", "চল্লিশ",
            "একচল্লিশ", "বিয়াল্লিশ", "তেতাল্লিশ", "চৌচল্লিশ",
            "পঁয়তাল্লিশ", "ছেচল্লিশ", "সাতচল্লিশ", "আটচল্লিশ", "উনপঞ্চাশ",
            "পঞ্চাশ", "একান্ন", "বাহান্ন", "তিপ্পান্ন", "চুয়ান্ন", "পঞ্চান্ন",
            "ছাপ্পান্ন", "সাতান্ন", "আটান্ন", "উনষাট", "ষাট",
            "একষট্টি", "বাষট্টি", "তেষট্টি", "চৌষট্টি", "পঁয়ষট্টি",
            "ছিষট্টি", "সাতষট্টি", "আটষট্টি", "উনসত্তর", "সত্তর",
            "একাত্তর ", "বাহাত্তর", "তিয়াত্তর", "চুয়াত্তর", "পঁচাত্তর",
            "ছিয়াত্তর", "সাতাত্তর", "আটাত্তর", "উনআশি", "আশি",
            "একাশি", "বিরাশি", "তিরাশি", "চুরাশি", "পঁচাশি",
            "ছিয়াশি", "সাতাশি", "আটাশি", "উননব্বই", "নব্বই",
            "একানব্বই", "বিরানব্বই", "তিরানব্বই", "চুরানব্বই", "পঁচানব্বই",
            "ছিয়ানব্বই", "সাতানব্বই", "আটানব্বই", "নিরানব্বই"
        };
        // 千的孟加拉语单词
        private const string HAZAR = " হাজার ";
        //  lakh 的孟加拉语单词
        private const string LAKH = " লাখ ";
        //  crore 的孟加拉语单词
        private const string KOTI = " কোটি ";
        // 最大允许的数字
        BigInteger MAX_NUMBER = BigInteger.Parse("99999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999");

        // 将字符串转换为数字
        public static decimal StrToNumber(string number)
        {
            return Math.Abs(decimal.Parse(number));
        }

        // 解析数字，分离整数部分和小数部分
        public static (int integerPart, int decimalPart) ParseNumber(decimal number)
        {
            string decimalStr = (number - (int)number).ToString().Split('.').Skip(1).FirstOrDefault() ?? "0";
            return ((int)number, int.Parse(decimalStr));
        }

        // 解析 paisa（货币小数部分）
        public static (int integerPart, int paisaPart) ParsePaisa(decimal number)
        {
            string paisaStr = (number - (int)number).ToString().Split('.').Skip(1).FirstOrDefault() ?? "0";
            if (!string.IsNullOrEmpty(paisaStr))
            {
                paisaStr = (int.Parse(paisaStr) * 100).ToString().Substring(0, 2);
            }
            return ((int)number, int.Parse(paisaStr));
        }

        // 检查数字是否小于最大允许值
        private void IsSmallerThanMaxNumber(decimal number)
        {
            if (BigInteger.Parse(number.ToString()) >= MAX_NUMBER)//TODO:需要评估
            {
                throw new NumberTooLargeError($"Too Large number maximum value={MAX_NUMBER}");
            }
        }

        // 将小数部分转换为孟加拉语单词
        private string DosomikToBengaliWord(int number)
        {
            StringBuilder word = new StringBuilder();
            foreach (char digit in number.ToString())
            {
                word.Append(" ").Append(AKOK[int.Parse(digit.ToString())]);
            }
            return word.ToString();
        }

        // 将整数转换为孟加拉语单词
        private string NumberToBengaliWord(int number)
        {
            if (number == 0)
            {
                return "শূন্য";
            }

            StringBuilder words = new StringBuilder();

            if (number >= (int)Math.Pow(10, 7))
            {
                words.Append(NumberToBengaliWord(number / (int)Math.Pow(10, 7))).Append(KOTI);
                number %= (int)Math.Pow(10, 7);
            }

            if (number >= (int)Math.Pow(10, 5))
            {
                words.Append(NumberToBengaliWord(number / (int)Math.Pow(10, 5))).Append(LAKH);
                number %= (int)Math.Pow(10, 5);
            }

            if (number >= 1000)
            {
                words.Append(NumberToBengaliWord(number / 1000)).Append(HAZAR);
                number %= 1000;
            }

            if (number >= 100)
            {
                words.Append(AKOK[number / 100]).Append("শত ");
                number %= 100;
            }

            if (number >= 10 && number <= 99)
            {
                words.Append(DOSOK[number - 10]).Append(" ");
                number = 0;
            }

            if (number > 0 && number < 10)
            {
                words.Append(AKOK[number]).Append(" ");
            }

            return words.ToString().Trim();
        }

        // 将数字转换为孟加拉语货币表示
        public string ToCurrency(string val)
        {
            string dosomikWord = null;
            decimal number = StrToNumber(val);
            var (integerPart, decimalPart) = ParsePaisa(number);
            IsSmallerThanMaxNumber(integerPart);

            if (decimalPart > 0)
            {
                dosomikWord = $" {NumberToBengaliWord(decimalPart)} পয়সা";
            }

            string words = $"{NumberToBengaliWord(integerPart)} টাকা";

            if (dosomikWord != null)
            {
                return (words + dosomikWord).Trim();
            }
            return words.Trim();
        }

        // 将数字转换为孟加拉语基数词表示
        public string ToCardinal(string number)
        {
            string dosomikWord = null;
            decimal num = StrToNumber(number);
            var (integerPart, decimalPart) = ParseNumber(num);
            IsSmallerThanMaxNumber(integerPart);

            if (decimalPart > 0)
            {
                dosomikWord = $" দশমিক{DosomikToBengaliWord(decimalPart)}";
            }

            string words = NumberToBengaliWord(integerPart);

            if (dosomikWord != null)
            {
                return (words + dosomikWord).Trim();
            }
            return words.Trim();
        }

        // 将数字转换为孟加拉语序数词表示（这里简单返回基数词）
        public string ToOrdinal(string number)
        {
            return ToCardinal(number);
        }

        // 将数字转换为孟加拉语排名表示
        public string ToOrdinalNum(string number)
        {
            decimal num = StrToNumber(number);
            IsSmallerThanMaxNumber(num);

            int intNumber = (int)num;
            if (intNumber >= 1 && intNumber <= 10)
            {
                return RANKING[intNumber];
            }
            else
            {
                string rank = ToCardinal(intNumber.ToString());
                if (rank.EndsWith("ত"))
                {
                    return rank + "ম";
                }
                return rank + "তম";
            }
        }

        // 将数字转换为孟加拉语年份表示
        public string ToYear(string number)
        {
            decimal num = StrToNumber(number);
            IsSmallerThanMaxNumber(num);
            return ToCardinal(((int)num).ToString()) + " সাল";
        }
    }
}