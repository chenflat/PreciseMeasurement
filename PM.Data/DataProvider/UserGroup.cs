using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PM.Entity;

namespace PM.Data {
    public class UserGroup {

        /// <summary>
        /// 创建用户组
        /// </summary>
        /// <param name="groupInfo"></param>
        /// <returns></returns>
        public static bool CreateUserGroup(GroupInfo groupInfo) {
            return DatabaseProvider.GetInstance().CreateUserGroup(groupInfo);
        }

        /// <summary>
        /// 更新用户组
        /// </summary>
        /// <param name="groupInfo"></param>
        /// <returns></returns>
        public static bool UpdateUserGroup(GroupInfo groupInfo) {
            return DatabaseProvider.GetInstance().UpdateUserGroup(groupInfo);
        }

        /// <summary>
        /// 删除用户组
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        public static int DeleteUserGroupByIdList(string idList) {
            return DatabaseProvider.GetInstance().DeleteUserGroupByIdList(idList);
        }

        /// <summary>
        /// 查找用户组信息
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static DataTable FindUserGroupByCondition(string condition) {
            return DatabaseProvider.GetInstance().FindUserGroupByCondition(condition);
        }

        /// <summary>
        /// 查找指定的用户
        /// </summary>
        /// <param name="groupid"></param>
        /// <returns></returns>
        public static IDataReader FindUserGroupById(int groupid) {
            return DatabaseProvider.GetInstance().FindUserGroupById(groupid);
        }

        /// <summary>
        /// 获取指定ID的用户组对象
        /// </summary>
        /// <param name="groupid">用户组ID</param>
        /// <returns></returns>
        public static GroupInfo GetGroupInfo(int groupid) {
            if (groupid <= 0)
                return null;
            GroupInfo groupInfo = null;
            using (IDataReader reader = FindUserGroupById(groupid)) {
                if (reader.Read()) {
                    groupInfo = LoadGroupInfo(reader);
                }
                reader.Close();
            }

            return groupInfo;
        }

        public static GroupInfo LoadGroupInfo(IDataReader reader) {
            GroupInfo groupInfo = new GroupInfo();
            groupInfo.GroupId = reader.GetInt32(reader.GetOrdinal("GROUP_ID"));
            groupInfo.GroupName = reader["Group_Name"].ToString();
            groupInfo.Description = reader["Description"].ToString();
            return groupInfo;
        }

    }
}
