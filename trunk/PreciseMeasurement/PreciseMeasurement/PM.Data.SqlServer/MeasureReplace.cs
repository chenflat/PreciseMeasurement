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
            string commandText = string.Format("SELECT {0} FROM [{1}MEASUREREPLACE] {2}",
                                                 DbFields.MEASUREREPLACE,
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

        public int CreateMeasureReplace(MeasureReplaceInfo measureReplaceInfo) {

            DbParameter[] parms = { 
                                  DbHelper.MakeInParam("@POINTNUM", (DbType)SqlDbType.VarChar, 12, measureReplaceInfo.Pointnum),
                                  DbHelper.MakeInParam("@MEASUREMENTVALUE", (DbType)SqlDbType.Decimal, 4, measureReplaceInfo.Measurementvalue),
                                  DbHelper.MakeInParam("@ENTERBY", (DbType)SqlDbType.VarChar, 100, measureReplaceInfo.EnterBy),
                                  DbHelper.MakeInParam("@ENTERDATE", (DbType)SqlDbType.DateTime, 8, measureReplaceInfo.EnterDate),
                                  DbHelper.MakeInParam("@TOPOINTNUM", (DbType)SqlDbType.VarChar, 12, measureReplaceInfo.ToPointnum),
                                  DbHelper.MakeInParam("@TOMEASUREMENTVALUE", (DbType)SqlDbType.Decimal, 4, measureReplaceInfo.ToMeasurementValue),
                                  DbHelper.MakeInParam("@FROMDEPT", (DbType)SqlDbType.VarChar, 30, measureReplaceInfo.FromDept),
                                  DbHelper.MakeInParam("@FROMLOC", (DbType)SqlDbType.VarChar, 12, measureReplaceInfo.FromLoc),
                                  DbHelper.MakeInParam("@REPLACEDATE", (DbType)SqlDbType.DateTime, 8, measureReplaceInfo.ReplaceDate),
                                  DbHelper.MakeInParam("@REPLACETYPE", (DbType)SqlDbType.VarChar, 16, measureReplaceInfo.ReplaceType),
                                  DbHelper.MakeInParam("@ORGID", (DbType)SqlDbType.VarChar, 8, measureReplaceInfo.Orgid),
                                  DbHelper.MakeInParam("@SITEID", (DbType)SqlDbType.VarChar, 8, measureReplaceInfo.Siteid),
                                  DbHelper.MakeInParam("@MEMO", (DbType)SqlDbType.VarChar, 254, measureReplaceInfo.Memo)
                                 };

            string commandText = string.Format("INSERT INTO [{0}MEASUREREPLACE] ([POINTNUM],[MEASUREMENTVALUE],[ENTERBY],[ENTERDATE],"
                             + "[TOPOINTNUM],[TOMEASUREMENTVALUE],[FROMDEPT],[FROMLOC],[REPLACEDATE],[REPLACETYPE],"
                             + "[ORGID],[SITEID],[MEMO]) VALUES(@POINTNUM, @MEASUREMENTVALUE, @ENTERBY, @ENTERDATE, @TOPOINTNUM,"
                             + " @TOMEASUREMENTVALUE, @FROMDEPT,@FROMLOC,@REPLACEDATE,@REPLACETYPE,@ORGID,@SITEID,@MEMO)", BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms);
        }

        public bool UpdateMeasureReplace(MeasureReplaceInfo measureReplaceInfo) {
            DbParameter[] parms = { 
                                  DbHelper.MakeInParam("@MEASURETRANSID", (DbType)SqlDbType.BigInt, 8, measureReplaceInfo.Measuretransid),
                                  DbHelper.MakeInParam("@POINTNUM", (DbType)SqlDbType.VarChar, 12, measureReplaceInfo.Pointnum),
                                  DbHelper.MakeInParam("@MEASUREMENTVALUE", (DbType)SqlDbType.Decimal, 4, measureReplaceInfo.Measurementvalue),
                                  DbHelper.MakeInParam("@ENTERBY", (DbType)SqlDbType.VarChar, 100, measureReplaceInfo.EnterBy),
                                  DbHelper.MakeInParam("@ENTERDATE", (DbType)SqlDbType.DateTime, 8, measureReplaceInfo.EnterDate),
                                  DbHelper.MakeInParam("@TOPOINTNUM", (DbType)SqlDbType.VarChar, 12, measureReplaceInfo.ToPointnum),
                                  DbHelper.MakeInParam("@TOMEASUREMENTVALUE", (DbType)SqlDbType.Decimal, 4, measureReplaceInfo.ToMeasurementValue),
                                  DbHelper.MakeInParam("@FROMDEPT", (DbType)SqlDbType.VarChar, 30, measureReplaceInfo.FromDept),
                                  DbHelper.MakeInParam("@FROMLOC", (DbType)SqlDbType.VarChar, 12, measureReplaceInfo.FromLoc),
                                  DbHelper.MakeInParam("@REPLACEDATE", (DbType)SqlDbType.DateTime, 8, measureReplaceInfo.ReplaceDate),
                                  DbHelper.MakeInParam("@REPLACETYPE", (DbType)SqlDbType.VarChar, 16, measureReplaceInfo.ReplaceType),
                                  DbHelper.MakeInParam("@ORGID", (DbType)SqlDbType.VarChar, 8, measureReplaceInfo.Orgid),
                                  DbHelper.MakeInParam("@SITEID", (DbType)SqlDbType.VarChar, 8, measureReplaceInfo.Siteid),
                                  DbHelper.MakeInParam("@MEMO", (DbType)SqlDbType.VarChar, 254, measureReplaceInfo.Memo)
                                 };
            string commandText = string.Format("UPDATE [{0}MEASUREREPLACE] SET [POINTNUM]=@POINTNUM,[MEASUREMENTVALUE]=@MEASUREMENTVALUE,"
           + "[ENTERBY]=@ENTERBY,[ENTERDATE]=@ENTERDATE,[TOPOINTNUM]=@TOPOINTNUM,[TOMEASUREMENTVALUE]=@TOMEASUREMENTVALUE,"
           + "[FROMDEPT]=@FROMDEPT,[FROMLOC]=@FROMLOC,[REPLACEDATE]=@REPLACEDATE,[REPLACETYPE]=@REPLACETYPE,ORGID=@ORGID,"
           + "[SITEID]=@SITEID,[MEMO]=@MEMO WHERE [MEASURETRANSID]=@MEASURETRANSID", BaseConfigs.GetTablePrefix);
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
            string commandText = string.Format("SELECT COUNT(MEASURETRANSID) FROM [{0}MEASUREREPLACE] WHERE {1})",
                                             BaseConfigs.GetTablePrefix);
            return TypeConverter.ObjectToInt(DbHelper.ExecuteDataset(CommandType.Text, commandText).Tables[0].Rows[0][0]);
        }
    }
}
