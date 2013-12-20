using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PM.Data;
using PM.Config;
using PM.Common;
using PM.Entity;

namespace PM.Data {

    /// <summary>
    /// 同义数值域定义
    /// </summary>
    public class Synonymdomain {

        /// <summary>
        /// 创建同义数值域定义
        /// </summary>
        /// <param name="synonymdomainInfo">同义数值域定义对象</param>
        /// <returns></returns>
        public static int CreateSynonymdomain(SynonymdomainInfo synonymdomainInfo) {
            return DatabaseProvider.GetInstance().CreateSynonymdomain(synonymdomainInfo);
        }

        /// <summary>
        /// 更新同义数值域定义
        /// </summary>
        /// <param name="synonymdomainInfo">同义数值域定义对象</param>
        /// <returns></returns>
        public static bool UpdateSynonymdomain(SynonymdomainInfo synonymdomainInfo) {
            return DatabaseProvider.GetInstance().UpdateSynonymdomain(synonymdomainInfo);
        }

        /// <summary>
        /// 删除同义数值域定义
        /// </summary>
        /// <param name="idList">同义数值域定义主键ID</param>
        /// <returns></returns>
        public static int DeleteSynonymdomain(string idList) {
            return DatabaseProvider.GetInstance().DeleteSynonymdomain(idList);
        }

        /// <summary>
        /// 查找同义数值域定义
        /// </summary>
        /// <param name="condition">查询条件SQL,以 and 开头</param>
        /// <returns></returns>
        public static DataTable FindSynonymdomainByCondition(string condition) {
            return DatabaseProvider.GetInstance().FindSynonymdomainByCondition(condition);
        }


        /// <summary>
        /// 查找同义数值域定义
        /// </summary>
        /// <param name="domainId">域ID</param>
        /// <returns></returns>
        public static DataTable FindSynonymdomainByDomainId(string domainId) {
            return DatabaseProvider.GetInstance().FindSynonymdomainByDomainId(domainId);
        }
    }
}
