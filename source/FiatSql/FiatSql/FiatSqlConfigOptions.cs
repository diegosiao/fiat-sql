using Slink.Vendors;
using Slink.Vendors.Postgres;
using System;
using System.Data;

namespace Slink
{
    public class SlinkConfigOptions
    {
        public FiatSqlVendors Vendor { get; set; }

        internal IFiatTemplates Templates 
        { 
            get
            {
                switch (Vendor)
                {
                    case FiatSqlVendors.Postgres:
                        return new PostgresTemplates();
                    case FiatSqlVendors.MySQL:
                    case FiatSqlVendors.SqlServer:
                    default:
                        throw new Exception();
                }
            } 
        }

        public string[] ProceduresNamespaces { get; set; }

        public string[] EntitiesNamespaces { get; set; }

        /// <summary>
        /// If true, even queries and entity CRUD operations will be translated and compiled into Slink managed Stored Procedures.
        /// <para>Chances are this project will not support operations outside Stored Procedures because it is philosophically contradictory.</para>
        /// <para>Default value is true.</para>
        /// </summary>
        public bool StoredProceduresOnly { get; set; }

        /// <summary>
        /// The name of the table 
        /// </summary>
        public string ManagementTable { get; set; }

        public string EntityManagementTable { get; set; }

        public string ProcedureManagementTable { get; set; }

        public uint? DefaultIdentation { get; set; }

        public Func<IDbConnection> ConnectionFactory { get; set; }

        public string ConnectionString { get; set; }

        public bool SkipShemaValidation { get; set; }

        public bool SkipProcedureValidation { get; set; }

        public FiatNamingPolicy NamingPolicy { get; set; }

        private IFiatSqlWriter _writer;

        public IFiatSqlWriter Writer 
        {
            get
            {
                switch (Vendor)
                {
                    case FiatSqlVendors.Postgres:
                        return _writer ??= new PostgresSqlWriter();
                    case FiatSqlVendors.MySQL:
                    case FiatSqlVendors.SqlServer:
                    default:
                        throw new Exception($"Vendor not implemented {Vendor}");
                }
            }
        }

        public SlinkConfigOptions()
        {
            // Default values
            NamingPolicy = FiatNamingPolicy.Lowercase;
            
            ManagementTable = "FiatManagement".Np();
            EntityManagementTable = "FiatManagementEntity".Np();
            ProcedureManagementTable = "FiatManagementProcedure".Np();

            StoredProceduresOnly = true;
        }
    }
}
