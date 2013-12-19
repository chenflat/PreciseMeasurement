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
    /// 资产类别定义
    /// </summary>
    public class Classification {

        /// <summary>
        /// 创建资产类别定义
        /// </summary>
        /// <param name="classificationInfo">资产类别定义对象</param>
        /// <returns></returns>
        public static int CreateClassification(ClassificationInfo classificationInfo) {
            return DatabaseProvider.GetInstance().CreateClassification(classificationInfo);
        }

        /// <summary>
        /// 更新资产类别定义
        /// </summary>
        /// <param name="classificationInfo">资产类别定义对象</param>
        /// <returns></returns>
        public static bool UpdateClassification(ClassificationInfo classificationInfo) {
            return DatabaseProvider.GetInstance().UpdateClassification(classificationInfo);
        }

        /// <summary>
        /// 删除资产类别定义
        /// </summary>
        /// <param name="idList">资产类别定义对象</param>
        /// <returns></returns>
        public static int DeleteClassification(string idList) {
            return DatabaseProvider.GetInstance().DeleteClassification(idList);
        }

        /// <summary>
        /// 查找资产类别定义
        /// </summary>
        /// <param name="condition">资产类别定义对象</param>
        /// <returns></returns>
        public static DataTable FindClassificationByCondition(string condition) {
            return DatabaseProvider.GetInstance().FindClassificationByCondition(condition);
        }

    }
}
