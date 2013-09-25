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
            string commandText = string.Format("SELECT {0} FROM [{1}MEASUREPOINT] {2}",
                                                DbFields.MEASUREPOINT,
                                                BaseConfigs.GetTablePrefix,
                                                condition);
            return DbHelper.ExecuteDataset(CommandType.Text, commandText).Tables[0];
        }

        public IDataReader FindMeasurePointById(long id)
        {
            DbParameter param = DbHelper.MakeInParam("@MEASUREPOINTID", (DbType)SqlDbType.BigInt, 8, id);
            string commandText = string.Format("SELECT {0} FROM [{1}MEASUREPOINT] WHERE [MEASUREPOINTID]=@MEASUREPOINTID",
                                                DbFields.ORGANIZATION,
                                                BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteReader(CommandType.Text, commandText, param);
        }

        public DataTable FindMeasurePointTableByLocation(string location)
        {
            string commandText = string.Format("SELECT {0} FROM [{1}MEASUREPOINT] WHERE LOCATION='{2}'",
                                                DbFields.MEASUREPOINT,
                                                BaseConfigs.GetTablePrefix,
                                                location);
            return DbHelper.ExecuteDataset(CommandType.Text, commandText).Tables[0];
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
                                  DbHelper.MakeInParam("@PHONE", (DbType)SqlDbType.VarChar, 8, measurePointInfo.Phone)
                                 };

            string commandText = string.Format("INSERT INTO [{0}MEASUREPOINT] ([ORGID],[DESCRIPTION],[ORGTYPE],[LEVEL_],[COMMENTS],[LEADER],[PHONE],[ADDRESS],[PARENT]) VALUES(@ORGID, @DESCRIPTION, @ORGTYPE, @LEVEL, @COMMENTS, @LEADER, @PHONE,@ADDRESS,@PARENT)", BaseConfigs.GetTablePrefix);
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
                                  DbHelper.MakeInParam("@PHONE", (DbType)SqlDbType.VarChar, 8, measurePointInfo.Phone)
                                 };


            string commandText = string.Format("UPDATE [{0}MEASUREPOINT] SET [POINTNUM]=@POINTNUM,[POINTCODE]=@POINTCODE,"
            + "[DESCRIPTION]=@DESCRIPTION,[DISPLAYSEQUENCE]=@DISPLAYSEQUENCE,[IPADDRESS]=@IPADDRESS,[CARDNUM]=@CARDNUM,"
            + "[DEVICENUM]=@DEVICENUM,[SERVERIP]=@SERVERIP,[SERVERPORT]=@SERVERPORT,[METERNAME]=@METERNAME,ORGID=@ORGID,"
            + "[SITEID]=@SITEID,[LOCATION]=@LOCATION,[CARRIER]=@CARRIER,[SUPERVISOR]=@SUPERVISOR,[PHONE]=@PHONE"
            + " WHERE [MEASUREPOINTID]=@MEASUREPOINTID", BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms) > 0;
        }

        public int DeleteMeasurePoint(string idList)
        {
            string commandText = string.Format("DELETE FROM [{0}MEASUREPOINT] WHERE [MEASUREPOINTID] IN ({1}))",
                                              BaseConfigs.GetTablePrefix,
                                              idList);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText);
        }

        public int MeasurePointCount(string condition)
        {
            if (condition == "") {
                condition = "1=1";
            }
            string commandText = string.Format("SELECT COUNT(MEASUREPOINTID) FROM [{0}MEASUREPOINT] WHERE {1})",
                                             BaseConfigs.GetTablePrefix);
            return TypeConverter.ObjectToInt(DbHelper.ExecuteDataset(CommandType.Text, commandText).Tables[0].Rows[0][0]);
        }

        public DataTable FindMeasurePointParamByPointNum(string pointnum)
        {
            string commandText = string.Format("SELECT {0} FROM [{1}MEASUREPOINTPARAM] where [POINTNUM]={2}",
                                                DbFields.MEASUREPOINTPARAM,
                                                BaseConfigs.GetTablePrefix,
                                                pointnum);
            return DbHelper.ExecuteDataset(CommandType.Text, commandText).Tables[0];
        }


        public IDataReader FindMeasurePointParamById(int id) {
            DbParameter param = DbHelper.MakeInParam("@MEASUREPOINTPARAMUID", (DbType)SqlDbType.Int, 4, id);
            string commandText = string.Format("SELECT {0} FROM [{1}MEASUREPOINTPARAM] WHERE [MEASUREPOINTPARAMUID]=@MEASUREPOINTPARAMUID",
                                                DbFields.MEASUREPOINTPARAM,
                                                BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteReader(CommandType.Text, commandText, param);
        }


        public int CreateMeasurePointParam(MeasurePointParamInfo paramInfo)
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
                                  DbHelper.MakeInParam("@ULPMNUM", (DbType)SqlDbType.Int, 4, paramInfo.Ulpmnum)
                                 };
            string commandText = string.Format("INSERT INTO [{0}MEASUREPOINTPARAM] ([POINTNUM],[MEASUREUNITID],[LOWERWARNING],"
                                +"[LOWERACTION],[LLPMNUM],[LLPRIORITY],[UPPERWARNING],[UPPERACTION],[ULPMNUM]) "
                                + "VALUES(@POINTNUM, @MEASUREUNITID, @LOWERWARNING, @LOWERACTION, @LLPMNUM, @LLPRIORITY,"
                                + " @UPPERWARNING,@UPPERACTION,@ULPMNUM)", BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms);
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
                                  DbHelper.MakeInParam("@ULPMNUM", (DbType)SqlDbType.Int, 4, paramInfo.Ulpmnum)
                                 };
            string commandText = string.Format("UPDATE [{0}MEASUREPOINTPARAM] SET [POINTNUM]=@POINTNUM,"
                                + "[MEASUREUNITID]=@MEASUREUNITID,LOWERWARNING=@LOWERWARNING,[LOWERACTION]=@LOWERACTION,"
                                + "[LLPMNUM]=@LLPMNUM,[LLPRIORITY]=@LLPRIORITY,[UPPERWARNING]=@UPPERWARNING,"
                                + "[UPPERACTION]=@UPPERACTION,[ULPMNUM]=@ULPMNUM", BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms) > 0;

        }

        public int DeleteMeasurePointParam(string idList)
        {
            string commandText = string.Format("DELETE FROM [{0}MEASUREPOINTPARAM] WHERE [MEASUREPOINTPARAMUID] IN ({1}))",
                                              BaseConfigs.GetTablePrefix,
                                              idList);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText);
        }

    }
}
