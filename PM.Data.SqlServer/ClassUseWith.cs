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
    public partial class DataProvider : IDataProvider {

   //     --CLASSSTRUCTUREID     varchar(20)          null,
   //--CLASSUSEWITHID       bigint               identity,
   //--DESCRIPTION          varchar(100)         null,
   //--OBJECTNAME           varchar(30)          null,
   //--OBJECTVALUE          varchar(30)          null,


        /// <summary>
        /// 创建分类结构使用的对象
        /// </summary>
        /// <param name="classUseWithInfo">分类结构使用的对象</param>
        /// <returns></returns>
        public int CreateClassUseWith(ClassUseWithInfo classUseWithInfo) {
            DbParameter[] parms = { 
                        DbHelper.MakeInParam("@CLASSSTRUCTUREID", (DbType)SqlDbType.VarChar,20,classUseWithInfo.Classstructureid)	,
                        DbHelper.MakeInParam("@DESCRIPTION", (DbType)SqlDbType.VarChar,30,classUseWithInfo.Description)	,
                        DbHelper.MakeInParam("@OBJECTNAME", (DbType)SqlDbType.VarChar,4000,classUseWithInfo.ObjectName)	,
                        DbHelper.MakeInParam("@OBJECTVALUE", (DbType)SqlDbType.VarChar,4,classUseWithInfo.ObjectValue)	
			};
            string commandText = string.Format("INSERT INTO [{0}CLASSUSEWITH] (CLASSSTRUCTUREID,DESCRIPTION,OBJECTNAME,OBJECTVALUE)VALUES(@CLASSSTRUCTUREID,@DESCRIPTION,@OBJECTNAME,@OBJECTVALUE)", BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms);
        }

        /// <summary>
        /// 更新分类结构使用的对象
        /// </summary>
        /// <param name="classUseWithInfo">分类结构使用的对象</param>
        /// <returns></returns>
        public bool UpdateClassUseWith(ClassUseWithInfo classUseWithInfo) {
            DbParameter[] parms = { 
                        DbHelper.MakeInParam("@CLASSUSEWITHID", (DbType)SqlDbType.BigInt,8,classUseWithInfo.ClassUseWithId)	,
                        DbHelper.MakeInParam("@CLASSSTRUCTUREID", (DbType)SqlDbType.VarChar,20,classUseWithInfo.Classstructureid)	,
                        DbHelper.MakeInParam("@DESCRIPTION", (DbType)SqlDbType.VarChar,30,classUseWithInfo.Description)	,
                        DbHelper.MakeInParam("@OBJECTNAME", (DbType)SqlDbType.VarChar,4000,classUseWithInfo.ObjectName)	,
                        DbHelper.MakeInParam("@OBJECTVALUE", (DbType)SqlDbType.VarChar,4,classUseWithInfo.ObjectValue)	
			};
            string commandText = string.Format("UPDATE [{0}CLASSUSEWITH] SET [CLASSSTRUCTUREID] = @CLASSSTRUCTUREID,[DESCRIPTION] = @DESCRIPTION,[OBJECTNAME] = @OBJECTNAME,[OBJECTVALUE] = @OBJECTVALUE WHERE [CLASSUSEWITHID]=@CLASSUSEWITHID", BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms) > 0;
        }
        /// <summary>
        /// 删除分类结构使用的对象
        /// </summary>
        /// <param name="idList">主键ID，多个ID以","分隔</param>
        /// <returns></returns>
        public int DeleteClassUseWith(string idList) {
            string commandText = string.Format("DELETE FROM [{0}CLASSUSEWITH] WHERE [CLASSUSEWITHID] IN ({1})",
                                              BaseConfigs.GetTablePrefix,
                                              idList);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText);
        }
        /// <summary>
        /// 查找分类结构使用的对象
        /// </summary>
        /// <param name="condition">查询条件SQL,以 and 开头</param>
        /// <returns></returns>
        public DataTable FindClassUseWithByCondition(string condition) {
            string commandText = string.Format("select {0}CLASSUSEWITH.* from [{0}CLASSUSEWITH] WHERE 1=1 {1}",
                                               BaseConfigs.GetTablePrefix,
                                               condition);
            return DbHelper.ExecuteDataset(CommandType.Text, commandText).Tables[0];
        }

    }
}
