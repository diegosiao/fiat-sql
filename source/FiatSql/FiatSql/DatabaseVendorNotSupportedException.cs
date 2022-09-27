using System;

namespace Slink
{
    internal class DatabaseVendorNotSupportedException : Exception
    {
        public DatabaseVendorNotSupportedException(
            SlinkVendors vendor = SlinkVendors.Undefined, 
            string message = "The database vendor '{0}' is not yet supported. ") 
            : base(string.Format(message, vendor))
        {
            HelpLink = "https://github.com/diegosiao/csql/help/database-support";
        }
    }
}
