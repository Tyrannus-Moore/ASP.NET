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

        /// <summary>
        /// 检查一个字符串是否可以转化为日期，一般用于验证用户输入日期的合法性。
        /// </summary>
        /// <param name="_value">需验证的字符串。</param>
        /// <returns>是否可以转化为日期的bool值。</returns>
        public static bool IsStringDate(string _value)
        {
            DateTime dt;
            try
            {
                dt = DateTime.Parse(_value);
            }
            catch (FormatException)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 把字符串转成日期
        /// </summary>
        /// <param name="_value">字符串</param>
        /// <param name="_defValue">默认值</param>
        /// <returns>返回转换后的日期</returns>
        public static DateTime StrToDate(string _value, DateTime _defValue)
        {
            try
            {
                return DateTime.Parse(_value);
            }
            catch (FormatException)
            {
                return _defValue;
            }
        }

        /// <summary>
        /// 把字符串转成日期,默认值为当前时间
        /// </summary>
        /// <param name="_value">字符串</param>
        /// <returns></returns>
        public static DateTime StrToDate(string _value)
        {
            return StrToDate(_value, DateTime.Now);
        }
    }
}
