using FiatSql.Cli.Entities;
using System.Diagnostics;

namespace FiatSql.Cli.Procedures
{
    /// <summary>
    /// Runs in a TRANSACTION.
    /// Keep it clean. Keep it simple.
    /// </summary>
    public class Sp_CustomerCreate : FiatSqlProcedure
    {
        public OutParameterVarchar Error { get; set; }

        /// <summary>
        /// Implicit IN parameters.
        /// Implicit COMMIT.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="car"></param>
        public Sp_CustomerCreate(
            PersonEntity person,
            CarEntity car,
            PersonCarRelationEntity personCarRelation,
            FiatSqlConfigOptions options = null) : base(options)
        {
            Execute(new FiatInsert<PersonEntity>(person));

            Execute(new FiatInsert<CarEntity>(car));

            Execute(new FiatInsert<PersonCarRelationEntity>(personCarRelation));

            Debug.WriteLine(BuildSql());
        }
    }
}
