

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

        public int CreateAssetattribute(AssetattributeInfo assetattributeInfo) {
            DbParameter[] parms = { 
                                   DbHelper.MakeInParam("@ASSETATTRID", (DbType)SqlDbType.VarChar,20,assetattributeInfo.Assetattrid),
                                   DbHelper.MakeInParam("@ATTRDESCPREFIX", (DbType)SqlDbType.VarChar,8,assetattributeInfo.Attrdescprefix),			
                                   DbHelper.MakeInParam("@DATATYPE", (DbType)SqlDbType.VarChar,8,assetattributeInfo.Datatype),			
                                   DbHelper.MakeInParam("@DESCRIPTION", (DbType)SqlDbType.VarChar,100,assetattributeInfo.Description),			
                                   DbHelper.MakeInParam("@DOMAINID", (DbType)SqlDbType.VarChar,18,assetattributeInfo.Domainid),			
                                   DbHelper.MakeInParam("@MEASUREUNITID", (DbType)SqlDbType.VarChar,16,assetattributeInfo.Measureunitid),			
                                   DbHelper.MakeInParam("@DYNAMICATTR", (DbType)SqlDbType.Bit,1,assetattributeInfo.Dynamicattr),			
                                   DbHelper.MakeInParam("@ORGID", (DbType)SqlDbType.VarChar,8,assetattributeInfo.Orgid),			
                                   DbHelper.MakeInParam("@SITEID", (DbType)SqlDbType.VarChar,8,assetattributeInfo.Siteid)
			};
            string commandText = string.Format("INSERT INTO [{0}ASSETATTRIBUTE] (ASSETATTRID,ATTRDESCPREFIX,DATATYPE,DESCRIPTION,DOMAINID,MEASUREUNITID,DYNAMICATTR,ORGID,SITEID)VALUES(@ASSETATTRID,@ATTRDESCPREFIX,@DATATYPE,@DESCRIPTION,@DOMAINID,@MEASUREUNITID,@DYNAMICATTR,@ORGID,@SITEID)", BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms);
        }



        public bool UpdateAssetattribute(AssetattributeInfo assetattributeInfo) {

            DbParameter[] parms = { 
						           DbHelper.MakeInParam("@ASSETATTRIBUTEID", (DbType)SqlDbType.BigInt,8,assetattributeInfo.Assetattributeid),
                                   DbHelper.MakeInParam("@ASSETATTRID", (DbType)SqlDbType.VarChar,20,assetattributeInfo.Assetattrid),
                                   DbHelper.MakeInParam("@ATTRDESCPREFIX", (DbType)SqlDbType.VarChar,8,assetattributeInfo.Attrdescprefix),			
                                   DbHelper.MakeInParam("@DATATYPE", (DbType)SqlDbType.VarChar,8,assetattributeInfo.Datatype),			
                                   DbHelper.MakeInParam("@DESCRIPTION", (DbType)SqlDbType.VarChar,100,assetattributeInfo.Description),			
                                   DbHelper.MakeInParam("@DOMAINID", (DbType)SqlDbType.VarChar,18,assetattributeInfo.Domainid),			
                                   DbHelper.MakeInParam("@MEASUREUNITID", (DbType)SqlDbType.VarChar,16,assetattributeInfo.Measureunitid),			
                                   DbHelper.MakeInParam("@DYNAMICATTR", (DbType)SqlDbType.Bit,1,assetattributeInfo.Dynamicattr),			
                                   DbHelper.MakeInParam("@ORGID", (DbType)SqlDbType.VarChar,8,assetattributeInfo.Orgid),			
                                   DbHelper.MakeInParam("@SITEID", (DbType)SqlDbType.VarChar,8,assetattributeInfo.Siteid)
			};
            string commandText = string.Format("UPDATE [{0}ASSETATTRIBUTE] SET [ASSETATTRID] = @ASSETATTRID,[ATTRDESCPREFIX] = @ATTRDESCPREFIX,[DATATYPE] = @DATATYPE,[DESCRIPTION] = @DESCRIPTION,[DOMAINID] = @DOMAINID,[MEASUREUNITID] = @MEASUREUNITID,[DYNAMICATTR] = @DYNAMICATTR,[ORGID] = @ORGID,[SITEID] = @SITEID WHERE [ASSETATTRIBUTEID]=@ASSETATTRIBUTEID", BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms) > 0;
        }

        public int DeleteAssetattribute(string idList) {
            string commandText = string.Format("DELETE FROM [{0}ASSETATTRIBUTE] WHERE [MEASUREPOINTID] IN ({1})",
                                              BaseConfigs.GetTablePrefix,
                                              idList);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText);
        }


        public IDataReader FindAssetattributeByAssetattrid(String assetattrid) {
            string commandText = string.Format("select * from [{0}ASSETATTRIBUTE] where [ASSETATTRID]='{1}'", BaseConfigs.GetTablePrefix, assetattrid);
            return DbHelper.ExecuteReader(CommandType.Text, commandText);
        }

        public DataTable FindAssetattributeByCondition(string condition) {
            string commandText = string.Format("select {0}ASSETATTRIBUTE.* from [{0}ASSETATTRIBUTE] WHERE 1=1 {1}",
                                                BaseConfigs.GetTablePrefix,
                                                condition);
            return DbHelper.ExecuteDataset(CommandType.Text, commandText).Tables[0];

        }

        public int AssetattributeCount(string condition) {
            string commandText = string.Format("SELECT COUNT(*) FROM [{0}ASSETATTRIBUTE] WHERE 1=1 {1}",
                                             BaseConfigs.GetTablePrefix, condition);
            return TypeConverter.ObjectToInt(DbHelper.ExecuteDataset(CommandType.Text, commandText).Tables[0].Rows[0][0]);

        }

    }
}
