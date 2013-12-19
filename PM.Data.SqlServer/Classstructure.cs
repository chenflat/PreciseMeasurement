

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

        public int CreateClassstructure(ClassstructureInfo classstructureInfo) {
            DbParameter[] parms = { 
			    DbHelper.MakeInParam("@CLASSIFICATIONID", (DbType)SqlDbType.VarChar,200,classstructureInfo.Classificationid)	,
                DbHelper.MakeInParam("@CLASSSTRUCTUREID", (DbType)SqlDbType.VarChar,20,classstructureInfo.Classstructureid)	,
                DbHelper.MakeInParam("@DESCRIPTION", (DbType)SqlDbType.VarChar,100,classstructureInfo.Description)	,
                DbHelper.MakeInParam("@GENASSETDESC", (DbType)SqlDbType.Bit,1,classstructureInfo.Genassetdesc)	,
                DbHelper.MakeInParam("@HASCHILDREN", (DbType)SqlDbType.Bit,1,classstructureInfo.Haschildren)	,
                DbHelper.MakeInParam("@HASLD", (DbType)SqlDbType.Bit,1,classstructureInfo.Hasld)	,
                DbHelper.MakeInParam("@LANGCODE", (DbType)SqlDbType.VarChar,4,classstructureInfo.Langcode)	,
                DbHelper.MakeInParam("@ORGID", (DbType)SqlDbType.VarChar,8,classstructureInfo.Orgid)	,
                DbHelper.MakeInParam("@PARENT", (DbType)SqlDbType.VarChar,20,classstructureInfo.Parent)	,
                DbHelper.MakeInParam("@SITEID", (DbType)SqlDbType.VarChar,10,classstructureInfo.Siteid)	,
                DbHelper.MakeInParam("@TYPE", (DbType)SqlDbType.VarChar,8,classstructureInfo.Type)	,
                DbHelper.MakeInParam("@USECLASSINDESC", (DbType)SqlDbType.Bit,1,classstructureInfo.Useclassindesc)	
			};
            string commandText = string.Format("INSERT INTO [{0}CLASSSTRUCTURE] (CLASSIFICATIONID,CLASSSTRUCTUREID,DESCRIPTION,GENASSETDESC,HASCHILDREN,HASLD,LANGCODE,ORGID,PARENT,SITEID,TYPE,USECLASSINDESC)VALUES(@CLASSIFICATIONID,@CLASSSTRUCTUREID,@DESCRIPTION,@GENASSETDESC,@HASCHILDREN,@HASLD,@LANGCODE,@ORGID,@PARENT,@SITEID,@TYPE,@USECLASSINDESC)", BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms);
        }

        public bool UpdateClassstructure(ClassstructureInfo classstructureInfo) {

            DbParameter[] parms = { 
                DbHelper.MakeInParam("@CLASSSTRUCTUREUID", (DbType)SqlDbType.BigInt,8,classstructureInfo.Classstructureuid),
                DbHelper.MakeInParam("@CLASSIFICATIONID", (DbType)SqlDbType.VarChar,200,classstructureInfo.Classificationid)	,
                DbHelper.MakeInParam("@CLASSSTRUCTUREID", (DbType)SqlDbType.VarChar,20,classstructureInfo.Classstructureid)	,
                DbHelper.MakeInParam("@DESCRIPTION", (DbType)SqlDbType.VarChar,100,classstructureInfo.Description)	,
                DbHelper.MakeInParam("@GENASSETDESC", (DbType)SqlDbType.Bit,1,classstructureInfo.Genassetdesc)	,
                DbHelper.MakeInParam("@HASCHILDREN", (DbType)SqlDbType.Bit,1,classstructureInfo.Haschildren)	,
                DbHelper.MakeInParam("@HASLD", (DbType)SqlDbType.Bit,1,classstructureInfo.Hasld)	,
                DbHelper.MakeInParam("@LANGCODE", (DbType)SqlDbType.VarChar,4,classstructureInfo.Langcode)	,
                DbHelper.MakeInParam("@ORGID", (DbType)SqlDbType.VarChar,8,classstructureInfo.Orgid)	,
                DbHelper.MakeInParam("@PARENT", (DbType)SqlDbType.VarChar,20,classstructureInfo.Parent)	,
                DbHelper.MakeInParam("@SITEID", (DbType)SqlDbType.VarChar,10,classstructureInfo.Siteid)	,
                DbHelper.MakeInParam("@TYPE", (DbType)SqlDbType.VarChar,8,classstructureInfo.Type)	,
                DbHelper.MakeInParam("@USECLASSINDESC", (DbType)SqlDbType.Bit,1,classstructureInfo.Useclassindesc)			
			};
            string commandText = string.Format("UPDATE [{0}CLASSSTRUCTURE] SET [CLASSIFICATIONID] = @CLASSIFICATIONID,[CLASSSTRUCTUREID] = @CLASSSTRUCTUREID,[DESCRIPTION] = @DESCRIPTION,[GENASSETDESC] = @GENASSETDESC,[HASCHILDREN] = @HASCHILDREN,[HASLD] = @HASLD,[LANGCODE] = @LANGCODE,[ORGID] = @ORGID,[PARENT] = @PARENT,[SITEID] = @SITEID,[TYPE] = @TYPE,[USECLASSINDESC] = @USECLASSINDESC WHERE [CLASSSTRUCTUREUID]=@CLASSSTRUCTUREUID", BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms) > 0;
        }

        public int DeleteClassstructure(string idList) {
            string commandText = string.Format("DELETE FROM [{0}CLASSSTRUCTURE] WHERE [MEASUREPOINTID] IN ({1})",
                                              BaseConfigs.GetTablePrefix,
                                              idList);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText);
        }

        public DataTable FindClassstructureByCondition(string condition) {
            string commandText = string.Format("select {0}CLASSSTRUCTURE.* from [{0}CLASSSTRUCTURE] WHERE 1=1 {1}",
                                                BaseConfigs.GetTablePrefix,
                                                condition);
            return DbHelper.ExecuteDataset(CommandType.Text, commandText).Tables[0];

        }


    }
}
