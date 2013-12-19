using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PM.Data;
using PM.Config;
using PM.Common;
using PM.Entity;

namespace PM.Data {

    public class Longdescription {

        /// <summary>
        /// 创建长描述
        /// </summary>
        /// <param name="longdescriptionInfo">长描述对象</param>
        /// <returns></returns>
        public static int CreateLongdescription(LongdescriptionInfo longdescriptionInfo) {
            return DatabaseProvider.GetInstance().CreateLongdescription(longdescriptionInfo);
        }

        /// <summary>
        /// 更新长描述，通过主键ID
        /// </summary>
        /// <param name="longdescriptionInfo">长描述对象</param>
        /// <returns></returns>
        public static bool UpdateLongdescriptionById(LongdescriptionInfo longdescriptionInfo) {
            return DatabaseProvider.GetInstance().UpdateLongdescriptionById(longdescriptionInfo);
        }

        /// <summary>
        /// 更新长描述,通过键值
        /// </summary>
        /// <param name="longdescriptionInfo">长描述对象</param>
        /// <returns></returns>
        public static bool UpdateLongdescriptionByKey(LongdescriptionInfo longdescriptionInfo) {
            return DatabaseProvider.GetInstance().UpdateLongdescriptionByKey(longdescriptionInfo);
        }

        /// <summary>
        /// 删除长描述
        /// </summary>
        /// <param name="idList">长描述主键ID，多个ID以","分隔</param>
        /// <returns></returns>
        public static int DeleteLongdescription(string idList) {
            return DatabaseProvider.GetInstance().DeleteLongdescription(idList);
        }

        /// <summary>
        /// 查找长描述
        /// </summary>
        /// <param name="condition">查询条件SQL,以 and 开头</param>
        /// <returns></returns>
        public static DataTable FindLongdescriptionByCondition(string condition) {
            return DatabaseProvider.GetInstance().FindLongdescriptionByCondition(condition);
        }

    }
}
