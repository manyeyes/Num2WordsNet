using Num2WordsNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Num2WordsNet
{
    public class Lang_AZ : Num2Word_Base
    {
        public Dictionary<int, string> DIGITS = new Dictionary<int, string>
        {
            { 0, "sıfır" },
            { 1, "bir" },
            { 2, "iki" },
            { 3, "üç" },
            { 4, "dörd" },
            { 5, "beş" },
            { 6, "altı" },
            { 7, "yeddi" },
            { 8, "səkkiz" },
            { 9, "doqquz" }
        };

        public Dictionary<int, string> DECIMALS = new Dictionary<int, string>
        {
            { 1, "on" },
            { 2, "iyirmi" },
            { 3, "otuz" },
            { 4, "qırx" },
            { 5, "əlli" },
            { 6, "altmış" },
            { 7, "yetmiş" },
            { 8, "səksən" },
            { 9, "doxsan" }
        };

        public Dictionary<int, string> POWERS_OF_TEN = new Dictionary<int, string>
        {
            { 2, "yüz" },
            { 3, "min" },
            { 6, "milyon" },
            { 9, "milyard" },
            { 12, "trilyon" },
            { 15, "katrilyon" },
            { 18, "kentilyon" },
            { 21, "sekstilyon" },
            { 24, "septilyon" },
            { 27, "oktilyon" },
            { 30, "nonilyon" },
            { 33, "desilyon" },
            { 36, "undesilyon" },
            { 39, "dodesilyon" },
            { 42, "tredesilyon" },
            { 45, "katordesilyon" },
            { 48, "kendesilyon" },
            { 51, "seksdesilyon" },
            { 54, "septendesilyon" },
            { 57, "oktodesilyon" },
            { 60, "novemdesilyon" },
            { 63, "vigintilyon" }
        };

        public string VOWELS = "aıoueəiöü";
        public Dictionary<char, string> VOWEL_TO_CARDINAL_SUFFIX_MAP = new Dictionary<char, string>
        {
            { 'a', "ıncı" },
            { 'ı', "ıncı" },
            { 'e', "inci" },
            { 'ə', "inci" },
            { 'i', "inci" },
            { 'o', "uncu" },
            { 'u', "uncu" },
            { 'ö', "üncü" },
            { 'ü', "üncü" }
        };

        public Dictionary<char, string> VOWEL_TO_CARDINAL_NUM_SUFFIX_MAP = new Dictionary<char, string>
        {
            { 'a', "cı" },
            { 'ı', "cı" },
            { 'e', "ci" },
            { 'ə', "ci" },
            { 'i', "ci" },
            { 'o', "cu" },
            { 'u', "cu" },
            { 'ö', "cü" },
            { 'ü', "cü" }
        };

        public string[] CURRENCY_INTEGRAL = { "manat", "manat" };
        public string[] CURRENCY_FRACTION = { "qəpik", "qəpik" };
        public Dictionary<string, Tuple<string[], string[]>> CURRENCY_FORMS = new Dictionary<string, Tuple<string[], string[]>>();

        public string negword = "mənfi";
        public string pointword = "nöqtə";

        public override void Setup()
        {
            CURRENCY_FORMS = new Dictionary<string, Tuple<string[], string[]>>
            {
                { "AZN", Tuple.Create(CURRENCY_INTEGRAL, CURRENCY_FRACTION) }
            };
            base.Setup();
        }

        public string ToCardinal(decimal value)
        {
            string valueStr = value.ToString();
            string[] parts = valueStr.Split('.');
            string integralPart = parts[0];
            string fractionPart = parts.Length > 1 ? parts[1] : "";

            if (integralPart.StartsWith("-"))
            {
                integralPart = integralPart.Substring(1);
            }

            string integralPartInWords = IntToWord(integralPart);
            string fractionPartInWords = string.IsNullOrEmpty(fractionPart) ? "" : IntToWord(fractionPart, true);

            string valueInWords = integralPartInWords;
            if (!string.IsNullOrEmpty(fractionPart))
            {
                valueInWords = $"{integralPartInWords} {pointword} {fractionPartInWords}";
            }

            if (value < 0)
            {
                valueInWords = $"{negword} {valueInWords}";
            }

            return valueInWords;
        }

        public string ToOrdinal(decimal value)
        {
            if ((int)value != value)
            {
                throw new ArgumentException("Value must be an integer.");
            }

            string cardinal = ToCardinal(value);
            char? lastVowel = _LastVowel(cardinal);
            if (!lastVowel.HasValue)
            {
                throw new InvalidOperationException("No vowel found in the cardinal number.");
            }

            string suffix = VOWEL_TO_CARDINAL_SUFFIX_MAP[lastVowel.Value];

            if (VOWELS.Contains(cardinal[cardinal.Length - 1]))
            {
                cardinal = cardinal.Substring(0, cardinal.Length - 1);
            }

            string ordinal = $"{cardinal}{suffix}";
            return ordinal;
        }

        public string ToOrdinalNum(decimal value)
        {
            if ((int)value != value)
            {
                throw new ArgumentException("Value must be an integer.");
            }

            string cardinal = ToCardinal(value);
            char? lastVowel = _LastVowel(cardinal);
            if (!lastVowel.HasValue)
            {
                throw new InvalidOperationException("No vowel found in the cardinal number.");
            }

            string suffix = VOWEL_TO_CARDINAL_NUM_SUFFIX_MAP[lastVowel.Value];
            string ordinalNum = $"{value}-{suffix}";
            return ordinalNum;
        }

        public string ToYear(decimal value)
        {
            if ((int)value != value)
            {
                throw new ArgumentException("Value must be an integer.");
            }

            string year = ToCardinal(Math.Abs(value));
            if (value < 0)
            {
                year = $"e.ə. {year}";
            }

            return year;
        }

        public string Pluralize(int n, string[] forms)
        {
            int form = n == 1 ? 0 : 1;
            return forms[form];
        }

        public string IntToWord(string numStr, bool leadingZeros = false)
        {
            List<string> words = new List<string>();
            char[] reversedStr = numStr.Reverse().ToArray();

            for (int index = 0; index < reversedStr.Length; index++)
            {
                int digitInt = int.Parse(reversedStr[index].ToString());
                int remainderTo3 = index % 3;
                if (remainderTo3 == 0)
                {
                    if (index > 0)
                    {
                        if (reversedStr.Skip(index).Take(3).Any(c => c != '0'))
                        {
                            words.Insert(0, POWERS_OF_TEN[index]);
                        }
                    }
                    if (digitInt > 0)
                    {
                        if (!(digitInt == 1 && index == 3))
                        {
                            words.Insert(0, DIGITS[digitInt]);
                        }
                    }
                }
                else if (remainderTo3 == 1)
                {
                    if (digitInt != 0)
                    {
                        words.Insert(0, DECIMALS[digitInt]);
                    }
                }
                else
                {
                    if (digitInt > 0)
                    {
                        words.Insert(0, POWERS_OF_TEN[2]);
                    }
                    if (digitInt > 1)
                    {
                        words.Insert(0, DIGITS[digitInt]);
                    }
                }
            }

            if (numStr == "0")
            {
                words.Add(DIGITS[0]);
            }

            if (leadingZeros)
            {
                int zerosCount = numStr.Length - int.Parse(numStr).ToString().Length;
                for (int i = 0; i < zerosCount; i++)
                {
                    words.Insert(0, DIGITS[0]);
                }
            }

            return string.Join(" ", words);
        }

        private char? _LastVowel(string value)
        {
            for (int i = value.Length - 1; i >= 0; i--)
            {
                if (VOWELS.Contains(value[i]))
                {
                    return value[i];
                }
            }
            return null;
        }
    }
}