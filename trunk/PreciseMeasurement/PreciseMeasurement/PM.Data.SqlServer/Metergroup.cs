

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
    ///		[CHENPING]	2013-12-18 22:32:00 Code file automatically generated from MeasureSystem
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class DataProvider : IDataProvider {

        public int CreateMetergroup(MetergroupInfo metergroupInfo) {
            DbParameter[] parms = { 
			    DbHelper.MakeInParam("@DESCRIPTION", (DbType)SqlDbType.VarChar,100,metergroupInfo.Description),
                DbHelper.MakeInParam("@GROUPNAME", (DbType)SqlDbType.VarChar,10,metergroupInfo.Groupname),
                DbHelper.MakeInParam("@HASLD", (DbType)SqlDbType.Bit,1,metergroupInfo.Hasld),			
                DbHelper.MakeInParam("@LANGCODE", (DbType)SqlDbType.VarChar,4,metergroupInfo.Langcode)
			};
            string commandText = string.Format("INSERT INTO [{0}METERGROUP] (DESCRIPTION,GROUPNAME,HASLD,LANGCODE)VALUES(@DESCRIPTION,@GROUPNAME,@HASLD,@LANGCODE)", BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms);
        }

        public bool UpdateMetergroup(MetergroupInfo metergroupInfo) {

            DbParameter[] parms = { 
				DbHelper.MakeInParam("@DESCRIPTION", (DbType)SqlDbType.VarChar,100,metergroupInfo.Description),
                DbHelper.MakeInParam("@GROUPNAME", (DbType)SqlDbType.VarChar,10,metergroupInfo.Groupname),
                DbHelper.MakeInParam("@HASLD", (DbType)SqlDbType.Bit,1,metergroupInfo.Hasld),			
                DbHelper.MakeInParam("@LANGCODE", (DbType)SqlDbType.VarChar,4,metergroupInfo.Langcode),
			    DbHelper.MakeInParam("@METERGROUPID", (DbType)SqlDbType.BigInt,8,metergroupInfo.Metergroupid)
			};
            string commandText = string.Format("UPDATE [{0}METERGROUP] SET [DESCRIPTION] = @DESCRIPTION,[GROUPNAME] = @GROUPNAME,[HASLD] = @HASLD,[LANGCODE] = @LANGCODE WHERE [METERGROUPID]=@METERGROUPID", BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms) > 0;
        }

        public int DeleteMetergroup(string idList) {
            string commandText = string.Format("DELETE FROM [{0}METERGROUP] WHERE [MEASUREPOINTID] IN ({1})",
                                              BaseConfigs.GetTablePrefix,
                                              idList);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText);
        }

        public DataTable FindMetergroupByCondition(string condition) {
            string commandText = string.Format("select {0}METERGROUP.* from [{0}METERGROUP] WHERE 1=1 {1}",
                                                BaseConfigs.GetTablePrefix,
                                                condition);
            return DbHelper.ExecuteDataset(CommandType.Text, commandText).Tables[0];

        }


    }
}
