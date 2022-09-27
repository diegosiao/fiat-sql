using Slink.Cli.Entities;

namespace Slink.Cli.Commands
{
    /// <summary>
    /// Runs in a TRANSACTION.
    /// Keep it clean. Keep it simple.
    /// </summary>
    public class CustomerCreateCommand : FiatSqlCommand
    {
        public OutParameterVarchar Error { get; set; }

        /// <summary>
        /// Implicit IN parameters.
        /// Implicit COMMIT.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="car"></param>
        public CustomerCreateCommand(
            PersonEntity person,
            CarEntity car,
            PersonCarRelationEntity personCarRelation,
            SlinkConfigOptions options = null) : base(options)
        {
            // Implement this
            Insert(person);

            Insert(car);

            Insert(personCarRelation);

            /****************************
            TODO Remove this PoC approach
            *****************************/
            Execute(new FiatInsert<PersonEntity>(person));
            
            Execute(new FiatInsert<CarEntity>(car));

            Execute(new FiatInsert<PersonCarRelationEntity>(personCarRelation));
        }
    }
}
