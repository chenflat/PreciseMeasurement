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
        ///  获取位置
        /// </summary>
        /// <returns></returns>
        public IDataReader FindLocationsList()
        {
            string commandText = string.Format("SELECT {0} FROM [{1}LOCATIONS] ORDER BY [LOCATIONSID] ASC",
                                                  DbFields.LOCATIONS,
                                                  BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteReader(System.Data.CommandType.Text, commandText);
        }

        /// <summary>
        /// 获取位置
        /// </summary>
        /// <param name="orgid">组织机构代码</param>
        /// <returns></returns>
        public IDataReader FindLocationsByOrgId(string orgid)
        {
            string commandText = string.Format("SELECT {0} FROM [{1}LOCATIONS] WHERE ORGID='{2}' ORDER BY [LOCATIONSID] ASC",
                                                 DbFields.LOCATIONS,
                                                 BaseConfigs.GetTablePrefix,
                                                 orgid);
            return DbHelper.ExecuteReader(System.Data.CommandType.Text, commandText);
        }


        /// <summary>
        /// 获取位置
        /// </summary>
        /// <param name="id">获取位置ID</param>
        /// <returns></returns>
        public IDataReader FindLocationById(long id)
        {
            DbParameter param = DbHelper.MakeInParam("@id", (DbType)SqlDbType.Int, 4, id);
            string commandText = string.Format("SELECT {0} FROM [{1}LOCATIONS] WHERE [LOCATIONSID]=@id",
                                                DbFields.LOCATIONS,
                                                BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteReader(CommandType.Text, commandText, param);
        }

        /// <summary>
        /// 获取指定类型的位置
        /// </summary>
        /// <param name="orgid">组织机构代码</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public IDataReader FindLocationsByOrgIdAndType(string orgid, string type)
        {
            string commandText = string.Format("SELECT {0} FROM [{1}LOCATIONS] WHERE ORGID='{2}' and TYPE='{3}' ORDER BY [LOCATIONSID] ASC",
                                               DbFields.LOCATIONS,
                                               BaseConfigs.GetTablePrefix,
                                               orgid,
                                               type);
            return DbHelper.ExecuteReader(System.Data.CommandType.Text, commandText);
        }


        /// <summary>
        /// 新增位置信息
        /// </summary>
        /// <param name="locationInfo">位置信息</param>
        /// <returns>返回位置ID, 如果已存在该位置则返回-1</returns>
        public int CreateLocation(LocationInfo locationInfo)
        {
            DbParameter[] parms = { 
                                  DbHelper.MakeInParam("@LOCATION", (DbType)SqlDbType.VarChar, 12, locationInfo.Location),
                                  DbHelper.MakeInParam("@DESCRIPTION", (DbType)SqlDbType.VarChar, 100, locationInfo.Description),
                                  DbHelper.MakeInParam("@TYPE", (DbType)SqlDbType.VarChar, 10, locationInfo.Type),
                                  DbHelper.MakeInParam("@DISABLED", (DbType)SqlDbType.TinyInt, 1, locationInfo.Disabled),
                                  DbHelper.MakeInParam("@EXTERNALREFID", (DbType)SqlDbType.VarChar, 10, locationInfo.Externalrefid),
                                  DbHelper.MakeInParam("@ISREPAIRFACILITY", (DbType)SqlDbType.TinyInt, 1, locationInfo.Isrepairfacility),
                                  DbHelper.MakeInParam("@X", (DbType)SqlDbType.VarChar, 10, locationInfo.X),
                                  DbHelper.MakeInParam("@Y", (DbType)SqlDbType.VarChar, 10, locationInfo.Y),
                                  DbHelper.MakeInParam("@Z", (DbType)SqlDbType.VarChar, 10, locationInfo.Z),
                                  DbHelper.MakeInParam("@ORGID", (DbType)SqlDbType.VarChar, 8, locationInfo.Orgid),
                                  DbHelper.MakeInParam("@OWNERSYSID", (DbType)SqlDbType.VarChar, 10, locationInfo.Ownersysid),
                                  DbHelper.MakeInParam("@SENDERSYSID", (DbType)SqlDbType.VarChar, 50, locationInfo.Sendersysid),
                                  DbHelper.MakeInParam("@SERVICEADDRESSCODE", (DbType)SqlDbType.VarChar, 30, locationInfo.Serviceaddresscode),
                                  DbHelper.MakeInParam("@SITEID", (DbType)SqlDbType.VarChar, 8, locationInfo.Siteid),
                                  DbHelper.MakeInParam("@SOURCESYSID", (DbType)SqlDbType.VarChar, 10, locationInfo.Sourcesysid),
                                  DbHelper.MakeInParam("@STATUS", (DbType)SqlDbType.VarChar, 20, locationInfo.Status),
                                  DbHelper.MakeInParam("@STATUSDATE", (DbType)SqlDbType.DateTime, 8, locationInfo.Statusdate),
                                  DbHelper.MakeInParam("@CHANGEBY", (DbType)SqlDbType.VarChar,30, locationInfo.Sendersysid),
                                  DbHelper.MakeInParam("@CHANGEDATE", (DbType)SqlDbType.DateTime, 8, locationInfo.Changedate)

                                  };
            string commandText = string.Format("INSERT INTO [{0}LOCATIONS] ([LOCATION],[DESCRIPTION],[TYPE],[DISABLED],[EXTERNALREFID],[ISREPAIRFACILITY],[X],[Y],[Z],[ORGID],[OWNERSYSID],[SENDERSYSID],[SERVICEADDRESSCODE],[SITEID],[SOURCESYSID],[STATUS],[STATUSDATE],[CHANGEBY],[CHANGEDATE]) VALUES(@LOCATION, @DESCRIPTION, @TYPE, @DISABLED, @EXTERNALREFID, @ISREPAIRFACILITY, @X,@Y,@Z,@ORGID,@OWNERSYSID,@SENDERSYSID,@SERVICEADDRESSCODE,@SITEID,@SOURCESYSID,@STATUS,@STATUSDATE,@CHANGEBY,@CHANGEDATE)", BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms);
        }

        /// <summary>
        /// 更新位置信息
        /// </summary>
        /// <param name="locationInfo">位置信息</param>
        /// <returns></returns>
        public bool UpdateLocation(LocationInfo locationInfo)
        {
            DbParameter[] parms = { 
                                  DbHelper.MakeInParam("@LOCATIONSID", (DbType)SqlDbType.BigInt, 8, locationInfo.Locationsid),
                                  DbHelper.MakeInParam("@LOCATION", (DbType)SqlDbType.VarChar, 12, locationInfo.Location),
                                  DbHelper.MakeInParam("@DESCRIPTION", (DbType)SqlDbType.VarChar, 100, locationInfo.Description),
                                  DbHelper.MakeInParam("@TYPE", (DbType)SqlDbType.VarChar, 10, locationInfo.Type),
                                  DbHelper.MakeInParam("@DISABLED", (DbType)SqlDbType.TinyInt, 1, locationInfo.Disabled),
                                  DbHelper.MakeInParam("@EXTERNALREFID", (DbType)SqlDbType.VarChar, 10, locationInfo.Externalrefid),
                                  DbHelper.MakeInParam("@ISREPAIRFACILITY", (DbType)SqlDbType.TinyInt, 1, locationInfo.Isrepairfacility),
                                  DbHelper.MakeInParam("@X", (DbType)SqlDbType.VarChar, 10, locationInfo.X),
                                  DbHelper.MakeInParam("@Y", (DbType)SqlDbType.VarChar, 10, locationInfo.Y),
                                  DbHelper.MakeInParam("@Z", (DbType)SqlDbType.VarChar, 10, locationInfo.Z),
                                  DbHelper.MakeInParam("@ORGID", (DbType)SqlDbType.VarChar, 8, locationInfo.Orgid),
                                  DbHelper.MakeInParam("@OWNERSYSID", (DbType)SqlDbType.VarChar, 10, locationInfo.Ownersysid),
                                  DbHelper.MakeInParam("@SENDERSYSID", (DbType)SqlDbType.VarChar, 50, locationInfo.Sendersysid),
                                  DbHelper.MakeInParam("@SERVICEADDRESSCODE", (DbType)SqlDbType.VarChar, 30, locationInfo.Serviceaddresscode),
                                  DbHelper.MakeInParam("@SITEID", (DbType)SqlDbType.VarChar, 8, locationInfo.Siteid),
                                  DbHelper.MakeInParam("@SOURCESYSID", (DbType)SqlDbType.VarChar, 10, locationInfo.Sourcesysid),
                                  DbHelper.MakeInParam("@STATUS", (DbType)SqlDbType.VarChar, 20, locationInfo.Status),
                                  DbHelper.MakeInParam("@STATUSDATE", (DbType)SqlDbType.DateTime, 8, locationInfo.Statusdate),
                                  DbHelper.MakeInParam("@CHANGEBY", (DbType)SqlDbType.VarChar,30, locationInfo.Sendersysid),
                                  DbHelper.MakeInParam("@CHANGEDATE", (DbType)SqlDbType.DateTime, 8, locationInfo.Changedate)

                                  };

            string commandText = string.Format("UPDATE [{0}LOCATIONS] SET [LOCATION]=@LOCATION,[DESCRIPTION]=@DESCRIPTION, "
                + "[TYPE]=@TYPE,[DISABLED]=@DISABLED,[EXTERNALREFID]=@EXTERNALREFID,[ISREPAIRFACILITY]=@ISREPAIRFACILITY,"
                + "[X]=@X,[Y]=@Y,Z=@Z,[ORGID]=@ORGID,[OWNERSYSID]=@OWNERSYSID,[SENDERSYSID]=@SENDERSYSID,"
                + "[SERVICEADDRESSCODE]=@SERVICEADDRESSCODE,"
                + "[SITEID]=@SITEID,[SOURCESYSID]=@SOURCESYSID,[STATUS]=@STATUS,[STATUSDATE]=@STATUSDATE,[CHANGEBY]=@CHANGEBY,"
                + "[CHANGEDATE]=@CHANGEDATE WHERE [LOCATIONSID]=@LOCATIONSID",
                                              BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms) > 0;
        }

        /// <summary>
        /// 删除位置信息
        /// </summary>
        /// <param name="idList">位置ID列表</param>
        /// <returns></returns>
        public int DeleteLocation(string idList)
        {
            string commandText = string.Format("DELETE FROM [{0}LOCATIONS] WHERE [LOCATIONSID] IN ({1}))",
                                               BaseConfigs.GetTablePrefix,
                                               idList);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText);
        }

        /// <summary>
        /// 获取位置层级关系
        /// </summary>
        /// <returns></returns>
        public IDataReader FindAllLochierarchy()
        {
            string commandText = string.Format("SELECT {0} FROM [{1}LOCHIERARCHY] ORDER BY [LOCHIERARCHYID] ASC",
                                                  DbFields.LOCHIERARCHY,
                                                  BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteReader(System.Data.CommandType.Text, commandText);
        }

        /// <summary>
        /// 获取指定位置的层级信息
        /// </summary>
        /// <param name="location">位置编码</param>
        /// <returns></returns>
        public IDataReader FindLochierarchyByLocation(string location)
        {
            string commandText = string.Format("SELECT {0} FROM [{1}LOCHIERARCHY] WHERE [LOCATION]='{2}' ORDER BY [LOCHIERARCHYID] ASC",
                                                  DbFields.LOCHIERARCHY,
                                                  BaseConfigs.GetTablePrefix,
                                                  location);
            return DbHelper.ExecuteReader(System.Data.CommandType.Text, commandText);
        }
    }
}
