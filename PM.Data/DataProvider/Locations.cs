using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using PM.Data;
using PM.Config;
using PM.Common;
using PM.Entity;

namespace PM.Data
{
    public class Locations
    {
        public static DataTable FindLocationsByCondition(string condition)
        {
            return DatabaseProvider.GetInstance().FindLocationsByCondition(condition);
        }

        public static IDataReader FindLocationsListByCondition(string condition)
        {
            return DatabaseProvider.GetInstance().FindLocationsListByCondition(condition);
        }

        public static IDataReader FindLocationsByOrgId(string orgid)
        {
            return DatabaseProvider.GetInstance().FindLocationsByOrgId(orgid);
        }

        public static LocationInfo GetLocationInfo(long locationsid)
        {
            if (locationsid <= 0)
                return null;
            LocationInfo locationInfo = null;
            IDataReader reader = DatabaseProvider.GetInstance().FindLocationById(locationsid);
            if (reader.Read()) {
                locationInfo = LoadlocationInfo(reader);
                reader.Close();
            }

            return locationInfo;
        }

        public static LocationInfo LoadlocationInfo (IDataReader reader) {
            LocationInfo locationInfo = new LocationInfo();
            locationInfo.Locationsid = reader.GetInt64(reader.GetOrdinal("LOCATIONSID"));
            locationInfo.Location = reader["LOCATION"].ToString();
            locationInfo.Description = reader["DESCRIPTION"].ToString();
            locationInfo.Type = reader["TYPE"].ToString();
            locationInfo.Disabled = Convert.ToBoolean(reader["DISABLED"]);
            locationInfo.Externalrefid = reader["EXTERNALREFID"].ToString();
            locationInfo.Isrepairfacility = Convert.ToBoolean(reader["ISREPAIRFACILITY"]);
            locationInfo.X = reader["X"].ToString();
            locationInfo.Y = reader["Y"].ToString();
            locationInfo.Z = reader["Z"].ToString();
            locationInfo.Orgid = reader["ORGID"].ToString();
            locationInfo.Ownersysid = reader["OWNERSYSID"].ToString();
            locationInfo.Sendersysid = reader["SENDERSYSID"].ToString();
            locationInfo.Serviceaddresscode = reader["SERVICEADDRESSCODE"].ToString();
            locationInfo.Siteid = reader["SITEID"].ToString();
            locationInfo.Sourcesysid = reader["SOURCESYSID"].ToString();
            locationInfo.Status = reader["STATUS"].ToString();
            locationInfo.Statusdate = TypeConverter.StrToDateTime(reader["STATUSDATE"].ToString(), DateTime.Parse("1900-01-01")); 
            locationInfo.Changeby = reader["CHANGEBY"].ToString();
            locationInfo.Changedate = TypeConverter.StrToDateTime(reader["CHANGEDATE"].ToString(), DateTime.Parse("1900-01-01"));
            locationInfo.Parent = reader["PARENT"].ToString();
            locationInfo.Children = TypeConverter.StrToBool(reader["CHILDREN"].ToString(), false);
            
            
            return locationInfo;
        }


        public static IDataReader FindLocationsByOrgIdAndType(string orgid, string type) {
            return DatabaseProvider.GetInstance().FindLocationsByOrgIdAndType(orgid, type);
        }

        public static bool CreateLocation(LocationInfo locationInfo)
        {
            return DatabaseProvider.GetInstance().CreateLocation(locationInfo);
        }

        public static bool UpdateLocation(LocationInfo locationInfo)
        {
            return DatabaseProvider.GetInstance().UpdateLocation(locationInfo);
        }

        public static int DeleteLocation(string idList)
        {
            return DatabaseProvider.GetInstance().DeleteLocation(idList);
        }

        public static int LocationsCount(string condition)
        {
            return DatabaseProvider.GetInstance().LocationsCount(condition);
        }
    }
}
