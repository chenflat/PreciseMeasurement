using System;
using System.Collections;
using System.Text;

namespace PM.Common.ExcelUtils
{

    /// <summary>
    /// 提供创建pString链表的类
    /// </summary>
    public class pStringCollection : CollectionBase
    {
        /// <summary>
        /// 将字符串添加到<see cref="pStringCollection"/>表的结尾处。
        /// </summary>
        /// <param name="value">要添加到<see cref="pStringCollection"/>的末尾处的字符串<see cref="pString"/>类型。</param>
        /// <returns>索引，已在此处添加了 value。</returns>
        public int Add(pString value)
        {
            return List.Add(value);
        }
        /// <summary>
        /// 将字符串添加到<see cref="pStringCollection"/>表的结尾处。
        /// </summary>
        /// <param name="value">要添加到<see cref="pStringCollection"/>的末尾处的字符串<see cref="string"/>类型。</param>
        /// <returns>索引，已在此处添加了 value。</returns>
        public int Addstr(string value)
        {
            return this.Add(new pString(value));
        }
        /// <summary>
        /// 获取或设定指定索引位置的<see cref="pString"/>型对象
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException">index 大于或等于该对象的长度或小于零。</exception>
        public pString this[int index]
        {
            get
            {
                try
                {
                    if (Type.GetTypeCode(List[index].GetType()) == TypeCode.String)
                        return new pString(List[index].ToString());
                    return (pString)List[index];
                }
                catch
                {
                    throw new Exception("索引出的类型不匹配，请确定通过Add方法或AddRange方法插入的数据项为pString或string类对象");
                }
            }
            set
            {
                List[index] = value;
            }
        }
        /// <summary>
        /// 将元素复制到新数组中
        /// </summary>
        /// <returns><see cref="pString"/>组成的数组</returns>
        public pString[] ToArray()
        {
            pString[] res = new pString[List.Count];
            List.CopyTo(res, 0);
            return res;
        }
    }
}
