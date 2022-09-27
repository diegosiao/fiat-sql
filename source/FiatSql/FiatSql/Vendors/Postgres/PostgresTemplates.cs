namespace Slink.Vendors.Postgres
{
    public class PostgresTemplates : ISlinkTemplates
    {
        public string ProcedureTemplate =>
@$"CREATE OR REPLACE FUNCTION _#schema#_._#name#_(
_#parameters#_
)
RETURNS INT4
LANGUAGE plpgsql
AS $function$
BEGIN
{ISlinkTemplates.DefaultNotes}

_#body#_

  RETURN 0;
END;
$function$
;";

        public string DropProcedureTemplate => "DROP FUNCTION _#schema#_._#name#_;";
    }
}
