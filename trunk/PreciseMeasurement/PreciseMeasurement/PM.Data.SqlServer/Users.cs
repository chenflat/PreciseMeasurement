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
    public partial class DataProvider : IDataProvider
    {

        public DataTable FindUserTableByCondition(string condition)
        {
            string commandText = string.Format("SELECT  [{0}USERS].*,[{0}LOCATIONS].DESCRIPTION as ORGNAME FROM [{0}USERS] LEFT OUTER JOIN [{0}LOCATIONS] ON [{0}USERS].ORGID=[{0}LOCATIONS].ORGID  where [{0}USERS].STATUS<>'DELETED' {1} ORDER BY [{0}USERS].[USERID] DESC",
                                                   BaseConfigs.GetTablePrefix,
                                                   condition);
            return DbHelper.ExecuteDataset(CommandType.Text, commandText).Tables[0];
        }

        public int UsersCount(string condition) {
            string commandText = string.Format("SELECT COUNT(USERID) FROM [{0}USERS] WHERE STATUS<>'DELETED' {1}",
                                            BaseConfigs.GetTablePrefix, condition);
            return TypeConverter.ObjectToInt(DbHelper.ExecuteDataset(CommandType.Text, commandText).Tables[0].Rows[0][0]);
        }

        public DataTable GetUserInfo(string userName, string passWord)
        {
            string commandText = string.Format("SELECT  {0}  FROM [{1}USERS] where  STATUS<>'DELETED' and USERNAME='{2}' and PASSWORD='{3}'  ORDER BY [USERID] DESC",
                                                    DbFields.USERS,
                                                    BaseConfigs.GetTablePrefix,
                                                    userName,passWord);
            return DbHelper.ExecuteDataset(CommandType.Text, commandText).Tables[0];
        }

        public IDataReader GetUserInfo(int userId)
        {
            DbParameter param = DbHelper.MakeInParam("@USERID", (DbType)SqlDbType.Int, 4, userId);
            string commandText = string.Format("select {0} from [{1}MEASUREPOINT] WHERE [USERID]=@USERID",
                                                DbFields.USERS,
                                                BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteReader(CommandType.Text, commandText, param);
        }

        public IDataReader GetUserInfoToReader(string userName)
        {
            DbParameter param = DbHelper.MakeInParam("@USERNAME", (DbType)SqlDbType.Text, 50, userName);
            string commandText = string.Format("select {0} from [{1}MEASUREPOINT] WHERE  STATUS<>'DELETED' and [USERNAME]=@USERNAME",
                                                DbFields.USERS,
                                                BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteReader(CommandType.Text, commandText, param);
        }

        public bool CreateUser(UserInfo userinfo)
        {
            DbParameter[] parms = { 
                                  DbHelper.MakeInParam("@USERID", (DbType)SqlDbType.Int, 4, userinfo.UserId),
                                  DbHelper.MakeInParam("@USERNAME", (DbType)SqlDbType.VarChar, 50, userinfo.UserName),
                                  DbHelper.MakeInParam("@PASSWORD", (DbType)SqlDbType.VarChar, 50, userinfo.Password),
                                  DbHelper.MakeInParam("@ENABLED", (DbType)SqlDbType.SmallInt, 1, userinfo.Enabled),
                                  DbHelper.MakeInParam("@CREATEDDATE", (DbType)SqlDbType.DateTime, 8, userinfo.CreatedDate),
                                  DbHelper.MakeInParam("@MODIFIEDDATE", (DbType)SqlDbType.DateTime, 8, userinfo.ModifiedDate),
                                  DbHelper.MakeInParam("@PASSWORDENCRYPTED", (DbType)SqlDbType.Int, 4, userinfo.PasswordEncrypted),
                                  DbHelper.MakeInParam("@PASSWORDMODIFIEDDATE", (DbType)SqlDbType.DateTime, 8, userinfo.PasswordModifiedDate),
                                  DbHelper.MakeInParam("@REALNAME", (DbType)SqlDbType.VarChar, 45, userinfo.Realname),
                                  DbHelper.MakeInParam("@DISPLAYNAME", (DbType)SqlDbType.VarChar, 45, userinfo.Displayname),
                                  DbHelper.MakeInParam("@DIGEST", (DbType)SqlDbType.VarChar, 255, userinfo.Digest),
                                  DbHelper.MakeInParam("@PASSWORD", (DbType)SqlDbType.VarChar, 50, userinfo.Password),
                                  DbHelper.MakeInParam("@EMAILADDRESS", (DbType)SqlDbType.VarChar, 100, userinfo.EmailAddress),
                                  DbHelper.MakeInParam("@REMINDERQUERYQUESTION", (DbType)SqlDbType.VarChar, 75, userinfo.ReminderQueryQuestion),
                                  DbHelper.MakeInParam("@REMINDERQUERYANSWER", (DbType)SqlDbType.VarChar, 75, userinfo.ReminderQueryAnswer),
                                  DbHelper.MakeInParam("@SEX", (DbType)SqlDbType.VarChar, 10, userinfo.Sex),
                                  DbHelper.MakeInParam("@WORKPHONE", (DbType)SqlDbType.VarChar, 30, userinfo.WorkPhone),
                                  DbHelper.MakeInParam("@WORKMOBILE", (DbType)SqlDbType.VarChar, 30, userinfo.WorkMobile),
                                  DbHelper.MakeInParam("@PHONE", (DbType)SqlDbType.VarChar, 30, userinfo.Phone),
                                  DbHelper.MakeInParam("@MOBILE", (DbType)SqlDbType.VarChar, 30, userinfo.Mobile),
                                  DbHelper.MakeInParam("@ADDRESS", (DbType)SqlDbType.VarChar, 100, userinfo.Address),
                                  DbHelper.MakeInParam("@TIMEZONE", (DbType)SqlDbType.VarChar, 75, userinfo.TimeZone),
                                  DbHelper.MakeInParam("@LANGUAGE", (DbType)SqlDbType.VarChar, 75, userinfo.Language),
                                  DbHelper.MakeInParam("@GREETING", (DbType)SqlDbType.VarChar, 255, userinfo.Greeting),
                                  DbHelper.MakeInParam("@WEBSITE", (DbType)SqlDbType.VarChar, 75, userinfo.Website),
                                  DbHelper.MakeInParam("@JOBTITLE", (DbType)SqlDbType.VarChar, 100, userinfo.Jobtitle),
                                  DbHelper.MakeInParam("@COMMENTS", (DbType)SqlDbType.VarChar, 4000, userinfo.Comments),
                                  DbHelper.MakeInParam("@SIGNIFICANTOTHER", (DbType)SqlDbType.VarChar, 100, userinfo.Significantother),
                                  DbHelper.MakeInParam("@BIRTHDAY", (DbType)SqlDbType.DateTime, 8, userinfo.Birthday),
                                  DbHelper.MakeInParam("@ANNIVERSARY", (DbType)SqlDbType.DateTime, 8, userinfo.Anniversary),
                                  DbHelper.MakeInParam("@LOGINDATE", (DbType)SqlDbType.DateTime, 8, userinfo.LoginDate),
                                  DbHelper.MakeInParam("@LOGINIP", (DbType)SqlDbType.VarChar, 100, userinfo.LoginIp),
                                  DbHelper.MakeInParam("@LASTLOGINDATE", (DbType)SqlDbType.DateTime, 8, userinfo.LastLoginDate),
                                  DbHelper.MakeInParam("@LASTLOGINIP", (DbType)SqlDbType.VarChar, 100, userinfo.LastLoginIp),
                                  DbHelper.MakeInParam("@ISSUPERUSER", (DbType)SqlDbType.TinyInt, 1, userinfo.IsSuperuser),
                                  DbHelper.MakeInParam("@ORGID", (DbType)SqlDbType.VarChar, 8, userinfo.Orgid),
                                  DbHelper.MakeInParam("@STATUS", (DbType)SqlDbType.VarChar, 20, userinfo.Status),
                                 };
            string commandText = string.Format("INSERT INTO [{0}USERS] ([USERNAME],[PASSWORD],[ENABLED],[CREATEDDATE],[MODIFIEDDATE],[PASSWORDENCRYPTED],"
                + "[PASSWORDMODIFIEDDATE],[REALNAME],[DISPLAYNAME],[DIGEST],[EMAILADDRESS],[REMINDERQUERYQUESTION],[REMINDERQUERYANSWER],"
                + "[SEX],[WORKPHONE],[WORKMOBILE],[PHONE],[MOBILE],[ADDRESS],[TIMEZONE],[LANGUAGE],[GREETING],[WEBSITE],[JOBTITLE],[COMMENTS],"
                + "[SIGNIFICANTOTHER],[BIRTHDAY],[ANNIVERSARY],[LOGINDATE],[LOGINIP],[LASTLOGINDATE],[LASTLOGINIP],[ISSUPERUSER],[ORGID],[STATUS]) "
                + "values (@USERNAME,@PASSWORD,@ENABLED,@CREATEDDATE,@MODIFIEDDATE,@PASSWORDENCRYPTED,"
                + "@PASSWORDMODIFIEDDATE,@REALNAME,@DISPLAYNAME,@DIGEST,@EMAILADDRESS,@REMINDERQUERYQUESTION,@REMINDERQUERYANSWER,"
                + "@SEX,@WORKPHONE,@WORKMOBILE,@PHONE,@MOBILE,@ADDRESS,@TIMEZONE,@LANGUAGE,@GREETING,@WEBSITE,@JOBTITLE,@COMMENTS,"
                + "@SIGNIFICANTOTHER,@BIRTHDAY,@ANNIVERSARY,@LOGINDATE,@LOGINIP,@LASTLOGINDATE,@LASTLOGINIP,@ISSUPERUSER,@ORGID,@STATUS)", BaseConfigs.GetTablePrefix);
             return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms)>0;
        }

        public bool UpdateUser(UserInfo userinfo)
        {
            DbParameter[] parms = { 
                                  DbHelper.MakeInParam("@USERID", (DbType)SqlDbType.Int, 4, userinfo.UserId),
                                  DbHelper.MakeInParam("@USERNAME", (DbType)SqlDbType.VarChar, 50, userinfo.UserName),
                                  DbHelper.MakeInParam("@PASSWORD", (DbType)SqlDbType.VarChar, 50, userinfo.Password),
                                  DbHelper.MakeInParam("@ENABLED", (DbType)SqlDbType.SmallInt, 1, userinfo.Enabled),
                                  DbHelper.MakeInParam("@CREATEDDATE", (DbType)SqlDbType.DateTime, 8, userinfo.CreatedDate),
                                  DbHelper.MakeInParam("@MODIFIEDDATE", (DbType)SqlDbType.DateTime, 8, userinfo.ModifiedDate),
                                  DbHelper.MakeInParam("@PASSWORDENCRYPTED", (DbType)SqlDbType.Int, 4, userinfo.PasswordEncrypted),
                                  DbHelper.MakeInParam("@PASSWORDMODIFIEDDATE", (DbType)SqlDbType.DateTime, 8, userinfo.PasswordModifiedDate),
                                  DbHelper.MakeInParam("@REALNAME", (DbType)SqlDbType.VarChar, 45, userinfo.Realname),
                                  DbHelper.MakeInParam("@DISPLAYNAME", (DbType)SqlDbType.VarChar, 45, userinfo.Displayname),
                                  DbHelper.MakeInParam("@DIGEST", (DbType)SqlDbType.VarChar, 255, userinfo.Digest),
                                  DbHelper.MakeInParam("@PASSWORD", (DbType)SqlDbType.VarChar, 50, userinfo.Password),
                                  DbHelper.MakeInParam("@EMAILADDRESS", (DbType)SqlDbType.VarChar, 100, userinfo.EmailAddress),
                                  DbHelper.MakeInParam("@REMINDERQUERYQUESTION", (DbType)SqlDbType.VarChar, 75, userinfo.ReminderQueryQuestion),
                                  DbHelper.MakeInParam("@REMINDERQUERYANSWER", (DbType)SqlDbType.VarChar, 75, userinfo.ReminderQueryAnswer),
                                  DbHelper.MakeInParam("@SEX", (DbType)SqlDbType.VarChar, 10, userinfo.Sex),
                                  DbHelper.MakeInParam("@WORKPHONE", (DbType)SqlDbType.VarChar, 30, userinfo.WorkPhone),
                                  DbHelper.MakeInParam("@WORKMOBILE", (DbType)SqlDbType.VarChar, 30, userinfo.WorkMobile),
                                  DbHelper.MakeInParam("@PHONE", (DbType)SqlDbType.VarChar, 30, userinfo.Phone),
                                  DbHelper.MakeInParam("@MOBILE", (DbType)SqlDbType.VarChar, 30, userinfo.Mobile),
                                  DbHelper.MakeInParam("@ADDRESS", (DbType)SqlDbType.VarChar, 100, userinfo.Address),
                                  DbHelper.MakeInParam("@TIMEZONE", (DbType)SqlDbType.VarChar, 75, userinfo.TimeZone),
                                  DbHelper.MakeInParam("@LANGUAGE", (DbType)SqlDbType.VarChar, 75, userinfo.Language),
                                  DbHelper.MakeInParam("@GREETING", (DbType)SqlDbType.VarChar, 255, userinfo.Greeting),
                                  DbHelper.MakeInParam("@WEBSITE", (DbType)SqlDbType.VarChar, 75, userinfo.Website),
                                  DbHelper.MakeInParam("@JOBTITLE", (DbType)SqlDbType.VarChar, 100, userinfo.Jobtitle),
                                  DbHelper.MakeInParam("@COMMENTS", (DbType)SqlDbType.VarChar, 4000, userinfo.Comments),
                                  DbHelper.MakeInParam("@SIGNIFICANTOTHER", (DbType)SqlDbType.VarChar, 100, userinfo.Significantother),
                                  DbHelper.MakeInParam("@BIRTHDAY", (DbType)SqlDbType.DateTime, 8, userinfo.Birthday),
                                  DbHelper.MakeInParam("@ANNIVERSARY", (DbType)SqlDbType.DateTime, 8, userinfo.Anniversary),
                                  DbHelper.MakeInParam("@LOGINDATE", (DbType)SqlDbType.DateTime, 8, userinfo.LoginDate),
                                  DbHelper.MakeInParam("@LOGINIP", (DbType)SqlDbType.VarChar, 100, userinfo.LoginIp),
                                  DbHelper.MakeInParam("@LASTLOGINDATE", (DbType)SqlDbType.DateTime, 8, userinfo.LastLoginDate),
                                  DbHelper.MakeInParam("@LASTLOGINIP", (DbType)SqlDbType.VarChar, 100, userinfo.LastLoginIp),
                                  DbHelper.MakeInParam("@ISSUPERUSER", (DbType)SqlDbType.TinyInt, 1, userinfo.IsSuperuser),
                                  DbHelper.MakeInParam("@ORGID", (DbType)SqlDbType.VarChar, 8, userinfo.Orgid),
                                  DbHelper.MakeInParam("@STATUS", (DbType)SqlDbType.VarChar, 20, userinfo.Status),
                                 };
            string commandText = string.Format("UPDATE [{0}USERS] SET [USERNAME]=@USERNAME,[PASSWORD]=@PASSWORD,[ENABLED]=@ENABLED,"
                + "[CREATEDDATE]=@CREATEDDATE,[MODIFIEDDATE]=@MODIFIEDDATE,[PASSWORDENCRYPTED]=@PASSWORDENCRYPTED,"
                + "[PASSWORDMODIFIEDDATE]=@PASSWORDMODIFIEDDATE,[REALNAME]=@REALNAME,[DISPLAYNAME]=@DISPLAYNAME,[DIGEST]=@DIGEST,"
                + "[EMAILADDRESS]=@EMAILADDRESS,[REMINDERQUERYQUESTION]=@REMINDERQUERYQUESTION,[REMINDERQUERYANSWER]=@REMINDERQUERYANSWER,"
                + "[SEX]=@SEX,[WORKPHONE]=@WORKPHONE,[WORKMOBILE]=@WORKMOBILE,[PHONE]=@PHONE,[MOBILE]=@MOBILE,[ADDRESS]=@ADDRESS,"
                + "[TIMEZONE]=@TIMEZONE,[LANGUAGE]=@LANGUAGE,[GREETING]=@GREETING,[WEBSITE]=@WEBSITE,[JOBTITLE]=@JOBTITLE,[COMMENTS]=@COMMENTS,"
                + "[SIGNIFICANTOTHER]=@SIGNIFICANTOTHER,[BIRTHDAY]=@BIRTHDAY,[ANNIVERSARY]=@ANNIVERSARY,[LOGINDATE]=@LOGINDATE,[LOGINIP]=@LOGINIP,"
                + "[LASTLOGINDATE]=@LASTLOGINDATE,[LASTLOGINIP]=@LASTLOGINIP,[ISSUPERUSER]=@ISSUPERUSER,[ORGID]=@ORGID,[STATUS]=@STATUS"
                + " WHERE [USERID]=@USERID", BaseConfigs.GetTablePrefix);



            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms) > 0;
        }


        public bool UpdatePassword(int userid, string password, DateTime passwordmodifieddate) {
            DbParameter[] parms = { 
                                  DbHelper.MakeInParam("@USERID", (DbType)SqlDbType.Int, 4, userid),
                                  DbHelper.MakeInParam("@PASSWORD", (DbType)SqlDbType.VarChar, 50, password),
                                  DbHelper.MakeInParam("@PASSWORDMODIFIEDDATE", (DbType)SqlDbType.DateTime, 8, passwordmodifieddate)
                                  };
             string commandText = string.Format("UPDATE [{0}USERS] SET PASSWORD=@PASSWORD,PASSWORDMODIFIEDDATE=@PASSWORDMODIFIEDDATE WHERE [USERID]=@USERID",BaseConfigs.GetTablePrefix);
             return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms) > 0;
        }

        public int DeleteUserByUidlist(string uidList)
        {
            string commandText = string.Format("UPDATE [{0}USERS] SET [STATUS]='DELETED' WHERE [USERID] IN ({1})",
                                              BaseConfigs.GetTablePrefix,
                                              uidList);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText);
        }

    }
}
