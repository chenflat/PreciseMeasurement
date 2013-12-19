using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PM.Data;
using PM.Config;
using PM.Common;
using PM.Entity;

namespace PM.Data {
    public class Assetattribute {

        /// <summary>
        /// 创建资产属性信息
        /// </summary>
        /// <param name="assetattributeInfo">资产属性对象</param>
        /// <returns></returns>
        public static int CreateAssetattribute(AssetattributeInfo assetattributeInfo) {
            return DatabaseProvider.GetInstance().CreateAssetattribute(assetattributeInfo);
        }

        /// <summary>
        /// 更新资产属性信息
        /// </summary>
        /// <param name="assetattributeInfo">资产属性对象</param>
        /// <returns></returns>
        public static bool UpdateAssetattribute(AssetattributeInfo assetattributeInfo) {
            return DatabaseProvider.GetInstance().UpdateAssetattribute(assetattributeInfo);
        }

        /// <summary>
        /// 删除指定的资产属性信息
        /// </summary>
        /// <param name="idList">属性数据ID列表</param>
        /// <returns></returns>
        public static int DeleteAssetattribute(string idList) {
            return DatabaseProvider.GetInstance().DeleteAssetattribute(idList);
        }

        /// <summary>
        /// 查找指定属性ID的信息
        /// </summary>
        /// <param name="assetattrid">资产属性ID</param>
        /// <returns></returns>
        public static IDataReader FindAssetattributeByAssetattrid(String assetattrid) {
            return DatabaseProvider.GetInstance().FindAssetattributeByAssetattrid(assetattrid);
        }

        /// <summary>
        /// 查找指定条件的资产属性信息
        /// </summary>
        /// <param name="condition">查询条件SQL，以 and 开始</param>
        /// <returns></returns>
        public static DataTable FindAssetattributeByCondition(string condition) {
            return DatabaseProvider.GetInstance().FindAssetmeterByCondition(condition);
        }

        /// <summary>
        /// 获取查询条件的结果条数
        /// </summary>
        /// <param name="condition">查询条件SQL，以 and 开始</param>
        /// <returns></returns>
        public static int AssetattributeCount(string condition) {
            return DatabaseProvider.GetInstance().AssetattributeCount(condition);
        }

    }
}
