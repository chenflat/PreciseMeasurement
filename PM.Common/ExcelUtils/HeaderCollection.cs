using System;
using System.Collections.Specialized;

namespace PM.Common.ExcelUtils
{
    /// <summary>
    /// HeaderCollection 的摘要说明。
    /// </summary>
    public class HeaderCollection : NameObjectCollectionBase
    {
        /// <summary>
        /// 
        /// </summary>
        public HeaderCollection()
        {
        }
        internal Header owner;
        /// <summary>
        /// 返回拥有当前实例的<see cref="Header"/>。如果不存在则为null。
        /// </summary>
        public Header Owner
        {
            get { return owner; }
        }
        /// <summary>
        /// 添加标题
        /// </summary>
        /// <param name="header"></param>
        public void Add(Header header)
        {
            header.parent = this.owner;
            this.BaseAdd(header.Name, header);
        }
        /// <summary>
        /// 移除指定标题
        /// </summary>
        /// <param name="Name"></param>
        public void Remove(string Name)
        {
            this.BaseRemove(Name);
        }
        /// <summary>
        /// 移除指定位置的标题
        /// </summary>
        /// <param name="Index"></param>
        public void RemoveAt(int Index)
        {
            this.BaseRemoveAt(Index);
        }
        /// <summary>
        /// 返回指定的标题
        /// </summary>
        public Header this[int Index]
        {
            get { return (Header)this.BaseGet(Index); }
        }
        /// <summary>
        /// 返回指定的标题
        /// </summary>
        public Header this[string Name]
        {
            get { return (Header)this.BaseGet(Name); }
        }
        /// <summary>
        /// 移除所有的标题
        /// </summary>
        public void Clear()
        {
            this.BaseClear();
        }
        /// <summary>
        /// 获得标题集合的所有标题数目
        /// </summary>
        public int HeadsCount
        {
            get
            {
                int res = 0;
                for (int i = 0; i < this.Count; i++)
                    res += this[i].HeadsCount;
                return res;
            }
        }
        /// <summary>
        /// 获得标题集合中的最大深度集合
        /// </summary>
        public int MaxDep
        {
            get
            {
                int res = 0;
                for (int i = 0; i < this.Count; i++)
                    res = this[i].MaxDep > res ? this[i].MaxDep : res;
                return res;
            }
        }
        /// <summary>
        /// 顺序获得所有的Header节点的值集合
        /// </summary>
        public StringCollection[] AllDataCfgs
        {
            get
            {
                StringCollection[] stss = new StringCollection[HeadsCount];
                int pos = 0;
                for (int i = 0; i < this.Count; i++)
                {
                    StringCollection[] temp = this[i].AllDataCfgs;
                    for (int j = 0; j < temp.Length; j++)
                        stss[pos++] = temp[j];
                }
                return stss;
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
                int pos = 0;
                for (int i = 0; i < this.Count; i++)
                {
                    StringCollection[] temp = this[i].AllDataValues;
                    for (int j = 0; j < temp.Length; j++)
                        stss[pos++] = temp[j];
                }
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
                int pos = 0;
                for (int i = 0; i < this.Count; i++)
                {
                    StringCollection[] temp = this[i].AllDataTexts;
                    for (int j = 0; j < temp.Length; j++)
                        stss[pos++] = temp[j];
                }
                return stss;
            }
        }

        private object tag;
        /// <summary>
        /// 获取或设置Tag
        /// </summary>
        public object Tag
        {
            get { return tag; }
            set { tag = value; }
        }
    }
}
