using System;
using System.Collections.Generic;
using System.Text;
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
        /// 创建分析设置信息
        /// </summary>
        /// <param name="analyzeSettingInfo"></param>
        /// <returns></returns>
        public bool CreateAnalyzeSettingInfo(AnalyzeSettingInfo analyzeSettingInfo) {
            DbParameter[] parms = { 
                                  DbHelper.MakeInParam("@TYPE", (DbType)SqlDbType.VarChar, 30, analyzeSettingInfo.Type.ToString()),
                                  DbHelper.MakeInParam("@SETTINGNAME", (DbType)SqlDbType.VarChar, 30, analyzeSettingInfo.SettingName),
                                  DbHelper.MakeInParam("@DESCRIPTION", (DbType)SqlDbType.VarChar, 100, analyzeSettingInfo.Description),
                                  DbHelper.MakeInParam("@TABLENAME", (DbType)SqlDbType.VarChar, 50, analyzeSettingInfo.TableName),
                                  DbHelper.MakeInParam("@USERID", (DbType)SqlDbType.Int, 4, analyzeSettingInfo.UserId),
                                  DbHelper.MakeInParam("@ORGID", (DbType)SqlDbType.VarChar, 8, analyzeSettingInfo.Orgid)
                                  };
            string commandText = string.Format("INSERT INTO [{0}ANALYZESETTING] ([TYPE],[SETTINGNAME],[DESCRIPTION],[TABLENAME],[USERID],[ORGID])" +
              "VALUES(@TYPE,@SETTINGNAME,@DESCRIPTION,@TABLENAME,@USERID,@ORGID);", BaseConfigs.GetTablePrefix);

            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms) > 0;
        }

        /// <summary>
        /// 更新分析设置信息
        /// </summary>
        /// <param name="analyzeSettingInfo"></param>
        /// <returns></returns>
        public bool UpdateAnalyzeSettingInfo(AnalyzeSettingInfo analyzeSettingInfo)
        {
            DbParameter[] parms = { 
                                  DbHelper.MakeInParam("@SETTINGID", (DbType)SqlDbType.Int, 4, analyzeSettingInfo.SettingId),
                                  DbHelper.MakeInParam("@TYPE", (DbType)SqlDbType.VarChar, 30, analyzeSettingInfo.Type.ToString()),
                                  DbHelper.MakeInParam("@SETTINGNAME", (DbType)SqlDbType.VarChar, 30, analyzeSettingInfo.SettingName),
                                  DbHelper.MakeInParam("@DESCRIPTION", (DbType)SqlDbType.VarChar, 100, analyzeSettingInfo.Description),
                                  DbHelper.MakeInParam("@TABLENAME", (DbType)SqlDbType.VarChar, 50, analyzeSettingInfo.TableName),
                                  DbHelper.MakeInParam("@USERID", (DbType)SqlDbType.Int, 4, analyzeSettingInfo.UserId),
                                  DbHelper.MakeInParam("@ORGID", (DbType)SqlDbType.VarChar, 8, analyzeSettingInfo.Orgid)
                                  };
            string commandText = string.Format("UPDATE [{0}ANALYZESETTING]  SET [TYPE]=@TYPE,[SETTINGNAME]=@SETTINGNAME,"+
                "[DESCRIPTION]=@DESCRIPTION,[TABLENAME]=@TABLENAME,[USERID]=@USERID,[ORGID]=@ORGID" +
                " WHERE [SETTINGID]=@SETTINGID;", BaseConfigs.GetTablePrefix);

            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms) > 0;
        }

        /// <summary>
        /// 删除分析设置信息
        /// </summary>
        /// <param name="analyzeSettingInfo"></param>
        /// <returns></returns>
        public bool DeleteAnalyzeSettingInfoBySettingName(SettingType type, string settingname, int userid,string orgid)
        {
            DbParameter[] parms = { 
                                 
                                  DbHelper.MakeInParam("@TYPE", (DbType)SqlDbType.VarChar, 30, type.ToString()),
                                  DbHelper.MakeInParam("@SETTINGNAME", (DbType)SqlDbType.VarChar, 30, settingname),
                                  DbHelper.MakeInParam("@USERID", (DbType)SqlDbType.Int, 4, userid),
                                  DbHelper.MakeInParam("@ORGID", (DbType)SqlDbType.VarChar, 8, orgid)
                                  };
            string commandText = string.Format("DELETE FROM [{0}ANALYZESETTING] WHERE [TYPE]=@TYPE AND [SETTINGNAME]=@SETTINGNAME AND [USERID]=@USERID AND [ORGID]=@ORGID", BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms) > 0;
        }

        /// <summary>
        /// 删除用户设置
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="orgid">组织机构ID</param>
        /// <returns></returns>
        public bool DeleteAnalyzeSettingInfoByUser(int userid, string orgid,string tablename) {
            DbParameter[] parms = { 
                                  DbHelper.MakeInParam("@USERID", (DbType)SqlDbType.Int, 4, userid),
                                  DbHelper.MakeInParam("@ORGID", (DbType)SqlDbType.VarChar, 8, orgid),
                                  DbHelper.MakeInParam("@TABLENAME", (DbType)SqlDbType.VarChar, 50, tablename)
                                  };
            string commandText = string.Format("DELETE FROM [{0}ANALYZESETTING] WHERE [USERID]=@USERID AND [ORGID]=@ORGID and TABLENAME=@TABLENAME", BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms) > 0;
        }


        /// <summary>
        /// 查找分析设置信息
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="orgid">组织机构ID</param>
        /// <returns>分析设置信息</returns>
        public IDataReader FindAnalyzeSettingInfo(int userid, string orgid, string tablename)
        {
            DbParameter[] parms = { 
                                  DbHelper.MakeInParam("@USERID", (DbType)SqlDbType.Int, 4, userid),
                                  DbHelper.MakeInParam("@ORGID", (DbType)SqlDbType.VarChar, 8, orgid),
                                  DbHelper.MakeInParam("@TABLENAME", (DbType)SqlDbType.VarChar, 50, tablename)
                                  };
            string commandText = string.Format("select * from [{0}ANALYZESETTING] WHERE [USERID]=@USERID AND [ORGID]=@ORGID and ISNULL(TABLENAME,'')=@TABLENAME", BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteReader(CommandType.Text, commandText, parms);
        }
    }
}
