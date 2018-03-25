using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Maticsoft.BLL
{
    public class Validator
    {
        /// </summary>
        /// <param name="express">正则表达式的内容。</param>
        /// <param name="value">需验证的字符串。</param>
        /// <returns>是否合法的bool值。</returns>
        public static bool QuickValidate(string express, string value)
        {
            if (value == null) return false;
            Regex myRegex = new Regex(express);
            if (value.Length == 0)
            {
                return false;
            }
            return myRegex.IsMatch(value);
        }

        /// <summary>
        /// 检查一个字符串是否是纯数字构成的，一般用于查询字符串参数的有效性验证。
        /// </summary>
        /// <param name="value">需验证的字符串。。</param>
        /// <returns>是否合法的bool值。</returns>
        public static bool IsNumberId(string value)
        {
            return Validator.QuickValidate("^[1-9]*[0-9]*$", value);
        }

        /// <summary>
        /// 获取正确的Id
        /// </summary>
        /// <param name="value">字符串</param>
        /// <returns></returns>
        public static int StrToId(string value)
        {
            if (IsNumberId(value))
                return int.Parse(value);
            else
                return 0;
        }
    }
}
