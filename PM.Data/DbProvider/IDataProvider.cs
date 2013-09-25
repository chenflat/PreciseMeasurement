using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PM.Entity;

namespace PM.Data
{
    public partial interface IDataProvider
    {
        /// <summary>
        /// 获取组织机构
        /// </summary>
        /// <returns></returns>
        IDataReader FindAllOrganizations();

        /// <summary>
        /// 获取组织机构
        /// </summary>
        /// <returns></returns>
        DataTable FindOrganizationsListDataTable();

        /// <summary>
        /// 获取指定主键ID的组织机构
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        IDataReader FindOrganizationsById(long id);

        /// <summary>
        /// 获取指定主键ID的组织机构
        /// </summary>
        /// <param name="orgid">组织机构ID</param>
        /// <returns></returns>
        IDataReader FindOrganizationsByOrgId(String orgid);

        /// <summary>
        /// 新增组织机构信息
        /// </summary>
        /// <param name="orgInfo"></param>
        long AddOrganizations(OrganizationInfo orgInfo);

        /// <summary>
        /// 更新组织机构信息
        /// </summary>
        /// <param name="orgInfo"></param>
        /// <returns></returns>
        long UpdateOrganizations(OrganizationInfo orgInfo);

        /// <summary>
        /// 删除指定的组织机构
        /// </summary>
        /// <param name="organizationid">组织机构ID</param>
        long DeleteOrganizations(long organizationid);


        /// <summary>
        ///  获取位置
        /// </summary>
        /// <returns></returns>
        IDataReader FindLocationsList();

        /// <summary>
        /// 获取位置
        /// </summary>
        /// <param name="orgid">组织机构代码</param>
        /// <returns></returns>
        IDataReader FindLocationsByOrgId(string orgid);

        /// <summary>
        /// 获取位置
        /// </summary>
        /// <param name="id">位置ID</param>
        /// <returns></returns>
        IDataReader FindLocationById(long id);

        /// <summary>
        /// 获取指定类型的位置
        /// </summary>
        /// <param name="orgid">组织机构代码</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        IDataReader FindLocationsByOrgIdAndType(string orgid, string type);

        /// <summary>
        /// 新增位置信息
        /// </summary>
        /// <param name="locationInfo">位置信息</param>
        /// <returns>返回位置ID, 如果已存在该位置则返回-1</returns>
        int CreateLocation(LocationInfo locationInfo);

        /// <summary>
        /// 更新位置信息
        /// </summary>
        /// <param name="locationInfo">位置信息</param>
        /// <returns></returns>
        bool UpdateLocation(LocationInfo locationInfo);

        /// <summary>
        /// 删除位置信息
        /// </summary>
        /// <param name="idList">位置ID列表</param>
        /// <returns></returns>
        int DeleteLocation(string idList);

        /// <summary>
        /// 获取位置层级关系
        /// </summary>
        /// <returns></returns>
        IDataReader FindAllLochierarchy();

        /// <summary>
        /// 获取指定位置的层级信息
        /// </summary>
        /// <param name="location">位置编码</param>
        /// <returns></returns>
        IDataReader FindLochierarchyByLocation(string location);



        /// <summary>
        /// 获取所有计量单位数据
        /// </summary>
        /// <returns></returns>
        IDataReader FindAllMeasureUnits();

        DataTable FindAllMeasureUnitListDataTable();

        /// <summary>
        /// 获取指定单位的计量单位信息
        /// </summary>
        /// <param name="abbreviation">计量单位缩写</param>
        /// <returns></returns>
        IDataReader FindMeasureUnitByAbbreviation(String abbreviation);

        /// <summary>
        /// 获取指定名称的计量单位
        /// </summary>
        /// <param name="description">计量单位名称</param>
        /// <returns></returns>
        IDataReader FindMeasureUnitByDescription(String description);

        /// <summary>
        /// 获取指定ID的计量单位信息
        /// </summary>
        /// <param name="id">计量单位对象唯一标识</param>
        /// <returns></returns>
        IDataReader FindMeasureUnitById(long id);

        /// <summary>
        /// 创建计量单位信息
        /// </summary>
        /// <param name="measureunitInfo">计量单位对象</param>
        /// <returns></returns>
        long CreateMeasureUnit(MeasureUnitInfo measureunitInfo);

        /// <summary>
        /// 更新计量单位信息
        /// </summary>
        /// <param name="measureunitInfo">计量单位对象</param>
        /// <returns></returns>
        long UpdateMeasureUnit(MeasureUnitInfo measureunitInfo);

        /// <summary>
        /// 删除计量单位信息
        /// </summary>
        /// <param name="id">计量单位对象唯一标识</param>
        /// <returns></returns>
        int DeleteMeasureUnit(long id);


        /// <summary>
        /// 查找所有计量点列表
        /// </summary>
        /// <returns>计量点列表</returns>
        DataTable FindMeasurePointByCondition(string condition);

        /// <summary>
        /// 获取指定的计量点
        /// </summary>
        /// <param name="id">计量点主键ID</param>
        /// <returns></returns>
        IDataReader FindMeasurePointById(long id);


        /// <summary>
        /// 获取指定位置的计量点列表
        /// </summary>
        /// <param name="location">位置编码</param>
        /// <returns></returns>
        DataTable FindMeasurePointTableByLocation(string location);


        /// <summary>
        /// 添加计量点信息
        /// </summary>
        /// <param name="measurePointInfo">计量点信息</param>
        /// <returns></returns>
        int CreateMeasurePoint(MeasurePointInfo measurePointInfo);

        /// <summary>
        /// 更新计量点信息
        /// </summary>
        /// <param name="measurePointInfo">计量点信息</param>
        /// <returns></returns>
        bool UpdateMeasurePoint(MeasurePointInfo measurePointInfo);

        /// <summary>
        /// 删除计量点信息
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        int DeleteMeasurePoint(string idList);

        /// <summary>
        /// 获取计量点条数
        /// </summary>
        /// <returns></returns>
        int MeasurePointCount(string condition);

        /// <summary>
        /// 获取指定计量点的参数信息
        /// </summary>
        /// <param name="pointnum">计量点编号</param>
        /// <returns></returns>
        DataTable FindMeasurePointParamByPointNum(string pointnum);

        /// <summary>
        /// 获取指定ID的参数信息
        /// </summary>
        /// <param name="id">参数ID</param>
        /// <returns></returns>
        IDataReader FindMeasurePointParamById(int id);

        /// <summary>
        /// 添加计量点参数信息
        /// </summary>
        /// <param name="paramInfo">参数信息</param>
        /// <returns></returns>
        int CreateMeasurePointParam(MeasurePointParamInfo paramInfo);

        /// <summary>
        /// 更新计量点参数信息
        /// </summary>
        /// <param name="paramInfo">参数信息</param>
        /// <returns></returns>
        bool UpdateMeasurePointParam(MeasurePointParamInfo paramInfo);

        /// <summary>
        /// 删除计量点参数信息
        /// </summary>
        /// <param name="idList">参数ID列表</param>
        /// <returns></returns>
        int DeleteMeasurePointParam(string idList);


        /// <summary>
        /// 获取换表记录
        /// </summary>
        /// <param name="condition">查找条件</param>
        /// <returns></returns>
        DataTable FindMeasureReplaceTableByCondition(string condition);


        /// <summary>
        /// 获取换表记录信息
        /// </summary>
        /// <param name="id">换表记录ID</param>
        /// <returns></returns>
        IDataReader FindMeasureReplaceById(long id);

        /// <summary>
        /// 添加换表记录
        /// </summary>
        /// <param name="measureReplaceInfo"></param>
        /// <returns></returns>
        int CreateMeasureReplace(MeasureReplaceInfo measureReplaceInfo);

        /// <summary>
        /// 更新换表记录
        /// </summary>
        /// <param name="measureReplaceInfo"></param>
        /// <returns></returns>
        bool UpdateMeasureReplace(MeasureReplaceInfo measureReplaceInfo);

        /// <summary>
        /// 删除换表记录
        /// </summary>
        /// <param name="idList">ID列表</param>
        /// <returns></returns>
        int DeleteMeasureReplace(string idList);

        /// <summary>
        /// 换表记录条数
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        int MeasureReplaceCount(string condition);


        DataTable FindUserTable();

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        DataTable GetUserInfo(string userName, string passWord);

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        DataTable GetUserInfo(int userId);


        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        IDataReader GetUserInfoToReader(string userName);

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="column"></param>
        /// <param name="orderType"></param>
        /// <returns></returns>
        DataTable GetUserList(int pageSize, int pageIndex, string column, string orderType);
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="currentPage"></param>
        /// <returns></returns>
        DataTable GetUserList(int pageSize, int currentPage);

        /// <summary>
        /// 创建新用户.
        /// </summary>
        /// <param name="userinfo">用户信息</param>
        /// <returns>返回用户ID, 如果已存在该用户名则返回-1</returns>
        long CreateUser(UserInfo userinfo);

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="userinfo">用户信息</param>
        /// <returns>是否更新成功</returns>
        bool UpdateUser(UserInfo userInfo);


        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="uidList">用户Id列表</param>
        void DeleteUserByUidlist(string uidList);
    }
}
