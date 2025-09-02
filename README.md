# Num2WordsNet
Num2WordsNet is a port of the Python project num2words to the C# language.

num2words 库 —— 将数字转换为多种语言的文字表述，例如 42 这样的数字转换为像 “forty-two（四十二）” 这样文字表述的库。它支持多种语言（详见下方列表获取完整的语言清单）。

### 如何使用
传入数值参数

```csharp
string result = Num2Words.Process("24,120.10");
Console.WriteLine(result);
// twenty-four thousand, one hundred and twenty point one zero

result = Num2Words.Process(0.42, lang: "ce");
Console.WriteLine(result);
// ноль а диъ шиъ

result = Num2Words.Process("42");
Console.WriteLine(result);
// forty-two

```

### 除了数值参数之外，还有两个主要的可选参数，即“to”和“lang”：

“to”：要使用的转换器。支持以下取值：

- “cardinal”（默认值），用于将数字转换为基数词形式（例如将“42”转换为“forty-two”）。
- “ordinal”，用于将数字转换为序数词形式（例如将“42”转换为“forty-second”）。
- “ordinal_num”，用于将数字转换为特定格式的序数词表示（具体格式因语言而异）。
- “year”，用于将数字转换为年份相关的表述形式（比如将“1999”转换为对应的年份读法）。
- “currency”，用于将数字转换为货币金额的文字表述形式（例如将“12.5”转换为“twelve dollars and fifty cents”之类的表述，具体取决于所设定的货币及语言）。 

### 支持的语言（`lang`参数取值）
`lang`参数用于指定将数字转换为文字表述时所使用的语言，支持以下取值：

### 已支持语言（Supported）
- ✔ `en`（英语，默认值） 
- ✔ `am`（阿姆哈拉语）
- ✔ `ar`（阿拉伯语）
- ✔ `az`（阿塞拜疆语）
- ✔ `be`（白俄罗斯语）
- ✔ `bn`（孟加拉语）
- ✔ `ca`（加泰罗尼亚语）
- ✔ `ce`（车臣语）
- 
### 待支持语言（Pending Support）
- ☐ `cs`（捷克语）
- ☐ `cy`（威尔士语）
- ☐ `da`（丹麦语）
- ☐ `de`（德语）
- ☐ `en_GB`（英语 - 英国）
- ☐ `en_IN`（英语 - 印度）
- ☐ `en_NG`（英语 - 尼日利亚）
- ☐ `es`（西班牙语）
- ☐ `es_CO`（西班牙语 - 哥伦比亚）
- ☐ `es_CR`（西班牙语 - 哥斯达黎加）
- ☐ `es_GT`（西班牙语 - 危地马拉）
- ☐ `es_VE`（西班牙语 - 委内瑞拉）
- ☐ `eu`（欧元相关用语，可能是特定场景下的语言设定）
- ☐ `fa`（波斯语）
- ☐ `fi`（芬兰语）
- ☐ `fr`（法语）
- ☐ `fr_BE`（法语 - 比利时）
- ☐ `fr_CH`（法语 - 瑞士）
- ☐ `fr_DZ`（法语 - 阿尔及利亚）
- ☐ `he`（希伯来语）
- ☐ `hi`（印地语）
- ☐ `hu`（匈牙利语）
- ☐ `hy`（亚美尼亚语）
- ☐ `id`（印度尼西亚语）
- ☐ `is`（冰岛语）
- ☐ `it`（意大利语）
- ☐ `ja`（日语）
- ☐ `kn`（卡纳达语）
- ☐ `ko`（韩语）
- ☐ `kz`（哈萨克语）
- ☐ `mn`（蒙古语）
- ☐ `lt`（立陶宛语）
- ☐ `lv`（拉脱维亚语）
- ☐ `nl`（荷兰语）
- ☐ `no`（挪威语）
- ☐ `pl`（波兰语）
- ☐ `pt`（葡萄牙语）
- ☐ `pt_BR`（葡萄牙语 - 巴西）
- ☐ `ro`（罗马尼亚语）
- ☐ `ru`（俄语）
- ☐ `sl`（斯洛文尼亚语）
- ☐ `sk`（斯洛伐克语）
- ☐ `sr`（塞尔维亚语）
- ☐ `sv`（瑞典语）
- ☐ `te`（泰卢固语）
- ☐ `tet`（德顿语）
- ☐ `tg`（塔吉克语）
- ☐ `tr`（土耳其语）
- ☐ `th`（泰语）
- ☐ `uk`（乌克兰语）
- ☐ `vi`（越南语）
- ☐ `zh`（繁体中文）
- ☐ `zh_CN`（简体中文 / 中国大陆地区使用）
- ☐ `zh_TW`（繁体中文 / 中国台湾地区使用）
- ☐ `zh_HK`（繁体中文 / 中国香港地区使用） 

引用参考
----------
[1] https://github.com/savoirfairelinux/num2words
