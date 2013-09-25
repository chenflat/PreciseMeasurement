using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using PM.Entity;
using PM.Common;

namespace PM.Data
{
    /// <summary>
    /// 组织机构数据操作类
    /// </summary>
    public class Organizations
    {
        /// <summary>
        /// 获取组织机构
        /// </summary>
        /// <returns></returns>
        public static IDataReader FindAllOrganizations() {
            return DatabaseProvider.GetInstance().FindAllOrganizations();
        }

        /// <summary>
        /// 获取组织机构
        /// </summary>
        /// <returns></returns>
        public static DataTable FindOrganizationsListDataTable()
        {
            return DatabaseProvider.GetInstance().FindOrganizationsListDataTable();
        }

        /// <summary>
        /// 获取组织机构信息
        /// </summary>
        /// <param name="organizationid">组织机构ID</param>
        /// <returns></returns>
        public static OrganizationInfo GetOrganizationInfo(long organizationid)
        {
            if (organizationid <= 0)
                return null;
            IDataReader reader;
            OrganizationInfo orgInfo = null;
            reader = DatabaseProvider.GetInstance().FindOrganizationsById(organizationid);
            if (reader.Read())
            {
                orgInfo = LoadOrganizationInfo(reader);
                reader.Close();
            }
            return orgInfo;
        }

        /// <summary>
        /// 获取组织机构信息
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static OrganizationInfo LoadOrganizationInfo(IDataReader reader)
        {
            OrganizationInfo orgInfo = new OrganizationInfo();
            orgInfo.Organizationid = reader.GetInt64(reader.GetOrdinal("ORGANIZATIONID"));
            orgInfo.Orgid = reader["ORGID"].ToString();
            orgInfo.Description = reader["DESCRIPTION"].ToString();
            orgInfo.Orgtype = reader["ORGTYPE"].ToString();
            orgInfo.Level = TypeConverter.ObjectToInt(reader["LEVEL_"].ToString());
            orgInfo.Comments = reader["COMMENTS"].ToString();
            orgInfo.Leader = reader["LEADER"].ToString();
            orgInfo.Phone = reader["PHONE"].ToString();
            orgInfo.Address = reader["ADDRESS"].ToString();
            orgInfo.Parent = reader["PARENT"].ToString();

            return orgInfo;
        }

        /// <summary>
        /// 获取组织机构信息
        /// </summary>
        /// <param name="organizationid">组织机构ID</param>
        /// <returns></returns>
        public static OrganizationInfo GetOrganizationInfoByOrgId(string orgid)
        {
            IDataReader reader;
            OrganizationInfo orgInfo = null;

            reader = DatabaseProvider.GetInstance().FindOrganizationsByOrgId(orgid);
            if (reader.Read())
            {
                orgInfo = LoadOrganizationInfo(reader);
                reader.Close();
            }
            return orgInfo;
        }

        /// <summary>
        /// 创建组织机构
        /// </summary>
        /// <param name="orgInfo"></param>
        public static long CreateOrganizationInfo(OrganizationInfo orgInfo) {
            return DatabaseProvider.GetInstance().AddOrganizations(orgInfo);
        }

        /// <summary>
        /// 更新组织机构
        /// </summary>
        /// <param name="orgInfo"></param>
        public static long UpdateOrganizationInfo(OrganizationInfo orgInfo) {
           return DatabaseProvider.GetInstance().UpdateOrganizations(orgInfo);
        }

        /// <summary>
        /// 删除组织机构
        /// </summary>
        /// <param name="organizationid">组织机构ID</param>
        public static long DeleteOrganizationInfo(long organizationid)
        {
            return DatabaseProvider.GetInstance().DeleteOrganizations(organizationid);
        }
       
    }
}
