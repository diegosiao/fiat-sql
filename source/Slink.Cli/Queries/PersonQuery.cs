using Slink.Cli.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Slink.Cli.Queries
{
    public class PersonQuery : SlinkQuery<PersonQuery>
    {
        [SlinkFrom]
        public PersonEntity Person;

        [SlinkJoin]
        public AddressEntity HomeAddress;

        [SlinkJoin]
        public AddressEntity WorkAddress;

        [SlinkJoinToMany(
            relationEntity: typeof(PersonCarRelationEntity), 
            fromColumn: nameof(PersonCarRelationEntity.PersonId), 
            onColumn: nameof(PersonCarRelationEntity.CarId))]
        public IEnumerable<CarEntity> Cars;

        public static async Task<SlinkQueryResult<PersonQuery>> WithValidatedAdressesAsync(DateTime createdAfter)
        {
            return await Where(x => x.HomeAddress.Validated == true)
                .And(x => x.Person.Creation >= createdAfter)
                .And(x => x.Person.Salary > 9999.999M)
                .OrderByAsc(x => x.Person.Name, x => x.Person.Birth, x => x.Person.Creation)
                .Exec();
        }
    }
}
