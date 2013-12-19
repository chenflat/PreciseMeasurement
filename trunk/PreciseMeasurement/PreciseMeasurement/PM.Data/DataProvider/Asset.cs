using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PM.Data;
using PM.Config;
using PM.Common;
using PM.Entity;

namespace PM.Data {

    public class Asset {

        /// <summary>
        /// 创建资产信息
        /// </summary>
        /// <param name="assetInfo">资产信息</param>
        /// <returns></returns>
        public static int CreateAsset(AssetInfo assetInfo) {
            return DatabaseProvider.GetInstance().CreateAsset(assetInfo);
        }

        /// <summary>
        /// 更新资产信息
        /// </summary>
        /// <param name="assetInfo"></param>
        /// <returns></returns>
        public static bool UpdateAsset(AssetInfo assetInfo) {
            return DatabaseProvider.GetInstance().UpdateAsset(assetInfo);
        }

        /// <summary>
        /// 删除指定的资产信息
        /// </summary>
        /// <param name="idList">资产数据主键ID列表</param>
        /// <returns></returns>
        public static int DeleteAsset(string idList) {
            return DatabaseProvider.GetInstance().DeleteAsset(idList);
        }

        /// <summary>
        /// 查找指定条件的资产信息
        /// </summary>
        /// <param name="condition">查询条件SQL</param>
        /// <returns></returns>
        public static DataTable FindAssetByCondition(string condition) {
            return DatabaseProvider.GetInstance().FindAssetByCondition(condition);
        }

        /// <summary>
        /// 返回指定查询条件的资产信息条数
        /// </summary>
        /// <param name="condition">查询条件SQL</param>
        /// <returns></returns>
        public static int AssetCount(string condition) {
            return DatabaseProvider.GetInstance().AssetCount(condition);
        }


    }
}
