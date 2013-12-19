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
    /// 类别层次结构定义
    /// </summary>
    public class Classstructure {

        /// <summary>
        /// 创建类别层次结构定义
        /// </summary>
        /// <param name="classstructureInfo">类别层次结构定义对象</param>
        /// <returns></returns>
        public static int CreateClassstructure(ClassstructureInfo classstructureInfo) { 
           return DatabaseProvider.GetInstance().CreateClassstructure(classstructureInfo);
        }

        /// <summary>
        /// 更新类别层次结构定义
        /// </summary>
        /// <param name="classstructureInfo">类别层次结构定义对象</param>
        /// <returns></returns>
        public static bool UpdateClassstructure(ClassstructureInfo classstructureInfo) {
            return DatabaseProvider.GetInstance().UpdateClassstructure(classstructureInfo);
        }

        /// <summary>
        /// 删除类别层次结构定义
        /// </summary>
        /// <param name="idList">结构主键ID，多个ID以","分隔</param>
        /// <returns></returns>
        public static int DeleteClassstructure(string idList) {
            return DatabaseProvider.GetInstance().DeleteClassstructure(idList);
        }

        /// <summary>
        /// 查找类别层次结构定义
        /// </summary>
        /// <param name="condition">查询条件SQL,以 and 开头</param>
        /// <returns></returns>
        public static DataTable FindClassstructureByCondition(string condition) {
            return DatabaseProvider.GetInstance().FindClassstructureByCondition(condition);
        }
    }
}
