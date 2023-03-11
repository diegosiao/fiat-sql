using Helix.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.Engine.Configuration
{
    public class GlobalConfiguration 
    {
        public DatabaseConfiguration[] Databases { get; set; }

        public bool Validate()
        {
            return Databases != null && Databases.Any();
        }
    }


    public class DatabaseConfiguration
    {
        public string Name { get; set; }

        public string Schema { get; set; }

        public DatabaseVendor Vendor { get; set; }

        public string DomainNamespace { get; set; }

        public string ConnectionString { get; set; }

        /// <summary>
        /// Temp solution
        /// </summary>
        public string BaseDirectory { get; set; }
    }
}
