using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Num2WordsNet
{
    public class Lang_EN : Lang_EU
    {
        public List<Tuple<int, string>> mid_numwords = new List<Tuple<int, string>>();
        public string[] low_numwords;
        public Dictionary<string, string> ords = new Dictionary<string, string>();

        public override void Setup()
        {
            base.Setup();

            negword = "minus ";
            pointword = "point";
            exclude_title = new List<string> { "and", "point", "minus" };
            mid_numwords = new List<Tuple<int, string>>
        {
            Tuple.Create(1000, "thousand"), Tuple.Create(100, "hundred"),
            Tuple.Create(90, "ninety"), Tuple.Create(80, "eighty"), Tuple.Create(70, "seventy"),
            Tuple.Create(60, "sixty"), Tuple.Create(50, "fifty"), Tuple.Create(40, "forty"),
            Tuple.Create(30, "thirty"),Tuple.Create(20, "twenty")
        };
            low_numwords = new string[]
        {
             "twenty","nineteen", "eighteen", "seventeen",
            "sixteen", "fifteen", "fourteen", "thirteen",
            "twelve", "eleven", "ten", "nine", "eight",
            "seven", "six", "five", "four", "three", "two",
            "one", "zero"
        };
            ords = new Dictionary<string, string>
        {
            {"one", "first"},
            {"two", "second"},
            {"three", "third"},
            {"four", "fourth"},
            {"five", "fifth"},
            {"six", "sixth"},
            {"seven", "seventh"},
            {"eight", "eighth"},
            {"nine", "ninth"},
            {"ten", "tenth"},
            {"eleven", "eleventh"},
            {"twelve", "twelfth"}
        };
        }

        public override void SetHighNumwords(string[] high)
        {
            long max = 3 + 3 * high.Length;
            for (int i = 0; i < high.Length; i++)
            {
                long n = max - 3 * (i);
                if (n > 3)
                {
                    cards[(double)Math.Pow(10, n)] = high[i] + "illion";
                }
            }
        }

        public override (string, decimal) Merge((string, decimal) lpair, (string, decimal) rpair)
        {
            string ltext = lpair.Item1;
            decimal lnum = lpair.Item2;
            string rtext = rpair.Item1;
            decimal rnum = rpair.Item2;

            if (lnum == 1 && rnum < 100)
            {
                return (rtext, rnum);
            }
            else if (100 > lnum && lnum > rnum)
            {
                return ($"{ltext}-{rtext}", lnum + rnum);
            }
            else if (lnum >= 100 && 100 > rnum)
            {
                return ($"{ltext} and {rtext}", lnum + rnum);
            }
            else if (rnum > lnum)
            {
                return ($"{ltext} {rtext}", lnum * rnum);
            }
            return ($"{ltext}, {rtext}", lnum + rnum);
        }
        public override string ToOrdinal(decimal value)
        {
            VerifyOrdinal(value);
            string[] outwords = ToCardinal(value).Split(' ');
            string[] lastwords = outwords.Last().Split('-');
            string lastword = lastwords.Last().ToLower();
            if (ords.TryGetValue(lastword, out string ordinal))
            {
                lastword = ordinal;
            }
            else
            {
                if (lastword.EndsWith("y"))
                {
                    lastword = lastword.Substring(0, lastword.Length - 1) + "ie";
                }
                lastword += "th";
            }
            lastwords[lastwords.Length - 1] = Title(lastword);
            outwords[outwords.Length - 1] = string.Join("-", lastwords);
            return string.Join(" ", outwords);
        }

        public override string ToOrdinalNum(decimal value)
        {
            VerifyOrdinal(value);
            return $"{value}{ToOrdinal(value).Substring(ToOrdinal(value).Length - 2)}";
        }

        public override string ToYear(decimal val, bool longval = true, string suffix = null)
        {
            if (val < 0)
            {
                val = Math.Abs(val);
                suffix = suffix ?? "BC";
            }
            decimal high = val / 100;
            decimal low = val % 100;

            string valtext;
            if (high == 0 || (high % 10 == 0 && low < 10) || high >= 100)
            {
                valtext = ToCardinal(val);
            }
            else
            {
                string hightext = ToCardinal(high);
                string lowtext;
                if (low == 0)
                {
                    lowtext = "hundred";
                }
                else if (low < 10)
                {
                    lowtext = $"oh-{ToCardinal(low)}";
                }
                else
                {
                    lowtext = ToCardinal(low);
                }
                valtext = $"{hightext} {lowtext}";
            }
            return suffix == null ? valtext : $"{valtext} {suffix}";
        }
    }
}
