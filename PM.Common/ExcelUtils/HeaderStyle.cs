using System;
using System.Drawing;

namespace PM.Common.ExcelUtils
{
    /// <summary>
    /// Excel单元格文本的位置上标、下标、常规。
    /// </summary>
    public enum ExcelTextPos
    {
        /// <summary>
        /// 常规
        /// </summary>
        Regular,
        /// <summary>
        /// 上标
        /// </summary>
        Up,
        /// <summary>
        /// 下标
        /// </summary>
        Down
    }
    /// <summary>
    /// 描述标题样式的类
    /// </summary>
    public class HeaderStyle
    {
        /// <summary>
        /// 默认方式初始化实例对象（宋体12旁黑色常规字体，横向文本，如果是Excel则不自动换行，
        /// </summary>
        public HeaderStyle()
        {
            xlsTextPos = ExcelTextPos.Regular;
            IsExcelAutoLine = false;
            Is横向文本 = false;
            fontstyle = FontStyle.Regular;
            fontsize = 12;
            fontName = "宋体";
            fontColor = Color.Black;
            backColor = Color.Empty;
        }
        /// <summary>
        /// Excel文字位置（上标，下标，常规）
        /// </summary>
        private ExcelTextPos xlsTextPos;
        /// <summary>
        ///  设定Excel单元格是否是自动换行，此属性仅当在Excel表格中展现数据时有效。
        /// </summary>
        private bool isExcelAutoLine;
        /// <summary>
        /// 文字样式的属性（包括粗体、斜体、下划线、删除线的组合）
        /// </summary>
        private FontStyle fontstyle;
        /// <summary>
        /// 获取或设置FontStyle，该字段在Html呈现时无效
        /// </summary>
        public FontStyle FontStyle
        {
            set { fontstyle = value; }
            get { return fontstyle; }
        }
        /// <summary>
        /// 字体的大小。单位像素
        /// </summary>
        private int fontsize;
        /// <summary>
        /// 获取或设置字体的大小。单位像素。
        /// </summary>
        public int FontSize
        {
            get { return fontsize; }
            set { fontsize = value; }
        }
        /// <summary>
        /// 字体的名字
        /// </summary>
        private string fontName;
        /// <summary>
        /// 获取或设置字体的名称
        /// </summary>
        public string FontName
        {
            get { return fontName; }
            set { fontName = value; }
        }
        /// <summary>
        /// 获取或设置文字的颜色
        /// </summary>
        private Color fontColor;
        /// <summary>
        /// 获取或设置文字的颜色
        /// </summary>
        public Color FontColor
        {
            get { return fontColor; }
            set { fontColor = value; }
        }
        private Color backColor;
        /// <summary>
        /// 获取或设置背景的颜色
        /// </summary>
        public Color BackColor
        {
            get { return backColor; }
            set { backColor = value; }
        }
        /// <summary>
        /// 文字的排列方向
        /// </summary>
        private bool Is横向文本;
        /// <summary>
        /// 获取或设置Excel单元格文本的位置，此属性仅当在Excel表格中展现数据时有效。
        /// </summary>
        public ExcelTextPos XlsTextPos
        {
            get { return xlsTextPos; }
            set { xlsTextPos = value; }
        }

        /// <summary>
        /// 获取或设置一个bool值，决定Excel单元格是否是自动换行，此属性仅当在Excel表格中展现数据时有效。
        /// </summary>
        public bool IsExcelAutoLine
        {
            get { return isExcelAutoLine; }
            set { isExcelAutoLine = value; }
        }
        /// <summary>
        /// 获取或设置一个bool值，决定文本是否含有删除线。
        /// </summary>
        public bool IsStrikeout
        {
            get { return (fontstyle & FontStyle.Strikeout) == FontStyle.Strikeout; }
            set
            {
                if (value)
                    fontstyle |= FontStyle.Strikeout;
                else
                    fontstyle &= (~FontStyle.Strikeout);
            }
        }
        /// <summary>
        /// 获取或设置一个bool值，决定文本是否为粗体。
        /// </summary>
        public bool IsBold
        {
            get { return (fontstyle & FontStyle.Bold) == FontStyle.Bold; }
            set
            {
                if (value)
                    fontstyle |= FontStyle.Bold;
                else
                    fontstyle &= (~FontStyle.Bold);
            }
        }
        /// <summary>
        /// 获取或设置一个bool值，决定文本是否为斜体。
        /// </summary>
        public bool IsItalic
        {
            get { return (fontstyle & FontStyle.Italic) == FontStyle.Italic; }
            set
            {
                if (value)
                    fontstyle |= FontStyle.Italic;
                else
                    fontstyle &= (~FontStyle.Italic);
            }
        }
        /// <summary>
        /// 获取或设置一个bool值，决定文本是否含有下划线。
        /// </summary>
        public bool IsUnderLine
        {
            get { return (fontstyle & FontStyle.Underline) == FontStyle.Underline; }
            set
            {
                if (value)
                    fontstyle |= FontStyle.Underline;
                else
                    fontstyle &= (~FontStyle.Underline);
            }
        }
        /// <summary>
        /// 获取或设置一个bool值，决定文本是否是常规文本。
        /// </summary>
        public bool Regular
        {
            get { return fontstyle == 0; }
            set { fontstyle = FontStyle.Regular; }
        }
        /// <summary>
        /// 文本的方向
        /// </summary>
        public bool iIs横向文本
        {
            get { return Is横向文本; }
            set { Is横向文本 = value; }
        }

        /// <summary>
        /// 复制一个完全相同的<see cref="HeaderStyle"/>对象.
        /// </summary>
        /// <returns></returns>
        public HeaderStyle Clone()
        {
            HeaderStyle hs = new HeaderStyle();
            hs.IsExcelAutoLine = this.IsExcelAutoLine;
            hs.xlsTextPos = this.xlsTextPos;
            hs.Is横向文本 = this.Is横向文本;
            hs.fontstyle = fontstyle;
            hs.fontsize = fontsize;
            hs.fontName = fontName;
            hs.fontColor = fontColor;
            return hs;
        }
    }
}
