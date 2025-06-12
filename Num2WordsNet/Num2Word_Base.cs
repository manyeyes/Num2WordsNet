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
        public Dictionary<double, string> cards = new Dictionary<double, string>();
        // 最大支持的数值
        public double MAXVAL;

        public Num2Word_Base()
        {
            Setup();

            // 检查是否有高、中、低数字单词字段
            if (GetType().GetFields().Any(field => new[] { "high_numwords", "mid_numwords", "low_numwords" }.Contains(field.Name)))
            {
                SetNumwords();
                MAXVAL = 1000 * (double)cards.First().Key;
            }
        }

        public void SetNumwords()
        {
            var high = (string[]?)GetType().GetField("high_numwords").GetValue(this) ?? null;
            var mid = (List<Tuple<int, string>>?)GetType().GetField("mid_numwords").GetValue(this) ?? null;
            var low = (string[])GetType().GetField("low_numwords").GetValue(this);
            SetHighNumwords(high);
            SetMidNumwords(mid);
            SetLowNumwords(low);
        }

        // 设置高数字单词，抽象方法，由子类实现
        public virtual void SetHighNumwords(string[] high)
        {
            throw new NotImplementedException();
        }

        public virtual void SetMidNumwords(List<Tuple<int, string>>  mid)
        {            
            foreach (var item in mid)
            {
                cards[item.Item1] = item.Item2;
            }
        }

        public virtual void SetLowNumwords(string[] numwords)
        {            
            for (int i = 0; i < numwords.Length; i++)
            {
                cards[numwords.Length - 1 - i] = numwords[i];
            }
        }

        public List<object> Splitnum(decimal value)
        {
            foreach (var entry in cards)
            {
                if (entry.Key > (double)value)
                {
                    continue;
                }

                var outList = new List<object>();
                decimal div = 0;
                decimal mod = 0;
                if (value == 0)
                {
                    div = 1;
                    mod = 0;
                }
                else
                {
                    div = Math.Floor(value / (decimal)entry.Key);
                    mod = value % (decimal)entry.Key;
                }

                if (div == 1)
                {
                    if (mod > 0)
                    {
                        outList.Add(Tuple.Create(cards[1].ToString(), (decimal)1));
                    }
                }
                else
                {
                    if (div == value)
                    {
                        return new List<object> { Tuple.Create(div * (decimal)entry.Key, (div * (decimal)entry.Key)) };
                    }
                    var c = Clean(Splitnum(div));
                    var cTuple = Tuple.Create(c.Item1, c.Item2);
                    outList.Add(cTuple);
                    //outList.AddRange(Splitnum(div));
                }

                outList.Add(Tuple.Create(entry.Value.ToString(), (decimal)entry.Key));

                if (mod > 0)
                {
                    var c = Clean(Splitnum(mod));
                    var cTuple = Tuple.Create(c.Item1,  c.Item2);
                    outList.Add(cTuple);
                    //outList.AddRange(Splitnum(mod));
                }

                return outList;

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

            if ((double)value >= MAXVAL)
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
        public virtual (string, decimal) Merge((string, decimal) curr, (string, decimal) next)
        {
            throw new NotImplementedException();
        }

        public (string, decimal) Clean(List<object> val)
        {
            var outList = val;
            while (val.Count != 1)
            {
                outList = new List<object>();
                var left = (Tuple<string, decimal>)val[0];
                var right = (Tuple<string, decimal>)val[1];
                if (left != null && right != null)
                {
                    var xxx = Merge((left.Item1, left.Item2), (right.Item1, right.Item2));
                    outList.Add(Tuple.Create(xxx.Item1, xxx.Item2));
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
            var result = (Tuple<string, decimal>)val[0];
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

        public virtual string ToOrdinalNum(decimal value)
        {
            return value.ToString();
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