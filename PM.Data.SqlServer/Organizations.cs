using System;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

using PM.Data;
using PM.Config;
using PM.Common;
using PM.Entity;

using System.Text.RegularExpressions;
using System.Collections.Generic;


namespace PM.Data.SqlServer
{
    public partial class DataProvider : IDataProvider
    {
        public IDataReader FindAllOrganizations()
        {
            string commandText = string.Format("SELECT {0} FROM [ORGANIZATION] ORDER BY [ORGANIZATIONID] ASC",
                                                DbFields.ORGANIZATION);
            return DbHelper.ExecuteReader(System.Data.CommandType.Text, commandText);
        }

        public DataTable FindOrganizationsListDataTable()
        {
            string commandText = string.Format("SELECT {0} FROM [ORGANIZATION] ORDER BY [ORGANIZATIONID] ASC",
                                                DbFields.ORGANIZATION);

            return DbHelper.ExecuteDataset(CommandType.Text, commandText).Tables[0];
        }

        public IDataReader FindOrganizationsById(long id)
        {
            DbParameter param = DbHelper.MakeInParam("@ORGANIZATIONID", (DbType)SqlDbType.BigInt, 8, id);
            string commandText = string.Format("SELECT {0} FROM [{1}ORGANIZATION] WHERE [ORGANIZATIONID]=@ORGANIZATIONID",
                                                DbFields.ORGANIZATION,
                                                BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteReader(CommandType.Text, commandText, param);
        }

        public IDataReader FindOrganizationsByOrgId(string orgid)
        {
            DbParameter param = DbHelper.MakeInParam("@ORGID", (DbType)SqlDbType.VarChar, 8, orgid);
            string commandText = string.Format("SELECT {0} FROM [{1}ORGANIZATION] WHERE [ORGID]=@ORGID",
                                                DbFields.ORGANIZATION,
                                                BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteReader(CommandType.Text, commandText, param);
        }

        public long AddOrganizations(OrganizationInfo orgInfo)
        {
            DbParameter[] parms = { 
                                  DbHelper.MakeInParam("@ORGID", (DbType)SqlDbType.VarChar, 8, orgInfo.Orgid),
                                  DbHelper.MakeInParam("@DESCRIPTION", (DbType)SqlDbType.VarChar, 100, orgInfo.Description),
                                  DbHelper.MakeInParam("@ORGTYPE", (DbType)SqlDbType.VarChar, 10, orgInfo.Orgtype),
                                  DbHelper.MakeInParam("@LEVEL", (DbType)SqlDbType.Int, 4, orgInfo.Level),
                                  DbHelper.MakeInParam("@COMMENTS", (DbType)SqlDbType.VarChar, 256, orgInfo.Comments),
                                  DbHelper.MakeInParam("@LEADER", (DbType)SqlDbType.VarChar, 50, orgInfo.Leader),
                                  DbHelper.MakeInParam("@PHONE", (DbType)SqlDbType.VarChar, 50, orgInfo.Phone),
                                  DbHelper.MakeInParam("@ADDRESS", (DbType)SqlDbType.VarChar, 100, orgInfo.Address),
                                  DbHelper.MakeInParam("@PARENT", (DbType)SqlDbType.VarChar, 8, orgInfo.Parent)

                                  };
            string commandText = string.Format("INSERT INTO [{0}ORGANIZATION] ([ORGID],[DESCRIPTION],[ORGTYPE],[LEVEL_],[COMMENTS],[LEADER],[PHONE],[ADDRESS],[PARENT]) VALUES(@ORGID, @DESCRIPTION, @ORGTYPE, @LEVEL, @COMMENTS, @LEADER, @PHONE,@ADDRESS,@PARENT)", BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms);
        }

        public long UpdateOrganizations(OrganizationInfo orgInfo)
        {
            DbParameter[] parms = { 
                                  DbHelper.MakeInParam("@ORGANIZATIONID", (DbType)SqlDbType.BigInt, 8, orgInfo.Organizationid),
                                  DbHelper.MakeInParam("@DESCRIPTION", (DbType)SqlDbType.VarChar, 100, orgInfo.Description),
                                  DbHelper.MakeInParam("@ORGTYPE", (DbType)SqlDbType.VarChar, 10, orgInfo.Orgtype),
                                  DbHelper.MakeInParam("@LEVEL", (DbType)SqlDbType.Int, 4, orgInfo.Level),
                                  DbHelper.MakeInParam("@COMMENTS", (DbType)SqlDbType.VarChar, 256, orgInfo.Comments),
                                  DbHelper.MakeInParam("@LEADER", (DbType)SqlDbType.VarChar, 50, orgInfo.Leader),
                                  DbHelper.MakeInParam("@PHONE", (DbType)SqlDbType.VarChar, 50, orgInfo.Phone),
                                  DbHelper.MakeInParam("@ADDRESS", (DbType)SqlDbType.VarChar, 100, orgInfo.Address),
                                  DbHelper.MakeInParam("@PARENT", (DbType)SqlDbType.VarChar, 8, orgInfo.Parent)
                                  };
            string commandText = string.Format("UPDATE [{0}ORGANIZATION] SET [DESCRIPTION]=@DESCRIPTION, [ORGTYPE]=@ORGTYPE,[LEVEL_]=@LEVEL,[COMMENTS]=@COMMENTS,[LEADER]=@LEADER,[PHONE]=@PHONE,[ADDRESS]=@ADDRESS,PARENT=@PARENT WHERE [ORGANIZATIONID]=@ORGANIZATIONID",
                                                BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms);
        }

        public long DeleteOrganizations(long organizationid)
        {
            if (!Utils.IsNumeric(organizationid))
                return 0;
            string commandText = string.Format("DELETE FROM [{0}ORGANIZATION] WHERE [ORGANIZATIONID]='{1}'",
                                                BaseConfigs.GetTablePrefix,
                                                organizationid);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText);
        }
       
    }
}
