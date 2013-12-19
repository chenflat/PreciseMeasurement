

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

        public int CreatePmdomain(PmdomainInfo pmdomainInfo) {
            DbParameter[] parms = { 
						DbHelper.MakeInParam("@DOMAINID", (DbType)SqlDbType.VarChar,50,pmdomainInfo.Domainid),
                        DbHelper.MakeInParam("@DESCRIPTION", (DbType)SqlDbType.VarChar,100,pmdomainInfo.Description)	,
                        DbHelper.MakeInParam("@DOMAINTYPE", (DbType)SqlDbType.VarChar,10,pmdomainInfo.Domaintype)	,
                        DbHelper.MakeInParam("@SYSTYPE", (DbType)SqlDbType.VarChar,10,pmdomainInfo.Systype)	,
                        DbHelper.MakeInParam("@LENGTH", (DbType)SqlDbType.Int,4,pmdomainInfo.Length)	
			};
            string commandText = string.Format("INSERT INTO [{0}PMDOMAIN] (DOMAINID,DESCRIPTION,DOMAINTYPE,SYSTYPE,LENGTH)VALUES(@DOMAINID,@DESCRIPTION,@DOMAINTYPE,@SYSTYPE,@LENGTH)", BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms);
        }

        public bool UpdatePmdomain(PmdomainInfo pmdomainInfo) {

            DbParameter[] parms = { 
			            DbHelper.MakeInParam("@SYSDOMAINID", (DbType)SqlDbType.BigInt,8,pmdomainInfo.Sysdomainid),
			            DbHelper.MakeInParam("@DOMAINID", (DbType)SqlDbType.VarChar,50,pmdomainInfo.Domainid),
                        DbHelper.MakeInParam("@DESCRIPTION", (DbType)SqlDbType.VarChar,100,pmdomainInfo.Description)	,
                        DbHelper.MakeInParam("@DOMAINTYPE", (DbType)SqlDbType.VarChar,10,pmdomainInfo.Domaintype)	,
                        DbHelper.MakeInParam("@SYSTYPE", (DbType)SqlDbType.VarChar,10,pmdomainInfo.Systype)	,
                        DbHelper.MakeInParam("@LENGTH", (DbType)SqlDbType.Int,4,pmdomainInfo.Length)	
			};
            string commandText = string.Format("UPDATE [{0}PMDOMAIN] SET [DOMAINID] = @DOMAINID,[DESCRIPTION] = @DESCRIPTION,[DOMAINTYPE] = @DOMAINTYPE,[SYSTYPE] = @SYSTYPE,[LENGTH] = @LENGTH WHERE [SYSDOMAINID]=@SYSDOMAINID", BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms) > 0;
        }

        public int DeletePmdomain(string idList) {
            string commandText = string.Format("DELETE FROM [{0}PMDOMAIN] WHERE [MEASUREPOINTID] IN ({1})",
                                              BaseConfigs.GetTablePrefix,
                                              idList);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText);
        }

        public DataTable FindPmdomainByCondition(string condition) {
            string commandText = string.Format("select {0}PMDOMAIN.* from [{0}PMDOMAIN] WHERE 1=1 {1}",
                                                BaseConfigs.GetTablePrefix,
                                                condition);
            return DbHelper.ExecuteDataset(CommandType.Text, commandText).Tables[0];

        }


    }
}
