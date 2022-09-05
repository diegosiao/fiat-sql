using System;
using System.Data;

namespace FiatSql
{
    public class DatabaseVendorDbTypeNotSupportedException : Exception
    {
        public DatabaseVendorDbTypeNotSupportedException(DbType dbType) : base($"Type not supported: {dbType}")
        {

        }
    }
}
