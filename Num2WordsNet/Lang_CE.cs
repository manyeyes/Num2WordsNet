using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Num2WordsNet
{
    internal class Lang_CE : Lang_EU
    {
        public static readonly Dictionary<string, string> CaseNames = new Dictionary<string, string>
    {
        {"abs", "Им."},
        {"gen", "Род."},
        {"dat", "Дат."},
        {"erg", "Эрг;"},
        {"instr", "Твор."},
        {"mat", "Вещ."},
        {"comp", "Сравнит."},
        {"all", "Местн."}
    };

        public static readonly Dictionary<string, string> CaseSuffixCons = new Dictionary<string, string>
    {
        {"gen", "аннан"},
        {"dat", "анна"},
        {"erg", "амма"},
        {"instr", "анца"},
        {"mat", "аннах"},
        {"comp", "аннал"},
        {"all", "анга"},
        {"obl", "ан"},
        {"ORD", "алгӀа"}
    };

        public static readonly Dictionary<string, string> CaseSuffixVoc = new Dictionary<string, string>
    {
        {"gen", "ннан"},
        {"dat", "нна"},
        {"erg", "мма"},
        {"instr", "нца"},
        {"mat", "ннах"},
        {"comp", "ннал"},
        {"all", "нга"},
        {"obl", "н"},
        {"ORD", "лгӀа"}
    };

        public static readonly Dictionary<int, Dictionary<string, string>> Cardinals = new Dictionary<int, Dictionary<string, string>>
    {
        {
            0, new Dictionary<string, string>
            {
                {"attr", "ноль"},
                {"abs", "ноль"},
                {"gen", "нолан"},
                {"dat", "нолана"},
                {"erg", "ноло"},
                {"instr", "ноланца"},
                {"mat", "ноланах"},
                {"comp", "ноланал"},
                {"all", "ноланга"}
            }
        },
        {
            1, new Dictionary<string, string>
            {
                {"attr", "цхьа"},
                {"obl", "цхьана"},
                {"abs", "цхьаъ"},
                {"gen", "цхьаннан"},
                {"dat", "цхьанна"},
                {"erg", "цхьамма"},
                {"instr", "цхьаьнца"},
                {"mat", "цхьаннах"},
                {"comp", "цхьаннал"},
                {"all", "цхаьнга"},
                {"ORD", "цхьалгӀа"}
            }
        },
        {
            2, new Dictionary<string, string>
            {
                {"attr", "ши"},
                {"obl", "шина"},
                {"abs", "шиъ"},
                {"gen", "шиннан"},
                {"dat", "шинна"},
                {"erg", "шимма"},
                {"instr", "шинца"},
                {"mat", "шиннах"},
                {"comp", "шиннал"},
                {"all", "шинга"},
                {"ORD", "шолгӀа"}
            }
        },
        {
            3, new Dictionary<string, string>
            {
                {"attr", "кхо"},
                {"obl", "кхона"},
                {"abs", "кхоъ"},
                {"gen", "кхааннан"},
                {"dat", "кхаанна"},
                {"erg", "кхаамма"},
                {"instr", "кхаанца"},
                {"mat", "кхааннах"},
                {"comp", "кхааннал"},
                {"all", "кхаанга"},
                {"ORD", "кхоалгӀа"}
            }
        },
        {
            4, new Dictionary<string, string>
            {
                {"attr", "д*и"},
                {"obl", "д*еа"},
                {"abs", "д*иъ"},
                {"gen", "д*еаннан"},
                {"dat", "д*еанна"},
                {"erg", "д*еамма"},
                {"instr", "д*еанца"},
                {"mat", "д*еаннах"},
                {"comp", "д*еаннал"},
                {"all", "д*еанга"},
                {"ORD", "д*оьалгӀа"}
            }
        },
        {
            5, new Dictionary<string, string>
            {
                {"attr", "пхи"},
                {"obl", "пхеа"},
                {"abs", "пхиъ"},
                {"gen", "пхеаннан"},
                {"dat", "пхеанна"},
                {"erg", "пхеамма"},
                {"instr", "нхеанца"},
                {"mat", "пхеаннах"},
                {"comp", "пхеаннал"},
                {"all", "пхеанга"},
                {"ORD", "пхоьалгӀа"}
            }
        },
        {
            6, new Dictionary<string, string>
            {
                {"abs", "ялх"},
                {"attr", "ялх"},
                {"ORD", "йолхалгӀа"}
            }
        },
        {
            7, new Dictionary<string, string>
            {
                {"abs", "ворхӀ"},
                {"attr", "ворхӀ"},
                {"ORD", "ворхӀалгӀа"}
            }
        },
        {
            8, new Dictionary<string, string>
            {
                {"abs", "бархӀ"},
                {"attr", "бархӀ"},
                {"ORD", "борхӀалӀа"}
            }
        },
        {
            9, new Dictionary<string, string>
            {
                {"abs", "исс"},
                {"attr", "исс"},
                {"ORD", "уьссалгӀa"}
            }
        },
        {
            10, new Dictionary<string, string>
            {
                {"attr", "итт"},
                {"abs", "итт"},
                {"gen", "иттаннан"},
                {"dat", "иттанна"},
                {"erg", "иттамма"},
                {"instr", "иттанца"},
                {"mat", "иттаннах"},
                {"comp", "иттаннал"},
                {"all", "иттанга"},
                {"ORD", "уьтталгӀа"}
            }
        },
        {
            11, new Dictionary<string, string>
            {
                {"abs", "цхьайтта"},
                {"attr", "цхьайтта"},
                {"ORD", "цхьайтталгӀа"}
            }
        },
        {
            12, new Dictionary<string, string>
            {
                {"abs", "шийтта"},
                {"attr", "шийтта"},
                {"ORD", "шийтталга"}
            }
        },
        {
            13, new Dictionary<string, string>
            {
                {"abs", "кхойтта"},
                {"attr", "кхойтта"},
                {"ORD", "кхойтталгӀа"}
            }
        },
        {
            14, new Dictionary<string, string>
            {
                {"abs", "д*ейтта"},
                {"attr", "д*ейтта"},
                {"ORD", "д*ейтталгӀа"}
            }
        },
        {
            15, new Dictionary<string, string>
            {
                {"abs", "пхийтта"},
                {"attr", "пхийтта"},
                {"ORD", "пхийтталгӀа"}
            }
        },
        {
            16, new Dictionary<string, string>
            {
                {"abs", "ялхитта"},
                {"attr", "ялхитта"},
                {"ORD", "ялхитталгӀа"}
            }
        },
        {
            17, new Dictionary<string, string>
            {
                {"abs", "вуьрхӀитта"},
                {"attr", "вуьрхӀитта"},
                {"ORD", "вуьрхӀитталгӀа"}
            }
        },
        {
            18, new Dictionary<string, string>
            {
                {"abs", "берхӀитта"},
                {"attr", "берхӀитта"},
                {"ORD", "берхитталӀа"}
            }
        },
        {
            19, new Dictionary<string, string>
            {
                {"abs", "ткъайесна"},
                {"attr", "ткъайесна"},
                {"ORD", "ткъаесналгӀа"}
            }
        },
        {
            20, new Dictionary<string, string>
            {
                {"abs", "ткъа"},
                {"gen", "ткъаннан"},
                {"dat", "ткъанна"},
                {"erg", "ткъамма"},
                {"instr", "ткъанца"},
                {"mat", "ткъаннах"},
                {"comp", "ткъаннал"},
                {"all", "ткъанга"},
                {"attr", "ткъе"},
                {"ORD", "ткъолгӀа"}
            }
        },
        {
            40, new Dictionary<string, string>
            {
                {"abs", "шовзткъа"},
                {"attr", "шовзткъе"},
                {"ORD", "шовзткъалгІа"}
            }
        },
        {
            60, new Dictionary<string, string>
            {
                {"abs", "кхузткъа"},
                {"attr", "кхузткъе"},
                {"ORD", "кхузткъалгІа"}
            }
        },
        {
            80, new Dictionary<string, string>
            {
                {"abs", "дезткъа"},
                {"attr", "дезткъе"},
                {"ORD", "дезткъалгІа"}
            }
        },
        {
            100, new Dictionary<string, string>
            {
                {"attr", "бӀе"},
                {"abs", "бӀе"},
                {"obl", "бӀен"},
                {"gen", "бӀеннан"},
                {"dat", "бӀенна"},
                {"erg", "бӀемма"},
                {"instr", "бӀенца"},
                {"mat", "бӀеннах"},
                {"comp", "бӀеннал"},
                {"all", "бӀенга"},
                {"ORD", "бІолгІа"}
            }
        },
        {
            1000, new Dictionary<string, string>
            {
                {"attr", "эзар"},
                {"abs", "эзар"},
                {"obl", "эзаран"},
                {"gen", "эзарнан"},
                {"dat", "эзарна"},
                {"erg", "эзарно"},
                {"instr", "эзарнаца"},
                {"mat", "эзарнах"},
                {"comp", "эзарнал"},
                {"all", "эзаранга"},
                {"ORD", "эзарлагІа"}
            }
        },
        {
            1000000, new Dictionary<string, string>
            {
                {"attr", "миллион"},
                {"abs", "миллион"},
                {"ORD", "миллионалгІа"}
            }
        }
    };

        public static readonly Dictionary<int, Dictionary<string, string>> Illions = new Dictionary<int, Dictionary<string, string>>
{
    {
        6, new Dictionary<string, string>
        {
            {"attr", "миллион"},
            {"abs", "миллион"},
            {"ORD", "миллионалгІа"}
        }
    },
    {
        9, new Dictionary<string, string>
        {
            {"attr", "миллиард"},
            {"abs", "миллиард"},
            {"ORD", "миллиардалгІа"}
        }
    },
    {
        12, new Dictionary<string, string>
        {
            {"attr", "биллион"},
            {"abs", "биллион"},
            {"ORD", "биллионалгІа"}
        }
    },
    {
        15, new Dictionary<string, string>
        {
            {"attr", "биллиард"},
            {"abs", "биллиард"},
            {"ORD", "биллиардалгІа"}
        }
    },
    {
        18, new Dictionary<string, string>
        {
            {"attr", "триллион"},
            {"abs", "триллион"},
            {"ORD", "триллионалгІа"}
        }
    },
    {
        21, new Dictionary<string, string>
        {
            {"attr", "триллиард"},
            {"abs", "триллиард"},
            {"ORD", "триллиардалгІа"}
        }
    },
    {
        24, new Dictionary<string, string>
        {
            {"attr", "квадриллион"},
            {"abs", "квадриллион"},
            {"ORD", "квадриллионалгІа"}
        }
    },
    {
        27, new Dictionary<string, string>
        {
            {"attr", "квадриллиард"},
            {"abs", "квадриллиард"},
            {"ORD", "квадриллиардалгІа"}
        }
    },
    {
        30, new Dictionary<string, string>
        {
            {"attr", "квинтиллион"},
            {"abs", "квинтиллион"},
            {"ORD", "квинтиллионалгІа"}
        }
    },
    {
        33, new Dictionary<string, string>
        {
            {"attr", "квинтиллиард"},
            {"abs", "квинтиллиард"},
            {"ORD", "квинтиллиардалгІа"}
        }
    }
};

        public const string Minus = "минус";
        public const string DecimalPoint = "а";


        public static readonly Dictionary<string, Tuple<string[], string[]>> CURRENCY_FORMS =
            new Dictionary<string, Tuple<string[], string[]>>
        {
        {
            "EUR",
            Tuple.Create(
                new[]{"Евро", "Евро" },
                new[]{"Сент", "Сенташ" }
            )
        },
        {
            "RUB",
            Tuple.Create(
                new[]{"Сом", "Сомаш"},
                new[]{"Кепек", "Кепекаш" }
            )
        },
        {
            "USD",
            Tuple.Create(
                new[]{"Доллар", "Доллараш" },
                new[] { "Сент", "Сенташ" }
            )
        },
        {
            "GBP",
            Tuple.Create(
                new[]{"Фунт", "Фунташ" },
                new[] { "Пенни", "Пенни" }
            )
        }
        };

        private List<Tuple<int, string>> mid_numwords = new List<Tuple<int, string>>();
        private List<string> low_numwords = new List<string>();
        private Dictionary<int, string> ords = new Dictionary<int, string>();

        public void Setup()
        {
            // 调用基类的Setup方法
            base.Setup();

            // 设置负数词和小数点词
            negword = "минус";
            pointword = "запятая";  // check !

            // 初始化空的数字词表和序数词映射
            mid_numwords = new List<Tuple<int, string>>();
            low_numwords = new List<string>();
            ords = new Dictionary<int, string>();
        }

        public string ToOrdinal(int number, string clazz = "д")
        {
            return ToCardinal(number, clazz, "ORD");
        }

        public string ToCardinal(int number, string clazz = "д", string caseForm = "abs")
        {
            if (number < 20)
            {
                return MakeCase(number, caseForm, clazz);
            }
            else if (number < 100)
            {
                int twens = number / 20;
                int units = number % 20;
                int baseNum = twens * 20;

                if (units == 0)
                {
                    return MakeCase(number, caseForm, clazz);
                }
                else
                {
                    string twenties = MakeCase(baseNum, "attr", clazz);
                    string rest = ToCardinal(units, clazz, caseForm);
                    return twenties + " " + rest.Replace("д*", clazz);
                }
            }
            else if (number < 1000)
            {
                int hundreds = number / 100;
                int tens = number % 100;

                string hundert = hundreds > 1 ?
                    Cardinals[hundreds]["attr"].Replace("д*", clazz) + " " :
                    "";

                if (tens != 0)
                {
                    string rest = ToCardinal(tens, clazz, caseForm);
                    return hundert + Cardinals[100]["abs"] + " " + rest;
                }
                else
                {
                    return hundert + MakeCase(100, caseForm, clazz);
                }
            }
            else if (number < 1000000)
            {
                int thousands = number / 1000;
                int hundert = number % 1000;

                string tcase = hundert > 0 ? "attr" : caseForm;
                string tausend;

                if (thousands > 1)
                {
                    tausend = ToCardinal(thousands, clazz, "attr") + " " + Cardinals[1000][tcase];
                }
                else
                {
                    tausend = MakeCase(1000, tcase, clazz);
                }

                string rest = hundert != 0 ?
                    " " + ToCardinal(hundert, clazz, caseForm) :
                    "";

                return tausend + rest;
            }
            else if (number < Math.Pow(10, 34))
            {
                List<string> outParts = new List<string>();
                int[] pots = { 6, 9, 12, 15, 18, 21, 24, 27, 30, 33 };

                foreach (int pot in pots.Reverse())
                {
                    int step = (int)(number / Math.Pow(10, pot) % 1000);
                    if (step > 0)
                    {
                        string words = ToCardinal(step, clazz, "attr");
                        outParts.Add(words + " " + Illions[pot]["attr"]);
                    }
                }

                int rest = number % (int)Math.Pow(10, 6);
                if (rest != 0)
                {
                    outParts.Add(ToCardinal(rest, clazz, caseForm));
                }

                return string.Join(" ", outParts);
            }

            return "NOT IMPLEMENTED";
        }

        public string ToCardinal(double number, string clazz = "д", string caseForm = "abs")
        {
            int integerPart = (int)number;
            string entires = ToCardinal(integerPart, clazz, caseForm);

            string floatStr = number.ToString("0.########", System.Globalization.CultureInfo.InvariantCulture);
            string[] parts = floatStr.Split('.');

            if (parts.Length > 1)
            {
                string floatPart = parts[1].TrimEnd('0');
                if (!string.IsNullOrEmpty(floatPart))
                {
                    string postfix = string.Join(" ", floatPart.Select(c => ToCardinal(int.Parse(c.ToString()), clazz, caseForm)));
                    return entires + " " + DecimalPoint + " " + postfix;
                }
            }

            return entires;
        }

        private string MoneyVerbose(int number, string currency, string caseForm)
        {
            string mcase = caseForm != "abs" ? "obl" : "attr";
            return ToCardinal(number, caseForm: mcase);
        }

        private string CentsVerbose(int number, string currency, string caseForm)
        {
            string mcase = caseForm != "abs" ? "obl" : "attr";
            return ToCardinal(number, caseForm: mcase);
        }

        public string ToCurrency(
            decimal val,
            string currency = "RUB",
            bool cents = true,
            string separator = ",",
            bool adjective = false,
            string caseForm = "abs")
        {
            var parts = ParseCurrencyParts(val);
            int left = parts.Item1;
            int right = parts.Item2;
            bool isNegative = parts.Item3;

            if (!CURRENCY_FORMS.TryGetValue(currency, out var currencyForms))
            {
                throw new NotImplementedException(
                    $"Currency code \"{currency}\" not implemented for \"{this.GetType().Name}\"");
            }

            var cr1 = currencyForms.Item1;
            var cr2 = currencyForms.Item2;
            string devise = cr1[0];  // 货币单位单数形式
            string centime = cr2[0]; // 辅币单位单数形式

            string minusStr = isNegative ? $"{Minus} " : "";
            string moneyStr = MoneyVerbose(left, currency, caseForm);
            string centsStr = cents ?
                CentsVerbose(right, currency, caseForm) :
                _CentsTerse(right, currency);

            return $"{minusStr}{moneyStr} {devise}{separator} {centsStr} {centime}";
        }

        public string ToOrdinalNum(int number)
        {
            VerifyOrdinal(number);
            return number + "-й";
        }

        public string ToYear(int year, string caseForm = "abs")
        {
            return ToCardinal(year, caseForm: caseForm);
        }

        protected string MakeCase(int number, string caseForm, string clazz = "д")
        {
            if (Cardinals.TryGetValue(number, out var numberCases))
            {
                if (numberCases.TryGetValue(caseForm, out string form))
                {
                    return form.Replace("д*", clazz);
                }
                else
                {
                    string absForm = numberCases["abs"];
                    var suffixes = absForm.EndsWith("а") ?
                        CaseSuffixVoc :
                        CaseSuffixCons;

                    if (suffixes.TryGetValue(caseForm, out string suffix))
                    {
                        return absForm.Replace("д*", clazz) + suffix;
                    }
                }
            }
            return number.ToString();
        }
    }
}
