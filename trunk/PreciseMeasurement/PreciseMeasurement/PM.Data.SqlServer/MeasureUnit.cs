using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using PM.Data;
using PM.Config;
using PM.Common;
using PM.Entity;

namespace PM.Data.SqlServer
{
    public partial class DataProvider : IDataProvider 
    {

        #region IDataProvider MeasureUnit 成员


        public IDataReader FindAllMeasureUnits()
        {
            string commandText = string.Format("SELECT {0} FROM [MEASUREUNIT] ORDER BY [DISPLAYSEQUENCE] ASC",
                                               DbFields.MEASUREUNIT);
            return DbHelper.ExecuteReader(System.Data.CommandType.Text, commandText);
        }

        public DataTable FindAllMeasureUnitListDataTable()
        {
            string commandText = string.Format("SELECT {0} FROM [MEASUREUNIT] ORDER BY [DISPLAYSEQUENCE] ASC",
                                               DbFields.MEASUREUNIT);

            return DbHelper.ExecuteDataset(CommandType.Text, commandText).Tables[0];
        }

        public IDataReader FindMeasureUnitByAbbreviation(string abbreviation)
        {
            DbParameter param = DbHelper.MakeInParam("@ABBREVIATION", (DbType)SqlDbType.VarChar, 8, abbreviation);
            string commandText = string.Format("SELECT {0} FROM [MEASUREUNIT] WHERE ABBREVIATION=@ABBREVIATION ORDER BY [DISPLAYSEQUENCE] ASC",
                                              DbFields.MEASUREUNIT);
            return DbHelper.ExecuteReader(CommandType.Text, commandText, param);
        }

        public IDataReader FindMeasureUnitByDescription(string description)
        {
            DbParameter param = DbHelper.MakeInParam("@DESCRIPTION", (DbType)SqlDbType.VarChar, 100, description);
            string commandText = string.Format("SELECT {0} FROM [MEASUREUNIT] WHERE DESCRIPTION=@DESCRIPTION ORDER BY [DISPLAYSEQUENCE] ASC",
                                              DbFields.MEASUREUNIT);
            return DbHelper.ExecuteReader(CommandType.Text, commandText, param);
        }

        public IDataReader FindMeasureUnitById(long id)
        {
            DbParameter param = DbHelper.MakeInParam("@MEASUREUNITUID", (DbType)SqlDbType.BigInt, 8, id);
            string commandText = string.Format("SELECT {0} FROM [MEASUREUNIT] WHERE MEASUREUNITUID=@MEASUREUNITUID",
                                              DbFields.MEASUREUNIT);
            return DbHelper.ExecuteReader(CommandType.Text, commandText, param);
        }

        public long CreateMeasureUnit(Entity.MeasureUnitInfo measureunitInfo)
        {
            DbParameter[] parms = { 
                                  DbHelper.MakeInParam("@CONTENTUID", (DbType)SqlDbType.VarChar, 50, measureunitInfo.Contentuid),
                                  DbHelper.MakeInParam("@MEASUREUNITID", (DbType)SqlDbType.VarChar, 16, measureunitInfo.Measureunitid),
                                  DbHelper.MakeInParam("@DESCRIPTION", (DbType)SqlDbType.VarChar, 100, measureunitInfo.Description),
                                  DbHelper.MakeInParam("@ABBREVIATION", (DbType)SqlDbType.Int, 4, measureunitInfo.Abbreviation),
                                  DbHelper.MakeInParam("@DISPLAYSEQUENCE", (DbType)SqlDbType.Int, 4, measureunitInfo.Displaysequence),
                                  DbHelper.MakeInParam("@ISCALCULATE", (DbType)SqlDbType.TinyInt, 1, measureunitInfo.IsCalculate),
                                  DbHelper.MakeInParam("@VISABLED", (DbType)SqlDbType.TinyInt, 1, measureunitInfo.Visabled),
                                  DbHelper.MakeInParam("@ISMAINPARAM", (DbType)SqlDbType.TinyInt, 1, measureunitInfo.IsMainParam),
                                  DbHelper.MakeInParam("@TYPE", (DbType)SqlDbType.VarChar, 8, measureunitInfo.Type),
                                  DbHelper.MakeInParam("@ORGID", (DbType)SqlDbType.VarChar, 8, measureunitInfo.Orgid),
                                  DbHelper.MakeInParam("@SITEID", (DbType)SqlDbType.VarChar, 8, measureunitInfo.Siteid)

                                  };
            string commandText = string.Format("INSERT INTO [{0}MEASUREUNIT] ([CONTENTUID],[MEASUREUNITID],[DESCRIPTION],[ABBREVIATION],[DISPLAYSEQUENCE],[ISCALCULATE],[VISABLED],[ISMAINPARAM],[TYPE],[ORGID],[SITEID]) VALUES(@CONTENTUID, @MEASUREUNITID, @DESCRIPTION, @ABBREVIATION, @DISPLAYSEQUENCE,@ISCALCULATE,@VISABLED,@ISMAINPARAM,@TYPE, @ORGID, @SITEID)", BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms);
        }

        public long UpdateMeasureUnit(Entity.MeasureUnitInfo measureunitInfo)
        {
            DbParameter[] parms = { 
                                  DbHelper.MakeInParam("@MEASUREUNITUID", (DbType)SqlDbType.BigInt, 8, measureunitInfo.Measureunituid),
                                  DbHelper.MakeInParam("@CONTENTUID", (DbType)SqlDbType.VarChar, 50, measureunitInfo.Contentuid),
                                  DbHelper.MakeInParam("@MEASUREUNITID", (DbType)SqlDbType.VarChar, 16, measureunitInfo.Measureunitid),
                                  DbHelper.MakeInParam("@DESCRIPTION", (DbType)SqlDbType.VarChar, 100, measureunitInfo.Description),
                                  DbHelper.MakeInParam("@ABBREVIATION", (DbType)SqlDbType.VarChar, 8, measureunitInfo.Abbreviation),
                                  DbHelper.MakeInParam("@DISPLAYSEQUENCE", (DbType)SqlDbType.Int, 4, measureunitInfo.Displaysequence),
                                  DbHelper.MakeInParam("@ISCALCULATE", (DbType)SqlDbType.TinyInt, 1, measureunitInfo.IsCalculate),
                                  DbHelper.MakeInParam("@VISABLED", (DbType)SqlDbType.TinyInt, 1, measureunitInfo.Visabled),
                                  DbHelper.MakeInParam("@ISMAINPARAM", (DbType)SqlDbType.TinyInt, 1, measureunitInfo.IsMainParam),
                                  DbHelper.MakeInParam("@ORGID", (DbType)SqlDbType.VarChar, 8, measureunitInfo.Orgid),
                                  DbHelper.MakeInParam("@SITEID", (DbType)SqlDbType.VarChar, 8, measureunitInfo.Siteid)
                                  };
            string commandText = string.Format("UPDATE [{0}MEASUREUNIT] SET [CONTENTUID]=@CONTENTUID, [MEASUREUNITID]=@MEASUREUNITID,[DESCRIPTION]=@DESCRIPTION,[ABBREVIATION]=@ABBREVIATION,[DISPLAYSEQUENCE]=@DISPLAYSEQUENCE,[ORGID]=@ORGID,[SITEID]=@SITEID,[ISCALCULATE]=@ISCALCULATE,[VISABLED]=@VISABLED,[ISMAINPARAM]=@ISMAINPARAM WHERE [MEASUREUNITUID]=@MEASUREUNITUID",
                                                BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms);
        }

        public int DeleteMeasureUnit(long id)
        {
            if (!Utils.IsNumeric(id))
                return 0;
            string commandText = string.Format("DELETE FROM [{0}MEASUREUNIT] WHERE [MEASUREUNITUID]='{1}'",
                                                BaseConfigs.GetTablePrefix,
                                                id);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText);
        }

        #endregion

    }
}
