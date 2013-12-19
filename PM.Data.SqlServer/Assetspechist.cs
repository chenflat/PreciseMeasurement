

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
    ///		[CHENPING]	2013-12-18 22:31:58 Code file automatically generated from MeasureSystem
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class DataProvider : IDataProvider {

        public int CreateAssetspechist(AssetspechistInfo assetspechistInfo) {
            DbParameter[] parms = { 
			DbHelper.MakeInParam("@ALNVALUE", (DbType)SqlDbType.VarChar,254,assetspechistInfo.Alnvalue),
            DbHelper.MakeInParam("@ASSETATTRID", (DbType)SqlDbType.VarChar,8,assetspechistInfo.Assetattrid)	,
            DbHelper.MakeInParam("@ASSETNUM", (DbType)SqlDbType.VarChar,16,assetspechistInfo.Assetnum)	,
            DbHelper.MakeInParam("@ASSETSPECID", (DbType)SqlDbType.BigInt,8,assetspechistInfo.Assetspecid)	,
            DbHelper.MakeInParam("@BASEMEASUREUNITID", (DbType)SqlDbType.VarChar,16,assetspechistInfo.Basemeasureunitid)	,
            DbHelper.MakeInParam("@CHANGEBY", (DbType)SqlDbType.VarChar,30,assetspechistInfo.Changeby)	,
            DbHelper.MakeInParam("@CHANGEDATE", (DbType)SqlDbType.DateTime,8,assetspechistInfo.Changedate)	,
            DbHelper.MakeInParam("@CLASSSPECID", (DbType)SqlDbType.BigInt,8,assetspechistInfo.Classspecid)	,
            DbHelper.MakeInParam("@CLASSSTRUCTUREID", (DbType)SqlDbType.VarChar,20,assetspechistInfo.Classstructureid)	,
            DbHelper.MakeInParam("@CREATEDDATE", (DbType)SqlDbType.DateTime,8,assetspechistInfo.Createddate)	,
            DbHelper.MakeInParam("@DISPLAYSEQUENCE", (DbType)SqlDbType.Int,4,assetspechistInfo.Displaysequence)	,
            DbHelper.MakeInParam("@LINKEDTOATTRIBUTE", (DbType)SqlDbType.VarChar,8,assetspechistInfo.Linkedtoattribute)	,
            DbHelper.MakeInParam("@LINKEDTOSECTION", (DbType)SqlDbType.VarChar,10,assetspechistInfo.Linkedtosection)	,
            DbHelper.MakeInParam("@MANDATORY", (DbType)SqlDbType.Bit,1,assetspechistInfo.Mandatory)	,
            DbHelper.MakeInParam("@MEASUREUNITID", (DbType)SqlDbType.VarChar,16,assetspechistInfo.Measureunitid)	,
            DbHelper.MakeInParam("@NUMVALUE", (DbType)SqlDbType.Decimal,26,assetspechistInfo.Numvalue)	,
            DbHelper.MakeInParam("@ORGID", (DbType)SqlDbType.VarChar,8,assetspechistInfo.Orgid)	,
            DbHelper.MakeInParam("@REMOVEDDATE", (DbType)SqlDbType.DateTime,8,assetspechistInfo.Removeddate)	,
            DbHelper.MakeInParam("@SECTION", (DbType)SqlDbType.VarChar,10,assetspechistInfo.Section)	,
            DbHelper.MakeInParam("@SITEID", (DbType)SqlDbType.VarChar,8,assetspechistInfo.Siteid)

			};
            string commandText = string.Format("INSERT INTO [{0}ASSETSPECHIST] (ALNVALUE,ASSETATTRID,ASSETNUM,ASSETSPECID,BASEMEASUREUNITID,CHANGEBY,CHANGEDATE,CLASSSPECID,CLASSSTRUCTUREID,CREATEDDATE,DISPLAYSEQUENCE,LINKEDTOATTRIBUTE,LINKEDTOSECTION,MANDATORY,MEASUREUNITID,NUMVALUE,ORGID,REMOVEDDATE,SECTION,SITEID)VALUES(@ALNVALUE,@ASSETATTRID,@ASSETNUM,@ASSETSPECID,@BASEMEASUREUNITID,@CHANGEBY,@CHANGEDATE,@CLASSSPECID,@CLASSSTRUCTUREID,@CREATEDDATE,@DISPLAYSEQUENCE,@LINKEDTOATTRIBUTE,@LINKEDTOSECTION,@MANDATORY,@MEASUREUNITID,@NUMVALUE,@ORGID,@REMOVEDDATE,@SECTION,@SITEID)", BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms);

        }

        public bool UpdateAssetspechist(AssetspechistInfo assetspechistInfo) {

            DbParameter[] parms = { 
			    DbHelper.MakeInParam("@ASSETSPECHISTID", (DbType)SqlDbType.BigInt,8,assetspechistInfo.Assetspechistid),
                DbHelper.MakeInParam("@ALNVALUE", (DbType)SqlDbType.VarChar,254,assetspechistInfo.Alnvalue),
                DbHelper.MakeInParam("@ASSETATTRID", (DbType)SqlDbType.VarChar,8,assetspechistInfo.Assetattrid)	,
                DbHelper.MakeInParam("@ASSETNUM", (DbType)SqlDbType.VarChar,16,assetspechistInfo.Assetnum)	,
                DbHelper.MakeInParam("@ASSETSPECID", (DbType)SqlDbType.BigInt,8,assetspechistInfo.Assetspecid)	,
                DbHelper.MakeInParam("@BASEMEASUREUNITID", (DbType)SqlDbType.VarChar,16,assetspechistInfo.Basemeasureunitid)	,
                DbHelper.MakeInParam("@CHANGEBY", (DbType)SqlDbType.VarChar,30,assetspechistInfo.Changeby)	,
                DbHelper.MakeInParam("@CHANGEDATE", (DbType)SqlDbType.DateTime,8,assetspechistInfo.Changedate)	,
                DbHelper.MakeInParam("@CLASSSPECID", (DbType)SqlDbType.BigInt,8,assetspechistInfo.Classspecid)	,
                DbHelper.MakeInParam("@CLASSSTRUCTUREID", (DbType)SqlDbType.VarChar,20,assetspechistInfo.Classstructureid)	,
                DbHelper.MakeInParam("@CREATEDDATE", (DbType)SqlDbType.DateTime,8,assetspechistInfo.Createddate)	,
                DbHelper.MakeInParam("@DISPLAYSEQUENCE", (DbType)SqlDbType.Int,4,assetspechistInfo.Displaysequence)	,
                DbHelper.MakeInParam("@LINKEDTOATTRIBUTE", (DbType)SqlDbType.VarChar,8,assetspechistInfo.Linkedtoattribute)	,
                DbHelper.MakeInParam("@LINKEDTOSECTION", (DbType)SqlDbType.VarChar,10,assetspechistInfo.Linkedtosection)	,
                DbHelper.MakeInParam("@MANDATORY", (DbType)SqlDbType.Bit,1,assetspechistInfo.Mandatory)	,
                DbHelper.MakeInParam("@MEASUREUNITID", (DbType)SqlDbType.VarChar,16,assetspechistInfo.Measureunitid)	,
                DbHelper.MakeInParam("@NUMVALUE", (DbType)SqlDbType.Decimal,26,assetspechistInfo.Numvalue)	,
                DbHelper.MakeInParam("@ORGID", (DbType)SqlDbType.VarChar,8,assetspechistInfo.Orgid)	,
                DbHelper.MakeInParam("@REMOVEDDATE", (DbType)SqlDbType.DateTime,8,assetspechistInfo.Removeddate)	,
                DbHelper.MakeInParam("@SECTION", (DbType)SqlDbType.VarChar,10,assetspechistInfo.Section)	,
                DbHelper.MakeInParam("@SITEID", (DbType)SqlDbType.VarChar,8,assetspechistInfo.Siteid)

			};
            string commandText = string.Format("UPDATE [{0}ASSETSPECHIST] SET [ALNVALUE] = @ALNVALUE,[ASSETATTRID] = @ASSETATTRID,[ASSETNUM] = @ASSETNUM,[ASSETSPECID] = @ASSETSPECID,[BASEMEASUREUNITID] = @BASEMEASUREUNITID,[CHANGEBY] = @CHANGEBY,[CHANGEDATE] = @CHANGEDATE,[CLASSSPECID] = @CLASSSPECID,[CLASSSTRUCTUREID] = @CLASSSTRUCTUREID,[CREATEDDATE] = @CREATEDDATE,[DISPLAYSEQUENCE] = @DISPLAYSEQUENCE,[LINKEDTOATTRIBUTE] = @LINKEDTOATTRIBUTE,[LINKEDTOSECTION] = @LINKEDTOSECTION,[MANDATORY] = @MANDATORY,[MEASUREUNITID] = @MEASUREUNITID,[NUMVALUE] = @NUMVALUE,[ORGID] = @ORGID,[REMOVEDDATE] = @REMOVEDDATE,[SECTION] = @SECTION,[SITEID] = @SITEID WHERE [ASSETSPECHISTID]=@ASSETSPECHISTID", BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms) > 0;
        }

        public int DeleteAssetspechist(string idList) {
            string commandText = string.Format("DELETE FROM [{0}ASSETSPECHIST] WHERE [MEASUREPOINTID] IN ({1})",
                                              BaseConfigs.GetTablePrefix,
                                              idList);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText);
        }

        public DataTable FindAssetspechistByCondition(string condition) {
            string commandText = string.Format("select {0}ASSETSPECHIST.* from [{0}ASSETSPECHIST] WHERE 1=1 {1}",
                                                BaseConfigs.GetTablePrefix,
                                                condition);
            return DbHelper.ExecuteDataset(CommandType.Text, commandText).Tables[0];

        }



    }
}
