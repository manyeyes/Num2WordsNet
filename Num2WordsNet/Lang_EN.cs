using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Num2WordsNet
{
    public class Lang_EN : Lang_EU
    {
        protected Dictionary<long, string> cards = new Dictionary<long, string>();
        protected string negword = "minus ";
        protected string pointword = "point";
        protected List<string> exclude_title = new List<string> { "and", "point", "minus" };
        protected List<(long, string)> mid_numwords = new List<(long, string)>
        {
            (1000, "thousand"), (100, "hundred"),
            (90, "ninety"), (80, "eighty"), (70, "seventy"),
            (60, "sixty"), (50, "fifty"), (40, "forty"),
            (30, "thirty"),(20,"twenty")
        };
        protected List<string> low_numwords = new List<string>
        {
             "twenty","nineteen", "eighteen", "seventeen",
            "sixteen", "fifteen", "fourteen", "thirteen",
            "twelve", "eleven", "ten", "nine", "eight",
            "seven", "six", "five", "four", "three", "two",
            "one", "zero"
        };
        protected Dictionary<string, string> ords = new Dictionary<string, string>
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

        public void SetHighNumwords(List<string> high)
        {
            long max = 3 + 3 * high.Count;
            for (int i = 0; i < high.Count; i++)
            {
                long n = max - 3 * (i + 1);
                cards[(long)Math.Pow(10, n)] = high[i] + "illion";
            }
        }

        public (string, decimal) Merge((string, decimal) lpair, (string, decimal) rpair)
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

        protected string Title(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                return word;
            }
            return char.ToUpper(word[0]) + word.Substring(1);
        }

        public string ToCardinal(decimal value)
        {
            if (value < 0)
            {
                return negword + ToCardinal(-value);
            }
            if (value < 21)
            {
                return low_numwords[20 - (int)value];
            }
            if (value < 100)
            {
                decimal tens = (int)(value / 10) * 10;
                decimal units = value % 10;
                if (units == 0)
                {
                    return mid_numwords.First(x => x.Item1 == tens).Item2;
                }
                return $"{mid_numwords.First(x => x.Item1 == tens).Item2}-{low_numwords[20 - (int)units]}";
            }
            foreach (var (num, word) in mid_numwords)
            {
                if (value >= num)
                {
                    decimal quotient = value / num;
                    decimal remainder = value % num;
                    if (remainder == 0)
                    {
                        if (num == 100 || num == 1000)
                        {
                            return $"{ToCardinal(quotient)} {word}";
                        }
                        return word;
                    }
                    return Merge((ToCardinal(quotient) + " " + word, quotient * num), (ToCardinal(remainder), remainder)).Item1;
                }
            }
            foreach (var num in cards.Keys.OrderByDescending(x => x))
            {
                if (value >= num)
                {
                    decimal quotient = value / num;
                    decimal remainder = value % num;
                    if (remainder == 0)
                    {
                        return $"{ToCardinal(quotient)} {cards[num]}";
                    }
                    return Merge((ToCardinal(quotient) + " " + cards[num], quotient * num), (ToCardinal(remainder), remainder)).Item1;
                }
            }
            return "";
        }

        public void VerifyOrdinal(long value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Ordinal values must be non-negative.");
            }
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

        public string ToOrdinalNum(long value)
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
