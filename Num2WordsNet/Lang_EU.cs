using Num2WordsNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Num2WordsNet
{
    public class Lang_EU : Num2Word_Base
    {
        // 定义通用的美元和分的形式
        private static readonly Tuple<string, string> GENERIC_DOLLARS = Tuple.Create("dollar", "dollars");
        private static readonly Tuple<string, string> GENERIC_CENTS = Tuple.Create("cent", "cents");
        private static string[]? high_numwords;

        // 货币形式字典
        public new Dictionary<string, Tuple<string[], string[]>> CURRENCY_FORMS = new Dictionary<string, Tuple<string[], string[]>>
        {
            { "AUD", Tuple.Create(GENERIC_DOLLARS.ToTupleArray(), GENERIC_CENTS.ToTupleArray()) },
            { "BYN", Tuple.Create(new[] { "rouble", "roubles" }, new[] { "kopek", "kopeks" }) },
            { "CAD", Tuple.Create(GENERIC_DOLLARS.ToTupleArray(), GENERIC_CENTS.ToTupleArray()) },
            { "EEK", Tuple.Create(new[] { "kroon", "kroons" }, new[] { "sent", "senti" }) },
            { "EUR", Tuple.Create(new[] { "euro", "euro" }, Tuple.Create(GENERIC_CENTS.Item1, GENERIC_CENTS.Item2).ToTupleArray()) },
            { "GBP", Tuple.Create(new[] { "pound sterling", "pounds sterling" }, new[] { "penny", "pence" }) },
            { "LTL", Tuple.Create(new[] { "litas", "litas" }, Tuple.Create(GENERIC_CENTS.Item1, GENERIC_CENTS.Item2).ToTupleArray()) },
            { "LVL", Tuple.Create(new[] { "lat", "lats" }, new[] { "santim", "santims" }) },
            { "USD", Tuple.Create(GENERIC_DOLLARS.ToTupleArray(), GENERIC_CENTS.ToTupleArray()) },
            { "RUB", Tuple.Create(new[] { "rouble", "roubles" }, new[] { "kopek", "kopeks" }) },
            { "SEK", Tuple.Create(new[] { "krona", "kronor" }, new[] { "öre", "öre" }) },
            { "NOK", Tuple.Create(new[] { "krone", "kroner" }, new[] { "øre", "øre" }) },
            { "PLN", Tuple.Create(new[] { "zloty", "zlotys", "zlotu" }, new[] { "grosz", "groszy" }) },
            { "MXN", Tuple.Create(new[] { "peso", "pesos" }, Tuple.Create(GENERIC_CENTS.Item1, GENERIC_CENTS.Item2).ToTupleArray()) },
            { "RON", Tuple.Create(new[] { "leu", "lei", "de lei" }, new[] { "ban", "bani", "de bani" }) },
            { "INR", Tuple.Create(new[] { "rupee", "rupees" }, new[] { "paisa", "paise" }) },
            { "HUF", Tuple.Create(new[] { "forint", "forint" }, new[] { "fillér", "fillér" }) },
            { "ISK", Tuple.Create(new[] { "króna", "krónur" }, new[] { "aur", "aurar" }) },
            { "UZS", Tuple.Create(new[] { "sum", "sums" }, new[] { "tiyin", "tiyins" }) },
            { "SAR", Tuple.Create(new[] { "saudi riyal", "saudi riyals" }, new[] { "halalah", "halalas" }) },
            { "JPY", Tuple.Create(new[] { "yen", "yen" }, new[] { "sen", "sen" }) },
            { "KRW", Tuple.Create(new[] { "won", "won" }, new[] { "jeon", "jeon" }) }
        };

        // 货币形容词字典
        public new Dictionary<string, string> CURRENCY_ADJECTIVES = new Dictionary<string, string>
        {
            { "AUD", "Australian" },
            { "BYN", "Belarusian" },
            { "CAD", "Canadian" },
            { "EEK", "Estonian" },
            { "USD", "US" },
            { "RUB", "Russian" },
            { "NOK", "Norwegian" },
            { "MXN", "Mexican" },
            { "RON", "Romanian" },
            { "INR", "Indian" },
            { "HUF", "Hungarian" },
            { "ISK", "íslenskar" },
            { "UZS", "Uzbekistan" },
            { "SAR", "Saudi" },
            { "JPY", "Japanese" },
            { "KRW", "Korean" }
        };

        // 十亿后缀和百万后缀
        public string GIGA_SUFFIX = "illiard";
        public string MEGA_SUFFIX = "illion";

        // 设置高数字单词
        public override void SetHighNumwords()
        {
            var high = high_numwords?.ToList();
            var lows = new[] { "non", "oct", "sept", "sext", "quint", "quadr", "tr", "b", "m" };
            var units = new[] { "", "un", "duo", "tre", "quattuor", "quin", "sex", "sept", "octo", "novem" };
            var tens = new[] { "dec", "vigint", "trigint", "quadragint", "quinquagint", "sexagint", "septuagint", "octogint", "nonagint" };
            high.Add("cent");
            high.AddRange(GenHighNumwords(units, tens, lows));

            int cap = 3 + 6 * high.Count;

            for (int i = 0; i < high.Count; i++)
            {
                int n = cap - 6 * i;
                if (!string.IsNullOrEmpty(GIGA_SUFFIX))
                {
                    cards[(decimal)Math.Pow(10, n)] = high[i] + GIGA_SUFFIX;
                }
                if (!string.IsNullOrEmpty(MEGA_SUFFIX))
                {
                    cards[(decimal)Math.Pow(10, n - 3)] = high[i] + MEGA_SUFFIX;
                }
            }
        }

        // 生成高数字单词
        private List<string> GenHighNumwords(string[] units, string[] tens, string[] lows)
        {
            var outList = new List<string>();
            foreach (var t in tens)
            {
                foreach (var u in units)
                {
                    outList.Add(u + t);
                }
            }
            outList.Reverse();
            outList.AddRange(lows);
            return outList;
        }

        // 处理复数形式
        public override string Pluralize(decimal n, string[] forms)
        {
            int form = n == 1 ? 0 : 1;
            return forms[form];
        }

        // 初始化设置
        public override void Setup()
        {
            var lows = new[] { "non", "oct", "sept", "sext", "quint", "quadr", "tr", "b", "m" };
            var units = new[] { "", "un", "duo", "tre", "quattuor", "quin", "sex", "sept", "octo", "novem" };
            var tens = new[] { "dec", "vigint", "trigint", "quadragint", "quinquagint", "sexagint", "septuagint", "octogint", "nonagint" };
            var high = new List<string> { "cent" };
            high.AddRange(GenHighNumwords(units, tens, lows));
            high_numwords = high.ToArray();
        }
    }

    // 扩展方法，用于将 Tuple<string, string> 转换为 string[]
    public static class TupleExtensions
    {
        public static string[] ToTupleArray(this Tuple<string, string> tuple)
        {
            return new[] { tuple.Item1, tuple.Item2 };
        }
    }
}
