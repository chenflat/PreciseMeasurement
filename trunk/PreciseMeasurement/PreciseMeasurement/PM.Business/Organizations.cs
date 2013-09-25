using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using PM.Data;
using PM.Entity;
using System.Web;

namespace PM.Business
{
    /// <summary>
    /// 组织机构业务逻辑类
    /// </summary>
    public class Organizations
    {
        private static List<OrganizationInfo> treeList = null;

        /// <summary>
        /// 获取所有机构
        /// </summary>
        /// <returns></returns>
        public static DataTable FindAllOrganizations()
        {
            return PM.Data.Organizations.FindOrganizationsListDataTable();
        }

        /// <summary>
        /// 获取所有机构
        /// </summary>
        /// <returns></returns>
        public static List<OrganizationInfo> GetOrganizationsList()
        {
            List<OrganizationInfo> listAll = new List<OrganizationInfo>();
            using (IDataReader reader = PM.Data.Organizations.FindAllOrganizations())
            {
                while (reader.Read())
                {
                    OrganizationInfo orginfo = PM.Data.Organizations.LoadOrganizationInfo(reader);
                    listAll.Add(orginfo);
                }
                reader.Close();
            }
            return listAll;
        }


        /// <summary>
        /// 获取所有机构树形列表
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public static List<OrganizationInfo> GetOrganizationTreeList(string prefix)
        {
            if (treeList == null) {
                treeList = new List<OrganizationInfo>();
                List<OrganizationInfo> listAll = GetOrganizationsList();
                foreach (OrganizationInfo orginfo in listAll)
                {
                    if (orginfo.Parent.Equals("")) {
                        treeList.Add(orginfo);
                        CreateOrganizationTree(listAll,orginfo.Orgid, prefix);
                    }
                }
                
            }
            return treeList;
        }


        /// <summary>
        /// 创建机构树节点
        /// </summary>
        /// <param name="list"></param>
        /// <param name="orgid"></param>
        /// <param name="prefix"></param>
        public static void CreateOrganizationTree(List<OrganizationInfo> list,string orgid,string prefix) {
            foreach (OrganizationInfo orginfo in list)
            {
                if (orginfo.Parent.Equals(orgid))
                {
                    orginfo.Description = prefix + orginfo.Description;
                    treeList.Add(orginfo);
                    CreateOrganizationTree(list, orginfo.Orgid, prefix + prefix);
                }
                
            }
        }

        /// <summary>
        /// 移除机构权变量
        /// </summary>
        public static void RemoveTreeList() {
            treeList = null;
        }

        /// <summary>
        /// 获取组织机构信息
        /// </summary>
        /// <param name="id">机构ID</param>
        /// <returns>组织机构信息</returns>
        public static OrganizationInfo GetOrganizationInfo(long id) {
            return id > 0 ? Data.Organizations.GetOrganizationInfo(id) : null;
        }

        public static long CreateOrganizationInfo(OrganizationInfo orgInfo) {
            long result = Data.Organizations.CreateOrganizationInfo(orgInfo);
            RemoveTreeList();
            return result;
        }

        public static long UpdateOrganizationInfo(OrganizationInfo orgInfo) {
            long result = Data.Organizations.UpdateOrganizationInfo(orgInfo);
            RemoveTreeList();
            return result;
        }

        public static long DeleteOrganizationInfo(long organizationid)
        {
            long id = Data.Organizations.DeleteOrganizationInfo(organizationid);
            RemoveTreeList();
            return id;
            
        }
    }
}
