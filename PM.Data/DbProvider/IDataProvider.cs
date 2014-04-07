using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PM.Entity;

namespace PM.Data {
    public partial interface IDataProvider {
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
        /// 获取指定的组织机构及子机构
        /// </summary>
        /// <param name="orgid">组织机构ID</param>
        /// <returns></returns>
        IDataReader FindOrganizationAndChildrenByOrgId(String orgid);


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
        /// 查找指定条件的位置信息
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        DataTable FindLocationsByCondition(string condition);

        /// <summary>
        /// 查找指定条件的位置信息
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        IDataReader FindLocationsListByCondition(string condition);

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
        bool CreateLocation(LocationInfo locationInfo);

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
        /// 获取计量点条数
        /// </summary>
        /// <returns></returns>
        int LocationsCount(string condition);




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
        /// 获取层级
        /// </summary>
        /// <param name="orgid">组织机构ID</param>
        /// <param name="siteid">地点ID</param>
        /// <returns></returns>
        IDataReader GetLevels(string orgid, string siteid);


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
        /// 获取计量点和位置信息
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        IDataReader FindMeasurePointAndLocation();

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
        /// 更新计量点坐标位置信息
        /// </summary>
        /// <param name="measurePointInfo">计量点信息</param>
        /// <returns></returns>
        int UpdateMeasurePointCoordinates(MeasurePointInfo measurePointInfo);

        /// <summary>
        /// 更新记量点最后更新日期
        /// </summary>
        /// <param name="pointnum">计量点</param>
        /// <param name="lastsyntime">最后更新时间</param>
        /// <returns></returns>
        bool UpdateMeasurePointLastSynTime(string pointnum, DateTime lastsyntime);


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
        /// 获取指定层级的计量器列表
        /// </summary>
        /// <param name="carrier">携能载体</param>
        /// <param name="level">层级ID</param>
        /// <param name="orgid">组织机构ID</param>
        /// <param name="siteid">地点ID</param>
        /// <returns></returns>
        IDataReader FindMeasurePointsByLevel(string carrier,int level, string orgid, string siteid);

        /// <summary>
        /// 添加计量点参数信息
        /// </summary>
        /// <param name="paramInfo">参数信息</param>
        /// <returns></returns>
        bool CreateMeasurePointParam(MeasurePointParamInfo paramInfo);

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
        bool CreateMeasureReplace(MeasureReplaceInfo measureReplaceInfo);

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


        /// <summary>
        /// 获取指定条件的用户信息
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        DataTable FindUserTableByCondition(string condition);

        /// <summary>
        /// 用户数
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        int UsersCount(string condition);

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
        IDataReader GetUserInfo(int userId);


        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        IDataReader GetUserInfoToReader(string userName);



        /// <summary>
        /// 创建新用户.
        /// </summary>
        /// <param name="userinfo">用户信息</param>
        /// <returns>返回用户ID, 如果已存在该用户名则返回-1</returns>
        bool CreateUser(UserInfo userinfo);

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="userinfo">用户信息</param>
        /// <returns>是否更新成功</returns>
        bool UpdateUser(UserInfo userinfo);

        /// <summary>
        /// 更新用户密码
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="password"></param>
        /// <param name="passwordmodifieddate"></param>
        /// <returns></returns>
        bool UpdatePassword(int userid, string password, DateTime passwordmodifieddate);

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="uidList">用户Id列表</param>
        int DeleteUserByUidlist(string uidList);


        /// <summary>
        /// 创建用户组
        /// </summary>
        /// <param name="groupInfo"></param>
        /// <returns></returns>
        bool CreateUserGroup(GroupInfo groupInfo);

        /// <summary>
        /// 更新用户组
        /// </summary>
        /// <param name="groupInfo"></param>
        /// <returns></returns>
        bool UpdateUserGroup(GroupInfo groupInfo);

        /// <summary>
        /// 删除用户组
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        int DeleteUserGroupByIdList(string idList);

        /// <summary>
        /// 查找指定的用户
        /// </summary>
        /// <param name="groupid"></param>
        /// <returns></returns>
        IDataReader FindUserGroupById(int groupid);

        /// <summary>
        /// 查找用户组信息
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        DataTable FindUserGroupByCondition(string condition);



        /// <summary>
        /// 获取指定计量器的最后记录值
        /// </summary>
        /// <param name="pointnum">记录器编号</param>
        /// <returns></returns>
        IDataReader FindLastMeasurement(string pointnum);

        /// <summary>
        /// 获取所有测点的最后计量值
        /// </summary>
        /// <param name="carrier">载体,汽、水、全部</param>
        /// <returns></returns>
        IDataReader GetLastMeasureValueByAllPoint(string carrier);

        IDataReader GetLastMeasureValueByAllPoint();


        /// <summary>
        /// 获取指定计量器的第一条记录值
        /// </summary>
        /// <param name="pointnum">记录器编号</param>
        /// <returns></returns>
        IDataReader FindFirstMeasurement(string pointnum);

        /// <summary>
        /// 获取指定查询条件的读表数据
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="pageindex">当前页</param>
        /// <param name="pagesize">每页显示数</param>
        /// <param name="recordcount">总条数</param>
        /// <returns></returns>
        DataTable FindMeasurementByCondition(string condition, string type, int pageindex, int pagesize, out int recordcount);

        /// <summary>
        /// 获取指定测点的读表数据
        /// </summary>
        /// <param name="pointnum">测点编号</param>
        /// <param name="startdate">开始时间</param>
        /// <param name="enddate">结束时间</param>
        /// <param name="type">查询类型</param>
        /// <param name="pageindex">当前页</param>
        /// <param name="pagesize">每页显示数</param>
        /// <param name="recordcount">总条数</param>
        /// <returns></returns>
        DataSet FindMeasurementByPointnum(string pointnum, string startdate, string enddate, string type, int pageindex, int pagesize);

        /// <summary>
        /// 获取指定时间内所有计量器的读表数据
        /// </summary>
        /// <param name="pointnum">测点编号</param>
        /// <param name="startdate">开始时间</param>
        /// <param name="enddate">结束时间</param>
        /// <param name="type">查询方式： ALL全部 DAY日报 WEEK周报 MONTH月报 </param>
        /// <param name="pageindex">当前页</param>
        /// <param name="pagesize">每页显示数</param>
        /// <returns></returns>
        DataSet FindMeasurementByAllPoint(string startdate, string enddate, string level, string type,string orgid, int pageindex, int pagesize);

        /// <summary>
        /// 获取指定时间内的的测量数据
        /// </summary>
        /// <param name="startdate">开始时间</param>
        /// <param name="enddate">结束时间</param>
        /// <returns></returns>
        IDataReader FindMeasurementByDate(string startdate, string enddate, string pointNum, ReportType reportType);

        /// <summary>
        /// 获取指定测点的最后计量时间
        /// </summary>
        /// <param name="pointnum">计量点编号</param>
        /// <param name="reportType">查询方式</param>
        /// <returns></returns>
        IDataReader GetLastMeasurtimeByPointNum(string pointnum, ReportType reportType);

        /// <summary>
        /// 获取指定时间内的的测量数据
        /// </summary>
        /// <param name="pointnum">测点编号</param>
        /// <param name="startdate">开始时间</param>
        /// <param name="enddate">结束时间</param>
        /// <param name="reportType">查询方式</param>
        /// <returns></returns>
        IDataReader FindMeasurementHistoryData(string pointnum, string startdate, string enddate, ReportType reportType);

        /// <summary>
        /// 获取指定时间内的测量数据报告
        /// </summary>
        /// <param name="startdate">开始时间</param>
        /// <param name="enddate">结束时间</param>
        /// <param name="level">等级</param>
        /// <param name="reportType">查询方式</param>
        /// <returns></returns>
        DataTable GetMeasurementReport(string startdate, string enddate, string level,string orgid, ReportType reportType);


        /// <summary>
        /// 获取指定时间内的测量数据自定义报告
        /// </summary>
        /// <param name="pointnum">自定义测点,多测点用半角逗号隔开,如S1,S2,S3</param>
        /// <param name="startdate">开始时间</param>
        /// <param name="enddate">结束时间</param>
        /// <param name="reportType">查询方式</param>
        /// <param name="formula">计算公式</param>
        /// <returns></returns>
        DataTable GetMeasurementCustomReport(string pointnum, string startdate, string enddate, ReportType reportType, string formula);




        /// <summary>
        /// 创建测量小时数据
        /// </summary>
        /// <param name="statInfo"></param>
        /// <returns></returns>
        bool CreateMeasurementHourData(MeasurementStatInfo statInfo);

        /// <summary>
        /// 创建测量每日数据
        /// </summary>
        /// <param name="statInfo"></param>
        /// <returns></returns>
        bool CreateMeasurementDayData(MeasurementStatInfo statInfo);

        /// <summary>
        /// 创建测量每月数据
        /// </summary>
        /// <param name="statInfo"></param>
        /// <returns></returns>
        bool CreateMeasurementMonthData(MeasurementStatInfo statInfo);


        /// <summary>
        /// 创建分析设置信息
        /// </summary>
        /// <param name="analyzeSettingInfo"></param>
        /// <returns></returns>
        bool CreateAnalyzeSettingInfo(AnalyzeSettingInfo analyzeSettingInfo);

        /// <summary>
        /// 更新分析设置信息
        /// </summary>
        /// <param name="analyzeSettingInfo"></param>
        /// <returns></returns>
        bool UpdateAnalyzeSettingInfo(AnalyzeSettingInfo analyzeSettingInfo);

        /// <summary>
        /// 删除分析设置信息
        /// </summary>
        /// <param name="analyzeSettingInfo"></param>
        /// <returns></returns>
        bool DeleteAnalyzeSettingInfoBySettingName(SettingType type, string settingname, int userid, string orgid);

        /// <summary>
        /// 删除用户设置
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="orgid">组织机构ID</param>
        /// <returns></returns>
        bool DeleteAnalyzeSettingInfoByUser(int userid, string orgid,string tablename);

        /// <summary>
        /// 查找分析设置信息
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="orgid">组织机构ID</param>
        /// <returns>分析设置信息</returns>
        IDataReader FindAnalyzeSettingInfo(int userid, string orgid,string tablename);

        /// <summary>
        /// 查找报警信息
        /// </summary>
        /// <param name="orgid">机构ID</param>
        /// <returns></returns>
        DataSet FindAlarmlogInfo(string startdate, string enddate, string pointnum, int status, string orgid, int pageindex, int pagesize);

        /// <summary>
        /// 创建报表设置
        /// </summary>
        /// <param name="reportSettingInfo"></param>
        /// <returns></returns>
        bool CreateReportSetting(ReportSettingInfo reportSettingInfo);

        /// <summary>
        /// 删除指定用户的报表设置
        /// </summary>
        /// <param name="settingname">设置名称</param>
        /// <param name="userid">用户ID</param>
        /// <param name="orgid">组织机构ID</param>
        /// <returns></returns>
        bool DeleteReportSettingByUserId(string settingname, int userid, string orgid);

        /// <summary>
        /// 删除指定用户的报表设置
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="orgid">组织机构ID</param>
        /// <returns></returns>
        bool DeleteReportSettingByUserId(int userid, string orgid);

        /// <summary>
        /// 获取指定用户的报表设置
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="orgid">组织机构ID</param>
        /// <returns></returns>
        IDataReader FindReportSettingByUserId(int userid, string orgid);

        /// <summary>
        /// 获取指定用户的报表设置
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="orgid">组织机构ID</param>
        /// <returns></returns>
        IDataReader FindReportSettingByUserId(string settingname, int userid, string orgid);

        /// <summary>
        /// 获取指定用户报表设置名称列表
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="orgid">组织机构ID</param>
        /// <returns></returns>
        IDataReader GetReportSettingNameList(int userid, string orgid);

        /// <summary>
        /// 创建资产信息
        /// </summary>
        /// <param name="assetInfo">资产信息</param>
        /// <returns></returns>
        int CreateAsset(AssetInfo assetInfo);

        /// <summary>
        /// 更新资产信息
        /// </summary>
        /// <param name="assetInfo"></param>
        /// <returns></returns>
        bool UpdateAsset(AssetInfo assetInfo);

        /// <summary>
        /// 更新资产坐标
        /// </summary>
        /// <param name="assetuid"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        int UpdateAssetCoordinates(long assetuid, string x, string y, string z);

        /// <summary>
        /// 删除指定的资产信息
        /// </summary>
        /// <param name="idList">资产数据主键ID列表</param>
        /// <returns></returns>
        int DeleteAsset(string idList);

        /// <summary>
        /// 查找指定条件的资产信息
        /// </summary>
        /// <param name="condition">查询条件SQL</param>
        /// <returns></returns>
        DataTable FindAssetByCondition(string condition);

        /// <summary>
        /// 返回指定查询条件的资产信息条数
        /// </summary>
        /// <param name="condition">查询条件SQL</param>
        /// <returns></returns>
        int AssetCount(string condition);


        /// <summary>
        /// 创建资产属性信息
        /// </summary>
        /// <param name="assetattributeInfo">资产属性对象</param>
        /// <returns></returns>
        int CreateAssetattribute(AssetattributeInfo assetattributeInfo);

        /// <summary>
        /// 更新资产属性信息
        /// </summary>
        /// <param name="assetattributeInfo">资产属性对象</param>
        /// <returns></returns>
        bool UpdateAssetattribute(AssetattributeInfo assetattributeInfo);

        /// <summary>
        /// 删除指定的资产属性信息
        /// </summary>
        /// <param name="idList">属性数据ID列表</param>
        /// <returns></returns>
        int DeleteAssetattribute(string idList);

        /// <summary>
        /// 查找指定属性ID的信息
        /// </summary>
        /// <param name="assetattrid">资产属性ID</param>
        /// <returns></returns>
        IDataReader FindAssetattributeByAssetattrid(String assetattrid);

        /// <summary>
        /// 查找指定条件的资产属性信息
        /// </summary>
        /// <param name="condition">查询条件SQL，以 and 开始</param>
        /// <returns></returns>
        DataTable FindAssetattributeByCondition(string condition);

        /// <summary>
        /// 获取查询条件的结果条数
        /// </summary>
        /// <param name="condition">查询条件SQL，以 and 开始</param>
        /// <returns></returns>
        int AssetattributeCount(string condition);

        /// <summary>
        /// 创建资产计量器
        /// </summary>
        /// <param name="assetmeterInfo">资产计量器对象</param>
        /// <returns></returns>
        int CreateAssetmeter(AssetmeterInfo assetmeterInfo);

        /// <summary>
        /// 更新资产计量器
        /// </summary>
        /// <param name="assetmeterInfo">资产计量器对象</param>
        /// <returns></returns>
        bool UpdateAssetmeter(AssetmeterInfo assetmeterInfo);

        /// <summary>
        /// 删除资产计量器
        /// </summary>
        /// <param name="idList">计量器ID列表</param>
        /// <returns></returns>
        int DeleteAssetmeter(string idList);

        /// <summary>
        /// 查找资产对应的计量器
        /// </summary>
        /// <param name="assetnum">资产编号</param>
        /// <returns></returns>
        DataTable FindAssetmeterByAssetnum(string assetnum);

        /// <summary>
        /// 查找资产计量器
        /// </summary>
        /// <param name="condition">查询SQL</param>
        /// <returns></returns>
        DataTable FindAssetmeterByCondition(string condition);


        /// <summary>
        /// 创建计量器组信息
        /// </summary>
        /// <param name="metergroupInfo">计量器组对象</param>
        /// <returns></returns>
        int CreateMetergroup(MetergroupInfo metergroupInfo);

        /// <summary>
        /// 更新计量器组信息
        /// </summary>
        /// <param name="metergroupInfo">计量器组对象</param>
        /// <returns></returns>
        bool UpdateMetergroup(MetergroupInfo metergroupInfo);

        /// <summary>
        /// 删除计量器组信息
        /// </summary>
        /// <param name="idList">数据ID</param>
        /// <returns></returns>
        int DeleteMetergroup(string idList);

        /// <summary>
        /// 查找计量器组信息
        /// </summary>
        /// <param name="condition">查询条件SQL,以 and 开头</param>
        /// <returns></returns>
        DataTable FindMetergroupByCondition(string condition);


        /// <summary>
        /// 创建计量器组包含的计量器
        /// </summary>
        /// <param name="meteringroupInfo">计量器组包含的计量器对象</param>
        /// <returns></returns>
        int CreateMeteringroup(MeteringroupInfo meteringroupInfo);

        /// <summary>
        /// 更新计量器组包含的计量器
        /// </summary>
        /// <param name="meteringroupInfo">计量器组包含的计量器对象</param>
        /// <returns></returns>
        bool UpdateMeteringroup(MeteringroupInfo meteringroupInfo);

        /// <summary>
        /// 删除计量器组包含的计量器
        /// </summary>
        /// <param name="idList">数据ID</param>
        /// <returns></returns>
        int DeleteMeteringroup(string idList);

        /// <summary>
        /// 查找计量器组包含的计量器
        /// </summary>
        /// <param name="condition">查询SQL,以 and 开头</param>
        /// <returns></returns>
        DataTable FindMeteringroupByCondition(string condition);

        /// <summary>
        /// 查找指定组的计量器
        /// </summary>
        /// <param name="groupName">组编号</param>
        /// <returns></returns>
        DataTable FindMeteringroupByGroup(string groupName);


        /// <summary>
        /// 创建资产规范变更历史记录
        /// </summary>
        /// <param name="assetspechistInfo">资产规范变更历史记录对象</param>
        /// <returns></returns>
        int CreateAssetspechist(AssetspechistInfo assetspechistInfo);

        /// <summary>
        /// 更新资产规范变更历史记录
        /// </summary>
        /// <param name="assetspechistInfo">资产规范变更历史记录对象</param>
        /// <returns></returns>
        bool UpdateAssetspechist(AssetspechistInfo assetspechistInfo);

        /// <summary>
        /// 删除资产规范变更历史记录
        /// </summary>
        /// <param name="idList">数据ID</param>
        /// <returns></returns>
        int DeleteAssetspechist(string idList);

        /// <summary>
        /// 查找资产规范变更历史记录
        /// </summary>
        /// <param name="condition">查询条件SQL,以 and 开头</param>
        /// <returns></returns>
        DataTable FindAssetspechistByCondition(string condition);


        /// <summary>
        /// 创建资产类别定义
        /// </summary>
        /// <param name="classificationInfo">资产类别定义对象</param>
        /// <returns></returns>
        int CreateClassification(ClassificationInfo classificationInfo);

        /// <summary>
        /// 更新资产类别定义
        /// </summary>
        /// <param name="classificationInfo">资产类别定义对象</param>
        /// <returns></returns>
        bool UpdateClassification(ClassificationInfo classificationInfo);

        /// <summary>
        /// 删除资产类别定义
        /// </summary>
        /// <param name="idList">类别主键ID</param>
        /// <returns></returns>
        int DeleteClassification(string idList);

        /// <summary>
        /// 查找资产类别定义
        /// </summary>
        /// <param name="condition">查询条件SQL,以 and 开头</param>
        /// <returns></returns>
        DataTable FindClassificationByCondition(string condition);


        /// <summary>
        /// 创建资产属性模板
        /// </summary>
        /// <param name="classspecInfo">资产属性模板对象</param>
        /// <returns></returns>
        int CreateClassspec(ClassspecInfo classspecInfo);

        /// <summary>
        /// 更新资产属性模板
        /// </summary>
        /// <param name="classspecInfo">资产属性模板对象</param>
        /// <returns></returns>
        bool UpdateClassspec(ClassspecInfo classspecInfo);

        /// <summary>
        /// 删除资产属性模板
        /// </summary>
        /// <param name="idList">属性模板ID</param>
        /// <returns></returns>
        int DeleteClassspec(string idList);

        /// <summary>
        /// 查找资产属性模板
        /// </summary>
        /// <param name="condition">查询条件SQL,以 and 开头</param>
        /// <returns></returns>
        DataTable FindClassspecByCondition(string condition);



        /// <summary>
        /// 创建类别层次结构定义
        /// </summary>
        /// <param name="classstructureInfo">类别层次结构定义对象</param>
        /// <returns></returns>
        int CreateClassstructure(ClassstructureInfo classstructureInfo);

        /// <summary>
        /// 更新类别层次结构定义
        /// </summary>
        /// <param name="classstructureInfo">类别层次结构定义对象</param>
        /// <returns></returns>
        bool UpdateClassstructure(ClassstructureInfo classstructureInfo);

        /// <summary>
        /// 删除类别层次结构定义
        /// </summary>
        /// <param name="idList">结构主键ID，多个ID以","分隔</param>
        /// <returns></returns>
        int DeleteClassstructure(string idList);

        /// <summary>
        /// 查找类别层次结构定义
        /// </summary>
        /// <param name="condition">查询条件SQL,以 and 开头</param>
        /// <returns></returns>
        DataTable FindClassstructureByCondition(string condition);


        /// <summary>
        /// 创建分类结构使用的对象
        /// </summary>
        /// <param name="classUseWithInfo">分类结构使用的对象</param>
        /// <returns></returns>
        int CreateClassUseWith(ClassUseWithInfo classUseWithInfo);

        /// <summary>
        /// 更新分类结构使用的对象
        /// </summary>
        /// <param name="classUseWithInfo">分类结构使用的对象</param>
        /// <returns></returns>
        bool UpdateClassUseWith(ClassUseWithInfo classUseWithInfo);
        /// <summary>
        /// 删除分类结构使用的对象
        /// </summary>
        /// <param name="idList">主键ID，多个ID以","分隔</param>
        /// <returns></returns>
        int DeleteClassUseWith(string idList);
        /// <summary>
        /// 查找分类结构使用的对象
        /// </summary>
        /// <param name="condition">查询条件SQL,以 and 开头</param>
        /// <returns></returns>
        DataTable FindClassUseWithByCondition(string condition);



        /// <summary>
        /// 创建长描述
        /// </summary>
        /// <param name="longdescriptionInfo">长描述对象</param>
        /// <returns></returns>
        int CreateLongdescription(LongdescriptionInfo longdescriptionInfo);

        /// <summary>
        /// 更新长描述，通过主键ID
        /// </summary>
        /// <param name="longdescriptionInfo">长描述对象</param>
        /// <returns></returns>
        bool UpdateLongdescriptionById(LongdescriptionInfo longdescriptionInfo);

        /// <summary>
        /// 更新长描述,通过键值
        /// </summary>
        /// <param name="longdescriptionInfo">长描述对象</param>
        /// <returns></returns>
        bool UpdateLongdescriptionByKey(LongdescriptionInfo longdescriptionInfo);

        /// <summary>
        /// 删除长描述
        /// </summary>
        /// <param name="idList">长描述主键ID，多个ID以","分隔</param>
        /// <returns></returns>
        int DeleteLongdescription(string idList);

        /// <summary>
        /// 查找长描述
        /// </summary>
        /// <param name="condition">查询条件SQL,以 and 开头</param>
        /// <returns></returns>
        DataTable FindLongdescriptionByCondition(string condition);


        /// <summary>
        /// 创建系统系统域定义
        /// </summary>
        /// <param name="pmdomainInfo">系统域定义对象</param>
        /// <returns></returns>
        int CreatePmdomain(PmdomainInfo pmdomainInfo);

        /// <summary>
        /// 更新系统域定义
        /// </summary>
        /// <param name="pmdomainInfo">系统域定义对象</param>
        /// <returns></returns>
        bool UpdatePmdomain(PmdomainInfo pmdomainInfo);

        /// <summary>
        /// 删除系统域定义
        /// </summary>
        /// <param name="idList">系统域定义主键ID，多个ID以","分隔</param>
        /// <returns></returns>
        int DeletePmdomain(string idList);

        /// <summary>
        /// 查找系统域定义
        /// </summary>
        /// <param name="condition"></param>
        /// <returns>查询条件SQL,以 and 开头</returns>
        DataTable FindPmdomainByCondition(string condition);

 

        /// <summary>
        /// 创建同义数值域定义
        /// </summary>
        /// <param name="synonymdomainInfo">同义数值域定义对象</param>
        /// <returns></returns>
        int CreateSynonymdomain(SynonymdomainInfo synonymdomainInfo);

        /// <summary>
        /// 更新同义数值域定义
        /// </summary>
        /// <param name="synonymdomainInfo">同义数值域定义对象</param>
        /// <returns></returns>
        bool UpdateSynonymdomain(SynonymdomainInfo synonymdomainInfo);

        /// <summary>
        /// 删除同义数值域定义
        /// </summary>
        /// <param name="idList">同义数值域定义主键ID</param>
        /// <returns></returns>
        int DeleteSynonymdomain(string idList);

        /// <summary>
        /// 查找同义数值域定义
        /// </summary>
        /// <param name="condition">查询条件SQL,以 and 开头</param>
        /// <returns></returns>
        DataTable FindSynonymdomainByCondition(string condition);

        /// <summary>
        /// 查找同义数值域定义
        /// </summary>
        /// <param name="domainId">域ID</param>
        /// <returns></returns>
        DataTable FindSynonymdomainByDomainId(string domainId);
    }
}
