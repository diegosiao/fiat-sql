using System;
using System.Data;

namespace Slink
{
    public class DatabaseVendorDbTypeNotSupportedException : Exception
    {
        public DatabaseVendorDbTypeNotSupportedException(DbType dbType) : base($"Type not supported: {dbType}")
        {

        }
    }
}
