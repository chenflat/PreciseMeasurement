using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using PM.Entity;
using PM.Common;
namespace PM.Data
{
    public class MeasureUnit
    {
        public static IDataReader FindAllMeasureUnits() {
            return DatabaseProvider.GetInstance().FindAllMeasureUnits();
        }

        public static DataTable FindAllMeasureUnitListDataTable() {
            return DatabaseProvider.GetInstance().FindAllMeasureUnitListDataTable();
        }


        public static IDataReader FindMeasureUnitByAbbreviation(string abbreviation)
        {
            return DatabaseProvider.GetInstance().FindMeasureUnitByAbbreviation(abbreviation);
        }

        public static IDataReader FindMeasureUnitByDescription(string description) {
            return DatabaseProvider.GetInstance().FindMeasureUnitByDescription(description);
        }

        public static MeasureUnitInfo GetMeasureunitInfo(long id) {
            if (id <= 0)
                return null;
            
            MeasureUnitInfo measureunitInfo = null;
            IDataReader reader = DatabaseProvider.GetInstance().FindMeasureUnitById(id);
             if (reader.Read())
            {
                measureunitInfo = LoadMeasureunitInfo(reader);
                reader.Close();
            }

            return measureunitInfo;

        }

        public static MeasureUnitInfo LoadMeasureunitInfo(IDataReader reader)
        {
            MeasureUnitInfo measureunitInfo = new MeasureUnitInfo();
            measureunitInfo.Measureunituid = reader.GetInt64(reader.GetOrdinal("MEASUREUNITUID"));
            measureunitInfo.Contentuid = reader["CONTENTUID"].ToString();
            measureunitInfo.Measureunitid = reader["MEASUREUNITID"].ToString();
            measureunitInfo.Description = reader["DESCRIPTION"].ToString();
            measureunitInfo.Abbreviation = reader["ABBREVIATION"].ToString();
            measureunitInfo.Displaysequence = TypeConverter.ObjectToInt(reader["DISPLAYSEQUENCE"].ToString());
            measureunitInfo.Type = reader["TYPE"].ToString();
            measureunitInfo.IsCalculate = Convert.ToBoolean(reader["ISCALCULATE"]);
            measureunitInfo.Visabled = Convert.ToBoolean(reader["VISABLED"]);
            measureunitInfo.IsMainParam = Convert.ToBoolean(reader["ISMAINPARAM"]); 
            measureunitInfo.Orgid = reader["ORGID"].ToString();
            measureunitInfo.Siteid = reader["SITEID"].ToString();
            return measureunitInfo;
        }

        public static long CreateMeasureUnit(MeasureUnitInfo measureunitInfo) {
            return DatabaseProvider.GetInstance().CreateMeasureUnit(measureunitInfo);
        }

        public static long UpdateMeasureUnit(MeasureUnitInfo measureunitInfo) {
            return DatabaseProvider.GetInstance().UpdateMeasureUnit(measureunitInfo);  
        }

        public static long DeleteMeasureUnit(long id) {
            return DatabaseProvider.GetInstance().DeleteMeasureUnit(id);
        }
    }
}
