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
    /// 资产属性模板
    /// </summary>
    public class Classspec {

        /// <summary>
        /// 创建资产属性模板
        /// </summary>
        /// <param name="classspecInfo">资产属性模板对象</param>
        /// <returns></returns>
        public static int CreateClassspec(ClassspecInfo classspecInfo) {
            return DatabaseProvider.GetInstance().CreateClassspec(classspecInfo);
        }

        /// <summary>
        /// 更新资产属性模板
        /// </summary>
        /// <param name="classspecInfo">资产属性模板对象</param>
        /// <returns></returns>
        public static bool UpdateClassspec(ClassspecInfo classspecInfo) {
            return DatabaseProvider.GetInstance().UpdateClassspec(classspecInfo);
        }

        /// <summary>
        /// 删除资产属性模板
        /// </summary>
        /// <param name="idList">资产属性模板对象</param>
        /// <returns></returns>
        public static int DeleteClassspec(string idList) {
            return DatabaseProvider.GetInstance().DeleteClassspec(idList);
        }

        /// <summary>
        /// 查找资产属性模板
        /// </summary>
        /// <param name="condition">资产属性模板对象</param>
        /// <returns></returns>
        public static DataTable FindClassspecByCondition(string condition) {
            return DatabaseProvider.GetInstance().FindClassspecByCondition(condition);
        }
    }
}
