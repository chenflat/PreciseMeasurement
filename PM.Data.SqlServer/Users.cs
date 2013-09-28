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
            string commandText = string.Format("SELECT  {0}  FROM [{1}USERS] where 1=1 {2} ORDER BY [USERID] DESC",
                                                   DbFields.USERS,
                                                   BaseConfigs.GetTablePrefix,
                                                   condition);
            return DbHelper.ExecuteDataset(CommandType.Text, commandText).Tables[0];
        }

        public DataTable GetUserInfo(string userName, string passWord)
        {
            throw new NotImplementedException();
        }

        public DataTable GetUserInfo(int userId)
        {
            throw new NotImplementedException();
        }

        public IDataReader GetUserInfoToReader(string userName)
        {
            throw new NotImplementedException();
        }

        public DataTable GetUserList(int pageSize, int pageIndex, string column, string orderType)
        {
            throw new NotImplementedException();
        }

        public DataTable GetUserList(int pageSize, int currentPage)
        {
            throw new NotImplementedException();
        }

        public bool CreateUser(UserInfo userinfo)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(UserInfo userInfo)
        {
            throw new NotImplementedException();
        }

        public void DeleteUserByUidlist(string uidList)
        {
            throw new NotImplementedException();
        }

    }
}
