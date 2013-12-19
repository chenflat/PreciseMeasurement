

using System;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

using PM.Data;
using PM.Config;
using PM.Common;
using PM.Entity;

namespace PM.Data.SqlServer {
    /// -----------------------------------------------------------------------------
    /// <summary>
    ///		The DataProvider class is an abstract class that provides the data layer
    ///		for the SqlServer module.
    /// </summary>
    /// <remarks></remarks>
    /// <history>
    ///		[CHENPING]	2013-12-18 22:31:59 Code file automatically generated from MeasureSystem
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class DataProvider : IDataProvider {

        public int CreateLongdescription(LongdescriptionInfo longdescriptionInfo) {
            DbParameter[] parms = { 
                        DbHelper.MakeInParam("@LDKEY", (DbType)SqlDbType.BigInt,8,longdescriptionInfo.Ldkey)	,
                        DbHelper.MakeInParam("@LDOWNERTABLE", (DbType)SqlDbType.VarChar,30,longdescriptionInfo.Ldownertable)	,
                        DbHelper.MakeInParam("@LDOWNERCOLE", (DbType)SqlDbType.VarChar,30,longdescriptionInfo.Ldownercole)	,
                        DbHelper.MakeInParam("@LDTEXT", (DbType)SqlDbType.VarChar,4000,longdescriptionInfo.Ldtext)	,
                        DbHelper.MakeInParam("@LANGCODE", (DbType)SqlDbType.VarChar,4,longdescriptionInfo.Langcode)	,
                        DbHelper.MakeInParam("@CONTENTUID", (DbType)SqlDbType.VarChar,10,longdescriptionInfo.Contentuid)	
			};
            string commandText = string.Format("INSERT INTO [{0}LONGDESCRIPTION] (LDKEY,LDOWNERTABLE,LDOWNERCOLE,LDTEXT,LANGCODE,CONTENTUID)VALUES(@LDKEY,@LDOWNERTABLE,@LDOWNERCOLE,@LDTEXT,@LANGCODE,@CONTENTUID)", BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms);
        }

        public bool UpdateLongdescriptionById(LongdescriptionInfo longdescriptionInfo) {

            DbParameter[] parms = { 
						DbHelper.MakeInParam("@LONGDESCRIPTIONID", (DbType)SqlDbType.BigInt,8,longdescriptionInfo.Longdescriptionid),
                        DbHelper.MakeInParam("@LDKEY", (DbType)SqlDbType.BigInt,8,longdescriptionInfo.Ldkey)	,
                        DbHelper.MakeInParam("@LDOWNERTABLE", (DbType)SqlDbType.VarChar,30,longdescriptionInfo.Ldownertable)	,
                        DbHelper.MakeInParam("@LDOWNERCOLE", (DbType)SqlDbType.VarChar,30,longdescriptionInfo.Ldownercole)	,
                        DbHelper.MakeInParam("@LDTEXT", (DbType)SqlDbType.VarChar,4000,longdescriptionInfo.Ldtext)	,
                        DbHelper.MakeInParam("@LANGCODE", (DbType)SqlDbType.VarChar,4,longdescriptionInfo.Langcode)	,
                        DbHelper.MakeInParam("@CONTENTUID", (DbType)SqlDbType.VarChar,10,longdescriptionInfo.Contentuid)	
			};
            string commandText = string.Format("UPDATE [{0}LONGDESCRIPTION] SET [LDKEY] = @LDKEY,[LDOWNERTABLE] = @LDOWNERTABLE,[LDOWNERCOLE] = @LDOWNERCOLE,[LDTEXT] = @LDTEXT,[LANGCODE] = @LANGCODE,[CONTENTUID] = @CONTENTUID WHERE [LONGDESCRIPTIONID]=@LONGDESCRIPTIONID", BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms) > 0;
        }

        public bool UpdateLongdescriptionByKey(LongdescriptionInfo longdescriptionInfo) {

            DbParameter[] parms = { 
						DbHelper.MakeInParam("@LONGDESCRIPTIONID", (DbType)SqlDbType.BigInt,8,longdescriptionInfo.Longdescriptionid),
                        DbHelper.MakeInParam("@LDKEY", (DbType)SqlDbType.BigInt,8,longdescriptionInfo.Ldkey)	,
                        DbHelper.MakeInParam("@LDOWNERTABLE", (DbType)SqlDbType.VarChar,30,longdescriptionInfo.Ldownertable)	,
                        DbHelper.MakeInParam("@LDOWNERCOLE", (DbType)SqlDbType.VarChar,30,longdescriptionInfo.Ldownercole)	,
                        DbHelper.MakeInParam("@LDTEXT", (DbType)SqlDbType.VarChar,4000,longdescriptionInfo.Ldtext)	,
                        DbHelper.MakeInParam("@LANGCODE", (DbType)SqlDbType.VarChar,4,longdescriptionInfo.Langcode)	,
                        DbHelper.MakeInParam("@CONTENTUID", (DbType)SqlDbType.VarChar,10,longdescriptionInfo.Contentuid)	
			};
            string commandText = string.Format("UPDATE [{0}LONGDESCRIPTION] SET [LDTEXT] = @LDTEXT,[LANGCODE] = @LANGCODE WHERE [LDKEY]=@LDKEY and [LDOWNERTABLE]=@LDOWNERTABLE,[LDOWNERCOLE]=@LDOWNERCOLE,", BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms) > 0;
        }

        public int DeleteLongdescription(string idList) {
            string commandText = string.Format("DELETE FROM [{0}LONGDESCRIPTION] WHERE [MEASUREPOINTID] IN ({1})",
                                              BaseConfigs.GetTablePrefix,
                                              idList);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText);
        }

        public DataTable FindLongdescriptionByCondition(string condition) {
            string commandText = string.Format("select {0}LONGDESCRIPTION.* from [{0}LONGDESCRIPTION] WHERE 1=1 {1}",
                                                BaseConfigs.GetTablePrefix,
                                                condition);
            return DbHelper.ExecuteDataset(CommandType.Text, commandText).Tables[0];

        }


    }
}
