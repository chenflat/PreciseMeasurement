

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
	///		[CHENPING]	2013-12-18 22:31:58 Code file automatically generated from MeasureSystem
	/// </history>
	/// -----------------------------------------------------------------------------
	public partial class DataProvider : IDataProvider
	{

		public int CreateClassspec(ClassspecInfo classspecInfo)
        {
		 DbParameter[] parms = { 
                DbHelper.MakeInParam("@APPLYDOWNHIER", (DbType)SqlDbType.Bit,1,classspecInfo.Applydownhier)	,
                DbHelper.MakeInParam("@ASSETATTRIBUTEID", (DbType)SqlDbType.BigInt,8,classspecInfo.Assetattributeid)	,
                DbHelper.MakeInParam("@ASSETATTRID", (DbType)SqlDbType.VarChar,8,classspecInfo.Assetattrid)	,
                DbHelper.MakeInParam("@ATTRDESCPREFIX", (DbType)SqlDbType.VarChar,8,classspecInfo.Attrdescprefix)	,
                DbHelper.MakeInParam("@CLASSSTRUCTUREID", (DbType)SqlDbType.VarChar,20,classspecInfo.Classstructureid)	,
                DbHelper.MakeInParam("@DOMAINID", (DbType)SqlDbType.VarChar,18,classspecInfo.Domainid)	,
                DbHelper.MakeInParam("@INHERITEDFROM", (DbType)SqlDbType.VarChar,254,classspecInfo.Inheritedfrom)	,
                DbHelper.MakeInParam("@INHERITEDFROMID", (DbType)SqlDbType.Int,4,classspecInfo.Inheritedfromid)	,
                DbHelper.MakeInParam("@LOOKUPNAME", (DbType)SqlDbType.VarChar,30,classspecInfo.Lookupname)	,
                DbHelper.MakeInParam("@MEASUREUNITID", (DbType)SqlDbType.VarChar,16,classspecInfo.Measureunitid)	,
                DbHelper.MakeInParam("@ORGID", (DbType)SqlDbType.VarChar,8,classspecInfo.Orgid)	,
                DbHelper.MakeInParam("@SECTION", (DbType)SqlDbType.VarChar,10,classspecInfo.Section)	,
                DbHelper.MakeInParam("@SITEID", (DbType)SqlDbType.VarChar,8,classspecInfo.Siteid)	,
                DbHelper.MakeInParam("@TABLEATTRIBUTE", (DbType)SqlDbType.VarChar,50,classspecInfo.Tableattribute)	
			};
			string commandText = string.Format("INSERT INTO [{0}CLASSSPEC] (APPLYDOWNHIER,ASSETATTRIBUTEID,ASSETATTRID,ATTRDESCPREFIX,CLASSSTRUCTUREID,DOMAINID,INHERITEDFROM,INHERITEDFROMID,LOOKUPNAME,MEASUREUNITID,ORGID,SECTION,SITEID,TABLEATTRIBUTE)VALUES(@APPLYDOWNHIER,@ASSETATTRIBUTEID,@ASSETATTRID,@ATTRDESCPREFIX,@CLASSSTRUCTUREID,@DOMAINID,@INHERITEDFROM,@INHERITEDFROMID,@LOOKUPNAME,@MEASUREUNITID,@ORGID,@SECTION,@SITEID,@TABLEATTRIBUTE)",BaseConfigs.GetTablePrefix);
			return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms);
		}
		
		public bool UpdateClassspec(ClassspecInfo classspecInfo)
        {

            DbParameter[] parms = { 
                DbHelper.MakeInParam("@CLASSSPECID", (DbType)SqlDbType.BigInt,8,classspecInfo.Classspecid),
                DbHelper.MakeInParam("@APPLYDOWNHIER", (DbType)SqlDbType.Bit,1,classspecInfo.Applydownhier)	,
                DbHelper.MakeInParam("@ASSETATTRIBUTEID", (DbType)SqlDbType.BigInt,8,classspecInfo.Assetattributeid)	,
                DbHelper.MakeInParam("@ASSETATTRID", (DbType)SqlDbType.VarChar,8,classspecInfo.Assetattrid)	,
                DbHelper.MakeInParam("@ATTRDESCPREFIX", (DbType)SqlDbType.VarChar,8,classspecInfo.Attrdescprefix)	,
                DbHelper.MakeInParam("@CLASSSTRUCTUREID", (DbType)SqlDbType.VarChar,20,classspecInfo.Classstructureid)	,
                DbHelper.MakeInParam("@DOMAINID", (DbType)SqlDbType.VarChar,18,classspecInfo.Domainid)	,
                DbHelper.MakeInParam("@INHERITEDFROM", (DbType)SqlDbType.VarChar,254,classspecInfo.Inheritedfrom)	,
                DbHelper.MakeInParam("@INHERITEDFROMID", (DbType)SqlDbType.Int,4,classspecInfo.Inheritedfromid)	,
                DbHelper.MakeInParam("@LOOKUPNAME", (DbType)SqlDbType.VarChar,30,classspecInfo.Lookupname)	,
                DbHelper.MakeInParam("@MEASUREUNITID", (DbType)SqlDbType.VarChar,16,classspecInfo.Measureunitid)	,
                DbHelper.MakeInParam("@ORGID", (DbType)SqlDbType.VarChar,8,classspecInfo.Orgid)	,
                DbHelper.MakeInParam("@SECTION", (DbType)SqlDbType.VarChar,10,classspecInfo.Section)	,
                DbHelper.MakeInParam("@SITEID", (DbType)SqlDbType.VarChar,8,classspecInfo.Siteid)	,
                DbHelper.MakeInParam("@TABLEATTRIBUTE", (DbType)SqlDbType.VarChar,50,classspecInfo.Tableattribute)
			};
			string commandText = string.Format("UPDATE [{0}CLASSSPEC] SET [APPLYDOWNHIER] = @APPLYDOWNHIER,[ASSETATTRIBUTEID] = @ASSETATTRIBUTEID,[ASSETATTRID] = @ASSETATTRID,[ATTRDESCPREFIX] = @ATTRDESCPREFIX,[CLASSSTRUCTUREID] = @CLASSSTRUCTUREID,[DOMAINID] = @DOMAINID,[INHERITEDFROM] = @INHERITEDFROM,[INHERITEDFROMID] = @INHERITEDFROMID,[LOOKUPNAME] = @LOOKUPNAME,[MEASUREUNITID] = @MEASUREUNITID,[ORGID] = @ORGID,[SECTION] = @SECTION,[SITEID] = @SITEID,[TABLEATTRIBUTE] = @TABLEATTRIBUTE WHERE [CLASSSPECID]=@CLASSSPECID",BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms) > 0;
		}
		
		public int DeleteClassspec(string idList)
        {
			string commandText = string.Format("DELETE FROM [{0}CLASSSPEC] WHERE [MEASUREPOINTID] IN ({1})",
                                              BaseConfigs.GetTablePrefix,
                                              idList);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText);
		}
		
		public DataTable FindClassspecByCondition(string condition)
        {
			string commandText = string.Format("select {0}CLASSSPEC.* from [{0}CLASSSPEC] WHERE 1=1 {1}",
                                                BaseConfigs.GetTablePrefix,
                                                condition);
            return DbHelper.ExecuteDataset(CommandType.Text, commandText).Tables[0];
          
		}

		
	}
}
