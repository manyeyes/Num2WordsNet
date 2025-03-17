using Num2WordsNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Num2WordsNet
{
    public class Lang_BE : Num2Word_Base
    {
        private const string ZERO = "нуль";

        private readonly Dictionary<int, string> ONES_FEMININE = new Dictionary<int, string>
        {
            { 1, "адна" },
            { 2, "дзве" },
            { 3, "тры" },
            { 4, "чатыры" },
            { 5, "пяць" },
            { 6, "шэсць" },
            { 7, "сем" },
            { 8, "восем" },
            { 9, "дзевяць" }
        };

        private readonly Dictionary<string, Dictionary<int, string>> ONES = new Dictionary<string, Dictionary<int, string>>
        {
            {
                "f", new Dictionary<int, string>
                {
                    { 1, "адна" },
                    { 2, "дзве" },
                    { 3, "тры" },
                    { 4, "чатыры" },
                    { 5, "пяць" },
                    { 6, "шэсць" },
                    { 7, "сем" },
                    { 8, "восем" },
                    { 9, "дзевяць" }
                }
            },
            {
                "m", new Dictionary<int, string>
                {
                    { 1, "адзін" },
                    { 2, "два" },
                    { 3, "тры" },
                    { 4, "чатыры" },
                    { 5, "пяць" },
                    { 6, "шэсць" },
                    { 7, "сем" },
                    { 8, "восем" },
                    { 9, "дзевяць" }
                }
            },
            {
                "n", new Dictionary<int, string>
                {
                    { 1, "адно" },
                    { 2, "два" },
                    { 3, "тры" },
                    { 4, "чатыры" },
                    { 5, "пяць" },
                    { 6, "шэсць" },
                    { 7, "сем" },
                    { 8, "восем" },
                    { 9, "дзевяць" }
                }
            }
        };

        private readonly Dictionary<int, string> TENS = new Dictionary<int, string>
        {
            { 0, "дзесяць" },
            { 1, "адзінаццаць" },
            { 2, "дванаццаць" },
            { 3, "трынаццаць" },
            { 4, "чатырнаццаць" },
            { 5, "пятнаццаць" },
            { 6, "шаснаццаць" },
            { 7, "сямнаццаць" },
            { 8, "васямнаццаць" },
            { 9, "дзевятнаццаць" }
        };

        private readonly Dictionary<int, string> TWENTIES = new Dictionary<int, string>
        {
            { 2, "дваццаць" },
            { 3, "трыццаць" },
            { 4, "сорак" },
            { 5, "пяцьдзясят" },
            { 6, "шэсцьдзясят" },
            { 7, "семдзесят" },
            { 8, "восемдзесят" },
            { 9, "дзевяноста" }
        };

        private readonly Tuple<string, string>[] TWENTIES_ORD =
        {
            Tuple.Create("дваццаць", "дваццаці"),
            Tuple.Create("трыццаць", "трыццаці"),
            Tuple.Create("сорак", "сарака"),
            Tuple.Create("пяцьдзясят", "пяцідзясяці"),
            Tuple.Create("шэсцьдзясят", "шaсцідзясяці"),
            Tuple.Create("семдзесят", "сямідзесяці"),
            Tuple.Create("восемдзесят", "васьмідзесяці"),
            Tuple.Create("дзевяноста", "дзевяноста")
        };

        private readonly Dictionary<int, string> HUNDREDS = new Dictionary<int, string>
        {
            { 1, "сто" },
            { 2, "дзвесце" },
            { 3, "трыста" },
            { 4, "чатырыста" },
            { 5, "пяцьсот" },
            { 6, "шэсцьсот" },
            { 7, "семсот" },
            { 8, "восемсот" },
            { 9, "дзевяцьсот" }
        };

        private readonly Dictionary<int, Tuple<string, string, string>> THOUSANDS = new Dictionary<int, Tuple<string, string, string>>
        {
            { 1, Tuple.Create("тысяча", "тысячы", "тысяч") },
            { 2, Tuple.Create("мільён", "мільёны", "мільёнаў") },
            { 3, Tuple.Create("мільярд", "мільярды", "мільярдаў") },
            { 4, Tuple.Create("трыльён", "трыльёны", "трыльёнаў") },
            { 5, Tuple.Create("квадрыльён", "квадрыльёны", "квадрыльёнаў") },
            { 6, Tuple.Create("квінтыльён", "квінтыльёны", "квінтыльёнаў") },
            { 7, Tuple.Create("секстыльён", "секстыльёны", "секстыльёнаў") },
            { 8, Tuple.Create("сэптыльён", "сэптыльёны", "сэптыльёнаў") },
            { 9, Tuple.Create("актыльён", "актыльёны", "актыльёнаў") },
            { 10, Tuple.Create("нанільён", "нанільёны", "нанільёнаў") }
        };

        public readonly Dictionary<string, Tuple<Tuple<string, string, string>, Tuple<string, string, string>>> CURRENCY_FORMS = new Dictionary<string, Tuple<Tuple<string, string, string>, Tuple<string, string, string>>>
        {
            {
                "RUB",
                Tuple.Create(
                    Tuple.Create("расійскі рубель", "расійскія рублі", "расійскіх рублёў"),
                    Tuple.Create("капейка", "капейкі", "капеек")
                )
            },
            {
                "EUR",
                Tuple.Create(
                    Tuple.Create("еўра", "еўра", "еўра"),
                    Tuple.Create("цэнт", "цэнты", "цэнтаў")
                )
            },
            {
                "USD",
                Tuple.Create(
                    Tuple.Create("долар", "долары", "долараў"),
                    Tuple.Create("цэнт", "цэнты", "цэнтаў")
                )
            },
            {
                "UAH",
                Tuple.Create(
                    Tuple.Create("грыўна", "грыўны", "грыўнаў"),
                    Tuple.Create("капейка", "капейкі", "капеек")
                )
            },
            {
                "KZT",
                Tuple.Create(
                    Tuple.Create("тэнге", "тэнге", "тэнге"),
                    Tuple.Create("тыйін", "тыйіны", "тыйінаў")
                )
            },
            {
                "BYN",
                Tuple.Create(
                    Tuple.Create("беларускі рубель", "беларускія рублі", "беларускіх рублёў"),
                    Tuple.Create("капейка", "капейкі", "капеек")
                )
            },
            {
                "UZS",
                Tuple.Create(
                    Tuple.Create("сум", "сумы", "сумаў"),
                    Tuple.Create("тыйін", "тыйіны", "тыйінаў")
                )
            },
            {
                "PLN",
                Tuple.Create(
                    Tuple.Create("злоты", "злотых", "злотых"),
                    Tuple.Create("грош", "грошы", "грошаў")
                )
            }
        };

        public string negword;
        public string pointword;
        public Dictionary<string, string> ords;
        public Dictionary<string, string> ords_adjective;

        public override void Setup()
        {
            negword = "мінус";
            pointword = "коска";
            ords = new Dictionary<string, string>
            {
                { "нуль", "нулявы" },
                { "адзін", "першы" },
                { "два", "другі" },
                { "тры", "трэці" },
                { "чатыры", "чацвёрты" },
                { "пяць", "пяты" },
                { "шэсць", "шосты" },
                { "сем", "сёмы" },
                { "восем", "восьмы" },
                { "дзевяць", "дзявяты" },
                { "сто", "соты" },
                { "тысяча", "тысячны" }
            };

            ords_adjective = new Dictionary<string, string>
            {
                { "адзін", "адна" },
                { "адна", "адна" },
                { "дзве", "двух" },
                { "тры", "трох" },
                { "чатыры", "чатырох" },
                { "пяць", "пяці" },
                { "шэсць", "шасці" },
                { "сем", "сямі" },
                { "восем", "васьмі" },
                { "дзевяць", "дзевяцi" },
                { "сто", "ста" }
            };
        }

        public string ToCardinal(decimal number, string gender = "m")
        {
            string n = number.ToString().Replace(",", ".");
            if (n.Contains("."))
            {
                string[] parts = n.Split('.');
                string left = parts[0];
                string right = parts[1];

                int leadingZeroCount = 0;
                if (right.All(c => c == '0'))
                {
                    leadingZeroCount = 0;
                }
                else
                {
                    leadingZeroCount = right.Length - right.TrimStart('0').Length;
                }

                string decimalPart = String.Concat(Enumerable.Repeat(ZERO + " ", leadingZeroCount)) + _Int2Word(int.Parse(right), gender);
                return $"{_Int2Word(int.Parse(left), gender)} {pointword} {decimalPart}";
            }
            else
            {
                return _Int2Word(int.Parse(n), gender);
            }
        }

        public string Pluralize(int n, Tuple<string, string, string> forms)
        {
            if (n % 100 < 10 || n % 100 > 20)
            {
                if (n % 10 == 1)
                {
                    return forms.Item1;
                }
                else if (n % 10 > 1 && n % 10 < 5)
                {
                    return forms.Item2;
                }
                else
                {
                    return forms.Item3;
                }
            }
            else
            {
                return forms.Item3;
            }
        }

        public string ToOrdinal(decimal number, string gender = "m")//gender["m","f"]
        {
            if ((int)number != number)
            {
                throw new ArgumentException("Number must be an integer for ordinal conversion.");
            }
            //if (gender is bool boolGender && boolGender)
            //{
            //    gender = "f";
            //}
            string[] outwords = ToCardinal(number, gender).Split(' ');
            string lastword = outwords.Last().ToLower();
            try
            {
                if (outwords.Length > 1)
                {
                    if (ords_adjective.ContainsKey(outwords[outwords.Length - 2]))
                    {
                        outwords[outwords.Length - 2] = ords_adjective[outwords[outwords.Length - 2]];
                    }
                    else if (outwords[outwords.Length - 2] == "дзесяць")
                    {
                        outwords[outwords.Length - 2] = outwords[outwords.Length - 2].Substring(0, outwords[outwords.Length - 2].Length - 1) + "і";
                    }
                }
                if (outwords.Length == 3)
                {
                    if (outwords[outwords.Length - 3] == "адзін" || outwords[outwords.Length - 3] == "адна")
                    {
                        outwords[outwords.Length - 3] = "";
                    }
                }
                lastword = ords[lastword];
            }
            catch (KeyNotFoundException)
            {
                if (ords_adjective.ContainsKey(lastword.Substring(0, lastword.Length - 3)))
                {
                    lastword = ords_adjective[lastword.Substring(0, lastword.Length - 3)] + "соты";
                }
                else if (lastword.EndsWith("дзесяць"))
                {
                    lastword = "дзясяты";
                }
                else if (lastword.EndsWith("семдзесят"))
                {
                    lastword = "сямідзясяты";
                }
                else if (lastword.EndsWith("ь") || lastword.EndsWith("ц"))
                {
                    lastword = lastword.Substring(0, lastword.Length - 2) + "ты";
                }
                else if (lastword.EndsWith("к"))
                {
                    lastword = lastword.Replace("о", "а") + "авы";
                }
                else if (lastword.EndsWith("ч") || lastword.EndsWith("ч"))
                {
                    if (lastword.EndsWith("ч", StringComparison.Ordinal))
                    {
                        lastword = lastword.Substring(0, lastword.Length - 1) + "ны";
                    }
                    if (lastword.EndsWith("ч", StringComparison.Ordinal))
                    {
                        lastword = lastword + "ны";
                    }
                }
                else if (lastword.EndsWith("н") || lastword.EndsWith("н"))
                {
                    lastword = lastword.Substring(0, lastword.LastIndexOf("н") + 1) + "ны";
                }
                else if (lastword.EndsWith("наў"))
                {
                    lastword = lastword.Substring(0, lastword.LastIndexOf("н") + 1) + "ны";
                }
                else if (lastword.EndsWith("д") || lastword.EndsWith("д"))
                {
                    lastword = lastword.Substring(0, lastword.LastIndexOf("д") + 1) + "ны";
                }
            }

            if (gender == "f")
            {
                if (lastword.EndsWith("ці"))
                {
                    lastword = lastword.Substring(0, lastword.Length - 2) + "цяя";
                }
                else
                {
                    lastword = lastword.Substring(0, lastword.Length - 1) + "ая";
                }
            }

            if (gender == "n")
            {
                if (lastword.EndsWith("ці") || lastword.EndsWith("ца"))
                {
                    lastword = lastword.Substring(0, lastword.Length - 2) + "цяе";
                }
                else
                {
                    lastword = lastword.Substring(0, lastword.Length - 1) + "ае";
                }
            }

            outwords[outwords.Length - 1] = Title(lastword);
            if (outwords.Length == 2 && outwords[outwords.Length - 2] == "адна")
            {
                outwords[outwords.Length - 2] = outwords[outwords.Length - 1];
                outwords = outwords.Take(outwords.Length - 1).ToArray();
            }

            if (outwords.Length > 1 && (THOUSANDS.Values.Any(x => x.Item1.Contains(outwords[outwords.Length - 1]) || x.Item2.Contains(outwords[outwords.Length - 1]) || x.Item3.Contains(outwords[outwords.Length - 1])) || outwords[outwords.Length - 1].Contains("тысяч")))
            {
                List<string> newOutwords = new List<string>();
                foreach (string w in outwords)
                {
                    Tuple<string, string> replacement = TWENTIES_ORD.FirstOrDefault(x => w.Contains(x.Item1));
                    if (replacement != null)
                    {
                        newOutwords.Add(w.Replace(replacement.Item1, replacement.Item2));
                    }
                    else
                    {
                        newOutwords.Add(w);
                    }
                }
                outwords = new[] { string.Join("", newOutwords) };
            }

            return string.Join(" ", outwords).Trim();
        }

        private string _MoneyVerbose(int number, string currency)
        {
            string gender = "m";
            if (currency == "UAH")
            {
                gender = "f";
            }
            return _Int2Word(number, gender);
        }

        private string _CentsVerbose(int number, string currency)
        {
            string gender;
            if (new[] { "UAH", "RUB", "BYN" }.Contains(currency))
            {
                gender = "f";
            }
            else
            {
                gender = "m";
            }
            return _Int2Word(number, gender);
        }

        private string _Int2Word(int n, string gender = "m")
        {
            if (n < 0)
            {
                return $"{negword} {_Int2Word(Math.Abs(n), gender)}";
            }

            if (n == 0)
            {
                return ZERO;
            }

            List<string> words = new List<string>();
            string numStr = n.ToString();
            List<string> chunks = SplitByX(numStr, 3).ToList();
            int i = chunks.Count;
            foreach (string x in chunks)
            {
                i--;
                if (int.Parse(x) == 0)
                {
                    continue;
                }

                int[] digits = GetDigits(int.Parse(x));
                int n1 = digits[0];
                int n2 = digits[1];
                int n3 = digits[2];

                if (n3 > 0)
                {
                    words.Add(HUNDREDS[n3]);
                }

                if (n2 > 1)
                {
                    words.Add(TWENTIES[n2]);
                }

                if (n2 == 1)
                {
                    words.Add(TENS[n1]);
                }
                else if (n1 > 0)
                {
                    Dictionary<int, string> ones;
                    if (i == 0)
                    {
                        ones = ONES[gender];
                    }
                    else if (i == 1)
                    {
                        ones = ONES["f"];
                    }
                    else
                    {
                        ones = ONES["m"];
                    }
                    words.Add(ones[n1]);
                }

                if (i > 0)
                {
                    words.Add(Pluralize(int.Parse(x), THOUSANDS[i]));
                }
            }

            return string.Join(" ", words);
        }

        private static IEnumerable<string> SplitByX(string input, int x)
        {
            int length = input.Length;
            for (int i = length; i > 0; i -= x)
            {
                if (i - x < 0)
                {
                    yield return input.Substring(0, i);
                }
                else
                {
                    yield return input.Substring(i - x, x);
                }
            }
        }

        private static int[] GetDigits(int number)
        {
            string numStr = number.ToString().PadLeft(3, '0');
            return new[]
            {
                int.Parse(numStr[2].ToString()),
                int.Parse(numStr[1].ToString()),
                int.Parse(numStr[0].ToString())
            };
        }

        private string Title(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }
            return char.ToUpper(input[0]) + input.Substring(1);
        }
    }
}