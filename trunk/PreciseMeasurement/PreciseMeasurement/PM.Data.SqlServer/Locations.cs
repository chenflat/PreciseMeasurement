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
        public DataTable FindLocationsByCondition(string condition)
        {
            string commandText = string.Format("SELECT {0}LOCATIONS.*, [{0}LOCHIERARCHY].PARENT, [{0}LOCHIERARCHY].CHILDREN,[{0}LOCHIERARCHY].[LEVEL] FROM [{0}LOCATIONS] inner join [{0}LOCHIERARCHY] on [{0}LOCATIONS].location=[{0}LOCHIERARCHY].location where 1=1 {1} ORDER BY [{1}LOCATIONS].[LOCATIONSID] ASC",
                                                  BaseConfigs.GetTablePrefix,
                                                  condition);
            return DbHelper.ExecuteDataset(CommandType.Text, commandText).Tables[0];
        }


        public IDataReader FindLocationsListByCondition(string condition)
        {
            string commandText = string.Format("SELECT {0}LOCATIONS.*, [{0}LOCHIERARCHY].PARENT, [{0}LOCHIERARCHY].CHILDREN,[{0}LOCHIERARCHY].[LEVEL] FROM [{0}LOCATIONS] inner join [{0}LOCHIERARCHY] on [{0}LOCATIONS].location=[{0}LOCHIERARCHY].location where 1=1 {1} ORDER BY [{1}LOCATIONS].[LOCATIONSID] ASC",
                                                      BaseConfigs.GetTablePrefix,
                                                      condition);
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
            string commandText = string.Format("SELECT {0}LOCATIONS.*, [{0}LOCHIERARCHY].PARENT, [{0}LOCHIERARCHY].CHILDREN,[{0}LOCHIERARCHY].LEVEL FROM [{0}LOCATIONS] "
                + " inner join [{0}LOCHIERARCHY] on [{0}LOCATIONS].location=[{0}LOCHIERARCHY].location WHERE [{0}LOCATIONS].LOCATIONSID=@id",
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
        public bool CreateLocation(LocationInfo locationInfo)
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
            DbParameter[] parms2 = {
                                    DbHelper.MakeInParam("@LOCATION", (DbType)SqlDbType.VarChar, 12, locationInfo.Location),
                                    DbHelper.MakeInParam("@PARENT", (DbType)SqlDbType.VarChar, 12, locationInfo.Parent),
                                    DbHelper.MakeInParam("@CHILDREN", (DbType)SqlDbType.TinyInt, 1, locationInfo.Children),
                                    DbHelper.MakeInParam("@SITEID", (DbType)SqlDbType.VarChar, 8, locationInfo.Siteid),
                                    DbHelper.MakeInParam("@ORGID", (DbType)SqlDbType.VarChar, 8, locationInfo.Orgid),
                                    DbHelper.MakeInParam("@SYSTEMID", (DbType)SqlDbType.VarChar, 50, locationInfo.Ownersysid),
                                    DbHelper.MakeInParam("@LEVEL", (DbType)SqlDbType.Int, 4, locationInfo.Level)
                                    
                                   };
            string commandText = string.Format("INSERT INTO [{0}LOCATIONS] ([LOCATION],[DESCRIPTION],[TYPE],[DISABLED],[EXTERNALREFID],[ISREPAIRFACILITY],[X],[Y],[Z],[ORGID],[OWNERSYSID],[SENDERSYSID],[SERVICEADDRESSCODE],[SITEID],[SOURCESYSID],[STATUS],[STATUSDATE],[CHANGEBY],[CHANGEDATE]) VALUES(@LOCATION, @DESCRIPTION, @TYPE, @DISABLED, @EXTERNALREFID, @ISREPAIRFACILITY, @X,@Y,@Z,@ORGID,@OWNERSYSID,@SENDERSYSID,@SERVICEADDRESSCODE,@SITEID,@SOURCESYSID,@STATUS,@STATUSDATE,@CHANGEBY,@CHANGEDATE)", BaseConfigs.GetTablePrefix);
            if (DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms) > 0)
            {
                string commandText2 = string.Format("INSERT INTO [{0}LOCHIERARCHY]([LOCATION],[PARENT],[ORGID],[SITEID],[SYSTEMID],[LEVEL]) "
                    + " Values(@LOCATION,@PARENT,@ORGID,@SITEID,@SYSTEMID,@LEVEL)", BaseConfigs.GetTablePrefix);
                return DbHelper.ExecuteNonQuery(CommandType.Text, commandText2, parms2) > 0;
            }
            else {
                return false;
            }
            
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
                                  DbHelper.MakeInParam("@CHANGEBY", (DbType)SqlDbType.VarChar,30, locationInfo.Sendersysid),
                                  DbHelper.MakeInParam("@CHANGEDATE", (DbType)SqlDbType.DateTime, 8, locationInfo.Changedate)
                                  };

            string commandText = string.Format("UPDATE [{0}LOCATIONS] SET [LOCATION]=@LOCATION,[DESCRIPTION]=@DESCRIPTION, "
                + "[TYPE]=@TYPE,[DISABLED]=@DISABLED,[EXTERNALREFID]=@EXTERNALREFID,[ISREPAIRFACILITY]=@ISREPAIRFACILITY,"
                + "[X]=@X,[Y]=@Y,Z=@Z,[ORGID]=@ORGID,[OWNERSYSID]=@OWNERSYSID,[SENDERSYSID]=@SENDERSYSID,"
                + "[SERVICEADDRESSCODE]=@SERVICEADDRESSCODE,"
                + "[SITEID]=@SITEID,[SOURCESYSID]=@SOURCESYSID,[CHANGEBY]=@CHANGEBY,"
                + "[CHANGEDATE]=@CHANGEDATE WHERE [LOCATIONSID]=@LOCATIONSID",
                                              BaseConfigs.GetTablePrefix);


            DbParameter[] parms2 = {
                                    DbHelper.MakeInParam("@LOCATION", (DbType)SqlDbType.VarChar, 12, locationInfo.Location),
                                    DbHelper.MakeInParam("@PARENT", (DbType)SqlDbType.VarChar, 12, locationInfo.Parent),
                                    DbHelper.MakeInParam("@CHILDREN", (DbType)SqlDbType.TinyInt, 1, locationInfo.Children),
                                    DbHelper.MakeInParam("@SITEID", (DbType)SqlDbType.VarChar, 8, locationInfo.Siteid),
                                    DbHelper.MakeInParam("@ORGID", (DbType)SqlDbType.VarChar, 8, locationInfo.Orgid),
                                    DbHelper.MakeInParam("@SYSTEMID", (DbType)SqlDbType.VarChar, 50, locationInfo.Ownersysid),
                                    DbHelper.MakeInParam("@LEVEL", (DbType)SqlDbType.Int, 4, locationInfo.Level)
                                   };

             if(DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms) > 0) 
             {

                 string commandText2 = string.Format("UPDATE [{0}LOCHIERARCHY] SET SITEID=@SITEID,PARENT=@PARENT,CHILDREN=@CHILDREN,ORGID=@ORGID,SYSTEMID=@SYSTEMID,LEVEL=@LEVEL WHERE LOCATION=@LOCATION", BaseConfigs.GetTablePrefix);

                 return DbHelper.ExecuteNonQuery(CommandType.Text, commandText2, parms2) > 0;

             } else {
                return false;
             }
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

        public int LocationsCount(string condition) {
            if (condition == "")
            {
                condition = "1=1";
            }
            string commandText = string.Format("SELECT COUNT(LOCATIONSID) FROM [{0}LOCATIONS] WHERE {1})",
                                             BaseConfigs.GetTablePrefix);
            return TypeConverter.ObjectToInt(DbHelper.ExecuteDataset(CommandType.Text, commandText).Tables[0].Rows[0][0]);
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

        /// <summary>
        /// 获取层级
        /// </summary>
        /// <param name="orgid">组织机构ID</param>
        /// <param name="siteid">地点ID</param>
        /// <returns></returns>
        public IDataReader GetLevels(string orgid, string siteid)
        {
            DbParameter[] parms = { 
                                  DbHelper.MakeInParam("@ORGID", (DbType)SqlDbType.VarChar, 8, orgid),
                                  DbHelper.MakeInParam("@SITEID", (DbType)SqlDbType.VarChar, 8, siteid)
                                    };
            string commandText = string.Format("SELECT DISTINCT [LEVEL] FROM [{0}LOCHIERARCHY] where isnull(ORGID,'')=@ORGID AND isnull(SITEID,'')=@SITEID order by [LEVEL]",
                                                    BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteReader(System.Data.CommandType.Text, commandText, parms);
        }

    }
}
