using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using PM.Entity;
using PM.Common;

namespace PM.Data
{
    /// <summary>
    /// 用户数据操作类
    /// </summary>
    public class Users
    {
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        public static DataTable FindUserTableByCondition(string condition) {
            return DatabaseProvider.GetInstance().FindUserTableByCondition(condition);
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="passWord">密码</param>
        /// <returns></returns>
        public static DataTable GetUserInfo(string userName, string passWord) {
            return DatabaseProvider.GetInstance().GetUserInfo(userName, passWord);
        }


        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        public static UserInfo GetUserInfo(int userId)
        {

            if (userId <= 0)
                return null;
            IDataReader reader;
            UserInfo userInfo = null;
            reader = DatabaseProvider.GetInstance().GetUserInfo(userId);
            if (reader.Read())
            {
                userInfo = LoadUserInfo(reader);
                reader.Close();
            }
            return userInfo;
        }

        public static UserInfo LoadUserInfo(IDataReader reader)
        {
            UserInfo userInfo = new UserInfo();
            userInfo.UserId = reader.GetInt32(reader.GetOrdinal("USERID"));
            userInfo.UserName = reader["USERNAME"].ToString();
            userInfo.Password = reader["PASSWORD"].ToString();
            userInfo.Enabled = reader.GetBoolean(reader.GetOrdinal("ENABLED"));
            userInfo.CreatedDate = TypeConverter.StrToDateTime(reader["CREATEDDATE"].ToString(),DateTime.Parse("1900-01-01"));
            userInfo.ModifiedDate = TypeConverter.StrToDateTime(reader["MODIFIEDDATE"].ToString(), DateTime.Parse("1900-01-01"));
            userInfo.PasswordEncrypted = TypeConverter.ObjectToInt(reader["PASSWORDENCRYPTED"]);
            userInfo.PasswordModifiedDate = TypeConverter.StrToDateTime(reader["PASSWORDMODIFIEDDATE"].ToString(), DateTime.Parse("1900-01-01"));
            userInfo.Realname = reader["REALNAME"].ToString();
            userInfo.Displayname = reader["DISPLAYNAME"].ToString();
            userInfo.Digest = reader["DIGEST"].ToString();
            userInfo.EmailAddress = reader["EMAILADDRESS"].ToString();
            userInfo.ReminderQueryQuestion = reader["REMINDERQUERYQUESTION"].ToString();
            userInfo.ReminderQueryAnswer = reader["REMINDERQUERYANSWER"].ToString();
            userInfo.Sex = reader["SEX"].ToString();
            userInfo.WorkPhone = reader["WORKPHONE"].ToString();
            userInfo.WorkMobile = reader["WORKMOBILE"].ToString();
            userInfo.Phone = reader["PHONE"].ToString();
            userInfo.Mobile = reader["MOBILE"].ToString();
            userInfo.Address = reader["ADDRESS"].ToString();
            userInfo.TimeZone = reader["TIMEZONE"].ToString();
            userInfo.Language = reader["LANGUAGE"].ToString();
            userInfo.Greeting = reader["GREETING"].ToString();
            userInfo.Website = reader["WEBSITE"].ToString();
            userInfo.Jobtitle = reader["JOBTITLE"].ToString();
            userInfo.Comments = reader["COMMENTS"].ToString();
            userInfo.Significantother = reader["SIGNIFICANTOTHER"].ToString();
            userInfo.Birthday = TypeConverter.StrToDateTime(reader["BIRTHDAY"].ToString(), DateTime.Parse("1900-01-01"));
            userInfo.Anniversary = TypeConverter.StrToDateTime(reader["ANNIVERSARY"].ToString(), DateTime.Parse("1900-01-01"));
            userInfo.LoginDate = TypeConverter.StrToDateTime(reader["LOGINDATE"].ToString(), DateTime.Parse("1900-01-01 00:00:00"));
            userInfo.LoginIp = reader["LOGINIP"].ToString();
            userInfo.LastLoginDate = TypeConverter.StrToDateTime(reader["LASTLOGINDATE"].ToString(), DateTime.Parse("1900-01-01  00:00:00"));
            userInfo.LastLoginIp = reader["LASTLOGINIP"].ToString();
            userInfo.IsSuperuser = reader.GetBoolean(reader.GetOrdinal("ISSUPERUSER"));
            userInfo.Orgid = reader["ORGID"].ToString();
            userInfo.Status = reader["STATUS"].ToString();

            return userInfo;
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        public static UserInfo GetUserInfoByUserName(string userName)
        {
            if (userName.Length == 0)
                return null;
            IDataReader reader;
            UserInfo userInfo = null;
            reader = DatabaseProvider.GetInstance().GetUserInfoToReader(userName);
            if (reader.Read())
            {
                userInfo = LoadUserInfo(reader);
                reader.Close();
            }
            return userInfo;
        
        }


        /// <summary>
        /// 新增用户信息
        /// </summary>
        /// <param name="userinfo"></param>
        /// <returns></returns>
        public static bool CreateUser(UserInfo userinfo) {
            return DatabaseProvider.GetInstance().CreateUser(userinfo);
        }

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public static bool UpdateUser(UserInfo userInfo) {
            return DatabaseProvider.GetInstance().UpdateUser(userInfo);
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
            if (passwordmodifieddate == null) {
                passwordmodifieddate = DateTime.Now;
            }
            return DatabaseProvider.GetInstance().UpdatePassword(userid, password, passwordmodifieddate);
        }

        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="uidList">用户ID列表</param>
        /// <returns></returns>
        public static int DeleteUserByUidlist(string uidList) {
            return DatabaseProvider.GetInstance().DeleteUserByUidlist(uidList);
        }
    }
}
