using Num2WordsNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Num2WordsNet
{
    public class Lang_AM : Lang_EU
    {
        List<Tuple<int, string>> mid_numwords = new List<Tuple<int, string>>();
        List<string> low_numwords = new List<string>();
        Dictionary<string, string> ords = new Dictionary<string, string>();
        // 定义货币形式
        public new Dictionary<string, Tuple<string[], string[]>> CURRENCY_FORMS = new Dictionary<string, Tuple<string[], string[]>>
        {
            { "ETB", Tuple.Create(new[] { "ብር", "ብር" }, new[] { "ሳንቲም", "ሳንቲም" }) }
        };

        // 定义十亿和百万的后缀
        public new string GIGA_SUFFIX = "ቢሊዮን";
        public new string MEGA_SUFFIX = "ሚሊዮን";

        // 设置高数字单词
        public override void SetHighNumwords()
        {
            var high = new List<string>();
            // 这里需要根据实际情况填充 high 列表
            var cap = 3 * (high.Count + 1);

            for (int i = 0; i < high.Count; i++)
            {
                int n = cap - 3 * i;
                if (n == 9)
                {
                    cards[(decimal)Math.Pow(10, n)] = high[i] + GIGA_SUFFIX;
                }
                else
                {
                    cards[(decimal)Math.Pow(10, n)] = high[i] + MEGA_SUFFIX;
                }
            }
        }

        // 初始化设置
        public override void Setup()
        {
            base.Setup();

            negword = "አሉታዊ ";
            pointword = "ነጥብ";
            exclude_title = new List<string> { "እና", "ነጥብ", "አሉታዊ" };

            mid_numwords = new List<Tuple<int, string>>
            {
                Tuple.Create(1000, "ሺህ"),
                Tuple.Create(100, "መቶ"),
                Tuple.Create(90, "ዘጠና"),
                Tuple.Create(80, "ሰማኒያ"),
                Tuple.Create(70, "ሰባ"),
                Tuple.Create(60, "ስድሳ"),
                Tuple.Create(50, "አምሳ"),
                Tuple.Create(40, "አርባ"),
                Tuple.Create(30, "ሠላሳ")
            };

            low_numwords = new List<string>
            {
                "ሃያ", "አሥራ ዘጠኝ", "አሥራ ስምንት", "አሥራ ሰባት",
                "አስራ ስድስት", "አሥራ አምስት", "አሥራ አራት", "አሥራ ሦስት",
                "አሥራ ሁለት", "አሥራ አንድ", "አሥር", "ዘጠኝ", "ስምንት",
                "ሰባት", "ስድስት", "አምስት", "አራት", "ሦስት", "ሁለት",
                "አንድ", "ዜሮ"
            };

            ords = new Dictionary<string, string>
            {
                { "አንድ", "አንደኛ" },
                { "ሁለት", "ሁለተኛ" },
                { "ሦስት", "ሦስተኛ" },
                { "አራት", "አራተኛ" },
                { "አምስት", "አምስተኛ" },
                { "ስድስት", "ስድስተኛ" },
                { "ሰባት", "ሰባተኛ" },
                { "ስምንት", "ስምንተኛ" },
                { "ዘጠኝ", "ዘጠነኛ" },
                { "አሥር", "አሥረኛ" },
                { "አሥራ አንድ", "አሥራ አንደኛ" },
                { "አሥራ ሁለት", "አሥራ ሁለተኛ" },
                { "አሥራ ሦስት", "አሥራ ሦስተኛ" },
                { "አሥራ አራት", "አሥራ አራተኛ" },
                { "አሥራ አምስት", "አሥራ አምስተኛ" },
                { "አሥራ ስድስት", "አሥራ ስድስተኛ" },
                { "አሥራ ሰባት", "አሥራ ሰባተኛ" },
                { "አሥራ ስምንት", "አሥራ ስምንተኛ" },
                { "አሥራ ዘጠኝ", "አሥራ ዘጠነኛ" }
            };
        }

        // 转换为基数词
        public override string ToCardinal(decimal value)
        {
            try
            {
                if ((int)value != value)
                {
                    return ToCardinalFloat(value);
                }
            }
            catch (Exception)
            {
                return ToCardinalFloat(value);
            }

            string output = "";
            if (value >= MAXVAL)
            {
                throw new OverflowException(string.Format(errmsg_toobig, value, MAXVAL));
            }

            if (value == 100)
            {
                return Title(output + "መቶ");
            }
            else
            {
                var val = Splitnum(value);
                var (words, _) = Clean(val);
                return Title(output + words);
            }
        }

        // 合并数字和单词
        public override (string, int) Merge((string, int) lpair, (string, int) rpair)
        {
            var (ltext, lnum) = lpair;
            var (rtext, rnum) = rpair;

            if (lnum == 1 && rnum < 100)
            {
                return (rtext, rnum);
            }
            else if (100 > lnum && lnum > rnum)
            {
                return ($"{ltext} {rtext}", lnum + rnum);
            }
            else if (lnum >= 100 && 100 > rnum)
            {
                return ($"{ltext} {rtext}", lnum + rnum);
            }
            else if (rnum > lnum)
            {
                return ($"{ltext} {rtext}", lnum * rnum);
            }

            return ("", 0);
        }

        // 转换为序数词
        public override string ToOrdinal(decimal value)
        {
            VerifyOrdinal(value);
            var outwords = ToCardinal(value).Split(' ');
            var lastwords = outwords[outwords.Length - 1].Split('-');
            var lastword = lastwords[lastwords.Length - 1].ToLower();

            if (ords.TryGetValue(lastword, out string ordinal))
            {
                lastword = ordinal;
            }
            else
            {
                lastword += "ኛ";
            }

            lastwords[lastwords.Length - 1] = Title(lastword);
            outwords[outwords.Length - 1] = string.Join(" ", lastwords);

            return string.Join(" ", outwords);
        }

        // 转换为带序数词后缀的数字
        public override decimal ToOrdinalNum(decimal value)
        {
            VerifyOrdinal(value);
            return decimal.Parse($"{value}{ToOrdinal(value).Substring(ToOrdinal(value).Length - 1)}");
        }

        // 转换为货币表示
        public override string ToCurrency(decimal val, string currency = "ብር", bool cents = true, string separator = " ከ", bool adjective = true)
        {
            return base.ToCurrency(val, currency, cents, separator, adjective);
        }

        // 转换为年份表示
        public override string ToYear(decimal val, bool longval = true, string suffix = null)
        {
            if (((int)val / 100) % 10 == 0)
            {
                return ToCardinal(val);
            }
            return ToSplitnum(val, hightxt: "መቶ", longval: longval);
        }
    }
}