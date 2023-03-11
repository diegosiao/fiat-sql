using Helix.Core;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

/* * * * * * * * * * * * * * * * * * * ** 
 *                                      *
 *  THIS CLASS WAS GENERATED BY HELIX   *
 *                                      *
 *  DO NOT EDIT THIS CLASS!             *
 *                                      *
 *  For more information:               *
 *  https://github.com/diegosiao/helix  *
 *                                      *
 * * * * * * * * * * * * * * * * * * * **/


namespace Helix.Example.Persistence
{
    [SuppressMessage(
        "Style", "IDE1006:Naming Styles", Justification = "Helix 'never map' premise")]
	public sealed partial class car : DbTuple
	{
        [Key]
        public Guid id { get; set; }

        public string model { get; set; }

        public int? modelyear { get; set; }

        public string? plates { get; set; }

        public DateTime creation { get; set; }

        public string createdby { get; set; }

        public DateTime? lastupdate { get; set; }

        public string? lastupdatedby { get; set; }



        private const string INSERT_TEMPLATE =
            @"
                        INSERT INTO car (
                            id,
                            model,
                            modelyear,
                            plates,
                            creation,
                            createdby,
                            lastupdate,
                            lastupdatedby
                        ) 
                        VALUES (
                            @id,
                            @model,
                            @modelyear,
                            @plates,
                            @creation,
                            @createdby,
                            @lastupdate,
                            @lastupdatedby
                        )";

        private const string UPDATE_TEMPLATE =
            @"$$updateTemplate$$";

        private const string SELECT_TEMPLATE =
            @"$$selectTemplate$$";

        private const string DELETE_TEMPLATE =
            @"$$selectTemplate$$";

        public car() : base(
            INSERT_TEMPLATE,
            UPDATE_TEMPLATE,
            SELECT_TEMPLATE,
            DELETE_TEMPLATE) 
        { }
	}
}
