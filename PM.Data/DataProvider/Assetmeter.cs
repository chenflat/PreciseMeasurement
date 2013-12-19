using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PM.Data;
using PM.Config;
using PM.Common;
using PM.Entity;

namespace PM.Data {

    public class Assetmeter {

        /// <summary>
        /// 创建资产计量器
        /// </summary>
        /// <param name="assetmeterInfo">资产计量器对象</param>
        /// <returns></returns>
        public static int CreateAssetmeter(AssetmeterInfo assetmeterInfo) {
            return DatabaseProvider.GetInstance().CreateAssetmeter(assetmeterInfo);
        }

        /// <summary>
        /// 更新资产计量器
        /// </summary>
        /// <param name="assetmeterInfo">资产计量器对象</param>
        /// <returns></returns>
        public static bool UpdateAssetmeter(AssetmeterInfo assetmeterInfo) {
            return DatabaseProvider.GetInstance().UpdateAssetmeter(assetmeterInfo);
        }

        /// <summary>
        /// 删除资产计量器
        /// </summary>
        /// <param name="idList">计量器ID列表</param>
        /// <returns></returns>
        public static int DeleteAssetmeter(string idList) {
            return DatabaseProvider.GetInstance().DeleteAssetmeter(idList);
        }

        /// <summary>
        /// 查找资产对应的计量器
        /// </summary>
        /// <param name="assetnum">资产编号</param>
        /// <returns></returns>
        public static DataTable FindAssetmeterByAssetnum(string assetnum) {
            return DatabaseProvider.GetInstance().FindAssetmeterByAssetnum(assetnum);
        }

        /// <summary>
        /// 查找资产计量器
        /// </summary>
        /// <param name="condition">查询SQL</param>
        /// <returns></returns>
        public static DataTable FindAssetmeterByCondition(string condition) {
            return DatabaseProvider.GetInstance().FindAssetmeterByCondition(condition);
        }
    }
}
