namespace Slink.Vendors.Postgres
{
    public class PostgresTemplates : IFiatTemplates
    {
        public string ProcedureTemplate =>
@$"CREATE OR REPLACE FUNCTION _#name#_(
_#parameters#_
)
RETURNS INT4
LANGUAGE plpgsql
AS $function$
BEGIN
{IFiatTemplates.DefaultNotes}

_#body#_

  RETURN 0;
END;
$function$
;";
    }
}
