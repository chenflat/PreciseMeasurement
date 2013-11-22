using System;
using System.Text;
using System.Data;
using System.Collections.Specialized;

namespace PM.Common.ExcelUtils
{
    /// <summary>
    /// 用于拼写常用简单Sql语句的类。该类仅支持简单的数据格式。对复杂的数据格式或试图插入空将会出现错误甚至产生异常。
    /// </summary>
    public class pStringSql
    {
        private int sqlSize;
        /// <summary>
        /// 获取或设置Sql语句的最大长度限制
        /// </summary>
        /// <remarks>该数值决定了用此类的某些方法返回的sql语句的最大长度限制，如果语句的字符数超过此最大值，该语句将被拆分为多条语句</remarks>
        public int SqlSize
        {
            get { return sqlSize; }
            set { sqlSize = value; }
        }
        /// <summary>
        /// 构造一个实例对象，并指定Sql的最大长度限制
        /// </summary>
        /// <param name="SqlSize">Sql语句的最大长度限制</param>
        public pStringSql(int SqlSize)
        {
            sqlSize = SqlSize;
        }
        /// <summary>
        /// 构造一个实例对象，并指定默认的Sql的最大长度限制（１０２４）
        /// </summary>
        public pStringSql()
        {
            sqlSize = 1024;
        }

        /// <summary>
        /// 设计一个用于将<see cref="DataSet"/>类对象插入数据库的Sql语句。
        /// </summary>
        /// <param name="dataSet">要插入的<see cref="DataSet"/>对象</param>
        /// <returns>Sql语句组</returns>
        public pString[] InsertDataSet(DataSet dataSet)
        {
            pStringCollection pslst = new pStringCollection();
            foreach (DataTable Dt in dataSet.Tables)
            {
                string[] temp = InsertDataTableS(Dt);
                if (temp == null || temp.Length == 0)
                    continue;
                if (pslst.Count > 0)
                {
                    for (int i = 0; i < temp.Length; i++)
                    {
                        pString pstemp = pslst[pslst.Count - 1];
                        if (pstemp.StrValue.Length + temp[i].Length <= sqlSize)
                        {
                            pslst[pslst.Count - 1] = pslst[pslst.Count - 1] + temp[i];
                        }
                        else
                        {
                            pslst.Addstr(temp[i]);
                        }
                    }
                }
                else
                {
                    if (temp.Length == 1)
                    {
                        pslst.Addstr(temp[0]);
                    }
                    else
                    {
                        pslst.Addstr(temp[0]);
                        for (int i = 1; i < temp.Length; i++)
                        {
                            pString pstemp = pslst[pslst.Count - 1];
                            if (pstemp.StrValue.Length + temp[i].Length <= sqlSize)
                            {
                                pslst[pslst.Count - 1] = pslst[pslst.Count - 1] + temp[i];
                            }
                            else
                            {
                                pslst.Addstr(temp[i]);
                            }
                        }
                    }
                }
            }
            return pslst.ToArray();
        }
        /// <summary>
        /// 设计一个用于将<see cref="DataTable"/>类对象插入数据库的Sql语句。
        /// </summary>
        /// <param name="dataTable">要插入的<see cref="DataTable"/>对象</param>
        /// <returns>Sql语句组</returns>
        public pString[] InsertDataTable(DataTable dataTable)
        {
            pStringCollection pslst = new pStringCollection();
            pString ps = new pString();
            pString pTemp = new pString();
            foreach (DataRow Dr in dataTable.Rows)
            {
                pString pTemp0 = InsertDataRow(Dr);
                if (pTemp.StrValue.Length + pTemp0.StrValue.Length > sqlSize)
                {
                    pslst.Add(pTemp);
                    pTemp = pTemp0;
                }
                else
                    pTemp = pTemp + pTemp0;
            }
            pslst.Add(pTemp);
            return pslst.ToArray();
        }
        private string[] InsertDataTableS(DataTable dataTable)
        {
            string[] Sqls = new string[dataTable.Rows.Count];
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Sqls[i] = InsertDataRow(dataTable.Rows[i]).StrValue;
            }
            return Sqls;
        }


        /// <summary>
        /// 设计一个用于将<see cref="DataRow"/>类对象插入数据库的Sql语句。
        /// </summary>
        /// <param name="dataRow">要插入的<see cref="DataRow"/>对象</param>
        /// <returns>Sql语句组</returns>
        public pString InsertDataRow(DataRow dataRow)
        {
            if (dataRow.Table.Columns.Count == 0)
                return new pString("");

            pString pTemp = new pString();
            for (int i = 0; i < dataRow.Table.Columns.Count; i++)
            {
                pTemp = pTemp + dataRow.Table.Columns[i].Caption + ",";
            }
            pTemp--;
            pString pSql = ("Insert Into " + dataRow.Table.TableName + "(" + pTemp + ")");
            pTemp = new pString("");
            for (int i = 0; i < dataRow.Table.Columns.Count; i++)
            {
                pTemp = pTemp + "'" + dataRow[i].ToString() + "',";
            }
            pTemp--;
            pSql = pSql + "values(" + pTemp + ");";
            return pSql;
        }
        /// <summary>
        /// 获得一条删除数据的sql语句
        /// </summary>
        /// <param name="dataRow"></param>
        /// <returns></returns>
        public pString DeleteDataRow(DataRow dataRow)
        {
            if (dataRow.Table.Columns.Count == 0)
                return new pString("");

            pString pTemp = new pString(" where ");
            for (int i = 0; i < dataRow.Table.Columns.Count; i++)
            {
                string str = "";
                if (dataRow[i].GetType().FullName == "System.DateTime")
                    str = dataRow[i].ToString().Replace("T", " ").Trim();
                else
                    str = dataRow[i].ToString().Trim();
                pTemp = pTemp + dataRow.Table.Columns[i].Caption + "='" + str + "'and ";
            }
            pTemp = pTemp - 4;
            pString pSql = ("delete from [" + dataRow.Table.TableName + "]" + pTemp);
            return pSql;
        }
        /// <summary>
        /// 返回一个用于删除表中数据的Sql语句
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public pString DelDataTable(DataTable dataTable)
        {
            pString pSql = new pString("delete from [" + dataTable.TableName + "]");
            return pSql;
        }

        /// <summary>
        /// 返回一个用于表示In条件的Sql语句条件字符串
        /// </summary>
        /// <param name="pSlst">In条件中的值集合</param>
        /// <param name="IsStr">值是否应以字带单引号的字符串形式表示</param>
        /// <returns></returns>
        public static pString GetSqlWhereIn(pStringCollection pSlst, bool IsStr)
        {
            pString pRes = new pString();
            foreach (pString ps in pSlst)
            {
                if (IsStr)
                {
                    pRes = pRes + ("'" + ps + "',");
                }
                else
                {
                    pRes = pRes + (ps + ",");
                }
            }
            if (pSlst.Count > 0)
                pRes--;
            return " in (" + pRes + ")";
        }
        /// <summary>
        /// 返回一个用于表示In条件的Sql语句条件字符串。例如 in('a','b','c')
        /// </summary>
        /// <param name="pSArray">In条件中的值集合</param>
        /// <param name="IsStr">值是否应以字带单引号的字符串形式表示</param>
        /// <returns></returns>
        public static pString GetSqlWhereIn(pString[] pSArray, bool IsStr)
        {
            pString pRes = new pString();
            foreach (pString ps in pSArray)
            {
                if (IsStr)
                {
                    pRes = pRes + ("'" + ps + "',");
                }
                else
                {
                    pRes = pRes + (ps + ",");
                }
            }
            if (pSArray.Length > 0)
                pRes--;
            return " in (" + pRes + ")";
        }
        /// <summary>
        /// 返回一个用于表示In条件的Sql语句条件字符串
        /// </summary>
        /// <param name="StrArray">In条件中的值集合</param>
        /// <param name="IsStr">值是否应以字带单引号的字符串形式表示</param>
        /// <returns></returns>
        public static pString GetSqlWhereIn(string[] StrArray, bool IsStr)
        {
            string pRes = "";
            foreach (string ps in StrArray)
            {
                if (IsStr)
                {
                    pRes = pRes + ("'" + ps + "',");
                }
                else
                {
                    pRes = pRes + (ps + ",");
                }
            }
            if (StrArray.Length > 0)
                pRes = pRes.Substring(0, pRes.Length - 1);
            return new pString(" in (" + pRes + ")");
        }
        /// <summary>
        /// 返回一个用于表示In条件的Sql语句条件字符串
        /// </summary>
        /// <param name="StrArray">In条件中的值集合</param>
        /// <param name="IsStr">值是否应以字带单引号的字符串形式表示</param>
        /// <returns></returns>
        public static pString GetSqlWhereIn(string[,] StrArray, bool IsStr)
        {
            string pRes = "";
            for (int i = 0; i < StrArray.GetLength(0); i++)
            {
                for (int j = 0; j < StrArray.GetLength(1); j++)
                {
                    if (IsStr)
                    {
                        pRes = pRes + ("'" + StrArray[i, j] + "',");
                    }
                    else
                    {
                        pRes = pRes + (StrArray[i, j] + ",");
                    }
                }
            }
            if (StrArray.Length > 0)
                pRes = pRes.Substring(0, pRes.Length - 1);
            return new pString(" in (" + pRes + ")");
        }
        /// <summary>
        /// 返回一个用于表示In条件的Sql语句条件字符串
        /// </summary>
        /// <param name="StrArray">In条件中的值集合</param>
        /// <param name="IsStr">值是否应以字带单引号的字符串形式表示</param>
        /// <returns></returns>
        public static pString GetSqlWhereIn(StringCollection StrArray, bool IsStr)
        {
            pString pRes = new pString();
            foreach (string ps in StrArray)
            {
                if (IsStr)
                {
                    pRes = pRes + ("'" + ps + "',");
                }
                else
                {
                    pRes = pRes + (ps + ",");
                }
            }
            if (StrArray.Count > 0)
                pRes--;
            return " in (" + pRes + ")";
        }
        /// <summary>
        /// 返回一个用于执行Select操作的不完整sql语句，该语句只包含字段名。
        /// </summary>
        /// <param name="pSlst">要获得的字段名集合</param>
        /// <param name="pSlstAs">字段别名集合</param>
        /// <returns><see cref="pString"/>型返回值</returns>
        public static pString GetSqlSelects(pStringCollection pSlst, pStringCollection pSlstAs)
        {
            pString pRes = new pString();
            if (pSlstAs == null)
            {
                foreach (pString ps in pSlst)
                {
                    pRes = pRes + (ps + ",");
                }
            }
            else
            {
                for (int i = 0; i < pSlst.Count; i++)
                {
                    pRes = pRes + (pSlst[i] + " AS " + pSlstAs[i] + ",");
                }
            }
            pRes--;
            return " select " + pRes;
        }
        /// <summary>
        /// 返回一个用于执行Select操作的不完整sql语句，该语句只包含字段名。
        /// </summary>
        /// <param name="pSArray">要获得的字段名集合</param>
        /// <param name="pSArrayAs">字段别名集合</param>
        /// <returns><see cref="pString"/>型返回值</returns>
        public static pString GetSqlSelects(pString[] pSArray, pString[] pSArrayAs)
        {
            pString pRes = new pString();
            if (pSArrayAs == null)
            {
                foreach (pString ps in pSArray)
                {
                    pRes = pRes + (ps + ",");
                }
            }
            else
            {
                for (int i = 0; i < pSArray.Length; i++)
                {
                    pRes = pRes + (pSArray[i] + " AS " + pSArrayAs[i] + ",");
                }
            }
            pRes--;
            return " select " + pRes;
        }
        /// <summary>
        /// 返回一个用于执行Select操作的不完整sql语句，该语句只包含字段名。
        /// </summary>
        /// <param name="StrArray">要获得的字段名集合</param>
        /// <param name="StrArrayAs">字段别名集合</param>
        /// <returns><see cref="pString"/>型返回值</returns>
        public static pString GetSqlSelects(string[] StrArray, string[] StrArrayAs)
        {
            pString pRes = new pString();
            if (StrArrayAs == null)
            {
                foreach (string ps in StrArray)
                {
                    pRes = pRes + (ps + ",");
                }
            }
            else
            {
                for (int i = 0; i < StrArray.Length; i++)
                {
                    pRes = pRes + (StrArray[i] + " AS " + StrArrayAs[i] + ",");
                }
            }
            pRes--;
            return " select " + pRes;
        }
        /// <summary>
        /// 返回一个用于执行Select操作的不完整sql语句，该语句只包含字段名。
        /// </summary>
        /// <param name="StrArray">要获得的字段名集合</param>
        /// <param name="StrArrayAs">字段别名集合</param>
        /// <returns><see cref="pString"/>型返回值</returns>
        public static pString GetSqlSelects(StringCollection StrArray, StringCollection StrArrayAs)
        {
            pString pRes = new pString();
            if (StrArrayAs == null)
            {
                foreach (string ps in StrArray)
                {
                    pRes = pRes + (ps + ",");
                }
            }
            else
            {
                for (int i = 0; i < StrArray.Count; i++)
                {
                    pRes = pRes + (StrArray[i] + " AS " + StrArrayAs[i] + ",");
                }
            }
            pRes--;
            return " select " + pRes;
        }

        /// <summary>
        /// 返回一个用于表示and条件的Sql语句条件字符串
        /// </summary>
        /// <param name="sts">条件语句集合，例如像"strUserName='admin'"的条件选择语句组成的集合</param>
        /// <returns></returns>
        public static pString GetSqlWhereAnd(StringCollection sts)
        {
            pString ps = new pString();
            foreach (string st in sts)
            {
                if (st.Trim() != "")
                    ps += (st + " and ");
            }
            ps -= 5;
            return ps;
        }

        string AutoSqlvalue = "";

        /// <summary>
        /// 用于生成简单sql语句或sql查询条件操作的初始化工作。
        /// </summary>
        public void SqlReset()
        {
            AutoSqlvalue = "";
        }
        /// <summary>
        /// 用于将and条件语句添加到某sql语句
        /// </summary>
        /// <param name="str">条件语句，例如" strUserName='admin' "</param>
        /// <remarks>在首次调用此方法前必须必须先执行<see cref="SqlReset"/>方法，而且该方法只能支持含有一个where关键字的语句</remarks>
        public void AddAndSql(string str)
        {
            if (AutoSqlvalue.Length > 0)
                AutoSqlvalue += " and " + str;
            else
                AutoSqlvalue += str;
        }
        /// <summary>
        /// 用于将or条件语句添加到某sql语句
        /// </summary>
        /// <param name="str">条件语句，例如" strUserName='admin' "</param>
        /// <remarks>在首次调用此方法前必须必须先执行<see cref="SqlReset"/>方法，而且该方法只能支持含有一个where关键字的语句</remarks>
        public void AddOrSql(string str)
        {
            if (AutoSqlvalue.Length > 0)
                AutoSqlvalue += " or " + str;
            else
                AutoSqlvalue += str;
        }
        /// <summary>
        /// 通过字符串拼接形式，自动生成一条Sql条件语句
        /// </summary>
        /// <param name="IsReset">生成结束后是否执行SqlReset操作</param>
        /// <returns>pString型返回值</returns>
        public pString ToSql(bool IsReset)
        {
            pString ps = new pString(AutoSqlvalue);
            if (IsReset)
                AutoSqlvalue = "";
            return ps;
        }


    }
}
