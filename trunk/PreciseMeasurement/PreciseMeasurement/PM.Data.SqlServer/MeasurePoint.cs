using System;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;


using PM.Data;
using PM.Config;
using PM.Common;
using PM.Entity;

namespace PM.Data.SqlServer
{
    public partial class DataProvider : IDataProvider
    {

        public DataTable FindMeasurePointByCondition(string condition)
        {
            string commandText = string.Format("select {0}MEASUREPOINT.*,{0}ORGANIZATION.DESCRIPTION as ORGNAME from [{0}MEASUREPOINT] "
                + "left outer join [{0}ORGANIZATION] on [{0}MEASUREPOINT].ORGID=[{0}ORGANIZATION].ORGID where "
                +"[{0}MEASUREPOINT].STATUS='ACTIVE' {1} ORDER BY [{0}MEASUREPOINT].DISPLAYSEQUENCE ASC",
                                                BaseConfigs.GetTablePrefix,
                                                condition);
            return DbHelper.ExecuteDataset(CommandType.Text, commandText).Tables[0];
        }

        public IDataReader FindMeasurePointById(long id)
        {
            DbParameter param = DbHelper.MakeInParam("@MEASUREPOINTID", (DbType)SqlDbType.BigInt, 8, id);
            string commandText = string.Format("select {0}MEASUREPOINT.*,{0}ORGANIZATION.DESCRIPTION as ORGNAME from [{0}MEASUREPOINT] "
                +"left outer join [{0}ORGANIZATION] on [{0}MEASUREPOINT].ORGID=[{0}ORGANIZATION].ORGID WHERE [MEASUREPOINTID]=@MEASUREPOINTID",
                                                BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteReader(CommandType.Text, commandText, param);
        }

        public DataTable FindMeasurePointTableByLocation(string location)
        {
            string commandText = string.Format("SELECT {0} FROM [{1}MEASUREPOINT] WHERE STATUS='ACTIVE' AND LOCATION='{2}' order by DISPLAYSEQUENCE ASC",
                                                DbFields.MEASUREPOINT,
                                                BaseConfigs.GetTablePrefix,
                                                location);
            return DbHelper.ExecuteDataset(CommandType.Text, commandText).Tables[0];
        }

        
        /// <summary>
        /// 获取计量点和位置信息
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        public IDataReader FindMeasurePointAndLocation() {
            string commandText = string.Format("SELECT * FROM [{0}MEASUREPOINT] WHERE STATUS='ACTIVE' order by DISPLAYSEQUENCE ASC",
                                                BaseConfigs.GetTablePrefix
                                                );
            return DbHelper.ExecuteReader(CommandType.Text, commandText);

        }

        /// <summary>
        /// 获取指定层级的计量器列表
        /// </summary>
        /// <param name="level">层级ID</param>
        /// <param name="orgid">组织机构ID</param>
        /// <param name="siteid">地点ID</param>
        /// <returns></returns>
        public IDataReader FindMeasurePointsByLevel(string carrier, int level, string orgid, string siteid) {

            DbParameter[] parms = { 
                                  DbHelper.MakeInParam("@CARRIER", (DbType)SqlDbType.VarChar, 12, carrier),
                                  DbHelper.MakeInParam("@LEVEL", (DbType)SqlDbType.Int, 4, level),
                                  DbHelper.MakeInParam("@ORGID", (DbType)SqlDbType.VarChar, 8, orgid),
                                  DbHelper.MakeInParam("@SITEID", (DbType)SqlDbType.VarChar, 8, siteid)
                                    };


            string commandText = string.Format("SELECT [{0}MEASUREPOINT].* FROM [{0}MEASUREPOINT] inner join CP_GetOrgIdTable('{1}') b on [{0}MEASUREPOINT].orgid=b.orgid WHERE [{0}MEASUREPOINT].LEVEL=@LEVEL and [{0}MEASUREPOINT].CARRIER=@CARRIER " +
                " and isnull([{0}MEASUREPOINT].siteid,'')=@SITEID AND [{0}MEASUREPOINT].STATUS='ACTIVE'",
                BaseConfigs.GetTablePrefix,orgid);

            return DbHelper.ExecuteReader(CommandType.Text, commandText, parms);
        }

        public int CreateMeasurePoint(MeasurePointInfo measurePointInfo)
        {
            DbParameter[] parms = { 
                                  DbHelper.MakeInParam("@POINTNUM", (DbType)SqlDbType.VarChar, 8, measurePointInfo.Pointnum),
                                  DbHelper.MakeInParam("@POINTCODE", (DbType)SqlDbType.VarChar, 20, measurePointInfo.PointCode),
                                  DbHelper.MakeInParam("@DESCRIPTION", (DbType)SqlDbType.VarChar, 100, measurePointInfo.Description),
                                  DbHelper.MakeInParam("@DISPLAYSEQUENCE", (DbType)SqlDbType.Int, 4, measurePointInfo.Displaysequence),
                                  DbHelper.MakeInParam("@IPADDRESS", (DbType)SqlDbType.VarChar, 256, measurePointInfo.Ipaddress),
                                  DbHelper.MakeInParam("@CARDNUM", (DbType)SqlDbType.VarChar, 50, measurePointInfo.Cardnum),
                                  DbHelper.MakeInParam("@DEVICENUM", (DbType)SqlDbType.VarChar, 50, measurePointInfo.Devicenum),
                                  DbHelper.MakeInParam("@SERVERIP", (DbType)SqlDbType.VarChar, 100, measurePointInfo.Serverip),
                                  DbHelper.MakeInParam("@SERVERPORT", (DbType)SqlDbType.VarChar, 8, measurePointInfo.Serverport),
                                  DbHelper.MakeInParam("@METERNAME", (DbType)SqlDbType.VarChar, 8, measurePointInfo.Metername),
                                  DbHelper.MakeInParam("@ORGID", (DbType)SqlDbType.VarChar, 8, measurePointInfo.Orgid),
                                  DbHelper.MakeInParam("@SITEID", (DbType)SqlDbType.VarChar, 8, measurePointInfo.Siteid),
                                  DbHelper.MakeInParam("@LOCATION", (DbType)SqlDbType.VarChar, 8, measurePointInfo.Location),
                                  DbHelper.MakeInParam("@CARRIER", (DbType)SqlDbType.VarChar, 8, measurePointInfo.Carrier),
                                  DbHelper.MakeInParam("@SUPERVISOR", (DbType)SqlDbType.VarChar, 8, measurePointInfo.Supervisor),
                                  DbHelper.MakeInParam("@PHONE", (DbType)SqlDbType.VarChar, 8, measurePointInfo.Phone),
                                  DbHelper.MakeInParam("@STATUS", (DbType)SqlDbType.VarChar, 12, measurePointInfo.Status),
                                  DbHelper.MakeInParam("@LEVEL", (DbType)SqlDbType.Int, 4, measurePointInfo.Level),
                                  DbHelper.MakeInParam("@X", (DbType)SqlDbType.VarChar, 10, measurePointInfo.X),
                                  DbHelper.MakeInParam("@Y", (DbType)SqlDbType.VarChar, 10, measurePointInfo.Y),
                                  DbHelper.MakeInParam("@Z", (DbType)SqlDbType.VarChar, 10, measurePointInfo.Z),
                                  DbHelper.MakeInParam("@Classstructureid", (DbType)SqlDbType.VarChar, 20, measurePointInfo.Classstructureid),
                                  

                                 };

            string commandText = string.Format("INSERT INTO [{0}MEASUREPOINT] ([POINTNUM],[POINTCODE],[DESCRIPTION],[DISPLAYSEQUENCE],[IPADDRESS],"
                                + "[CARDNUM],[DEVICENUM],[SERVERIP],[SERVERPORT],[METERNAME],[ORGID],[SITEID],[LOCATION],[CARRIER],[SUPERVISOR],[PHONE],[STATUS],[LEVEL],[X],[Y],[Z],[Classstructureid])"
                                + " VALUES(@POINTNUM, @POINTCODE, @DESCRIPTION, @DISPLAYSEQUENCE, @IPADDRESS, @CARDNUM, @DEVICENUM,@SERVERIP,@SERVERPORT,"
                                + "@METERNAME,@ORGID,@SITEID,@LOCATION,@CARRIER,@SUPERVISOR,@PHONE,@STATUS,@LEVEL,@X,@Y,@Z,@Classstructureid)", BaseConfigs.GetTablePrefix);

            //累计更新行
            //int retRows = 0;
            //if (DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms) > -1)
            //{
                
                ////新增计量器参数信息
                //string commandText2 = string.Format("SELECT * FROM [{0}MEASUREUNIT] WHERE ISMAINPARAM=1",BaseConfigs.GetTablePrefix);
                //using (IDataReader dr = DbHelper.ExecuteReader(CommandType.Text, commandText2))
                //{
                //    while (dr.Read())
                //    {
                //        DbParameter[] unitParams = { 
                //                           DbHelper.MakeInParam("@POINTNUM", (DbType)SqlDbType.VarChar, 8, measurePointInfo.Pointnum),
                //                           DbHelper.MakeInParam("@MEASUREUNITID", (DbType)SqlDbType.VarChar, 16, dr["MEASUREUNITID"].ToString())
                //                           };
                //        string commandText3 = string.Format("INSERT INTO [{0}MEASUREPOINTPARAM](POINTNUM,MEASUREUNITID)VALUES(@POINTNUM,@MEASUREUNITID)",BaseConfigs.GetTablePrefix);
                //        retRows+=DbHelper.ExecuteNonQuery(CommandType.Text, commandText3, unitParams);

                //    }
                //    dr.Close();
                //}

            //}
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms);


        }

        public bool UpdateMeasurePoint(MeasurePointInfo measurePointInfo)
        {
            DbParameter[] parms = { 
                                  DbHelper.MakeInParam("@MEASUREPOINTID", (DbType)SqlDbType.BigInt, 8, measurePointInfo.Measurepointid),
                                  DbHelper.MakeInParam("@POINTNUM", (DbType)SqlDbType.VarChar, 8, measurePointInfo.Pointnum),
                                  DbHelper.MakeInParam("@POINTCODE", (DbType)SqlDbType.VarChar, 20, measurePointInfo.PointCode),
                                  DbHelper.MakeInParam("@DESCRIPTION", (DbType)SqlDbType.VarChar, 100, measurePointInfo.Description),
                                  DbHelper.MakeInParam("@DISPLAYSEQUENCE", (DbType)SqlDbType.Int, 4, measurePointInfo.Displaysequence),
                                  DbHelper.MakeInParam("@IPADDRESS", (DbType)SqlDbType.VarChar, 256, measurePointInfo.Ipaddress),
                                  DbHelper.MakeInParam("@CARDNUM", (DbType)SqlDbType.VarChar, 50, measurePointInfo.Cardnum),
                                  DbHelper.MakeInParam("@DEVICENUM", (DbType)SqlDbType.VarChar, 50, measurePointInfo.Devicenum),
                                  DbHelper.MakeInParam("@SERVERIP", (DbType)SqlDbType.VarChar, 100, measurePointInfo.Serverip),
                                  DbHelper.MakeInParam("@SERVERPORT", (DbType)SqlDbType.VarChar, 8, measurePointInfo.Serverport),
                                  DbHelper.MakeInParam("@METERNAME", (DbType)SqlDbType.VarChar, 8, measurePointInfo.Metername),
                                  DbHelper.MakeInParam("@ORGID", (DbType)SqlDbType.VarChar, 8, measurePointInfo.Orgid),
                                  DbHelper.MakeInParam("@SITEID", (DbType)SqlDbType.VarChar, 8, measurePointInfo.Siteid),
                                  DbHelper.MakeInParam("@LOCATION", (DbType)SqlDbType.VarChar, 8, measurePointInfo.Location),
                                  DbHelper.MakeInParam("@CARRIER", (DbType)SqlDbType.VarChar, 8, measurePointInfo.Carrier),
                                  DbHelper.MakeInParam("@SUPERVISOR", (DbType)SqlDbType.VarChar, 8, measurePointInfo.Supervisor),
                                  DbHelper.MakeInParam("@PHONE", (DbType)SqlDbType.VarChar, 8, measurePointInfo.Phone),
                                  DbHelper.MakeInParam("@STATUS", (DbType)SqlDbType.VarChar, 12, measurePointInfo.Status),
                                  DbHelper.MakeInParam("@LEVEL", (DbType)SqlDbType.Int, 4, measurePointInfo.Level),
                                  DbHelper.MakeInParam("@X", (DbType)SqlDbType.VarChar, 10, measurePointInfo.X),
                                  DbHelper.MakeInParam("@Y", (DbType)SqlDbType.VarChar, 10, measurePointInfo.Y),
                                  DbHelper.MakeInParam("@Z", (DbType)SqlDbType.VarChar, 10, measurePointInfo.Z),
                                  DbHelper.MakeInParam("@Classstructureid", (DbType)SqlDbType.VarChar, 20, measurePointInfo.Classstructureid)
                                 };


            string commandText = string.Format("UPDATE [{0}MEASUREPOINT] SET [POINTNUM]=@POINTNUM,[POINTCODE]=@POINTCODE,"
            + "[DESCRIPTION]=@DESCRIPTION,[DISPLAYSEQUENCE]=@DISPLAYSEQUENCE,[IPADDRESS]=@IPADDRESS,[CARDNUM]=@CARDNUM,"
            + "[DEVICENUM]=@DEVICENUM,[SERVERIP]=@SERVERIP,[SERVERPORT]=@SERVERPORT,[METERNAME]=@METERNAME,ORGID=@ORGID,"
            + "[SITEID]=@SITEID,[LOCATION]=@LOCATION,[CARRIER]=@CARRIER,[SUPERVISOR]=@SUPERVISOR,[PHONE]=@PHONE,[STATUS]=@STATUS,"
            + "[LEVEL]=@LEVEL,[X]=@X,[Y]=@Y,[Z]=@Z,[Classstructureid]=@Classstructureid"
            + " WHERE [MEASUREPOINTID]=@MEASUREPOINTID", BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms) > 0;
        }

        /// <summary>
        /// 更新计量点坐标位置信息
        /// </summary>
        /// <param name="measurePointInfo">计量点信息</param>
        /// <returns></returns>
        public int UpdateMeasurePointCoordinates(MeasurePointInfo measurePointInfo) {
            DbParameter[] parms = { 
                                  DbHelper.MakeInParam("@POINTNUM", (DbType)SqlDbType.VarChar, 8, measurePointInfo.Pointnum),
                                  DbHelper.MakeInParam("@X", (DbType)SqlDbType.VarChar, 10, measurePointInfo.X),
                                  DbHelper.MakeInParam("@Y", (DbType)SqlDbType.VarChar, 10, measurePointInfo.Y),
                                  DbHelper.MakeInParam("@Z", (DbType)SqlDbType.VarChar, 10, measurePointInfo.Z),
                                  DbHelper.MakeInParam("@ORGID", (DbType)SqlDbType.VarChar, 8, measurePointInfo.Orgid)
                                 };


            string commandText = string.Format("UPDATE [{0}MEASUREPOINT] SET [X]=@X,[Y]=@Y,[Z]=@Z"
            + " WHERE [POINTNUM]=@POINTNUM AND [ORGID]=@ORGID", BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms);
        }

        public int DeleteMeasurePoint(string idList)
        {
            string commandText = string.Format("UPDATE [{0}MEASUREPOINT] SET [STATUS]='DELETED' WHERE [MEASUREPOINTID] IN ({1})",
                                              BaseConfigs.GetTablePrefix,
                                              idList);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText);
        }

        public int MeasurePointCount(string condition)
        {
            string commandText = string.Format("SELECT COUNT(MEASUREPOINTID) FROM [{0}MEASUREPOINT] WHERE STATUS='ACTIVE' {1})",
                                             BaseConfigs.GetTablePrefix,condition);
            return TypeConverter.ObjectToInt(DbHelper.ExecuteDataset(CommandType.Text, commandText).Tables[0].Rows[0][0]);
        }

        public DataTable FindMeasurePointParamByPointNum(string pointnum)
        {
            string commandText = string.Format("SELECT [{0}MEASUREPOINTPARAM].*,[{0}MEASUREUNIT].*,[{0}MEASUREPOINT].DESCRIPTION as POINTNAME,[{0}MEASUREUNIT].DESCRIPTION as MEASUREUNITNAME"
                +" FROM [{0}MEASUREPOINTPARAM] left outer join [{0}MEASUREPOINT] on [{0}MEASUREPOINTPARAM].POINTNUM=[{0}MEASUREPOINT].POINTNUM "
                + " left outer join [{0}MEASUREUNIT] on [{0}MEASUREPOINTPARAM].MEASUREUNITID=[{0}MEASUREUNIT].MEASUREUNITID "
                + " where [{0}MEASUREPOINT].STATUS='ACTIVE' AND [{0}MEASUREPOINTPARAM].POINTNUM='{1}'",
                                                BaseConfigs.GetTablePrefix,
                                                pointnum);
            return DbHelper.ExecuteDataset(CommandType.Text, commandText).Tables[0];
        }


        public IDataReader FindMeasurePointParamById(int id) {
            DbParameter param = DbHelper.MakeInParam("@MEASUREPOINTPARAMUID", (DbType)SqlDbType.Int, 4, id);
            string commandText = string.Format("SELECT * FROM [{0}MEASUREPOINTPARAM] WHERE [MEASUREPOINTPARAMUID]=@MEASUREPOINTPARAMUID",
                                                BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteReader(CommandType.Text, commandText, param);
        }


        public bool CreateMeasurePointParam(MeasurePointParamInfo paramInfo)
        {
            DbParameter[] parms = { 
                                  DbHelper.MakeInParam("@POINTNUM", (DbType)SqlDbType.VarChar, 8, paramInfo.Pointnum),
                                  DbHelper.MakeInParam("@MEASUREUNITID", (DbType)SqlDbType.VarChar, 16, paramInfo.Measureunitid),
                                  DbHelper.MakeInParam("@LOWERWARNING", (DbType)SqlDbType.Decimal, 4, paramInfo.Lowerwarning),
                                  DbHelper.MakeInParam("@LOWERACTION", (DbType)SqlDbType.Decimal, 4, paramInfo.Loweraction),
                                  DbHelper.MakeInParam("@LLPMNUM", (DbType)SqlDbType.VarChar, 8, paramInfo.Llpmnum),
                                  DbHelper.MakeInParam("@LLPRIORITY", (DbType)SqlDbType.Int, 50, paramInfo.Llpriority),
                                  DbHelper.MakeInParam("@UPPERWARNING", (DbType)SqlDbType.Decimal, 4, paramInfo.Upperwarning),
                                  DbHelper.MakeInParam("@UPPERACTION", (DbType)SqlDbType.VarChar, 8, paramInfo.Upperaction),
                                  DbHelper.MakeInParam("@ULPMNUM", (DbType)SqlDbType.VarChar, 8, paramInfo.Ulpmnum),
                                  DbHelper.MakeInParam("@ULPRIORITY", (DbType)SqlDbType.Int, 4, paramInfo.Ulpriority),
                                  DbHelper.MakeInParam("@ABBREVIATION", (DbType)SqlDbType.VarChar, 8, paramInfo.Abbreviation),
                                  DbHelper.MakeInParam("@DISPLAYSEQUENCE", (DbType)SqlDbType.Int, 4, paramInfo.Displaysequence),
                                  DbHelper.MakeInParam("@ISCALCULATE", (DbType)SqlDbType.TinyInt, 1, paramInfo.IsCalculate),
                                  DbHelper.MakeInParam("@VISABLED", (DbType)SqlDbType.TinyInt, 1, paramInfo.Visabled),
                                  DbHelper.MakeInParam("@ISMAINPARAM", (DbType)SqlDbType.TinyInt, 1, paramInfo.IsMainParam)

                                 };
            string commandText = string.Format("INSERT INTO [{0}MEASUREPOINTPARAM] ([POINTNUM],[MEASUREUNITID],[LOWERWARNING],"
                                + "[LOWERACTION],[LLPMNUM],[LLPRIORITY],[UPPERWARNING],[UPPERACTION],[ULPMNUM],[ABBREVIATION],"
                                + "[DISPLAYSEQUENCE],[ISCALCULATE],[VISABLED],[ISMAINPARAM]) "
                                + "VALUES(@POINTNUM, @MEASUREUNITID, @LOWERWARNING, @LOWERACTION, @LLPMNUM, @LLPRIORITY,"
                                + " @UPPERWARNING,@UPPERACTION,@ULPMNUM, @ABBREVIATION, @DISPLAYSEQUENCE,@ISCALCULATE,@VISABLED,@ISMAINPARAM)", BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms) > 0;
        }

        public bool UpdateMeasurePointParam(MeasurePointParamInfo paramInfo)
        {
            DbParameter[] parms = {  
                                  DbHelper.MakeInParam("@MEASUREPOINTPARAMUID", (DbType)SqlDbType.Int, 4, paramInfo.Measurepointparamuid),
                                  DbHelper.MakeInParam("@POINTNUM", (DbType)SqlDbType.VarChar, 8, paramInfo.Pointnum),
                                  DbHelper.MakeInParam("@MEASUREUNITID", (DbType)SqlDbType.VarChar, 16, paramInfo.Measureunitid),
                                  DbHelper.MakeInParam("@LOWERWARNING", (DbType)SqlDbType.Decimal, 4, paramInfo.Lowerwarning),
                                  DbHelper.MakeInParam("@LOWERACTION", (DbType)SqlDbType.Decimal, 4, paramInfo.Loweraction),
                                  DbHelper.MakeInParam("@LLPMNUM", (DbType)SqlDbType.VarChar, 8, paramInfo.Llpmnum),
                                  DbHelper.MakeInParam("@LLPRIORITY", (DbType)SqlDbType.Int, 50, paramInfo.Llpriority),
                                  DbHelper.MakeInParam("@UPPERWARNING", (DbType)SqlDbType.Decimal, 4, paramInfo.Upperwarning),
                                  DbHelper.MakeInParam("@UPPERACTION", (DbType)SqlDbType.VarChar, 8, paramInfo.Upperaction),
                                  DbHelper.MakeInParam("@ULPMNUM", (DbType)SqlDbType.VarChar, 8, paramInfo.Ulpmnum),
                                  DbHelper.MakeInParam("@ULPRIORITY", (DbType)SqlDbType.Int, 4, paramInfo.Ulpriority),
                                  DbHelper.MakeInParam("@ABBREVIATION", (DbType)SqlDbType.VarChar, 8, paramInfo.Abbreviation),
                                  DbHelper.MakeInParam("@DISPLAYSEQUENCE", (DbType)SqlDbType.Int, 4, paramInfo.Displaysequence),
                                  DbHelper.MakeInParam("@ISCALCULATE", (DbType)SqlDbType.TinyInt, 1, paramInfo.IsCalculate),
                                  DbHelper.MakeInParam("@VISABLED", (DbType)SqlDbType.TinyInt, 1, paramInfo.Visabled),
                                  DbHelper.MakeInParam("@ISMAINPARAM", (DbType)SqlDbType.TinyInt, 1, paramInfo.IsMainParam)
                                 };
            string commandText = string.Format("UPDATE [{0}MEASUREPOINTPARAM] SET "
                                + "LOWERWARNING=@LOWERWARNING,[LOWERACTION]=@LOWERACTION,"
                                + "[LLPMNUM]=@LLPMNUM,[LLPRIORITY]=@LLPRIORITY,[UPPERWARNING]=@UPPERWARNING,"
                                + "[UPPERACTION]=@UPPERACTION,[ULPMNUM]=@ULPMNUM,[ABBREVIATION]=@ABBREVIATION,[ULPRIORITY]=@ULPRIORITY,"
                                + "[DISPLAYSEQUENCE]=@DISPLAYSEQUENCE,[ISCALCULATE]=@ISCALCULATE,[VISABLED]=@VISABLED,"
                                + "[ISMAINPARAM]=@ISMAINPARAM where MEASUREPOINTPARAMUID=@MEASUREPOINTPARAMUID", BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms) > 0;

        }


        
        public int DeleteMeasurePointParam(string idList)
        {
            string commandText = string.Format("DELETE FROM [{0}MEASUREPOINTPARAM] WHERE [MEASUREPOINTPARAMUID] IN ({1})",
                                              BaseConfigs.GetTablePrefix,
                                              idList);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText);
        }


        /// <summary>
        /// 更新记量点最后更新日期
        /// </summary>
        /// <param name="pointnum">计量点</param>
        /// <param name="lastsyntime">最后更新时间</param>
        /// <returns></returns>
        public bool UpdateMeasurePointLastSynTime(string pointnum, DateTime lastsyntime)
        {
            DbParameter[] parms = {  
                                  DbHelper.MakeInParam("@POINTNUM", (DbType)SqlDbType.VarChar, 8, pointnum),
                                  DbHelper.MakeInParam("@LASTSYNTIME", (DbType)SqlDbType.DateTime, 8, lastsyntime)
            };
            string commandText = string.Format("UPDATE [{0}MEASUREPOINT] SET LASTSYNTIME=@LASTSYNTIME WHERE POINTNUM=@POINTNUM", BaseConfigs.GetTablePrefix);

            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms) > 0;
        }




    }
}
