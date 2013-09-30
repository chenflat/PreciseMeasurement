using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

using PM.Common;

namespace PM.Web.controls
{
    public partial class PageControl : System.Web.UI.UserControl
    {
        public event FormEvent.BindData BindDataEvent;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnGo.CausesValidation = false;
        }
        protected override void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void InitializeComponent()
        {
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            this.TxtPageSize.TextChanged += new System.EventHandler(this.TxtPageSize_TextChanged);
            this.Load += new System.EventHandler(this.Page_Load);
        }


        private void btnFirst_Click(object sender, System.EventArgs e)
        {
            this.CurrentPageIndex = 1;
            if (BindDataEvent != null) { BindDataEvent(); }
            this.txtPage.Value = this.CurrentPageIndex.ToString();
        }
        private void btnPrev_Click(object sender, System.EventArgs e)
        {
            this.CurrentPageIndex = this.CurrentPageIndex - 1;
            if (BindDataEvent != null) { BindDataEvent(); }
            this.txtPage.Value = this.CurrentPageIndex.ToString();
        }
        private void btnNext_Click(object sender, System.EventArgs e)
        {
            this.CurrentPageIndex = this.CurrentPageIndex + 1;
            if (BindDataEvent != null) { BindDataEvent(); }
            this.txtPage.Value = this.CurrentPageIndex.ToString();
        }
        private void btnLast_Click(object sender, System.EventArgs e)
        {
            this.CurrentPageIndex = this.PageCount;
            if (BindDataEvent != null) { BindDataEvent(); }
            this.txtPage.Value = this.CurrentPageIndex.ToString();
        }

        protected void btnGo_ServerClick(object sender, EventArgs e)
        {
            GotoPage(this.txtPage);
            if (BindDataEvent != null) { BindDataEvent(); }
            SetButtonEnabled();
        }
        #region 属性设置

        /// <summary>
        /// 每页数量
        /// </summary>
        public int PageSize
        {
            set
            {
                if (value < 1)
                {
                    value = 1;
                }
                TxtPageSize.Text = value.ToString();
            }

            get
            {
                if ((TxtPageSize.Text.Trim() == "") || (TxtPageSize.Text.Trim() == "0"))
                {
                    TxtPageSize.Text = CustomPageSize.ToString();//"15";
                }
                return Convert.ToInt32(TxtPageSize.Text.Trim());

            }
        }

        //  public int CustomPageSize = 15;
        /// <summary>
        /// 自定义初始显示条数
        /// </summary>
        private int _customerpagesize = 15;
        public int CustomPageSize
        {
            set { _customerpagesize = value; }
            get { return _customerpagesize; }
        }



        /// <summary>
        /// 当前页索引
        /// </summary>
        public int CurrentPageIndex
        {
            set
            {
                if (value < 1)
                {
                    value = 1;
                }
                if (value > PageCount)
                {
                    value = PageCount;
                }
                this.hidCurrentPageIndex.Value = value.ToString();
            }

            get
            {
                if (this.hidCurrentPageIndex.Value == "")
                {
                    this.hidCurrentPageIndex.Value = "1";
                }
                else if (Convert.ToInt32(this.hidCurrentPageIndex.Value) > PageCount)
                {
                    hidCurrentPageIndex.Value = PageCount.ToString();
                    txtPage.Value = PageCount.ToString();
                }
                return Convert.ToInt32(this.hidCurrentPageIndex.Value);
            }
        }

        /// <summary>
        /// 总条数
        /// </summary>
        /// 
        public int RecordCount
        {
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                this.hidRecordCount.Value = value.ToString();

            }

            get
            {
                if (this.hidRecordCount.Value == "")
                {
                    this.hidRecordCount.Value = "0";
                }
                return Convert.ToInt32(this.hidRecordCount.Value);
            }
        }
        /// <summary>
        /// 总页数
        /// </summary>
        /// 
        public int PageCount
        {
            get
            {
                int iTotalPage = (RecordCount % PageSize);
                int iRecordCountFull = 0;
                if (iTotalPage == 0)    //能整除
                {
                    iRecordCountFull = RecordCount;
                }
                else
                {
                    iRecordCountFull = RecordCount + this.PageSize - iTotalPage;    //不能整除加多一页数量减去余数
                }
                int iPageCount = iRecordCountFull / PageSize;
                if (iPageCount < 1) { iPageCount = 1; }
                return iPageCount;
            }
        }

        #endregion


        /// <summary>
        /// GotoPage
        /// 跳转至指定页
        /// </summary>
        /// 

        public void GotoPage(System.Web.UI.HtmlControls.HtmlInputText txt)
        {
            if (!IsNumber(txt.Value))
            {
                this.CurrentPageIndex = 1;
            }
            else
            {
                if (Convert.ToInt32(txt.Value) < 1)
                {
                    this.CurrentPageIndex = 1;
                }
                else
                {
                    if (Convert.ToInt32(txt.Value) > this.PageCount)
                    {
                        this.CurrentPageIndex = this.PageCount;
                    }
                    else
                    {
                        this.CurrentPageIndex = Convert.ToInt32(txt.Value);
                    }
                }
            }
            txt.Value = this.CurrentPageIndex.ToString();
        }


        /// <summary>
        /// 
        /// 显示页信息
        /// </summary>
        /// 
        public void SetPageLabel(int iCurrentPageRecord)
        {
            if (iCurrentPageRecord == 0)
            {
                this.lblPageInfo.Text = "第1页/共1页";
            }
            else
            {
                this.lblPageInfo.Text = "共<strong><font color='blue'>" + this.RecordCount.ToString() + "</font></strong>条记录，第" + this.CurrentPageIndex.ToString() + "页/共" + this.PageCount.ToString() + "页";
            }
            SetButtonEnabled();
        }

        public void ShowPageButton()
        {
            this.btnFirst.Enabled = false;
            this.btnPrev.Enabled = false;
            this.btnNext.Enabled = false;
            this.btnLast.Enabled = false;
            this.btnGo.Disabled = true;
            this.lblPageInfo.Text = "第1页/共1页";
        }

        protected void SetButtonEnabled()
        {
            //对分页按钮的控制
            if (CurrentPageIndex == 1 && PageCount > 1)
            {
                btnFirst.Enabled = false;
                btnPrev.Enabled = false;

                btnNext.Enabled = true;
                btnLast.Enabled = true;
            }
            else if (CurrentPageIndex == PageCount && PageCount > 1)
            {
                btnFirst.Enabled = true;
                btnPrev.Enabled = true;

                btnNext.Enabled = false;
                btnLast.Enabled = false;
            }
            else if (CurrentPageIndex == PageCount && PageCount == 1)
            {
                btnFirst.Enabled = false;
                btnPrev.Enabled = false;

                btnNext.Enabled = false;
                btnLast.Enabled = false;
            }
            else
            {
                btnFirst.Enabled = true;
                btnPrev.Enabled = true;

                btnNext.Enabled = true;
                btnLast.Enabled = true;
            }
            //跳转按钮的控制
            if (RecordCount == 0)
            {
                btnGo.Disabled = true;
            }
            else
            {
                btnGo.Disabled = false;
            }
        }


        protected void TxtPageSize_TextChanged(object sender, EventArgs e)
        {

            if (BindDataEvent != null) { BindDataEvent(); }
            if (TxtPageSize.Text.Trim() != "")
            {
                PageSize = Convert.ToInt32(TxtPageSize.Text.Trim());
            }
            else
            {
                PageSize = 15;
            }
        }



        /// <summary>
        /// 判断给定的字符串(strNumber)是否是数值型
        /// </summary>
        /// <param name="strNumber">要确认的字符串</param>
        /// <returns>是则返加true 不是则返回 false</returns>
        private bool IsNumber(string strNumber)
        {
            return new Regex(@"^([0-9])[0-9]*(\.\w*)?$").IsMatch(strNumber);
        }
    }
}