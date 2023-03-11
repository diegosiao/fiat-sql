using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.Common
{
    public static class ConnectionFactory
    {
        public static DbConnection GetNew(string connectionString, DatabaseVendor vendor)
        {
            switch (vendor)
            {
                //string assemblyName, string typeName, bool ignoreCase, BindingFlags bindingAttr, Binder? binder, object?[]? args,
                case DatabaseVendor.Postgres:

                    //var connection = Activator.CreateInstance(
                    //    assemblyName: "Npgsql, Version=7.0.2.0, Culture=neutral, PublicKeyToken=5d8b90d52f46fda7", 
                    //    typeName: "NpgsqlConnection", 
                    //    ignoreCase: true, 
                    //    bindingAttr: System.Reflection.BindingFlags.Default, 
                    //    binder: null,
                    //    args: new object?[] { connectionString },
                    //    culture: null,
                    //    activationAttributes: null)?.Unwrap() as DbConnection;

                    //if (connection == null)
                    //    throw new ArgumentException("Error creating the specified connection. ");

                    return new NpgsqlConnection(connectionString);
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
