

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

        public int CreateAsset(AssetInfo assetInfo) {
            DbParameter[] parms = { 
			    DbHelper.MakeInParam("@ANCESTOR", (DbType)SqlDbType.VarChar,12,assetInfo.Ancestor),			
                DbHelper.MakeInParam("@ASSETID", (DbType)SqlDbType.BigInt,8,assetInfo.Assetid),
                DbHelper.MakeInParam("@ASSETNUM", (DbType)SqlDbType.VarChar,16,assetInfo.Assetnum),			
                DbHelper.MakeInParam("@ASSETTAG", (DbType)SqlDbType.VarChar,64,assetInfo.Assettag),
                DbHelper.MakeInParam("@ASSETTYPE", (DbType)SqlDbType.VarChar,15,assetInfo.Assettype),
                DbHelper.MakeInParam("@SPECCLASS", (DbType)SqlDbType.VarChar,15,assetInfo.Specclass),			
                DbHelper.MakeInParam("@CALNUM", (DbType)SqlDbType.VarChar,8,assetInfo.Calnum),			
                DbHelper.MakeInParam("@CHANGEBY", (DbType)SqlDbType.VarChar,30,assetInfo.Changeby),
                DbHelper.MakeInParam("@CHANGEDATE", (DbType)SqlDbType.DateTime,8,assetInfo.Changedate),			
                DbHelper.MakeInParam("@CLASSSTRUCTUREID", (DbType)SqlDbType.VarChar,20,assetInfo.Classstructureid),			
                DbHelper.MakeInParam("@DESCRIPTION", (DbType)SqlDbType.VarChar,100,assetInfo.Description),			
                DbHelper.MakeInParam("@DISABLED", (DbType)SqlDbType.Bit,1,assetInfo.Disabled),			
                DbHelper.MakeInParam("@EXTERNALREFID", (DbType)SqlDbType.VarChar,10,assetInfo.Externalrefid),			
                DbHelper.MakeInParam("@FAILURECODE", (DbType)SqlDbType.VarChar,8,assetInfo.Failurecode),
                DbHelper.MakeInParam("@GROUPNAME", (DbType)SqlDbType.VarChar,10,assetInfo.Groupname),			
                DbHelper.MakeInParam("@HASCHILDREN", (DbType)SqlDbType.Bit,1,assetInfo.Haschildren),
                DbHelper.MakeInParam("@HASMOREDESC", (DbType)SqlDbType.Bit,1,assetInfo.Hasmoredesc),			
                DbHelper.MakeInParam("@INSTALLDATE", (DbType)SqlDbType.DateTime,8,assetInfo.Installdate),
                DbHelper.MakeInParam("@ISRUNNING", (DbType)SqlDbType.Bit,1,assetInfo.Isrunning),
                DbHelper.MakeInParam("@LANGCODE", (DbType)SqlDbType.VarChar,4,assetInfo.Langcode),	
                DbHelper.MakeInParam("@LOCATION", (DbType)SqlDbType.VarChar,12,assetInfo.Location),			
                DbHelper.MakeInParam("@MAINTHIERCHY", (DbType)SqlDbType.Bit,1,assetInfo.Mainthierchy),
                DbHelper.MakeInParam("@MANUFACTURER", (DbType)SqlDbType.VarChar,12,assetInfo.Manufacturer),			
                DbHelper.MakeInParam("@MOVED", (DbType)SqlDbType.Bit,1,assetInfo.Moved),			
                DbHelper.MakeInParam("@ORGID", (DbType)SqlDbType.VarChar,8,assetInfo.Orgid),		
                DbHelper.MakeInParam("@OWNERSYSID", (DbType)SqlDbType.VarChar,10,assetInfo.Ownersysid),			
                DbHelper.MakeInParam("@PARENT", (DbType)SqlDbType.VarChar,12,assetInfo.Parent),	
                DbHelper.MakeInParam("@PRIORITY", (DbType)SqlDbType.Int,1,assetInfo.Priority),
                DbHelper.MakeInParam("@SENDERSYSID", (DbType)SqlDbType.VarChar,50,assetInfo.Sendersysid),			
                DbHelper.MakeInParam("@SERIALNUM", (DbType)SqlDbType.VarChar,64,assetInfo.Serialnum),
                DbHelper.MakeInParam("@SHIFTNUM", (DbType)SqlDbType.VarChar,8,assetInfo.Shiftnum),			
                DbHelper.MakeInParam("@SITEID", (DbType)SqlDbType.VarChar,8,assetInfo.Siteid),			
                DbHelper.MakeInParam("@SOURCESYSID", (DbType)SqlDbType.VarChar,10,assetInfo.Sourcesysid),			
                DbHelper.MakeInParam("@STATUS", (DbType)SqlDbType.VarChar,20,assetInfo.Status),			
                DbHelper.MakeInParam("@STATUSDATE", (DbType)SqlDbType.DateTime,8,assetInfo.Statusdate),			
                DbHelper.MakeInParam("@USAGE", (DbType)SqlDbType.VarChar,15,assetInfo.Usage),			
                DbHelper.MakeInParam("@VENDOR", (DbType)SqlDbType.VarChar,12,assetInfo.Vendor),			
                DbHelper.MakeInParam("@WARRANTYEXPDATE", (DbType)SqlDbType.DateTime,8,assetInfo.Warrantyexpdate),			
                DbHelper.MakeInParam("@EC1", (DbType)SqlDbType.VarChar,10,assetInfo.Ec1),			
                DbHelper.MakeInParam("@EC2", (DbType)SqlDbType.VarChar,10,assetInfo.Ec2),			
                DbHelper.MakeInParam("@EC3", (DbType)SqlDbType.VarChar,10,assetInfo.Ec3),			
                DbHelper.MakeInParam("@EC4", (DbType)SqlDbType.VarChar,10,assetInfo.Ec4),			
                DbHelper.MakeInParam("@EC5", (DbType)SqlDbType.Decimal,8,assetInfo.Ec5),			
                DbHelper.MakeInParam("@EC6", (DbType)SqlDbType.DateTime,8,assetInfo.Ec6),			
                DbHelper.MakeInParam("@EC7", (DbType)SqlDbType.Decimal,8,assetInfo.Ec7),			
                DbHelper.MakeInParam("@EC8", (DbType)SqlDbType.VarChar,10,assetInfo.Ec8),			
                DbHelper.MakeInParam("@EC9", (DbType)SqlDbType.VarChar,10,assetInfo.Ec9),			
                DbHelper.MakeInParam("@EC10", (DbType)SqlDbType.VarChar,10,assetInfo.Ec10),			
                DbHelper.MakeInParam("@EC11", (DbType)SqlDbType.VarChar,10,assetInfo.Ec11),			
                DbHelper.MakeInParam("@EC12", (DbType)SqlDbType.Decimal,8,assetInfo.Ec12),			
                DbHelper.MakeInParam("@EC13", (DbType)SqlDbType.DateTime,8,assetInfo.Ec13),			
                DbHelper.MakeInParam("@EC14", (DbType)SqlDbType.VarChar,10,assetInfo.Ec14),			
                DbHelper.MakeInParam("@EC15", (DbType)SqlDbType.Decimal,8,assetInfo.Ec15)
			};
            string commandText = string.Format("INSERT INTO [{0}ASSET] (ANCESTOR,ASSETID,ASSETNUM,ASSETTAG,ASSETTYPE,SPECCLASS,CALNUM,CHANGEBY,CHANGEDATE,CLASSSTRUCTUREID,DESCRIPTION,DISABLED,EXTERNALREFID,FAILURECODE,GROUPNAME,HASCHILDREN,HASMOREDESC,INSTALLDATE,ISRUNNING,LANGCODE,LOCATION,MAINTHIERCHY,MANUFACTURER,MOVED,ORGID,OWNERSYSID,PARENT,PRIORITY,SENDERSYSID,SERIALNUM,SHIFTNUM,SITEID,SOURCESYSID,STATUS,STATUSDATE,USAGE,VENDOR,WARRANTYEXPDATE,EC1,EC2,EC3,EC4,EC5,EC6,EC7,EC8,EC9,EC10,EC11,EC12,EC13,EC14,EC15)VALUES(@ANCESTOR,@ASSETID,@ASSETNUM,@ASSETTAG,@ASSETTYPE,@SPECCLASS,@CALNUM,@CHANGEBY,@CHANGEDATE,@CLASSSTRUCTUREID,@DESCRIPTION,@DISABLED,@EXTERNALREFID,@FAILURECODE,@GROUPNAME,@HASCHILDREN,@HASMOREDESC,@INSTALLDATE,@ISRUNNING,@LANGCODE,@LOCATION,@MAINTHIERCHY,@MANUFACTURER,@MOVED,@ORGID,@OWNERSYSID,@PARENT,@PRIORITY,@SENDERSYSID,@SERIALNUM,@SHIFTNUM,@SITEID,@SOURCESYSID,@STATUS,@STATUSDATE,@USAGE,@VENDOR,@WARRANTYEXPDATE,@EC1,@EC2,@EC3,@EC4,@EC5,@EC6,@EC7,@EC8,@EC9,@EC10,@EC11,@EC12,@EC13,@EC14,@EC15)", BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms);



        }

        public bool UpdateAsset(AssetInfo assetInfo) {

            DbParameter[] parms = { 
			        DbHelper.MakeInParam("@ASSETUID", (DbType)SqlDbType.BigInt,8,assetInfo.Assetuid),
                    DbHelper.MakeInParam("@ANCESTOR", (DbType)SqlDbType.VarChar,12,assetInfo.Ancestor),			
                    DbHelper.MakeInParam("@ASSETID", (DbType)SqlDbType.BigInt,8,assetInfo.Assetid),
                    DbHelper.MakeInParam("@ASSETNUM", (DbType)SqlDbType.VarChar,16,assetInfo.Assetnum),			
                    DbHelper.MakeInParam("@ASSETTAG", (DbType)SqlDbType.VarChar,64,assetInfo.Assettag),
                    DbHelper.MakeInParam("@ASSETTYPE", (DbType)SqlDbType.VarChar,15,assetInfo.Assettype),
                    DbHelper.MakeInParam("@SPECCLASS", (DbType)SqlDbType.VarChar,15,assetInfo.Specclass),			
                    DbHelper.MakeInParam("@CALNUM", (DbType)SqlDbType.VarChar,8,assetInfo.Calnum),			
                    DbHelper.MakeInParam("@CHANGEBY", (DbType)SqlDbType.VarChar,30,assetInfo.Changeby),
                    DbHelper.MakeInParam("@CHANGEDATE", (DbType)SqlDbType.DateTime,8,assetInfo.Changedate),			
                    DbHelper.MakeInParam("@CLASSSTRUCTUREID", (DbType)SqlDbType.VarChar,20,assetInfo.Classstructureid),			
                    DbHelper.MakeInParam("@DESCRIPTION", (DbType)SqlDbType.VarChar,100,assetInfo.Description),			
                    DbHelper.MakeInParam("@DISABLED", (DbType)SqlDbType.Bit,1,assetInfo.Disabled),			
                    DbHelper.MakeInParam("@EXTERNALREFID", (DbType)SqlDbType.VarChar,10,assetInfo.Externalrefid),			
                    DbHelper.MakeInParam("@FAILURECODE", (DbType)SqlDbType.VarChar,8,assetInfo.Failurecode),
                    DbHelper.MakeInParam("@GROUPNAME", (DbType)SqlDbType.VarChar,10,assetInfo.Groupname),			
                    DbHelper.MakeInParam("@HASCHILDREN", (DbType)SqlDbType.Bit,1,assetInfo.Haschildren),
                    DbHelper.MakeInParam("@HASMOREDESC", (DbType)SqlDbType.Bit,1,assetInfo.Hasmoredesc),			
                    DbHelper.MakeInParam("@INSTALLDATE", (DbType)SqlDbType.DateTime,8,assetInfo.Installdate),
                    DbHelper.MakeInParam("@ISRUNNING", (DbType)SqlDbType.Bit,1,assetInfo.Isrunning),
                    DbHelper.MakeInParam("@LANGCODE", (DbType)SqlDbType.VarChar,4,assetInfo.Langcode),	
                    DbHelper.MakeInParam("@LOCATION", (DbType)SqlDbType.VarChar,12,assetInfo.Location),			
                    DbHelper.MakeInParam("@MAINTHIERCHY", (DbType)SqlDbType.Bit,1,assetInfo.Mainthierchy),
                    DbHelper.MakeInParam("@MANUFACTURER", (DbType)SqlDbType.VarChar,12,assetInfo.Manufacturer),			
                    DbHelper.MakeInParam("@MOVED", (DbType)SqlDbType.Bit,1,assetInfo.Moved),			
                    DbHelper.MakeInParam("@ORGID", (DbType)SqlDbType.VarChar,8,assetInfo.Orgid),		
                    DbHelper.MakeInParam("@OWNERSYSID", (DbType)SqlDbType.VarChar,10,assetInfo.Ownersysid),			
                    DbHelper.MakeInParam("@PARENT", (DbType)SqlDbType.VarChar,12,assetInfo.Parent),	
                    DbHelper.MakeInParam("@PRIORITY", (DbType)SqlDbType.Int,1,assetInfo.Priority),
                    DbHelper.MakeInParam("@SENDERSYSID", (DbType)SqlDbType.VarChar,50,assetInfo.Sendersysid),			
                    DbHelper.MakeInParam("@SERIALNUM", (DbType)SqlDbType.VarChar,64,assetInfo.Serialnum),
                    DbHelper.MakeInParam("@SHIFTNUM", (DbType)SqlDbType.VarChar,8,assetInfo.Shiftnum),			
                    DbHelper.MakeInParam("@SITEID", (DbType)SqlDbType.VarChar,8,assetInfo.Siteid),			
                    DbHelper.MakeInParam("@SOURCESYSID", (DbType)SqlDbType.VarChar,10,assetInfo.Sourcesysid),			
                    DbHelper.MakeInParam("@STATUS", (DbType)SqlDbType.VarChar,20,assetInfo.Status),			
                    DbHelper.MakeInParam("@STATUSDATE", (DbType)SqlDbType.DateTime,8,assetInfo.Statusdate),			
                    DbHelper.MakeInParam("@USAGE", (DbType)SqlDbType.VarChar,15,assetInfo.Usage),			
                    DbHelper.MakeInParam("@VENDOR", (DbType)SqlDbType.VarChar,12,assetInfo.Vendor),			
                    DbHelper.MakeInParam("@WARRANTYEXPDATE", (DbType)SqlDbType.DateTime,8,assetInfo.Warrantyexpdate),			
                    DbHelper.MakeInParam("@EC1", (DbType)SqlDbType.VarChar,10,assetInfo.Ec1),			
                    DbHelper.MakeInParam("@EC2", (DbType)SqlDbType.VarChar,10,assetInfo.Ec2),			
                    DbHelper.MakeInParam("@EC3", (DbType)SqlDbType.VarChar,10,assetInfo.Ec3),			
                    DbHelper.MakeInParam("@EC4", (DbType)SqlDbType.VarChar,10,assetInfo.Ec4),			
                    DbHelper.MakeInParam("@EC5", (DbType)SqlDbType.Decimal,8,assetInfo.Ec5),			
                    DbHelper.MakeInParam("@EC6", (DbType)SqlDbType.DateTime,8,assetInfo.Ec6),			
                    DbHelper.MakeInParam("@EC7", (DbType)SqlDbType.Decimal,8,assetInfo.Ec7),			
                    DbHelper.MakeInParam("@EC8", (DbType)SqlDbType.VarChar,10,assetInfo.Ec8),			
                    DbHelper.MakeInParam("@EC9", (DbType)SqlDbType.VarChar,10,assetInfo.Ec9),			
                    DbHelper.MakeInParam("@EC10", (DbType)SqlDbType.VarChar,10,assetInfo.Ec10),			
                    DbHelper.MakeInParam("@EC11", (DbType)SqlDbType.VarChar,10,assetInfo.Ec11),			
                    DbHelper.MakeInParam("@EC12", (DbType)SqlDbType.Decimal,8,assetInfo.Ec12),			
                    DbHelper.MakeInParam("@EC13", (DbType)SqlDbType.DateTime,8,assetInfo.Ec13),			
                    DbHelper.MakeInParam("@EC14", (DbType)SqlDbType.VarChar,10,assetInfo.Ec14),			
                    DbHelper.MakeInParam("@EC15", (DbType)SqlDbType.Decimal,8,assetInfo.Ec15)
			};
            string commandText = string.Format("UPDATE [{0}ASSET] SET [ANCESTOR] = @ANCESTOR,[ASSETID] = @ASSETID,[ASSETNUM] = @ASSETNUM,[ASSETTAG] = @ASSETTAG,[ASSETTYPE] = @ASSETTYPE,[SPECCLASS] = @SPECCLASS,[CALNUM] = @CALNUM,[CHANGEBY] = @CHANGEBY,[CHANGEDATE] = @CHANGEDATE,[CLASSSTRUCTUREID] = @CLASSSTRUCTUREID,[DESCRIPTION] = @DESCRIPTION,[DISABLED] = @DISABLED,[EXTERNALREFID] = @EXTERNALREFID,[FAILURECODE] = @FAILURECODE,[GROUPNAME] = @GROUPNAME,[HASCHILDREN] = @HASCHILDREN,[HASMOREDESC] = @HASMOREDESC,[INSTALLDATE] = @INSTALLDATE,[ISRUNNING] = @ISRUNNING,[LANGCODE] = @LANGCODE,[LOCATION] = @LOCATION,[MAINTHIERCHY] = @MAINTHIERCHY,[MANUFACTURER] = @MANUFACTURER,[MOVED] = @MOVED,[ORGID] = @ORGID,[OWNERSYSID] = @OWNERSYSID,[PARENT] = @PARENT,[PRIORITY] = @PRIORITY,[SENDERSYSID] = @SENDERSYSID,[SERIALNUM] = @SERIALNUM,[SHIFTNUM] = @SHIFTNUM,[SITEID] = @SITEID,[SOURCESYSID] = @SOURCESYSID,[STATUS] = @STATUS,[STATUSDATE] = @STATUSDATE,[USAGE] = @USAGE,[VENDOR] = @VENDOR,[WARRANTYEXPDATE] = @WARRANTYEXPDATE,[EC1] = @EC1,[EC2] = @EC2,[EC3] = @EC3,[EC4] = @EC4,[EC5] = @EC5,[EC6] = @EC6,[EC7] = @EC7,[EC8] = @EC8,[EC9] = @EC9,[EC10] = @EC10,[EC11] = @EC11,[EC12] = @EC12,[EC13] = @EC13,[EC14] = @EC14,[EC15] = @EC15 WHERE [ASSETUID]=@ASSETUID", BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms) > 0;
        }

        /// <summary>
        /// 更新资产坐标
        /// </summary>
        /// <param name="assetuid"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public int UpdateAssetCoordinates(long assetuid, string x, string y, string z) {

            DbParameter[] parms = { 
			        DbHelper.MakeInParam("@ASSETUID", (DbType)SqlDbType.BigInt,8,assetuid),
                    		
                    DbHelper.MakeInParam("@EC1", (DbType)SqlDbType.VarChar,10,x),			
                    DbHelper.MakeInParam("@EC2", (DbType)SqlDbType.VarChar,10,y),			
                    DbHelper.MakeInParam("@EC3", (DbType)SqlDbType.VarChar,10,z)
                                   };
		    string commandText = string.Format("UPDATE [{0}ASSET] SET [EC1] = @EC1,[EC2] = @EC2,[EC3] = @EC3 WHERE [ASSETUID]=@ASSETUID", BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms);
        }

        public int DeleteAsset(string idList) {
            string commandText = string.Format("DELETE FROM [{0}ASSET] WHERE [ASSETUID] IN ({1})",
                                              BaseConfigs.GetTablePrefix,
                                              idList);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText);
        }

        public DataTable FindAssetByCondition(string condition) {
            string commandText = string.Format("select {0}ASSET.* from [{0}ASSET] WHERE 1=1 {1}",
                                                BaseConfigs.GetTablePrefix,
                                                condition);
            return DbHelper.ExecuteDataset(CommandType.Text, commandText).Tables[0];

        }

        public int AssetCount(string condition) {
            string commandText = string.Format("SELECT COUNT(*) FROM [{0}ASSET] WHERE 1=1 {1}",
                                             BaseConfigs.GetTablePrefix, condition);
            return TypeConverter.ObjectToInt(DbHelper.ExecuteDataset(CommandType.Text, commandText).Tables[0].Rows[0][0]);

        }

    }
}
