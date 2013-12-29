using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PM.Data;
using PM.Config;
using PM.Common;
using PM.Entity;

namespace PM.Data {

    /// <summary>
    /// 类别层次结构定义
    /// </summary>
    public class Classstructure {

        /// <summary>
        /// 创建类别层次结构定义
        /// </summary>
        /// <param name="classstructureInfo">类别层次结构定义对象</param>
        /// <returns></returns>
        public static int CreateClassstructure(ClassstructureInfo classstructureInfo) { 
           return DatabaseProvider.GetInstance().CreateClassstructure(classstructureInfo);
        }

        /// <summary>
        /// 更新类别层次结构定义
        /// </summary>
        /// <param name="classstructureInfo">类别层次结构定义对象</param>
        /// <returns></returns>
        public static bool UpdateClassstructure(ClassstructureInfo classstructureInfo) {
            return DatabaseProvider.GetInstance().UpdateClassstructure(classstructureInfo);
        }

        /// <summary>
        /// 删除类别层次结构定义
        /// </summary>
        /// <param name="idList">结构主键ID，多个ID以","分隔</param>
        /// <returns></returns>
        public static int DeleteClassstructure(string idList) {
            return DatabaseProvider.GetInstance().DeleteClassstructure(idList);
        }

        /// <summary>
        /// 查找类别层次结构定义
        /// </summary>
        /// <param name="condition">查询条件SQL,以 and 开头</param>
        /// <returns></returns>
        public static DataTable FindClassstructureByCondition(string condition) {
            return DatabaseProvider.GetInstance().FindClassstructureByCondition(condition);
        }

        public static IDataReader FindClassstructureById(long classstructureuid) {
            string condition = string.Format(" and classstructureuid='{0}'",classstructureuid);
            return FindClassstructureByCondition(condition).CreateDataReader();
        }

        /// <summary>
        /// 返回类别结构对象
        /// </summary>
        /// <param name="classstructureuid">类别结构主键ID</param>
        /// <returns></returns>
        public static ClassstructureInfo GetClassstructureInfo(long classstructureuid) {
            if (classstructureuid <= 0)
                return null;
            ClassstructureInfo classstructureInfo = null;
            using (IDataReader reader = FindClassstructureById(classstructureuid)) {
                if (reader.Read()) {
                    classstructureInfo = LoadClassstructureInfo(reader);
                }

                reader.Close();
            }
            return classstructureInfo;
        }

        /// <summary>
        /// 加载类别结构对象
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static ClassstructureInfo LoadClassstructureInfo(IDataReader reader) {
            ClassstructureInfo classstructureInfo = new ClassstructureInfo();
            classstructureInfo.Classificationid = reader["Classificationid"].ToString();
            classstructureInfo.Classstructureid = reader["Classstructureid"].ToString();
            classstructureInfo.Classstructureuid = TypeConverter.ObjectToLong(reader["Classstructureuid"], 0);
            classstructureInfo.Description = reader["Description"].ToString();
            classstructureInfo.Genassetdesc = TypeConverter.StrToBool(reader["Genassetdesc"].ToString(),false);
            classstructureInfo.Haschildren = TypeConverter.StrToBool(reader["Haschildren"].ToString(), false);
            classstructureInfo.Hasld = TypeConverter.StrToBool(reader["Hasld"].ToString(), false);
            classstructureInfo.Langcode = reader["Langcode"].ToString();
            classstructureInfo.Orgid = reader["Orgid"].ToString();
            classstructureInfo.Parent = reader["Parent"].ToString();
            classstructureInfo.Siteid = reader["Siteid"].ToString();
            classstructureInfo.Type = reader["Type"].ToString();
            classstructureInfo.Useclassindesc = TypeConverter.StrToBool(reader["Useclassindesc"].ToString(), false);

            return classstructureInfo;
        }


    }
}
