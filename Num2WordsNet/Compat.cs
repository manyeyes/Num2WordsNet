using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Num2WordsNet
{
    internal class Compat
    {
        // 定义一个方法 to_s 用于将值转换为字符串
        public static string ToS(object val)
        {
            // 直接使用 ToString 方法将对象转换为字符串
            return val?.ToString() ?? "";
        }
    }
}
