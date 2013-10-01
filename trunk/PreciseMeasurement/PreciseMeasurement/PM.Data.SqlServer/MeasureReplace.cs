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
        public DataTable FindMeasureReplaceTableByCondition(string condition) {
            string commandText = string.Format("SELECT [{0}MEASUREREPLACE].*, [MEASUREUNIT].DESCRIPTION as MEASUREUNITNAME"
                + " FROM [{0}MEASUREREPLACE] left outer join [{0}MEASUREUNIT] on [{0}MEASUREREPLACE].[MEASUREUNITID]=[{0}MEASUREUNIT].[MEASUREUNITID]"
                +" where 1=1 {1}",
                                BaseConfigs.GetTablePrefix,
                                condition);
            return DbHelper.ExecuteDataset(CommandType.Text, commandText).Tables[0];
        }

        public IDataReader FindMeasureReplaceById(long id) {
            DbParameter param = DbHelper.MakeInParam("@MEASURETRANSID", (DbType)SqlDbType.BigInt, 8, id);
            string commandText = string.Format("SELECT {0} FROM [{1}MEASUREREPLACE] WHERE [MEASURETRANSID]=@MEASURETRANSID",
                                                DbFields.MEASUREREPLACE,
                                                BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteReader(CommandType.Text, commandText, param);
        }

        public bool CreateMeasureReplace(MeasureReplaceInfo measureReplaceInfo) {

            DbParameter[] parms = { 
                                  DbHelper.MakeInParam("@POINTNUM", (DbType)SqlDbType.VarChar, 12, measureReplaceInfo.Pointnum),
                                  DbHelper.MakeInParam("@MEASUREUNITID", (DbType)SqlDbType.VarChar, 16, measureReplaceInfo.MeasureunitId),
                                  DbHelper.MakeInParam("@MEASUREMENTVALUE", (DbType)SqlDbType.Decimal, 4, measureReplaceInfo.MeasurementValue),
                                  DbHelper.MakeInParam("@ENTERBY", (DbType)SqlDbType.VarChar, 100, measureReplaceInfo.EnterBy),
                                  DbHelper.MakeInParam("@ENTERDATE", (DbType)SqlDbType.DateTime, 8, measureReplaceInfo.EnterDate),
                                  DbHelper.MakeInParam("@TOPOINTNUM", (DbType)SqlDbType.VarChar, 12, measureReplaceInfo.ToPointnum),
                                  DbHelper.MakeInParam("@TOMEASUREMENTVALUE", (DbType)SqlDbType.Decimal, 4, measureReplaceInfo.ToMeasurementValue),
                                  DbHelper.MakeInParam("@CORRECTEDVALUE", (DbType)SqlDbType.Decimal, 4, measureReplaceInfo.CorrectedValue),
                                  DbHelper.MakeInParam("@FROMDEPT", (DbType)SqlDbType.VarChar, 30, measureReplaceInfo.FromDept),
                                  DbHelper.MakeInParam("@FROMLOC", (DbType)SqlDbType.VarChar, 12, measureReplaceInfo.FromLoc),
                                  DbHelper.MakeInParam("@REPLACEPERSON", (DbType)SqlDbType.VarChar, 30, measureReplaceInfo.ReplacePerson),
                                  DbHelper.MakeInParam("@REPLACEDATE", (DbType)SqlDbType.DateTime, 8, measureReplaceInfo.ReplaceDate),
                                  DbHelper.MakeInParam("@REPLACETYPE", (DbType)SqlDbType.VarChar, 16, measureReplaceInfo.ReplaceType),
                                  DbHelper.MakeInParam("@STATUS", (DbType)SqlDbType.VarChar, 16, measureReplaceInfo.ReplaceType),
                                  DbHelper.MakeInParam("@ORGID", (DbType)SqlDbType.VarChar, 8, measureReplaceInfo.Orgid),
                                  DbHelper.MakeInParam("@SITEID", (DbType)SqlDbType.VarChar, 8, measureReplaceInfo.Siteid),
                                  DbHelper.MakeInParam("@MEMO", (DbType)SqlDbType.VarChar, 254, measureReplaceInfo.Memo)
                                 };

            string commandText = string.Format("INSERT INTO [{0}MEASUREREPLACE] ([POINTNUM],[MEASUREUNITID],[MEASUREMENTVALUE],[ENTERBY],[ENTERDATE],"
                             + "[TOPOINTNUM],[TOMEASUREMENTVALUE],[CORRECTEDVALUE],[FROMDEPT],[FROMLOC],[REPLACEPERSON],[REPLACEDATE],[REPLACETYPE],"
                             + "[STATUS],[ORGID],[SITEID],[MEMO]) VALUES(@POINTNUM,@MEASUREUNITID, @MEASUREMENTVALUE, @ENTERBY, @ENTERDATE, @TOPOINTNUM,"
                             + " @TOMEASUREMENTVALUE,@CORRECTEDVALUE, @FROMDEPT,@FROMLOC,@REPLACEPERSON,@REPLACEDATE,@REPLACETYPE,@STATUS,@ORGID,@SITEID,@MEMO)", BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms) > 0;
        }

        public bool UpdateMeasureReplace(MeasureReplaceInfo measureReplaceInfo) {
            DbParameter[] parms = { 
                                  DbHelper.MakeInParam("@MEASURETRANSID", (DbType)SqlDbType.BigInt, 8, measureReplaceInfo.Measuretransid),
                                  DbHelper.MakeInParam("@MEASUREUNITID", (DbType)SqlDbType.VarChar, 16, measureReplaceInfo.MeasureunitId),
                                  DbHelper.MakeInParam("@POINTNUM", (DbType)SqlDbType.VarChar, 12, measureReplaceInfo.Pointnum),
                                  DbHelper.MakeInParam("@MEASUREMENTVALUE", (DbType)SqlDbType.Decimal, 4, measureReplaceInfo.MeasurementValue),
                                  DbHelper.MakeInParam("@ENTERBY", (DbType)SqlDbType.VarChar, 100, measureReplaceInfo.EnterBy),
                                  DbHelper.MakeInParam("@ENTERDATE", (DbType)SqlDbType.DateTime, 8, measureReplaceInfo.EnterDate),
                                  DbHelper.MakeInParam("@TOPOINTNUM", (DbType)SqlDbType.VarChar, 12, measureReplaceInfo.ToPointnum),
                                  DbHelper.MakeInParam("@TOMEASUREMENTVALUE", (DbType)SqlDbType.Decimal, 4, measureReplaceInfo.ToMeasurementValue),
                                  DbHelper.MakeInParam("@CORRECTEDVALUE", (DbType)SqlDbType.Decimal, 4, measureReplaceInfo.CorrectedValue),
                                  DbHelper.MakeInParam("@FROMDEPT", (DbType)SqlDbType.VarChar, 30, measureReplaceInfo.FromDept),
                                  DbHelper.MakeInParam("@FROMLOC", (DbType)SqlDbType.VarChar, 12, measureReplaceInfo.FromLoc),
                                  DbHelper.MakeInParam("@REPLACEPERSON", (DbType)SqlDbType.VarChar, 30, measureReplaceInfo.ReplacePerson),
                                  DbHelper.MakeInParam("@REPLACEDATE", (DbType)SqlDbType.DateTime, 8, measureReplaceInfo.ReplaceDate),
                                  DbHelper.MakeInParam("@REPLACETYPE", (DbType)SqlDbType.VarChar, 16, measureReplaceInfo.ReplaceType),
                                  DbHelper.MakeInParam("@STATUS", (DbType)SqlDbType.VarChar, 16, measureReplaceInfo.ReplaceType),
                                 // DbHelper.MakeInParam("@ORGID", (DbType)SqlDbType.VarChar, 8, measureReplaceInfo.Orgid),
                                 // DbHelper.MakeInParam("@SITEID", (DbType)SqlDbType.VarChar, 8, measureReplaceInfo.Siteid),
                                  DbHelper.MakeInParam("@MEMO", (DbType)SqlDbType.VarChar, 254, measureReplaceInfo.Memo)
                                 };
            string commandText = string.Format("UPDATE [{0}MEASUREREPLACE] SET [POINTNUM]=@POINTNUM,[MEASUREUNITID]=@MEASUREUNITID,[MEASUREMENTVALUE]=@MEASUREMENTVALUE,"
           + "[ENTERBY]=@ENTERBY,[ENTERDATE]=@ENTERDATE,[TOPOINTNUM]=@TOPOINTNUM,[TOMEASUREMENTVALUE]=@TOMEASUREMENTVALUE,[CORRECTEDVALUE]=@CORRECTEDVALUE,"
           + "[FROMDEPT]=@FROMDEPT,[FROMLOC]=@FROMLOC,[REPLACEPERSON]=@REPLACEPERSON,[REPLACEDATE]=@REPLACEDATE,[REPLACETYPE]=@REPLACETYPE,"
           + "[MEMO]=@MEMO,[STATUS]=@STATUS WHERE [MEASURETRANSID]=@MEASURETRANSID", BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms) > 0;
        }

        public int DeleteMeasureReplace(string idList)
        {
            string commandText = string.Format("DELETE FROM [{0}MEASUREREPLACE] WHERE [MEASURETRANSID] IN ({1}))",
                                             BaseConfigs.GetTablePrefix,
                                             idList);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText);
        }

        public int MeasureReplaceCount(string condition)
        {
            if (condition == "")
            {
                condition = "1=1";
            }
            string commandText = string.Format("SELECT COUNT([{0}MEASUREREPLACE].MEASURETRANSID) FROM [{0}MEASUREREPLACE] WHERE 1=1 {1}",
                                             BaseConfigs.GetTablePrefix, condition);
            return TypeConverter.ObjectToInt(DbHelper.ExecuteDataset(CommandType.Text, commandText).Tables[0].Rows[0][0]);
        }
    }
}
