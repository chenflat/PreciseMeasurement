using System;
using System.Data;
using System.Reflection;

namespace PM.Data
{
    public class DataReaderExtender : IDataReader, IDisposable, IDataRecord
    {
        private IDataReader reader;

        public DataReaderExtender()
        {

        }

        public DataReaderExtender(IDataReader _reader)
        {
            this.reader = _reader;
        }

        #region IDataReader 成员

        public void Close()
        {
            reader.Close();
        }

        public int Depth
        {
            get { return reader.Depth; }
        }

        public DataTable GetSchemaTable()
        {
            return reader.GetSchemaTable();
        }

        public bool IsClosed
        {
            get { return reader.IsClosed; }
        }

        public bool NextResult()
        {
            return reader.NextResult();
        }

        public bool Read()
        {
            return reader.Read();
        }

        public int RecordsAffected
        {
            get { return reader.RecordsAffected; }
        }

        #endregion

        #region IDisposable 成员

        public void Dispose()
        {
            if (reader != null)
                reader.Dispose();
        }

        #endregion

        #region IDataRecord 成员

        public int FieldCount
        {
            get { return reader.FieldCount; }
        }

        public bool GetBoolean(int i)
        {
            return reader.GetBoolean(i);
        }

        public bool GetBoolean(string name)
        {
            bool ret = false;
            if (!this.IsDBNull(name))
            {
                ret = GetBoolean(reader.GetOrdinal(name));
            }
            return ret;
        }

        public byte GetByte(int i)
        {
            return reader.GetByte(i);
        }

        public byte GetByte(string name)
        {
            return GetByte(reader.GetOrdinal(name));
        }

        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            return reader.GetBytes(i, fieldOffset, buffer, bufferoffset, length);
        }

        public char GetChar(int i)
        {
            return reader.GetChar(i);
        }

        public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            return reader.GetChars(i, fieldoffset, buffer, bufferoffset, length);
        }

        public IDataReader GetData(int i)
        {
            return GetData(i);
        }

        public string GetDataTypeName(int i)
        {
            return reader.GetDataTypeName(i);
        }

        public string GetDataTypeName(string name)
        {
            return reader.GetDataTypeName(reader.GetOrdinal(name));
        }

        public DateTime GetDateTime(int i)
        {
            return reader.GetDateTime(i);
        }

        public DateTime GetDateTime(string name)
        {
            if (this.IsDBNull(name))
                return DateTime.Now;
            return reader.GetDateTime(reader.GetOrdinal(name));
        }

        public decimal GetDecimal(int i)
        {
            return reader.GetDecimal(i);
        }

        public decimal GetDecimal(string name)
        {
            decimal @decimal = 0M;
            if (this.IsDBNull(name))
                return @decimal;
            return reader.GetDecimal(reader.GetOrdinal(name));
        }

        public double GetDouble(int i)
        {
            return reader.GetDouble(i);
        }

        public double GetDouble(string name)
        {
            double d = 0.0;
            if (this.IsDBNull(name))
                return d;
            return reader.GetDouble(reader.GetOrdinal(name));
        }

        public Type GetFieldType(int i)
        {
            return reader.GetFieldType(i);
        }

        public Type GetFieldType(string name)
        {
            return reader.GetFieldType(reader.GetOrdinal(name));
        }

        public float GetFloat(int i)
        {
            return reader.GetFloat(i);
        }

        public float GetFloat(string name)
        {
            float @float = 0f;
            if (this.IsDBNull(name))
                return @float;
            return reader.GetFloat(reader.GetOrdinal(name));
        }

        public Guid GetGuid(int i)
        {
            return reader.GetGuid(i);
        }

        public Guid GetGuid(string name)
        {
            return reader.GetGuid(reader.GetOrdinal(name));
        }

        public short GetInt16(int i)
        {
            return reader.GetInt16(i);
        }

        public short GetInt16(string name)
        {
            if (this.IsDBNull(name))
                return 0;
            return reader.GetInt16(reader.GetOrdinal(name));
        }

        public int GetInt32(int i)
        {
            return reader.GetInt32(i);
        }

        public int GetInt32(string name)
        {
            if (this.IsDBNull(name))
                return 0;
            return reader.GetInt32(reader.GetOrdinal(name));
        }

        public long GetInt64(int i)
        {
            return reader.GetInt64(i);
        }

        public long GetInt64(string name)
        {
            if (this.IsDBNull(name))
                return 0L;
            return reader.GetInt64(reader.GetOrdinal(name));
        }

        public string GetName(int i)
        {
            return reader.GetName(i);
        }

        public int GetOrdinal(string name)
        {
            return reader.GetOrdinal(name);
        }

        public string GetString(int i)
        {
            return reader.GetString(i);
        }

        public string GetString(string name)
        {
            if (this.IsDBNull(name))
                return string.Empty;
            return reader.GetString(reader.GetOrdinal(name));
        }

        public object GetValue(int i)
        {
            return reader.GetValue(i);
        }

        public object GetValue(string name)
        {
            return reader.GetValue(reader.GetOrdinal(name));
        }

        public int GetValues(object[] values)
        {
            throw new NotImplementedException();
        }

        public bool IsDBNull(int i)
        {
            return reader.IsDBNull(i);
        }

        public bool IsDBNull(string name)
        {
            return reader.IsDBNull(reader.GetOrdinal(name));
        }

        public object this[string name]
        {
            get { return this.reader[name]; }
        }

        public object this[int i]
        {
            get { return this.reader[i]; }
        }

        #endregion

        #region IDisposable 成员

        void IDisposable.Dispose()
        {
            if (reader != null)
                reader.Dispose();
        }

        #endregion
    }
}
