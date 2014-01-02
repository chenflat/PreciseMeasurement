using System;
using System.Collections.Generic;
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


        /// <summary>
        /// 创建用户组
        /// </summary>
        /// <param name="groupInfo"></param>
        /// <returns></returns>
        public bool CreateUserGroup(GroupInfo groupInfo) {
            DbParameter[] parms = { 
                                  DbHelper.MakeInParam("@GROUP_ID", (DbType)SqlDbType.Int, 4, groupInfo.GroupId),
                                  DbHelper.MakeInParam("@GROUP_NAME", (DbType)SqlDbType.VarChar, 50, groupInfo.GroupName),
                                  DbHelper.MakeInParam("@DESCRIPTION", (DbType)SqlDbType.VarChar, 50, groupInfo.Description),
                                 };
            string commandText = string.Format("INSERT INTO [{0}GROUPS]([GROUP_NAME],[DESCRIPTION])VALUES(@GROUP_NAME,@DESCRIPTION)",
                BaseConfigs.GetTablePrefix);

            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms) > 0;
        }

        /// <summary>
        /// 更新用户组
        /// </summary>
        /// <param name="groupInfo"></param>
        /// <returns></returns>
       public bool UpdateUserGroup(GroupInfo groupInfo) {
           DbParameter[] parms = { 
                                  DbHelper.MakeInParam("@GROUP_ID", (DbType)SqlDbType.Int, 4, groupInfo.GroupId),
                                  DbHelper.MakeInParam("@GROUP_NAME", (DbType)SqlDbType.VarChar, 50, groupInfo.GroupName),
                                  DbHelper.MakeInParam("@DESCRIPTION", (DbType)SqlDbType.VarChar, 50, groupInfo.Description),
                                 };
           string commandText = string.Format("UPDATE [{0}GROUPS] SET [GROUP_NAME]=@GROUP_NAME,[DESCRIPTION]=@DESCRIPTION"
               + " WHERE [GROUP_ID]=@GROUP_ID", BaseConfigs.GetTablePrefix);

           return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms) > 0;
       }

        /// <summary>
        /// 删除用户组
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
       public int DeleteUserGroupByIdList(string idList) {
           string commandText = string.Format("DELETE FROM [{0}GROUPS] WHERE [GROUP_ID] IN ({1})",
                                                 BaseConfigs.GetTablePrefix,
                                                 idList);
           return DbHelper.ExecuteNonQuery(CommandType.Text, commandText);
       }

        /// <summary>
        /// 查找指定的用户
        /// </summary>
        /// <param name="groupid"></param>
        /// <returns></returns>
       public IDataReader FindUserGroupById(int groupid) {
           DbParameter param = DbHelper.MakeInParam("@GROUPID", (DbType)SqlDbType.Int, 4, groupid);
           string commandText = string.Format("select * from [{0}GROUPS] WHERE [GROUP_ID]=@GROUPID",
                                               BaseConfigs.GetTablePrefix);
           return DbHelper.ExecuteReader(CommandType.Text, commandText, param);
       }

        /// <summary>
        /// 查找用户组信息
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
       public DataTable FindUserGroupByCondition(string condition) {
           string commandText = string.Format("SELECT [{0}GROUPS].* FROM [{0}GROUPS] WHERE 1=1 {1}",
                                                     BaseConfigs.GetTablePrefix,
                                                     condition);
           return DbHelper.ExecuteDataset(CommandType.Text, commandText).Tables[0];
       }
    }
}
