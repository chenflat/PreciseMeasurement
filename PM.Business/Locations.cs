using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PM.Entity;
using PM.Data;
using PM.Common;
using PM.Config;

namespace PM.Business
{
    /// <summary>
    /// 位置业务逻辑操作类
    /// </summary>
    public class Locations
    {
        private static List<LocationInfo> treeList = null;
        /// <summary>
        /// 获取指定条件的位置数据
        /// </summary>
        /// <param name="condition">查询条件（不需要Where关键字）</param>
        /// <returns></returns>
        public static DataTable FindLocationsByCondition(string condition) {
            return Data.Locations.FindLocationsByCondition(condition);
        }


        public static List<LocationInfo> GetLocationsTreeList(string prefix)
        {
            treeList = new List<LocationInfo>();
            List<LocationInfo> listAll = GetLocationsList();
            foreach (LocationInfo item in listAll)
            {
                 if (item.Parent.Equals("")) {
                        treeList.Add(item);
                        CreateLocationTree(listAll, item.Location, prefix);
                    }
            }
            return treeList;

        }

        /// <summary>
        /// 创建机构树节点
        /// </summary>
        /// <param name="list"></param>
        /// <param name="orgid"></param>
        /// <param name="prefix"></param>
        public static void CreateLocationTree(List<LocationInfo> list, string location, string prefix)
        {
            foreach (LocationInfo locationInfo in list)
            {
                if (locationInfo.Parent.Equals(location))
                {
                    locationInfo.Description = prefix + locationInfo.Description;
                    treeList.Add(locationInfo);
                    CreateLocationTree(list, locationInfo.Location, prefix + prefix);
                }

            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<LocationInfo> GetLocationsList()
        {
            List<LocationInfo> listAll = new List<LocationInfo>();
            using (IDataReader reader = PM.Data.Locations.FindLocationsListByCondition(""))
            {
                while (reader.Read())
                {
                    LocationInfo orginfo = PM.Data.Locations.LoadlocationInfo(reader);
                    listAll.Add(orginfo);
                }
                reader.Close();
            }
            return listAll;
        }


        /// <summary>
        /// 移除机构权变量
        /// </summary>
        public static void RemoveTreeList()
        {
            treeList = null;
        }

        /// <summary>
        /// 获取指定组织的位置数据
        /// </summary>
        /// <param name="orgid">组织机构</param>
        /// <returns></returns>
        public static IDataReader FindLocationsByOrgId(string orgid) {
            return Data.Locations.FindLocationsByOrgId(orgid);
        }

        /// <summary>
        /// 获取指定组织和类型的位置数据
        /// </summary>
        /// <param name="orgid">组织机构</param>
        /// <param name="type">位置类型</param>
        /// <returns></returns>
        public static IDataReader FindLocationsByOrgIdAndType(string orgid, string type) {
            return Data.Locations.FindLocationsByOrgIdAndType(orgid, type);
        }

        /// <summary>
        /// 创建位置
        /// </summary>
        /// <param name="locationInfo">位置信息</param>
        /// <returns>返回ture||false</returns>
        public static bool CreateLocation(LocationInfo locationInfo) {
            bool children = false;
            //string condition = string.Format(" and [{0}LOCATIONS]='{1}'", BaseConfigs.GetTablePrefix, locationInfo.Location);
            locationInfo.Children = children;
            
            bool ret = Data.Locations.CreateLocation(locationInfo);
            if (ret) RemoveTreeList();
            return ret;
        }

        /// <summary>
        /// 更新位置信息
        /// </summary>
        /// <param name="locationInfo">位置信息</param>
        /// <returns>返回ture||false</returns>
        public static bool UpdateLocation(LocationInfo locationInfo)
        {
            bool ret = Data.Locations.UpdateLocation(locationInfo);
            if (ret) RemoveTreeList();
            return ret;
        }

        /// <summary>
        /// 删除位置信息
        /// </summary>
        /// <param name="idList">位置ID或ID列表</param>
        /// <returns>返回删除影响的行数</returns>
        public static int DeleteLocation(string idList)
        {
            return Data.Locations.DeleteLocation(idList);
        }

        public static LocationInfo GetLocationInfo(long locationsid) {
            return Data.Locations.GetLocationInfo(locationsid);
        }

        /// <summary>
        /// 判断是否存在相同位置编码的数据
        /// </summary>
        /// <param name="location">位置编码</param>
        /// <returns></returns>
        public static bool ExistLocation(string location) {
            if (location.Length <= 0)
                return false;
            string condition = string.Format(" and [{0}LOCATIONS].location='{1}'",BaseConfigs.GetTablePrefix,location);
            return Data.Locations.LocationsCount(condition) > 0;
        }
    }
}
