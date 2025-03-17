using Num2WordsNet;

namespace Num2WordsNet
{
    public class Num2Words
    {
        // 存储不同语言的转换器实例
        private static readonly Dictionary<string, Num2Word_Base> CONVERTER_CLASSES = new Dictionary<string, Num2Word_Base>
        {
            { "am", new Lang_AM() },
            { "ar", new Lang_AR() },
            { "az", new Lang_AZ() },
            { "be", new Lang_BE() },
            { "bn", new Lang_BN() },
            //{ "ca", new Lang_CA() },
            //{ "ce", new Lang_CE() },
            //{ "cs", new Lang_CS() },
            //{ "cy", new Lang_CY() },
            { "en", new Lang_EN() },
            //{ "en_IN", new Lang_EN_IN() },
            //{ "en_NG", new Lang_EN_NG() },
            //{ "fa", new Lang_FA() },
            //{ "fr", new Lang_FR() },
            //{ "fr_CH", new Lang_FR_CH() },
            //{ "fr_BE", new Lang_FR_BE() },
            //{ "fr_DZ", new Lang_FR_DZ() },
            //{ "de", new Lang_DE() },
            //{ "fi", new Lang_FI() },
            //{ "eo", new Lang_EO() },
            //{ "es", new Lang_ES() },
            //{ "es_CO", new Lang_ES_CO() },
            //{ "es_CR", new Lang_ES_CR() },
            //{ "es_GT", new Lang_ES_GT() },
            //{ "es_NI", new Lang_ES_NI() },
            //{ "es_VE", new Lang_ES_VE() },
            //{ "id", new Lang_ID() },
            //{ "ja", new Lang_JA() },
            //{ "kn", new Lang_KN() },
            //{ "ko", new Lang_KO() },
            //{ "kz", new Lang_KZ() },
            //{ "lt", new Lang_LT() },
            //{ "lv", new Lang_LV() },
            //{ "pl", new Lang_PL() },
            //{ "ro", new Lang_RO() },
            //{ "ru", new Lang_RU() },
            //{ "sk", new Lang_SK() },
            //{ "sl", new Lang_SL() },
            //{ "sr", new Lang_SR() },
            //{ "sv", new Lang_SV() },
            //{ "no", new Lang_NO() },
            //{ "da", new Lang_DA() },
            //{ "pt", new Lang_PT() },
            //{ "pt_BR", new Lang_PT_BR() },
            //{ "he", new Lang_HE() },
            //{ "it", new Lang_IT() },
            //{ "vi", new Lang_VI() },
            //{ "tg", new Lang_TG() },
            //{ "th", new Lang_TH() },
            //{ "tr", new Lang_TR() },
            //{ "nl", new Lang_NL() },
            //{ "uk", new Lang_UK() },
            //{ "te", new Lang_TE() },
            //{ "tet", new Lang_TET() },
            //{ "hu", new Lang_HU() },
            //{ "is", new Lang_IS() },
            //{ "hi", new Lang_HI() }
        };

        // 支持的转换类型
        private static readonly List<string> CONVERTES_TYPES = new List<string>
        {
            "cardinal", "ordinal", "ordinal_num", "year", "currency"
        };

        public static string Process(object number, bool ordinal = false, string lang = "en", string to = "cardinal", Dictionary<string, object> kwargs = null)
        {
            // 先尝试完整的语言代码
            if (!CONVERTER_CLASSES.ContainsKey(lang))
            {
                // 再尝试前两个字符
                lang = lang.Substring(0, Math.Min(2, lang.Length));
            }
            if (!CONVERTER_CLASSES.ContainsKey(lang))
            {
                throw new NotImplementedException($"Language {lang} is not implemented.");
            }
            var converter = CONVERTER_CLASSES[lang];

            if (number is string numStr)
            {
                number = converter.StrToNumber(numStr);
            }

            // 向后兼容
            if (ordinal)
            {
                to = "ordinal";
            }

            if (!CONVERTES_TYPES.Contains(to))
            {
                throw new NotImplementedException($"Conversion type {to} is not implemented.");
            }

            var methodName = $"To{char.ToUpper(to[0]) + to.Substring(1)}";
            var method = converter.GetType().GetMethod(methodName);
            if (method == null)
            {
                throw new NotImplementedException($"Method {methodName} is not implemented in the converter.");
            }

            var parameters = new List<object> { Convert.ToDecimal(number) };
            if (method.GetParameters().Length == 3)
            {
                parameters.Add(true);
                parameters.Add(null);
            }
            if (kwargs != null)
            {
                foreach (var param in kwargs)
                {
                    var paramInfo = method.GetParameters().FirstOrDefault(p => p.Name == param.Key);
                    if (paramInfo != null)
                    {
                        parameters.Add(param.Value);
                    }
                }
            }

            return (string)method.Invoke(converter, parameters.ToArray());
        }
    }
}