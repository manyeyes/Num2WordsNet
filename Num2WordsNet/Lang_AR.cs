using Num2WordsNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Num2WordsNet
{
    public class Lang_AR : Num2Word_Base
    {
        public string errmsg_toobig = "abs({0}) must be less than {1}.";
        public BigInteger MAXVAL = (BigInteger)Math.Pow(10, 51);

        public decimal number;
        public string arabicPrefixText;
        public string arabicSuffixText;
        public int integer_value;
        public string _decimalValue;
        public int partPrecision = 2;
        public string[] currency_unit;
        public string[] currency_subunit;
        public bool isCurrencyPartNameFeminine = true;
        public bool isCurrencyNameFeminine = false;
        public string separator = "و";

        public string[] arabicOnes = {
            "", "واحد", "اثنان", "ثلاثة", "أربعة", "خمسة", "ستة", "سبعة", "ثمانية",
            "تسعة",
            "عشرة", "أحد عشر", "اثنا عشر", "ثلاثة عشر", "أربعة عشر", "خمسة عشر",
            "ستة عشر", "سبعة عشر", "ثمانية عشر",
            "تسعة عشر"
        };

        public string[] arabicFeminineOnes = {
            "", "إحدى", "اثنتان", "ثلاث", "أربع", "خمس", "ست", "سبع", "ثمان",
            "تسع",
            "عشر", "إحدى عشرة", "اثنتا عشرة", "ثلاث عشرة", "أربع عشرة",
            "خمس عشرة", "ست عشرة", "سبع عشرة", "ثماني عشرة",
            "تسع عشرة"
        };

        public string[] arabicOrdinal = {
            "", "اول", "ثاني", "ثالث", "رابع", "خامس", "سادس", "سابع", "ثامن",
            "تاسع", "عاشر", "حادي عشر", "ثاني عشر", "ثالث عشر", "رابع عشر",
            "خامس عشر", "سادس عشر", "سابع عشر", "ثامن عشر", "تاسع عشر"
        };

        public string[] arabicTens = {
            "عشرون", "ثلاثون", "أربعون", "خمسون", "ستون", "سبعون", "ثمانون",
            "تسعون"
        };

        public string[] arabicHundreds = {
            "", "مائة", "مئتان", "ثلاثمائة", "أربعمائة", "خمسمائة", "ستمائة",
            "سبعمائة", "ثمانمائة", "تسعمائة"
        };

        public string[] arabicAppendedTwos = {
            "مئتا", "ألفا", "مليونا", "مليارا", "تريليونا", "كوادريليونا",
            "كوينتليونا", "سكستيليونا", "سبتيليونا", "أوكتيليونا ",
            "نونيليونا", "ديسيليونا", "أندسيليونا", "دوديسيليونا",
            "تريديسيليونا", "كوادريسيليونا", "كوينتينيليونا"
        };

        public string[] arabicTwos = {
            "مئتان", "ألفان", "مليونان", "ملياران", "تريليونان",
            "كوادريليونان", "كوينتليونان", "سكستيليونان", "سبتيليونان",
            "أوكتيليونان ", "نونيليونان ", "ديسيليونان", "أندسيليونان",
            "دوديسيليونان", "تريديسيليونان", "كوادريسيليونان", "كوينتينيليونان"
        };

        public string[] arabicGroup = {
            "مائة", "ألف", "مليون", "مليار", "تريليون", "كوادريليون",
            "كوينتليون", "سكستيليون", "سبتيليون", "أوكتيليون", "نونيليون",
            "ديسيليون", "أندسيليون", "دوديسيليون", "تريديسيليون",
            "كوادريسيليون", "كوينتينيليون"
        };

        public string[] arabicAppendedGroup = {
            "", "ألفاً", "مليوناً", "ملياراً", "تريليوناً", "كوادريليوناً",
            "كوينتليوناً", "سكستيليوناً", "سبتيليوناً", "أوكتيليوناً",
            "نونيليوناً", "ديسيليوناً", "أندسيليوناً", "دوديسيليوناً",
            "تريديسيليوناً", "كوادريسيليوناً", "كوينتينيليوناً"
        };

        public string[] arabicPluralGroups = {
            "", "آلاف", "ملايين", "مليارات", "تريليونات", "كوادريليونات",
            "كوينتليونات", "سكستيليونات", "سبتيليونات", "أوكتيليونات",
            "نونيليونات", "ديسيليونات", "أندسيليونات", "دوديسيليونات",
            "تريديسيليونات", "كوادريسيليونات", "كوينتينيليونات"
        };

        public Lang_AR()
        {
            currency_unit = new string[] { "ريال", "ريالان", "ريالات", "ريالاً" };
            currency_subunit = new string[] { "هللة", "هللتان", "هللات", "هللة" };
        }

        public void NumberToArabic(string arabic_prefix_text, string arabic_suffix_text)
        {
            arabicPrefixText = arabic_prefix_text;
            arabicSuffixText = arabic_suffix_text;
            ExtractIntegerAndDecimalParts();
        }

        public void ExtractIntegerAndDecimalParts()
        {
            string[] splits = Regex.Split(number.ToString(), "\\.");

            integer_value = int.Parse(splits[0]);
            if (splits.Length > 1)
            {
                _decimalValue = DecimalValue(splits[1]).ToString();
            }
            else
            {
                _decimalValue = "0";
            }
        }

        public int DecimalValue(string decimal_part)
        {
            if (partPrecision != decimal_part.Length)
            {
                int decimal_part_length = decimal_part.Length;
                string decimal_part_builder = decimal_part;
                for (int i = 0; i < partPrecision - decimal_part_length; i++)
                {
                    decimal_part_builder += '0';
                }
                decimal_part = decimal_part_builder;

                int dec = decimal_part.Length <= partPrecision ? decimal_part.Length : partPrecision;
                string result = decimal_part.Substring(0, dec);
                return int.Parse(result);
            }
            return int.Parse(decimal_part);
        }

        public string digit_feminine_status(int digit, int group_level)
        {
            if (group_level == -1)
            {
                if (isCurrencyPartNameFeminine)
                {
                    return arabicFeminineOnes[digit];
                }
                else
                {
                    return arabicOnes[digit];
                }
            }
            else if (group_level == 0)
            {
                if (isCurrencyNameFeminine)
                {
                    return arabicFeminineOnes[digit];
                }
                else
                {
                    return arabicOnes[digit];
                }
            }
            else
            {
                return arabicOnes[digit];
            }
        }

        public string ProcessArabicGroup(int group_number, int group_level, decimal remaining_number)
        {
            int tens = (int)(group_number % 100);
            int hundreds = (int)(group_number / 100);
            string ret_val = "";

            if (hundreds > 0)
            {
                if (tens == 0 && hundreds == 2)
                {
                    ret_val = $"{arabicAppendedTwos[0]}";
                }
                else
                {
                    ret_val = $"{arabicHundreds[hundreds]}";
                    if (ret_val != "" && tens != 0)
                    {
                        ret_val += " و ";
                    }
                }
            }

            if (tens > 0)
            {
                if (tens < 20)
                {
                    if (tens == 2 && hundreds == 0 && group_level > 0)
                    {
                        int pow = (int)Math.Floor(Math.Log10(integer_value));
                        if (integer_value > 10 && pow % 3 == 0 && integer_value == 2 * (int)Math.Pow(10, pow))
                        {
                            ret_val = $"{arabicAppendedTwos[group_level]}";
                        }
                        else
                        {
                            ret_val = $"{arabicTwos[group_level]}";
                        }
                    }
                    else
                    {
                        if (tens == 1 && group_level > 0 && hundreds == 0)
                        {
                            ret_val += "";
                        }
                        else if ((tens == 1 || tens == 2) && (group_level == 0 || group_level == -1) && hundreds == 0 && remaining_number == 0)
                        {
                            ret_val += "";
                        }
                        else if (tens == 1 && group_level > 0)
                        {
                            ret_val += arabicGroup[group_level];
                        }
                        else
                        {
                            ret_val += digit_feminine_status(tens, group_level);
                        }
                    }
                }
                else
                {
                    int ones = tens % 10;
                    int tensIndex = (tens / 10) - 2;
                    if (ones > 0)
                    {
                        ret_val += digit_feminine_status(ones, group_level);
                    }
                    if (ret_val != "" && ones != 0)
                    {
                        ret_val += " و ";
                    }

                    ret_val += arabicTens[tensIndex];
                }
            }

            return ret_val;
        }

        public decimal Abs(decimal number)
        {
            return number >= 0 ? number : -number;
        }

        public string ToStr(decimal number)
        {
            int integer = (int)number;
            if (integer == number)
            {
                return integer.ToString();
            }
            decimal dec = (number - integer) * (decimal)Math.Pow(10, 9);
            return integer.ToString() + "." + ((int)dec).ToString("D9").TrimEnd('0');
        }

        public string convert(decimal value)
        {
            number = decimal.Parse(ToStr(value));
            NumberToArabic(arabicPrefixText, arabicSuffixText);
            return convert_to_arabic();
        }

        public string convert_to_arabic()
        {
            decimal temp_number = number;

            if (temp_number == 0)
            {
                return "صفر";
            }

            string decimal_string = ProcessArabicGroup(int.Parse(_decimalValue), -1, 0);
            string ret_val = "";
            int group = 0;

            while (temp_number > 0)
            {
                int number_to_process = (int)(temp_number % 1000);
                temp_number = (int)(temp_number / 1000);

                string group_description = ProcessArabicGroup(number_to_process, group, (decimal)Math.Floor(temp_number));
                if (group_description != "")
                {
                    if (group > 0)
                    {
                        if (ret_val != "")
                        {
                            ret_val = $" {ret_val}";
                        }
                        if (number_to_process != 2 && number_to_process != 1)
                        {
                            if (number_to_process % 100 != 1)
                            {
                                if (3 <= number_to_process && number_to_process <= 10)
                                {
                                    ret_val = $"{arabicPluralGroups[group]} {ret_val}";
                                }
                                else
                                {
                                    if (ret_val != "")
                                    {
                                        ret_val = $"{arabicAppendedGroup[group]} {ret_val}";
                                    }
                                    else
                                    {
                                        ret_val = $"{arabicGroup[group]} {ret_val}";
                                    }
                                }
                            }
                            else
                            {
                                ret_val = $"{arabicGroup[group]} {ret_val}";
                            }
                        }
                    }
                    ret_val = $"{group_description} {ret_val}";
                }
                group++;
            }

            string formatted_number = "";
            if (arabicPrefixText != "")
            {
                formatted_number += $"{arabicPrefixText} ";
            }
            formatted_number += ret_val;

            if (integer_value != 0)
            {
                int remaining100 = integer_value % 100;

                if (remaining100 == 0)
                {
                    formatted_number += currency_unit[0];
                }
                else if (remaining100 == 1)
                {
                    formatted_number += currency_unit[0];
                }
                else if (remaining100 == 2)
                {
                    if (integer_value == 2)
                    {
                        formatted_number += currency_unit[1];
                    }
                    else
                    {
                        formatted_number += currency_unit[0];
                    }
                }
                else if (3 <= remaining100 && remaining100 <= 10)
                {
                    formatted_number += currency_unit[2];
                }
                else if (11 <= remaining100 && remaining100 <= 99)
                {
                    formatted_number += currency_unit[3];
                }
            }

            if (_decimalValue != "0")
            {
                formatted_number += $" {separator} ";
                formatted_number += decimal_string;
            }

            if (_decimalValue != "0")
            {
                formatted_number += " ";
                int remaining100 = int.Parse(_decimalValue) % 100;

                if (remaining100 == 0)
                {
                    formatted_number += currency_subunit[0];
                }
                else if (remaining100 == 1)
                {
                    formatted_number += currency_subunit[0];
                }
                else if (remaining100 == 2)
                {
                    formatted_number += currency_subunit[1];
                }
                else if (3 <= remaining100 && remaining100 <= 10)
                {
                    formatted_number += currency_subunit[2];
                }
                else if (11 <= remaining100 && remaining100 <= 99)
                {
                    formatted_number += currency_subunit[3];
                }
            }

            if (arabicSuffixText != "")
            {
                formatted_number += $" {arabicSuffixText}";
            }

            return formatted_number;
        }

        public decimal validate_number(decimal number)
        {
            if (BigInteger.Parse(number.ToString()) >= MAXVAL)
            {
                throw new OverflowException(string.Format(errmsg_toobig, number, MAXVAL));
            }
            return number;
        }

        public void set_currency_prefer(string currency)
        {
            switch (currency)
            {
                case "TND":
                    currency_unit = new string[] { "دينار", "ديناران", "دينارات", "ديناراً" };
                    currency_subunit = new string[] { "مليماً", "ميلمان", "مليمات", "مليم" };
                    partPrecision = 3;
                    break;
                case "EGP":
                    currency_unit = new string[] { "جنيه", "جنيهان", "جنيهات", "جنيهاً" };
                    currency_subunit = new string[] { "قرش", "قرشان", "قروش", "قرش" };
                    partPrecision = 2;
                    break;
                case "KWD":
                    currency_unit = new string[] { "دينار", "ديناران", "دينارات", "ديناراً" };
                    currency_subunit = new string[] { "فلس", "فلسان", "فلس", "فلس" };
                    partPrecision = 2;
                    break;
                default:
                    currency_unit = new string[] { "ريال", "ريالان", "ريالات", "ريالاً" };
                    currency_subunit = new string[] { "هللة", "هللتان", "هللات", "هللة" };
                    partPrecision = 2;
                    break;
            }
        }

        public string ToCurrency(decimal value, string currency = "SR", string prefix = "", string suffix = "")
        {
            set_currency_prefer(currency);
            isCurrencyNameFeminine = false;
            separator = "و";
            arabicPrefixText = prefix;
            arabicSuffixText = suffix;
            return convert(value: value);
        }

        public string ToOrdinal(decimal number, string prefix = "")
        {
            if (number <= 19)
            {
                return $"{arabicOrdinal[(int)number]}";
            }
            if (number < 100)
            {
                isCurrencyNameFeminine = true;
            }
            else
            {
                isCurrencyNameFeminine = false;
            }
            currency_subunit = new string[] { "", "", "", "" };
            currency_unit = new string[] { "", "", "", "" };
            arabicPrefixText = prefix;
            arabicSuffixText = "";
            return $"{convert(Abs(number)).Trim()}";
        }

        public string ToYear(decimal value)
        {
            value = validate_number(value);
            return ToCardinal(value);
        }

        public string ToOrdinalNum(decimal value)
        {
            return ToOrdinal(value).Trim();
        }

        public string ToCardinal(decimal number)
        {
            isCurrencyNameFeminine = false;
            number = validate_number(number);
            string minus = "";
            if (number < 0)
            {
                minus = "سالب ";
            }
            separator = ",";
            currency_subunit = new string[] { "", "", "", "" };
            currency_unit = new string[] { "", "", "", "" };
            arabicPrefixText = "";
            arabicSuffixText = "";
            return minus + convert(value: Abs(number)).Trim();
        }
    }
}