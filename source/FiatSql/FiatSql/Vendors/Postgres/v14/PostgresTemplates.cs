namespace FiatSql.Vendors.Postgres.v14
{
    public class PostgresTemplates : IFiatTemplates
    {
        public string ProcedureTemplate => 
@"CREATE OR REPLACE FUNCTION _#name#_(
_#parameters#_
)
RETURNS INT4
LANGUAGE plpgsql
AS $function$
BEGIN
  -- FIATSQL:HASH _#hash#_

_#body#_

  RETURN 0;
END;
$function$
;";
    }
}
