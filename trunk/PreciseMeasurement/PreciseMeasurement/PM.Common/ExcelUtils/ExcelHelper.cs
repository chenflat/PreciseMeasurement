using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Xml;
using System.IO;
using System.Web;

namespace PM.Common.ExcelUtils
{
    public class ExcelHelper
    {
        #region 关于Excel的操作
        /// <summary>
        /// 将数据保存到Excel中
        /// </summary>
        /// <param name="DT"></param>
        /// <returns></returns>
        public static string GetExcelFileAndToResponse(DataTable DT)
        {
            OExcel OE = new OExcel();
            OE.SetTableText(1, 1, 1, DT, true);
            string filePath = GetExportExcelFileName();
            OE.SaveAs(filePath, false, true);
            OE.Release();
            ExecExportFile(filePath);
            try
            {
                System.IO.File.Delete(filePath);

            }
            catch (Exception)
            {

            }
            return filePath;
        }
        /// <summary>
        /// 将标题，数据源保存到Excel中
        /// </summary>
        /// <param name="DT">数据源</param>
        /// <param name="TableTitle">标题</param>
        /// <returns></returns>
        public static string GetExcelFileAndToResponse(DataTable DT, string TableTitle)
        {
            OExcel OE = new OExcel();
            OE.SetTableText(1, 2, 1, DT, TableTitle.ToString(), true);
            string filePath = GetExportExcelFileName();
            OE.SaveAs(filePath, false, true);
            OE.Release();
            ExecExportFile(filePath);
            try
            {
                System.IO.File.Delete(filePath);
            }
            catch (Exception)
            {

            }
            return filePath;
        }
        /// <summary>
        /// 将主单标题，主单，明细单（sheet2)导出到Excel
        /// </summary>
        /// <param name="DTMain">主单数据源</param>
        /// <param name="DTDetail">明细数据源</param>
        /// <param name="TableTitle">主单标题</param>
        /// <returns></returns>
        public static string GetExcelFileAndToResponse(DataTable DTMain, DataTable DTDetail, string TableTitle)
        {
            OExcel OE = new OExcel();
            OE.SetTableText(1, 2, 1, DTMain, TableTitle.ToString(), true);
            OE.SetTableText(2, 1, 1, DTDetail, true);
            string filePath = GetExportExcelFileName();
            OE.SaveAs(filePath, false, true);
            OE.Release();
            ExecExportFile(filePath);
            try
            {
                System.IO.File.Delete(filePath);

            }
            catch (Exception)
            {

            }
            return filePath;
        }
        /// <summary>
        /// 返回Excel文件的路径和名称
        /// </summary>
        /// <param name="strFileName">文件名</param>
        private static string GetExportExcelFileName()
        {
            string strFile = Guid.NewGuid().ToString();

            string path = HttpContext.Current.Request.PhysicalApplicationPath;
            path += @"TempFile\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path + strFile + ".xls";

        }
        private static void ExecExportFile(string filePath)
        {
            FileStream MyFileStream;
            long FileSize;

            MyFileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            FileSize = MyFileStream.Length;

            byte[] Buffer = new byte[(int)FileSize];
            MyFileStream.Read(Buffer, 0, (int)FileSize);
            MyFileStream.Close();

            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + filePath);
            HttpContext.Current.Response.ContentType = "application/octet-stream";

            HttpContext.Current.Response.BinaryWrite(Buffer);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.Close();
        }
        /// <summary>
        /// 通过XML文件过滤数据源Table
        /// </summary>
        /// <param name="dtSource">数据源Table</param>
        /// <param name="sFinderName">过滤名称</param>
        /// <param name="xmlFile">Xml文件的物理地址</param>
        /// <returns></returns>
        public static DataTable GetToExcelTable(DataTable dtSource, string sFinderName, string xmlFile)
        {
            DataTable dt = new DataTable(); //整理后，返回的DataTable    
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFile);
            if (doc == null)
            {
                return dtSource;
            }
            try
            {
                for (int i = 0; i < doc.ChildNodes.Count; i++)  //xml节点
                {
                    XmlNode oNode = doc.ChildNodes.Item(i);
                    if (!oNode.LocalName.ToLower().Equals("root"))  //根节点返回
                    {
                        continue;
                    }
                    for (int j = 0; j < oNode.ChildNodes.Count; j++)
                    {
                       // string sCaption = "";
                        if (oNode.ChildNodes[j].Attributes["id"].Value.ToLower().Equals(sFinderName.ToLower())) //判断是否是过滤的信息
                        {  //确定
                            XmlNodeList nodeList = oNode.ChildNodes[j].ChildNodes;
                            ////安xml顺序数据中显示
                            foreach (XmlNode xn in nodeList)
                            {
                                dt.Columns.Add(xn.Attributes["Caption"].Value.ToString());
                            }
                            for (int iRow = 0; iRow < dtSource.Rows.Count; iRow++)
                            {
                                DataRow dr = dt.NewRow();
                                for (int iCol = 0; iCol < dt.Columns.Count; iCol++)
                                {
                                    string sColName = GetColNameFromXmlNode(nodeList, dt.Columns[iCol].ColumnName.ToString());
                                    if (sColName.Length > 0)
                                    {
                                        dr[iCol] = dtSource.Rows[iRow][sColName].ToString();
                                    }
                                }
                                dt.Rows.Add(dr);
                            }

                            dt.AcceptChanges();

                            return dt;

                        }
                    }
                }
            }
            catch (Exception)
            {
               // throw;
                return null;
            }
            return dt;
        }
        private static string GetColNameFromXmlNode(XmlNodeList objNode, string sCaption)
        {
            foreach (XmlNode xn in objNode)
            {
                if (xn.Attributes["Caption"].Value.ToLower().Equals(sCaption.ToLower()))
                {
                    return xn.Attributes["ColName"].Value.ToString();
                }
            }
            return "";
        }

        public static void CreateExcel(DataTable dt) {
            CreateExcel(dt, "");
        }

        /// <summary>
        /// 生成Excel文件
        /// </summary>
        /// <param name="ds">数据集</param>
        /// <param name="fileName">生成文件名</param>
        public static void CreateExcel(DataTable dt,string fileName)
        {
            if(fileName=="")
                fileName = "ExcelFile.xls";

            HttpResponse resp;
            resp = HttpContext.Current.Response;
            resp.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            resp.AppendHeader("Content-Disposition", "attachment;filename=" + fileName);
            //resp.ContentType = "application/vnd.ms-excel";
            resp.ContentType = "application/x-msexcel";
            //Response.ContentType = "application/vnd.ms-excel"; 
            string colHeaders = "", ls_item = "";

            ////定义表对象与行对象，同时用DataSet对其值进行初始化
            //DataTable dt = ds.Tables[0];
            DataRow[] myRow = dt.Select();//可以类似dt.Select("id>10")之形式达到数据筛选目的
            int i = 0;
            int cl = dt.Columns.Count;

            //取得数据表各列标题，各标题之间以t分割，最后一个列标题后加回车符
            for (i = 0; i < cl; i++)
            {
                colHeaders += Utils.FilterString(dt.Columns[i].Caption.ToString().ToLower().Trim());    //去掉换行和换列符号
                if (i == (cl - 1))//最后一列，加n
                {
                    colHeaders += "\n";
                }
                else
                {
                    colHeaders += "\t";
                }

            }
            resp.Write(colHeaders);
            //向HTTP输出流中写入取得的数据信息

            //逐行处理数据 
            foreach (DataRow row in myRow)
            {
                //当前行数据写入HTTP输出流，并且置空ls_item以便下行数据   
                for (i = 0; i < cl; i++)
                {
                    ls_item += Utils.FilterString(row[i].ToString().ToLower().Trim());    //去掉换行和换列符号
                    if (i == (cl - 1))//最后一列，加n
                    {
                        ls_item += "\n";
                    }
                    else
                    {
                        ls_item += "\t";
                    }

                }
                resp.Write(ls_item);
                ls_item = "";

            }
            resp.End();
        }
        public static void CreateExcelFile(DataTable dt)
        {
            string strPathFile = "excelFile.xls";
            StringWriter sw = new StringWriter();
            //构建表头
            string strTmp = string.Empty;
            for (int ihead = 0; ihead < dt.Columns.Count; ihead++)
            {
                strTmp += Utils.FilterString(dt.Columns[ihead].Caption.Trim());
                if (ihead < dt.Columns.Count - 1)
                {   //换行
                    strTmp += "\t";
                }
            }
            sw.WriteLine(strTmp);
            //表内容
            for (int iRow = 0; iRow < dt.Rows.Count; iRow++)
            {
                strTmp = string.Empty;
                for (int icol = 0; icol < dt.Columns.Count; icol++)
                {
                    strTmp += Utils.FilterString(dt.Rows[iRow][icol].ToString());
                    if (icol < dt.Columns.Count - 1)
                    {
                        strTmp += "\t";
                    }
                }
                sw.WriteLine(strTmp);
            }

            sw.Close();
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + strPathFile);

            //HttpContext.Current.Response.ContentType = "application/ms-excel";
            HttpContext.Current.Response.ContentType = "application/x-msexcel";
            //HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            HttpContext.Current.Response.Write(sw);
            HttpContext.Current.Response.End();
        }
        #endregion
    }
}
