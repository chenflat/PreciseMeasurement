using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PM.Data;
using PM.Config;
using PM.Common;
using PM.Entity;

namespace PM.Data {

    public class Metergroup {

        /// <summary>
        /// 创建计量器组信息
        /// </summary>
        /// <param name="metergroupInfo">计量器组对象</param>
        /// <returns></returns>
        public static int CreateMetergroup(MetergroupInfo metergroupInfo) {
            return DatabaseProvider.GetInstance().CreateMetergroup(metergroupInfo);
        }

        /// <summary>
        /// 更新计量器组信息
        /// </summary>
        /// <param name="metergroupInfo">计量器组对象</param>
        /// <returns></returns>
        public static bool UpdateMetergroup(MetergroupInfo metergroupInfo) {
            return DatabaseProvider.GetInstance().UpdateMetergroup(metergroupInfo);
        }

        /// <summary>
        /// 删除计量器组信息
        /// </summary>
        /// <param name="idList">数据ID</param>
        /// <returns></returns>
        public static int DeleteMetergroup(string idList) {
            return DatabaseProvider.GetInstance().DeleteMetergroup(idList);
        }

        /// <summary>
        /// 查找计量器组信息
        /// </summary>
        /// <param name="condition">查询条件SQL,以 and 开头</param>
        /// <returns></returns>
        public static DataTable FindMetergroupByCondition(string condition) {
            return DatabaseProvider.GetInstance().FindMetergroupByCondition(condition);
        }

    }
}
