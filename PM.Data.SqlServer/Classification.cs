

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

		public int CreateClassification(ClassificationInfo classificationInfo)
        {
		 DbParameter[] parms = { 
						DbHelper.MakeInParam("@CLASSIFICATIONID", (DbType)SqlDbType.VarChar,20,classificationInfo.Classificationid),
                        DbHelper.MakeInParam("@DESCRIPTION", (DbType)SqlDbType.VarChar,100,classificationInfo.Description)	,
                        DbHelper.MakeInParam("@HASLD", (DbType)SqlDbType.Bit,1,classificationInfo.Hasld)	,
                        DbHelper.MakeInParam("@ORGID", (DbType)SqlDbType.VarChar,8,classificationInfo.Orgid)	,
                        DbHelper.MakeInParam("@SITEID", (DbType)SqlDbType.VarChar,8,classificationInfo.Siteid)	

			};
			string commandText = string.Format("INSERT INTO [{0}CLASSIFICATION] (CLASSIFICATIONID,DESCRIPTION,HASLD,ORGID,SITEID)VALUES(@CLASSIFICATIONID,@DESCRIPTION,@HASLD,@ORGID,@SITEID)",BaseConfigs.GetTablePrefix);
			return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms);
		}
		
		public bool UpdateClassification(ClassificationInfo classificationInfo)
        {
            DbParameter[] parms = { 
			            DbHelper.MakeInParam("@CLASSIFICATIONUID", (DbType)SqlDbType.BigInt,8,classificationInfo.Classificationuid),
                        DbHelper.MakeInParam("@CLASSIFICATIONID", (DbType)SqlDbType.VarChar,20,classificationInfo.Classificationid),
                        DbHelper.MakeInParam("@DESCRIPTION", (DbType)SqlDbType.VarChar,100,classificationInfo.Description)	,
                        DbHelper.MakeInParam("@HASLD", (DbType)SqlDbType.Bit,1,classificationInfo.Hasld)	,
                        DbHelper.MakeInParam("@ORGID", (DbType)SqlDbType.VarChar,8,classificationInfo.Orgid)	,
                        DbHelper.MakeInParam("@SITEID", (DbType)SqlDbType.VarChar,8,classificationInfo.Siteid)	
			};
			string commandText = string.Format("UPDATE [{0}CLASSIFICATION] SET [CLASSIFICATIONID] = @CLASSIFICATIONID,[DESCRIPTION] = @DESCRIPTION,[HASLD] = @HASLD,[ORGID] = @ORGID,[SITEID] = @SITEID WHERE [CLASSIFICATIONUID]=CLASSIFICATIONUID",BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms) > 0;
		}
		
		public int DeleteClassification(string idList)
        {
			string commandText = string.Format("DELETE FROM [{0}CLASSIFICATION] WHERE [MEASUREPOINTID] IN ({1})",
                                              BaseConfigs.GetTablePrefix,
                                              idList);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText);
		}
		
		public DataTable FindClassificationByCondition(string condition)
        {
			string commandText = string.Format("select {0}CLASSIFICATION.* from [{0}CLASSIFICATION] WHERE 1=1 {1}",
                                                BaseConfigs.GetTablePrefix,
                                                condition);
            return DbHelper.ExecuteDataset(CommandType.Text, commandText).Tables[0];
          
		}
		
		
	}
}
