using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PM.Entity;
using PM.Data;
using PM.Common;

namespace PM.Business
{
    public class Users
    {
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        public static DataTable FindUserTableByCondition(string condition) {
            return Data.Users.FindUserTableByCondition(condition);
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public static DataTable GetUserInfo(string userName, string passWord) {
            return Data.Users.GetUserInfo(userName, passWord);
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static UserInfo GetUserInfo(int userId)
        {
            return Data.Users.GetUserInfo(userId);
        }


        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static UserInfo GetUserInfoByUserName(string userName)
        {
            return Data.Users.GetUserInfoByUserName(userName);
        }

        /// <summary>
        /// 新增用户信息
        /// </summary>
        /// <param name="userinfo"></param>
        /// <returns></returns>
        public static bool CreateUser(UserInfo userinfo) {
            return Data.Users.CreateUser(userinfo);
        }

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public static bool UpdateUser(UserInfo userInfo) {
            return Data.Users.UpdateUser(userInfo);
        }

        /// <summary>
        /// 更新用户密码
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="password"></param>
        /// <param name="passwordmodifieddate"></param>
        /// <returns></returns>
        public static bool UpdatePassword(int userid, string password, DateTime passwordmodifieddate)
        {
            return Data.Users.UpdatePassword(userid, password, passwordmodifieddate);
        }

        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="uidList"></param>
        /// <returns></returns>
        public static int DeleteUserByUidlist(string uidList) {
            return Data.Users.DeleteUserByUidlist(uidList);
        }
    }
}
