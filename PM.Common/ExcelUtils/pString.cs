#define DotNet2p0
using System;
using System.Data;
using System.Text;
using System.Security.Cryptography;
using System.Collections.Specialized;

namespace PM.Common.ExcelUtils
{
    /// <summary>
    /// 用于完善字符串处理的类库
    /// </summary>
    public class pString
    {
        private string stValue;
        private static Encoding en = Encoding.GetEncoding("GB2312");
        /// <summary>
        /// 读取或设置该实例的<see cref="string"/>型值
        /// </summary>
        /// <value><see cref="string"/>型的值</value>
        public string StrValue
        {
            get { return stValue; }
            set { stValue = value; }
        }
        /// <summary>
        /// 无初始值的初始化，用该构造函数初始化后此实例的<see cref="StrValue"/>为<see cref="string.Empty"/>。
        /// </summary>
        public pString()
        {
            stValue = string.Empty;
        }
        /// <summary>
        /// 用一个<see cref="string"/>类型的字符串构造一个实例对象。
        /// </summary>
        /// <param name="stData">字符串的值</param>
        public pString(string stData)
        {
            stValue = stData;
        }

        /// <summary>
        /// 判断当前实例是否是数字
        /// </summary>
        /// <param name="IsHaveCBC">是否包含全角的字符</param>
        /// <returns>如果是返回true</returns>
        public bool GetIsNumber(bool IsHaveCBC)
        {
            pString res = new pString(this.stValue);
            if (IsHaveCBC)
            {
                res = res.ChangeToSBC();
            }
            try
            {
                double m = Convert.ToDouble(res.stValue);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 获取一个bool值，以判断该实例是不是一个数字型的字符串，该属性的返回值将受全角半角的影响。
        /// </summary>
        public bool IsNumber
        {
            get
            {
                pString res = new pString(this.stValue);
                try
                {
                    double m = Convert.ToDouble(res.stValue);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 已重载。截掉字符串末尾指定数目的字符
        /// </summary>
        /// <param name="stData">字符串</param>
        /// <param name="count">要截掉的字符数</param>
        /// <returns>返回的字符串</returns>
        /// <remarks>要截掉的字符数如果大于字符串长度则返回件则返回<see cref="string.Empty"/>。</remarks>
        /// <example><code>
        /// pString ps = new pString("abcd");
        /// pString res1 = ps - 2;
        /// pString res2 = ps--;
        /// /*
        /// Result:
        /// res1.StrValue is "ab"
        /// res2.StrValue is "abc"
        /// */
        /// </code></example>
        static public pString operator -(pString stData, int count)
        {
            string stemp = stData.StrValue;
            pString res;
            if (stemp.Length >= count)
                res = new pString(stemp.Substring(0, stemp.Length - count));
            else
                res = new pString(string.Empty);
            return res;
        }
        /// <summary>
        /// 已重载。字符串截取末尾的一个字符
        /// </summary>
        /// <param name="stData">字符串</param>
        /// <returns>返回的字符串</returns>
        /// <remarks>要截掉的字符数如果大于字符串长度则返回件则返回<see cref="string.Empty"/>。</remarks>
        /// <example><code>
        /// pString ps = new pString("abcd");
        /// pString res1 = ps - 2;
        /// pString res2 = ps--;
        /// /*
        /// Result:
        /// res1.StrValue is "ab"
        /// res2.StrValue is "abc"
        /// */
        /// </code></example>
        static public pString operator --(pString stData)
        {
            stData = stData - 1;
            return stData;
        }
        /// <summary>
        /// 已重载。<see cref="pString"/>型字符串加上一个<see cref="pString"/>型字符串
        /// </summary>
        /// <param name="stData0">字符串1</param>
        /// <param name="stData1">字符串2</param>
        /// <returns>结果字符串</returns>
        static public pString operator +(pString stData0, pString stData1)
        {
            return new pString(stData0.stValue + stData1.stValue);
        }
        /// <summary>
        /// 已重载。<see cref="pString"/>型字符串加上一个<see cref="string"/>型字符串
        /// </summary>
        /// <param name="stData0">字符串1</param>
        /// <param name="stData1">字符串2</param>
        /// <returns>结果字符串</returns>
        static public pString operator +(pString stData0, string stData1)
        {
            return new pString(stData0.stValue + stData1);
        }
        /// <summary>
        /// 已重载。<see cref="string"/>型字符串加上一个<see cref="pString"/>型字符串
        /// </summary>
        /// <param name="stData0">字符串1</param>
        /// <param name="stData1">字符串2</param>
        /// <returns>返回的字符串</returns>
        static public pString operator +(string stData0, pString stData1)
        {
            return new pString(stData0 + stData1.stValue);
        }

        ///// <summary>
        ///// 已重载。确定两个<see cref="pString"/>型对象是否相等。
        ///// </summary>
        ///// <param name="stData0">字符串1</param>
        ///// <param name="stData1">字符串2</param>
        ///// <returns>bool型返回值</returns>
        //static public bool operator ==(pString stData0, pString stData1)
        //{
        //    if (stData0 == null && stData1 == null)
        //        return true;
        //    if (stData0 == null || stData1 == null)
        //        return false;
        //    return stData0.GetHashCode() == stData1.GetHashCode();
        //}
        ///// <summary>
        ///// 已重载。确定<see cref="pString"/>型和<see cref="string"/>型对象是否相等。
        ///// </summary>
        ///// <param name="stData0">字符串1</param>
        ///// <param name="stData1">字符串2</param>
        ///// <returns>bool型返回值</returns>
        //static public bool operator ==(pString stData0, string stData1)
        //{
        //    return stData0.GetHashCode() == stData1.GetHashCode();
        //}
        ///// <summary>
        ///// 已重载。确定<see cref="string"/>型和<see cref="pString"/>型对象是否相等。
        ///// </summary>
        ///// <param name="stData0">字符串1</param>
        ///// <param name="stData1">字符串2</param>
        ///// <returns>bool型返回值</returns>
        //static public bool operator ==(string stData0, pString stData1)
        //{
        //    return stData0.GetHashCode() == stData1.GetHashCode();
        //}
        /// <summary>
        /// 已重写。返回该实例的哈希代码。
        /// </summary>
        /// <returns>一个 32 位有符号整数哈希代码。</returns>
        public override int GetHashCode()
        {
            return stValue.GetHashCode();
        }
        ///// <summary>
        ///// 已重载。已重写。确定两个 pString 对象是否具有相同的值。
        ///// </summary>
        ///// <param name="obj"></param>
        ///// <returns></returns>
        //public override bool Equals(object obj)
        //{
        //    return GetHashCode() == obj.GetHashCode();
        //}
        ///// <summary>
        ///// 已重载。确定两个<see cref="pString"/>型对象是否相等。
        ///// </summary>
        ///// <param name="stData0">字符串1</param>
        ///// <param name="stData1">字符串2</param>
        ///// <returns>bool型返回值</returns>
        //static public bool operator !=(pString stData0, pString stData1)
        //{
        //    if (stData0 == null && stData1 == null)
        //        return false;
        //    if (stData0 == null || stData1 == null)
        //        return true;
        //    return stData0.GetHashCode() != stData1.GetHashCode();
        //}
        ///// <summary>
        ///// 已重载。确定<see cref="pString"/>型对象和<see cref="string"/>型对象是否相等。
        ///// </summary>
        ///// <param name="stData0">字符串1</param>
        ///// <param name="stData1">字符串2</param>
        ///// <returns>bool型返回值</returns>
        //static public bool operator !=(pString stData0, string stData1)
        //{
        //    return stData0.GetHashCode() != stData1.GetHashCode();
        //}
        ///// <summary>
        ///// 已重载。确定<see cref="string"/>型对象和<see cref="pString"/>型对象是否相等。
        ///// </summary>
        ///// <param name="stData0">字符串1</param>
        ///// <param name="stData1">字符串2</param>
        ///// <returns>bool型返回值</returns>
        //static public bool operator !=(string stData0, pString stData1)
        //{
        //    return stData0.GetHashCode() != stData1.GetHashCode();
        //}
        /// <summary>
        /// 从所示位置开始寻找匹配位置.并返回寻找字符串下一个字符的索引
        /// </summary>
        /// <param name="StartIndex">起始位置</param>
        /// <param name="str">要查找的字符串</param>
        /// <returns>索引位置</returns>
        /// <remarks>该方法返回的所以位置有可能超出字符串的索引范围，所以在使用时应该做如下判断
        /// <code>
        /// pString ps = new pString("abcdef");
        /// int Index = ps.IndexOfNext("def", 1);
        /// if(Index != ps.StrValue.Length)
        /// {
        ///     char c = ps[Index];
        /// }
        /// </code></remarks>
        public int IndexOfNext(string str, int StartIndex)
        {
            int res = this.StrValue.IndexOf(str, StartIndex);
            if (res == -1)
                return -1;
            else
                return res + str.Length;
        }
        /// <summary>
        /// 从字符串开始寻找匹配位置.并返回寻找字符串下一个字符的索引
        /// </summary>
        /// <param name="str">要查找的字符串</param>
        /// <returns>索引位置</returns>
        /// <remarks>该方法返回的所以位置有可能超出字符串的索引范围，所以在使用时应该做如下判断
        /// <code>
        /// pString ps = new pString("abcdef");
        /// int Index = ps.IndexOfNext("def");
        /// if(Index != ps.StrValue.Length)
        /// {
        ///     char c = ps[Index];
        /// }
        /// </code></remarks>
        public int IndexOfNext(string str)
        {
            return IndexOfNext(str, 0);
        }

        /// <summary>
        /// 从字符串结尾开始从所指位置开始寻找匹配位置.并返回寻找字符串下一个字符的索引
        /// </summary>
        /// <param name="StartIndex">起始位置</param>
        /// <param name="str">要查找的字符串</param>
        /// <returns>索引位置</returns>
        /// <exception cref="ArgumentNullException">str为空引用（Visual Basic 中为 Nothing）。</exception>
        /// <remarks>该方法返回的所以位置有可能超出字符串的索引范围，所以在使用时应该做如下判断
        /// <code>
        /// pString ps = new pString("abcdef");
        /// int Index = ps.LastIndexOfNext("def", 1);
        /// if(Index != ps.StrValue.Length)
        /// {
        ///     char c = ps[Index];
        /// }
        /// </code></remarks>
        public int LastIndexOfNext(string str, int StartIndex)
        {
            int res = this.StrValue.LastIndexOf(str, StartIndex);
            if (res == -1)
                return -1;
            else
                return res + str.Length;
        }
        /// <summary>
        /// 从字符串的结尾开始寻找匹配位置。并返回寻找字符串的下一个字符的索引
        /// </summary>
        /// <param name="str">要查找的字符串</param>
        /// <returns>索引位置</returns>
        /// <exception cref="ArgumentNullException">str为空引用（Visual Basic 中为 Nothing）。</exception>
        /// <remarks>该方法返回的所以位置有可能超出字符串的索引范围，所以在使用时应该做如下判断
        /// <code>
        /// pString ps = new pString("abcdef");
        /// int Index = ps.LastIndexOfNext("def");
        /// if(Index != ps.StrValue.Length)
        /// {
        ///     char c = ps[Index];
        /// }
        /// </code></remarks>
        public int LastIndexOfNext(string str)
        {
            return LastIndexOfNext(str, this.StrValue.Length - 1);
        }

        /// <summary>
        /// 返回给定正（倒）序索引值的倒（正）叙索引值
        /// </summary>
        /// <remarks>如果给定的索引值超出字符串范围则返回-1</remarks>
        /// <param name="Index">从0开始的索引值</param>
        /// <returns>返回的从0开始的索引值</returns>
        /// <example><code>
        /// pString ps = new pString("1234");
        /// int Index = ps.ChangeOrder(2);
        /// /*
        /// Result:
        /// Index is 1
        /// */
        /// </code></example>
        public int ChangeOrder(int Index)
        {
            if (Index >= stValue.Length)
                return -1;
            return stValue.Length - Index - 1;
        }

        /// <summary>
        /// 根据开始结束字符串从当前实例的开始位置截取字符串，截得的字符串包括开始字符串、结束字符串。
        /// </summary>
        /// <param name="strS">开始字符串</param>
        /// <param name="strE">结束字符串</param>
        /// <returns>截取后的值</returns>
        /// <exception cref="ArgumentNullException">strS或strE为空引用（Visual Basic 中为 Nothing）。</exception>
        /// <remarks>如果在字符串中包含多处与开始字符串、结束字符串相同的位置，则截得的结果是以从开始位置起第一个与开始字符串相匹配的位置前到从开始位置起第一个与结束字符串相匹配的位置后的字符串。如果字符串不符合截取条件则返回<see cref="string.Empty"/>。与之相类似的方法还有<see cref="GetMidStr(string,string)"/>,<see cref="GetMidStrS(string,string)"/>,<see cref="GetMidStrE(string,string)"/>,<see cref="GetLastMidStrSE(string,string)"/>,<see cref="GetLastMidStr(string,string)"/>,<see cref="GetLastMidStrS(string,string)"/>,<see cref="GetLastMidStrE(string,string)"/>,</remarks>
        /// <example><code>
        /// pString ps =new pString("ABCDEFABCDEFABCDEF");
        /// pString resps0 = ps.GetMidStrSE("B","B");
        /// pString resps1 = ps.GetMidStrS("B","B");
        /// pString resps2 = ps.GetMidStrE("B","B");
        /// pString resps3 = ps.GetMidStr("B","B");
        /// pString resps4 = ps.GetLastMidStrSE("B","B");
        /// pString resps5 = ps.GetLastMidStrS("B","B");
        /// pString resps6 = ps.GetLastMidStrE("B","B");
        /// pString resps7 = ps.GetLastMidStr("B","B");
        /// /*
        /// Result:
        /// resps0.StrValue is "BCDEFAB"
        /// resps1.StrValue is "BCDEFA"
        /// resps2.StrValue is "CDEFAB"
        /// resps3.StrValue is "CDEFA"
        /// resps4.StrValue is "BCDEFABCDEFAB"
        /// resps5.StrValue is "BCDEFABCDEFA"
        /// resps6.StrValue is "CDEFABCDEFAB"
        /// resps7.StrValue is "CDEFABCDEFA"
        /// */
        /// </code></example>
        public pString GetMidStrSE(string strS, string strE)
        {
            string temp = this.StrValue;
            int stpos = temp.IndexOf(strS);
            int count = this.IndexOfNext(strE);
            if (stpos == -1 || count == -1)
                return new pString(string.Empty);
            return new pString(temp.Substring(stpos, count - stpos));
        }
        /// <summary>
        /// 根据开始结束字符串从当前实例的开始位置截取字符串，截得的字符串不包括开始字符串、结束字符串。
        /// </summary>
        /// <param name="strS">开始字符串</param>
        /// <param name="strE">结束字符串</param>
        /// <returns>截取后的值</returns>
        /// <exception cref="ArgumentNullException">strS或strE为空引用（Visual Basic 中为 Nothing）。</exception>
        /// <remarks>如果在字符串中包含多处与开始字符串、结束字符串相同的位置，则截得的结果是以从开始位置起第一个与开始字符串相匹配的位置后到从开始位置起第一个与结束字符串相匹配的位置前位置后的字符串。如果字符串不符合截取条件则返回<see cref="string.Empty"/>。与之相类似的方法还有<see cref="GetMidStrSE(string,string)"/>,<see cref="GetMidStrS(string,string)"/>,<see cref="GetMidStrE(string,string)"/>,<see cref="GetLastMidStrSE(string,string)"/>,<see cref="GetLastMidStr(string,string)"/>,<see cref="GetLastMidStrS(string,string)"/>,<see cref="GetLastMidStrE(string,string)"/>,</remarks>
        /// <example><code>
        /// pString ps =new pString("ABCDEFABCDEFABCDEF");
        /// pString resps0 = ps.GetMidStrSE("B","B");
        /// pString resps1 = ps.GetMidStrS("B","B");
        /// pString resps2 = ps.GetMidStrE("B","B");
        /// pString resps3 = ps.GetMidStr("B","B");
        /// pString resps4 = ps.GetLastMidStrSE("B","B");
        /// pString resps5 = ps.GetLastMidStrS("B","B");
        /// pString resps6 = ps.GetLastMidStrE("B","B");
        /// pString resps7 = ps.GetLastMidStr("B","B");
        /// /*
        /// Result:
        /// resps0.StrValue is "BCDEFAB"
        /// resps1.StrValue is "BCDEFA"
        /// resps2.StrValue is "CDEFAB"
        /// resps3.StrValue is "CDEFA"
        /// resps4.StrValue is "BCDEFABCDEFAB"
        /// resps5.StrValue is "BCDEFABCDEFA"
        /// resps6.StrValue is "CDEFABCDEFAB"
        /// resps7.StrValue is "CDEFABCDEFA"
        /// */
        /// </code></example>
        public pString GetMidStr(string strS, string strE)
        {
            string temp = this.StrValue;
            int stpos = this.IndexOfNext(strS);
            int count = temp.IndexOf(strE);
            if (stpos == -1 || count == -1)
                return new pString(string.Empty);
            return new pString(temp.Substring(stpos, count - stpos));
        }
        /// <summary>
        /// 根据开始结束字符串从当前实例的开始位置截取字符串，截得的字符串包括开始字符串。
        /// </summary>
        /// <param name="strS">开始字符串</param>
        /// <param name="strE">结束字符串</param>
        /// <returns>截取后的值</returns>
        /// <exception cref="ArgumentNullException">strS或strE为空引用（Visual Basic 中为 Nothing）。</exception>
        /// <remarks>如果在字符串中包含多处与开始字符串、结束字符串相同的位置，则截得的结果是以从开始位置起第一个与开始字符串相匹配的位置前到从开始位置起第一个与结束字符串相匹配的位置前位置后的字符串。如果字符串不符合截取条件则返回<see cref="string.Empty"/>。与之相类似的方法还有<see cref="GetMidStrSE(string,string)"/>,<see cref="GetMidStr(string,string)"/>,<see cref="GetMidStrE(string,string)"/>,<see cref="GetLastMidStrSE(string,string)"/>,<see cref="GetLastMidStr(string,string)"/>,<see cref="GetLastMidStrS(string,string)"/>,<see cref="GetLastMidStrE(string,string)"/>,</remarks>
        /// <example><code>
        /// pString ps =new pString("ABCDEFABCDEFABCDEF");
        /// pString resps0 = ps.GetMidStrSE("B","B");
        /// pString resps1 = ps.GetMidStrS("B","B");
        /// pString resps2 = ps.GetMidStrE("B","B");
        /// pString resps3 = ps.GetMidStr("B","B");
        /// pString resps4 = ps.GetLastMidStrSE("B","B");
        /// pString resps5 = ps.GetLastMidStrS("B","B");
        /// pString resps6 = ps.GetLastMidStrE("B","B");
        /// pString resps7 = ps.GetLastMidStr("B","B");
        /// /*
        /// Result:
        /// resps0.StrValue is "BCDEFAB"
        /// resps1.StrValue is "BCDEFA"
        /// resps2.StrValue is "CDEFAB"
        /// resps3.StrValue is "CDEFA"
        /// resps4.StrValue is "BCDEFABCDEFAB"
        /// resps5.StrValue is "BCDEFABCDEFA"
        /// resps6.StrValue is "CDEFABCDEFAB"
        /// resps7.StrValue is "CDEFABCDEFA"
        /// */
        /// </code></example>
        public pString GetMidStrS(string strS, string strE)
        {
            string temp = this.StrValue;
            int stpos = temp.IndexOf(strS);
            int count = temp.IndexOf(strE);
            if (stpos == -1 || count == -1)
                return new pString(string.Empty);
            return new pString(temp.Substring(stpos, count - stpos));
        }
        /// <summary>
        /// 根据开始结束字符串从当前实例的开始位置截取字符串，截得的字符串包括结束字符串。
        /// </summary>
        /// <param name="strS">开始字符串</param>
        /// <param name="strE">结束字符串</param>
        /// <returns>截取后的值</returns>
        /// <exception cref="ArgumentNullException">strS或strE为空引用（Visual Basic 中为 Nothing）。</exception>
        /// <remarks>如果在字符串中包含多处与开始字符串、结束字符串相同的位置，则截得的结果是以从开始位置起第一个与开始字符串相匹配的位置后到从开始位置起第一个与结束字符串相匹配的位置后的字符串。如果字符串不符合截取条件则返回<see cref="string.Empty"/>。与之相类似的方法还有<see cref="GetMidStrSE(string,string)"/>,<see cref="GetMidStr(string,string)"/>,<see cref="GetMidStrS(string,string)"/>,<see cref="GetLastMidStrSE(string,string)"/>,<see cref="GetLastMidStr(string,string)"/>,<see cref="GetLastMidStrS(string,string)"/>,<see cref="GetLastMidStrE(string,string)"/>,</remarks>
        /// <example><code>
        /// pString ps =new pString("ABCDEFABCDEFABCDEF");
        /// pString resps0 = ps.GetMidStrSE("B","B");
        /// pString resps1 = ps.GetMidStrS("B","B");
        /// pString resps2 = ps.GetMidStrE("B","B");
        /// pString resps3 = ps.GetMidStr("B","B");
        /// pString resps4 = ps.GetLastMidStrSE("B","B");
        /// pString resps5 = ps.GetLastMidStrS("B","B");
        /// pString resps6 = ps.GetLastMidStrE("B","B");
        /// pString resps7 = ps.GetLastMidStr("B","B");
        /// /*
        /// Result:
        /// resps0.StrValue is "BCDEFAB"
        /// resps1.StrValue is "BCDEFA"
        /// resps2.StrValue is "CDEFAB"
        /// resps3.StrValue is "CDEFA"
        /// resps4.StrValue is "BCDEFABCDEFAB"
        /// resps5.StrValue is "BCDEFABCDEFA"
        /// resps6.StrValue is "CDEFABCDEFAB"
        /// resps7.StrValue is "CDEFABCDEFA"
        /// */
        /// </code></example>
        public pString GetMidStrE(string strS, string strE)
        {
            string temp = this.StrValue;
            int stpos = this.IndexOfNext(strS);
            int count = this.IndexOfNext(strE);
            if (stpos == -1 || count == -1)
                return new pString(string.Empty);
            return new pString(temp.Substring(stpos, count - stpos));
        }
        /// <summary>
        /// 根据开始结束字符串从当前实例的首尾开始截取字符串，截得的字符串包括开始字符串和结束字符串。
        /// </summary>
        /// <param name="strS">开始字符串</param>
        /// <param name="strE">结束字符串</param>
        /// <returns>截取后的值</returns>
        /// <exception cref="ArgumentNullException">strS或strE为空引用（Visual Basic 中为 Nothing）。</exception>
        /// <remarks>如果在字符串中包含多处与开始字符串、结束字符串相同的位置，则截得的结果是以从开始位置起第一个与开始字符串相匹配的位置后到从末尾位置起第一个与结束字符串相匹配的位置前位置后的字符串。如果字符串不符合截取条件则返回<see cref="string.Empty"/>。与之相类似的方法还有<see cref="GetMidStrSE(string,string)"/>,<see cref="GetMidStr(string,string)"/>,<see cref="GetMidStrS(string,string)"/>,<see cref="GetMidStrE(string,string)"/>,<see cref="GetLastMidStr(string,string)"/>,<see cref="GetLastMidStrS(string,string)"/>,<see cref="GetLastMidStrE(string,string)"/>,</remarks>
        /// <example><code>
        /// pString ps =new pString("ABCDEFABCDEFABCDEF");
        /// pString resps0 = ps.GetMidStrSE("B","B");
        /// pString resps1 = ps.GetMidStrS("B","B");
        /// pString resps2 = ps.GetMidStrE("B","B");
        /// pString resps3 = ps.GetMidStr("B","B");
        /// pString resps4 = ps.GetLastMidStrSE("B","B");
        /// pString resps5 = ps.GetLastMidStrS("B","B");
        /// pString resps6 = ps.GetLastMidStrE("B","B");
        /// pString resps7 = ps.GetLastMidStr("B","B");
        /// /*
        /// Result:
        /// resps0.StrValue is "BCDEFAB"
        /// resps1.StrValue is "BCDEFA"
        /// resps2.StrValue is "CDEFAB"
        /// resps3.StrValue is "CDEFA"
        /// resps4.StrValue is "BCDEFABCDEFAB"
        /// resps5.StrValue is "BCDEFABCDEFA"
        /// resps6.StrValue is "CDEFABCDEFAB"
        /// resps7.StrValue is "CDEFABCDEFA"
        /// */
        /// </code></example>
        public pString GetLastMidStrSE(string strS, string strE)
        {
            string temp = this.StrValue;
            int stpos = temp.IndexOf(strS);
            int count = this.LastIndexOfNext(strE);
            if (stpos == -1 || count == -1)
                return new pString(string.Empty);
            return new pString(temp.Substring(stpos, count - stpos));
        }
        /// <summary>
        /// 根据开始结束字符串从当前实例的首尾开始截取字符串，截得的字符串不包括开始字符串和结束字符串。
        /// </summary>
        /// <param name="strS">开始字符串</param>
        /// <param name="strE">结束字符串</param>
        /// <returns>截取后的值</returns>
        /// <exception cref="ArgumentNullException">strS或strE为空引用（Visual Basic 中为 Nothing）。</exception>
        /// <remarks>如果在字符串中包含多处与开始字符串、结束字符串相同的位置，则截得的结果是以从开始位置起第一个与开始字符串相匹配的位置后到从末尾位置起第一个与结束字符串相匹配的位置前位置后的字符串。如果字符串不符合截取条件则返回<see cref="string.Empty"/>。与之相类似的方法还有<see cref="GetMidStrSE(string,string)"/>,<see cref="GetMidStr(string,string)"/>,<see cref="GetMidStrS(string,string)"/>,<see cref="GetMidStrE(string,string)"/>,<see cref="GetLastMidStrSE(string,string)"/>,<see cref="GetLastMidStrS(string,string)"/>,<see cref="GetLastMidStrE(string,string)"/>,</remarks>
        /// <example><code>
        /// pString ps =new pString("ABCDEFABCDEFABCDEF");
        /// pString resps0 = ps.GetMidStrSE("B","B");
        /// pString resps1 = ps.GetMidStrS("B","B");
        /// pString resps2 = ps.GetMidStrE("B","B");
        /// pString resps3 = ps.GetMidStr("B","B");
        /// pString resps4 = ps.GetLastMidStrSE("B","B");
        /// pString resps5 = ps.GetLastMidStrS("B","B");
        /// pString resps6 = ps.GetLastMidStrE("B","B");
        /// pString resps7 = ps.GetLastMidStr("B","B");
        /// /*
        /// Result:
        /// resps0.StrValue is "BCDEFAB"
        /// resps1.StrValue is "BCDEFA"
        /// resps2.StrValue is "CDEFAB"
        /// resps3.StrValue is "CDEFA"
        /// resps4.StrValue is "BCDEFABCDEFAB"
        /// resps5.StrValue is "BCDEFABCDEFA"
        /// resps6.StrValue is "CDEFABCDEFAB"
        /// resps7.StrValue is "CDEFABCDEFA"
        /// */
        /// </code></example>
        public pString GetLastMidStr(string strS, string strE)
        {
            string temp = this.StrValue;
            int stpos = this.IndexOfNext(strS);
            int count = temp.LastIndexOf(strE);
            if (stpos == -1 || count == -1)
                return new pString(string.Empty);
            return new pString(temp.Substring(stpos, count - stpos));
        }
        /// <summary>
        /// 根据开始结束字符串从当前实例的首尾开始截取字符串，截得的字符串包括开始字符串。
        /// </summary>
        /// <param name="strS">开始字符串</param>
        /// <param name="strE">结束字符串</param>
        /// <returns>截取后的值</returns>
        /// <exception cref="ArgumentNullException">strS或strE为空引用（Visual Basic 中为 Nothing）。</exception>
        /// <remarks>如果在字符串中包含多处与开始字符串、结束字符串相同的位置，则截得的结果是以从开始位置起第一个与开始字符串相匹配的位置后到从末尾位置起第一个与结束字符串相匹配的位置前位置后的字符串。如果字符串不符合截取条件则返回<see cref="string.Empty"/>。与之相类似的方法还有<see cref="GetMidStrSE(string,string)"/>,<see cref="GetMidStr(string,string)"/>,<see cref="GetMidStrS(string,string)"/>,<see cref="GetMidStrE(string,string)"/>,<see cref="GetLastMidStrSE(string,string)"/>,<see cref="GetLastMidStr(string,string)"/>,<see cref="GetLastMidStrE(string,string)"/>,</remarks>
        /// <example><code>
        /// pString ps =new pString("ABCDEFABCDEFABCDEF");
        /// pString resps0 = ps.GetMidStrSE("B","B");
        /// pString resps1 = ps.GetMidStrS("B","B");
        /// pString resps2 = ps.GetMidStrE("B","B");
        /// pString resps3 = ps.GetMidStr("B","B");
        /// pString resps4 = ps.GetLastMidStrSE("B","B");
        /// pString resps5 = ps.GetLastMidStrS("B","B");
        /// pString resps6 = ps.GetLastMidStrE("B","B");
        /// pString resps7 = ps.GetLastMidStr("B","B");
        /// /*
        /// Result:
        /// resps0.StrValue is "BCDEFAB"
        /// resps1.StrValue is "BCDEFA"
        /// resps2.StrValue is "CDEFAB"
        /// resps3.StrValue is "CDEFA"
        /// resps4.StrValue is "BCDEFABCDEFAB"
        /// resps5.StrValue is "BCDEFABCDEFA"
        /// resps6.StrValue is "CDEFABCDEFAB"
        /// resps7.StrValue is "CDEFABCDEFA"
        /// */
        /// </code></example>
        public pString GetLastMidStrS(string strS, string strE)
        {
            string temp = this.StrValue;
            int stpos = temp.IndexOf(strS);
            int count = temp.LastIndexOf(strE);
            if (stpos == -1 || count == -1)
                return new pString(string.Empty);
            return new pString(temp.Substring(stpos, count - stpos));
        }
        /// <summary>
        /// 根据开始结束字符串从当前实例的首尾开始截取字符串，截得的字符串包括结束字符串。
        /// </summary>
        /// <param name="strS">开始字符串</param>
        /// <param name="strE">结束字符串</param>
        /// <returns>截取后的值</returns>
        /// <exception cref="ArgumentNullException">strS或strE为空引用（Visual Basic 中为 Nothing）。</exception>
        /// <remarks>如果在字符串中包含多处与开始字符串、结束字符串相同的位置，则截得的结果是以从开始位置起第一个与开始字符串相匹配的位置后到从末尾位置起第一个与结束字符串相匹配的位置后的字符串。如果字符串不符合截取条件则返回<see cref="string.Empty"/>。与之相类似的方法还有<see cref="GetMidStrSE(string,string)"/>,<see cref="GetMidStr(string,string)"/>,<see cref="GetMidStrS(string,string)"/>,<see cref="GetMidStrE(string,string)"/>,<see cref="GetLastMidStrSE(string,string)"/>,<see cref="GetLastMidStr(string,string)"/>,<see cref="GetLastMidStrS(string,string)"/>,</remarks>
        /// <example><code>
        /// pString ps =new pString("ABCDEFABCDEFABCDEF");
        /// pString resps0 = ps.GetMidStrSE("B","B");
        /// pString resps1 = ps.GetMidStrS("B","B");
        /// pString resps2 = ps.GetMidStrE("B","B");
        /// pString resps3 = ps.GetMidStr("B","B");
        /// pString resps4 = ps.GetLastMidStrSE("B","B");
        /// pString resps5 = ps.GetLastMidStrS("B","B");
        /// pString resps6 = ps.GetLastMidStrE("B","B");
        /// pString resps7 = ps.GetLastMidStr("B","B");
        /// /*
        /// Result:
        /// resps0.StrValue is "BCDEFAB"
        /// resps1.StrValue is "BCDEFA"
        /// resps2.StrValue is "CDEFAB"
        /// resps3.StrValue is "CDEFA"
        /// resps4.StrValue is "BCDEFABCDEFAB"
        /// resps5.StrValue is "BCDEFABCDEFA"
        /// resps6.StrValue is "CDEFABCDEFAB"
        /// resps7.StrValue is "CDEFABCDEFA"
        /// */
        /// </code></example>
        public pString GetLastMidStrE(string strS, string strE)
        {
            string temp = this.StrValue;
            int stpos = this.IndexOfNext(strS);
            int count = this.LastIndexOfNext(strE);
            if (stpos == -1 || count == -1)
                return new pString(string.Empty);
            return new pString(temp.Substring(stpos, count - stpos));
        }

        /// <summary>
        /// 将字符串从左侧开始分别读取分割字符串前的数据，每读一次，数据被截短一次。
        /// </summary>
        /// <param name="cptstr">分隔字符串</param>
        /// <returns>数据项</returns>
        /// <remarks>如果字符串中找不到分隔字符串，则返回整个字符串，而且当前字符串也被截为string.Empty，该方法受大小写影响。</remarks>
        /// <exception cref="ArgumentNullException">cptstr 为空引用（Visual Basic 中为 Nothing）。</exception>
        /// <example><code>
        /// pString ps = new pString("A1B2C3");
        /// pString rps;
        /// rps = ps.GetData("1");
        /// /*
        /// Result:
        /// rps.StrValue is "A"
        /// ps.StrValue is "B2C3"
        /// */
        /// rps = ps.GetData("2");
        /// /*
        /// Result:
        /// rps.StrValue is "B"
        /// ps.StrValue is "C3"
        /// */
        /// rps = ps.GetData("3");
        /// /*
        /// Result:
        /// rps.StrValue is "C"
        /// ps.StrValue is string.Empty
        /// */
        /// </code></example>
        public pString GetData(string cptstr)
        {
            int pos = this.StrValue.IndexOf(cptstr);
            if (pos == -1)
                pos = StrValue.Length;
            pString res = new pString(StrValue.Substring(0, pos));
            this.StrValue = StrValue.Substring(pos + cptstr.Length);
            res.StrValue = res.StrValue.Replace(cptstr, string.Empty);
            return res;
        }

        /// <summary>
        /// 将字符串中的字符替换为全角
        /// </summary>
        /// <returns>转换后的字符串</returns>
        /// <remarks>该转换是借助于<see cref="ChangeToSBC(char)"/>与<see cref="ChangeToSBC(char)"/>两个静态方法实现的转换的条件请参阅<see cref="ChangeToSBC(char)"/>与<see cref="ChangeToSBC(char)"/>的备注信息</remarks>
        /// <example><code>
        /// pString ps = new pString("ABCD1234");
        /// ps = ps.ChangeToSBC();
        /// pString ps2 = new pString("ＡＢＣＤ１２３４");
        /// ps2 = ps2.ChangeToCBC();
        /// /*
        /// ps.StrValue is "ＡＢＣＤ１２３４"
        /// ps2.StrValue is "ABCD1234"
        /// */
        /// </code></example>
        public pString ChangeToCBC()
        {
            string res = stValue;
            for (int i = 0; i < res.Length; i++)
            {
                char tempc = res[i];
                char temp = pString.ChangeToCBC(tempc);
                if (temp != tempc)
                {
                    res = res.Replace(tempc, temp);
                }
            }
            return new pString(res);
        }
        /// <summary>
        /// 有选择的将字符串中的字符替换为全角
        /// </summary>
        /// <param name="str">一个由要替换的字符组成的字符串</param>
        /// <returns>转换后的字符串</returns>
        /// <exception cref="ArgumentNullException">str为空引用（Visual Basic 中为 Nothing）。</exception>
        /// <remarks>该转换是借助于<see cref="ChangeToSBC(char)"/>与<see cref="ChangeToSBC(char)"/>两个静态方法实现的转换的条件请参阅<see cref="ChangeToSBC(char)"/>与<see cref="ChangeToSBC(char)"/>的备注信息</remarks>
        /// <example><code>
        /// pString ps = new pString("ABCD1234");
        /// string str = "A1";
        /// ps = ps.ChangeToSBC(str);
        /// str = "Ａ";
        /// pString ps2 = ps.ChangeToCBC(str);
        /// /*
        /// ps.StrValue is "ＡBCD１234"
        /// ps2.StrValue is "ABCD１234"
        /// */
        /// </code></example>
        public pString ChangeToCBC(string str)
        {
            string res = stValue;
            for (int i = 0; i < res.Length; i++)
            {
                char tempc = res[i];
                if (res.StartsWith(tempc.ToString()))
                {
                    char temp = pString.ChangeToCBC(tempc);
                    if (temp != tempc)
                    {
                        res = res.Replace(tempc, temp);
                    }
                }
            }
            return new pString(res);
        }
        /// <summary>
        /// 将字符串中的字符替换为半角
        /// </summary>
        /// <returns>转换后的字符串</returns>
        /// <remarks>该转换是借助于<see cref="ChangeToSBC(char)"/>与<see cref="ChangeToSBC(char)"/>两个静态方法实现的转换的条件请参阅<see cref="ChangeToSBC(char)"/>与<see cref="ChangeToSBC(char)"/>的备注信息</remarks>
        /// <example><code>
        /// pString ps = new pString("ABCD1234");
        /// ps = ps.ChangeToSBC();
        /// pString ps2 = new pString("ＡＢＣＤ１２３４");
        /// ps2 = ps2.ChangeToCBC();
        /// /*
        /// ps.StrValue is "ＡＢＣＤ１２３４"
        /// ps2.StrValue is "ABCD1234"
        /// */
        /// </code></example>
        public pString ChangeToSBC()
        {
            string res = stValue;
            for (int i = 0; i < res.Length; i++)
            {
                char tempc = res[i];
                char temp = pString.ChangeToSBC(tempc);
                if (temp != tempc)
                {
                    res = res.Replace(tempc, temp);
                }
            }
            return new pString(res);
        }
        /// <summary>
        /// 有选择的将字符串中的字符替换为半角
        /// </summary>
        /// <param name="str">一个由要替换的字符组成的字符串</param>
        /// <returns>转换后的字符串</returns>
        /// <exception cref="ArgumentNullException">str为空引用（Visual Basic 中为 Nothing）。</exception>
        /// <remarks>该转换是借助于<see cref="ChangeToSBC(char)"/>与<see cref="ChangeToSBC(char)"/>两个静态方法实现的转换的条件请参阅<see cref="ChangeToSBC(char)"/>与<see cref="ChangeToSBC(char)"/>的备注信息</remarks>
        /// <example><code>
        /// pString ps = new pString("ABCD1234");
        /// string str = "A1";
        /// ps = ps.ChangeToSBC(str);
        /// str = "Ａ";
        /// pString ps2 = ps.ChangeToCBC(str);
        /// /*
        /// ps.StrValue is "ＡBCD１234"
        /// ps2.StrValue is "ABCD１234"
        /// */
        /// </code></example>
        public pString ChangeToSBC(string str)
        {
            string res = stValue;
            for (int i = 0; i < res.Length; i++)
            {
                char tempc = res[i];
                if (res.IndexOf(tempc.ToString()) != -1)
                {
                    char temp = pString.ChangeToSBC(tempc);
                    if (temp != tempc)
                    {
                        res = res.Replace(tempc, temp);
                    }
                }
            }
            return new pString(res);
        }

        /// <summary>
        /// 将指定字符替换为全角，如果不属于替换范围则返回原字符
        /// </summary>
        /// <param name="c">要替换的字符</param>
        /// <returns>替换后的字符</returns>
        /// <remarks>该方法与<see cref="ChangeToCBC(char)"/>方法只对ASCII码表中值为３３～１２５的字符有效</remarks>
        /// <example>
        /// <code>
        /// char c = 'Ａ';
        /// c = pString.ChangeToSBC(c);
        /// char b = pString.ChangeToCBC(c);
        /// /*
        /// Result:
        /// c is 'A';
        /// b is 'Ａ';
        /// */
        /// </code>
        /// </example>
        public static char ChangeToCBC(char c)
        {
            if (c <= IoFndConst.MaxSBCchar && c >= IoFndConst.MinSBCchar)
                return (char)(c + IoFndConst.CBC_SBC);
            return c;
        }
        /// <summary>
        /// 将指定字符替换为半角，如果不属于替换范围则返回原字符
        /// </summary>
        /// <param name="c">要替换的字符</param>
        /// <returns>替换后的字符</returns>
        /// <remarks>该方法与<see cref="ChangeToCBC(char)"/>方法只对ASCII码表中值为３３～１２５的字符有效</remarks>
        /// <example>
        /// <code>
        /// char c = 'Ａ';
        /// c = pString.ChangeToSBC(c);
        /// char b = pString.ChangeToCBC(c);
        /// /*
        /// Result:
        /// c is 'A';
        /// b is 'Ａ';
        /// */
        /// </code>
        /// </example>
        public static char ChangeToSBC(char c)
        {
            if (c <= IoFndConst.MaxCBCchar && c >= IoFndConst.MinSBCchar)
                return (char)(c - IoFndConst.CBC_SBC);
            return c;
        }
        /// <summary>
        /// 返回指定位置的大写字母
        /// </summary>
        /// <param name="Index">从1开始的字母顺序位置</param>
        /// <returns></returns>
        public static char GetLetter(int Index)
        {
            char c = 'A';
            char m = (char)(c + (Index % 26 - 1));
            return m;
        }
        /// <summary>
        /// 返回指定位置的小写字母
        /// </summary>
        /// <param name="Index">从1开始的字母顺序位置</param>
        /// <returns></returns>
        public static char Getletter(int Index)
        {
            char c = 'a';
            char m = (char)(c + (Index % 26 - 1));
            return m;
        }
        /// <summary>
        /// 返回或设定指定位置上的字符
        /// </summary>
        /// <param name="Index">从0开始的索引</param>
        /// <value>将要替换成的一个字符</value>
        /// <returns>char型的一个字符</returns>
        public char this[int Index]
        {
            get { return stValue[Index]; }
            set
            {
                string temp0 = stValue.Substring(0, Index);
                string temp1 = stValue.Substring(Index + 1, stValue.Length - temp0.Length - 1);
                stValue = temp0 + value + temp1;
            }
        }
        /// <summary>
        /// 从字符串结尾开始获取指定长度的字符串
        /// </summary>
        /// <param name="Count">要获得的字符串长度</param>
        /// <returns>得到的字符串</returns>
        /// <exception cref="ArgumentOutOfRangeException">Count 为负，或大于此字符串的长度。</exception>
        /// <example>
        /// <code>
        /// pString ps = new pString("abc");
        /// ps = ps.LSubString(2);
        /// /*
        /// Result:
        /// ps.StrValue is "bc"
        /// */
        /// </code>
        /// </example>
        public pString LSubString(int Count)
        {
            return new pString(stValue.Substring(stValue.Length - Count, Count));
        }

        /// <summary>
        /// 截取给定索引值左边的指定字符数目的字符串
        /// </summary>
        /// <param name="StartIndex">从0开始的索引值</param>
        /// <param name="Length">要截得的字符串字符数</param>
        /// <returns>截得的字符串</returns>
        /// <exception cref="ArgumentOutOfRangeException">StartIndex小于-1或大于该字符串的最大索引值或者Length小于0</exception>
        /// <remarks>该方法当StartIndex为-1，Length大于0时不会发生异常，返回结果为""。</remarks>
        public pString SubStringL(int StartIndex, int Length)
        {
            if (Length < 0)
                throw new ArgumentOutOfRangeException("Length", "长度不能小于 0。");
            int start = 0;
            int Ct = StartIndex + 1;
            if (Length < StartIndex)
            {
                Ct = Length;
                start = StartIndex - Ct + 1;
            }
            return new pString(stValue.Substring(start, Ct));
        }
        /// <summary>
        /// 截取给定索引值左边的字符串
        /// </summary>
        /// <param name="StartIndex">从0开始的索引值</param>
        /// <returns>截得的字符串</returns>
        /// <remarks>该方法当输入的参数为-1时不会发生异常，返回结果为""。</remarks>
        /// <exception cref="ArgumentOutOfRangeException">当StartIndex小于-1或大于该字符串的最大索引值</exception>
        public pString SubStringL(int StartIndex)
        {
            return new pString(stValue.Substring(0, StartIndex + 1));
        }

        /// <summary>
        /// 从字符串开始位置寻找指定字符串的匹配位置，然后返回该字符串前的字符串，返回结果不包括指定字符串
        /// </summary>
        /// <param name="str">要寻找的指定字符串</param>
        /// <returns>截得的字符串</returns>
        /// <exception cref="ArgumentNullException">str为空引用（Visual Basic 中为 Nothing）。</exception>
        /// <remarks>当找不到指定字符串时会返回<see cref="string.Empty"/></remarks>
        public pString SubStringL(string str)
        {
            return SubStringL(stValue.IndexOf(str)) - 1;
        }
        /// <summary>
        /// 从字符串开始位置寻找指定字符串的匹配位置，然后返回该字符串前的字符串，返回结果包括指定字符串
        /// </summary>
        /// <param name="str">要寻找的指定字符串</param>
        /// <exception cref="ArgumentNullException">str为空引用（Visual Basic 中为 Nothing）。</exception>
        /// <returns>截得的字符串</returns>
        /// <remarks>当找不到指定字符串时会返回指定字符串</remarks>        
        public pString SubStringLS(string str)
        {
            return SubStringL(stValue.IndexOf(str)) - 1 + str;
        }
        /// <summary>
        /// 从字符串开始位置寻找指定字符串的匹配位置，然后返回该字符串后的字符串，返回结果不包括指定字符串
        /// </summary>
        /// <param name="str">要寻找的指定字符串</param>
        /// <exception cref="ArgumentNullException">str为空引用（Visual Basic 中为 Nothing）。</exception>
        /// <returns>截得的字符串</returns>
        /// <remarks>当找不到指定字符串时会返回<see cref="string.Empty"/></remarks>   
        public pString SubStringR(string str)
        {
            int StartIndex = IndexOfNext(str);
            if (StartIndex == -1)
                return new pString(string.Empty);
            return new pString(stValue.Substring(StartIndex));
        }
        /// <summary>
        /// 从字符串开始位置寻找指定字符串的匹配位置，然后返回该字符串后的字符串，返回结果包括指定字符串
        /// </summary>
        /// <param name="str">要寻找的指定字符串</param>
        /// <exception cref="ArgumentNullException">str为空引用（Visual Basic 中为 Nothing）。</exception>
        /// <returns>截得的字符串</returns>
        /// <remarks>当找不到指定字符串时会返回指定字符串</remarks>   
        public pString SubStringRS(string str)
        {
            int StartIndex = stValue.IndexOf(str);
            if (StartIndex == -1)
                return new pString(str);
            return new pString(stValue.Substring(StartIndex));
        }

        /// <summary>
        /// 从字符串末尾位置寻找指定字符串的匹配位置，然后返回该字符串前的字符串，返回结果不包括指定字符串
        /// </summary>
        /// <param name="str">要寻找的指定字符串</param>
        /// <returns>截得的字符串</returns>
        /// <exception cref="ArgumentNullException">str为空引用（Visual Basic 中为 Nothing）。</exception>
        /// <remarks>当找不到指定字符串时会返回<see cref="string.Empty"/></remarks>
        public pString LastSubStringL(string str)
        {
            return SubStringL(stValue.LastIndexOf(str)) - 1;
        }
        /// <summary>
        /// 从字符串末尾位置寻找指定字符串的匹配位置，然后返回该字符串前的字符串，返回结果包括指定字符串
        /// </summary>
        /// <param name="str">要寻找的指定字符串</param>
        /// <exception cref="ArgumentNullException">str为空引用（Visual Basic 中为 Nothing）。</exception>
        /// <returns>截得的字符串</returns>
        /// <remarks>当找不到指定字符串时会返回指定字符串</remarks>     
        public pString LastSubStringLS(string str)
        {
            return SubStringL(stValue.LastIndexOf(str)) - 1 + str;
        }
        /// <summary>
        /// 从字符串末尾位置寻找指定字符串的匹配位置，然后返回该字符串后的字符串，返回结果不包括指定字符串
        /// </summary>
        /// <param name="str">要寻找的指定字符串</param>
        /// <exception cref="ArgumentNullException">str为空引用（Visual Basic 中为 Nothing）。</exception>
        /// <returns>截得的字符串</returns>
        /// <remarks>当找不到指定字符串时会返回<see cref="string.Empty"/></remarks>   
        public pString LastSubStringR(string str)
        {
            int StartIndex = LastIndexOfNext(str);
            if (StartIndex == -1)
                return new pString(string.Empty);
            return new pString(stValue.Substring(StartIndex));
        }
        /// <summary>
        /// 从字符串末尾位置寻找指定字符串的匹配位置，然后返回该字符串后的字符串，返回结果包括指定字符串
        /// </summary>
        /// <param name="str">要寻找的指定字符串</param>
        /// <exception cref="ArgumentNullException">str为空引用（Visual Basic 中为 Nothing）。</exception>
        /// <returns>截得的字符串</returns>
        /// <remarks>当找不到指定字符串时会返回指定字符串</remarks>   
        public pString LastSubStringRS(string str)
        {
            int StartIndex = stValue.LastIndexOf(str);
            if (StartIndex == -1)
                return new pString(str);
            return new pString(stValue.Substring(StartIndex));
        }
        /// <summary>
        /// 返回本实例中所有匹配的数目
        /// </summary>
        /// <param name="c">要查找的字符对象</param>
        /// <returns></returns>
        public int FindChars(char c)
        {
            int res = 0;
            foreach (char ch in stValue.ToCharArray())
            {
                if (c == ch)
                    res++;
            }
            return res;
        }

        /// <summary>
        /// 返回当前字符串的GB2312形式编码
        /// </summary>
        /// <returns></returns>
        public byte[] Get2312Bytes()
        {
            pString temp = new pString(stValue);
            if (temp[this.ChangeOrder(0)] != '\0')
                temp = temp + "\0";
            return en.GetBytes(temp.stValue);
        }
        /// <summary>
        /// 返回以GB2312形式编码字节流的字符串
        /// </summary>
        /// <param name="Data">用GB2312编码的字节流</param>
        /// <remarks>该方法不舍弃结尾的'\0'字符</remarks>
        public void GetpString(byte[] Data)
        {
            if (Data.Length == 0)
                stValue = "";
            stValue = pString.en.GetString(Data);
        }
        /// <summary>
        /// 返回当前字符串的MD5值组成的字符串
        /// </summary>
        /// <returns></returns>
        public string ToMD5()
        {
            byte[] bt = UTF8Encoding.UTF8.GetBytes(stValue);
            MD5CryptoServiceProvider objMD5;
            objMD5 = new MD5CryptoServiceProvider();
            byte[] output = objMD5.ComputeHash(bt);
            return BitConverter.ToString(output);
        }

        /// <summary>
        /// 在数组中查找字符串。返回数组中相同的字符串索引
        /// </summary>
        /// <param name="str">要匹配的字符串</param>
        /// <param name="array">要查询的数组</param>
        /// <param name="IsTrim">是否忽略开始结束的字符</param>
        /// <returns></returns>
        public static int Find(string str, string[] array, bool IsTrim)
        {
            if (array == null)
                return -1;
            for (int i = 0; i < array.Length; i++)
            {
                if (IsTrim)
                {
                    if (str.Trim() == array[i].Trim())
                        return i;
                }
                else
                {
                    if (str == array[i])
                        return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// 在数组中查找字符串。返回数组中相同的字符串索引
        /// </summary>
        /// <param name="str">要匹配的字符串</param>
        /// <param name="array">要查询的数组</param>
        /// <param name="IsTrim">是否忽略开始结束的字符</param>
        /// <returns></returns>
        public static int Find(string str, pString[] array, bool IsTrim)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (IsTrim)
                {
                    if (str.Trim() == array[i].StrValue.Trim())
                        return i;
                }
                else
                {
                    if (str == array[i].StrValue)
                        return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// 在<see cref="DataTable"/>某列中查找字符串。返回相同的字符串索引
        /// </summary>
        /// <param name="str">要匹配的字符串</param>
        /// <param name="dt">数据集</param>
        /// <param name="ColName">列名称</param>
        /// <param name="IsTrim">是否忽略开始结束的字符</param>
        /// <returns></returns>
        public static int Find(string str, DataTable dt, string ColName, bool IsTrim)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (IsTrim)
                {
                    if (str.Trim() == dt.Rows[i][ColName].ToString().Trim())
                        return i;
                }
                else
                {
                    if (str == dt.Rows[i][ColName].ToString())
                        return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// 在<see cref="DataTable"/>某列中查找字符串。返回相同的字符串索引
        /// </summary>
        /// <param name="str">要匹配的字符串</param>
        /// <param name="dt">数据集</param>
        /// <param name="ColIndex">列索引</param>
        /// <param name="IsTrim">是否忽略开始结束的字符</param>
        /// <returns></returns>
        public static int Find(string str, DataTable dt, int ColIndex, bool IsTrim)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (IsTrim)
                {
                    if (str.Trim() == dt.Rows[i][ColIndex].ToString().Trim())
                        return i;
                }
                else
                {
                    if (str == dt.Rows[i][ColIndex].ToString())
                        return i;
                }
            }
            return -1;
        }
        /// <summary>
        /// 在<see cref="StringCollection"/>中查找字符串。返回数组中相同的字符串索引
        /// </summary>
        /// <param name="str">要匹配的字符串</param>
        /// <param name="sts">数据集合</param>
        /// <param name="IsTrim">是否忽略开始结束的字符</param>
        /// <returns></returns>
        public static int Find(string str, StringCollection sts, bool IsTrim)
        {
            if (sts == null)
                return -1;
            for (int i = 0; i < sts.Count; i++)
            {
                if (IsTrim)
                {
                    if (str.Trim() == sts[i].Trim())
                        return i;
                }
                else
                {
                    if (str == sts[i])
                        return i;
                }
            }
            return -1;
        }
        /// <summary>
        /// 比较两个字符串集合中是否含有相同实例
        /// </summary>
        /// <param name="array1"></param>
        /// <param name="array2"></param>
        /// <param name="IsTrim">是否滤去开头结尾的空格</param>
        /// <returns></returns>
        public static bool IsContainEachOther(string[] array1, string[] array2, bool IsTrim)
        {
            ExceptionOpt.IsNull(array1, "array1");
            ExceptionOpt.IsNull(array2, "array2");
            for (int i = 0; i < array1.Length; i++)
            {
                if (Find(array1[i], array2, IsTrim) != -1)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// 比较两个字符串集合中是否含有相同实例
        /// </summary>
        /// <param name="array1"></param>
        /// <param name="array2"></param>
        /// <param name="IsTrim">是否滤去开头结尾的空格</param>
        /// <returns></returns>
        public static bool IsContainEachOther(StringCollection array1, StringCollection array2, bool IsTrim)
        {
            ExceptionOpt.IsNull(array1, "array1");
            ExceptionOpt.IsNull(array2, "array2");
            for (int i = 0; i < array1.Count; i++)
            {
                if (Find(array1[i], array2, IsTrim) != -1)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// 比较两个字符串集合中是否含有相同实例
        /// </summary>
        /// <param name="array1"></param>
        /// <param name="array2"></param>
        /// <param name="IsTrim">是否滤去开头结尾的空格</param>
        /// <returns></returns>
        public static bool IsContainEachOther(string[] array1, StringCollection array2, bool IsTrim)
        {
            ExceptionOpt.IsNull(array1, "array1");
            ExceptionOpt.IsNull(array2, "array2");
            for (int i = 0; i < array1.Length; i++)
            {
                if (Find(array1[i], array2, IsTrim) != -1)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// 是否有包含关系
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="strs">字符串数组</param>
        /// <param name="Istrim">是否去掉开始结束空格</param>
        public static bool IsHave(string str, string[] strs, bool Istrim)
        {
            if (Istrim)
            {
                foreach (string st in strs)
                {
                    if (str.Trim() == st.Trim())
                        return true;
                }
                return false;
            }
            else
            {
                foreach (string st in strs)
                {
                    if (str == st)
                        return true;
                }
                return false;
            }
        }
        /// <summary>
        /// 初始化一个字符串数组
        /// </summary>
        /// <param name="strs">字符串数组</param>
        /// <param name="size">初始的大小</param>
        /// <param name="str">初始值</param>
        public static void SetString(ref string[] strs, int size, string str)
        {
            int imax = 0;
            if (strs == null)
                strs = new string[size];
            imax = strs.Length < size ? strs.Length : size;
            for (int i = 0; i < imax; i++)
                strs[i] = str;
        }
        /// <summary>
        /// 初始化一个字符串2维数组
        /// </summary>
        /// <param name="strs">字符串2维数组</param>
        /// <param name="r">行数</param>
        /// <param name="c">列数</param>
        /// <param name="str">初始值</param>
        public static void SetString(ref string[,] strs, int r, int c, string str)
        {
            if (strs == null)
                strs = new string[r, c];
            int rmax = strs.GetLength(0) < r ? strs.GetLength(0) : r;
            int cmax = strs.GetLength(1) < c ? strs.GetLength(1) : c;
            for (int rs = 0; rs < rmax; rs++)
            {
                for (int cs = 0; cs < cmax; cs++)
                    strs[rs, cs] = str;
            }
        }
    }
}
