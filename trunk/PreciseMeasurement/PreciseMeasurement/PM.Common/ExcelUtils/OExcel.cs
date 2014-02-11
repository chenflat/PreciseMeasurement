#define NotNet1p0
using System;
#if NotNet2p0
using System.Collections.Generic;
#endif
using System.Text;
using System.Collections;
using System.Data;
using System.Collections.Specialized;
using System.Drawing;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;


namespace PM.Common.ExcelUtils
{
    /// <summary>
    /// 记载Excel单元格组成的矩形区域
    /// </summary>
    public class ExcelRange
    {
        /// <summary>
        /// 区域的起始行相对于1的索引
        /// </summary>
        public int uRow;
        /// <summary>
        /// 区域的起始列相对于1的索引
        /// </summary>
        public int lCol;
        /// <summary>
        /// 区域的结束列相对于1的索引
        /// </summary>
        public int rCol;
        /// <summary>
        /// 区域的结束行相对于1的索引
        /// </summary>
        public int bRow;
        /// <summary>
        /// 初始化ExcelRange结构
        /// </summary>
        /// <param name="ur">区域的起始行相对于1的索引</param>
        /// <param name="lc">区域的起始列相对于1的索引</param>
        /// <param name="br">区域的结束行相对于1的索引</param>
        /// <param name="rc">区域的结束列相对于1的索引</param>
        public ExcelRange(int ur, int lc, int br, int rc)
        {
            uRow = ur;
            lCol = lc;
            rCol = rc;
            bRow = br;
        }
        /// <summary>
        /// 获得区域的行数
        /// </summary>
        public int Rows
        {
            get { return bRow - uRow + 1; }
        }
        /// <summary>
        /// 获得区域的列数
        /// </summary>
        public int Cols
        {
            get { return rCol - lCol + 1; }
        }
        /// <summary>
        /// 返回一个excel区域
        /// </summary>
        /// <param name="top">区域左上角单元格相对于1的行索引</param>
        /// <param name="left">区域左上角单元格相对于1的列索引</param>
        /// <param name="w">区域宽</param>
        /// <param name="h">区域高</param>
        /// <returns></returns>
        public static ExcelRange GetExcelRange(int top, int left, int w, int h)
        {
            return new ExcelRange(top, left, h + top - 1, w + left - 1);
        }
    }
    /// <summary>
    /// 封装了Excel常用操作,包括添加批注，文本，查找，替换，设定格式，添加删除行等操作，执行其中的任何方法都应该用<code>try{}catch{}</code>的方式，在捕获异常的操作中调用<see cref="Release"/>方法关闭Excel进程
    /// </summary>
    public class OExcel
    {
        Excel.Workbook workbook;
        Excel._Application app = new Excel.ApplicationClass();
        object obj = System.Reflection.Missing.Value;
        /// <summary>
        /// 
        /// </summary>
        public OExcel()
        {
            workbook = app.Workbooks.Add(obj);
            app.DisplayAlerts = false;
            app.UserControl = false;
            //app.DisplayAlerts = false;

        }
        /// <summary>
        /// 以ExcelWorkbook构造实例。当以此种方式构造实例时将关闭以前的Excel应用。
        /// </summary>
        /// <param name="Workbook"></param>
        public OExcel(object Workbook)
        {
            try
            {
                this.Release();
                workbook = (Excel.Workbook)Workbook;
                app = workbook.Application;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                this.Release();
                throw new Exception("模块初始化失败");
            }
        }
        /// <summary>
        /// 以Excel文件初始化实例
        /// </summary>
        /// <param name="fName">Excel路径</param>
        public OExcel(string fName)
        {
            try
            {
                app.Workbooks.Open(fName, false, obj, obj, obj, obj, obj, obj, obj, obj, obj, obj, obj, obj, obj);
                workbook = app.ActiveWorkbook;
                app.DisplayAlerts = false;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                this.Release();
                throw new Exception("模块初始化失败");
            }
        }
        /// <summary>
        /// 利用反身方法调用打开文件方法
        /// </summary>
        /// <param name="fName">文件名</param>
        /// <param name="booInvoke">是否反射</param>
        public OExcel(string fName, bool booInvoke)
        {
            try
            {
                object[] Pars = new Object[1];
                Pars[0] = fName;
                app.Workbooks.GetType().InvokeMember("Open", BindingFlags.InvokeMethod, null, app.Workbooks, Pars);

                workbook = app.ActiveWorkbook;
                app.DisplayAlerts = false;

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                this.Release();
                throw new Exception("模块初始化失败");

            }
        }
        /// <summary>
        /// 是否包含指定的sheet页
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool IsHaveSheet(string name)
        {
            try
            {
                object m = workbook.Sheets[name];
                return true;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="des"></param>
        /// <param name="src"></param>
        /// <param name="srcnames"></param>
        public static void CopySheetTo(string des, string src, params string[] srcnames)
        {
            Excel._Application apptemp = null;
            object obj = System.Reflection.Missing.Value;
            try
            {
                apptemp = new Excel.ApplicationClass();
                apptemp.DisplayAlerts = false;
                Excel.Workbook wbdes = apptemp.Workbooks.Open(des, false, obj, obj, obj, obj, obj, obj, obj, obj, obj, obj, obj, obj, obj);
                Excel.Workbook wbsrc = apptemp.Workbooks.Open(src, false, obj, obj, obj, obj, obj, obj, obj, obj, obj, obj, obj, obj, obj);
                ((Excel.Sheets)wbsrc.Sheets[srcnames]).Copy(obj, wbdes.Sheets[wbdes.Sheets.Count]);
                wbdes.Save();
                apptemp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(apptemp);
                apptemp = null;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                try
                {
                    apptemp.Quit(); System.Runtime.InteropServices.Marshal.ReleaseComObject(apptemp);
                    apptemp = null;
                }
                catch { }
            }
        }

        public static void CopySheetTo(string des, string src, bool All)
        {
            Excel._Application apptemp = null;
            object obj = System.Reflection.Missing.Value;
            try
            {
                apptemp = new Excel.ApplicationClass();
                apptemp.DisplayAlerts = false;
                Excel.Workbook wbdes = apptemp.Workbooks.Open(des, false, obj, obj, obj, obj, obj, obj, obj, obj, obj, obj, obj, obj, obj);
                Excel.Workbook wbsrc = apptemp.Workbooks.Open(src, false, obj, obj, obj, obj, obj, obj, obj, obj, obj, obj, obj, obj, obj);
                //获取源和目标的Sheet页汇总
                string[] srcnames = new string[wbsrc.Sheets.Count];
                string[] desnames = new string[wbdes.Sheets.Count];
                for (int i = 1; i <= srcnames.Length; i++)
                {
                    srcnames[i - 1] = ((Excel.Worksheet)wbsrc.Sheets[i]).Name;
                }
                for (int i = 1; i <= desnames.Length; i++)
                {
                    desnames[i - 1] = ((Excel.Worksheet)wbdes.Sheets[i]).Name;
                }
                //根据源和目标页的对比决定是覆盖还是插入到目标页
                for (int i = 0; i < srcnames.Length; i++)
                {
                    string srcname = srcnames[i];
                    bool find = false;
                    int sheetIndex = 0;
                    for (int j = 0; j < desnames.Length; j++)
                    {
                        string desname = desnames[j];
                        if (srcname.Trim().ToUpper() == desname.Trim().ToUpper())
                        {
                            find = true;
                            sheetIndex = j + 1;
                            break;
                        }
                    }
                    if (find)
                    {
                        //删除
                        ((Excel.Worksheet)wbdes.Sheets[sheetIndex]).Delete();
                    }
                    //插入
                    ((Excel.Worksheet)wbsrc.Sheets[(object)(i + 1)]).Copy(obj, (Excel.Worksheet)wbdes.Sheets[wbdes.Sheets.Count]);


                }
                wbdes.Save();

                if (apptemp != null)
                {
                    apptemp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(apptemp);
                }
                if (wbdes != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(wbdes);
                if (wbsrc != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(wbsrc);

                wbdes = null;
                wbsrc = null;

                apptemp = null;
                GC.Collect();

                //apptemp.Quit();
                //System.Runtime.InteropServices.Marshal.ReleaseComObject(apptemp);
                //apptemp = null;
            }
            catch (Exception)
            {
                try
                {
                    if (apptemp != null)
                    {
                        apptemp.Quit();
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(apptemp);
                    }
                    //if (wbdes != null)
                    //    System.Runtime.InteropServices.Marshal.ReleaseComObject(wbdes);
                    //if (wbsrc != null)
                    //    System.Runtime.InteropServices.Marshal.ReleaseComObject(wbsrc);

                    //wbdes = null;
                    //wbsrc = null;

                    apptemp = null;
                    GC.Collect();
                }
                catch
                { }
                //string msg = ex.Message;
                //try
                //{
                //    apptemp.Quit(); System.Runtime.InteropServices.Marshal.ReleaseComObject(apptemp);
                //    apptemp = null;
                //}
                //catch { }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="des"></param>
        /// <param name="src"></param>
        /// <param name="srcnames"></param>
        public static void CopySheetTo(string des, string src, params int[] srcnames)
        {
            Excel._Application apptemp = null;
            object obj = System.Reflection.Missing.Value;
            try
            {
                apptemp = new Excel.ApplicationClass();
                apptemp.DisplayAlerts = false;
                Excel.Workbook wbdes = apptemp.Workbooks.Open(des, false, obj, obj, obj, obj, obj, obj, obj, obj, obj, obj, obj, obj, obj);
                Excel.Workbook wbsrc = apptemp.Workbooks.Open(src, false, obj, obj, obj, obj, obj, obj, obj, obj, obj, obj, obj, obj, obj);
                ((Excel.Sheets)wbsrc.Sheets[srcnames]).Copy(obj, wbdes.Sheets[wbdes.Sheets.Count]);
                wbdes.Save();
                apptemp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(apptemp);
                apptemp = null;
            }
            catch
            {
                try
                {
                    apptemp.Quit(); System.Runtime.InteropServices.Marshal.ReleaseComObject(apptemp);
                    apptemp = null;
                }
                catch { }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="des"></param>
        /// <param name="src"></param>
        public static void CopySheetTo(string des, string src)
        {
            Excel._Application apptemp = null;
            object obj = System.Reflection.Missing.Value;
            try
            {
                apptemp = new Excel.ApplicationClass();
                apptemp.DisplayAlerts = false;
                Excel.Workbook wbdes = apptemp.Workbooks.Open(des, false, obj, obj, obj, obj, obj, obj, obj, obj, obj, obj, obj, obj, obj);
                Excel.Workbook wbsrc = apptemp.Workbooks.Open(src, false, obj, obj, obj, obj, obj, obj, obj, obj, obj, obj, obj, obj, obj);
                wbsrc.Sheets.Copy(obj, wbdes.Sheets[1]);
                wbdes.Save();
                apptemp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(apptemp);
                apptemp = null;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                try
                {
                    apptemp.Quit(); System.Runtime.InteropServices.Marshal.ReleaseComObject(apptemp);
                    apptemp = null;
                }
                catch { }
            }
        }
        /// <summary>
        /// 改变sheet页名字
        /// </summary>
        /// <param name="oldname"></param>
        /// <param name="NewName"></param>
        public void ChangeSheetName(string oldname, string NewName)
        {
            GetSheet(oldname).Name = NewName;
        }
        private Excel.Worksheet GetSheet()
        {
            return (Excel.Worksheet)workbook.ActiveSheet;
        }
        private Excel.Worksheet GetSheet(int SheetIndex)
        {
            return (Excel.Worksheet)workbook.Sheets[SheetIndex];
        }
        private Excel.Worksheet GetSheet(string SheetName)
        {
            return (Excel.Worksheet)workbook.Sheets[SheetName];
        }
        private Excel.Range GetRange(Excel.Worksheet ws, ExcelRange erange)
        {
            Excel.Range rs, re;
            rs = (Excel.Range)ws.Cells[erange.uRow, erange.lCol];
            re = (Excel.Range)ws.Cells[erange.bRow, erange.rCol];
            return ws.get_Range(rs, re);
        }
        /// <summary>
        /// 获取sheet页的数目
        /// </summary>
        public int Count
        {
            get { return workbook.Sheets.Count; }
        }
        /// <summary>
        /// 返回sheet名集合
        /// </summary>
        public string[] sheets
        {
            get
            {
                string[] res = new string[Count];
                for (int i = 1; i <= res.Length; i++)
                {
                    res[i - 1] = GetSheet(i).Name;
                }
                return res;
            }
        }
        /// <summary>
        /// 在当前活动的sheet上给指定行列的单元格添加批注
        /// </summary>
        /// <param name="Row">从1开始的行序号</param>
        /// <param name="Col">从1开始的列序号</param>
        /// <param name="Text">标签内容</param>
        public void SetRemark(int Row, int Col, string Text)
        {
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.ActiveSheet;
            Excel.Range range = (Excel.Range)worksheet.Cells[Row, Col];
            range.ClearComments();
            range.AddComment(Text);
        }
        /// <summary>
        /// 在指定的sheet上给指定行列的单元格添加批注
        /// </summary>
        /// <param name="SheetIndex">从1开始的sheet的索引序号</param>
        /// <param name="Row">从1开始的行序号</param>
        /// <param name="Col">从1开始的列序号</param>
        /// <param name="Text">标签内容</param>
        public void SetRemark(int SheetIndex, int Row, int Col, string Text)
        {
            Excel.Worksheet worksheet = GetSheet(SheetIndex);
            Excel.Range range = (Excel.Range)worksheet.Cells[Row, Col];
            range.ClearComments();
            range.AddComment(Text);
        }
        /// <summary>
        /// 在指定的sheet上给指定行列的单元格添加批注
        /// </summary>
        /// <param name="SheetName">sheet的名字</param>
        /// <param name="Row">从1开始的行序号</param>
        /// <param name="Col">从1开始的列序号</param>
        /// <param name="Text">标签内容</param>
        public void SetRemark(string SheetName, int Row, int Col, string Text)
        {
            Excel.Worksheet worksheet = GetSheet(SheetName);
            Excel.Range range = (Excel.Range)worksheet.Cells[Row, Col];
            range.ClearComments();
            range.AddComment(Text);
        }

        /// <summary>
        /// 在当前活动的sheet上给指定区域的单元格成批添加批注该方法比反复使用SetRemark速度要快
        /// </summary>
        /// <param name="erange">单元格区域</param>
        /// <param name="Text">标签内容的二位数组[行，列]</param>
        public void SetRemarks(ExcelRange erange, string[,] Text)
        {
            SetRemarks(GetSheet(), erange, Text);
        }
        /// <summary>
        /// 在指定的sheet上给指定区域的单元格成批添加批注该方法比反复使用SetRemark速度要快
        /// </summary>
        /// <param name="SheetIndex">从1开始的sheet的索引序号</param>
        /// <param name="erange">单元格区域</param>
        /// <param name="Text">标签内容的二位数组[行，列]</param>
        public void SetRemarks(int SheetIndex, ExcelRange erange, string[,] Text)
        {
            SetRemarks(GetSheet(SheetIndex), erange, Text);
        }
        /// <summary>
        /// 在指定的sheet上给指定区域的单元格成批添加批注该方法比反复使用SetRemark速度要快
        /// </summary>
        /// <param name="SheetName">sheet名</param>
        /// <param name="erange">单元格区域</param>
        /// <param name="Text">标签内容的二位数组[行，列]</param>
        public void SetRemarks(string SheetName, ExcelRange erange, string[,] Text)
        {
            SetRemarks(GetSheet(SheetName), erange, Text);
        }
        private void SetRemarks(Excel.Worksheet ws, ExcelRange erange, string[,] Text)
        {
            int ls = Text.GetLength(1);
            ls = erange.Cols < ls ? erange.Cols : ls;
            int rs = Text.GetLength(0);
            rs = erange.Rows < rs ? erange.Rows : rs;
            int ur = erange.uRow;
            int lc = erange.lCol;
            for (int i = 0; i < rs; i++)
            {
                for (int j = 0; j < ls; j++)
                {
                    Excel.Range range = (Excel.Range)ws.Cells[ur + i, lc + j];
                    range.ClearComments();
                    if (Text[i, j] != null)
                        range.AddComment(Text[i, j]);
                }
            }
        }
        /// <summary>
        /// 获得区域的批注信息。没有批注则返回null。
        /// </summary>
        /// <param name="erange"></param>
        /// <returns></returns>
        public string[,] GetRemarks(ExcelRange erange)
        {
            return GetRemarks(GetSheet(), erange);
        }

        private string[,] GetRemarks(Excel.Worksheet ws, ExcelRange erange)
        {
            string[,] res = new string[erange.Rows, erange.Cols];

            int ls = res.GetLength(1);
            int rs = res.GetLength(0);
            int ur = erange.uRow;
            int lc = erange.lCol;
            for (int i = 0; i < rs; i++)
            {
                for (int j = 0; j < ls; j++)
                {
                    Excel.Range range = (Excel.Range)ws.Cells[ur + i, lc + j];
                    if (range.Comment != null)
                        res[i, j] = range.Comment.Text(obj, obj, obj);
                    else
                        res[i, j] = null;
                }
            }
            return res;
        }

        /// <summary>
        /// 在当前活动的sheet上给指定行列的单元格添加文本
        /// </summary>
        /// <param name="Row">从1开始的行序号</param>
        /// <param name="Col">从1开始的列序号</param>
        /// <param name="Text">文本内容</param>
        public void SetText(int Row, int Col, string Text)
        {
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.ActiveSheet;
            worksheet.Cells[Row, Col] = Text;
        }
        /// <summary>
        /// 在指定的sheet上给指定行列的单元格添加文本
        /// </summary>
        /// <param name="SheetIndex">从1开始的sheet的索引序号</param>
        /// <param name="Row">从1开始的行序号</param>
        /// <param name="Col">从1开始的列序号</param>
        /// <param name="Text">文本内容</param>
        public void SetText(int SheetIndex, int Row, int Col, string Text)
        {
            Excel.Worksheet worksheet = GetSheet(SheetIndex);
            worksheet.Cells[Row, Col] = Text;
        }
        /// <summary>
        /// 在指定的sheet上给指定行列的单元格添加文本
        /// </summary>
        /// <param name="SheetName">sheet的名字</param>
        /// <param name="Row">从1开始的行序号</param>
        /// <param name="Col">从1开始的列序号</param>
        /// <param name="Text">文本内容</param>
        public void SetText(string SheetName, int Row, int Col, string Text)
        {
            Excel.Worksheet worksheet = GetSheet(SheetName);
            worksheet.Cells[Row, Col] = Text;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="erange"></param>
        /// <param name="Text"></param>
        public void SetTexts(ExcelRange erange, string[,] Text)
        {
            SetTexts(GetSheet(), erange, Text);
        }
        /// <summary>
        /// 在指定的sheet上给指定区域的单元格成批添加文本该方法比反复使用SetRemark速度要快
        /// </summary>
        /// <param name="SheetIndex">从1开始的sheet的索引序号</param>
        /// <param name="erange">单元格区域</param>
        /// <param name="Text">文本内容的二位数组[行，列]</param>
        public void SetTexts(int SheetIndex, ExcelRange erange, string[,] Text)
        {
            SetTexts(GetSheet(SheetIndex), erange, Text);
        }
        /// <summary>
        /// 在指定的sheet上给指定区域的单元格成批添加文本该方法比反复使用SetRemark速度要快
        /// </summary>
        /// <param name="SheetName">sheet的名字</param>
        /// <param name="erange">单元格区域</param>
        /// <param name="Text">文本内容的二位数组[行，列]</param>
        public void SetTexts(string SheetName, ExcelRange erange, string[,] Text)
        {
            SetTexts(GetSheet(SheetName), erange, Text);
        }
        private void SetTexts(Excel.Worksheet ws, ExcelRange erange, string[,] Text)
        {
            ExceptionOpt.IsNull(Text, "Text");
            int ls = Text.GetLength(1);
            ls = erange.Cols < ls ? erange.Cols : ls;
            int rs = Text.GetLength(0);
            rs = erange.Rows < rs ? erange.Rows : rs;
            int ur = erange.uRow;
            int lc = erange.lCol;
            for (int i = 0; i < rs; i++)
            {
                for (int j = 0; j < ls; j++)
                {
                    if (Text[i, j] != null)
                        ws.Cells[ur + i, lc + j] = Text[i, j];
                }
            }
        }

        /// <summary>
        /// 获得指定区域的文本
        /// </summary>
        /// <param name="erange"></param>
        /// <param name="Lookin"></param>
        /// <returns></returns>
        public string[,] GetTexts(ExcelRange erange, Excel.XlFindLookIn Lookin)
        {
            return GetCells(GetSheet(), erange, Lookin);
        }
        /// <summary>
        /// 获得指定区域的文本
        /// </summary>
        /// <param name="erange"></param>
        /// <param name="SheetIndex"></param>
        /// <param name="Lookin"></param>
        /// <returns></returns>
        public string[,] GetTexts(int SheetIndex, ExcelRange erange, Excel.XlFindLookIn Lookin)
        {
            return GetCells(GetSheet(SheetIndex), erange, Lookin);
        }
        /// <summary>
        /// 获得指定区域的文本
        /// </summary>
        /// <param name="erange"></param>
        /// <param name="SheetName"></param>
        /// <param name="Lookin"></param>
        /// <returns></returns>
        public string[,] GetTexts(string SheetName, ExcelRange erange, Excel.XlFindLookIn Lookin)
        {
            return GetCells(GetSheet(SheetName), erange, Lookin);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SheetIndex"></param>
        /// <param name="r"></param>
        /// <param name="c"></param>
        /// <param name="Lookin"></param>
        /// <returns></returns>
        public string GetText(int SheetIndex, int r, int c, Excel.XlFindLookIn Lookin)
        {
            try
            {
                Excel.Range rg = (Excel.Range)GetSheet(SheetIndex).Cells[r, c];
                switch (Lookin)
                {
                    case Excel.XlFindLookIn.xlComments:
                        return rg.Text.ToString();
                    case Excel.XlFindLookIn.xlValues:
                        return rg.Value2.ToString();
                    case Excel.XlFindLookIn.xlFormulas:
                        return rg.Formula.ToString();
                }
                return "";
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sheetname"></param>
        /// <param name="r"></param>
        /// <param name="c"></param>
        /// <param name="Lookin"></param>
        /// <returns></returns>
        public string GetText(string sheetname, int r, int c, Excel.XlFindLookIn Lookin)
        {
            try
            {
                Excel.Range rg = (Excel.Range)GetSheet(sheetname).Cells[r, c];
                switch (Lookin)
                {
                    case Excel.XlFindLookIn.xlComments:
                        return rg.Text.ToString();
                    case Excel.XlFindLookIn.xlValues:
                        return rg.Value2.ToString();
                    case Excel.XlFindLookIn.xlFormulas:
                        return rg.Formula.ToString();
                }
                return "";
            }
            catch
            {
                return "";
            }
        }
        private string[,] GetCells(Excel.Worksheet ws, ExcelRange erange, Excel.XlFindLookIn Lookin)
        {
            Excel.Worksheet worksheet = ws;
            string[,] res = new string[erange.Rows, erange.Cols];
            switch (Lookin)
            {
                case Excel.XlFindLookIn.xlComments:
                    for (int r = 0; r < erange.Rows; r++)
                    {
                        for (int c = 0; c < erange.Cols; c++)
                        {
                            res[r, c] = ((Excel.Range)worksheet.Cells[erange.uRow + r, erange.lCol + c]).Text.ToString();
                        }
                    }
                    break;
                case Excel.XlFindLookIn.xlFormulas:
                    for (int r = 0; r < erange.Rows; r++)
                    {
                        for (int c = 0; c < erange.Cols; c++)
                        {
                            res[r, c] = ((Excel.Range)worksheet.Cells[erange.uRow + r, erange.lCol + c]).Formula.ToString();
                        }
                    }
                    break;
                case Excel.XlFindLookIn.xlValues:
                    for (int r = 0; r < erange.Rows; r++)
                    {
                        for (int c = 0; c < erange.Cols; c++)
                        {
                            res[r, c] = ((Excel.Range)worksheet.Cells[erange.uRow + r, erange.lCol + c]).Value2.ToString();
                        }
                    }
                    break;
            }
            return res;
        }
        #region
        ///// <summary>
        ///// 在Excel工作簿中查询指定条件的单元格集合
        ///// </summary>
        ///// <param name="Text">查询的信息字符串</param>
        ///// <param name="Lookin">查询的内容（公式，标签，值）</param>
        ///// <param name="Lookat">单元格匹配说明</param>
        ///// <param name="SearchOrder">查询规则（行，列）</param>
        ///// <param name="SearchDirection">查询方向（向上，向下）</param>
        ///// <param name="MatchCase">是否匹配大小写</param>
        ///// <returns></returns>
        //public Excel.Range[] FindRangesInAll(string Text, Excel.XlFindLookIn Lookin, Excel.XlLookAt Lookat, Excel.XlSearchOrder SearchOrder, Excel.XlSearchDirection SearchDirection, bool MatchCase)
        //{
        //    try
        //    {
        //        int iMax = workbook.Sheets.Count + 1;
        //        ArrayList at = new ArrayList();
        //        Excel.Range[][] rangetemp = new Excel.Range[iMax][];
        //        for (int i = 1; i < iMax; i++)
        //            rangetemp[i] = FindRanges(i, Text, Lookin, Lookat, SearchOrder, SearchDirection, MatchCase);
        //        iMax=rangetemp.GetLength(0);
        //        int jMax=rangetemp.GetLength(1);
        //        Excel.Range[] rgs = new Excel.Range[ iMax*jMax ];
        //        int pos=0;
        //        for (int i = 0; i < iMax; i++)
        //        {
        //            for (int j = 0; j < jMax; j++)
        //            {
        //                rgs[pos++] = rangetemp[i][j];
        //            }
        //        }
        //        return rgs;
        //    }
        //    catch
        //    { return new Excel.Range[0]; }
        //}
        ///// <summary>
        ///// 在Excel工作簿中查询指定条件的单元格集合
        ///// </summary>
        ///// <param name="Text">查询的信息字符串</param>
        ///// <param name="Lookin">查询的内容（公式，标签，值）</param>
        ///// <param name="Lookat">单元格匹配说明</param>
        ///// <param name="SearchOrder">查询规则（行，列）</param>
        ///// <param name="SearchDirection">查询方向（向上，向下）</param>
        ///// <param name="MatchCase">是否匹配大小写</param>
        ///// <returns></returns>
        //public Excel.Range[] FindRanges(string Text, Excel.XlFindLookIn Lookin, Excel.XlLookAt Lookat, Excel.XlSearchOrder SearchOrder, Excel.XlSearchDirection SearchDirection, bool MatchCase)
        //{
        //    try
        //    {
        //        Excel.Range temp;
        //        Excel.Worksheet worksheet = GetSheet();
        //        Excel.Range rg = worksheet.Cells.Find(Text, worksheet.Application.ActiveCell, Lookin, Lookat, SearchOrder, SearchDirection, MatchCase, true);
        //        if (rg == null)
        //            return new Excel.Range[0];
        //        ArrayList altemp = new ArrayList();
        //        altemp.Add(rg);
        //        temp = rg;
        //        Excel.Range trg;
        //        while (true)
        //        {
        //            trg = worksheet.UsedRange.FindNext(temp);
        //            if (trg == null)
        //                break;
        //            if (trg.Row == rg.Row && trg.Column == rg.Column)
        //                break;
        //            altemp.Add(trg);
        //            temp = trg;
        //        }
        //        Excel.Range[] res = new Excel.Range[altemp.Count];
        //        for (int i = 0; i < res.Length; i++)
        //        {
        //            res[i] = (Excel.Range)altemp[i];
        //        }
        //        return res;
        //    }
        //    catch
        //    { return new Excel.Range[0]; }
        //}   
        ///// <summary>
        ///// 在指定的sheet上查询指定条件的单元格集合
        ///// </summary>
        ///// <param name="SheetIndex">从1开始的sheet的索引序号</param>
        ///// <param name="Text">查询的信息字符串</param>
        ///// <param name="Lookin">查询的内容（公式，标签，值）</param>
        ///// <param name="Lookat">单元格匹配说明</param>
        ///// <param name="SearchOrder">查询规则（行，列）</param>
        ///// <param name="SearchDirection">查询方向（向上，向下）</param>
        ///// <param name="MatchCase">是否匹配大小写</param>
        ///// <returns></returns>
        //public Excel.Range[] FindRanges(int SheetIndex, string Text, Excel.XlFindLookIn Lookin, Excel.XlLookAt Lookat, Excel.XlSearchOrder SearchOrder, Excel.XlSearchDirection SearchDirection, bool MatchCase)
        //{
        //    try
        //    {
        //        Excel.Range temp;
        //        Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[SheetIndex];
        //        workbook.Sheets.Select(SheetIndex);
        //        Excel.Range rg = worksheet.Cells.Find(Text, worksheet.Application.ActiveCell, Lookin, Lookat, SearchOrder, SearchDirection, MatchCase, obj);
        //        if (rg == null)
        //            return new Excel.Range[0];
        //        ArrayList altemp = new ArrayList();
        //        altemp.Add(rg);
        //        temp = rg;
        //        Excel.Range trg;
        //        while (true)
        //        {
        //            trg = worksheet.UsedRange.FindNext(temp);
        //            if (trg == null)
        //                break;
        //            if (trg.Row == rg.Row && trg.Column == rg.Column)
        //                break;
        //            altemp.Add(trg);
        //            temp = trg;
        //        }
        //        Excel.Range[] res = new Excel.Range[altemp.Count];
        //        for (int i = 0; i < res.Length; i++)
        //        {
        //            res[i] = (Excel.Range)altemp[i];
        //        }
        //        return res;
        //    }
        //    catch
        //    { return new Excel.Range[0]; }
        //}
        ///// <summary>
        ///// 在指定的sheet上查询指定条件的单元格集合
        ///// </summary>
        ///// <param name="SheetName">sheet的名字</param>
        ///// <param name="Text">查询的信息字符串</param>
        ///// <param name="Lookin">查询的内容（公式，标签，值）</param>
        ///// <param name="Lookat">单元格匹配说明</param>
        ///// <param name="SearchOrder">查询规则（行，列）</param>
        ///// <param name="SearchDirection">查询方向（向上，向下）</param>
        ///// <param name="MatchCase">是否匹配大小写</param>
        ///// <returns></returns>
        //public Excel.Range[] FindRanges(string SheetName, string Text, Excel.XlFindLookIn Lookin, Excel.XlLookAt Lookat, Excel.XlSearchOrder SearchOrder, Excel.XlSearchDirection SearchDirection, bool MatchCase)
        //{
        //    try
        //    {
        //        Excel.Range temp;
        //        Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[SheetName];
        //        workbook.Sheets.Select(SheetName);
        //        Excel.Range rg = worksheet.Cells.Find(Text, worksheet.Application.ActiveCell, Lookin, Lookat, SearchOrder, SearchDirection, MatchCase, obj);
        //        if (rg == null)
        //            return new Excel.Range[0];
        //        ArrayList altemp = new ArrayList();
        //        altemp.Add(rg);
        //        temp = rg;
        //        Excel.Range trg;
        //        while (true)
        //        {
        //            trg = worksheet.UsedRange.FindNext(temp);
        //            if (trg == null)
        //                break;
        //            if (trg.Row == rg.Row && trg.Column == rg.Column)
        //                break;
        //            altemp.Add(trg);
        //            temp = trg;
        //        }
        //        Excel.Range[] res = new Excel.Range[altemp.Count];
        //        for (int i = 0; i < res.Length; i++)
        //        {
        //            res[i] = (Excel.Range)altemp[i];
        //        }
        //        return res;
        //    }
        //    catch
        //    { return new Excel.Range[0]; }
        //}

        ///// <summary>
        ///// 在Excel工作簿中查询指定条件的首个单元格
        ///// </summary>
        ///// <param name="Text">查询的信息字符串</param>
        ///// <param name="Lookin">查询的内容（公式，标签，值）</param>
        ///// <param name="Lookat">单元格匹配说明</param>
        ///// <param name="SearchOrder">查询规则（行，列）</param>
        ///// <param name="SearchDirection">查询方向（向上，向下）</param>
        ///// <param name="MatchCase">是否匹配大小写</param>
        ///// <returns></returns>
        //public Excel.Range FindRangeInAll(string Text, Excel.XlFindLookIn Lookin, Excel.XlLookAt Lookat, Excel.XlSearchOrder SearchOrder, Excel.XlSearchDirection SearchDirection, bool MatchCase)
        //{
        //    try
        //    {
        //        foreach (Excel.Worksheet wh in workbook.Sheets)
        //        {
        //            Excel.Range rg = wh.Cells.Find(Text, wh.Cells[1, 1], Lookin, Lookat, SearchOrder, SearchDirection, MatchCase, obj);
        //            if (rg != null)
        //                return rg;
        //        }
        //        return null;
        //    }
        //    catch
        //    { return null; }
        //}
        ///// <summary>
        ///// 在Excel工作簿中查询指定条件的首个单元格
        ///// </summary>
        ///// <param name="Text">查询的信息字符串</param>
        ///// <param name="Lookin">查询的内容（公式，标签，值）</param>
        ///// <param name="Lookat">单元格匹配说明</param>
        ///// <param name="SearchOrder">查询规则（行，列）</param>
        ///// <param name="SearchDirection">查询方向（向上，向下）</param>
        ///// <param name="MatchCase">是否匹配大小写</param>
        ///// <returns></returns>
        //public Excel.Range FindRange(string Text, Excel.XlFindLookIn Lookin, Excel.XlLookAt Lookat, Excel.XlSearchOrder SearchOrder, Excel.XlSearchDirection SearchDirection, bool MatchCase)
        //{
        //    try
        //    {
        //        Excel.Worksheet wh = GetSheet();
        //        Excel.Range rg = wh.Cells.Find(Text, wh.Cells[1, 1], Lookin, Lookat, SearchOrder, SearchDirection, MatchCase, obj);
        //        return rg;
        //    }
        //    catch
        //    { return null; }
        //}
        ///// <summary>
        ///// 在指定的sheet上查询指定条件的首个单元格
        ///// </summary>
        ///// <param name="SheetIndex">从1开始的sheet的索引序号</param>
        ///// <param name="Text">查询的信息字符串</param>
        ///// <param name="Lookin">查询的内容（公式，标签，值）</param>
        ///// <param name="Lookat">单元格匹配说明</param>
        ///// <param name="SearchOrder">查询规则（行，列）</param>
        ///// <param name="SearchDirection">查询方向（向上，向下）</param>
        ///// <param name="MatchCase">是否匹配大小写</param>
        ///// <returns></returns>
        //public Excel.Range FindRange(int SheetIndex, string Text, Excel.XlFindLookIn Lookin, Excel.XlLookAt Lookat, Excel.XlSearchOrder SearchOrder, Excel.XlSearchDirection SearchDirection, bool MatchCase)
        //{
        //    try
        //    {
        //        Excel.Worksheet wh=GetSheet(SheetIndex);
        //        Excel.Range rg = wh.Cells.Find(Text, wh.Cells[1, 1], Lookin, Lookat, SearchOrder, SearchDirection, MatchCase, obj);
        //        return rg;
        //    }
        //    catch
        //    { return null; }
        //}
        ///// <summary>
        ///// 在指定的sheet上查询指定条件的首个单元格
        ///// </summary>
        ///// <param name="SheetName">sheet的名字</param>
        ///// <param name="Text">查询的信息字符串</param>
        ///// <param name="Lookin">查询的内容（公式，标签，值）</param>
        ///// <param name="Lookat">单元格匹配说明</param>
        ///// <param name="SearchOrder">查询规则（行，列）</param>
        ///// <param name="SearchDirection">查询方向（向上，向下）</param>
        ///// <param name="MatchCase">是否匹配大小写</param>
        ///// <returns></returns>
        //public Excel.Range FindRange(string SheetName, string Text, Excel.XlFindLookIn Lookin, Excel.XlLookAt Lookat, Excel.XlSearchOrder SearchOrder, Excel.XlSearchDirection SearchDirection, bool MatchCase)
        //{
        //    try
        //    {
        //        Excel.Worksheet wh = GetSheet(SheetName);
        //        Excel.Range rg = wh.Cells.Find(Text, wh.Cells[1, 1], Lookin, Lookat, SearchOrder, SearchDirection, MatchCase, obj);
        //        return rg;
        //    }
        //    catch
        //    { return null; }
        //}
        #endregion

        /// <summary>
        /// 在Excel工作簿中查询指定条件的单元格集合
        /// </summary>
        /// <param name="Text">查询的信息字符串</param>
        /// <param name="Lookin">查询的内容（公式，标签，值）</param>
        /// <param name="isFirst">是否只查找一个</param>
        /// <returns></returns>
        public Excel.Range[] FindRanges(string Text, Excel.XlFindLookIn Lookin, bool isFirst)
        {
            return find(GetSheet(), Text, Lookin, isFirst);
        }
        /// <summary>
        /// 在指定的sheet上查询指定条件的单元格集合
        /// </summary>
        /// <param name="SheetIndex">从1开始的sheet的索引序号</param>
        /// <param name="Text">查询的信息字符串</param>
        /// <param name="Lookin">查询的内容（公式，标签，值）</param>
        /// <param name="isFirst">是否只查找一个</param>
        /// <returns></returns>
        public Excel.Range[] FindRanges(int SheetIndex, string Text, Excel.XlFindLookIn Lookin, bool isFirst)
        {
            return find(GetSheet(SheetIndex), Text, Lookin, isFirst);
        }
        /// <summary>
        /// 在指定的sheet上查询指定条件的单元格集合
        /// </summary>
        /// <param name="SheetName">sheet的名字</param>
        /// <param name="Text">查询的信息字符串</param>
        /// <param name="Lookin">查询的内容（公式，标签，值）</param>
        /// <param name="isFirst">是否只查找一个</param>
        /// <returns></returns>
        public Excel.Range[] FindRanges(string SheetName, string Text, Excel.XlFindLookIn Lookin, bool isFirst)
        {
            return find(GetSheet(SheetName), Text, Lookin, isFirst);
        }
        private Excel.Range[] find(Excel.Worksheet ws, string Text, Excel.XlFindLookIn Lookin, bool isFirst)
        {
            ArrayList rgs = new ArrayList();
            Excel.Range rg = ws.UsedRange;
            int rstart = rg.Row;
            int rend = rg.Rows.Count + rstart;
            int cstart = rg.Column;
            int cend = rg.Columns.Count + cstart;
            switch (Lookin)
            {
                case Excel.XlFindLookIn.xlComments:
                    for (int r = rstart; r < rend; r++)
                    {
                        for (int c = cstart; c < rend; c++)
                        {
                            Excel.Range rgm = (Excel.Range)ws.Cells[r, c];
                            if ((rgm.Text != null) && (rgm.Text.ToString() == Text))
                            {
                                rgs.Add(rgm);
                                if (isFirst)
                                    break;
                            }
                        }
                    }
                    break;
                case Excel.XlFindLookIn.xlFormulas:
                    for (int r = rstart; r < rend; r++)
                    {
                        for (int c = cstart; c < rend; c++)
                        {
                            Excel.Range rgm = (Excel.Range)ws.Cells[r, c];
                            if ((rgm.Formula != null) && (rgm.Formula.ToString() == Text))
                            {
                                rgs.Add(rgm);
                                if (isFirst)
                                    break;
                            }
                        }
                    }
                    break;
                case Excel.XlFindLookIn.xlValues:
                    for (int r = rstart; r < rend; r++)
                    {
                        for (int c = cstart; c < rend; c++)
                        {
                            Excel.Range rgm = (Excel.Range)ws.Cells[r, c];
                            if ((rgm.Value2 != null) && (rgm.Value2.ToString() == Text))
                            {
                                rgs.Add(rgm);
                                if (isFirst)
                                    break;
                            }
                        }
                    }
                    break;
            }
            Excel.Range[] rergs = new Excel.Range[rgs.Count];
            rgs.CopyTo(rergs);
            return rergs;
        }
        /// <summary>
        /// 返回所有的带有批注的单元格
        /// </summary>
        /// <returns></returns>
        public Excel.Range[] GetRemark()
        {
            return GetRemark(GetSheet());
        }
        /// <summary>
        /// 返回所有的带有批注的单元格
        /// </summary>
        /// <param name="SheetIndex"></param>
        /// <returns></returns>
        public Excel.Range[] GetRemark(int SheetIndex)
        {
            return GetRemark(GetSheet(SheetIndex));
        }
        /// <summary>
        /// 返回所有的带有批注的单元格
        /// </summary>
        /// <param name="SheetName"></param>
        /// <returns></returns>
        public Excel.Range[] GetRemark(string SheetName)
        {
            return GetRemark(GetSheet(SheetName));
        }
        /// <summary>
        /// 返回所有的标注区域
        /// </summary>
        /// <returns></returns>
        public Excel.Range[] GetAllRemarks()
        {
            ArrayList rgs = new ArrayList();
            foreach (Excel.Worksheet ws in workbook.Sheets)
            {
                Excel.Range rg = ws.UsedRange;
                int rstart = rg.Row;
                int rend = rg.Rows.Count + rstart;
                int cstart = rg.Column;
                int cend = rg.Columns.Count + cstart;
                for (int r = rstart; r < rend; r++)
                {
                    for (int c = cstart; c < rend; c++)
                    {
                        Excel.Range rgm = (Excel.Range)ws.Cells[r, c];
                        if (rgm.Comment != null)
                        {
                            rgs.Add(rgm);
                        }
                    }
                }
            }
            Excel.Range[] rergs = new Excel.Range[rgs.Count];
            rgs.CopyTo(rergs);
            return rergs;
        }
        private Excel.Range[] GetRemark(Excel.Worksheet ws)
        {
            ArrayList rgs = new ArrayList();
            Excel.Range rg = ws.UsedRange;
            int rstart = rg.Row;
            int rend = rg.Rows.Count + rstart;
            int cstart = rg.Column;
            int cend = rg.Columns.Count + cstart;
            for (int r = rstart; r < rend; r++)
            {
                for (int c = cstart; c < rend; c++)
                {
                    Excel.Range rgm = (Excel.Range)ws.Cells[r, c];
                    if (rgm.Comment != null)
                    {
                        rgs.Add(rgm);
                    }
                }
            }
            Excel.Range[] rergs = new Excel.Range[rgs.Count];
            rgs.CopyTo(rergs);
            return rergs;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Lookin"></param>
        /// <returns></returns>
        public Excel.Range[] FindAllRanges(string Text, Excel.XlFindLookIn Lookin)
        {
            ArrayList rgs = new ArrayList();
            foreach (Excel.Worksheet ws in workbook.Sheets)
            {
                Excel.Range rg = ws.UsedRange;
                int rstart = rg.Row;
                int rend = rg.Rows.Count + rstart;
                int cstart = rg.Column;
                int cend = rg.Columns.Count + cstart;
                switch (Lookin)
                {
                    case Excel.XlFindLookIn.xlComments:
                        for (int r = rstart; r < rend; r++)
                        {
                            for (int c = cstart; c < rend; c++)
                            {
                                Excel.Range rgm = (Excel.Range)ws.Cells[r, c];
                                if ((rgm.Text != null) && (rgm.Text.ToString() == Text))
                                {
                                    rgs.Add(rgm);
                                }
                            }
                        }
                        break;
                    case Excel.XlFindLookIn.xlFormulas:
                        for (int r = rstart; r < rend; r++)
                        {
                            for (int c = cstart; c < rend; c++)
                            {
                                Excel.Range rgm = (Excel.Range)ws.Cells[r, c];
                                if ((rgm.Formula != null) && (rgm.Formula.ToString() == Text))
                                {
                                    rgs.Add(rgm);
                                }
                            }
                        }
                        break;
                    case Excel.XlFindLookIn.xlValues:
                        for (int r = rstart; r < rend; r++)
                        {
                            for (int c = cstart; c < rend; c++)
                            {
                                Excel.Range rgm = (Excel.Range)ws.Cells[r, c];
                                if ((rgm.Value2 != null) && (rgm.Value2.ToString() == Text))
                                {
                                    rgs.Add(rgm);
                                }
                            }
                        }
                        break;
                }
            }
            Excel.Range[] rergs = new Excel.Range[rgs.Count];
            rgs.CopyTo(rergs);
            return rergs;
        }

        /// <summary>
        /// 选定区域
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public object Select(ExcelRange range)
        {
            return Select(GetSheet(), range);
        }
        /// <summary>
        /// 选定区域
        /// </summary>
        /// <param name="SheetIndex"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        public object Select(int SheetIndex, ExcelRange range)
        {
            return Select(GetSheet(SheetIndex), range);
        }
        /// <summary>
        /// 选定区域
        /// </summary>
        /// <param name="SheetName"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        public object Select(string SheetName, ExcelRange range)
        {
            return Select(GetSheet(SheetName), range);
        }
        private object Select(Excel.Worksheet ws, ExcelRange range)
        {
            ws.Select(obj);
            if (range != null)
                return GetRange(ws, range).Select();
            else
                return ws.UsedRange.Select();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public object Select(string r, string c)
        {
            return Select(GetSheet(), r, c);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="SheetName"></param>
        /// <param name="r"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public object Select(string SheetName, string r, string c)
        {
            return Select(GetSheet(), r, c);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="SheetIndex"></param>
        /// <param name="r"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public object Select(int SheetIndex, string r, string c)
        {
            return Select(GetSheet(), r, c);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public object Select(int r, int c)
        {
            return Select(GetSheet(), r, c);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="SheetName"></param>
        /// <param name="r"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public object Select(string SheetName, int r, int c)
        {
            return Select(GetSheet(SheetName), r, c);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="SheetIndex"></param>
        /// <param name="r"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public object Select(int SheetIndex, int r, int c)
        {
            return Select(GetSheet(SheetIndex), r, c);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rg"></param>
        /// <returns></returns>
        public object Select(Excel.Range rg)
        {
            return Select(rg.Worksheet, rg.Row, rg.Column);
        }
        private object Select(Excel.Worksheet ws, string r, string c)
        {
            ws.Select(obj);
            return ((Excel.Range)ws.Cells[r, c]).Select();
        }
        private object Select(Excel.Worksheet ws, int r, int c)
        {
            ws.Select(obj);
            return ((Excel.Range)ws.Cells[r, c]).Select();
        }

        private void SetBKColor(Excel.Worksheet ws, ExcelRange rg, System.Drawing.Color cl)
        {
            int rstart = rg.uRow;
            int rend = rg.Rows + rstart;
            int cstart = rg.lCol;
            int cend = rg.Cols + cstart;
            GetRange(ws, rg).Interior.Color = GetBGRFromColor(cl);
            //for (int r = rstart; r < rend; r++)
            //{
            //    for (int c = cstart; c < rend; c++)
            //    {
            //        Excel.Range rgm = (Excel.Range)ws.Cells[r, c];
            //        rgm.Interior.Color = GetBGRFromColor(cl);
            //    }
            //}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        /// <param name="c"></param>
        /// <param name="cl"></param>
        public void SetBKColor(string r, string c, Color cl)
        {
            SetBKColor(GetSheet(), r, c, cl);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="SheetIndex"></param>
        /// <param name="r"></param>
        /// <param name="c"></param>
        /// <param name="cl"></param>
        public void SetBKColor(int SheetIndex, string r, string c, Color cl)
        {
            SetBKColor(GetSheet(SheetIndex), r, c, cl);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="SheetName"></param>
        /// <param name="r"></param>
        /// <param name="c"></param>
        /// <param name="cl"></param>
        public void SetBKColor(string SheetName, string r, string c, Color cl)
        {
            SetBKColor(GetSheet(SheetName), r, c, cl);
        }
        private void SetBKColor(Excel.Worksheet ws, string r, string c, Color cl)
        {
            Excel.Range rgm = (Excel.Range)ws.Cells[r, c];
            rgm.Interior.Color = GetBGRFromColor(cl);
        }

        /// <summary>
        /// 替换Excel工作簿中单元格内容
        /// </summary>
        /// <param name="Text">原字符串</param>
        /// <param name="ToText">替换为</param>
        /// <param name="Lookat">单元格匹配说明</param>
        /// <param name="SearchOrder">替换顺序</param>
        /// <param name="MatchCase">是否匹配单元格</param>
        public void ReplaceRanges(string Text, string ToText, Excel.XlLookAt Lookat, Excel.XlSearchOrder SearchOrder, bool MatchCase)
        {
            foreach (Excel.Worksheet worksheet in workbook.Sheets)
                worksheet.Cells.Replace(Text, ToText, Lookat, SearchOrder, MatchCase, obj, obj, obj);
        }
        /// <summary>
        /// 替换指定的sheet中单元格内容
        /// </summary>
        /// <param name="SheetIndex">从1开始的sheet的索引序号</param>
        /// <param name="Text">原字符串</param>
        /// <param name="ToText">替换为</param>
        /// <param name="Lookat">单元格匹配说明</param>
        /// <param name="SearchOrder">替换顺序</param>
        /// <param name="MatchCase">是否匹配单元格</param>
        public void ReplaceRanges(int SheetIndex, string Text, string ToText, Excel.XlLookAt Lookat, Excel.XlSearchOrder SearchOrder, bool MatchCase)
        {
            Excel.Worksheet worksheet = GetSheet(SheetIndex);
            worksheet.Cells.Replace(Text, ToText, Lookat, SearchOrder, MatchCase, obj, obj, obj);
        }
        /// <summary>
        /// 替换指定的sheet中单元格内容
        /// </summary>
        /// <param name="SheetName">sheet的名字</param>
        /// <param name="Text">原字符串</param>
        /// <param name="ToText">替换为</param>
        /// <param name="Lookat">单元格匹配说明</param>
        /// <param name="SearchOrder">替换顺序</param>
        /// <param name="MatchCase">是否匹配单元格</param>
        public void ReplaceRanges(string SheetName, string Text, string ToText, Excel.XlLookAt Lookat, Excel.XlSearchOrder SearchOrder, bool MatchCase)
        {
            Excel.Worksheet worksheet = GetSheet(SheetName);
            worksheet.Cells.Replace(Text, ToText, Lookat, SearchOrder, MatchCase, obj, obj, obj);
        }

        /// <summary>
        /// 在当前活动的sheet上给指定区域设置简单格式
        /// </summary>
        /// <param name="erange">要修改的单元格区域</param>
        /// <param name="NumberFormatLocal">以用户语言字符串设置对象的格式代码</param>
        /// <param name="HAlign">对象的水平对齐方式</param>
        /// <param name="VAlign">对象的垂直对齐方式</param>
        /// <param name="WrapText">是否自动换行，如果设置为True，ShrinkToFit将无效</param>
        /// <param name="Orientation">文本旋转角度</param>
        /// <param name="AddIndent">是否两端分散对其</param>
        /// <param name="IndentLevel">样式的缩进量</param>
        /// <param name="ShrinkToFit">是否缩放以适应单元格大小</param>
        /// <param name="ReadingOrder">文本顺序</param>
        /// <param name="MergeCells">是否合并单元格</param>
        /// <param name="IsTextStyle">是否是竖排版文本</param>
        public void SetRangesFormat(ExcelRange erange, string NumberFormatLocal, Excel.XlHAlign HAlign, Excel.XlVAlign VAlign, bool WrapText, int Orientation, bool AddIndent, int IndentLevel, bool ShrinkToFit, Excel.Constants ReadingOrder, bool MergeCells, bool IsTextStyle)
        {
            Excel.Range rg = GetRange(GetSheet(), erange);
            rg.NumberFormatLocal = NumberFormatLocal;
            rg.HorizontalAlignment = HAlign;
            rg.VerticalAlignment = VAlign;
            rg.WrapText = WrapText;
            rg.Orientation = Orientation;
            rg.AddIndent = AddIndent;
            rg.IndentLevel = IndentLevel;
            rg.ShrinkToFit = ShrinkToFit;
            rg.ReadingOrder = (int)ReadingOrder;
            rg.MergeCells = MergeCells;
            if (IsTextStyle)
                rg.Orientation = -4166;
        }
        /// <summary>
        /// 在指定的sheet上给指定区域设置简单格式
        /// </summary>
        /// <param name="SheetIndex">从1开始的sheet的索引序号</param>
        /// <param name="erange">要修改的单元格区域</param>
        /// <param name="NumberFormatLocal">以用户语言字符串设置对象的格式代码</param>
        /// <param name="HAlign">对象的水平对齐方式</param>
        /// <param name="VAlign">对象的垂直对齐方式</param>
        /// <param name="WrapText">是否自动换行，如果设置为True，ShrinkToFit将无效</param>
        /// <param name="Orientation">文本旋转角度</param>
        /// <param name="AddIndent">是否两端分散对其</param>
        /// <param name="IndentLevel">样式的缩进量</param>
        /// <param name="ShrinkToFit">是否缩放以适应单元格大小</param>
        /// <param name="ReadingOrder">文本顺序</param>
        /// <param name="MergeCells">是否合并单元格</param>
        /// <param name="IsTextStyle">是否是竖排版文本</param>
        public void SetRangesFormat(int SheetIndex, ExcelRange erange, string NumberFormatLocal, Excel.XlHAlign HAlign, Excel.XlVAlign VAlign, bool WrapText, int Orientation, bool AddIndent, int IndentLevel, bool ShrinkToFit, Excel.Constants ReadingOrder, bool MergeCells, bool IsTextStyle)
        {
            Excel.Range rg = GetRange(GetSheet(SheetIndex), erange);
            rg.NumberFormatLocal = NumberFormatLocal;
            rg.HorizontalAlignment = HAlign;
            rg.VerticalAlignment = VAlign;
            rg.WrapText = WrapText;
            rg.Orientation = Orientation;
            rg.AddIndent = AddIndent;
            rg.IndentLevel = IndentLevel;
            rg.ShrinkToFit = ShrinkToFit;
            rg.ReadingOrder = (int)ReadingOrder;
            rg.MergeCells = MergeCells;
            if (IsTextStyle)
                rg.Orientation = -4166;
        }
        /// <summary>
        /// 在指定的sheet上给指定区域设置简单格式
        /// </summary>
        /// <param name="SheetName">sheet的名字</param>
        /// <param name="erange">要修改的单元格区域</param>
        /// <param name="NumberFormatLocal">以用户语言字符串设置对象的格式代码</param>
        /// <param name="HAlign">对象的水平对齐方式</param>
        /// <param name="VAlign">对象的垂直对齐方式</param>
        /// <param name="WrapText">是否自动换行，如果设置为True，ShrinkToFit将无效</param>
        /// <param name="Orientation">文本旋转角度</param>
        /// <param name="AddIndent">是否两端分散对其</param>
        /// <param name="IndentLevel">样式的缩进量</param>
        /// <param name="ShrinkToFit">是否缩放以适应单元格大小</param>
        /// <param name="ReadingOrder">文本顺序</param>
        /// <param name="MergeCells">是否合并单元格</param>
        /// <param name="IsTextStyle">是否是竖排版文本</param>
        public void SetRangesFormat(string SheetName, ExcelRange erange, string NumberFormatLocal, Excel.XlHAlign HAlign, Excel.XlVAlign VAlign, bool WrapText, int Orientation, bool AddIndent, int IndentLevel, bool ShrinkToFit, Excel.Constants ReadingOrder, bool MergeCells, bool IsTextStyle)
        {
            Excel.Range rg = GetRange(GetSheet(SheetName), erange);
            rg.NumberFormatLocal = NumberFormatLocal;
            rg.HorizontalAlignment = HAlign;
            rg.VerticalAlignment = VAlign;
            rg.WrapText = WrapText;
            rg.Orientation = Orientation;
            rg.AddIndent = AddIndent;
            rg.IndentLevel = IndentLevel;
            rg.ShrinkToFit = ShrinkToFit;
            rg.ReadingOrder = (int)ReadingOrder;
            rg.MergeCells = MergeCells;
            if (IsTextStyle)
                rg.Orientation = -4166;
        }
        /// <summary>
        /// 设置区域内单元格的格式
        /// </summary>
        /// <param name="SheetName"></param>
        /// <param name="erange"></param>
        /// <param name="NumberFormatLocal"></param>
        public void SetRangesFormat(int SheetIndex, ExcelRange erange, string NumberFormatLocal)
        {
            Excel.Range rg = GetRange(GetSheet(SheetIndex), erange);
            rg.NumberFormatLocal = NumberFormatLocal;
            this.Save();
        }
        /// <summary>
        /// 设置指定的列的宽度
        /// </summary>
        /// <param name="SheetIndex"></param>
        /// <param name="erange"></param>
        /// <param name="ColsWidth"></param>
        public void SetRangesFormat(int SheetIndex, ExcelRange erange, int ColsWidth)
        {
            Excel.Range rg = GetRange(GetSheet(SheetIndex), erange);

            rg.ColumnWidth = ColsWidth;
            this.Save();
        }



        /// <summary>
        /// 合并单元格
        /// </summary>
        /// <param name="erange">指定区域</param>
        public void AddRanges(ExcelRange erange)
        {
            Excel.Range rg = GetRange(GetSheet(), erange);
            rg.MergeCells = true;
        }
        /// <summary>
        /// 合并单元格
        /// </summary>
        /// <param name="SheetName"></param>
        /// <param name="erange"></param>
        public void AddRanges(string SheetName, ExcelRange erange)
        {
            Excel.Range rg = GetRange(GetSheet(SheetName), erange);
            rg.MergeCells = true;
        }
        /// <summary>
        /// 合并单元格
        /// </summary>
        /// <param name="SheetIndex"></param>
        /// <param name="erange"></param>
        public void AddRanges(int SheetIndex, ExcelRange erange)
        {
            Excel.Range rg = GetRange(GetSheet(SheetIndex), erange);
            rg.MergeCells = true;
        }
        /// <summary>
        /// 在当前活动的worksheet，在指定的行添加删除若干行
        /// </summary>
        /// <param name="n">操作的行数，大于0添加，小于0减少</param>
        /// <param name="Index">行序号</param>
        public void AddLines(int n, int Index)
        {
            Excel.Worksheet worksheet = GetSheet();
            if (n < 0)
            {
                n = n * (-1);
                for (int i = 0; i < n; i++)
                {
                    Excel.Range range = (Excel.Range)worksheet.get_Range(worksheet.Cells[Index, 1], worksheet.Cells[Index, 256]);
                    range.Delete(Excel.XlDeleteShiftDirection.xlShiftUp);
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    Excel.Range range = (Excel.Range)worksheet.get_Range(worksheet.Cells[Index, 1], worksheet.Cells[Index, 256]);
                    //张相涛2008年3月24日加 修改数值型的格式
                    range.NumberFormat = "@";
                    range.Insert(Excel.XlInsertShiftDirection.xlShiftDown, obj);
                }
            }
        }
        /// <summary>
        /// 在指定的sheet上，在指定的行添加删除若干行
        /// </summary>
        /// <param name="SheetIndex">从1开始的sheet的索引序号</param>
        /// <param name="n">操作的行数，大于0添加，小于0减少</param>
        /// <param name="Index">行序号</param>
        public void AddLines(int SheetIndex, int n, int Index)
        {
            Excel.Worksheet worksheet = GetSheet(SheetIndex);
            if (n < 0)
            {
                n = n * (-1);
                for (int i = 0; i < n; i++)
                {
                    Excel.Range range = (Excel.Range)worksheet.Lines(Index);
                    range.Delete(Excel.XlDeleteShiftDirection.xlShiftUp);
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    Excel.Range range = (Excel.Range)worksheet.Lines(Index);
                    range.Insert(Excel.XlInsertShiftDirection.xlShiftDown, obj);
                }
            }
        }
        /// <summary>
        /// 在指定的sheet上，在指定的行添加删除若干行
        /// </summary>
        /// <param name="SheetName">sheet的名字</param>
        /// <param name="n">操作的行数，大于0添加，小于0减少</param>
        /// <param name="Index">行序号</param>
        public void AddLines(string SheetName, int n, int Index)
        {
            Excel.Worksheet worksheet = GetSheet(SheetName);
            if (n < 0)
            {
                n = n * (-1);
                for (int i = 0; i < n; i++)
                {
                    Excel.Range range = (Excel.Range)worksheet.Lines(Index);
                    range.Delete(Excel.XlDeleteShiftDirection.xlShiftUp);
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    Excel.Range range = (Excel.Range)worksheet.Lines(Index);
                    range.Insert(Excel.XlInsertShiftDirection.xlShiftDown, obj);
                }
            }
        }

        /// <summary>
        /// 在当前活动的worksheet，从指定的行列开始插入一个<see cref="DataTable"/>对象
        /// </summary>
        /// <param name="Row">起始行</param>
        /// <param name="Col">起始列</param>
        /// <param name="Data"><see cref="DataTable"/>对象</param>
        /// <param name="IsContainTitle">插入时是否插入列名</param>
        public void SetTableText(int Row, int Col, DataTable Data, bool IsContainTitle)
        {
            Excel.Worksheet worksheet = GetSheet();
            if (IsContainTitle)//带有列名
            {
                int iMax = Data.Rows.Count + 1;
                int jMax = Data.Columns.Count;
                for (int j = Row; j <= jMax; j++)
                    worksheet.Cells[Row, j] = Data.Columns[j - 1].Caption;
                for (int i = Row + 1; i <= iMax; i++)
                {
                    for (int j = Col; j <= jMax; j++)
                    {
                        worksheet.Cells[i, j] = Data.Rows[i - Row - 1][j - 1].ToString();
                    }
                }
            }
            else
            {
                int iMax = Data.Rows.Count;
                int jMax = Data.Columns.Count;
                for (int i = Row; i <= iMax; i++)
                {
                    for (int j = Col; j <= jMax; j++)
                    {
                        worksheet.Cells[i, j] = Data.Rows[i - Row - 1][j - 1].ToString();
                    }
                }
            }
        }
        /// <summary>
        /// 在指定的sheet中，从指定的行列开始插入一个<see cref="DataTable"/>对象
        /// </summary>
        /// <param name="SheetIndex">从1开始的sheet的索引序号</param>
        /// <param name="Row">起始行</param>
        /// <param name="Col">起始列</param>
        /// <param name="Data"><see cref="DataTable"/>对象</param>
        /// <param name="IsContainTitle">插入时是否插入列名</param>
        public void SetTableText(int SheetIndex, int Row, int Col, DataTable Data, bool IsContainTitle)
        {
            Excel.Worksheet worksheet = GetSheet(SheetIndex);
            if (IsContainTitle)//带有列名
            {
                int iMax = Data.Rows.Count + 1;
                int jMax = Data.Columns.Count;
                for (int j = Row; j <= jMax; j++)
                    worksheet.Cells[1, j] = Data.Columns[j - 1].Caption;
                for (int i = Row + 1; i <= iMax; i++)
                {
                    for (int j = Col; j <= jMax; j++)
                    {
                        worksheet.get_Range(worksheet.Cells[i, j], worksheet.Cells[i, j]).NumberFormatLocal = "@";
                        worksheet.Cells[i, j] = Data.Rows[i - Row - 1][j - 1].ToString();
                    }
                }
            }
            else
            {
                int iMax = Data.Rows.Count;
                int jMax = Data.Columns.Count;
                for (int i = Row; i <= iMax; i++)
                {
                    for (int j = Col; j <= jMax; j++)
                    {
                        worksheet.get_Range(worksheet.Cells[i, j], worksheet.Cells[i, j]).NumberFormatLocal = "@";
                        worksheet.Cells[i, j] = Data.Rows[i - Row - 1][j - 1].ToString();
                    }
                }
            }
        }
        /// <summary>
        /// 在指定的sheet中，从指定的行列开始插入一个<see cref="DataTable"/>对象
        /// </summary>
        /// <param name="SheetIndex">从1开始的sheet的索引序号</param>
        /// <param name="Row">起始行</param>
        /// <param name="Col">起始列</param>
        /// <param name="Data"><see cref="DataTable"/>对象</param>
        /// <param name="sTableExplain">表格的表头</param>
        /// <param name="IsContainTitle">插入时是否插入列名</param>
        public void SetTableText(int SheetIndex, int Row, int Col, DataTable Data, string sTableExplain, bool IsContainTitle)
        {
            Excel.Worksheet worksheet = GetSheet(SheetIndex);
            if (IsContainTitle)//带有列名
            {
                int iMax = Data.Rows.Count;
                int jMax = Data.Columns.Count;
                ExcelRange ERange = new ExcelRange(1, 1, 1, Data.Columns.Count);
                HeaderStyle st = new HeaderStyle();
                st.IsBold = true;
                st.IsExcelAutoLine = true;
                st.Regular = true;
                st.XlsTextPos = ExcelTextPos.Regular;

                worksheet.Cells[1, 1] = sTableExplain.ToString();
                SetRangesFormat(worksheet, ERange, st);

                for (int j = Col; j <= jMax; j++)
                    worksheet.Cells[2, j] = Data.Columns[j - 1].Caption;
                for (int i = Row + 1; i <= iMax + Row; i++)
                {
                    for (int j = Col; j <= jMax + Col - 1; j++)
                    {
                        worksheet.get_Range(worksheet.Cells[i, j], worksheet.Cells[i, j]).NumberFormatLocal = "@";
                        worksheet.Cells[i, j] = Data.Rows[i - Row - 1][j - Col].ToString();
                    }
                }
            }
            else
            {
                int iMax = Data.Rows.Count;
                int jMax = Data.Columns.Count;
                #region 标题
                ExcelRange ERange = new ExcelRange(1, 1, 1, Data.Columns.Count);
                HeaderStyle st = new HeaderStyle();
                st.IsBold = true;
                st.IsExcelAutoLine = true;
                st.Regular = true;
                st.XlsTextPos = ExcelTextPos.Regular;

                worksheet.Cells[1, 1] = sTableExplain.ToString();
                SetRangesFormat(worksheet, ERange, st);
                #endregion
                for (int i = Row; i <= iMax; i++)
                {
                    for (int j = Col; j <= jMax; j++)
                    {
                        worksheet.get_Range(worksheet.Cells[i, j], worksheet.Cells[i, j]).NumberFormatLocal = "@";
                        worksheet.Cells[i, j] = Data.Rows[i - Row - 1][j - 1].ToString();
                    }
                }
            }
        }
        /// <summary>
        /// 在指定的sheet中，从指定的行列开始插入一个<see cref="DataTable"/>对象
        /// </summary>
        /// <param name="SheetName">sheet的名字</param>
        /// <param name="Row">起始行</param>
        /// <param name="Col">起始列</param>
        /// <param name="Data"><see cref="DataTable"/>对象</param>
        /// <param name="IsContainTitle">插入时是否插入列名</param>
        public void SetTableText(string SheetName, int Row, int Col, DataTable Data, bool IsContainTitle)
        {
            Excel.Worksheet worksheet = GetSheet(SheetName);
            if (IsContainTitle)//带有列名
            {
                int iMax = Data.Rows.Count + 1;
                int jMax = Data.Columns.Count;
                for (int j = Row; j <= jMax; j++)
                    worksheet.Cells[1, j] = Data.Columns[j - 1].Caption;
                for (int i = Row + 1; i <= iMax; i++)
                {
                    for (int j = Col; j <= jMax; j++)
                    {
                        worksheet.Cells[i, j] = Data.Rows[i - Row - 1][j - 1].ToString();
                    }
                }
            }
            else
            {
                int iMax = Data.Rows.Count;
                int jMax = Data.Columns.Count;
                for (int i = Row; i <= iMax; i++)
                {
                    for (int j = Col; j <= jMax; j++)
                    {
                        worksheet.Cells[i, j] = Data.Rows[i - Row - 1][j - 1].ToString();
                    }
                }
            }
        }

        /// <summary>
        /// 将文件另存为新的Excel文件
        /// </summary>
        /// <param name="FileName">文件名</param>
        /// <param name="IsDel">是否先删除目标文件</param>
        public void SaveAs(string FileName, bool IsDel)
        {
            try
            {
                if (IsDel)
                    System.IO.File.Delete(FileName);
            }
            catch { }
            workbook.SaveAs(FileName, Excel.XlFileFormat.xlWorkbookNormal, obj, obj, obj, obj, Excel.XlSaveAsAccessMode.xlNoChange, obj, obj, obj, obj, obj);
        }
        /// <summary>
        /// 利用反射方法调用SaveAs，可以适用于不同的版本
        /// </summary>
        /// <param name="FileName">文件名</param>
        /// <param name="IsDel">是否删除</param>
        /// <param name="booInvoke">是否用反射</param>
        public void SaveAs(string FileName, bool IsDel, bool booInvoke)
        {
            try
            {
                if (IsDel)
                    System.IO.File.Delete(FileName);
            }
            catch { }

            object[] Parameters = new Object[7];
            Parameters[0] = FileName;
            Parameters[1] = Excel.XlFileFormat.xlExcel9795;
            Parameters[2] = Missing.Value;
            Parameters[3] = Missing.Value;
            Parameters[4] = Missing.Value;
            Parameters[5] = Missing.Value;
            Parameters[6] = Excel.XlSaveAsAccessMode.xlNoChange;
            workbook.GetType().InvokeMember("SaveAs", BindingFlags.InvokeMethod, null, workbook, Parameters);
            //app.Visible = true; //如果只想用程序控制该excel而不想让用户操作时候，可以设置为false

        }
        /// <summary>
        /// 将文件另存为网页
        /// </summary>
        /// <param name="FileName">文件名</param>
        /// <param name="IsDel">是否先删除目标文件</param>
        public void SaveAsHtml(string FileName, bool IsDel)
        {
            try
            {
                if (IsDel)
                    System.IO.File.Delete(FileName);
            }
            catch { }
            workbook.SaveAs(FileName, Excel.XlFileFormat.xlHtml, obj, obj, obj, obj, Excel.XlSaveAsAccessMode.xlNoChange, obj, obj, obj, obj, obj);
        }
        /// <summary>
        /// 保存文件
        /// </summary>
        public void Save()
        {
            workbook.Save();

        }

        /// <summary>
        /// 插入一个图表数据
        /// </summary>
        /// <param name="datatable">框架及数据，该框架必须符合一定的规范</param>
        /// <param name="Title">图表名称</param>
        /// <param name="Text">文本信息</param>
        /// <param name="SheetName">sheet名字</param>
        /// <param name="PicSheetName">用于放置图表的sheet页名字</param>
        /// <param name="Width">图表宽</param>
        /// <param name="Height">图表高</param>
        public void AddExcelChart(DataTable datatable, string Title, string Text, string SheetName, string PicSheetName, int Width, int Height)
        {
            Excel.Worksheet xlWorksheet = (Excel.Worksheet)workbook.Sheets[SheetName];
            Excel.Worksheet xlWorksheet2 = (Excel.Worksheet)workbook.Sheets[PicSheetName];
            Excel.Chart xlChart = null;
            //清除默认数据
            object Cell1 = xlWorksheet.Cells[1, 1];
            object Cell2 = xlWorksheet.Cells[datatable.Rows.Count + 1, datatable.Columns.Count + 1];

            Excel.Range picRange = xlWorksheet.get_Range(Cell1, Cell2);
            picRange.Clear();
            Excel.ChartObject co = (Excel.ChartObject)xlWorksheet2.ChartObjects(1);
            co.Select(obj);
            xlChart = co.Chart;


            object PlotBy = Excel.XlRowCol.xlColumns;
            xlChart.SetSourceData(picRange, PlotBy);

            Cell2 = xlWorksheet.Cells[datatable.Rows.Count + 1, 1];
            xlWorksheet.get_Range(Cell1, Cell2).NumberFormat = "@";
            //设置图表标题
            xlChart.HasTitle = true;
            xlChart.ChartTitle.Text = Title;

            xlWorksheet2.Shapes.Item(1).Width = Width;
            xlWorksheet2.Shapes.Item(1).Height = Height;

            //xlChart.PlotArea.Width=Width;
            //xlChart.PlotArea.Height=Height;

            int posR = 1;
            int posC = 1;
            for (int i = 0; i < datatable.Columns.Count; i++)
            {
                ((Excel.Range)xlWorksheet.Cells[posR++, posC]).Value2 = datatable.Columns[i].ColumnName;
                for (int j = 0; j < datatable.Rows.Count; j++)
                {
                    ((Excel.Range)xlWorksheet.Cells[posR++, posC]).Value2 = datatable.Rows[j][i];
                }
                posC++;
                posR = 1;
            }
        }
        /// <summary>
        /// 插入一个图表数据
        /// </summary>
        /// <param name="datatable">框架及数据，该框架必须符合一定的规范</param>
        /// <param name="Title">图表名称</param>
        /// <param name="Text">文本信息</param>
        /// <param name="SheetName">sheet名字</param>
        /// <param name="PicSheetName">用于放置图表的sheet页名字</param>
        public void AddExcelChart(DataTable datatable, string Title, string Text, string SheetName, string PicSheetName)
        {
            Excel.Worksheet xlWorksheet = (Excel.Worksheet)workbook.Sheets[SheetName];
            Excel.Worksheet xlWorksheet2 = (Excel.Worksheet)workbook.Sheets[PicSheetName];
            Excel.Chart xlChart = null;
            //清除默认数据
            object Cell1 = xlWorksheet.Cells[1, 1];
            object Cell2 = xlWorksheet.Cells[datatable.Rows.Count + 1, datatable.Columns.Count + 1];

            Excel.Range picRange = xlWorksheet.get_Range(Cell1, Cell2);
            picRange.Clear();
            Excel.ChartObject co = (Excel.ChartObject)xlWorksheet2.ChartObjects(1);
            co.Select(obj);
            xlChart = co.Chart;
            //xlChart = (Excel.Chart)app.Charts[1];


            object PlotBy = Excel.XlRowCol.xlColumns;
            xlChart.SetSourceData(picRange, PlotBy);

            Cell2 = xlWorksheet.Cells[datatable.Rows.Count + 1, 1];
            xlWorksheet.get_Range(Cell1, Cell2).NumberFormat = "@";
            //设置图表标题
            xlChart.HasTitle = true;
            xlChart.ChartTitle.Text = Title;

            int posR = 1;
            int posC = 1;
            for (int i = 0; i < datatable.Columns.Count; i++)
            {
                ((Excel.Range)xlWorksheet.Cells[posR++, posC]).Value2 = datatable.Columns[i].ColumnName;
                for (int j = 0; j < datatable.Rows.Count; j++)
                {
                    ((Excel.Range)xlWorksheet.Cells[posR++, posC]).Value2 = datatable.Rows[j][i];
                }
                posC++;
                posR = 1;
            }
        }

        /// <summary>
        /// 关闭所使用的Excel进程
        /// </summary>
        public void Release()
        {
            if (app != null)
            {
                app.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
            }
            if (workbook != null)
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
            workbook = null;
            app = null;
            GC.Collect();
        }

        /// <summary>
        /// 获得当前选择区域的信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetSelected()
        {
            try
            {
                DataTable dt = new DataTable();
                Excel.Worksheet xlWorksheet = GetSheet();
                Excel.Range rg = (Excel.Range)app.Selection;
                //Excel.Range rg = xlWorksheet.UsedRange;
                if (rg.Columns.Count == rg.Rows.Count)
                {
                    dt.Columns.Add();
                    DataRow dr = dt.NewRow();
                    dr[0] = rg.Value2;
                    dt.Rows.Add(dr);
                    return dt;
                }
                Array ar = (Array)rg.Value2;
                for (int i = 0; i < rg.Columns.Count; i++)
                    dt.Columns.Add();
                for (int i = 0; i < rg.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    for (int j = 0; j < rg.Columns.Count; j++)
                    {
                        dr[j] = ar.GetValue(i + 1, j + 1);
                    }
                    dt.Rows.Add(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                string a = ex.Message;
                return null;
            }
        }
        /// <summary>
        /// 得到指定Sheet页中的数据到DataTable
        /// </summary>
        /// <param name="isheetIndex"></param>
        /// <returns></returns>
        public DataTable GetSelected(int isheetIndex)
        {
            int icols = 0;
            try
            {
                DataTable dt = new DataTable();
                Excel.Worksheet xlWorksheet = GetSheet(isheetIndex);
                Excel.Range rg = xlWorksheet.UsedRange;
                //if (rg.Columns.Count == rg.Rows.Count)
                //{
                //    dt.Columns.Add();
                //    DataRow dr = dt.NewRow();
                //    dr[0] = rg.Value2;
                //    dt.Rows.Add(dr);
                //    return dt;
                //}
                if (isheetIndex == 2)
                {
                    xlWorksheet.get_Range(xlWorksheet.Cells[1, 8], xlWorksheet.Cells[xlWorksheet.UsedRange.Rows.Count, 8]).NumberFormatLocal = "m-d;@";
                    this.Save();
                }
                Array ar = (Array)rg.Value2;

                for (int i = 1; i <= rg.Columns.Count; i++)
                    dt.Columns.Add(ar.GetValue(1, i).ToString());


                for (int i = 2; i <= rg.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    for (int j = 1; j <= rg.Columns.Count; j++)
                    {

                        if (isheetIndex == 2 && j == 8)
                        {
                            if (ar.GetValue(i, j) != null)
                            {
                                string str = ar.GetValue(i, j).ToString();
                                if (str != "")
                                {
                                    icols = i;
                                    try
                                    {
                                        DateTime Dt = Convert.ToDateTime("1900-1-1");
                                        DateTime dTemp = Dt.Date.AddDays(Convert.ToInt32(str) - 2);
                                        dr[j - 1] = dTemp.ToString("M-d");
                                    }
                                    catch
                                    {
                                        dr[j - 1] = str;
                                    }
                                }
                            }

                        }
                        else
                            dr[j - 1] = ar.GetValue(i, j);
                    }
                    dt.Rows.Add(dr);
                }
                dt.AcceptChanges();
                return dt;
            }
            catch (Exception ex)
            {
                string a = ex.Message;
                return null;
            }
        }
        /// <summary>
        /// 得到指定Sheet页中的数据到DataTable
        /// </summary>
        /// <param name="isheetIndex">Sheete页序号</param>
        /// <param name="sYC">对应的‘印次’字段名</param>
        /// <param name="src_no1">对应的‘订单编号’字段名</param>
        /// <returns></returns>
        public DataTable GetSelectedByIndex(int isheetIndex)
        {
            
            try
            {
                DataTable dt = new DataTable();
                Excel.Worksheet xlWorksheet = GetSheet(isheetIndex);
                Excel.Range rg = xlWorksheet.UsedRange;
                //if (rg.Columns.Count == rg.Rows.Count)
                //{
                //    dt.Columns.Add();
                //    DataRow dr = dt.NewRow();
                //    dr[0] = rg.Value2;
                //    dt.Rows.Add(dr);
                //    return dt;
                //}

                Array ar = (Array)rg.Value2;
                for (int i = 1; i <= rg.Columns.Count; i++)
                {
                    if (ar.GetValue(1, i) == null)
                    {
                        dt.Columns.Add("=无效列" + i.ToString());
                    }
                    else
                    {
                        dt.Columns.Add(ar.GetValue(1, i).ToString());
                    }
                }

                for (int i = 2; i <= rg.Rows.Count; i++)
                {

                    DataRow dr = dt.NewRow();
                    for (int j = 1; j <= rg.Columns.Count; j++)
                    {
                        dr[j - 1] = ar.GetValue(i, j);
                    }
                    dt.Rows.Add(dr);
                }
                dt.AcceptChanges();
                return dt;
            }
            catch (Exception)
            {
                //throw;
              //  string a = ex.Message;
                return null;
            }
        }
        /// <summary>
        /// 得到指定Sheet页中的数据到DataTable框架
        /// </summary>
        /// <param name="isheetIndex">Sheet索引</param>
        /// <returns></returns>
        public DataTable GetSelectedTableCloneByIndex(int isheetIndex)
        {
            //int icols = 0;
            try
            {
                DataTable dt = new DataTable();
                Excel.Worksheet xlWorksheet = GetSheet(isheetIndex);
                Excel.Range rg = xlWorksheet.UsedRange;
                Array ar = (Array)rg.Value2;
                for (int i = 1; i <= rg.Columns.Count; i++)
                {
                    if (ar.GetValue(1, i) == null)
                    {
                        dt.Columns.Add("=无效列" + i.ToString());
                    }
                    else
                    {
                        dt.Columns.Add(ar.GetValue(1, i).ToString());
                    }
                }

                //for (int i = 2; i <= rg.Rows.Count; i++)
                //{

                //    DataRow dr = dt.NewRow();
                //    for (int j = 1; j <= rg.Columns.Count; j++)
                //    {
                //        dr[j - 1] = ar.GetValue(i, j);
                //    }
                //    dt.Rows.Add(dr);
                //}
                dt.AcceptChanges();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
               // string a = ex.Message;
              //  return null;
            }
        }
        /// <summary>
        /// 获得当前选择区域的信息以及左上角单元格的位置信息
        /// </summary>
        /// <param name="Row"></param>
        /// <param name="Col"></param>
        /// <returns></returns>
        public DataTable GetSelected(out int Row, out int Col)
        {
            try
            {
                DataTable dt = new DataTable();
                Excel.Worksheet xlWorksheet = GetSheet();
                Excel.Range rg = (Excel.Range)app.Selection;
                if (rg.Columns.Count == rg.Rows.Count)
                {
                    dt.Columns.Add();
                    DataRow dr = dt.NewRow();
                    dr[0] = rg.Value2;
                    dt.Rows.Add(dr);
                    Row = rg.Row;
                    Col = rg.Column;
                    return dt;
                }
                Array ar = (Array)rg.Value2;
                for (int i = 0; i < rg.Columns.Count; i++)
                    dt.Columns.Add();
                for (int i = 0; i < rg.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    for (int j = 0; j < rg.Columns.Count; j++)
                    {
                        dr[j] = ar.GetValue(i + 1, j + 1);
                    }
                    dt.Rows.Add(dr);
                }
                Row = rg.Row;
                Col = rg.Column;
                return dt;
            }
            catch (Exception ex)
            {
                string a = ex.Message;
                Row = 0;
                Col = 0;
                return null;
            }
        }
        /// <summary>
        /// 获取选规定sheet的区域
        /// </summary>
        /// <returns></returns>
        public ExcelRange GetSelectRange()
        {
            return GetSelectRange(GetSheet());
        }
        /// <summary>
        /// 根据Sheet索引，获取选规定sheet的区域
        /// </summary>
        /// <returns></returns>
        public ExcelRange GetSelectRange(int iSheetIndex)
        {
            return GetSelectRange(GetSheet(iSheetIndex));
        }
        private ExcelRange GetSelectRange(Excel.Worksheet xlWorksheet)
        {
            //xlWorksheet.Cells.Select;
            //Excel.Range eg = ((Excel.Range)xlWorksheet.Application.Selection);
            Excel.Range eg = xlWorksheet.UsedRange;
            if (eg == null)
                return null;
            return ExcelRange.GetExcelRange(eg.Row, eg.Column, eg.Columns.Count, eg.Rows.Count);
        }
        /// <summary>
        /// 获取行数和列数
        /// </summary>
        /// <param name="iSheetIndex"></param>
        /// <param name="iRows"></param>
        /// <param name="iCols"></param>
        public void GetSelectRowCol(int iSheetIndex, out int iRows, out int iCols)
        {
            Excel.Worksheet xlWorksheet = GetSheet(iSheetIndex);
            Excel.Range rg = xlWorksheet.UsedRange;

            iRows = rg.Rows.Count;
            iCols = rg.Columns.Count;
        }

        /// <summary>
        /// 清除一定区域的标注
        /// </summary>
        /// <param name="erange"></param>
        public void ClearRemark(ExcelRange erange)
        {
            ClearRemark(GetSheet(), erange);
        }
        /// <summary>
        /// 清除一定区域的标注
        /// </summary>
        /// <param name="index"></param>
        /// <param name="erange"></param>
        public void ClearRemark(int index, ExcelRange erange)
        {
            ClearRemark(GetSheet(index), erange);
        }
        /// <summary>
        /// 清除一定区域的标注
        /// </summary>
        /// <param name="sheetname"></param>
        /// <param name="erange"></param>
        public void ClearRemark(string sheetname, ExcelRange erange)
        {
            ClearRemark(GetSheet(sheetname), erange);
        }
        /// <summary>
        /// 清楚所有标注
        /// </summary>
        public void ClearAllRemark()
        {
            foreach (Excel.Worksheet ws in workbook.Sheets)
            {
                ws.UsedRange.ClearComments();
            }
        }

        private void ClearRemark(Excel.Worksheet ws, ExcelRange erange)
        {
            GetRange(ws, erange).ClearComments();
        }

        /// <summary>
        /// 内部测试函数调用会发生意想不到的结果。禁止使用
        /// </summary>
        public void test()
        {
            try
            {
                workbook = app.Workbooks.Add(obj);
                this.SaveAs("C:\new.xls", true);
            }
            catch (Exception ex)
            {
                string a = ex.Message;
            }
        }

        /// <summary>
        /// 设定是否现实警告信息
        /// </summary>
        /// <param name="f"></param>
        public void SetDisplayAlerts(bool f)
        {
            app.DisplayAlerts = f;
        }
        /// <summary>
        /// 清楚制定页的表格内容
        /// </summary>
        public void ClearSheetText(int Index)
        {
            ((Excel.Range)GetSheet(Index).Cells.get_Range("A1", "AA200")).Clear();
        }
        /// <summary>
        /// 删除指定的sheet页
        /// </summary>
        /// <param name="Index"></param>
        public void DeleteSheet(int Index)
        {
            GetSheet(Index).Delete();
        }
        /// <summary>
        /// 删除指定的sheet页
        /// </summary>
        /// <param name="Name"></param>
        public void DeleteSheet(string Name)
        {
            GetSheet(Name).Delete();
        }
        /// <summary>
        /// 保留指定sheet，删除，其余的。
        /// </summary>
        /// <param name="Index"></param>
        public void DeleteSheetExcept(int Index)
        {
            if ((this.workbook.Sheets.Count > 1) && (Index <= this.workbook.Sheets.Count) && (Index > 0))
            {
                ArrayList ins = new ArrayList();
                for (int i = 1; i <= workbook.Sheets.Count; i++)
                {
                    if (Index != i)
                        ins.Add(i);
                }
                int[] rms = new int[ins.Count];
                ins.CopyTo(rms);
                ((Excel.Sheets)workbook.Sheets[rms]).Delete();
                return;
            }
            throw new Exception("当前Excel只包含一个sheet页，不能删除。或者给出的索引无效。");
        }
        /// <summary>
        /// 保留指定sheet，删除，其余的。
        /// </summary>
        /// <param name="sheetname"></param>
        public void DeleteSheetExcept(string sheetname)
        {
            if (IsHaveSheet(sheetname))
            {
                int index = GetSheet(sheetname).Index;
                DeleteSheetExcept(index);
                return;
            }
            throw new Exception("当前Excel中找不到名为" + sheetname + "的sheet页");
        }
        /// <summary>
        /// 添加一张sheet页
        /// </summary>
        /// <param name="Name"></param>
        public void AddSheet(string Name)
        {
            workbook.Sheets.Add(obj, (Excel.Worksheet)workbook.Sheets[workbook.Sheets.Count], obj, obj);
            ((Excel.Worksheet)workbook.Sheets[workbook.Sheets.Count]).Name = Name;
        }

        /// <summary>
        /// 根据<see cref="HeaderStyle"/>样式，设定Excel单元格格式。
        /// </summary>
        /// <param name="ws">sheet页</param>
        /// <param name="erange"><see cref="ExcelRange"/>描述的一个区域</param>
        /// <param name="hs"><see cref="HeaderStyle"/>决定的样式</param>
        private void SetRangesFormat(Excel.Worksheet ws, ExcelRange erange, HeaderStyle hs)
        {
            Excel.Range rg = GetRange(ws, erange);
            rg.NumberFormatLocal = "@";
            rg.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rg.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            rg.WrapText = hs.IsExcelAutoLine;
            rg.AddIndent = false;
            rg.IndentLevel = 0;
            rg.ShrinkToFit = false;
            rg.ReadingOrder = (int)Excel.Constants.xlContext;
            rg.MergeCells = true;
            if (hs.iIs横向文本)
                rg.Orientation = -4166;
            else
                rg.Orientation = 0;
            rg.Font.Name = hs.FontName;
            rg.Font.ColorIndex = 3;
            rg.Font.Bold = hs.IsBold;
            rg.Font.Italic = hs.IsItalic;
            rg.Font.Underline = hs.IsUnderLine;
            rg.Font.Strikethrough = hs.IsStrikeout;
            rg.Font.Size = hs.FontSize;
            rg.Font.Subscript = (hs.XlsTextPos == ExcelTextPos.Down);
            rg.Font.Superscript = (hs.XlsTextPos == ExcelTextPos.Up);
            rg.Font.Color = GetBGRFromColor(hs.FontColor);
            if (!hs.BackColor.IsEmpty)
            {
                rg.Interior.Color = GetBGRFromColor(hs.BackColor);
                rg.Interior.Pattern = Excel.XlPattern.xlPatternSolid;
                rg.Interior.PatternColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic;
            }
            else
                rg.Interior.ColorIndex = -4142;
        }

        /// <summary>
        /// 根据<see cref="Color"/>结构获得一个24位整数，按照BBGGRR的形式组成
        /// </summary>
        /// <param name="c">颜色</param>
        /// <returns>24位整数</returns>
        private int GetBGRFromColor(Color c)
        {
            int res = 0;
            res += c.B;
            res <<= 8;
            res += c.G;
            res <<= 8;
            res += c.R;
            return res;
        }

        #region CDattable
        /// <summary>
        /// 添加一个列标题，并且根据表头的深度自动合并单元格
        /// </summary>
        /// <param name="ws">sheet页</param>
        /// <param name="h">列标题集合</param>
        /// <param name="r">行序号</param>
        /// <param name="c">列序号</param>
        /// <param name="iMaxDep">标题的最大深度</param>
        /// <param name="iDep">当前深度</param>
        private void AddCHeader(Excel.Worksheet ws, Header h, int r, int c, int iMaxDep, int iDep)
        {
            ws.Cells[r, c] = h.Text;
            //无子列
            if (h.sHeaders.Count == 0)
            {
                SetRangesFormat(ws, ExcelRange.GetExcelRange(r, c, h.HeadsCount, iMaxDep - iDep + 1), h.HeaderStyle);
            }
            else
            {
                SetRangesFormat(ws, ExcelRange.GetExcelRange(r, c, h.HeadsCount, 1), h.HeaderStyle);
                AddCHeader(ws, h.sHeaders, r + 1, c);
            }
        }

        /// <summary>
        /// 添加一个行标题，并且根据表头的深度自动合并单元格
        /// </summary>
        /// <param name="ws">sheet页</param>
        /// <param name="h">列标题集合</param>
        /// <param name="r">行序号</param>
        /// <param name="c">列序号</param>
        /// <param name="iMaxDep">标题的最大深度</param>
        /// <param name="iDep">当前深度</param>
        private void AddRHeader(Excel.Worksheet ws, Header h, int r, int c, int iMaxDep, int iDep)
        {
            ws.Cells[r, c] = h.Text;
            //无子列
            if (h.sHeaders.Count == 0)
            {
                SetRangesFormat(ws, ExcelRange.GetExcelRange(r, c, iMaxDep - iDep + 1, h.HeadsCount), h.HeaderStyle);
            }
            else
            {
                SetRangesFormat(ws, ExcelRange.GetExcelRange(r, c, 1, h.HeadsCount), h.HeaderStyle);
                AddRHeader(ws, h.sHeaders, r, c + 1);
            }
        }

        /// <summary>
        /// 添加子列标题集合，并且根据表头的深度自动合并单元格
        /// </summary>
        /// <param name="ws">sheet页</param>
        /// <param name="hs">列标题集合</param>
        /// <param name="r">行序号</param>
        /// <param name="c">列序号</param>
        /// <param name="iMaxDep">标题的最大深度</param>
        /// <param name="iDep">当前深度</param>
        private void AddCHeader(Excel.Worksheet ws, HeaderCollection hs, int r, int c, int iMaxDep, int iDep)
        {
            int w = hs.HeadsCount;
            int h = hs.MaxDep;
            int startr = r;
            int startc = c;
            for (int i = 0; i < hs.Count; i++)
            {
                AddCHeader(ws, hs[i], r, c, hs[i].MaxDep, 1);
                c += hs[i].HeadsCount;
            }
        }

        /// <summary>
        /// 添加子行标题集合，并且根据表头的深度自动合并单元格
        /// </summary>
        /// <param name="ws">sheet页</param>
        /// <param name="hs">列标题集合</param>
        /// <param name="r">行序号</param>
        /// <param name="c">列序号</param>
        /// <param name="iMaxDep">标题的最大深度</param>
        /// <param name="iDep">当前深度</param>
        private void AddRHeader(Excel.Worksheet ws, HeaderCollection hs, int r, int c, int iMaxDep, int iDep)
        {
            int w = hs.HeadsCount;
            int h = hs.MaxDep;
            int startr = r;
            int startc = c;
            string[,] data = new string[w, h];
            for (int i = 0; i < hs.Count; i++)
            {
                AddRHeader(ws, hs[i], r, c, hs[i].MaxDep, 1);
                r += hs[i].HeadsCount;
            }
        }


        /// <summary>
        /// 添加一个完整的列标题
        /// </summary>
        /// <param name="ws">sheet页</param>
        /// <param name="hs">标题集合</param>
        /// <param name="r">从1开始的行索引</param>
        /// <param name="c">从1开始的列索引</param>
        private void AddCHeader(Excel.Worksheet ws, HeaderCollection hs, int r, int c)
        {
            int w = hs.HeadsCount;
            int h = hs.MaxDep;
            int startr = r;
            int startc = c;
            for (int i = 0; i < hs.Count; i++)
            {
                AddCHeader(ws, hs[i], r, c, hs[i].MaxDep, 1);
                c += hs[i].HeadsCount;
            }
        }
        /// <summary>
        /// 添加一个完整的行标题
        /// </summary>
        /// <param name="ws">sheet页</param>
        /// <param name="hs">标题集合</param>
        /// <param name="r">从1开始的行索引</param>
        /// <param name="c">从1开始的列索引</param>
        private void AddRHeader(Excel.Worksheet ws, HeaderCollection hs, int r, int c)
        {
            int w = hs.HeadsCount;
            int h = hs.MaxDep;
            int startr = r;
            int startc = c;
            string[,] data = new string[w, h];
            for (int i = 0; i < hs.Count; i++)
            {
                AddRHeader(ws, hs[i], r, c, hs[i].MaxDep, 1);
                r += hs[i].HeadsCount;
            }
        }

        /// <summary>
        /// 将一个<see cref="CDataTable"/>对象加入到Excel文件中.
        /// </summary>
        /// <param name="ws">sheet页</param>
        /// <param name="cdata">数据</param>
        /// <param name="r">行</param>
        /// <param name="c">列</param>
        /// <param name="IsFast">是否快速检索</param>
        /// <param name="str">默认字符串</param>
        /// <param name="GetDataStyle">检索数据的方式</param>
        /// <param name="fc">执行插入数据时的委托调用</param>
        private void AddCDataTable(Excel.Worksheet ws, CDataTable cdata, int r, int c, string str, bool IsFast, GetCDataTableData GetDataStyle, AddCDataTableOptForCell fc)
        {
            int maxw, maxh, dataw, datah, rdep, cdep;
            dataw = cdata.ColHeaders.HeadsCount;
            datah = cdata.RowHeaders.HeadsCount;
            rdep = cdata.RowHeaders.MaxDep;
            cdep = cdata.ColHeaders.MaxDep;
            maxw = dataw + rdep;
            maxh = datah + cdep;
            ExcelRange er = ExcelRange.GetExcelRange(r, c, maxw, maxh);
            Excel.Range rg = GetRange(ws, er);
            rg.Cells.Clear();
            rg.NumberFormatLocal = "@";
            if (cdata.ColHeaders != null)
            {
                AddCHeader(ws, cdata.ColHeaders, r, c + rdep);
            }
            if (cdata.RowHeaders != null)
            {
                AddRHeader(ws, cdata.RowHeaders, r + cdep, c);
            }
            if (cdata.RowHeaders == null || cdata.ColHeaders == null)
                return;
            DataTable[,] strdatas = cdata.GetDatasTable(IsFast, GetDataStyle);
            if (strdatas == null)
                return;

            int iws = strdatas.GetLength(1);
            int ihs = strdatas.GetLength(0);
            int strr, strc;
            strr = cdep + 1;
            strc = rdep + 1;
            StringCollection[] rowtext = cdata.RowHeaders.AllDataTexts;
            StringCollection[] rowvalue = cdata.RowHeaders.AllDataValues;
            StringCollection[] coltext = cdata.ColHeaders.AllDataTexts;
            StringCollection[] colvalue = cdata.ColHeaders.AllDataValues;
            for (int i = 0; i < ihs; i++)
            {
                for (int j = 0; j < iws; j++)
                {
                    if (fc != null)
                    {
                        fc((Excel.Range)ws.Cells[strr + i, strc + j], strdatas[i, j], rowtext[i], rowvalue[i], coltext[j], colvalue[j]);
                    }
                    else
                    {
                        try
                        {
                            ws.Cells[strr + i, strc + j] = strdatas[i, j].Rows[0][cdata.DataValueText].ToString();
                        }
                        catch
                        {
                            ws.Cells[strr + i, strc + j] = str;
                        }
                    }
                }
            }
            rg.Columns.AutoFit();
            rg.Rows.AutoFit();
        }


        /// <summary>
        /// 在当前的sheet页插入一个<see cref="CDataTable"/>对象。
        /// </summary>
        /// <param name="cdata">架构数据</param>
        /// <param name="r">从1开始的行</param>
        /// <param name="c">从1开始的列</param>
        /// <param name="str">没有数据时的默认字符串</param>
        /// <param name="IsFast">是否快速查找</param>
        /// <param name="GetDataStyle">用于检索数据的方式</param>
        public void AddCDataTable(CDataTable cdata, int r, int c, string str, bool IsFast, GetCDataTableData GetDataStyle)
        {
            AddCDataTable(GetSheet(), cdata, r, c, str, IsFast, GetDataStyle, null);
        }

        /// <summary>
        /// 在当前的sheet页插入一个<see cref="CDataTable"/>对象。
        /// </summary>
        /// <param name="cdata">架构数据</param>
        /// <param name="r">从1开始的行</param>
        /// <param name="c">从1开始的列</param>
        /// <param name="str">没有数据时的默认字符串</param>
        /// <param name="IsFast">是否快速查找</param>
        /// <param name="GetDataStyle">用于检索数据的方式</param>
        /// <param name="fc">1个针对数据插入的委托调用</param>
        public void AddCDataTable(CDataTable cdata, int r, int c, string str, bool IsFast, GetCDataTableData GetDataStyle, AddCDataTableOptForCell fc)
        {
            AddCDataTable(GetSheet(), cdata, r, c, str, IsFast, GetDataStyle, fc);
        }

        /// <summary>
        /// 在指定的sheet页插入一个<see cref="CDataTable"/>对象。
        /// </summary>
        /// <param name="Index">sheet页的索引</param>
        /// <param name="cdata">架构数据</param>
        /// <param name="r">从1开始的行</param>
        /// <param name="c">从1开始的列</param>
        /// <param name="str">没有数据时的默认字符串</param>
        /// <param name="IsFast">是否快速查找</param>
        /// <param name="GetDataStyle">用于检索数据的方式</param>
        public void AddCDataTable(int Index, CDataTable cdata, int r, int c, string str, bool IsFast, GetCDataTableData GetDataStyle)
        {
            AddCDataTable(GetSheet(Index), cdata, r, c, str, IsFast, GetDataStyle, null);
        }

        /// <summary>
        /// 在指定的sheet页插入一个<see cref="CDataTable"/>对象。
        /// </summary>
        /// <param name="Index">sheet页的索引</param>
        /// <param name="cdata">架构数据</param>
        /// <param name="r">从1开始的行</param>
        /// <param name="c">从1开始的列</param>
        /// <param name="str">没有数据时的默认字符串</param>
        /// <param name="IsFast">是否快速查找</param>
        /// <param name="GetDataStyle">用于检索数据的方式</param>
        /// <param name="fc">1个针对数据插入的委托调用</param>
        public void AddCDataTable(int Index, CDataTable cdata, int r, int c, string str, bool IsFast, GetCDataTableData GetDataStyle, AddCDataTableOptForCell fc)
        {
            AddCDataTable(GetSheet(Index), cdata, r, c, str, IsFast, GetDataStyle, fc);
        }

        /// <summary>
        /// 在指定的sheet页插入一个<see cref="CDataTable"/>对象。
        /// </summary>
        /// <param name="SheetName">sheet页的名字</param>
        /// <param name="cdata">架构数据</param>
        /// <param name="r">从1开始的行</param>
        /// <param name="c">从1开始的列</param>
        /// <param name="str">没有数据时的默认字符串</param>
        /// <param name="IsFast">是否快速查找</param>
        /// <param name="GetDataStyle">用于检索数据的方式</param>
        public void AddCDataTable(string SheetName, CDataTable cdata, int r, int c, string str, bool IsFast, GetCDataTableData GetDataStyle)
        {
            AddCDataTable(GetSheet(SheetName), cdata, r, c, str, IsFast, GetDataStyle, null);
        }

        /// <summary>
        /// 在指定的sheet页插入一个<see cref="CDataTable"/>对象。
        /// </summary>
        /// <param name="SheetName">sheet页的名字</param>
        /// <param name="cdata">架构数据</param>
        /// <param name="r">从1开始的行</param>
        /// <param name="c">从1开始的列</param>
        /// <param name="str">没有数据时的默认字符串</param>
        /// <param name="IsFast">是否快速查找</param>
        /// <param name="GetDataStyle">用于检索数据的方式</param>
        /// <param name="fc">1个针对数据插入的委托调用</param>
        public void AddCDataTable(string SheetName, CDataTable cdata, int r, int c, string str, bool IsFast, GetCDataTableData GetDataStyle, AddCDataTableOptForCell fc)
        {
            AddCDataTable(GetSheet(SheetName), cdata, r, c, str, IsFast, GetDataStyle, fc);
        }

        /// <summary>
        /// 将<see cref="CDataTable"/>插入Excel时，执行每个插入数据操作的委托调用。
        /// </summary>
        public delegate void AddCDataTableOptForCell(Excel.Range Cell, DataTable CellData, StringCollection RowTexts, StringCollection RowValues, StringCollection ColTexts, StringCollection ColValues);
        #endregion
    }
}
