using FiatSql.Vendors;
using FiatSql.Vendors.Postgres;
using System;
using System.Data;

namespace FiatSql
{
    public class FiatSqlConfigOptions
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

        public FiatSqlConfigOptions()
        {
            // Default values
            NamingPolicy = FiatNamingPolicy.Lowercase;
            
            ManagementTable = "FiatManagement".Np();
            EntityManagementTable = "FiatManagementEntity".Np();
            ProcedureManagementTable = "FiatManagementProcedure".Np();
        }
    }
}
