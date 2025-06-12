using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Num2WordsNet
{
    public class Lang_CA : Lang_EU
    {
        // 定义通用的美元和分的形式
        private static readonly string[] GENERIC_DOLLARS = new string[] { "dòlar", "dòlars" };
        private static readonly string[] GENERIC_CENTS = new string[] { "centau", "centaus" };
        public static readonly string[] CURRENCIES_UNA = new string[]
        {
            "SLL", "SEK", "NOK", "CZK", "DKK", "ISK", "SKK", "GBP", "CYP", "EGP",
            "FKP", "GIP", "LBP", "SDG", "SHP", "SSP", "SYP", "INR", "IDR", "LKR",
            "MUR", "NPR", "PKR", "SCR", "ESP", "TRY", "ITL"
        };

        public static readonly string[] CENTS_UNA = new string[]
        {
            "EGP", "JOD", "LBP", "SDG", "SSP", "SYP"
        };

        public static readonly Dictionary<string, Tuple<string[], string[]>> CURRENCY_FORMS =
        new Dictionary<string, Tuple<string[], string[]>>
        {
            { "EUR", Tuple.Create(new[] { "euro", "euros" }, new[] { "cèntim", "cèntims" }) },
            { "ESP", Tuple.Create(new[] { "pesseta", "pessetes" }, new[] { "cèntim", "cèntims" }) },
            { "USD", Tuple.Create(GENERIC_DOLLARS, new[] { "centau", "centaus" }) },
            { "PEN", Tuple.Create(new[] { "sol", "sols" }, new[] { "cèntim", "cèntims" }) },
            { "CRC", Tuple.Create(new[] { "colón", "colons" }, GENERIC_CENTS) },
            { "AUD", Tuple.Create(GENERIC_DOLLARS, GENERIC_CENTS) },
            { "CAD", Tuple.Create(GENERIC_DOLLARS, GENERIC_CENTS) },
            { "GBP", Tuple.Create(new[] { "lliura", "lliures" }, new[] { "penic", "penics" }) },
            { "RUB", Tuple.Create(new[] { "ruble", "rubles" }, new[] { "copec", "copecs" }) },
            { "SEK", Tuple.Create(new[] { "corona", "corones" }, new[] { "öre", "öre" }) },
            { "NOK", Tuple.Create(new[] { "corona", "corones" }, new[] { "øre", "øre" }) },
            { "PLN", Tuple.Create(new[] { "zloty", "zlotys" }, new[] { "grosz", "groszy" }) },
            { "MXN", Tuple.Create(new[] { "peso", "pesos" }, GENERIC_CENTS) },
            { "RON", Tuple.Create(new[] { "leu", "lei" }, new[] { "ban", "bani" }) },
            { "INR", Tuple.Create(new[] { "rupia", "rupies" }, new[] { "paisa", "paise" }) },
            { "HUF", Tuple.Create(new[] { "fòrint", "fòrints" }, new[] { "fillér", "fillérs" }) },
            { "FRF", Tuple.Create(new[] { "franc", "francs" }, new[] { "cèntim", "cèntims" }) },
            { "CNY", Tuple.Create(new[] { "iuan", "iuans" }, new[] { "fen", "jiao" }) },
            { "CZK", Tuple.Create(new[] { "corona", "corones" }, new[] { "haléř", "haléřů" }) },
            { "NIO", Tuple.Create(new[] { "córdoba", "córdobas" }, GENERIC_CENTS) },
            { "VES", Tuple.Create(new[] { "bolívar", "bolívars" }, new[] { "cèntim", "cèntims" }) },
            { "BRL", Tuple.Create(new[] { "real", "reals" }, GENERIC_CENTS) },
            { "CHF", Tuple.Create(new[] { "franc", "francs" }, new[] { "cèntim", "cèntims" }) },
            { "JPY", Tuple.Create(new[] { "ien", "iens" }, new[] { "sen", "sen" }) },
            { "KRW", Tuple.Create(new[] { "won", "wons" }, new[] { "jeon", "jeon" }) },
            { "KPW", Tuple.Create(new[] { "won", "wons" }, new[] { "chŏn", "chŏn" }) },
            { "TRY", Tuple.Create(new[] { "lira", "lires" }, new[] { "kuruş", "kuruş" }) },
            { "ZAR", Tuple.Create(new[] { "rand", "rands" }, new[] { "cèntim", "cèntims" }) },
            { "KZT", Tuple.Create(new[] { "tenge", "tenge" }, new[] { "tin", "tin" }) },
            { "UAH", Tuple.Create(new[] { "hrívnia", "hrívnies" }, new[] { "kopiika", "kopíok" }) },
            { "THB", Tuple.Create(new[] { "baht", "bahts" }, new[] { "satang", "satang" }) },
            { "AED", Tuple.Create(new[] { "dirham", "dirhams" }, new[] { "fils", "fulūs" }) },
            { "AFN", Tuple.Create(new[] { "afgani", "afganis" }, new[] { "puli", "puls" }) },
            { "ALL", Tuple.Create(new[] { "lek", "lekë" }, new[] { "qqindarka", "qindarkë" }) },
            { "AMD", Tuple.Create(new[] { "dram", "drams" }, new[] { "luma", "lumas" }) },
            { "ANG", Tuple.Create(new[] { "florí", "florins" }, new[] { "cèntim", "cèntims" }) },
            { "AOA", Tuple.Create(new[] { "kwanza", "kwanzes" }, new[] { "cèntim", "cèntims" }) },
            { "ARS", Tuple.Create(new[] { "peso", "pesos" }, GENERIC_CENTS) },
            { "AWG", Tuple.Create(new[] { "florí", "florins" }, GENERIC_CENTS) },
            { "AZN", Tuple.Create(new[] { "manat", "manats" }, new[] { "qəpik", "qəpik" }) },
            { "BBD", Tuple.Create(GENERIC_DOLLARS, GENERIC_CENTS) },
            { "BDT", Tuple.Create(new[] { "taka", "taka" }, new[] { "poisha", "poisha" }) },
            { "BGN", Tuple.Create(new[] { "lev", "leva" }, new[] { "stotinka", "stotinki" }) },
            { "BHD", Tuple.Create(new[] { "dinar", "dinars" }, new[] { "fils", "fulūs" }) },
            { "BIF", Tuple.Create(new[] { "franc", "francs" }, new[] { "cèntim", "cèntims" }) },
            { "BMD", Tuple.Create(GENERIC_DOLLARS, GENERIC_CENTS) },
            { "BND", Tuple.Create(GENERIC_DOLLARS, GENERIC_CENTS) },
            { "BOB", Tuple.Create(new[] { "boliviano", "bolivianos" }, GENERIC_CENTS) },
            { "BSD", Tuple.Create(GENERIC_DOLLARS, GENERIC_CENTS) },
            { "BTN", Tuple.Create(new[] { "ngultrum", "ngultrums" }, new[] { "chetrum", "chetrums" }) },
            { "BWP", Tuple.Create(new[] { "pula", "pula" }, new[] { "thebe", "thebe" }) },
            { "BYN", Tuple.Create(new[] { "ruble", "rubles" }, new[] { "copec", "copecs" }) },
            { "BYR", Tuple.Create(new[] { "ruble", "rubles" }, new[] { "copec", "copecs" }) },
            { "BZD", Tuple.Create(GENERIC_DOLLARS, new[] { "cèntim", "cèntims" }) },
            { "CDF", Tuple.Create(new[] { "franc", "francs" }, new[] { "cèntim", "cèntims" }) },
            { "CLP", Tuple.Create(new[] { "peso", "pesos" }, GENERIC_CENTS) },
            { "COP", Tuple.Create(new[] { "peso", "pesos" }, GENERIC_CENTS) },
            { "CUP", Tuple.Create(new[] { "peso", "pesos" }, GENERIC_CENTS) },
            { "CVE", Tuple.Create(new[] { "escut", "escuts" }, GENERIC_CENTS) },
            { "CYP", Tuple.Create(new[] { "lliura", "lliures" }, new[] { "cèntim", "cèntims" }) },
            { "DJF", Tuple.Create(new[] { "franc", "francs" }, new[] { "cèntim", "cèntims" }) },
            { "DKK", Tuple.Create(new[] { "corona", "corones" }, new[] { "øre", "øre" }) },
            { "DOP", Tuple.Create(new[] { "peso", "pesos" }, GENERIC_CENTS) },
            { "DZD", Tuple.Create(new[] { "dinar", "dinars" }, new[] { "cèntim", "cèntims" }) },
            { "ECS", Tuple.Create(new[] { "sucre", "sucres" }, GENERIC_CENTS) },
            { "EGP", Tuple.Create(new[] { "lliura", "lliures" }, new[] { "piastre", "piastres" }) },
            { "ERN", Tuple.Create(new[] { "nakfa", "nakfes" }, new[] { "cèntim", "cèntims" }) },
            { "ETB", Tuple.Create(new[] { "birr", "birr" }, new[] { "cèntim", "cèntims" }) },
            { "FJD", Tuple.Create(GENERIC_DOLLARS, GENERIC_CENTS) },
            { "FKP", Tuple.Create(new[] { "lliura", "lliures" }, new[] { "penic", "penics" }) },
            { "GEL", Tuple.Create(new[] { "lari", "laris" }, new[] { "tetri", "tetri" }) },
            { "GHS", Tuple.Create(new[] { "cedi", "cedis" }, new[] { "pesewa", "pesewas" }) },
            { "GIP", Tuple.Create(new[] { "lliura", "lliures" }, new[] { "penic", "penics" }) },
            { "GMD", Tuple.Create(new[] { "dalasi", "dalasis" }, new[] { "butut", "bututs" }) },
            { "GNF", Tuple.Create(new[] { "franc", "francs" }, new[] { "cèntim", "cèntims" }) },
            { "GTQ", Tuple.Create(new[] { "quetzal", "quetzals" }, GENERIC_CENTS) },
            { "GYD", Tuple.Create(GENERIC_DOLLARS, GENERIC_CENTS) },
            { "HKD", Tuple.Create(GENERIC_DOLLARS, GENERIC_CENTS) },
            { "HNL", Tuple.Create(new[] { "lempira", "lempires" }, GENERIC_CENTS) },
            { "HRK", Tuple.Create(new[] { "kuna", "kuna" }, new[] { "lipa", "lipa" }) },
            { "HTG", Tuple.Create(new[] { "gourde", "gourdes" }, new[] { "cèntim", "cèntims" }) },
            { "IDR", Tuple.Create(new[] { "rúpia", "rúpies" }, new[] { "cèntim", "cèntims" }) },
            { "ILS", Tuple.Create(new[] { "xéquel", "xéquels" }, new[] { "agorà", "agorot" }) },
            { "IQD", Tuple.Create(new[] { "dinar", "dinars" }, new[] { "fils", "fils" }) },
            { "IRR", Tuple.Create(new[] { "rial", "rials" }, new[] { "dinar", "dinars" }) },
            { "ISK", Tuple.Create(new[] { "corona", "corones" }, new[] { "eyrir", "aurar" }) },
            { "ITL", Tuple.Create(new[] { "lira", "lires" }, new[] { "cèntim", "cèntims" }) },
            { "JMD", Tuple.Create(GENERIC_DOLLARS, new[] { "cèntim", "cèntims" }) },
            { "JOD", Tuple.Create(new[] { "dinar", "dinars" }, new[] { "piastra", "piastres" }) },
            { "KES", Tuple.Create(new[] { "xiling", "xílings" }, new[] { "cèntim", "cèntims" }) },
            { "KGS", Tuple.Create(new[] { "som", "som" }, new[] { "tyiyn", "tyiyn" }) },
            { "KHR", Tuple.Create(new[] { "riel", "riels" }, new[] { "cèntim", "cèntims" }) },
            { "KMF", Tuple.Create(new[] { "franc", "francs" }, new[] { "cèntim", "cèntims" }) },
            { "KWD", Tuple.Create(new[] { "dinar", "dinars" }, new[] { "fils", "fils" }) },
            { "KYD", Tuple.Create(GENERIC_DOLLARS, new[] { "cèntim", "cèntims" }) },
            { "LAK", Tuple.Create(new[] { "kip", "kips" }, new[] { "at", "at" }) },
            { "LBP", Tuple.Create(new[] { "lliura", "lliures" }, new[] { "piastra", "piastres" }) },
            { "LKR", Tuple.Create(new[] { "rúpia", "rúpies" }, new[] { "cèntim", "cèntims" }) },
            { "LRD", Tuple.Create(GENERIC_DOLLARS, new[] { "cèntim", "cèntims" }) },
            { "LSL", Tuple.Create(new[] { "loti", "maloti" }, new[] { "sente", "lisente" }) },
            { "LTL", Tuple.Create(new[] { "lita", "litai" }, new[] { "cèntim", "cèntims" }) },
            { "LYD", Tuple.Create(new[] { "dinar", "dinars" }, new[] { "dírham", "dírhams" }) },
            { "MAD", Tuple.Create(new[] { "dírham", "dirhams" }, new[] { "cèntim", "cèntims" }) },
            { "MDL", Tuple.Create(new[] { "leu", "lei" }, new[] { "ban", "bani" }) },
            { "MGA", Tuple.Create(new[] { "ariary", "ariary" }, new[] { "iraimbilanja", "iraimbilanja" }) },
            { "MKD", Tuple.Create(new[] { "denar", "denari" }, new[] { "deni", "deni" }) },
            { "MMK", Tuple.Create(new[] { "kyat", "kyats" }, new[] { "pya", "pyas" }) },
            { "MNT", Tuple.Create(new[] { "tögrög", "tögrög" }, new[] { "möngö", "möngö" }) },
            { "MOP", Tuple.Create(new[] { "pataca", "pataques" }, new[] { "avo", "avos" }) },
            { "MRO", Tuple.Create(new[] { "ouguiya", "ouguiya" }, new[] { "khoums", "khoums" }) },
            { "MRU", Tuple.Create(new[] { "ouguiya", "ouguiya" }, new[] { "khoums", "khoums" }) },
            { "MUR", Tuple.Create(new[] { "rupia", "rúpies" }, new[] { "cèntim", "cèntims" }) },
            { "MVR", Tuple.Create(new[] { "rufiyaa", "rufiyaa" }, new[] { "laari", "laari" }) },
            { "MWK", Tuple.Create(new[] { "kwacha", "kwacha" }, new[] { "tambala", "tambala" }) },
            { "MYR", Tuple.Create(new[] { "ringgit", "ringgits" }, new[] { "sen", "sens" }) },
            { "MZN", Tuple.Create(new[] { "metical", "meticals" }, GENERIC_CENTS) },
            { "NAD", Tuple.Create(GENERIC_DOLLARS, new[] { "cèntim", "cèntims" }) },
            { "NGN", Tuple.Create(new[] { "naira", "naires" }, new[] { "kobo", "kobos" }) },
            { "NPR", Tuple.Create(new[] { "rupia", "rupies" }, new[] { "paisa", "paises" }) },
            { "NZD", Tuple.Create(GENERIC_DOLLARS, GENERIC_CENTS) },
            { "OMR", Tuple.Create(new[] { "rial", "rials" }, new[] { "baisa", "baisa" }) },
            { "PAB", Tuple.Create(GENERIC_DOLLARS, new[] { "centésimo", "centésimos" }) },
            { "PGK", Tuple.Create(new[] { "kina", "kina" }, new[] { "toea", "toea" }) },
            { "PHP", Tuple.Create(new[] { "peso", "pesos" }, GENERIC_CENTS) },
            { "PKR", Tuple.Create(new[] { "rupia", "rupies" }, new[] { "paisa", "paise" }) },
            { "PLZ", Tuple.Create(new[] { "zloty", "zlotys" }, new[] { "grosz", "groszy" }) },
            { "PYG", Tuple.Create(new[] { "guaraní", "guaranís" }, new[] { "cèntim", "cèntims" }) },
            { "QAR", Tuple.Create(new[] { "rial", "rials" }, new[] { "dírham", "dírhams" }) },
            { "QTQ", Tuple.Create(new[] { "quetzal", "quetzals" }, GENERIC_CENTS) },
            { "RSD", Tuple.Create(new[] { "dinar", "dinars" }, new[] { "para", "para" }) },
            { "RUR", Tuple.Create(new[] { "ruble", "rubles" }, new[] { "copec", "copecs" }) },
            { "RWF", Tuple.Create(new[] { "franc", "francs" }, new[] { "cèntim", "cèntims" }) },
            { "SAR", Tuple.Create(new[] { "riyal", "riyals" }, new[] { "hàl・lala", "hàl・lalat" }) },
            { "SBD", Tuple.Create(GENERIC_DOLLARS, new[] { "cèntim", "cèntims" }) },
            { "SCR", Tuple.Create(new[] { "rupia", "rupies" }, new[] { "cèntim", "cèntims" }) },
            { "SDG", Tuple.Create(new[] { "lliura", "lliures" }, new[] { "piastre", "piastres" }) },
            { "SGD", Tuple.Create(GENERIC_DOLLARS, new[] { "cèntim", "cèntims" }) },
            { "SHP", Tuple.Create(new[] { "lliura", "lliures" }, new[] { "penic", "penics" }) },
            { "SLL", Tuple.Create(new[] { "leonE", "leones" }, new[] { "cèntim", "cèntims" }) },
            { "SRD", Tuple.Create(GENERIC_DOLLARS, new[] { "cèntim", "cèntims" }) },
            { "SSP", Tuple.Create(new[] { "lliura", "lliures" }, new[] { "piastre", "piastres" }) },
            { "STD", Tuple.Create(new[] { "dobra", "dobrAs" }, new[] { "cèntim", "cèntims" }) },
            { "SVC", Tuple.Create(new[] { "colón", "colons" }, GENERIC_CENTS) },
            { "SYP", Tuple.Create(new[] { "lliura", "lliures" }, new[] { "piastre", "piastres" }) },
            { "SZL", Tuple.Create(new[] { "lilangeni", "emalangeni" }, new[] { "cèntim", "cèntims" }) },
            { "TJS", Tuple.Create(new[] { "somoni", "somoni" }, new[] { "diram", "diram" }) },
            { "TMT", Tuple.Create(new[] { "manat", "manats" }, new[] { "teňňesi", "teňňesi" }) },
            { "TND", Tuple.Create(new[] { "dinar", "dinars" }, new[] { "mil・lim", "mil・limat" }) },
            { "TOP", Tuple.Create(new[] { "paanga", "paangas" }, new[] { "seniti", "seniti" }) },
            { "TTD", Tuple.Create(GENERIC_DOLLARS, new[] { "cèntim", "cèntims" }) },
            { "TWD", Tuple.Create(new[] { "nou dòlar", "nous dòlars" }, new[] { "fen", "fen" }) },
            { "TZS", Tuple.Create(new[] { "xíling", "xílings" }, new[] { "cèntim", "cèntims" }) },
            { "UGX", Tuple.Create(new[] { "xíling", "xílings" }, new[] { "cèntim", "cèntims" }) },
            { "UYU", Tuple.Create(new[] { "peso", "pesos" }, new[] { "centèsim", "centèsims" }) },
            { "UZS", Tuple.Create(new[] { "som", "som" }, new[] { "tiyin", "tiyin" }) },
            { "VND", Tuple.Create(new[] { "dong", "dongs" }, new[] { "xu", "xu" }) },
            { "VUV", Tuple.Create(new[] { "vatu", "vatus" }, new[] { "cèntim", "cèntims" }) },
            { "WST", Tuple.Create(new[] { "tala", "tala" }, new[] { "sene", "sene" }) },
            { "XAF", Tuple.Create(new[] { "franc CFA", "francs CFA" }, new[] { "cèntim", "cèntims" }) },
            { "XCD", Tuple.Create(GENERIC_DOLLARS, new[] { "cèntim", "cèntims" }) },
            { "XOF", Tuple.Create(new[] { "franc CFA", "francs CFA" }, new[] { "cèntim", "cèntims" }) },
            { "XPF", Tuple.Create(new[] { "franc CFP", "francs CFP" }, new[] { "cèntim", "cèntims" }) },
            { "YER", Tuple.Create(new[] { "rial", "rials" }, new[] { "fils", "fils" }) },
            { "YUM", Tuple.Create(new[] { "dinar", "dinars" }, new[] { "para", "para" }) },
            { "ZMW", Tuple.Create(new[] { "kwacha", "kwacha" }, new[] { "ngwee", "ngwee" }) },
            { "ZWL", Tuple.Create(GENERIC_DOLLARS, new[] { "cèntim", "cèntims" }) },
            //{ "ZWL", Tuple.Create(GENERIC_DOLLARS, new[] { "cèntim", "cèntims" }) }
        };

        private static readonly string GIGA_SUFFIX = null;
        private static readonly string MEGA_SUFFIX = "ilió";

        public string[]? high_numwords;
        public string negword;
        public string pointword;
        public string errmsg_nonnum;
        public string errmsg_floatord;
        public string errmsg_negord;
        public string errmsg_toobig;
        public string gender_stem;
        public List<string> exclude_title;

        public List<Tuple<int, string>> mid_numwords;
        public string[] low_numwords;
        public Dictionary<int, string> mid_num;
        public Dictionary<int, string> low_num;
        public Dictionary<decimal, string> ords;
        public Dictionary<int, string> ords_2;
        public Dictionary<int, string> ords_3;

        public override void Setup()
        {
            base.Setup();

            var lows = new List<string> { "quadr", "tr", "b", "m" };
            high_numwords = GenHighNumwords(new string[] { }, new string[] { }, lows.ToArray())?.ToArray();
            negword = "menys ";
            pointword = "punt";
            errmsg_nonnum = "type(%s) no és [long, int, float]";
            errmsg_floatord = "El float %s no pot ser tractat com un" +
                " ordinal.";
            errmsg_negord = "El número negatiu %s no pot ser tractat" +
                " com un ordinal.";
            errmsg_toobig = "abs(%s) ha de ser inferior a %s.";
            gender_stem = "è";
            exclude_title = new List<string> { "i", "menys", "punt" };

            mid_numwords = new List<Tuple<int, string>>
        {
            new Tuple<int, string>(1000, "mil"),
            new Tuple<int, string>(100, "cent"),
            new Tuple<int, string>(90, "noranta"),
            new Tuple<int, string>(80, "vuitanta"),
            new Tuple<int, string>(70, "setanta"),
            new Tuple<int, string>(60, "seixanta"),
            new Tuple<int, string>(50, "cinquanta"),
            new Tuple<int, string>(40, "quaranta"),
            new Tuple<int, string>(30, "trenta"),
        };

            low_numwords = new string[]
        {
            "vint-i-nou", "vint-i-vuit", "vint-i-set", "vint-i-sis", "vint-i-cinc",
            "vint-i-quatre", "vint-i-tres", "vint-i-dos", "vint-i-un", "vint",
            "dinou", "divuit", "disset", "setze", "quinze", "catorze", "tretze",
            "dotze", "onze", "deu", "nou", "vuit", "set", "sis", "cinc", "quatre",
            "tres", "dos", "un", "zero"
        };

            mid_num = new Dictionary<int, string>
        {
            { 1000, "mil" }, { 100, "cent" }, { 90, "noranta" }, { 80, "vuitanta" },
            { 70, "setanta" }, { 60, "seixanta" }, { 50, "cinquanta" }, { 40, "quaranta" },
            { 30, "trenta" }, { 20, "vint" }, { 10, "deu" }
        };

            low_num = new Dictionary<int, string>
        {
            { 0, "zero" }, { 1, "un" }, { 2, "dos" }, { 3, "tres" }, { 4, "quatre" },
            { 5, "cinc" }, { 6, "sis" }, { 7, "set" }, { 8, "vuit" }, { 9, "nou" },
            { 10, "deu" }, { 11, "onze" }, { 12, "dotze" }, { 13, "tretze" }, { 14, "catorze" },
            { 15, "quinze" }, { 16, "setze" }, { 17, "disset" }, { 18, "divuit" }, { 19, "dinou" },
            { 20, "vint" }, { 21, "vint-i-un" }, { 22, "vint-i-dos" }, { 23, "vint-i-tres" },
            { 24, "vint-i-quatre" }, { 25, "vint-i-cinc" }, { 26, "vint-i-sis" }, { 27, "vint-i-set" },
            { 28, "vint-i-vuit" }, { 29, "vint-i-nou" }
        };

            ords = new Dictionary<decimal, string>
        {
            { 1, "primer" }, { 2, "segon" }, { 3, "tercer" }, { 4, "quart" }, { 5, "cinqu" },
            { 6, "sis" }, { 7, "set" }, { 8, "vuit" }, { 9, "nov" }, { 10, "des" },
            { 11, "onz" }, { 12, "dotz" }, { 13, "tretz" }, { 14, "catorz" }, { 15, "quinz" },
            { 16, "setz" }, { 17, "disset" }, { 18, "divuit" }, { 19, "dinov" }, { 20, "vint" },
            { 30, "trent" }, { 40, "quarant" }, { 50, "cinquant" }, { 60, "seixant" }, { 70, "setant" },
            { 80, "vuitant" }, { 90, "norant" }, { 100, "cent" }, { 200, "dos-cent" }, { 300, "tres-cent" },
            { 400, "quatre-cent" }, { 500, "cinc-cent" }, { 600, "sis-cent" }, { 700, "set-cent" }, { 800, "vuit-cent" },
            { 900, "nou-cent" }, { 1e3m, "mil" }, { 1e6m, "milion" }, { 1e9m, "mil milion" }, { 1e12m, "bilion" },
            { 1e15m, "mil bilion" }
        };

            ords_2 = new Dictionary<int, string> { { 1, "1r" }, { 2, "2n" }, { 3, "3r" }, { 4, "4t" } };

            ords_3 = new Dictionary<int, string>
        {
            { 1, "unè" }, { 2, "dosè" }, { 3, "tresè" }, { 4, "quatrè" }, { 5, "cinquè" },
            { 6, "sisè" }, { 7, "setè" }, { 8, "vuitè" }, { 9, "novè" }
        };
        }

        // 合并数字词
        public override (string, decimal) Merge((string, decimal) curr, (string, decimal) next)
        {
            string ctext = curr.Item1;
            decimal cnum = curr.Item2;
            string ntext = next.Item1;
            decimal nnum = next.Item2;

            if (cnum == 1)
            {
                if (nnum < 1000000)
                    return next;
                ctext = "un";
            }

            if (nnum < cnum)
            {
                if (cnum < 100)
                    return ($"{ctext}-{ntext}", cnum + nnum);
                else if (nnum == 1)
                    return ($"{ctext} {ntext}", cnum + nnum);
                else if (cnum == 100)
                    return ($"{ctext} {ntext}", cnum + nnum);
                else
                    return ($"{ctext} {ntext}", cnum + nnum);
            }
            else if ((nnum % 1000000 == 0) && cnum > 1)
            {
                ntext = ntext.Substring(0, ntext.Length - 3) + "lions";
            }

            if (nnum == 100)
            {
                ntext += "s";
                ctext += "-";
            }
            else
            {
                ntext = " " + ntext;
            }

            return (ctext + ntext, cnum * nnum);
        }

        // 转换为序数词
        public override string ToOrdinal(decimal value)
        {
            VerifyOrdinal(value);

            string text;
            if (value == 0)
            {
                text = "";
            }
            else if (value < 5)
            {
                text = ords[value];
            }
            else if (value <= 20)
            {
                text = $"{ords[value]}{gender_stem}";
            }
            else if (value <= 30)
            {
                int frac = (int)value % 10;
                text = $"{ords[20]}-i-{ords_3[frac]}";
            }
            else if (value < 100)
            {
                int dec = ((int)value / 10) * 10;
                text = $"{ords[dec]}a-{ords_3[(int)value - dec]}";
            }
            else if (value == 100)
            {
                text = $"{ords[value]}{gender_stem}";
            }
            else if (value < 200)
            {
                int cen = ((int)value / 100) * 100;
                text = $"{ords[cen]} {ToOrdinal(value - cen)}";
            }
            else if (value < 1000)
            {
                int cen = ((int)value / 100) * 100;
                text = $"{ords[cen]}s {ToOrdinal(value - cen)}";
            }
            else if (value == 1000)
            {
                text = $"{ords[value]}{gender_stem}";
            }
            else if (value < 1000000)
            {
                int dec = (int)Math.Pow(1000, (int)Math.Log((int)value, 1000));
                int high_part = (int)value / dec;
                int low_part = (int)value % dec;
                string cardinal = high_part != 1 ? ToCardinal(high_part) : "";
                text = $"{cardinal} {ords[dec]} {ToOrdinal(low_part)}";
            }
            else if (value < 1e18m)
            {
                int dec = (int)Math.Pow(1000, (int)Math.Log((int)value, 1000));
                int high_part = (int)value / dec;
                int low_part = (int)value % dec;
                string cardinal = high_part != 1 ? ToCardinal(high_part) : "";
                text = $"{cardinal}{ords[dec]}{gender_stem} {ToOrdinal(low_part)}";
            }
            else
            {
                string part1 = ToCardinal(value);
                text = $"{part1.Substring(0, part1.Length - 1)}onè";
            }

            return text.Trim();
        }

        // 转换为序数数字
        public override string ToOrdinalNum(decimal value)
        {
            VerifyOrdinal(value);

            if (!ords_2.ContainsKey((int)value))
            {
                return $"{value}{(gender_stem == "è" ? "è" : "a")}";
            }
            else
            {
                return ords_2[(int)value];
            }
        }

        // 转换为货币表示
        public override string ToCurrency(decimal val, string currency = "EUR", bool cents = true,
                                 string separator = " amb", bool adjective = false)
        {
            string result = ToCurrency(val, currency, cents, separator, adjective);

            string[] list_result = result.Split(new[] { separator + " " }, StringSplitOptions.None);

            if (CURRENCIES_UNA.Contains(currency))
            {
                list_result[0] = list_result[0].Replace("un", "una");
                list_result[0] = list_result[0].Replace("dos", "dues");
                list_result[0] = list_result[0].Replace("cents", "centes");
            }

            list_result[0] = list_result[0].Replace("vint-i-un", "vint-i-un");
            list_result[0] = list_result[0].Replace(" i un", "-un");
            list_result[0] = list_result[0].Replace("un", "un");

            if (CENTS_UNA.Contains(currency))
            {
                list_result[1] = list_result[1].Replace("un", "una");
                list_result[1] = list_result[1].Replace("dos", "dues");
            }

            list_result[1] = list_result[1].Replace("vint-i-un", "vint-i-una");
            list_result[1] = list_result[1].Replace("un", "un");

            result = string.Join(separator + " ", list_result);

            return result;
        }
    }
}
