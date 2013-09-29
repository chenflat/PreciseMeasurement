using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using PM.Data;
using PM.Config;
using PM.Common;
using PM.Entity;

namespace PM.Data
{
    public class MeasureReplace
    {

        /// <summary>
        /// 获取换表记录
        /// </summary>
        /// <param name="condition">查找条件</param>
        /// <returns></returns>
        public static DataTable FindMeasureReplaceTableByCondition(string condition) {
            return DatabaseProvider.GetInstance().FindMeasureReplaceTableByCondition(condition);
        }


        /// <summary>
        /// 获取换表记录信息
        /// </summary>
        /// <param name="id">换表记录ID</param>
        /// <returns></returns>
        public static IDataReader FindMeasureReplaceById(long id) {
            return DatabaseProvider.GetInstance().FindMeasureReplaceById(id);
        }

        /// <summary>
        /// 添加换表记录
        /// </summary>
        /// <param name="measureReplaceInfo"></param>
        /// <returns></returns>
        public static bool CreateMeasureReplace(MeasureReplaceInfo measureReplaceInfo) {
            return DatabaseProvider.GetInstance().CreateMeasureReplace(measureReplaceInfo);
        }

        /// <summary>
        /// 更新换表记录
        /// </summary>
        /// <param name="measureReplaceInfo"></param>
        /// <returns></returns>
        public static bool UpdateMeasureReplace(MeasureReplaceInfo measureReplaceInfo) {
            return DatabaseProvider.GetInstance().UpdateMeasureReplace(measureReplaceInfo);
        }

        /// <summary>
        /// 删除换表记录
        /// </summary>
        /// <param name="idList">ID列表</param>
        /// <returns></returns>
        public static int DeleteMeasureReplace(string idList) {
            return DatabaseProvider.GetInstance().DeleteMeasureReplace(idList);
        }

        /// <summary>
        /// 换表记录条数
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        public static bool MeasureReplaceCount(string condition) {
            return DatabaseProvider.GetInstance().MeasureReplaceCount(condition);
        }
    }
}
