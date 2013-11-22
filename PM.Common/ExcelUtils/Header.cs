using System;
using System.Collections.Specialized;

namespace PM.Common.ExcelUtils
{

    /// <summary>
    /// 用来描述多层表头的数据结构。
    /// </summary>
    public class Header
    {
        static int index = 0;
        private HeaderStyle headStyle;
        /// <summary>
        /// 获取或设置当前标题的样式
        /// </summary>
        public HeaderStyle HeaderStyle
        {
            get { return headStyle; }
            set { headStyle = value; }
        }
        private HeaderCollection headerCollection;
        /// <summary>
        /// 实例化一个标题对象
        /// </summary>
        /// <param name="Text">标题文本</param>
        /// <param name="DataText">标题的数据字段</param>
        /// <param name="DataValue">标题的数据字段值</param>
        public Header(string Text, string DataText, string DataValue)
        {
            headerCollection = new HeaderCollection();
            headerCollection.owner = this;
            text = Text;
            dataValue = DataValue;
            dataText = DataText;
            Name = "Header" + index.ToString();
            index++;
            headStyle = new HeaderStyle();
        }
        /// <summary>
        /// 获得下一级标题集合
        /// </summary>
        public HeaderCollection sHeaders
        {
            get { return headerCollection; }
            set { headerCollection = value; headerCollection.owner = this; }
        }
        private string name;
        /// <summary>
        /// 获取或设置字段的名字
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string text;
        /// <summary>
        /// 获取或设置标题文本
        /// </summary>
        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        private string dataValue;
        private string dataText;
        /// <summary>
        /// 获取或设定标题对应的字段
        /// </summary>
        public string DataText
        {
            get { return dataText; }
            set { dataText = value.Trim(); }
        }
        /// <summary>
        /// 获取或设定标题字段的值
        /// </summary>
        public string DataValue
        {
            get { return dataValue; }
            set { dataValue = value.Trim(); }
        }
        /// <summary>
        /// 获得当前标题涉及到的总列数
        /// </summary>
        public int HeadsCount
        {
            get
            {
                if (sHeaders.Count == 0)
                    return 1;
                else
                {
                    return sHeaders.HeadsCount;
                }
            }
        }
        /// <summary>
        /// 获得当前标题中子标题的最大深度
        /// </summary>
        public int MaxDep
        {
            get
            {
                if (sHeaders.Count == 0)
                    return 1;
                else
                {
                    int res = 0;
                    for (int i = 0; i < sHeaders.Count; i++)
                    {
                        res = sHeaders[i].MaxDep > res ? sHeaders[i].MaxDep : res;
                    }
                    return res + 1;
                }
            }
        }
        /// <summary>
        /// 获得所有列的DataValues集合
        /// </summary>
        public StringCollection[] AllDataValues
        {
            get
            {
                StringCollection[] stss = new StringCollection[HeadsCount];
                for (int i = 0; i < stss.Length; i++)
                {
                    stss[i] = new StringCollection();
                }
                GetValuesHeader(this, stss, 0);
                return stss;
            }
        }
        /// <summary>
        /// 获得所有列的DataTexts集合
        /// </summary>
        public StringCollection[] AllDataTexts
        {
            get
            {
                StringCollection[] stss = new StringCollection[HeadsCount];
                for (int i = 0; i < stss.Length; i++)
                {
                    stss[i] = new StringCollection();
                }
                GetTextsHeader(this, stss, 0);
                return stss;
            }
        }
        /// <summary>
        /// 获得所有列的数据选择条件
        /// </summary>
        public StringCollection[] AllDataCfgs
        {
            get
            {
                StringCollection[] stsV = AllDataValues;
                StringCollection[] stsT = AllDataTexts;
                StringCollection[] stss = new StringCollection[stsT.Length];
                for (int i = 0; i < stss.Length; i++)
                {
                    stss[i] = new StringCollection();
                    for (int j = 0; j < stsT[i].Count; j++)
                    {
                        if (stsT[i][j] != "")
                        {
                            stss[i].Add(stsT[i][j] + "='" + stsV[i][j] + "'");
                        }
                    }
                }
                return stss;
            }
        }
        /// <summary>
        /// 从当前的Header节点获得后面的所有节点的DataText集合
        /// </summary>
        private void GetTextsHeader(Header h, StringCollection[] stss, int stpos)
        {
            int postemp = stpos;
            for (int i = 0; i < h.HeadsCount; i++)
            {
                stss[postemp++].Add(h.dataText.Trim());
            }
            postemp = stpos;
            for (int i = 0; i < h.sHeaders.Count; i++)
            {
                GetTextsHeader(h.sHeaders[i], stss, postemp);
                postemp += h.sHeaders[i].HeadsCount;
            }
        }
        /// <summary>
        /// 从当前的Header节点获得后面的所有节点的DataValue集合
        /// </summary>
        private void GetValuesHeader(Header h, StringCollection[] stss, int stpos)
        {
            int postemp = stpos;
            for (int i = 0; i < h.HeadsCount; i++)
            {
                stss[postemp++].Add(h.dataValue.Trim());
            }
            postemp = stpos;
            for (int i = 0; i < h.sHeaders.Count; i++)
            {
                GetValuesHeader(h.sHeaders[i], stss, postemp);
                postemp += h.sHeaders[i].HeadsCount;
            }
        }
        private object tag;
        /// <summary>
        /// 获取或设置标题的Tag
        /// </summary>
        public object Tag
        {
            get { return tag; }
            set { tag = value; }
        }

        internal Header parent = null;
        /// <summary>
        /// 获取父标题，如果没有则返回null。
        /// </summary>
        public Header Parent
        {
            get { return parent; }
        }
        /// <summary>
        /// 从包含当前的<see cref="Header"/>的<see cref="HeaderCollection"/>中移除出去。
        /// </summary>
        public void Delete()
        {
            if (parent != null)
                parent.sHeaders.Remove(this.name);
        }
    }
    /// <summary>
    /// 用于排序计算的Header的工具结构，没有实用意义
    /// </summary>
    public class WorkForHeader
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Index;
        /// <summary>
        /// 暂存
        /// </summary>
        public object temp;
        /// <summary>
        /// 字标题集合
        /// </summary>
        public StringCollection DataTexts;
        /// <summary>
        /// 
        /// </summary>
        public WorkForHeader()
        {
            Index = -1;
            temp = null;
            DataTexts = new StringCollection();
        }
    }
}
