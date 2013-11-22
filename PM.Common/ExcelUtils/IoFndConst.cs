#define DotNet2p0
using System;
#if DotNet2p0
using System.Collections.Generic;
#endif
using System.Text;
using System.Collections.Specialized;


namespace PM.Common.ExcelUtils
{
    /// <summary>
    /// 常量类
    /// </summary>
    public class IoFndConst
    {
        /// <summary>
        /// 全角的最小字符
        /// </summary>
        public const char MinCBCchar = '！';
        /// <summary>
        /// 全角的最大字符
        /// </summary>
        public const char MaxCBCchar = '｝';
        /// <summary>
        /// 半角的最小字符
        /// </summary>
        public const char MinSBCchar = '!';
        /// <summary>
        /// 半角的最大字符
        /// </summary>
        public const char MaxSBCchar = '}';
        /// <summary>
        /// 全角与半角的字符数值之差
        /// </summary>
        public const UInt16 CBC_SBC = MaxCBCchar - MaxSBCchar;
        /// <summary>
        /// 将路径记录到Xml文件时的数据表名称
        /// </summary>
        public const string DirFileInfoToXmlName = "DirFileInfoToXml";
        /// <summary>
        /// 年频度对照字符串
        /// </summary>
        private static string FreqYear = "0";
        /// <summary>
        /// 半年频度对照字符串
        /// </summary>
        private static string FreqHalfyear = "1";
        /// <summary>
        /// 季度频度对照字符串
        /// </summary>
        private static string FreqQuarter = "2";
        /// <summary>
        /// 月频度对照字符串
        /// </summary>
        private static string FreqMonth = "3";
        /// <summary>
        /// 日频度对照字符串
        /// </summary>
        private static string FreqDay = "4";
        /// <summary>
        /// 设定频度与字符串对照方式
        /// </summary>
        /// <param name="freqYear"></param>
        /// <param name="freqHalfyear"></param>
        /// <param name="freqQuarter"></param>
        /// <param name="freqMonth"></param>
        /// <param name="freqDay"></param>
        public static void SetFreq(string freqYear, string freqHalfyear, string freqQuarter, string freqMonth, string freqDay)
        {
            FreqYear = freqYear;
            FreqHalfyear = freqHalfyear;
            FreqQuarter = freqQuarter;
            FreqMonth = freqMonth;
            FreqDay = freqDay;
        }
        /// <summary>
        /// 获得指定字符串的频度
        /// </summary>
        /// <param name="stfreq"></param>
        /// <returns></returns>
        public static Freq GetFreq(string stfreq)
        {
            if (stfreq == FreqYear)
                return Freq.Year;
            else if (stfreq == FreqHalfyear)
                return Freq.HalfYear;
            else if (stfreq == FreqQuarter)
                return Freq.Quarter;
            else if (stfreq == FreqMonth)
                return Freq.Month;
            else if (stfreq == FreqDay)
                return Freq.Day;
            throw new Exception("没有对应的频度");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="freq"></param>
        /// <returns></returns>
        public static string GetfreqStr(Freq freq)
        {
            switch (freq)
            {
                case Freq.Year:
                    return FreqYear;
                case Freq.HalfYear:
                    return FreqHalfyear;
                case Freq.Quarter:
                    return FreqMonth;
                case Freq.Month:
                    return FreqMonth;
                case Freq.Day:
                    return FreqDay;
            }
            return null;
        }

        /// <summary>
        /// asp.net 执行alert脚本时进行的特殊字符替换。
        /// </summary>
        internal static string[] SpAlertMsgReplace = new string[]{"<","\\<",
													">","\\>",
													"'","\\'",
													"\"","\\\"",
													"\r","\\r",
													"\n","\\n"
													};
    }
    /// <summary>
    /// 日期类型中的频度枚举
    /// </summary>
    public enum Freq
    {
        /// <summary>
        /// 年
        /// </summary>
        Year = 0,
        /// <summary>
        /// 半年
        /// </summary>
        HalfYear = 1,
        /// <summary>
        /// 季
        /// </summary>
        Quarter = 2,
        /// <summary>
        /// 月
        /// </summary>
        Month = 3,
        /// <summary>
        /// 天
        /// </summary>
        Day = 4
    }
}
