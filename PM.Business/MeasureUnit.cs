using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PM.Entity;
using PM.Data;
using PM.Common;

namespace PM.Business
{
    /// <summary>
    /// 计量单位业务逻辑操作类
    /// </summary>
    public class MeasureUnit
    {
        public static DataTable FindAllMeasureUnitListDataTable() {
            return Data.MeasureUnit.FindAllMeasureUnitListDataTable();
        }

        public static List<MeasureUnitInfo> GetMeasureunitList(string description) {
            List<MeasureUnitInfo> listAll = new List<MeasureUnitInfo>();
            IDataReader reader = null;
            if (Utils.HasLength(description))
            {
                reader = Data.MeasureUnit.FindMeasureUnitByDescription(description);
            }
            else {
                reader = Data.MeasureUnit.FindAllMeasureUnits();
            }

            using (reader)
            {
                while (reader.Read())
                {
                    MeasureUnitInfo measureunitInfo = Data.MeasureUnit.LoadMeasureunitInfo(reader);
                    listAll.Add(measureunitInfo);
                }
                reader.Close();
            }
            return listAll;
        }

        public static MeasureUnitInfo GetMeasureunitInfo(long id) {
            return id >0 ? Data.MeasureUnit.GetMeasureunitInfo(id) : null;
        }

        public static long CreateMeasureUnit(MeasureUnitInfo measureunitInfo) {
            return Data.MeasureUnit.CreateMeasureUnit(measureunitInfo);
        }

        public static long UpdateMeasureUnit(MeasureUnitInfo measureunitInfo) {
            return Data.MeasureUnit.UpdateMeasureUnit(measureunitInfo);
        }

        public static long DeleteMeasureUnit(long id) {
            return Data.MeasureUnit.DeleteMeasureUnit(id);
        }
    }
}
