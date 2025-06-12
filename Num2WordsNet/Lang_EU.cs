namespace Num2WordsNet
{
    public class Lang_EU : Num2Word_Base
    {
        // 定义通用的美元和分的形式
        private static readonly string[] GENERIC_DOLLARS = new string[] { "dollar", "dollars" };
        private static readonly string[] GENERIC_CENTS = new string[] { "cent", "cents" };

        // 货币形式字典
        public new Dictionary<string, Tuple<string[], string[]>> CURRENCY_FORMS = new Dictionary<string, Tuple<string[], string[]>>
        {
            { "AUD", Tuple.Create(GENERIC_DOLLARS, GENERIC_CENTS) },
            { "BYN", Tuple.Create(new[] { "rouble", "roubles" }, new[] { "kopek", "kopeks" }) },
            { "CAD", Tuple.Create(GENERIC_DOLLARS, GENERIC_CENTS) },
            { "EEK", Tuple.Create(new[] { "kroon", "kroons" }, new[] { "sent", "senti" }) },
            { "EUR", Tuple.Create(new[] { "euro", "euro" }, GENERIC_CENTS) },
            { "GBP", Tuple.Create(new[] { "pound sterling", "pounds sterling" }, new[] { "penny", "pence" }) },
            { "LTL", Tuple.Create(new[] { "litas", "litas" }, GENERIC_CENTS) },
            { "LVL", Tuple.Create(new[] { "lat", "lats" }, new[] { "santim", "santims" }) },
            { "USD", Tuple.Create(GENERIC_DOLLARS, GENERIC_CENTS) },
            { "RUB", Tuple.Create(new[] { "rouble", "roubles" }, new[] { "kopek", "kopeks" }) },
            { "SEK", Tuple.Create(new[] { "krona", "kronor" }, new[] { "öre", "öre" }) },
            { "NOK", Tuple.Create(new[] { "krone", "kroner" }, new[] { "øre", "øre" }) },
            { "PLN", Tuple.Create(new[] { "zloty", "zlotys", "zlotu" }, new[] { "grosz", "groszy" }) },
            { "MXN", Tuple.Create(new[] { "peso", "pesos" }, GENERIC_CENTS) },
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
        public string[] high_numwords;

        // 设置高数字单词
        public override void SetHighNumwords(string[] high)
        {
            int cap = 3 + 6 * high.Length;
            for (int i = 0; i < high.Length; i++)
            {
                int n = cap - 6 * i;
                if (!string.IsNullOrEmpty(GIGA_SUFFIX)) //double.PositiveInfinity
                {
                    cards[(double)Math.Pow(10, n)] = high[i] + GIGA_SUFFIX;
                }
                if (!string.IsNullOrEmpty(MEGA_SUFFIX))
                {
                    cards[(double)Math.Pow(10, n - 3)] = high[i] + MEGA_SUFFIX;
                }
            }
        }

        // 生成高数字单词
        public List<string> GenHighNumwords(string[] units, string[] tens, string[] lows)
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

    //// 扩展方法，用于将 Tuple<string, string> 转换为 string[]
    //public static class TupleExtensions
    //{
    //    public static string[] ToTupleArray(this Tuple<string, string> tuple)
    //    {
    //        return new[] { tuple.Item1, tuple.Item2 };
    //    }
    //}
}
