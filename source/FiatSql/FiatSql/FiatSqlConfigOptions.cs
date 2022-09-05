using FiatSql.Vendors;
using FiatSql.Vendors.Postgres.v14;
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

        public string[] ProcedureNamespaces { get; set; }

        public string[] EntitiesNamespaces { get; set; }

        public uint? DefaultIdentation { get; set; }

        public Func<IDbConnection> ConnectionFactory { get; set; }

        public string ConnectionString { get; set; }

        public bool IgnoreProcedureValidation { get; set; }

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
    }
}
