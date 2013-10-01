using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PM.Entity;
using PM.Data;
using PM.Common;

namespace PM.Business
{
    /// <summary>
    /// 换表业务逻辑操作类
    /// </summary>
    public class MeasureReplace
    {
        /// <summary>
        /// 获取换表记录
        /// </summary>
        /// <param name="condition">查找条件</param>
        /// <returns></returns>
        public static DataTable FindMeasureReplaceTableByCondition(string condition) {
            return Data.MeasureReplace.FindMeasureReplaceTableByCondition(condition);
        
        }


        /// <summary>
        /// 添加换表记录
        /// </summary>
        /// <param name="measureReplaceInfo"></param>
        /// <returns></returns>
        public static bool CreateMeasureReplace(MeasureReplaceInfo measureReplaceInfo) {
            return Data.MeasureReplace.CreateMeasureReplace(measureReplaceInfo);
        }

        /// <summary>
        /// 更新换表记录
        /// </summary>
        /// <param name="measureReplaceInfo"></param>
        /// <returns></returns>
        public static bool UpdateMeasureReplace(MeasureReplaceInfo measureReplaceInfo) {
            return Data.MeasureReplace.UpdateMeasureReplace(measureReplaceInfo);
        }

        /// <summary>
        /// 删除换表记录
        /// </summary>
        /// <param name="idList">ID列表</param>
        /// <returns></returns>
        public static int DeleteMeasureReplace(string idList) {
            return Data.MeasureReplace.DeleteMeasureReplace(idList);
        }

        /// <summary>
        /// 换表记录条数
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        public static int MeasureReplaceCount(string condition) {
            return Data.MeasureReplace.MeasureReplaceCount(condition);
        }


        /// <summary>
        /// 获取指定ID的换表记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static MeasureReplaceInfo GetMeasureReplaceInfo(long id) {
            return Data.MeasureReplace.GetMeasureReplaceInfo(id);
        }
    }
}
