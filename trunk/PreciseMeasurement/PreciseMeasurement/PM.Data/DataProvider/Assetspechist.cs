using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PM.Data;
using PM.Config;
using PM.Common;
using PM.Entity;


namespace PM.Data {

    public class Assetspechist {

        /// <summary>
        /// 创建资产规范变更历史记录
        /// </summary>
        /// <param name="assetspechistInfo">资产规范变更历史记录对象</param>
        /// <returns></returns>
        public static int CreateAssetspechist(AssetspechistInfo assetspechistInfo) {
            return DatabaseProvider.GetInstance().CreateAssetspechist(assetspechistInfo);
        }

        /// <summary>
        /// 更新资产规范变更历史记录
        /// </summary>
        /// <param name="assetspechistInfo">资产规范变更历史记录对象</param>
        /// <returns></returns>
        public static bool UpdateAssetspechist(AssetspechistInfo assetspechistInfo) {
            return DatabaseProvider.GetInstance().UpdateAssetspechist(assetspechistInfo);
        }

        /// <summary>
        /// 删除资产规范变更历史记录
        /// </summary>
        /// <param name="idList">数据ID</param>
        /// <returns></returns>
        public static int DeleteAssetspechist(string idList) {
            return DatabaseProvider.GetInstance().DeleteAssetspechist(idList);
        }

        /// <summary>
        /// 查找资产规范变更历史记录
        /// </summary>
        /// <param name="condition">查询条件SQL,以 and 开头</param>
        /// <returns></returns>
        public static DataTable FindAssetspechistByCondition(string condition) {
            return DatabaseProvider.GetInstance().FindAssetspechistByCondition(condition);
        }

    }
}
