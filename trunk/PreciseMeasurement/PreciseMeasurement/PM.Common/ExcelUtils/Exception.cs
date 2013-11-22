using System;
using System.Data;

namespace PM.Common.ExcelUtils
{
    /// <summary>
    /// 异常判断函数
    /// </summary>
    public class ExceptionOpt
    {
        /// <summary>
        /// 判断某个变量是否为null，是则引发<see cref="ArgumentNullException"/>异常
        /// </summary>
        /// <param name="param">参数</param>
        /// <param name="pname">参数名</param>
        public static void IsNull(object param, string pname)
        {
            if (param == null)
                throw new ArgumentNullException(pname, "参数不能为空引用（Visual Basic 中为 Nothing）");
        }
    }
    /// <summary>
    /// 当类的数据成员为空引用（Visual Basic 中为 Nothing）时，试图执行与这个成员相关的方法时引发的异常。
    /// </summary>
    internal class DataNullException : Exception
    {
        /// <summary>
        /// 初始化YXKJ.Common.IOFnd.DataNullException类的新实例
        /// </summary>
        internal DataNullException()
        {
        }
        /// <summary>
        /// 使用错误信息来初始化YXKJ.Common.IOFnd.DataNullException类的新实例
        /// </summary>
        /// <param name="message"></param>
        internal DataNullException(string message)
            : base(message)
        {

        }

        internal static void DataNullExceptionCheck(object opt, string optname)
        {
            if (opt == null)
                throw new DataNullException(optname + "对象为null，访问失败。");
        }
    }
    /// <summary>
    /// 数据结构错误异常
    /// </summary>
    /// <remarks>当使用系统提供的方法对数据库实施操作时，如果提供的数据结构不正确则引发的异常</remarks>
    internal class DataStructErrorException : Exception
    {
        /// <summary>
        /// 以异常消息初始化异常实例
        /// </summary>
        /// <param name="message"></param>
        internal DataStructErrorException(string message)
            : base(message)
        { }
        /// <summary>
        /// </summary>
        /// <param name="dr"></param>
        internal static void TestData(DataRow dr)
        {
            ExceptionOpt.IsNull(dr, "dr");
            if ((dr.Table.TableName == "") || (dr.Table.Columns.Count <= 0))
            {
                throw new DataStructErrorException("输入的DataRow对象不包含列，或者没有表名");
            }
        }
    }
    /// <summary>
    /// 数据库操作执行错误异常
    /// </summary>
    internal class ExecuteErrorException : Exception
    {
        /// <summary>
        /// 以异常消息初始化异常实例
        /// </summary>
        /// <param name="message"></param>
        internal ExecuteErrorException(string message)
            : base(message)
        { }
    }
    /// <summary>
    /// 插入重复键值异常
    /// </summary>
    internal class HaveSameKeyException : Exception
    {
        /// <summary>
        /// 以异常消息初始化异常实例
        /// </summary>
        /// <param name="message"></param>
        internal HaveSameKeyException(string message)
            : base(message)
        { }
    }
    /// <summary>
    /// 构造数据库表时,不存在键引发的异常
    /// </summary>
    internal class NoKeyException : Exception
    {
        /// <summary>
        /// 以异常消息初始化异常实例
        /// </summary>
        /// <param name="message"></param>
        internal NoKeyException(string message)
            : base(message)
        { }
    }
    internal class DataFieldException : Exception
    {
        /// <summary>
        /// 以异常消息初始化异常实例
        /// </summary>
        /// <param name="message"></param>
        internal DataFieldException(string message)
            : base(message)
        { }
        /// <summary>
        /// 是否包含字段
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="fields"></param>
        internal static void IsAllHaveField(DataTable dt, string[] fields)
        {
            foreach (string str in fields)
            {
                if (!dt.Columns.Contains(str))
                    throw new DataFieldException("找不到指定的列：" + str);
            }
        }
        /// <summary>
        /// 关联键中包含非值类型字段
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="keys"></param>
        internal static void ContainObjectExp(DataTable dt, string[] keys)
        {
            foreach (string st in keys)
            {
                if (dt.Columns[st].DataType == typeof(string))
                    continue;
                if (!dt.Columns[st].DataType.IsValueType)
                    throw new DataFieldException("键字段中包含非值类型：" + st);
            }
        }
    }
}
