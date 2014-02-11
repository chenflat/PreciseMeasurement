using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Xml;
using System.IO;
using System.Web;
using Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Runtime.InteropServices;



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
        public static string GetExcelFileAndToResponse(System.Data.DataTable DT)
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
        public static string GetExcelFileAndToResponse(System.Data.DataTable DT, string TableTitle)
        {
            OExcel OE = new OExcel();
            OE.SetTableText(1, 2, 1, DT, TableTitle.ToString(), true);
            string filePath = GetExportExcelFileName();
            OE.SaveAs(filePath, false);
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
        public static string GetExcelFileAndToResponse(System.Data.DataTable DTMain, System.Data.DataTable DTDetail, string TableTitle)
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
        private static void ExecExportFile(string filePath,string fileName)
        {
            FileStream MyFileStream;
            long FileSize;

            MyFileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            FileSize = MyFileStream.Length;

            byte[] Buffer = new byte[(int)FileSize];
            MyFileStream.Read(Buffer, 0, (int)FileSize);
            MyFileStream.Close();


            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
           // HttpContext.Current.Response.ContentType = "application/octet-stream";
            HttpContext.Current.Response.ContentType = "application/x-msexcel";

            HttpContext.Current.Response.BinaryWrite(Buffer);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.Close();
        }

        private static void ExecExportFile(string filePath)
        {
            ExecExportFile(filePath, filePath);
        }


        /// <summary>
        /// 通过XML文件过滤数据源Table
        /// </summary>
        /// <param name="dtSource">数据源Table</param>
        /// <param name="sFinderName">过滤名称</param>
        /// <param name="xmlFile">Xml文件的物理地址</param>
        /// <returns></returns>
        public static System.Data.DataTable GetToExcelTable(System.Data.DataTable dtSource, string sFinderName, string xmlFile)
        {
            System.Data.DataTable dt = new System.Data.DataTable(); //整理后，返回的DataTable    
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

        public static void CreateExcel(System.Data.DataTable dt) {
            CreateExcel(dt, "","",0);
        }

        public static void CreateExcel(System.Data.DataTable dt, string fileName) {
            CreateExcel(dt, "","",0);
        }

        /// <summary>
        /// 生成Excel文件
        /// </summary>
        /// <param name="ds">数据集</param>
        /// <param name="fileName">生成文件名</param>
        public static void CreateExcel(System.Data.DataTable dt,string fileName,string docTitle,int width)
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
        public static void CreateExcelFile(System.Data.DataTable dt)
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

        /// <summary>
        /// 创建Excel报表文件
        /// </summary>
        /// <param name="table"></param>
        /// <param name="fileName">文件名称</param>
        /// <param name="date">统计月日期</param>
        /// <param name="docTitile">文档标题</param>
        /// <param name="reportType">报表类型</param>
        public static void CreateReportExcelFile(System.Data.DataTable table, string fileName,DateTime date,string docTitile,string reportType) {

            string exportFileName = string.Format("{0}_{1}.xls", fileName , DateTime.Now.ToString("yyyyMMddHHmmss"));

            //保存到文件夹
            HttpContext context = HttpContext.Current;
            string filePath = context.Server.MapPath("~/ExcelFile/");
            if (!System.IO.Directory.Exists(filePath))
                System.IO.Directory.CreateDirectory(filePath);

            if (fileName == "")
                fileName = filePath = "ExcelFile.xls";
            else
                fileName = filePath + fileName + ".xls";

            if (System.IO.File.Exists(fileName))
                System.IO.File.Delete(fileName);


            //定义表头数据
            System.Data.DataTable headTable = new System.Data.DataTable();
            headTable.Columns.Add("CAPTION");

            DataRow workRow;
            for (int ihead = 0; ihead < table.Columns.Count; ihead++) {
                workRow = headTable.NewRow();
                workRow[0] = Utils.FilterString(table.Columns[ihead].Caption.Trim());
                headTable.Rows.Add(workRow);
            }

            //当月天数
            int days = 0;
            string format = "", format2 = "",colSuffix = "";
            if (reportType == "DAY") {
                days = DateTime.DaysInMonth(date.Year, date.Month);
                format = "yyyy年MM月";
                format2 = "yyyy-MM";
            } else if (reportType=="WEEK") {
                days = 4;
                format = "yyyy年MM月";
                format2 = "yyyy-MM";
            }
            else if (reportType == "MONTH") {
                days = 12;
                format = "yyyy年";
                format2 = "yyyy-MM";
                colSuffix = "月";
            }

            object obj = System.Reflection.Missing.Value;

            Microsoft.Office.Interop.Excel.Workbook workbook;
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.ApplicationClass();
            workbook = app.Workbooks.Add((XlWBATemplate)(-4167));
            Worksheet worksheet = workbook.Worksheets[1] as Worksheet;
            worksheet.Name = date.ToString(format);
            Range range = null;
            app.Visible = false;
            try {
                int i;
                //设置列标题
                worksheet.Cells[1, 1] = docTitile;
                for (i = 0; i < headTable.Rows.Count; i++) {
                    if (i == 0) {
                        worksheet.Cells[2,i+1] = " 计量点\n\r日期";
                    }
                    else {
                        worksheet.Cells[2, i + 1] = headTable.Rows[i][0].ToString();
                    }
                }

                //数据排序
                DataView dv = table.DefaultView;
                dv.Sort = "[统计日期] asc";
                table = dv.ToTable();

                //设置列数据
                for (i = 0; i < days; i++) {
                    int colIndex = i + 1;
                    worksheet.Cells[3 + i, 1] = colIndex.ToString() + colSuffix;
                    DataRow row = null;
                  
                    foreach (DataRow dr in table.Rows) {
                        colIndex = i + 1;
                        if (reportType == "DAY") {
                            if (Convert.ToDateTime(dr["统计日期"]).Equals(Convert.ToDateTime(date.ToString(format2) + "-" + colIndex.ToString().PadLeft(2, '0'))))
                            {
                                row = dr;
                            }
                        }
                        else if (reportType == "MONTH") {
                            if(Convert.ToDateTime(dr["统计日期"]).ToString(format2)==(date.ToString("yyyy") + "-" + colIndex.ToString().PadLeft(2, '0'))) {
                                row = dr;
                                break;
                            }
                        }  
                    }
                    if (row != null) {
                        for (int j = 1; j < headTable.Rows.Count; j++) {
                            try {
                                worksheet.Cells[3 + i, j + 1] = row[j].ToString();
                            }
                            catch {
                            }
                        }
                    }
                }

                int footStartIndex = headTable.Rows.Count - 5;

                worksheet.Cells[days + 3, footStartIndex] = "负责人";
                worksheet.Cells[days + 3, footStartIndex + 2] = "审核人";
                worksheet.Cells[days + 3, footStartIndex + 4] = "日期";
                //合并第一行标题
                range = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, table.Columns.Count]];
                range.Merge(Missing.Value);
                range.RowHeight = 0x14;
                range.Font.Size = 14;
                range.Font.Name = "宋体";
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                range.VerticalAlignment = XlVAlign.xlVAlignCenter;

                
                //日期，计量点列
                range = worksheet.Range[worksheet.Cells[2, 1], worksheet.Cells[2, 1]];
                Border border = range.Borders[XlBordersIndex.xlDiagonalDown];
                border.LineStyle = XlLineStyle.xlContinuous;
                border.ColorIndex = XlColorIndex.xlColorIndexAutomatic;
                border.Weight = XlBorderWeight.xlThin;

                SetBorder(border, range);

                range.VerticalAlignment = XlVAlign.xlVAlignTop;
                range.RowHeight = 0X1C;
                range.ColumnWidth = 10.13;

                //设置标题样式
                range = worksheet.Range[worksheet.Cells[2, 1], worksheet.Cells[2, table.Columns.Count]];
                range.ColumnWidth = 9;
                range.VerticalAlignment = XlVAlign.xlVAlignCenter;
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                range.WrapText = true;

                range.VerticalAlignment = XlVAlign.xlVAlignCenter;
                range.RowHeight =0x1c;
                range = worksheet.Range[worksheet.Cells[2, 1], worksheet.Cells[2, 1]];
                range.ColumnWidth = 10.13;
                range = worksheet.Range[worksheet.Cells[2, 2], worksheet.Cells[2, table.Columns.Count]];
                range.ColumnWidth =9;
                range = worksheet.Range[worksheet.Cells[2, 2], worksheet.Cells[2, table.Columns.Count]];
                range.VerticalAlignment = XlVAlign.xlVAlignCenter;
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                range.WrapText = true;

                SetBorder(border, range);

                //设置内容
                range = worksheet.Range[worksheet.Cells[3, 1], worksheet.Cells[i+2, table.Columns.Count]];
                range.RowHeight = 14;
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                range.VerticalAlignment = XlVAlign.xlVAlignCenter;
                range.Font.Size = 11;
                range.Font.Name = "宋体";

                SetBorder(border, range);

                app.DisplayAlerts = true;
                app.AlertBeforeOverwriting = false;
                
                workbook.Saved = true;    
                workbook.SaveCopyAs(fileName);

                

            }
            catch (Exception exception) {
                FileInfo info = new FileInfo(fileName);
                string path = info.Directory.FullName + @"\MyTest.txt";
                if (!File.Exists(path)) {
                    using (StreamWriter writer = File.CreateText(path)) {
                        writer.WriteLine(exception.Message);
                    }
                }
            }
            finally {
                workbook.Close(false, Type.Missing, Type.Missing);
                app.Workbooks.Close();
                app.Quit();
                Marshal.FinalReleaseComObject(range);
                Marshal.FinalReleaseComObject(worksheet);
                Marshal.FinalReleaseComObject(workbook);
                Marshal.FinalReleaseComObject(app);
                range = null;
                worksheet = null;
                workbook = null;
                app = null;
                GC.Collect();

                ExecExportFile(fileName, exportFileName);
            }


            

        }


        private static void SetBorder(Border border, Range range)
        {
            border = range.Borders[XlBordersIndex.xlEdgeLeft];
            border.LineStyle = XlLineStyle.xlContinuous;
            border.ColorIndex = XlColorIndex.xlColorIndexAutomatic;
            border.Weight = XlBorderWeight.xlThin;

            border = range.Borders[XlBordersIndex.xlEdgeTop];
            border.LineStyle = XlLineStyle.xlContinuous;
            border.ColorIndex = XlColorIndex.xlColorIndexAutomatic;
            border.Weight = XlBorderWeight.xlThin;

            border = range.Borders[XlBordersIndex.xlEdgeBottom];
            border.LineStyle = XlLineStyle.xlContinuous;
            border.ColorIndex = XlColorIndex.xlColorIndexAutomatic;
            border.Weight = XlBorderWeight.xlThin;


            border = range.Borders[XlBordersIndex.xlEdgeRight];
            border.LineStyle = XlLineStyle.xlContinuous;
            border.ColorIndex = XlColorIndex.xlColorIndexAutomatic;
            border.Weight = XlBorderWeight.xlThin;

            border = range.Borders[XlBordersIndex.xlInsideVertical];
            border.LineStyle = XlLineStyle.xlContinuous;
            border.ColorIndex = XlColorIndex.xlColorIndexAutomatic;
            border.Weight = XlBorderWeight.xlThin;

            border = range.Borders[XlBordersIndex.xlInsideHorizontal];
            border.LineStyle = XlLineStyle.xlContinuous;
            border.ColorIndex = XlColorIndex.xlColorIndexAutomatic;
            border.Weight = XlBorderWeight.xlThin;

        }

        #endregion
    }
}
