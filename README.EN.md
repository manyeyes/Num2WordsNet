# Num2WordsNet

Num2WordsNet is a port of the Python project **num2words** to the C# programming language.

The num2words library converts numerical values into their word-based representations across multiple languages. For instance, the number "42" is transformed into "forty-two" (or its equivalent in other supported languages). A comprehensive list of supported languages is provided below.


## Usage
Pass a numerical value as a parameter to the `Num2Words.Process` method.

```csharp
// Convert a string-formatted number (uses comma as thousand separator and dot as decimal point)
string result = Num2Words.Process("24,120.10");
Console.WriteLine(result);
// Output: twenty-four thousand, one hundred and twenty point one zero

// Convert a decimal number and specify Chechen ("ce") as the target language
result = Num2Words.Process(0.42, lang: "ce");
Console.WriteLine(result);
// Output: ноль а диъ шиъ

// Convert an integer provided as a string
result = Num2Words.Process("42");
Console.WriteLine(result);
// Output: forty-two
```


## Key Optional Parameters
In addition to the numerical input, two primary optional parameters are available: `to` and `lang`.


### 1. Parameter: `to` (Converter Type)
This parameter specifies the type of conversion to apply. The following values are supported:

- **`cardinal`** (default): Converts numbers to their cardinal form (e.g., "42" → "forty-two").
- **`ordinal`**: Converts numbers to their ordinal form (e.g., "42" → "forty-second").
- **`ordinal_num`**: Converts numbers to a language-specific ordinal number format (the exact format varies by language).
- **`year`**: Converts numbers to a year-specific reading (e.g., "1999" → "nineteen ninety-nine" in English).
- **`currency`**: Converts numbers to a monetary word representation (e.g., "12.5" → "twelve dollars and fifty cents", with output dependent on the specified currency and language).


### 2. Parameter: `lang` (Target Language)
This parameter defines the language used for the word-based representation of the number. Supported values are listed below.


## Supported Languages (Values for `lang` Parameter)
Languages marked with ✔ are fully supported by Num2WordsNet; those marked with ☐ are pending implementation.

### Supported Languages
- ✔ `en` (English, default)
- ✔ `am` (Amharic)
- ✔ `ar` (Arabic)
- ✔ `az` (Azerbaijani)
- ✔ `be` (Belarusian)
- ✔ `bn` (Bengali)
- ✔ `ca` (Catalan)
- ✔ `ce` (Chechen)

### Languages Pending Support
- ☐ `cs` (Czech)
- ☐ `cy` (Welsh)
- ☐ `da` (Danish)
- ☐ `de` (German)
- ☐ `en_GB` (English - United Kingdom)
- ☐ `en_IN` (English - India)
- ☐ `en_NG` (English - Nigeria)
- ☐ `es` (Spanish)
- ☐ `es_CO` (Spanish - Colombia)
- ☐ `es_CR` (Spanish - Costa Rica)
- ☐ `es_GT` (Spanish - Guatemala)
- ☐ `es_VE` (Spanish - Venezuela)
- ☐ `eu` (Basque; note: previously described as "euro-related terminology"—corrected to standard language code)
- ☐ `fa` (Persian)
- ☐ `fi` (Finnish)
- ☐ `fr` (French)
- ☐ `fr_BE` (French - Belgium)
- ☐ `fr_CH` (French - Switzerland)
- ☐ `fr_DZ` (French - Algeria)
- ☐ `he` (Hebrew)
- ☐ `hi` (Hindi)
- ☐ `hu` (Hungarian)
- ☐ `hy` (Armenian)
- ☐ `id` (Indonesian)
- ☐ `is` (Icelandic)
- ☐ `it` (Italian)
- ☐ `ja` (Japanese)
- ☐ `kn` (Kannada)
- ☐ `ko` (Korean)
- ☐ `kz` (Kazakh)
- ☐ `mn` (Mongolian)
- ☐ `lt` (Lithuanian)
- ☐ `lv` (Latvian)
- ☐ `nl` (Dutch)
- ☐ `no` (Norwegian)
- ☐ `pl` (Polish)
- ☐ `pt` (Portuguese)
- ☐ `pt_BR` (Portuguese - Brazil)
- ☐ `ro` (Romanian)
- ☐ `ru` (Russian)
- ☐ `sl` (Slovenian)
- ☐ `sk` (Slovak)
- ☐ `sr` (Serbian)
- ☐ `sv` (Swedish)
- ☐ `te` (Telugu)
- ☐ `tet` (Tetum)
- ☐ `tg` (Tajik)
- ☐ `tr` (Turkish)
- ☐ `th` (Thai)
- ☐ `uk` (Ukrainian)
- ☐ `vi` (Vietnamese)
- ☐ `zh` (Traditional Chinese, generic)
- ☐ `zh_CN` (Simplified Chinese - Mainland China)
- ☐ `zh_TW` (Traditional Chinese - Taiwan, China)
- ☐ `zh_HK` (Traditional Chinese - Hong Kong, China)


## References
[1] Original Python Project: [num2words](https://github.com/savoirfairelinux/num2words)