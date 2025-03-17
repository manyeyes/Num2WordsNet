using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Num2WordsNet
{
    public abstract class Num2Word_Base
    {
        // 货币形式字典
        public Dictionary<string, Tuple<string[], string[]>> CURRENCY_FORMS = new Dictionary<string, Tuple<string[], string[]>>();
        // 货币形容词字典
        public Dictionary<string, string> CURRENCY_ADJECTIVES = new Dictionary<string, string>();

        // 是否转换为标题格式
        public bool is_title;
        // 小数精度
        public int precision = 2;
        // 排除标题大小写转换的单词列表
        public List<string> exclude_title = new List<string>();
        // 负号前缀
        public string negword = "(-) ";
        // 小数点分隔符
        public string pointword = "(.)";
        // 非数字错误信息
        public string errmsg_nonnum = "type({0}) not in [long, int, float]";
        // 浮点数作为序数的错误信息
        public string errmsg_floatord = "Cannot treat float {0} as ordinal.";
        // 负数作为序数的错误信息
        public string errmsg_negord = "Cannot treat negative num {0} as ordinal.";
        // 数值过大的错误信息
        public string errmsg_toobig = "abs({0}) must be less than {1}.";

        // 有序字典存储数字和对应的单词
        public OrderedDictionary cards = new OrderedDictionary();
        // 最大支持的数值
        public decimal MAXVAL;

        public Num2Word_Base()
        {
            Setup();

            // 检查是否有高、中、低数字单词字段
            if (GetType().GetFields().Any(field => new[] { "high_numwords", "mid_numwords", "low_numwords" }.Contains(field.Name)))
            {
                SetNumwords();
                MAXVAL = 1000 * (decimal)cards.Cast<DictionaryEntry>().First().Key;
            }
        }

        public void SetNumwords()
        {
            SetHighNumwords();
            SetMidNumwords();
            SetLowNumwords();
        }

        // 设置高数字单词，抽象方法，由子类实现
        public virtual void SetHighNumwords()
        {
            throw new NotImplementedException();
        }

        public void SetMidNumwords()
        {
            var mid = (List<Tuple<int, string>>)GetType().GetField("mid_numwords").GetValue(this);
            foreach (var item in mid)
            {
                cards[item.Item1] = item.Item2;
            }
        }

        public void SetLowNumwords()
        {
            var numwords = (string[])GetType().GetField("low_numwords").GetValue(this);
            for (int i = 0; i < numwords.Length; i++)
            {
                cards[numwords.Length - 1 - i] = numwords[i];
            }
        }

        public List<object> Splitnum(decimal value)
        {
            foreach (DictionaryEntry entry in cards)
            {
                if ((decimal)entry.Key > value)
                {
                    continue;
                }

                var outList = new List<object>();
                if (value == 0)
                {
                    var div = 1;
                    var mod = 0;
                }
                else
                {
                    var div = Math.Floor(value / (decimal)entry.Key);
                    var mod = value % (decimal)entry.Key;

                    if (div == 1)
                    {
                        outList.Add(Tuple.Create(cards[1].ToString(), 1));
                    }
                    else
                    {
                        if (div == value)
                        {
                            return new List<object> { Tuple.Create(div * ((decimal?)entry.Value??0), (int)(div * (decimal)entry.Key)) };
                        }
                        outList.Add(Splitnum(div));
                    }

                    outList.Add(Tuple.Create(entry.Value.ToString(), (int)(decimal)entry.Key));

                    if (mod > 0)
                    {
                        outList.Add(Splitnum(mod));
                    }

                    return outList;
                }
            }
            return null;
        }

        public (string, string) ParseMinus(string num_str)
        {
            if (num_str.StartsWith("-"))
            {
                return (negword.Trim() + " ", num_str.Substring(1));
            }
            return ("", num_str);
        }

        public decimal StrToNumber(string value)
        {
            return decimal.Parse(value);
        }

        public virtual string ToCardinal(decimal value)
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

            string outStr = "";
            if (value < 0)
            {
                value = Math.Abs(value);
                outStr = negword.Trim() + " ";
            }

            if (value >= MAXVAL)
            {
                throw new OverflowException(string.Format(errmsg_toobig, value, MAXVAL));
            }

            var val = Splitnum(value);
            var (words, _) = Clean(val);
            return Title(outStr + words);
        }

        public (int, int) Float2Tuple(decimal value)
        {
            var pre = (int)value;
            precision = Math.Abs(decimal.GetBits(value)[3] >> 16 & 0x7F);
            var post = Math.Abs(value - pre) * (decimal)Math.Pow(10, precision);
            if (Math.Abs(Math.Round(post) - post) < 0.01m)
            {
                post = (int)Math.Round(post);
            }
            else
            {
                post = (int)Math.Floor(post);
            }

            return (pre, (int)post);
        }

        public string ToCardinalFloat(decimal value)
        {
            try
            {
                var _ = (float)value;
            }
            catch (Exception)
            {
                throw new ArgumentException(string.Format(errmsg_nonnum, value));
            }

            var (pre, post) = Float2Tuple(value);

            var postStr = post.ToString();
            postStr = new string('0', precision - postStr.Length) + postStr;

            var outList = new List<string> { ToCardinal(pre) };
            if (value < 0 && pre == 0)
            {
                outList.Insert(0, negword.Trim());
            }

            if (precision > 0)
            {
                outList.Add(Title(pointword));
            }

            for (int i = 0; i < precision; i++)
            {
                var curr = int.Parse(postStr[i].ToString());
                outList.Add(ToCardinal(curr));
            }

            return string.Join(" ", outList);
        }

        // 合并数字单词，虚方法，子类覆盖
        public virtual (string, int) Merge((string, int) curr, (string, int) next)
        {
            throw new NotImplementedException();
        }

        public (string, int) Clean(List<object> val)
        {
            var outList = val;
            while (val.Count != 1)
            {
                outList = new List<object>();
                var left = (Tuple<string, int>)val[0];
                var right = (Tuple<string, int>)val[1];
                if (left != null && right != null)
                {
                    outList.Add(Merge((left.Item1, left.Item2), (right.Item1, right.Item2)));
                    if (val.Count > 2)
                    {
                        outList.AddRange(val.Skip(2));
                    }
                }
                else
                {
                    foreach (var elem in val)
                    {
                        if (elem is List<object> listElem)
                        {
                            if (listElem.Count == 1)
                            {
                                outList.Add(listElem[0]);
                            }
                            else
                            {
                                outList.Add(Clean(listElem));
                            }
                        }
                        else
                        {
                            outList.Add(elem);
                        }
                    }
                }
                val = outList;
            }
            var result = (Tuple<string, int>)val[0];
            return (result.Item1, result.Item2);
        }

        public string Title(string value)
        {
            if (is_title)
            {
                var outList = new List<string>();
                var words = value.Split(' ');
                foreach (var word in words)
                {
                    if (exclude_title.Contains(word))
                    {
                        outList.Add(word);
                    }
                    else
                    {
                        outList.Add(char.ToUpper(word[0]) + word.Substring(1));
                    }
                }
                value = string.Join(" ", outList);
            }
            return value;
        }

        public void VerifyOrdinal(decimal value)
        {
            if ((int)value != value)
            {
                throw new ArgumentException(string.Format(errmsg_floatord, value));
            }
            if (value < 0)
            {
                throw new ArgumentException(string.Format(errmsg_negord, value));
            }
        }

        public virtual string ToOrdinal(decimal value)
        {
            return ToCardinal(value);
        }

        public virtual decimal ToOrdinalNum(decimal value)
        {
            return value;
        }

        public string Inflect(decimal value, string text)
        {
            var parts = text.Split('/');
            if (value == 1)
            {
                return parts[0];
            }
            return string.Join("", parts);
        }

        public string ToSplitnum(decimal val, string hightxt = "", string lowtxt = "", string jointxt = "",
                                 int divisor = 100, bool longval = true, bool cents = true)
        {
            var outList = new List<string>();

            int high, low;
            if (val % 1 != 0)
            {
                (high, low) = Float2Tuple(val);
            }
            else
            {
                high = (int)val / divisor;
                low = (int)val % divisor;
            }

            if (high > 0)
            {
                hightxt = Title(Inflect(high, hightxt));
                outList.Add(ToCardinal(high));
                if (low > 0)
                {
                    if (longval)
                    {
                        if (!string.IsNullOrEmpty(hightxt))
                        {
                            outList.Add(hightxt);
                        }
                        if (!string.IsNullOrEmpty(jointxt))
                        {
                            outList.Add(Title(jointxt));
                        }
                    }
                }
                else if (!string.IsNullOrEmpty(hightxt))
                {
                    outList.Add(hightxt);
                }
            }

            if (low > 0)
            {
                if (cents)
                {
                    outList.Add(ToCardinal(low));
                }
                else
                {
                    outList.Add(low.ToString("D2"));
                }
                if (!string.IsNullOrEmpty(lowtxt) && longval)
                {
                    outList.Add(Title(Inflect(low, lowtxt)));
                }
            }

            return string.Join(" ", outList);
        }

        public virtual string ToYear(decimal value, bool longval = true, string suffix = null)
        {
            return ToCardinal(value);
        }

        // 复数形式处理，抽象方法，由子类实现
        public virtual string Pluralize(decimal n, string[] forms)
        {
            throw new NotImplementedException();
        }

        public virtual string _MoneyVerbose(decimal number, string currency)
        {
            return ToCardinal(number);
        }

        public virtual string _CentsVerbose(decimal number, string currency)
        {
            return ToCardinal(number);
        }

        public virtual string _CentsTerse(decimal number, string currency)
        {
            return number.ToString("D2");
        }

        public virtual string ToCurrency(decimal val, string currency = "EUR", bool cents = true, string separator = ",",
                                 bool adjective = false)
        {
            var (left, right, is_negative) = ParseCurrencyParts(val);

            if (!CURRENCY_FORMS.ContainsKey(currency))
            {
                throw new NotImplementedException($"Currency code \"{currency}\" not implemented for \"{GetType().Name}\"");
            }

            var (cr1, cr2) = CURRENCY_FORMS[currency];

            if (adjective && CURRENCY_ADJECTIVES.ContainsKey(currency))
            {
                cr1 = PrefixCurrency(CURRENCY_ADJECTIVES[currency], cr1);
            }

            var minus_str = is_negative ? negword.Trim() + " " : "";
            var money_str = _MoneyVerbose(left, currency);

            var has_decimal = val % 1 != 0 || val.ToString().Contains(".");

            if (has_decimal || right > 0)
            {
                var cents_str = cents ? _CentsVerbose(right, currency) : _CentsTerse(right, currency);

                return $"{minus_str}{money_str} {Pluralize(left, cr1)}{separator} {cents_str} {Pluralize(right, cr2)}";
            }
            else
            {
                return $"{minus_str}{money_str} {Pluralize(left, cr1)}";
            }
        }

        // 解析货币的整数部分、小数部分和正负号
        public (int, int, bool) ParseCurrencyParts(decimal value)
        {
            bool negative = value < 0;
            value = Math.Abs(value);
            int integer = (int)value;
            int cents = (int)((value - integer) * 100);
            return (integer, cents, negative);
        }

        // 为每个字符串添加前缀
        public string[] PrefixCurrency(string prefix, string[] baseArray)
        {
            return baseArray.Select(item => $"{prefix} {item}").ToArray();
        }

        public virtual void Setup()
        {
            // 默认实现为空
        }
    }
}