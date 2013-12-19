

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
	public partial class DataProvider : IDataProvider
	{

		public int CreateSynonymdomain(SynonymdomainInfo synonymdomainInfo)
        {
		 DbParameter[] parms = { 
						DbHelper.MakeInParam("@DEFAULTS", (DbType)SqlDbType.Bit,synonymdomainInfo.Defaults)
,			DbHelper.MakeInParam("@DESCRIPTION", (DbType)SqlDbType.VarChar,synonymdomainInfo.Description)
,			DbHelper.MakeInParam("@DOMAINID", (DbType)SqlDbType.VarChar,synonymdomainInfo.Domainid)
,			DbHelper.MakeInParam("@ORGID", (DbType)SqlDbType.VarChar,synonymdomainInfo.Orgid)
,			DbHelper.MakeInParam("@SITEID", (DbType)SqlDbType.VarChar,synonymdomainInfo.Siteid)
,			DbHelper.MakeInParam("@SYNONYMDOMAINID", (DbType)SqlDbType.BigInt, 0)
,			DbHelper.MakeInParam("@VALUE", (DbType)SqlDbType.VarChar,synonymdomainInfo.Value)
,			DbHelper.MakeInParam("@VALUEID", (DbType)SqlDbType.VarChar,synonymdomainInfo.Valueid)
			}
			string commandText = string.Format("INSERT INTO [{0}SYNONYMDOMAIN] (
DEFAULTS,DESCRIPTION,DOMAINID,ORGID,SITEID,VALUE,VALUEID
)VALUES(@DEFAULTS,@DESCRIPTION,@DOMAINID,@ORGID,@SITEID,@VALUE,@VALUEID)",BaseConfigs.GetTablePrefix);
			return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms);


		}
		
		public bool UpdateSynonymdomain(SynonymdomainInfo synonymdomainInfo)
        {
		
			DbParameter[] parms = { 
						DbHelper.MakeInParam("@DEFAULTS", (DbType)SqlDbType.Bit,synonymdomainInfo.Defaults)
,			DbHelper.MakeInParam("@DESCRIPTION", (DbType)SqlDbType.VarChar,synonymdomainInfo.Description)
,			DbHelper.MakeInParam("@DOMAINID", (DbType)SqlDbType.VarChar,synonymdomainInfo.Domainid)
,			DbHelper.MakeInParam("@ORGID", (DbType)SqlDbType.VarChar,synonymdomainInfo.Orgid)
,			DbHelper.MakeInParam("@SITEID", (DbType)SqlDbType.VarChar,synonymdomainInfo.Siteid)
,			DbHelper.MakeInParam("@SYNONYMDOMAINID", (DbType)SqlDbType.BigInt,synonymdomainInfo.Synonymdomainid)
,			DbHelper.MakeInParam("@VALUE", (DbType)SqlDbType.VarChar,synonymdomainInfo.Value)
,			DbHelper.MakeInParam("@VALUEID", (DbType)SqlDbType.VarChar,synonymdomainInfo.Valueid)
			}
			string commandText = string.Format("UPDATE [{0}SYNONYMDOMAIN] SET 
[DEFAULTS] = @DEFAULTS,[DESCRIPTION] = @DESCRIPTION,[DOMAINID] = @DOMAINID,[ORGID] = @ORGID,[SITEID] = @SITEID,[VALUE] = @VALUE,[VALUEID] = @VALUEID
			WHERE
			[DEFAULTS]=@DEFAULTS
			",BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms);
		}
		
		public int DeleteSynonymdomain(string idList)
        {
			string commandText = string.Format("DELETE FROM [{0}SYNONYMDOMAIN] WHERE [MEASUREPOINTID] IN ({1})",
                                              BaseConfigs.GetTablePrefix,
                                              idList);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText);
		}
		
		public DataTable FindSynonymdomainByCondition(string condition)
        {
			string commandText = string.Format("select {0}SYNONYMDOMAIN.* from [{0}SYNONYMDOMAIN] WHERE 1=1 {1}",
                                                BaseConfigs.GetTablePrefix,
                                                condition);
            return DbHelper.ExecuteDataset(CommandType.Text, commandText).Tables[0];
          
		}

		
	}
}
