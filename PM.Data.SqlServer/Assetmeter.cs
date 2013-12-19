

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

		public int CreateAssetmeter(AssetmeterInfo assetmeterInfo)
        {
            DbParameter[] parms = { 
						DbHelper.MakeInParam("@ACTIVE", (DbType)SqlDbType.Bit,2,assetmeterInfo.Active),			
                        DbHelper.MakeInParam("@ASSETNUM", (DbType)SqlDbType.VarChar,16,assetmeterInfo.Assetnum),			
                        DbHelper.MakeInParam("@AVERAGE", (DbType)SqlDbType.Decimal,8,assetmeterInfo.Average),			
                        DbHelper.MakeInParam("@AVGCALCMETHOD", (DbType)SqlDbType.VarChar,25,assetmeterInfo.Avgcalcmethod),			
                        DbHelper.MakeInParam("@BASEMEASUREUNITID", (DbType)SqlDbType.VarChar,16,assetmeterInfo.Basemeasureunitid),			
                        DbHelper.MakeInParam("@CHANGEBY", (DbType)SqlDbType.VarChar,30,assetmeterInfo.Changeby),			
                        DbHelper.MakeInParam("@CHANGEDATE", (DbType)SqlDbType.DateTime,8,assetmeterInfo.Changedate),			
                        DbHelper.MakeInParam("@HASLD", (DbType)SqlDbType.Bit,1,assetmeterInfo.Hasld),			
                        DbHelper.MakeInParam("@LANGCODE", (DbType)SqlDbType.VarChar,4,assetmeterInfo.Langcode),			
                        DbHelper.MakeInParam("@LASTREADING", (DbType)SqlDbType.VarChar,18,assetmeterInfo.Lastreading),			
                        DbHelper.MakeInParam("@LASTREADINGDATE", (DbType)SqlDbType.DateTime,8,assetmeterInfo.Lastreadingdate),			
                        DbHelper.MakeInParam("@LASTREADINGINSPCTR", (DbType)SqlDbType.VarChar,30,assetmeterInfo.Lastreadinginspctr),			
                        DbHelper.MakeInParam("@LIFETODATE", (DbType)SqlDbType.Decimal,8,assetmeterInfo.Lifetodate),			
                        DbHelper.MakeInParam("@MEASUREUNITID", (DbType)SqlDbType.VarChar,16,assetmeterInfo.Measureunitid),			
                        DbHelper.MakeInParam("@METERNAME", (DbType)SqlDbType.VarChar,10,assetmeterInfo.Metername),			
                        DbHelper.MakeInParam("@ORGID", (DbType)SqlDbType.VarChar,8,assetmeterInfo.Orgid),			
                        DbHelper.MakeInParam("@POINTNUM", (DbType)SqlDbType.VarChar,20,assetmeterInfo.Pointnum),			
                        DbHelper.MakeInParam("@READINGTYPE", (DbType)SqlDbType.VarChar,10,assetmeterInfo.Readingtype),			
                        DbHelper.MakeInParam("@REMARKS", (DbType)SqlDbType.VarChar,50,assetmeterInfo.Remarks),			
                        DbHelper.MakeInParam("@ROLLDOWNSOURCE", (DbType)SqlDbType.VarChar,14,assetmeterInfo.Rolldownsource),			
                        DbHelper.MakeInParam("@ROLLOVER", (DbType)SqlDbType.Decimal,8,assetmeterInfo.Rollover),			
                        DbHelper.MakeInParam("@SEQUENCE", (DbType)SqlDbType.Int,4,assetmeterInfo.Sequence),			
                        DbHelper.MakeInParam("@SINCEINSTALL", (DbType)SqlDbType.Decimal,8,assetmeterInfo.Sinceinstall),			
                        DbHelper.MakeInParam("@SINCELASTINSPECT", (DbType)SqlDbType.Decimal,8,assetmeterInfo.Sincelastinspect),			
                        DbHelper.MakeInParam("@SINCELASTOVERHAUL", (DbType)SqlDbType.Decimal,8,assetmeterInfo.Sincelastoverhaul),			
                        DbHelper.MakeInParam("@SINCELASTREPAIR", (DbType)SqlDbType.Decimal,8,assetmeterInfo.Sincelastrepair),			
                        DbHelper.MakeInParam("@SITEID", (DbType)SqlDbType.VarChar,8,assetmeterInfo.Siteid),			
                        DbHelper.MakeInParam("@SLIDINGWINDOWSIZE", (DbType)SqlDbType.Int,4,assetmeterInfo.Slidingwindowsize)
			};
			string commandText = string.Format("INSERT INTO [{0}ASSETMETER] (ACTIVE,ASSETNUM,AVERAGE,AVGCALCMETHOD,BASEMEASUREUNITID,CHANGEBY,CHANGEDATE,HASLD,LANGCODE,LASTREADING,LASTREADINGDATE,LASTREADINGINSPCTR,LIFETODATE,MEASUREUNITID,METERNAME,ORGID,POINTNUM,READINGTYPE,REMARKS,ROLLDOWNSOURCE,ROLLOVER,SEQUENCE,SINCEINSTALL,SINCELASTINSPECT,SINCELASTOVERHAUL,SINCELASTREPAIR,SITEID,SLIDINGWINDOWSIZE)VALUES(@ACTIVE,@ASSETNUM,@AVERAGE,@AVGCALCMETHOD,@BASEMEASUREUNITID,@CHANGEBY,@CHANGEDATE,@HASLD,@LANGCODE,@LASTREADING,@LASTREADINGDATE,@LASTREADINGINSPCTR,@LIFETODATE,@MEASUREUNITID,@METERNAME,@ORGID,@POINTNUM,@READINGTYPE,@REMARKS,@ROLLDOWNSOURCE,@ROLLOVER,@SEQUENCE,@SINCEINSTALL,@SINCELASTINSPECT,@SINCELASTOVERHAUL,@SINCELASTREPAIR,@SITEID,@SLIDINGWINDOWSIZE)",BaseConfigs.GetTablePrefix);
			return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms);

			

		}
		
		public bool UpdateAssetmeter(AssetmeterInfo assetmeterInfo)
        {

            DbParameter[] parms = { 
						DbHelper.MakeInParam("@ASSETMETERID", (DbType)SqlDbType.Int,4,assetmeterInfo.Assetmeterid),
                        DbHelper.MakeInParam("@ACTIVE", (DbType)SqlDbType.Bit,2,assetmeterInfo.Active),			
                        DbHelper.MakeInParam("@ASSETNUM", (DbType)SqlDbType.VarChar,16,assetmeterInfo.Assetnum),			
                        DbHelper.MakeInParam("@AVERAGE", (DbType)SqlDbType.Decimal,8,assetmeterInfo.Average),			
                        DbHelper.MakeInParam("@AVGCALCMETHOD", (DbType)SqlDbType.VarChar,25,assetmeterInfo.Avgcalcmethod),			
                        DbHelper.MakeInParam("@BASEMEASUREUNITID", (DbType)SqlDbType.VarChar,16,assetmeterInfo.Basemeasureunitid),			
                        DbHelper.MakeInParam("@CHANGEBY", (DbType)SqlDbType.VarChar,30,assetmeterInfo.Changeby),			
                        DbHelper.MakeInParam("@CHANGEDATE", (DbType)SqlDbType.DateTime,8,assetmeterInfo.Changedate),			
                        DbHelper.MakeInParam("@HASLD", (DbType)SqlDbType.Bit,1,assetmeterInfo.Hasld),			
                        DbHelper.MakeInParam("@LANGCODE", (DbType)SqlDbType.VarChar,4,assetmeterInfo.Langcode),			
                        DbHelper.MakeInParam("@LASTREADING", (DbType)SqlDbType.VarChar,18,assetmeterInfo.Lastreading),			
                        DbHelper.MakeInParam("@LASTREADINGDATE", (DbType)SqlDbType.DateTime,8,assetmeterInfo.Lastreadingdate),			
                        DbHelper.MakeInParam("@LASTREADINGINSPCTR", (DbType)SqlDbType.VarChar,30,assetmeterInfo.Lastreadinginspctr),			
                        DbHelper.MakeInParam("@LIFETODATE", (DbType)SqlDbType.Decimal,8,assetmeterInfo.Lifetodate),			
                        DbHelper.MakeInParam("@MEASUREUNITID", (DbType)SqlDbType.VarChar,16,assetmeterInfo.Measureunitid),			
                        DbHelper.MakeInParam("@METERNAME", (DbType)SqlDbType.VarChar,10,assetmeterInfo.Metername),			
                        DbHelper.MakeInParam("@ORGID", (DbType)SqlDbType.VarChar,8,assetmeterInfo.Orgid),			
                        DbHelper.MakeInParam("@POINTNUM", (DbType)SqlDbType.VarChar,20,assetmeterInfo.Pointnum),			
                        DbHelper.MakeInParam("@READINGTYPE", (DbType)SqlDbType.VarChar,10,assetmeterInfo.Readingtype),			
                        DbHelper.MakeInParam("@REMARKS", (DbType)SqlDbType.VarChar,50,assetmeterInfo.Remarks),			
                        DbHelper.MakeInParam("@ROLLDOWNSOURCE", (DbType)SqlDbType.VarChar,14,assetmeterInfo.Rolldownsource),			
                        DbHelper.MakeInParam("@ROLLOVER", (DbType)SqlDbType.Decimal,8,assetmeterInfo.Rollover),			
                        DbHelper.MakeInParam("@SEQUENCE", (DbType)SqlDbType.Int,4,assetmeterInfo.Sequence),			
                        DbHelper.MakeInParam("@SINCEINSTALL", (DbType)SqlDbType.Decimal,8,assetmeterInfo.Sinceinstall),			
                        DbHelper.MakeInParam("@SINCELASTINSPECT", (DbType)SqlDbType.Decimal,8,assetmeterInfo.Sincelastinspect),			
                        DbHelper.MakeInParam("@SINCELASTOVERHAUL", (DbType)SqlDbType.Decimal,8,assetmeterInfo.Sincelastoverhaul),			
                        DbHelper.MakeInParam("@SINCELASTREPAIR", (DbType)SqlDbType.Decimal,8,assetmeterInfo.Sincelastrepair),			
                        DbHelper.MakeInParam("@SITEID", (DbType)SqlDbType.VarChar,8,assetmeterInfo.Siteid),			
                        DbHelper.MakeInParam("@SLIDINGWINDOWSIZE", (DbType)SqlDbType.Int,4,assetmeterInfo.Slidingwindowsize)
	
			};
			string commandText = string.Format("UPDATE [{0}ASSETMETER] SET [ACTIVE] = @ACTIVE,[ASSETNUM] = @ASSETNUM,[AVERAGE] = @AVERAGE,[AVGCALCMETHOD] = @AVGCALCMETHOD,[BASEMEASUREUNITID] = @BASEMEASUREUNITID,[CHANGEBY] = @CHANGEBY,[CHANGEDATE] = @CHANGEDATE,[HASLD] = @HASLD,[LANGCODE] = @LANGCODE,[LASTREADING] = @LASTREADING,[LASTREADINGDATE] = @LASTREADINGDATE,[LASTREADINGINSPCTR] = @LASTREADINGINSPCTR,[LIFETODATE] = @LIFETODATE,[MEASUREUNITID] = @MEASUREUNITID,[METERNAME] = @METERNAME,[ORGID] = @ORGID,[POINTNUM] = @POINTNUM,[READINGTYPE] = @READINGTYPE,[REMARKS] = @REMARKS,[ROLLDOWNSOURCE] = @ROLLDOWNSOURCE,[ROLLOVER] = @ROLLOVER,[SEQUENCE] = @SEQUENCE,[SINCEINSTALL] = @SINCEINSTALL,[SINCELASTINSPECT] = @SINCELASTINSPECT,[SINCELASTOVERHAUL] = @SINCELASTOVERHAUL,[SINCELASTREPAIR] = @SINCELASTREPAIR,[SITEID] = @SITEID,[SLIDINGWINDOWSIZE] = @SLIDINGWINDOWSIZE WHERE [ASSETMETERID]=@ASSETMETERID",BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms) > 0;
		}
		
		public int DeleteAssetmeter(string idList)
        {
			string commandText = string.Format("DELETE FROM [{0}ASSETMETER] WHERE [MEASUREPOINTID] IN ({1})",
                                              BaseConfigs.GetTablePrefix,
                                              idList);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText);
		}

        public DataTable FindAssetmeterByAssetnum(string assetnum) {
            string commandText = string.Format("select {0}ASSETMETER.* from [{0}ASSETMETER] WHERE ASSETNUM='{1}'",
                                                BaseConfigs.GetTablePrefix,
                                                assetnum);
            return DbHelper.ExecuteDataset(CommandType.Text, commandText).Tables[0];
        }


		public DataTable FindAssetmeterByCondition(string condition)
        {
			string commandText = string.Format("select {0}ASSETMETER.* from [{0}ASSETMETER] WHERE 1=1 {1}",
                                                BaseConfigs.GetTablePrefix,
                                                condition);
            DataTable ret = DbHelper.ExecuteDataset(CommandType.Text, commandText).Tables[0];
            return ret;
          
		}
		
		
		
	}
}
