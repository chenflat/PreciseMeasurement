using System;
using System.Data;
using System.Collections.Specialized;

namespace PM.Common.ExcelUtils
{

    /// <summary>
    /// CDataTable 的摘要说明。
    /// </summary>
    public class CDataTable
    {
        /// <summary>
        /// 构造一个具有复合表头、列头结构的数据表。
        /// </summary>
        public CDataTable()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            rowHeaders = new HeaderCollection();
            colHeaders = new HeaderCollection();
        }
        private DataTable data;
        /// <summary>
        /// 获取或设置数据，该数据是可以通过多层复合行列的Header中Value属性相与决定的。
        /// </summary>
        public DataTable DataSouce
        {
            set { data = value; }
            get { return data; }
        }
        private string dataValueText;
        /// <summary>
        /// 获取或设置数据的值字段。
        /// </summary>
        public string DataValueText
        {
            get { return dataValueText; }
            set { dataValueText = value; }
        }
        private HeaderCollection rowHeaders;
        /// <summary>
        /// 获取或设置当前的行标题集合
        /// </summary>
        public HeaderCollection RowHeaders
        {
            set { rowHeaders = value; }
            get { return rowHeaders; }
        }
        private HeaderCollection colHeaders;
        /// <summary>
        /// 获取或设置当前的列标题集合
        /// </summary>
        public HeaderCollection ColHeaders
        {
            set { colHeaders = value; }
            get { return colHeaders; }
        }
        //		/// <summary>
        //		/// 根据复合表头得到一个字符串二维数组
        //		/// </summary>
        //		/// <param name="IsRemove">是否采取快速搜索方式</param>
        //		/// <param name="str">当没有数据时采取的默认字符串</param>
        //		/// <param name="Style">执行方式如果为true则是根据多维表格的位置的条件信息搜索数据填充，否则为从数据表中枚举数据然后填到对应位置，此方式只限数据与表格一一对应</param>
        //		/// <returns></returns>
        //		public string[,] GetStringsTable(bool IsRemove,string str,GetCDataTableData Style)
        //		{
        //			try
        //			{
        //				int dataw=ColHeaders.HeadsCount;
        //				int datah=RowHeaders.HeadsCount;
        //				string[,] datas=new string[datah,dataw];
        //				DataTable dtemp=DataSouce.Copy();
        //				switch(Style)
        //				{
        //					case GetCDataTableData.TableToData:
        //						StringCollection[] colvalues=ColHeaders.AllDataCfgs;
        //						StringCollection[] rowvalues=RowHeaders.AllDataCfgs;
        //						if(IsRemove)
        //						{
        //							for(int x=0;x<dataw;x++)
        //							{
        //								for(int y=0;y<datah;y++)
        //								{
        //									try
        //									{
        //										string stmp="";
        //										stmp=pStringSql.GetSqlWhereAnd(colvalues[x]).StrValue;
        //										stmp+=" and ";
        //										stmp+=pStringSql.GetSqlWhereAnd(rowvalues[y]).StrValue;
        //										DataRow dr=dtemp.Select(stmp)[0];
        //										datas[y,x]=dr[IoFndConst.CDataTableValue].ToString().Trim();
        //										dtemp.Rows.Remove(dr);
        //									}
        //									catch(Exception ex)
        //									{
        //										string a=ex.Message;
        //										datas[y,x]=str;
        //									}
        //								}
        //							}
        //						}
        //						else
        //						{
        //							for(int x=0;x<dataw;x++)
        //							{
        //								for(int y=0;y<datah;y++)
        //								{
        //									try
        //									{
        //										string stmp="";
        //										stmp=pStringSql.GetSqlWhereAnd(colvalues[x]).StrValue;
        //										stmp+=" and ";
        //										stmp+=pStringSql.GetSqlWhereAnd(rowvalues[y]).StrValue;
        //										DataRow dr=dtemp.Select(stmp)[0];
        //										datas[y,x]=dr[IoFndConst.CDataTableValue].ToString().Trim();
        //									}
        //									catch
        //									{
        //										datas[y,x]=str;
        //									}
        //								}
        //							}
        //						}
        //						break;
        //					case GetCDataTableData.DataToTable:
        //						//初始化，新建搜索树
        //						tpos=0;
        //						InitHeaders(rowHeaders);
        //						tpos=0;
        //						InitHeaders(colHeaders);
        //						for(int i=0;i<datah;i++)
        //						{
        //							for(int j=0;j<dataw;j++)
        //								datas[i,j]=str;
        //						}
        //
        //						foreach(DataRow dr in dtemp.Rows)
        //						{
        //							try
        //							{
        //								int r=GetRowColIndex(dr,rowHeaders);
        //								if(r==-1)
        //									continue;
        //								int c=GetRowColIndex(dr,colHeaders);
        //								if(c==-1)
        //									continue;
        //								datas[r,c]=dr[IoFndConst.CDataTableValue].ToString();
        //							}
        //							catch{}
        //						}
        //					
        //						ExitHeadersOpt(rowHeaders);
        //						ExitHeadersOpt(colHeaders);
        //						break;
        //				}
        //				return datas;
        //			}
        //			catch(Exception ex)
        //			{
        //				string a=ex.Message;
        //				return null;
        //			}
        //		}
        //		
        /// <summary>
        /// 根据复合表头得到一个<see cref="DataTable"/>二维数组。数组中放置着检索出来的数据
        /// </summary>
        /// <param name="IsRemove">当使用根据表格框架搜索数据的方法时，每次搜索到数据时是否移除以节省时间</param>
        /// <param name="Style">检索数据的方法</param>
        /// <returns></returns>
        public DataTable[,] GetDatasTable(bool IsRemove, GetCDataTableData Style)
        {
            try
            {
                int dataw = ColHeaders.HeadsCount;
                int datah = RowHeaders.HeadsCount;
                DataTable[,] datas = new DataTable[datah, dataw];
                if (DataSouce == null)
                    return datas;
                DataTable dtemp = DataSouce.Copy();
                int icmax = dtemp.Columns.Count;
                switch (Style)
                {
                    case GetCDataTableData.TableToData:
                        StringCollection[] colvalues = ColHeaders.AllDataCfgs;
                        StringCollection[] rowvalues = RowHeaders.AllDataCfgs;
                        if (IsRemove)
                        {
                            for (int x = 0; x < dataw; x++)
                            {
                                for (int y = 0; y < datah; y++)
                                {
                                    datas[y, x] = dtemp.Clone();
                                    try
                                    {
                                        string stmp = "";
                                        stmp = pStringSql.GetSqlWhereAnd(colvalues[x]).StrValue;
                                        stmp += " and ";
                                        stmp += pStringSql.GetSqlWhereAnd(rowvalues[y]).StrValue;
                                        DataRow[] drs = dtemp.Select(stmp);
                                        for (int i = 0; i < drs.Length; i++)
                                        {
                                            DataRow dr = datas[y, x].NewRow();
                                            for (int ic = 0; ic < icmax; ic++)
                                            {
                                                dr[ic] = drs[i][ic];
                                            }
                                            datas[y, x].Rows.Add(dr);
                                            dtemp.Rows.Remove(drs[i]);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        string a = ex.Message;
                                    }
                                }
                            }
                        }
                        else
                        {
                            for (int x = 0; x < dataw; x++)
                            {
                                for (int y = 0; y < datah; y++)
                                {
                                    datas[y, x] = new DataTable();
                                    try
                                    {
                                        string stmp = "";
                                        stmp = pStringSql.GetSqlWhereAnd(colvalues[x]).StrValue;
                                        stmp += " and ";
                                        stmp += pStringSql.GetSqlWhereAnd(rowvalues[y]).StrValue;
                                        DataRow[] drs = dtemp.Select(stmp);
                                        for (int i = 0; i < drs.Length; i++)
                                        {
                                            DataRow dr = datas[y, x].NewRow();
                                            for (int ic = 0; ic < icmax; ic++)
                                            {
                                                dr[ic] = drs[i][ic];
                                            }
                                            datas[y, x].Rows.Add(dr);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        string a = ex.Message;
                                    }
                                }
                            }
                        }
                        break;
                    case GetCDataTableData.DataToTable:
                        //初始化，新建搜索树
                        tpos = 0;
                        InitHeaders(rowHeaders);
                        tpos = 0;
                        InitHeaders(colHeaders);
                        for (int i = 0; i < datah; i++)
                        {
                            for (int j = 0; j < dataw; j++)
                                datas[i, j] = dtemp.Clone();
                        }

                        foreach (DataRow dr in dtemp.Rows)
                        {
                            try
                            {
                                int r = GetRowColIndex(dr, rowHeaders);
                                if (r == -1)
                                    continue;
                                int c = GetRowColIndex(dr, colHeaders);
                                if (c == -1)
                                    continue;
                                DataRow dr0 = datas[r, c].NewRow();
                                for (int ic = 0; ic < icmax; ic++)
                                {
                                    dr0[ic] = dr[ic];
                                }
                                datas[r, c].Rows.Add(dr0);
                            }
                            catch { }
                        }

                        ExitHeadersOpt(rowHeaders);
                        ExitHeadersOpt(colHeaders);
                        break;
                }
                return datas;
            }
            catch (Exception ex)
            {
                string a = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// 根据一个DataRow,找出它在对应的HeaderCollection中的位置。
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="hs"></param>
        /// <returns></returns>
        private int GetRowColIndex(DataRow dr, HeaderCollection hs)
        {
            foreach (string st in ((WorkForHeader)hs.Tag).DataTexts)
            {
                Header h = GetHeader(hs, st, dr[st].ToString().Trim());
                if (h == null)
                    continue;
                if (h.sHeaders.Count == 0)
                    return ((WorkForHeader)h.Tag).Index;
                else
                    return GetRowColIndex(dr, h.sHeaders);
            }
            return -1;
        }


        /// <summary>
        /// 根据DataText和DataValue从HeaderCollection中找出匹配的Header，找不到则返回null。
        /// </summary>
        /// <param name="hs"></param>
        /// <param name="DataText"></param>
        /// <param name="DataValue"></param>
        /// <returns></returns>
        private Header GetHeader(HeaderCollection hs, string DataText, string DataValue)
        {
            for (int i = 0; i < hs.Count; i++)
            {
                if (hs[i].DataText == DataText)
                {
                    if (hs[i].DataValue == DataValue)
                    {
                        return hs[i];
                    }
                }
            }
            return null;
        }
        int tpos = 0;
        /// <summary>
        /// 在进行数据查找前初始化HeaderCollection，完成Header的WorkForHeader结构初始化
        /// </summary>
        /// <param name="hs"></param>
        private void InitHeaders(HeaderCollection hs)
        {
            if (hs.Count == 0)
                return;
            WorkForHeader wh = new WorkForHeader();
            wh.temp = hs.Tag;
            hs.Tag = wh;
            wh.DataTexts.Add(hs[0].DataText);
            InitHeaders(hs[0]);
            for (int i = 1; i < hs.Count; i++)
            {
                if (wh.DataTexts[wh.DataTexts.Count - 1] != hs[i].DataText)
                {
                    wh.DataTexts.Add(hs[i].DataText);
                }
                InitHeaders(hs[i]);
            }
        }
        private void InitHeaders(Header h)
        {
            if (h.sHeaders.Count == 0)
            {
                WorkForHeader wh = new WorkForHeader();
                wh.Index = tpos++;
                wh.temp = h.Tag;
                h.Tag = wh;
            }
            else
            {
                InitHeaders(h.sHeaders);
            }
        }
        /// <summary>
        /// 在进行数据查找后还原HeaderCollection
        /// </summary>
        /// <param name="hs"></param>
        private void ExitHeadersOpt(HeaderCollection hs)
        {
            if (hs.Count > 0)
            {
                hs.Tag = ((WorkForHeader)hs.Tag).temp;
                for (int i = 0; i < hs.Count; i++)
                {
                    EndInitHeadea(hs[i]);
                }
            }
        }
        /// <summary>
        /// 标题还原
        /// </summary>
        /// <param name="h"></param>
        private void EndInitHeadea(Header h)
        {
            if (h.sHeaders.Count == 0)
            {
                h.Tag = ((WorkForHeader)h.Tag).temp;
            }
            else
                ExitHeadersOpt(h.sHeaders);
        }
    }
    /// <summary>
    /// 一个检索从<see cref="CDataTable"/>中的数据方式的枚举
    /// </summary>
    public enum GetCDataTableData
    {
        /// <summary>
        /// 先得到数据在填表
        /// </summary>
        DataToTable,
        /// <summary>
        /// 根据表找数据
        /// </summary>
        TableToData
    }
}
