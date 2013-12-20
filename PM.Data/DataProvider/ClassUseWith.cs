using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PM.Data;
using PM.Config;
using PM.Common;
using PM.Entity;

namespace PM.Data {
    public class ClassUseWith {

        /// <summary>
        /// 创建分类结构使用的对象
        /// </summary>
        /// <param name="classUseWithInfo">分类结构使用的对象</param>
        /// <returns></returns>
        public static int CreateClassUseWith(ClassUseWithInfo classUseWithInfo) {
            return DatabaseProvider.GetInstance().CreateClassUseWith(classUseWithInfo);
        }

        /// <summary>
        /// 更新分类结构使用的对象
        /// </summary>
        /// <param name="classUseWithInfo">分类结构使用的对象</param>
        /// <returns></returns>
        public static bool UpdateClassUseWith(ClassUseWithInfo classUseWithInfo) {
            return DatabaseProvider.GetInstance().UpdateClassUseWith(classUseWithInfo);
        }

        /// <summary>
        /// 删除分类结构使用的对象
        /// </summary>
        /// <param name="idList">主键ID，多个ID以","分隔</param>
        /// <returns></returns>
        public static int DeleteClassUseWith(string idList) {
            return DatabaseProvider.GetInstance().DeleteClassUseWith(idList);
        }

        /// <summary>
        /// 查找分类结构使用的对象
        /// </summary>
        /// <param name="condition">查询条件SQL,以 and 开头</param>
        /// <returns></returns>
        public static DataTable FindClassUseWithByCondition(string condition) {
            return DatabaseProvider.GetInstance().FindClassUseWithByCondition(condition);
        }

        /// <summary>
        /// 查找分类结构使用的对象
        /// </summary>
        /// <param name="classstructureid">分类结构ID</param>
        /// <returns></returns>
        public static DataTable FindClassUseWithByClassstructureid(string classstructureid) {
            return FindClassUseWithByCondition(" and [CLASSSTRUCTUREID]='" + classstructureid + "'");
        }


    }
}
