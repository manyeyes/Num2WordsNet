using System.Diagnostics;

namespace Num2WordsNet.Examples;
internal static partial class Program
{
    public static string applicationBase = AppDomain.CurrentDomain.BaseDirectory;
    [STAThread]
    private static void Main()
    {
        try
        {
            // 调用转换为基数词的方法
            string result = Num2Words.Process("24,120.10");
            Console.WriteLine(result);
            Debug.WriteLine(result);

            // 调用转换为基数词的方法
            result = Num2Words.Process("-42");
            Console.WriteLine(result);
            Debug.WriteLine(result);

            // 调用转换为序数词的方法
            result = Num2Words.Process(42, to: "ordinal");
            Console.WriteLine(result);
            Debug.WriteLine(result);

            // 调用转换为英文表述的方法
            result = Num2Words.Process(42, lang: "am");
            Console.WriteLine(result);
            Debug.WriteLine(result);

            result = Num2Words.Process(42, lang: "ar");
            Console.WriteLine(result);
            Debug.WriteLine(result);

            result = Num2Words.Process(42, lang: "az");
            Console.WriteLine(result);
            Debug.WriteLine(result);

            result = Num2Words.Process(42, lang: "be");
            Console.WriteLine(result);
            Debug.WriteLine(result);

            result = Num2Words.Process(42, lang: "ca");
            Console.WriteLine(result);
            Debug.WriteLine(result);

            result = Num2Words.Process(0.42, lang: "ce");
            Console.WriteLine(result);
            Debug.WriteLine(result);

            result = Num2Words.Process(42, lang: "ar", kwargs: new Dictionary<string, object> { { "prefix", "" } });
            Console.WriteLine(result);
            Debug.WriteLine(result);


            result = Num2Words.Process("-42256897.1250133");
            Console.WriteLine(result);
            Debug.WriteLine(result);

            result = Num2Words.Process(-1/235689741254f);
            Console.WriteLine(result);
            Debug.WriteLine(result);

            result = Num2Words.Process(1e-18m);
            Console.WriteLine(result);
            Debug.WriteLine(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}