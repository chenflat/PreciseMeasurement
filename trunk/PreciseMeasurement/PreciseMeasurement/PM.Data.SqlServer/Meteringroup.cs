

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

		public int CreateMeteringroup(MeteringroupInfo meteringroupInfo)
        {
		 DbParameter[] parms = { 
						DbHelper.MakeInParam("@AVGCALCMETHOD", (DbType)SqlDbType.VarChar,25,meteringroupInfo.Avgcalcmethod),			
                        DbHelper.MakeInParam("@GROUPNAME", (DbType)SqlDbType.VarChar,10,meteringroupInfo.Groupname),			
                        DbHelper.MakeInParam("@METERNAME", (DbType)SqlDbType.VarChar,10,meteringroupInfo.Metername),			
                        DbHelper.MakeInParam("@ROLLOVER", (DbType)SqlDbType.Decimal,8,meteringroupInfo.Rollover),			
                        DbHelper.MakeInParam("@SEQUENCE", (DbType)SqlDbType.Int,4,meteringroupInfo.Sequence),		
                        DbHelper.MakeInParam("@SLIDINGWINDOWSIZE", (DbType)SqlDbType.Int,4,meteringroupInfo.Slidingwindowsize),			
                        DbHelper.MakeInParam("@STATICAVERAGE", (DbType)SqlDbType.Decimal,8,meteringroupInfo.Staticaverage)
			};
			string commandText = string.Format("INSERT INTO [{0}METERINGROUP] (AVGCALCMETHOD,GROUPNAME,METERNAME,ROLLOVER,SEQUENCE,SLIDINGWINDOWSIZE,STATICAVERAGE)VALUES(@AVGCALCMETHOD,@GROUPNAME,@METERNAME,@ROLLOVER,@SEQUENCE,@SLIDINGWINDOWSIZE,@STATICAVERAGE)",BaseConfigs.GetTablePrefix);
			return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms);

			
		}
		
		public bool UpdateMeteringroup(MeteringroupInfo meteringroupInfo)
        {

            DbParameter[] parms = { 
			            DbHelper.MakeInParam("@METERINGROUPID", (DbType)SqlDbType.BigInt,8,meteringroupInfo.Meteringroupid),
                        DbHelper.MakeInParam("@AVGCALCMETHOD", (DbType)SqlDbType.VarChar,25,meteringroupInfo.Avgcalcmethod),			
                        DbHelper.MakeInParam("@GROUPNAME", (DbType)SqlDbType.VarChar,10,meteringroupInfo.Groupname),			
                        DbHelper.MakeInParam("@METERNAME", (DbType)SqlDbType.VarChar,10,meteringroupInfo.Metername),			
                        DbHelper.MakeInParam("@ROLLOVER", (DbType)SqlDbType.Decimal,8,meteringroupInfo.Rollover),			
                        DbHelper.MakeInParam("@SEQUENCE", (DbType)SqlDbType.Int,4,meteringroupInfo.Sequence),		
                        DbHelper.MakeInParam("@SLIDINGWINDOWSIZE", (DbType)SqlDbType.Int,4,meteringroupInfo.Slidingwindowsize),			
                        DbHelper.MakeInParam("@STATICAVERAGE", (DbType)SqlDbType.Decimal,8,meteringroupInfo.Staticaverage)
			
			};
			string commandText = string.Format("UPDATE [{0}METERINGROUP] SET [AVGCALCMETHOD] = @AVGCALCMETHOD,[GROUPNAME] = @GROUPNAME,[METERNAME] = @METERNAME,[ROLLOVER] = @ROLLOVER,[SEQUENCE] = @SEQUENCE,[SLIDINGWINDOWSIZE] = @SLIDINGWINDOWSIZE,[STATICAVERAGE] = @STATICAVERAGEWHERE [METERINGROUPID]=@METERINGROUPID",BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms) > 0;
		}
		
		public int DeleteMeteringroup(string idList)
        {
			string commandText = string.Format("DELETE FROM [{0}METERINGROUP] WHERE [MEASUREPOINTID] IN ({1})",
                                              BaseConfigs.GetTablePrefix,
                                              idList);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText);
		}
		
		public DataTable FindMeteringroupByCondition(string condition)
        {
			string commandText = string.Format("select {0}METERINGROUP.* from [{0}METERINGROUP] WHERE 1=1 {1}",
                                                BaseConfigs.GetTablePrefix,
                                                condition);
            return DbHelper.ExecuteDataset(CommandType.Text, commandText).Tables[0];
          
		}
		
		
	}
}
