using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PM.Data;
using PM.Config;
using PM.Common;
using PM.Entity;

namespace PM.Data {
    
    public class Meteringroup {

        /// <summary>
        /// 创建计量器组包含的计量器
        /// </summary>
        /// <param name="meteringroupInfo">计量器组包含的计量器对象</param>
        /// <returns></returns>
        public static int CreateMeteringroup(MeteringroupInfo meteringroupInfo) {
            return DatabaseProvider.GetInstance().CreateMeteringroup(meteringroupInfo);
        }

        /// <summary>
        /// 更新计量器组包含的计量器
        /// </summary>
        /// <param name="meteringroupInfo">计量器组包含的计量器对象</param>
        /// <returns></returns>
        public static bool UpdateMeteringroup(MeteringroupInfo meteringroupInfo) {
            return DatabaseProvider.GetInstance().UpdateMeteringroup(meteringroupInfo);
        }

        /// <summary>
        /// 删除计量器组包含的计量器
        /// </summary>
        /// <param name="idList">数据ID</param>
        /// <returns></returns>
        public static int DeleteMeteringroup(string idList) {
            return DatabaseProvider.GetInstance().DeleteMeteringroup(idList);
        }

        /// <summary>
        /// 查找计量器组包含的计量器
        /// </summary>
        /// <param name="condition">查询SQL,以 and 开头</param>
        /// <returns></returns>
        public static DataTable FindMeteringroupByCondition(string condition) {
            return DatabaseProvider.GetInstance().FindMeteringroupByCondition(condition);
        }

    }
}
