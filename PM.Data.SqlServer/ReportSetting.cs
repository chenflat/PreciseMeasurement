using System;
using System.Data;
using System.Data.Common;

using PM.Data;
using PM.Config;
using PM.Common;
using PM.Entity;

namespace PM.Data.SqlServer
{
    public partial class DataProvider : IDataProvider
    {
        /// <summary>
        /// 创建报表设置
        /// </summary>
        /// <param name="reportSettingInfo">报表设置</param>
        /// <returns></returns>
        public bool CreateReportSetting(ReportSettingInfo reportSettingInfo) {
            DbParameter[] parms = { 
                                  DbHelper.MakeInParam("@USERID", (DbType)SqlDbType.Int, 4, reportSettingInfo.UserId),
                                  DbHelper.MakeInParam("@ORGID", (DbType)SqlDbType.VarChar, 8, reportSettingInfo.Orgid),
                                  DbHelper.MakeInParam("@SETTINGNAME", (DbType)SqlDbType.VarChar, 30, reportSettingInfo.SettingName),
                                  DbHelper.MakeInParam("@DESCRIPTION", (DbType)SqlDbType.VarChar, 2000, reportSettingInfo.Description),
                                  DbHelper.MakeInParam("@POINTNUM", (DbType)SqlDbType.VarChar, 2000, reportSettingInfo.Pointnum),
                                  DbHelper.MakeInParam("@ISITEMFORMULA", (DbType)SqlDbType.Int, 4, reportSettingInfo.IsItemFormula?1:0),
                                  DbHelper.MakeInParam("@FORMULA", (DbType)SqlDbType.VarChar, 200, reportSettingInfo.Formula)
                                  };
            string commandText = string.Format("INSERT INTO [{0}REPORTSETTING] ([USERID],[ORGID],[SETTINGNAME],[DESCRIPTION],[POINTNUM],[ISITEMFORMULA],[FORMULA])" +
              "VALUES(@USERID,@ORGID,@SETTINGNAME,@DESCRIPTION,@POINTNUM,@ISITEMFORMULA,@FORMULA);", BaseConfigs.GetTablePrefix);

            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms) > 0;
        }

        /// <summary>
        /// 删除指定用户的报表设置
        /// </summary>
        /// <param name="settingname">设置名称</param>
        /// <param name="userid">用户ID</param>
        /// <param name="orgid">组织机构ID</param>
        /// <returns></returns>
        public bool DeleteReportSettingByUserId(string settingname, int userid, string orgid) {

            DbParameter[] parms = { 
                                  DbHelper.MakeInParam("@SETTINGNAME", (DbType)SqlDbType.VarChar, 30, settingname),
                                  DbHelper.MakeInParam("@USERID", (DbType)SqlDbType.Int, 4, userid),
                                  DbHelper.MakeInParam("@ORGID", (DbType)SqlDbType.VarChar, 8, orgid)
                                  };
            string commandText = string.Format("DELETE FROM [{0}REPORTSETTING] WHERE [SETTINGNAME]=@SETTINGNAME AND [USERID]=@USERID AND [ORGID]=@ORGID", BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms) > 0;
        }

        /// <summary>
        /// 删除指定用户的报表设置
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="orgid">组织机构ID</param>
        /// <returns></returns>
        public bool DeleteReportSettingByUserId(int userid, string orgid) {
            DbParameter[] parms = { 
                                  DbHelper.MakeInParam("@USERID", (DbType)SqlDbType.Int, 4, userid),
                                  DbHelper.MakeInParam("@ORGID", (DbType)SqlDbType.VarChar, 8, orgid)
                                  };
            string commandText = string.Format("DELETE FROM [{0}REPORTSETTING] WHERE [USERID]=@USERID AND [ORGID]=@ORGID", BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms) > 0;
        }

        /// <summary>
        /// 获取指定用户的报表设置
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="orgid">组织机构ID</param>
        /// <returns></returns>
        public IDataReader FindReportSettingByUserId(int userid, string orgid) {
            DbParameter[] parms = { 
                                  DbHelper.MakeInParam("@USERID", (DbType)SqlDbType.Int, 4, userid),
                                  DbHelper.MakeInParam("@ORGID", (DbType)SqlDbType.VarChar, 8, orgid)
                                  };
            string commandText = string.Format("select * from [{0}REPORTSETTING] WHERE [USERID]=@USERID AND [ORGID]=@ORGID", BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteReader(CommandType.Text, commandText, parms);
        }

        /// <summary>
        /// 获取指定用户的报表设置
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="orgid">组织机构ID</param>
        /// <returns></returns>
        public IDataReader FindReportSettingByUserId(string settingname, int userid, string orgid) {
            DbParameter[] parms = { 
                                  DbHelper.MakeInParam("@SETTINGNAME", (DbType)SqlDbType.VarChar, 30, settingname),
                                  DbHelper.MakeInParam("@USERID", (DbType)SqlDbType.Int, 4, userid),
                                  DbHelper.MakeInParam("@ORGID", (DbType)SqlDbType.VarChar, 8, orgid)
                                  };
            string commandText = string.Format("select * from [{0}REPORTSETTING] WHERE [SETTINGNAME]=@SETTINGNAME and [USERID]=@USERID AND [ORGID]=@ORGID", BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteReader(CommandType.Text, commandText, parms);
        }

        /// <summary>
        /// 获取指定用户报表设置名称列表
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="orgid">组织机构ID</param>
        /// <returns></returns>
        public IDataReader GetReportSettingNameList(int userid, string orgid) {
            DbParameter[] parms = { 
                                  DbHelper.MakeInParam("@USERID", (DbType)SqlDbType.Int, 4, userid),
                                  DbHelper.MakeInParam("@ORGID", (DbType)SqlDbType.VarChar, 8, orgid)
                                  };
            string commandText = string.Format("select distinct SETTINGNAME from [{0}REPORTSETTING] WHERE [USERID]=@USERID AND [ORGID]=@ORGID", BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteReader(CommandType.Text, commandText, parms);
        }
    }
}
