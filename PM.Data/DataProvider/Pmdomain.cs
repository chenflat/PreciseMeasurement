using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PM.Data;
using PM.Config;
using PM.Common;
using PM.Entity;

namespace PM.Data {
    public class Pmdomain {
        /// <summary>
        /// 创建系统系统域定义
        /// </summary>
        /// <param name="pmdomainInfo">系统域定义对象</param>
        /// <returns></returns>
        public static int CreatePmdomain(PmdomainInfo pmdomainInfo) {
            return DatabaseProvider.GetInstance().CreatePmdomain(pmdomainInfo);
        }

        /// <summary>
        /// 更新系统域定义
        /// </summary>
        /// <param name="pmdomainInfo">系统域定义对象</param>
        /// <returns></returns>
        public static bool UpdatePmdomain(PmdomainInfo pmdomainInfo) {
            return DatabaseProvider.GetInstance().UpdatePmdomain(pmdomainInfo);
        }


        /// <summary>
        /// 删除系统域定义
        /// </summary>
        /// <param name="idList">系统域定义主键ID，多个ID以","分隔</param>
        /// <returns></returns>
        public static int DeletePmdomain(string idList) {
            return DatabaseProvider.GetInstance().DeletePmdomain(idList);
        }


        /// <summary>
        /// 查找系统域定义
        /// </summary>
        /// <param name="condition"></param>
        /// <returns>查询条件SQL,以 and 开头</returns>
        public static DataTable FindPmdomainByCondition(string condition) {
            return DatabaseProvider.GetInstance().FindPmdomainByCondition(condition);
        }

    }
}
