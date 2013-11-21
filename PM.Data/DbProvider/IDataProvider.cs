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
        IDataReader GetLevels(string orgid,string siteid);


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
        /// 更新记量点最后更新日期
        /// </summary>
        /// <param name="pointnum">计量点</param>
        /// <param name="lastsyntime">最后更新时间</param>
        /// <returns></returns>
        bool UpdateMeasurePointLastSynTime(string pointnum,DateTime lastsyntime);


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
        /// <param name="level">层级ID</param>
        /// <param name="orgid">组织机构ID</param>
        /// <param name="siteid">地点ID</param>
        /// <returns></returns>
        IDataReader FindMeasurePointsByLevel(int level,string orgid,string siteid);

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
        /// 获取指定计量器的最后记录值
        /// </summary>
        /// <param name="pointnum">记录器编号</param>
        /// <returns></returns>
        IDataReader FindLastMeasurement(string pointnum);

        /// <summary>
        /// 获取指定查询条件的读表数据
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="pageindex">当前页</param>
        /// <param name="pagesize">每页显示数</param>
        /// <param name="recordcount">总条数</param>
        /// <returns></returns>
        DataTable FindMeasurementByCondition(string condition, string type,int pageindex, int pagesize, out int recordcount);

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
        DataSet FindMeasurementByPointnum(string pointnum,string startdate,string enddate, string type, int pageindex, int pagesize);

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
        DataSet FindMeasurementByAllPoint(string startdate, string enddate, string type, int pageindex, int pagesize);

        /// <summary>
        /// 获取指定时间内的的测量数据
        /// </summary>
        /// <param name="startdate">开始时间</param>
        /// <param name="enddate">结束时间</param>
        /// <returns></returns>
        IDataReader FindMeasurementByDate(string startdate, string enddate,ReportType reportType);

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
        /// <param name="reportType">查询方式</param>
        /// <returns></returns>
        DataTable GetMeasurementReport(string startdate, string enddate, ReportType reportType);

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
        bool DeleteAnalyzeSettingInfoByUser(int userid, string orgid);

        /// <summary>
        /// 查找分析设置信息
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="orgid">组织机构ID</param>
        /// <returns>分析设置信息</returns>
        IDataReader FindAnalyzeSettingInfo(int userid,string orgid);

        /// <summary>
        /// 查找报警信息
        /// </summary>
        /// <param name="orgid">机构ID</param>
        /// <returns></returns>
        DataSet FindAlarmlogInfo(string startdate, string enddate,string pointnum, int status, string orgid, int pageindex, int pagesize);
    }
}
