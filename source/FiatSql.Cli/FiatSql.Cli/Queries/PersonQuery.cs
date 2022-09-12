using FiatSql.Cli.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FiatSql.Cli.Queries
{
    public class PersonQuery : FiatSqlQuery<PersonQuery>
    {
        [FiatSqlFrom]
        public PersonEntity Person;

        [FiatSqlJoin]
        public AddressEntity HomeAddress;

        [FiatSqlJoin]
        public AddressEntity WorkAddress;

        [FiatSqlJoinToMany(
            relationEntity: typeof(PersonCarRelationEntity), 
            fromColumn: nameof(PersonCarRelationEntity.PersonId), 
            onColumn: nameof(PersonCarRelationEntity.CarId))]
        public IEnumerable<CarEntity> Cars;

        public static async Task<FiatSqlQueryResult<PersonQuery>> WithValidatedAdressesAsync(DateTime createdAfter)
        {
            return await Where(x => x.HomeAddress.Validated == true)
                .And(x => x.Person.Creation >= createdAfter)
                .And(x => x.Person.Salary > 9999.999M)
                .OrderByAsc(x => x.Person.Name, x => x.Person.Birth, x => x.Person.Creation)
                .Exec();
        }
    }
}
